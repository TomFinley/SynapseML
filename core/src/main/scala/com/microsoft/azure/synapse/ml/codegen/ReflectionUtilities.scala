package com.microsoft.azure.synapse.ml.codegen

import java.io.{ByteArrayOutputStream, DataOutputStream}

import scala.collection.JavaConverters
import scala.reflect.runtime.{universe => ru}

private[ml]
object ReflectionUtilities {
  /**
    * Meant to be called by Python wrapping code. Note that this utility is just intended for lightweight
    * portable simple serialization, without heavy dependencies upon anything like arrow.
    *
    * @return Return a byte array representation of an object. No type of schema information is
    *         necessarily bundled in this, as it is assumed the cammer knows what to do with it.
    */
  def asBytes(v: Any): Array[Byte] = {
    val byteStream = new ByteArrayOutputStream()
    writeCore(v, new DataOutputStream(byteStream))
    byteStream.toByteArray
  }

  @inline
  private def throwTypeUnsupported(obj: Any): Unit =
    throw new java.lang.UnsupportedOperationException(s"The type ${obj.getClass.getSimpleName} unsupported here.")

  @scala.annotation.tailrec
  private def writeCore(value: Any, dataStream: DataOutputStream): Unit = {
    value match {
      case seq: Seq[_] =>
        // Type erasure means we can't test whether this is a Seq[Int] or Seq[Double] directly.
        dataStream.writeInt(seq.length)
        if (seq.nonEmpty) {
          // This code assumes that the list is homogeneously typed.
          seq.head match {
            case _: Int => writeSeq(seq.asInstanceOf[Seq[Int]], dataStream.writeInt)
            case _: Double => writeSeq(seq.asInstanceOf[Seq[Double]], dataStream.writeDouble)
            case element => throwTypeUnsupported(element)
          }
        }
      case opt: Option[_] =>
        dataStream.writeBoolean(opt.isDefined)
        if (opt.isDefined) writeCore(opt.get, dataStream)
      case item => throwTypeUnsupported(item)
    }
  }

  def thisObjectInJava: String =
    "self._jvm." + ru.typeOf[this.type].typeSymbol.fullName

  /**
    * Maps the incoming value to something easily readable by py4j.
    *
    * @param value The value to try to wrap.
    * @return The wrapped
    */
  @scala.annotation.tailrec
  def asCollection(value: Any): Any = {
    // Suppress the avoid null, since using null is how the py4j translates to/from Python None objects.
    value match {
      //noinspection ScalaStyle
      case null => null // Not sure if it's worth distinguishing null vs. Some[_](null).
      case seq: Seq[_] => JavaConverters.seqAsJavaList(seq)
      case opt: Option[_] => asCollection(opt.orNull)
      case map: Map[_, _] => JavaConverters.mapAsJavaMap(map)
      case item => throwTypeUnsupported(item)
    }
  }

  private
  def writeSeq[T](seq: Seq[T], writer: T => Unit): Unit = for (v <- seq) writer(v)
}
