# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.


import sys
if sys.version >= '3':
    basestring = str

from pyspark import SparkContext, SQLContext
from pyspark.sql import DataFrame
from pyspark.ml.param.shared import *
from pyspark import keyword_only
from pyspark.ml.util import JavaMLReadable, JavaMLWritable
from synapse.ml.core.serialize.java_params_patch import *
from pyspark.ml.wrapper import JavaTransformer, JavaEstimator, JavaModel
from pyspark.ml.evaluation import JavaEvaluator
from pyspark.ml.common import inherit_doc
from synapse.ml.core.schema.Utils import *
from pyspark.ml.param import TypeConverters
from synapse.ml.core.schema.TypeConversionUtils import generateTypeConverter, complexTypeConverter
from py4j.java_collections import SetConverter, MapConverter, ListConverter
from typing import List, Optional


@inherit_doc
class DetectFace(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        errorCol (str): column to hold http errors
        handler (object): Which strategy to use when handling requests
        imageUrl (object): the url of the image to use
        outputCol (str): The name of the output column
        returnFaceAttributes (object): Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
        returnFaceId (object): Return faceIds of the detected faces or not. The default value is true
        returnFaceLandmarks (object): Return face landmarks of the detected faces or not. The default value is false.
        subscriptionKey (object): the API key to use
        timeout (float): number of seconds to wait before closing the connection
        url (str): Url of the service
    """

    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    handler = Param(Params._dummy(), "handler", "Which strategy to use when handling requests")
    
    imageUrl = Param(Params._dummy(), "imageUrl", "ServiceParam: the url of the image to use")
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    returnFaceAttributes = Param(Params._dummy(), "returnFaceAttributes", "ServiceParam: Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.")
    
    returnFaceId = Param(Params._dummy(), "returnFaceId", "ServiceParam: Return faceIds of the detected faces or not. The default value is true")
    
    returnFaceLandmarks = Param(Params._dummy(), "returnFaceLandmarks", "ServiceParam: Return face landmarks of the detected faces or not. The default value is false.")
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        concurrency=1,
        concurrentTimeout=None,
        errorCol="DetectFace_d87cf28dfe8f_error",
        handler=None,
        imageUrl=None,
        imageUrlCol=None,
        outputCol="DetectFace_d87cf28dfe8f_output",
        returnFaceAttributes=None,
        returnFaceAttributesCol=None,
        returnFaceId=None,
        returnFaceIdCol=None,
        returnFaceLandmarks=None,
        returnFaceLandmarksCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        timeout=60.0,
        url=None
        ):
        super(DetectFace, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.DetectFace", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="DetectFace_d87cf28dfe8f_error")
        self._setDefault(outputCol="DetectFace_d87cf28dfe8f_output")
        self._setDefault(timeout=60.0)
        if hasattr(self, "_input_kwargs"):
            kwargs = self._input_kwargs
        else:
            kwargs = self.__init__._input_kwargs
    
        if java_obj is None:
            for k,v in kwargs.items():
                if v is not None:
                    getattr(self, "set" + k[0].upper() + k[1:])(v)

    @keyword_only
    def setParams(
        self,
        concurrency=1,
        concurrentTimeout=None,
        errorCol="DetectFace_d87cf28dfe8f_error",
        handler=None,
        imageUrl=None,
        imageUrlCol=None,
        outputCol="DetectFace_d87cf28dfe8f_output",
        returnFaceAttributes=None,
        returnFaceAttributesCol=None,
        returnFaceId=None,
        returnFaceIdCol=None,
        returnFaceLandmarks=None,
        returnFaceLandmarksCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        timeout=60.0,
        url=None
        ):
        """
        Set the (keyword only) parameters
        """
        if hasattr(self, "_input_kwargs"):
            kwargs = self._input_kwargs
        else:
            kwargs = self.__init__._input_kwargs
        return self._set(**kwargs)

    @classmethod
    def read(cls):
        """ Returns an MLReader instance for this class. """
        return JavaMMLReader(cls)

    @staticmethod
    def getJavaPackage():
        """ Returns package name String. """
        return "com.microsoft.azure.synapse.ml.cognitive.DetectFace"

    @staticmethod
    def _from_java(java_stage):
        module_name=DetectFace.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".DetectFace"
        return from_java(java_stage, module_name)

    def setConcurrency(self, value):
        """
        Args:
            concurrency: max number of concurrent calls
        """
        self._set(concurrency=value)
        return self
    
    def setConcurrentTimeout(self, value):
        """
        Args:
            concurrentTimeout: max number seconds to wait on futures if concurrency >= 1
        """
        self._set(concurrentTimeout=value)
        return self
    
    def setErrorCol(self, value):
        """
        Args:
            errorCol: column to hold http errors
        """
        self._set(errorCol=value)
        return self
    
    def setHandler(self, value):
        """
        Args:
            handler: Which strategy to use when handling requests
        """
        self._set(handler=value)
        return self
    
    def setImageUrl(self, value):
        """
        Args:
            imageUrl: the url of the image to use
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setImageUrl(value)
        return self
    
    def setImageUrlCol(self, value):
        """
        Args:
            imageUrl: the url of the image to use
        """
        self._java_obj = self._java_obj.setImageUrlCol(value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
        return self
    
    def setReturnFaceAttributes(self, value):
        """
        Args:
            returnFaceAttributes: Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setReturnFaceAttributes(value)
        return self
    
    def setReturnFaceAttributesCol(self, value):
        """
        Args:
            returnFaceAttributes: Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
        """
        self._java_obj = self._java_obj.setReturnFaceAttributesCol(value)
        return self
    
    def setReturnFaceId(self, value):
        """
        Args:
            returnFaceId: Return faceIds of the detected faces or not. The default value is true
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setReturnFaceId(value)
        return self
    
    def setReturnFaceIdCol(self, value):
        """
        Args:
            returnFaceId: Return faceIds of the detected faces or not. The default value is true
        """
        self._java_obj = self._java_obj.setReturnFaceIdCol(value)
        return self
    
    def setReturnFaceLandmarks(self, value):
        """
        Args:
            returnFaceLandmarks: Return face landmarks of the detected faces or not. The default value is false.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setReturnFaceLandmarks(value)
        return self
    
    def setReturnFaceLandmarksCol(self, value):
        """
        Args:
            returnFaceLandmarks: Return face landmarks of the detected faces or not. The default value is false.
        """
        self._java_obj = self._java_obj.setReturnFaceLandmarksCol(value)
        return self
    
    def setSubscriptionKey(self, value):
        """
        Args:
            subscriptionKey: the API key to use
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setSubscriptionKey(value)
        return self
    
    def setSubscriptionKeyCol(self, value):
        """
        Args:
            subscriptionKey: the API key to use
        """
        self._java_obj = self._java_obj.setSubscriptionKeyCol(value)
        return self
    
    def setTimeout(self, value):
        """
        Args:
            timeout: number of seconds to wait before closing the connection
        """
        self._set(timeout=value)
        return self
    
    def setUrl(self, value):
        """
        Args:
            url: Url of the service
        """
        self._set(url=value)
        return self

    
    def getConcurrency(self):
        """
        Returns:
            concurrency: max number of concurrent calls
        """
        return self.getOrDefault(self.concurrency)
    
    
    def getConcurrentTimeout(self):
        """
        Returns:
            concurrentTimeout: max number seconds to wait on futures if concurrency >= 1
        """
        return self.getOrDefault(self.concurrentTimeout)
    
    
    def getErrorCol(self):
        """
        Returns:
            errorCol: column to hold http errors
        """
        return self.getOrDefault(self.errorCol)
    
    
    def getHandler(self):
        """
        Returns:
            handler: Which strategy to use when handling requests
        """
        return self.getOrDefault(self.handler)
    
    
    def getImageUrl(self):
        """
        Returns:
            imageUrl: the url of the image to use
        """
        return self._java_obj.getImageUrl()
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)
    
    
    def getReturnFaceAttributes(self):
        """
        Returns:
            returnFaceAttributes: Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
        """
        return self._java_obj.getReturnFaceAttributes()
    
    
    def getReturnFaceId(self):
        """
        Returns:
            returnFaceId: Return faceIds of the detected faces or not. The default value is true
        """
        return self._java_obj.getReturnFaceId()
    
    
    def getReturnFaceLandmarks(self):
        """
        Returns:
            returnFaceLandmarks: Return face landmarks of the detected faces or not. The default value is false.
        """
        return self._java_obj.getReturnFaceLandmarks()
    
    
    def getSubscriptionKey(self):
        """
        Returns:
            subscriptionKey: the API key to use
        """
        return self._java_obj.getSubscriptionKey()
    
    
    def getTimeout(self):
        """
        Returns:
            timeout: number of seconds to wait before closing the connection
        """
        return self.getOrDefault(self.timeout)
    
    
    def getUrl(self):
        """
        Returns:
            url: Url of the service
        """
        return self.getOrDefault(self.url)

    

    
    
    def setLocation(self, value):
        self._java_obj = self._java_obj.setLocation(value)
        return self
    
    def setLinkedService(self, value):
        self._java_obj = self._java_obj.setLinkedService(value)
        return self
        