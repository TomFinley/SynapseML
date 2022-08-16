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
class GenerateThumbnails(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        errorCol (str): column to hold http errors
        handler (object): Which strategy to use when handling requests
        height (object): the desired height of the image
        imageBytes (object): bytestream of the image to use
        imageUrl (object): the url of the image to use
        outputCol (str): The name of the output column
        smartCropping (object): whether to intelligently crop the image
        subscriptionKey (object): the API key to use
        timeout (float): number of seconds to wait before closing the connection
        url (str): Url of the service
        width (object): the desired width of the image
    """

    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    handler = Param(Params._dummy(), "handler", "Which strategy to use when handling requests")
    
    height = Param(Params._dummy(), "height", "ServiceParam: the desired height of the image")
    
    imageBytes = Param(Params._dummy(), "imageBytes", "ServiceParam: bytestream of the image to use")
    
    imageUrl = Param(Params._dummy(), "imageUrl", "ServiceParam: the url of the image to use")
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    smartCropping = Param(Params._dummy(), "smartCropping", "ServiceParam: whether to intelligently crop the image")
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)
    
    width = Param(Params._dummy(), "width", "ServiceParam: the desired width of the image")

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        concurrency=1,
        concurrentTimeout=None,
        errorCol="GenerateThumbnails_14ec2c2708c3_error",
        handler=None,
        height=None,
        heightCol=None,
        imageBytes=None,
        imageBytesCol=None,
        imageUrl=None,
        imageUrlCol=None,
        outputCol="GenerateThumbnails_14ec2c2708c3_output",
        smartCropping=None,
        smartCroppingCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        timeout=60.0,
        url=None,
        width=None,
        widthCol=None
        ):
        super(GenerateThumbnails, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.GenerateThumbnails", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="GenerateThumbnails_14ec2c2708c3_error")
        self._setDefault(outputCol="GenerateThumbnails_14ec2c2708c3_output")
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
        errorCol="GenerateThumbnails_14ec2c2708c3_error",
        handler=None,
        height=None,
        heightCol=None,
        imageBytes=None,
        imageBytesCol=None,
        imageUrl=None,
        imageUrlCol=None,
        outputCol="GenerateThumbnails_14ec2c2708c3_output",
        smartCropping=None,
        smartCroppingCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        timeout=60.0,
        url=None,
        width=None,
        widthCol=None
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
        return "com.microsoft.azure.synapse.ml.cognitive.GenerateThumbnails"

    @staticmethod
    def _from_java(java_stage):
        module_name=GenerateThumbnails.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".GenerateThumbnails"
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
    
    def setHeight(self, value):
        """
        Args:
            height: the desired height of the image
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setHeight(value)
        return self
    
    def setHeightCol(self, value):
        """
        Args:
            height: the desired height of the image
        """
        self._java_obj = self._java_obj.setHeightCol(value)
        return self
    
    def setImageBytes(self, value):
        """
        Args:
            imageBytes: bytestream of the image to use
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setImageBytes(value)
        return self
    
    def setImageBytesCol(self, value):
        """
        Args:
            imageBytes: bytestream of the image to use
        """
        self._java_obj = self._java_obj.setImageBytesCol(value)
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
    
    def setSmartCropping(self, value):
        """
        Args:
            smartCropping: whether to intelligently crop the image
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setSmartCropping(value)
        return self
    
    def setSmartCroppingCol(self, value):
        """
        Args:
            smartCropping: whether to intelligently crop the image
        """
        self._java_obj = self._java_obj.setSmartCroppingCol(value)
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
    
    def setWidth(self, value):
        """
        Args:
            width: the desired width of the image
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setWidth(value)
        return self
    
    def setWidthCol(self, value):
        """
        Args:
            width: the desired width of the image
        """
        self._java_obj = self._java_obj.setWidthCol(value)
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
    
    
    def getHeight(self):
        """
        Returns:
            height: the desired height of the image
        """
        return self._java_obj.getHeight()
    
    
    def getImageBytes(self):
        """
        Returns:
            imageBytes: bytestream of the image to use
        """
        return self._java_obj.getImageBytes()
    
    
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
    
    
    def getSmartCropping(self):
        """
        Returns:
            smartCropping: whether to intelligently crop the image
        """
        return self._java_obj.getSmartCropping()
    
    
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
    
    
    def getWidth(self):
        """
        Returns:
            width: the desired width of the image
        """
        return self._java_obj.getWidth()

    

    
    
    def setLocation(self, value):
        self._java_obj = self._java_obj.setLocation(value)
        return self
    
    def setLinkedService(self, value):
        self._java_obj = self._java_obj.setLinkedService(value)
        return self
        