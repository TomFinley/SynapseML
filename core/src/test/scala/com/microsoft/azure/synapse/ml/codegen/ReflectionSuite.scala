package com.microsoft.azure.synapse.ml.codegen

import org.apache.commons.lang.StringUtils
import org.apache.spark.ml.param.{DoubleParam, IntParam, ParamMap, ParamValidators, Params}
import org.scalatest.FunSuite

import scala.reflect.runtime.{universe => ru}

class ReflectionSuite extends FunSuite {
  test("Get params and defaults for method") {
    import ReflectionSuite.{ExtractDefaultsTestClass => C, ParamTestHelper => H}
    val testType = ru.typeOf[C]
    val inst = C()

    def localTest(methodName: String, helper: ReflectionSuite.ParamTestHelper): Unit = {
      val member = testType.member(ru.TermName(methodName))
      assert(member.isMethod)
      val method = member.asMethod
      val (params, deflts) = WrapUtils.getParamsDefaultsForMethod(testType, method, Some(inst))

      val names = params.map(_.name.toString).toIndexedSeq
      val types = params.map(_.typeSignature).toIndexedSeq

      assertResult(helper.names)(names)
      // Unfortunately we cannot do assertResult here, since that uses as == test, and the type tests are
      // not reliable unless the =:= operator is used.
      assert(helper.types.zip(types).forall(p => p._1 =:= p._2))
      assertResult(helper.defaults)(deflts)
    }

    localTest("a0", H())
    localTest("a1", H().add[Int]("b"))
    localTest("a2", H().add("b", 5))
    localTest("a3", H().add[String]("b").add[Int]("c"))
    localTest("a4", H().add("b", "hi").add[Int]("c"))
    localTest("a5", H().add("b", "hello").add("c", 2))
  }

  test("Wrap annotation extraction test") {
    import ReflectionSuite.{WrapExtractTestClass => C}
    val testType = ru.typeOf[C]

    def localTest(methodName: String, expectedWrap: wrap): Unit = {
      val member = testType.member(ru.TermName(methodName))
      assert(member.isMethod)
      val actualWrap = WrapUtils.getWrapForMethod(member.asMethod)
      if (expectedWrap == null) {
        assert(actualWrap.isEmpty)
      } else {
        assert(actualWrap.isDefined)
        assertResult(expectedWrap)(actualWrap.get)
      }
    }

    localTest("a0", wrap(asProperty = true, "miles"))
    localTest("a1", wrap(asProperty = true))
    localTest("a2", wrap())
    localTest("a4", null)

    def localTestExcept(methodName: String): Unit = {
      val member = testType.member(ru.TermName(methodName))
      assert(member.isMethod)
      assertThrows[UnsupportedOperationException](WrapUtils.getWrapForMethod(member.asMethod))
    }

    localTestExcept("a3")
  }

  test("Type comparisons demonstration") {
    // Less intended to test the library, but more as a living example to me of how the runtime test comparisons work,
    // since it really is not clear to me. These two types are not the same.
    assert(!(ru.typeOf[IndexedSeq[Int]] =:= ru.typeOf[Seq[Int]]))
    // However, IndexedSeq[Int] is also a Seq[Int].
    assert(ru.typeOf[IndexedSeq[Int]] <:< ru.typeOf[Seq[Int]])
    // Despite being implicitly convertible from an array, an Array does not descend from Seq.
    assert(!(ru.typeOf[Array[Int]] <:< ru.typeOf[Seq[Int]]))
    // The type without erasure is conforms to the type with erasure.
    assert(ru.typeOf[Seq[Int]] <:< ru.typeOf[Seq[_]])
    // As we see in two cases here, the generic type survives erasure.
    assert(!(ru.typeOf[Seq[Int]] <:< ru.typeOf[Seq[Double]]))
    assert(!(ru.typeOf[Seq[Int]] =:= ru.typeOf[Seq[Double]]))
  }

  test("Python literal translation") {
    def get[T: ru.TypeTag](value: T): String = {
      val trans = PythonInterop.getTranslator(ru.typeOf[T])
      trans.literalUnsafe(value).get
    }

    assertResult("5")(get(5))
    assertResult(s"${5.0}")(get(5.0))
    assertResult("\"my lovely horse!\"")(get("my lovely horse!"))
    assertResult("None")(get[String](null))
    val exp: String = "b\"Run\\ning \\through \\the field\""
    assertResult(exp)(get("Run\ning \through \the field".map(_.toByte).toArray))
    assertResult("None")(get[Array[Byte]](null))
    // Where are you going with your fetlocks blowing in the wind?

    assertResult("[1, 2, 5]")(get(IndexedSeq(1, 2, 5)))

    assertResult("""["with", None, "fetlocks"]""")(get(Seq[String]("with", null, "fetlocks")))
    assertResult("None")(get[Seq[Int]](null))

    // Try a compound list, in this case a sequence of sequence of integers.
    assertResult("[[4, 2], None, [7, 0]]")(get(Seq(Seq(4, 2), null, Seq(7, 0))))

    // Test that this still works if the type we use is not explicitly a Seq[Int] type, and doesn't have the generic
    // type parameter on it.
    assertResult("[1, 2, 5]")(get(new ReflectionSuite.SomewhatSeq(Seq(1, 2, 5))))

    assertResult("None")(get[Option[String]](null))
    assertResult("None")(get[Option[String]](Some(null)))
    assertResult("\"horse dentist\"")(get[Option[String]](Some("horse dentist")))
  }

  test("Python type hints per PEP 484") {
    def get[T: ru.TypeTag]: String = {
      val trans = PythonInterop.getTranslator(ru.typeOf[T])
      trans.typeHint.orNull
    }

    assertResult("int")(get[Int])
    assertResult("str")(get[String])
    assertResult("float")(get[Double])
    assertResult("Optional[int]")(get[Option[Int]])
    assertResult("List[Optional[int]]")(get[Seq[Option[Int]]])
    assertResult("Optional[List[int]]")(get[Option[Seq[Int]]])
    assertResult("List[List[str]]")(get[Seq[Seq[String]]])
  }

  test("Python method generation test") {
    import ReflectionSuite.{WrappableTestClass => C}
    val inst = new C()
    val pyClassStr: String = inst.pythonClassTestPassthrough
    println(pyClassStr)

    def exactlyOnce(s: String): Boolean = StringUtils.countMatches(pyClassStr, s) == 1

    assert(exactlyOnce("    def foo(self, bar: int) -> float:"))
    assert(!pyClassStr.contains("    def foo2(self, bar: int) -> float:"))
    assert(exactlyOnce("    def foo2override(self, bar: int) -> float:"))
    assert(exactlyOnce("    def foo3(self) -> int:"))
    assert(exactlyOnce("    def foo4(self, bar: int, biz: int) -> float:"))
    assert(!pyClassStr.contains("    def foo5(self) -> int:"))
    assert(exactlyOnce("    def getGoofy(self)"))
    assert(!pyClassStr.contains("    def setGoofy(self, value"))
    assert(exactlyOnce("    def getSilly(self)"))
    assert(exactlyOnce("    def setSilly(self, value"))
  }
}

private[this]
object ReflectionSuite {

  class SomewhatSeq(private val s: Seq[Int]) extends Seq[Int] {
    override def length: Int = s.length

    override def apply(idx: Int): Int = s(idx)

    override def iterator: Iterator[Int] = s.iterator
  }

  case class WrapExtractTestClass() {
    @wrap(true, "miles")
    def a0: Int = 2

    @wrap(true)
    def a1(b: Int): Double = b + 0.5

    @wrap()
    def a2(b: Int = 5): Double = b + 0.5

    @wrap(overrideName = "hello", asProperty = true)
    def a3(b: Int = 5): Double = b + 0.5

    def a4(b: Int = 5): Double = b + 0.5
  }

  case class ExtractDefaultsTestClass() {
    def a0: Int = 2

    def a1(b: Int): Int = b + 3

    def a2(b: Int = 5): Int = b + 4

    def a3(b: String, c: Int): String = s"$b + $c"

    def a4(b: String = "hi", c: Int): String = a3(b, c)

    def a5(b: String = "hello", c: Int = 2): String = a3(b, c)
  }

  class WrappableTestClass() extends TypeWrappable[ReflectionSuite.WrappableTestClass] with Params {
    private[ml] override def wrappingType: ru.TypeTag[WrappableTestClass] = ru.typeTag

    @wrap def foo(bar: Int): Double = bar + 0.5

    @wrap(false, "foo2override")
    def foo2(bar: Int): Double = bar + 0.5

    @wrap def foo3: Int = 2

    @wrap def foo4(bar: Int, biz: Int): Double = (bar + biz) * 0.5

    def foo5: Int = 3

    override def copy(extra: ParamMap): WrappableTestClass = defaultCopy(extra)

    override val uid: String = ""

    final val goofy: IntParam = new IntParam(this, "goofy", "A very goofy parameter.",
      ParamValidators.gtEq(0))
    final val silly: DoubleParam = new DoubleParam(this, "silly", "A very silly parameter.",
      ParamValidators.gtEq(1.0))

    final def getGoofy: Int = $(goofy)

    final def getSilly: Double = $(silly)

    final def setSilly(value: Double): this.type = set(silly, value)

    setDefault(goofy -> 2, silly -> 3.0)

    def pythonClassTestPassthrough: String = this.pythonClass()
  }

  /**
    * Convenience class for building the name, type, and default dictionaries.
    */
  case class ParamTestHelper() {
    private val nameBuilder = IndexedSeq.newBuilder[String]
    private val typeBuilder = IndexedSeq.newBuilder[ru.Type]
    private val defaultBuilder = IndexedSeq.newBuilder[Option[Any]]

    def names: IndexedSeq[String] = nameBuilder.result()

    def types: IndexedSeq[ru.Type] = typeBuilder.result()

    def defaults: IndexedSeq[Option[Any]] = defaultBuilder.result()

    def add[T](name: String, value: T)(implicit t: ru.TypeTag[T]): ParamTestHelper = {
      nameBuilder += name
      typeBuilder += t.tpe
      defaultBuilder += Some(value)
      this
    }

    def add[T](name: String)(implicit t: ru.TypeTag[T]): ParamTestHelper = {
      nameBuilder += name
      typeBuilder += t.tpe
      defaultBuilder += None
      this
    }
  }

}
