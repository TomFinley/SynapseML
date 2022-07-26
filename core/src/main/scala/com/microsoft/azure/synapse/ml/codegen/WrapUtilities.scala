package com.microsoft.azure.synapse.ml.codegen

import scala.annotation.StaticAnnotation
import scala.reflect.NameTransformer
import scala.reflect.runtime.{universe => ru}

/**
  * An attribute for methods to indicate that they should be wrapped for the code gen.
  *
  * @param asProperty   If this is a no-argument method, indicates whether this should be exposed as a property,
  *                     n languages such as Python or C# that support such concepts. This has no effect if the
  *                     annotated method has arguments.
  * @param overrideName Specified in case we want a distinct name from the method name being inspected.
  */
//noinspection ScalaStyle
// TODO: ScalaStyle dictates that class names should not be "lower cased." However, most of the used attributes
//  in the Scala standard library and Spark.
// TODO: Revisit if moving from Scala 2.12 to 2.13, the new ConstantAnnotation seems to be more in line with what
//  we would like, assuming we can get the named parameters to not be lost at runtime somehow.
private[ml] final case class wrap(asProperty: Boolean = false, overrideName: String = "")
  extends StaticAnnotation {
  def overrideNameOption: Option[String] = if (overrideName.isEmpty) None else Some(overrideName)
}

private[ml] object WrapUtils {
  def getParamsDefaultsForMethod(t: ru.Type, method: ru.MethodSymbol, instance: Option[Any] = None): (
    IndexedSeq[ru.Symbol], IndexedSeq[Option[Any]]) = {
    //require(method.isStatic || instance != null)
    require(method.paramLists.length <= 1)

    if (method.paramLists.isEmpty) {
      (IndexedSeq.empty, IndexedSeq.empty)
    } else {
      val params = method.paramLists.toIndexedSeq(0)

      val cl = scala.reflect.runtime.currentMirror.classLoader
      val mirror = ru.runtimeMirror(cl)
      val runtimeClass = mirror.runtimeClass(t)

      val defaults: IndexedSeq[Option[Any]] = (1 to params.length).map(i => {
        // This per:
        // https://stackoverflow.com/questions/14034142/how-do-i-access-default-parameter-values-via-scala-reflection
        val defaultMethodName = s"${method.name.toTermName.toString}$$default$$$i"
        val defaultJavaMethodName = NameTransformer.encode(defaultMethodName)
        val defaultMethodOption =
          try {
            Some(runtimeClass.getMethod(defaultJavaMethodName))
          } catch {
            case _: NoSuchMethodException => None
          }
        defaultMethodOption.map(_.invoke(instance.orNull))
      })
      (params.toIndexedSeq, defaults)
    }
  }

  private val TypeTag: ru.TypeTag[wrap] = ru.typeTag[wrap]
  private val TypeRepr: ru.Type = TypeTag.tpe
  // This assumes there is always one, or at least that the first one is the right one.

  // ScalaStyle and SLS barf on this -- pattern variables must start with a lower case letter per SLS 8.1.1,
  // but because it's a constant, ScalaStyle insists that it be PascalCased.

  private val (
    //noinspection ScalaStyle
    constructorParams: IndexedSeq[ru.Symbol], constructorParamsDefaults: IndexedSeq[Option[Any]]) =
  getParamsDefaultsForMethod(TypeRepr, TypeRepr.members.find(_.isConstructor).get.asMethod)

  val ConstructorParamNameToIdx: Map[String, Int] = {
    val builder = Map.newBuilder[String, Int]
    constructorParams.map(_.name.toString).zipWithIndex.foreach(builder += _)
    builder.result()
  }

  def getWrapForMethod(method: ru.MethodSymbol)(implicit litTag: ru.TypeTag[ru.Literal]): Option[wrap] = {
    method.annotations.find(_.tree.tpe =:= TypeRepr).map(a => {
      // Start with the default values.
      val vals = constructorParamsDefaults.map(_.orNull).toArray
      // For each observed argument, map it back to the values.
      val arguments = a.tree.children.tail
      // TODO: Consider using macros to support the rewrite. See the answer here.
      //  https://stackoverflow.com/questions/55032173/how-to-use-named-arguments-in-scala-user-defined-annotations
      //  More documentation here:
      //  https://docs.scala-lang.org/overviews/macros/annotations.html
      //  This may become more necessary if we decide to add lots of target-specific annotation options, that is,
      //  it may be that idiomatically we might want one method to be a property in C#, or different names to
      //  different targets, or something like this.
      for (i <- arguments.indices) {
        arguments(i) match {
          // TODO: These matches against literal and select and whatnot generate warnings during compilation
          //  that claim the type pattern is unchecked since eliminated by erasure, yet this clearly seems
          //  to work from my tests -- the expected values are reached from the tree elements. What's going on?
          case ru.Literal(ru.Constant(value)) =>
            vals(i) = value
          case ru.Select(term) =>
            val selectName = term._2.toString
            // In the event that it is a default, there is a corresponding method on the Java runtime "side"
            // with a pattern. It is preceded by the name of the corresponding method.
            if (!selectName.endsWith(s"$$default$$${i + 1}"))
              throw new UnsupportedOperationException(s"Do not know how to process expression '${arguments(i)}'!")
            vals(i) = constructorParamsDefaults(i).get
          case ru.TermName(_) =>
            // TODO: Revisit in 2.13, to see if ru.AssignOrNamedArg or something similar becomes used. At least in
            //  2.12, named arguments instead result in the creation of an (inaccessible) local variable named something
            //  like `x$1`, `x$2`, etc., to hold the assigned value, which cannot be recovered at runtime.
            throw new UnsupportedOperationException(s"For now named arguments do not work. " +
              s"Use positional arguments instead.")
          case arg =>
            throw new UnsupportedOperationException(s"Do not know how to process expression '$arg'!")
        }
      }
      wrap(vals(0).asInstanceOf[Boolean], vals(1).asInstanceOf[String])
    })
  }

}

