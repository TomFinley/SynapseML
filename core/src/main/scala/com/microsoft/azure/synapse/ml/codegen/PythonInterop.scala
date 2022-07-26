package com.microsoft.azure.synapse.ml.codegen

import scala.reflect.runtime.{universe => ru}

/**
  * Facilities for value interop between Python and Scala/Java objects across the py4j bridge used by Spark.
  */
private[ml]
object PythonInterop {

  trait Translator[T] {
    /**
      * The string Python representation of the type hint, per [[https://www.python.org/dev/peps/pep-0484/ PEP 484]].
      *
      * @return The Python type hint for the type.
      */
    def typeHint: String

    /**
      * Whether or not a given item can be passed in or returned directly, without need to use either [[wrapOutput()]]
      * or [[wrapInput()]] to adjust it for "transit" between Python and Scala/Java. Note that it is still allowed
      * for literals to have different representations between the two environments, as should be expressed through
      * [[literal()]].
      *
      * @return True if the item can be used directly without explicit conversion code, beyond that in py4j.
      */
    def isPassthrough: Boolean

    // TODO: Due to the recursive nature of some of these transformations,

    /**
      * Given a value that came from the Java/Scala side (as from a return value), convert it into a Python value.
      *
      * @param symbol      The original object out of `py4j`.
      * @param usedSymbols A set of already utilized symbols, in case temporary values must be used.
      * @return An expression containing the wrapping.
      */
    def wrapOutput(symbol: String, usedSymbols: => Set[String]): String

    /**
      * Given a value that came from Python ( as from an input parameter), convert it into something recognizable
      * by whatever is being invoked by py4j.
      *
      * @param symbol      The original object coming in from Python
      * @param usedSymbols A set of already utilized symbols, in case temporary values must be used.
      * @return An expression containing the wrapping.
      */
    def wrapInput(symbol: String, usedSymbols: => Set[String]): String

    /**
      * A string that can be used as a literal in Python, or else [[None]] if this type is not able to be expressed as
      * a literal. This is used primarily in writing out the values for the method argument defaults in Python.
      *
      * @param value The value to encode.
      * @return The string that can be used to express this string literal, or else [[None]] if we cannot express this
      *         type as a literal.
      */
    def literal(value: T): Option[String] = None

    /**
      * Necessary due to type erasure. Use sparingly, prefer the type safe [[literal()]] where possible.
      *
      * @param value The value to encode.
      * @return The literal string.
      */
    def literalUnsafe(value: Any): Option[String] = literal(value.asInstanceOf[T])
  }

  /**
    * Return or possibly construct a [[Translator]] given a type.
    *
    * @param t The type.
    * @return A transcoder corresponding to that type.
    */
  def getTranslator(t: ru.Type): Translator[_] = {
    // Unfortunately just doing maps for some of these may not work.

    @inline def is[T: ru.TypeTag]: Boolean = t =:= ru.typeOf[T]

    @inline def isSub[T: ru.TypeTag]: Boolean = t <:< ru.typeOf[T]

    t match {
      case _ if isSub[Option[_]] => new OptionTranslator(t)
      // TODO: At some point it seems sensible that we might have a Boolean argument or return value. In fact
      //  I'm a little surprised wee do not yet?
      case _ if is[Int] => IntPassthroughTranslator
      case _ if is[Long] => LongPassthroughTranslator
      case _ if is[String] => StringPassthroughTranslator
      case _ if is[Double] => DoublePassthroughTranslator
      case _ if is[Array[Byte]] => ByteArrayPassthroughTranslator
      // Is this the canonical way Scala users pass around byte buffers? Probably not that important.
      case t if isSub[Seq[_]] => new SeqTranslator(t)
      case _ => throw new UnsupportedOperationException(s"Translating type '$t' is not supported yet.")
    }
  }

  /**
    * Convenience variable for hte JVMView object, this assuming of course that this is something
    * structured with a `_java_obj` object. Obviously this would not work for class methods.
    */
  private val JvmView = "self._jvmv"
  private val ReflectTools = {
    val s = ReflectionUtilities.getClass.getCanonicalName
    // This is an `object`, not a `class`, the above name has `$` after it. We cut that out.
    assert(s.endsWith("$"))
    s.substring(0, s.length - 1)
  }

  def rtReference: String = JvmView + "." + ReflectTools

  /**
    * Most trivial form of the transcoder, where py4j handles all relevant interop and the only thing we
    * really need is the `hint`.
    *
    * @param hint The input hint, used as a simple value from [[typeHint]].
    */
  private abstract case class PassthroughTranslator[T](private val hint: String) extends Translator[T] {
    final override def typeHint: String = hint

    final override def isPassthrough: Boolean = true

    final override def wrapOutput(symbol: String, usedSymbols: => Set[String]): String = symbol

    final override def wrapInput(symbol: String, usedSymbols: => Set[String]): String = symbol
  }

  private object IntPassthroughTranslator extends PassthroughTranslator[Int]("int") {
    override def literal(value: Int): Option[String] = Some(value.toString)
  }

  private object LongPassthroughTranslator extends PassthroughTranslator[Long]("int") {
    override def literal(value: Long): Option[String] = Some(value.toString)
  }

  private object StringPassthroughTranslator extends PassthroughTranslator[String]("str") {
    override def literal(value: String): Option[String] = {
      // TODO: To what extent here and in other nullable types should `null` (not [[None]]) values be tolerated?
      Some(if (value == null) "None" else ru.Literal(ru.Constant(value)).toString)
    }
  }

  private object DoublePassthroughTranslator extends PassthroughTranslator[Double]("float") {
    // This may not be technically "right," since in principle the value should be one that could be round-tripped,
    // and I'm not sure that the default toString does that for values.
    override def literal(value: Double): Option[String] = Some(value.toString)
  }

  /**
    * For representing byte-arrays in a manner similar to that we see in py4j. Is it true that in Scala such
    * serialized structures are typically
    */
  private object ByteArrayPassthroughTranslator extends PassthroughTranslator[Array[Byte]]("bytes") {
    private lazy val ToEncode: IndexedSeq[String] = {
      val e = new Array[String](256)
      // Alternate encodings are possible, but this seems to mirror what Python itself does for the most part.

      e('\t'.toInt) = "\\t"
      e('\n'.toInt) = "\\n"
      e('\r'.toInt) = "\\r"
      e('\\'.toInt) = "\\"
      e('\"'.toInt) = "\""
      for (i <- (0 until 32) ++ (127 until 256)) {
        if (e(i) == null) e(i) = f"\\x$i%02x"
      }
      for (i <- 32 until 127) {
        if (e(i) == null) e(i) = i.toChar.toString
      }
      e
    }

    override def literal(value: Array[Byte]): Option[String] = {
      if (value == null) {
        Some("None")
      } else {
        val e = ToEncode
        val sb: StringBuilder = new StringBuilder("b\"")
        value.foreach(i => sb.append(e(i & 0xff)))
        sb.append('\"')
        Some(sb.result)
      }
    }
  }

  private def unusedTempVar(usedSymbols: Set[String]): String = {
    if (!usedSymbols.contains("x")) {
      "x"
    } else {
      var i = 1
      while (usedSymbols.contains("x" + i)) i += 1
      "x" + i
    }
  }

  private final class SeqTranslator(myType: ru.Type) extends Translator[Seq[_]] {
    private val elemTranslator: Translator[_] = {
      // For a type that implements, for example, Seq[Foo] but is not a Seq[Foo], this will return the type
      // of Seq[Foo]. The documentation on this method does not really leave me with a great deal of confidence.
      val seqType = myType.baseType(ru.typeOf[Seq[_]].typeSymbol)
      assert(seqType.typeArgs.length == 1)
      getTranslator(seqType.typeArgs.head)
    }

    override def isPassthrough: Boolean = false

    override def literal(value: Seq[_]): Option[String] = {
      // TODO: Investigate using spray.json with mmlspark's JsonPrinter.
      //  The potential trouble with that is that is as we see here, this takes [[Any]] objects, that is, it works
      //  through non-type-tag reflection, but it also simultaneously does recursive traversal of any collection
      //  types, which means that all type information of any type unknown to spray.json is lost. That's a bit much.
      //  So we have to either (1) accept that this practically might not come up or (2) engineer around that
      //  somehow. For now we'll just leave this as is.
      if (value == null) {
        Some("None")
      } else {
        val sb = new StringBuilder("[")
        val elemLiterals = value.map(elemTranslator.literalUnsafe)
        for (e <- elemLiterals) {
          if (sb.length > 1)
            sb.append(", ")
          if (e.isEmpty)
          // In Scala returns are disfavored. Is there a better way though?
            return None
          sb.append(e.get)
        }
        sb.append("]")
        Some(sb.result)
      }
    }

    /**
      * The type hint for a sequence, which is `typing.List`. Note that using `list` directly in this fashion
      * was not done for Python 3.8.
      *
      * @return The Python type hint for the sequence type, which is represented in python as a list.
      */
    override def typeHint: String = s"List[${elemTranslator.typeHint}]"

    override def wrapOutput(symbol: String, usedSymbols: => Set[String]): String = {
      // We want this to become as a list. We pass it back to our code, making it a java collections.
      val basic = s"$rtReference.asCollection($symbol)"
      if (elemTranslator.isPassthrough)
        basic
      else {
        // We must recursively apply the coding to the elements, which we do via a list comprehension.
        val compVar = unusedTempVar(usedSymbols)
        val compExpression = elemTranslator.wrapOutput(compVar, usedSymbols + compVar)
        s"[$compExpression for $compVar in $basic]"
      }
    }

    /**
      * Given a value that came from Python ( as from an input parameter), convert it into something recognizable
      * by whatever is being invoked by py4j.
      *
      * @param symbol      The original object coming in from Python
      * @param usedSymbols A set of already utilized symbols, in case temporary values must be used.
      * @return An expression containing the wrapping.
      */
    override def wrapInput(symbol: String, usedSymbols: => Set[String]): String = {
      val internal =
        if (elemTranslator.isPassthrough) {
          symbol
        } else {
          val compVar = unusedTempVar(usedSymbols)
          val compExpression = elemTranslator.wrapInput(compVar, usedSymbols + compVar)
          s"[$compExpression for $compVar in $symbol]"
        }
      s"ListConverter($internal)"
    }
  }

  /**
    * A translator for [[Option]].
    *
    * There are some issues around [[Option]] types, some obvious, some less so. Python APIs canonically treat `None`
    * as the missing value, whereas in Scala there is a [[Option]] of which one subtype is [[None]]. Despite having
    * the same name, the Python `None` is really rather closer to what is in Scala and many other languages `null`.
    *
    * This brings up the interesting effect that in Scala, [[Some(null)]] and `null` and [[None]] are distinct values,
    * whereas in a Python mapping, these would not be distinct, at least by a "natural" reading. For input, we have
    * `None` in Python map to [[None]] in Scala for such types as these.
    *
    * More subtly, it is entirely legal, though strange, to have a type like [[Option[Option[Option[Int] ] ] ]].
    * Resolving whether such a thing actually has a value in a single statement would be obnoxious on the Python side.
    * In order to make this less annoying, we disallow nested [[Option]]s of that sort.
    *
    * @param myType The [[Option]] type (not the generic argument, to be clear).
    */
  private final class OptionTranslator(myType: ru.Type) extends Translator[Option[_]] {
    private val elemTranslator: Translator[_] = {
      val e = myType.baseType(ru.typeOf[Option[_]].typeSymbol).typeArgs.head
      if (e <:< ru.typeOf[Option[_]])
        throw new UnsupportedOperationException(s"Nested Option type, as we see in $myType, is not allowed.")
      // Does Option[Option[_]] ever come up in a way that would justify the extra complexity of actually handling it?
      getTranslator(e)
    }

    // Note that the alternative to `Optional[Foo]` of Foo | None` is not present in Python 3.8 typing.
    override def typeHint: String = s"Optional[${elemTranslator.typeHint}]"

    override def isPassthrough: Boolean = false

    override def literal(value: Option[_]): Option[String] =
      if (value != null && value.isDefined) elemTranslator.literalUnsafe(value.get) else Some("None")

    override def wrapOutput(symbol: String, usedSymbols: => Set[String]): String = {
      val recurseSymbol = elemTranslator.wrapOutput(s"$symbol.get()", usedSymbols)
      s"$recurseSymbol if $symbol.isDefined() else None"
    }

    override def wrapInput(symbol: String, usedSymbols: => Set[String]): String = {
      // Accessing .None through py4j does not work so well, I suppose because they disallow that type. Nonetheless
      // it is accessible through getattr.
      val none: String = select(JvmView + ".scala", "None")
      val some: String = s"$JvmView.scala.Some($symbol)"
      s"$none if $symbol is None else $some"
    }
  }

  /**
    * Returns a valid referencing of `qualifier.name`. In the case where `name` is a valid Python name, it will
    * in fact just return that simple qualifier. If not it will use `getattr`. This difficulty comes up because,
    * while the attributes of a Python object can have seemingly any string name, the sentax Python can use in
    * the actual grammar for that name is limited. (For example, for an object `a` with an attribute named `+`,
    * one could not, for instance, write `a.+`.
    *
    * @param qualifier The object to reference for the attribute.
    * @param name      The name of the attribute.
    * @return A valid selection in Python to get that attribute.
    */
  def select(qualifier: String, name: String): String = {
    if (isGoodPythonName(name)) s"$qualifier.$name" else s"getattr($qualifier, ${ru.Literal(ru.Constant(name))})"
  }

  def isGoodPythonName(name: String): Boolean = Keywords.isGoodPythonName(name)

  /**
    * Reproduces the functionality of [[https://github.com/python/cpython/blob/3.10/Lib/keyword.py keyword]]
    * package for testing whether something is a keyword, and also provides functionality similar to the
    * `str.isidentifier(...)` method as well.
    */
  private object Keywords {
    private val KW = Set(
      """False None True and as assert async await break class continue def del elif else except
        |finally for from global if import in is lambda nonlocal not or pass raise return try
        |while with yield""".stripMargin.split(' '): _*)
    // These soft keywords might have some usage, but they seem to work fine as method, argument, and variables?
    // The underscore of course is used in the REPL.
    private val SoftKW = Set("_", "case", "match")

    private val IdentifierRegex = "^[_A-Za-z][_0-9A-Za-z]*$".r

    def isGoodPythonName(name: String): Boolean = !KW.contains(name) && IdentifierRegex.findFirstIn(name).isDefined
  }

}
