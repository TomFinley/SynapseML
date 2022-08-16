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
class VerifyFaces(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        errorCol (str): column to hold http errors
        faceId (object): faceId of the face, comes from Face - Detect.
        faceId1 (object): faceId of one face, comes from Face - Detect.
        faceId2 (object): faceId of another face, comes from Face - Detect.
        handler (object): Which strategy to use when handling requests
        largePersonGroupId (object): Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        outputCol (str): The name of the output column
        personGroupId (object): Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        personId (object): Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
        subscriptionKey (object): the API key to use
        timeout (float): number of seconds to wait before closing the connection
        url (str): Url of the service
    """

    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    faceId = Param(Params._dummy(), "faceId", "ServiceParam: faceId of the face, comes from Face - Detect.")
    
    faceId1 = Param(Params._dummy(), "faceId1", "ServiceParam: faceId of one face, comes from Face - Detect.")
    
    faceId2 = Param(Params._dummy(), "faceId2", "ServiceParam: faceId of another face, comes from Face - Detect.")
    
    handler = Param(Params._dummy(), "handler", "Which strategy to use when handling requests")
    
    largePersonGroupId = Param(Params._dummy(), "largePersonGroupId", "ServiceParam: Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.")
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    personGroupId = Param(Params._dummy(), "personGroupId", "ServiceParam: Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.")
    
    personId = Param(Params._dummy(), "personId", "ServiceParam: Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.")
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        concurrency=1,
        concurrentTimeout=None,
        errorCol="VerifyFaces_e1286bb44ba3_error",
        faceId=None,
        faceIdCol=None,
        faceId1=None,
        faceId1Col=None,
        faceId2=None,
        faceId2Col=None,
        handler=None,
        largePersonGroupId=None,
        largePersonGroupIdCol=None,
        outputCol="VerifyFaces_e1286bb44ba3_output",
        personGroupId=None,
        personGroupIdCol=None,
        personId=None,
        personIdCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        timeout=60.0,
        url=None
        ):
        super(VerifyFaces, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.VerifyFaces", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="VerifyFaces_e1286bb44ba3_error")
        self._setDefault(outputCol="VerifyFaces_e1286bb44ba3_output")
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
        errorCol="VerifyFaces_e1286bb44ba3_error",
        faceId=None,
        faceIdCol=None,
        faceId1=None,
        faceId1Col=None,
        faceId2=None,
        faceId2Col=None,
        handler=None,
        largePersonGroupId=None,
        largePersonGroupIdCol=None,
        outputCol="VerifyFaces_e1286bb44ba3_output",
        personGroupId=None,
        personGroupIdCol=None,
        personId=None,
        personIdCol=None,
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
        return "com.microsoft.azure.synapse.ml.cognitive.VerifyFaces"

    @staticmethod
    def _from_java(java_stage):
        module_name=VerifyFaces.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".VerifyFaces"
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
    
    def setFaceId(self, value):
        """
        Args:
            faceId: faceId of the face, comes from Face - Detect.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setFaceId(value)
        return self
    
    def setFaceIdCol(self, value):
        """
        Args:
            faceId: faceId of the face, comes from Face - Detect.
        """
        self._java_obj = self._java_obj.setFaceIdCol(value)
        return self
    
    def setFaceId1(self, value):
        """
        Args:
            faceId1: faceId of one face, comes from Face - Detect.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setFaceId1(value)
        return self
    
    def setFaceId1Col(self, value):
        """
        Args:
            faceId1: faceId of one face, comes from Face - Detect.
        """
        self._java_obj = self._java_obj.setFaceId1Col(value)
        return self
    
    def setFaceId2(self, value):
        """
        Args:
            faceId2: faceId of another face, comes from Face - Detect.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setFaceId2(value)
        return self
    
    def setFaceId2Col(self, value):
        """
        Args:
            faceId2: faceId of another face, comes from Face - Detect.
        """
        self._java_obj = self._java_obj.setFaceId2Col(value)
        return self
    
    def setHandler(self, value):
        """
        Args:
            handler: Which strategy to use when handling requests
        """
        self._set(handler=value)
        return self
    
    def setLargePersonGroupId(self, value):
        """
        Args:
            largePersonGroupId: Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setLargePersonGroupId(value)
        return self
    
    def setLargePersonGroupIdCol(self, value):
        """
        Args:
            largePersonGroupId: Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        """
        self._java_obj = self._java_obj.setLargePersonGroupIdCol(value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
        return self
    
    def setPersonGroupId(self, value):
        """
        Args:
            personGroupId: Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setPersonGroupId(value)
        return self
    
    def setPersonGroupIdCol(self, value):
        """
        Args:
            personGroupId: Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        """
        self._java_obj = self._java_obj.setPersonGroupIdCol(value)
        return self
    
    def setPersonId(self, value):
        """
        Args:
            personId: Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setPersonId(value)
        return self
    
    def setPersonIdCol(self, value):
        """
        Args:
            personId: Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
        """
        self._java_obj = self._java_obj.setPersonIdCol(value)
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
    
    
    def getFaceId(self):
        """
        Returns:
            faceId: faceId of the face, comes from Face - Detect.
        """
        return self._java_obj.getFaceId()
    
    
    def getFaceId1(self):
        """
        Returns:
            faceId1: faceId of one face, comes from Face - Detect.
        """
        return self._java_obj.getFaceId1()
    
    
    def getFaceId2(self):
        """
        Returns:
            faceId2: faceId of another face, comes from Face - Detect.
        """
        return self._java_obj.getFaceId2()
    
    
    def getHandler(self):
        """
        Returns:
            handler: Which strategy to use when handling requests
        """
        return self.getOrDefault(self.handler)
    
    
    def getLargePersonGroupId(self):
        """
        Returns:
            largePersonGroupId: Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        """
        return self._java_obj.getLargePersonGroupId()
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)
    
    
    def getPersonGroupId(self):
        """
        Returns:
            personGroupId: Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        """
        return self._java_obj.getPersonGroupId()
    
    
    def getPersonId(self):
        """
        Returns:
            personId: Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
        """
        return self._java_obj.getPersonId()
    
    
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
        