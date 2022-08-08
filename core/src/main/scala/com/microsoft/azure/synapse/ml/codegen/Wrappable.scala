// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

package com.microsoft.azure.synapse.ml.codegen

import com.microsoft.azure.synapse.ml.core.env.FileUtilities
import com.microsoft.azure.synapse.ml.core.serialize.ComplexParam
import com.microsoft.azure.synapse.ml.param._
import org.apache.commons.lang.StringEscapeUtils
import org.apache.spark.ml.evaluation.Evaluator
import org.apache.spark.ml.param._
import org.apache.spark.ml.{Estimator, Model, Transformer}
import java.lang.reflect.ParameterizedType
import java.nio.charset.StandardCharsets
import java.nio.file.Files

import scala.collection.Iterator.iterate
import scala.collection.mutable
import scala.reflect.runtime.{universe => ru}

trait BaseWrappable[T] extends Params {

  import com.microsoft.azure.synapse.ml.codegen.DefaultParamInfo._

  private[ml] def wrappingType: ru.TypeTag[T]

  protected val thisStage: Params = this

  protected lazy val copyrightLines: String =
    s"""|# Copyright (C) Microsoft Corporation. All rights reserved.
        |# Licensed under the MIT License. See LICENSE in project root for information.
        |""".stripMargin

  protected lazy val classNameHelper: String = thisStage.getClass.getName.split(".".toCharArray).last

  protected def companionModelClassName: String = {
    val superClass = iterate[Class[_]](thisStage.getClass)(_.getSuperclass)
      .find(c => Set("Estimator", "ProbabilisticClassifier", "Predictor", "BaseRegressor", "Ranker")(
        c.getSuperclass.getSimpleName))
      .get
    val typeArgs = thisStage.getClass.getGenericSuperclass.asInstanceOf[ParameterizedType].getActualTypeArguments
    val modelTypeArg = superClass.getSuperclass.getSimpleName match {
      case "Estimator" =>
        typeArgs.head
      case model if Set("ProbabilisticClassifier", "BaseRegressor", "Predictor", "Ranker")(model) =>
        typeArgs.last
    }
    modelTypeArg.getTypeName
  }

  def getParamInfo(p: Param[_]): ParamInfo[_] = {
    try {
      thisStage.getClass.getMethod(p.name)
        .getAnnotatedReturnType.getType.toString match {
        case "org.apache.spark.ml.param.Param<java.lang.String>" => StringInfo
        case _ => getGeneralParamInfo(p)
      }
    } catch {
      case _: Exception => getGeneralParamInfo(p)
    }

  }

}

trait PythonWrappable[T] extends BaseWrappable[T] {

  import GenerationUtils._

  def pyAdditionalMethods: String = {
    ""
  }

  private[ml] def pyBasicMethods: String = {
    val myType = wrappingType.tpe

    // TODO: Overloading methods of the same name in a Python wrapper can be awkward.
    //  Only add once we're certain we need it.
    // TODO: The existing wrapping code probably adds some methods. We aren't tracking these here, and probably should.
    //  If we choose to put these back into the original code, then this problem will become easier to address.
    val wrappedNames = mutable.Set.empty[String]

    def asOptionMethod(s: ru.Symbol): Option[ru.MethodSymbol] = if (s.isMethod) Some(s.asMethod) else None

    val sbAll = new mutable.StringBuilder
    val sbDef = new mutable.StringBuilder
    val sbBody = new mutable.StringBuilder

    for (method <- myType.members.flatMap(asOptionMethod)) {
      for (wrapObj <- WrapUtils.getWrapForMethod(method)) {
        generateMethod(myType, method, wrapObj, wrappedNames, sbDef, sbBody)
        if (sbAll.nonEmpty) sbAll.append('\n')
        sbAll.append(sbDef)
        sbAll.append(sbBody)
      }
    }
    sbAll.result()
  }

  protected lazy val pyInternalWrapper = false

  protected lazy val pyClassName: String = {
    if (pyInternalWrapper) {
      "_" + classNameHelper
    } else {
      "" + classNameHelper
    }
  }

  protected lazy val pyObjectBaseClass: String = {
    thisStage match {
      case _: Estimator[_] => "JavaEstimator"
      case _: Model[_] => "JavaModel"
      case _: Transformer => "JavaTransformer"
      case _: Evaluator => "JavaEvaluator"
      case _ => "object"
    }
  }

  protected lazy val pyInheritedClasses: Seq[String] =
    Seq("ComplexParamsMixin", "JavaMLReadable", "JavaMLWritable", pyObjectBaseClass)

  // TODO add default values
  protected lazy val pyClassDoc: String = {
    val argLines = thisStage.params.map { p =>
      s"""${p.name} (${getParamInfo(p).pyType}): ${p.doc}"""
    }.mkString("\n")
    s"""|"\""
        |Args:
        |${indent(argLines)}
        |"\""
        |""".stripMargin
  }

  private def escape(raw: String): String = {
    StringEscapeUtils.escapeJava(raw)
  }

  protected lazy val pyParamsDefinitions: String = {
    thisStage.params.map { p =>
      val typeConverterString = getParamInfo(p).pyTypeConverter.map(", typeConverter=" + _).getOrElse("")
      p match {
        case sp: ServiceParam[_] =>
          // Helps when we call _transfer_params_to_java the underlying java_obj set service params correctly
          s"""|${sp.name} = Param(Params._dummy(), "${sp.name}", "ServiceParam: ${escape(sp.doc)}"$typeConverterString)
              |""".stripMargin
        case _ =>
          s"""|${p.name} = Param(Params._dummy(), "${p.name}", "${escape(p.doc)}"$typeConverterString)
              |""".stripMargin
      }
    }.mkString("\n")
  }

  protected def pyParamArg[P](p: Param[P]): String = {
    (p, thisStage.getDefault(p)) match {
      case (_: ServiceParam[_], _) =>
        s"${p.name}=None,\n${p.name}Col=None"
      case (_: ComplexParam[_], _) | (_, None) =>
        s"${p.name}=None"
      case (_, Some(v)) =>
        s"""${p.name}=${PythonWrappableParam.pyDefaultRender(v, p)}"""
    }
  }

  protected def pyParamDefault[P](p: Param[P]): Option[String] = {
    (p, thisStage.getDefault(p)) match {
      case (_: ServiceParam[_], _) =>
        None
      case (_: ComplexParam[_], _) | (_, None) =>
        None
      case (_, Some(v)) =>
        Some(s"""self._setDefault(${pyParamArg(p)})""")
    }
  }

  protected def pyParamsArgs: String =
    thisStage.params.map(pyParamArg(_)).mkString(",\n")

  protected def pyParamsDefaults: String =
    thisStage.params.flatMap(pyParamDefault(_)).mkString("\n")

  protected def pyParamSetter(p: Param[_]): String = {
    val capName = p.name.capitalize
    val docString =
      s"""|"\""
          |Args:
          |    ${p.name}: ${p.doc}
          |"\""
          |""".stripMargin
    // scalastyle:off line.size.limit
    p match {
      case _: ServiceParam[_] =>
        s"""|def set$capName(self, value):
            |${indent(docString)}
            |    if isinstance(value, list):
            |        value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
            |    self._java_obj = self._java_obj.set$capName(value)
            |    return self
            |
            |def set${capName}Col(self, value):
            |${indent(docString)}
            |    self._java_obj = self._java_obj.set${capName}Col(value)
            |    return self
            |""".stripMargin
      case _ =>
        s"""|def set${p.name.capitalize}(self, value):
            |${indent(docString)}
            |    self._set(${p.name}=value)
            |    return self
            |""".stripMargin
    }
    // scalastyle:on line.size.limit
  }

  protected def pyParamsSetters: String =
    thisStage.params.map(pyParamSetter).mkString("\n")

  protected def pyExtraEstimatorMethods: String = {
    thisStage match {
      case _: Estimator[_] =>
        s"""|def _create_model(self, java_model):
            |    try:
            |        model = ${companionModelClassName.split(".".toCharArray).last}(java_obj=java_model)
            |        model._transfer_params_from_java()
            |    except TypeError:
            |        model = ${companionModelClassName.split(".".toCharArray).last}._from_java(java_model)
            |    return model
            |
            |def _fit(self, dataset):
            |    java_model = self._fit_java(dataset)
            |    return self._create_model(java_model)
            |""".stripMargin
      case _ =>
        ""
    }
  }

  protected def pyExtraEstimatorImports: String = {
    thisStage match {
      case _: Estimator[_] =>
        val companionModelImport = companionModelClassName
          .replaceAllLiterally("com.microsoft.azure.synapse.ml", "synapse.ml")
          .replaceAllLiterally("org.apache.spark", "pyspark")
          .split(".".toCharArray)
        val path = if (companionModelImport.head == "pyspark") {
          companionModelImport.dropRight(1).mkString(".")
        } else {
          companionModelImport.mkString(".")
        }
        val modelName = companionModelImport.last
        s"from $path import $modelName"
      case _ =>
        ""
    }
  }

  protected def pyParamGetter(p: Param[_]): String = {
    val capName = p.name.capitalize
    val docString =
      s"""|"\""
          |Returns:
          |    ${p.name}: ${p.doc}
          |"\""
          |""".stripMargin
    p match {
      case _: DataFrameParam =>
        s"""|
            |def get$capName(self):
            |${indent(docString)}
            |    ctx = SparkContext._active_spark_context
            |    sql_ctx = SQLContext.getOrCreate(ctx)
            |    return DataFrame(self._java_obj.get$capName(), sql_ctx)
            |""".stripMargin
      case _: TransformerParam | _: EstimatorParam | _: PipelineStageParam =>
        s"""|
            |def get$capName(self):
            |${indent(docString)}
            |    return JavaParams._from_java(self._java_obj.get$capName())
            |""".stripMargin
      case _: ServiceParam[_] =>
        s"""|
            |def get$capName(self):
            |${indent(docString)}
            |    return self._java_obj.get$capName()
            |""".stripMargin
      case _ =>
        s"""|
            |def get$capName(self):
            |${indent(docString)}
            |    return self.getOrDefault(self.${p.name})
            |""".stripMargin
    }
  }

  protected def pyParamsGetters: String =
    thisStage.params.map(pyParamGetter).mkString("\n")

  def pyInitFunc(): String = {
    s"""
       |@keyword_only
       |def __init__(
       |    self,
       |    java_obj=None,
       |${indent(pyParamsArgs)}
       |    ):
       |    super($pyClassName, self).__init__()
       |    if java_obj is None:
       |        self._java_obj = self._new_java_obj("${thisStage.getClass.getName}", self.uid)
       |    else:
       |        self._java_obj = java_obj
       |${indent(pyParamsDefaults)}
       |    if hasattr(self, \"_input_kwargs\"):
       |        kwargs = self._input_kwargs
       |    else:
       |        kwargs = self.__init__._input_kwargs
       |
       |    if java_obj is None:
       |        for k,v in kwargs.items():
       |            if v is not None:
       |                getattr(self, "set" + k[0].upper() + k[1:])(v)
       |${indent(pyInitFuncJavaBridge())}
       |""".stripMargin

  }

  protected def pyInitFuncJavaBridge(): String = {
    "self._jvmv = pyspark.SparkContext.getOrCreate()._jvm"
  }

  //noinspection ScalaStyle
  protected def pythonClass(): String = {
    s"""|$copyrightLines
        |
        |import sys
        |if sys.version >= '3':
        |    basestring = str
        |
        |from pyspark import SparkContext, SQLContext
        |from pyspark.sql import DataFrame
        |from pyspark.ml.param.shared import *
        |from pyspark import keyword_only
        |from pyspark.ml.util import JavaMLReadable, JavaMLWritable
        |from synapse.ml.core.serialize.java_params_patch import *
        |from pyspark.ml.wrapper import JavaTransformer, JavaEstimator, JavaModel
        |from pyspark.ml.evaluation import JavaEvaluator
        |from pyspark.ml.common import inherit_doc
        |from synapse.ml.core.schema.Utils import *
        |from pyspark.ml.param import TypeConverters
        |from synapse.ml.core.schema.TypeConversionUtils import generateTypeConverter, complexTypeConverter
        |from py4j.java_collections import SetConverter, MapConverter, ListConverter
        |from typing import List, Optional
        |$pyExtraEstimatorImports
        |
        |@inherit_doc
        |class $pyClassName(${pyInheritedClasses.mkString(", ")}):
        |${indent(pyClassDoc, 1)}
        |
        |${indent(pyParamsDefinitions, 1)}
        |
        |${indent(pyInitFunc(), 1)}
        |
        |    @keyword_only
        |    def setParams(
        |        self,
        |${indent(pyParamsArgs, 2)}
        |        ):
        |        "\""
        |        Set the (keyword only) parameters
        |        "\""
        |        if hasattr(self, \"_input_kwargs\"):
        |            kwargs = self._input_kwargs
        |        else:
        |            kwargs = self.__init__._input_kwargs
        |        return self._set(**kwargs)
        |
        |    @classmethod
        |    def read(cls):
        |        "\"" Returns an MLReader instance for this class. "\""
        |        return JavaMMLReader(cls)
        |
        |    @staticmethod
        |    def getJavaPackage():
        |        "\"" Returns package name String. "\""
        |        return "${thisStage.getClass.getName}"
        |
        |    @staticmethod
        |    def _from_java(java_stage):
        |        module_name=$pyClassName.__module__
        |        module_name=module_name.rsplit(".", 1)[0] + ".$classNameHelper"
        |        return from_java(java_stage, module_name)
        |
        |${indent(pyParamsSetters, 1)}
        |
        |${indent(pyParamsGetters, 1)}
        |
        |${indent(pyExtraEstimatorMethods, 1)}
        |
        |${indent(pyBasicMethods, 1)}
        |${indent(pyAdditionalMethods, 1)}
        """.stripMargin
  }

  def makePyFile(conf: CodegenConfig): Unit = {
    val importPath = thisStage.getClass.getName.split(".".toCharArray).dropRight(1)
    val srcFolders = importPath.mkString(".")
      .replaceAllLiterally("com.microsoft.azure.synapse.ml", "synapse.ml").split(".".toCharArray)
    val srcDir = FileUtilities.join((Seq(conf.pySrcDir.toString) ++ srcFolders.toSeq): _*)
    srcDir.mkdirs()
    Files.write(
      FileUtilities.join(srcDir, pyClassName + ".py").toPath,
      pythonClass().getBytes(StandardCharsets.UTF_8))
  }

  /**
    * Given a parameter and possible default as well as any existing default,
    *
    * @param param             The symbol of the parameter in the method we are wrapping.
    * @param defaultOption     The default object. This will be translated to Python if possible.
    * @param firstDefaultParam The name of the first default parameter, if possible. This is used to generate a
    *                          comprehensible error message in case we try to wrap a method where
    * @param usedVarNames      A set of already utilized symbols, in case temporary values must be used.
    * @param sbDef             A side effect of this method is to append a parameter definition.
    * @param sbBody            A side effect of this method is to append translation code to this buffer, if necessary.
    * @return Either the first default parameter, if it was defined, or else this parameter name if
    */
  private def generateParam(param: ru.Symbol,
                            defaultOption: Option[Any],
                            firstDefaultParam: Option[String],
                            usedVarNames: => Set[String],
                            sbDef: mutable.StringBuilder,
                            sbBody: mutable.StringBuilder): Option[String] = {
    val pName = param.name.toString
    if (!PythonInterop.isGoodPythonName(pName)) {
      throw new IllegalArgumentException(s"The parameter name '$pName' cannot be used in Python. Consider" +
        s"an alternate name, or making a separate private passthrough method to wrap this.")
    }
    val trans = PythonInterop.getTranslator(param.typeSignature)
    val hint = trans.typeHint
    val litOption = defaultOption.map(d => trans.literalUnsafe(d))
    if (firstDefaultParam.isDefined && litOption.isEmpty) {
      throw new UnsupportedOperationException(s"No literal default encodable for parameter $pName but one " +
        s"was previously established for parameter ${firstDefaultParam.get}")
    }
    // Append the parameter to the definition list, optionally with a default value.
    sbDef.append(s", $pName${hint.map(": " + _).getOrElse("")}${litOption.map(" = " + _).getOrElse("")}")
    // Register the default parameter we just did, if we did, so we have a sensible error message to give if needed.
    // Add the conversion code to the method body, if needed.
    if (!trans.isPassthrough) {
      // We need the conversion code. Just replace the original variable.
      sbBody.append(indent(s"$pName = ${trans.wrapInput(pName, usedVarNames)}"))
      sbBody.append("\n")
    }
    if (firstDefaultParam.isDefined) firstDefaultParam else litOption.map(_ => pName)
  }

  /**
    * Generates code for a single method.
    *
    * @param myType          The type for which methods are being generated.
    * @param method          The specific method being generated inside this function.
    * @param wrapObj         The [[wrap]] annotation that was attached to this method.
    * @param usedMemberNames Members of this class. This method should add the Python method name to it at the end.
    * @param sbDef           As a post condition this contains the `def` section of the Python method.
    * @param sbBody          As a post condition this contains the body of the Python method.
    */
  private def generateMethod(myType: ru.Type,
                             method: ru.MethodSymbol,
                             wrapObj: wrap,
                             usedMemberNames: mutable.Set[String],
                             sbDef: mutable.StringBuilder,
                             sbBody: mutable.StringBuilder): Unit = {
    // The JVM object is not available in @classmethod objects in Python according to typical wrapping.
    // On the other hand, methods in Scala itself aren't really static.
    require(!method.isStatic, s"Cannot wrap method $method. It is static.")
    // Doing something clever __init__ might be possible in future. Right now though, not supported.
    require(!method.isConstructor, s"Cannot wrap constructor $method.")

    val pyName = wrapObj.overrideNameOption.getOrElse(method.name.toString)
    if (usedMemberNames.contains(pyName)) {
      throw new UnsupportedOperationException(s"Method ${method.name} would result in a name collision in the" +
        "resulting Python class")
    }
    if (!PythonInterop.isGoodPythonName(pyName)) {
      throw new IllegalArgumentException(s"The method name '$pyName' cannot be used in Python. Consider specifying " +
        s"an alternate name in the wrap.")
    }

    val (params, defaults) = WrapUtils.getParamsDefaultsForMethod(myType, method, Some(this))

    sbDef.clear()
    sbBody.clear()
    if (params.isEmpty && wrapObj.asProperty)
      sbDef.append("@property\n")
    sbDef.append(s"def $pyName(self")

    var firstDefaultParam: Option[String] = None
    // These are the used local variable names, as opposed to member names.
    val usedVarNames: Set[String] = Set(params.map(_.name.toString): _*)
    for (pIdx <- params.indices) {
      // Add the parameter both to the function defintiion, as well as doing any conversion code necessary
      // in the body.
      firstDefaultParam = generateParam(params(pIdx), defaults(pIdx), firstDefaultParam, usedVarNames, sbDef, sbBody)


    }
    // All the inputs should be ready. Process the output.
    val trans = PythonInterop.getTranslator(method.returnType)
    // Add the type hint for the output in the deinfition.
    sbDef.append(s")${trans.typeHint.map(" -> " + _).getOrElse("")}:\n")
    // Add the return value to the end of the body.
    val eval = PythonInterop.select("self._java_obj", method.name.toString) + '(' +
      params.map(_.name).mkString(", ") + ')'
    sbBody.append(indent(s"return ${trans.wrapOutput(eval, usedVarNames)}"))
    sbBody.append("\n")
    usedMemberNames += pyName
  }
}

trait RWrappable[T] extends BaseWrappable[T] {

  import GenerationUtils._

  protected lazy val rInternalWrapper = false

  protected lazy val rFuncName: String = {
    if (rInternalWrapper) {
      "_ml_" + camelToSnake(classNameHelper)
    } else {
      "ml_" + camelToSnake(classNameHelper)
    }
  }

  protected def rParamsArgs: String =
    thisStage.params.map(rParamArg(_) + ",\n").mkString("")

  protected def rParamArg[T](p: Param[T]): String = {
    (p, thisStage.getDefault(p)) match {
      case (_: ServiceParam[_], _) =>
        s"${p.name}=NULL,\n${p.name}Col=NULL"
      case (_: ComplexParam[_], _) | (_, None) =>
        s"${p.name}=NULL"
      case (_, Some(v)) =>
        s"""${p.name}=${RWrappableParam.rDefaultRender(v, p)}"""
    }
  }

  protected def rDocString: String = {
    val paramDocLines = thisStage.params.map(p =>
      s"#' @param ${p.name} ${p.doc}"
    ).mkString("\n")
    s"""
       |#' $classNameHelper
       |#'
       |${paramDocLines}
       |#' @export
       |""".stripMargin
  }

  protected def rSetterLines: String = {
    thisStage.params.map { p =>
      val value = getParamInfo(p).rTypeConverter.map(tc => s"$tc(${p.name})").getOrElse(p.name)
      p match {
        case p: ServiceParam[_] =>
          s"""invoke("set${p.name.capitalize}Col", ${p.name}Col) %>%\ninvoke("set${p.name.capitalize}", $value)"""
        case p =>
          s"""invoke("set${p.name.capitalize}", $value)"""
      }
    }.mkString(" %>%\n")
  }

  protected def rExtraInitLines: String = {
    this match {
      case _: Estimator[_] =>
        "unfit.model=FALSE,\nonly.model=FALSE,\n"
      case _ =>
        "only.model=FALSE,\n"
    }
  }

  protected def rExtraBodyLines: String = {
    this match {
      case _: Estimator[_] =>
        s"""
           |if (unfit.model)
           |    return(mod_parameterized)
           |transformer <- mod_parameterized %>%
           |    invoke("fit", df)
           |scala_transformer_class <- "${companionModelClassName}"
           |""".stripMargin
      case _ =>
        s"""
           |transformer <- mod_parameterized
           |scala_transformer_class <- scala_class
           |""".stripMargin
    }
  }

  protected def rClass(): String = {
    s"""
       |$copyrightLines
       |
       |$rDocString
       |$rFuncName <- function(
       |    x,
       |${indent(rParamsArgs)}
       |${indent(rExtraInitLines)}
       |    uid=random_string("${rFuncName}"),
       |    ...)
       |{
       |    if (unfit.model) {
       |        sc <- x
       |    } else {
       |        df <- spark_dataframe(x)
       |        sc <- spark_connection(df)
       |    }
       |    scala_class <- "${thisStage.getClass.getName}"
       |    mod <- invoke_new(sc, scala_class, uid = uid)
       |    mod_parameterized <- mod %>%
       |${indent(rSetterLines, 2)}
       |${indent(rExtraBodyLines)}
       |    if (only.model)
       |        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
       |    transformed <- invoke(transformer, "transform", df)
       |    sdf_register(transformed)
       |}
       |""".stripMargin

  }

  def makeRFile(conf: CodegenConfig): Unit = {
    conf.rSrcDir.mkdirs()
    Files.write(
      FileUtilities.join(conf.rSrcDir, rFuncName + ".R").toPath,
      rClass().getBytes(StandardCharsets.UTF_8))
  }

}

trait TypeWrappable[T] extends PythonWrappable[T] with RWrappable[T] with DotnetWrappable[T]

trait Wrappable extends TypeWrappable[Params] {
  private[ml] override def wrappingType: ru.TypeTag[Params] = ru.typeTag

  protected override def pyInitFuncJavaBridge(): String = ""

}