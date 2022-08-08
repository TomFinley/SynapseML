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


@inherit_doc
class DictionaryExamples(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        errorCol (str): column to hold http errors
        fromLanguage (object): Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        handler (object): Which strategy to use when handling requests
        outputCol (str): The name of the output column
        subscriptionKey (object): the API key to use
        subscriptionRegion (object): the API region to use
        textAndTranslation (object):  A string specifying the translated text previously returned by the Dictionary lookup operation.
        timeout (float): number of seconds to wait before closing the connection
        toLanguage (object): Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        url (str): Url of the service
    """

    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    fromLanguage = Param(Params._dummy(), "fromLanguage", "ServiceParam: Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.")
    
    handler = Param(Params._dummy(), "handler", "Which strategy to use when handling requests")
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    subscriptionRegion = Param(Params._dummy(), "subscriptionRegion", "ServiceParam: the API region to use")
    
    textAndTranslation = Param(Params._dummy(), "textAndTranslation", "ServiceParam:  A string specifying the translated text previously returned by the Dictionary lookup operation.")
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    toLanguage = Param(Params._dummy(), "toLanguage", "ServiceParam: Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.")
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        concurrency=1,
        concurrentTimeout=None,
        errorCol="DictionaryExamples_0081d46ac3c9_error",
        fromLanguage=None,
        fromLanguageCol=None,
        handler=None,
        outputCol="DictionaryExamples_0081d46ac3c9_output",
        subscriptionKey=None,
        subscriptionKeyCol=None,
        subscriptionRegion=None,
        subscriptionRegionCol=None,
        textAndTranslation=None,
        textAndTranslationCol=None,
        timeout=60.0,
        toLanguage=None,
        toLanguageCol=None,
        url=None
        ):
        super(DictionaryExamples, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.DictionaryExamples", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="DictionaryExamples_0081d46ac3c9_error")
        self._setDefault(outputCol="DictionaryExamples_0081d46ac3c9_output")
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
        errorCol="DictionaryExamples_0081d46ac3c9_error",
        fromLanguage=None,
        fromLanguageCol=None,
        handler=None,
        outputCol="DictionaryExamples_0081d46ac3c9_output",
        subscriptionKey=None,
        subscriptionKeyCol=None,
        subscriptionRegion=None,
        subscriptionRegionCol=None,
        textAndTranslation=None,
        textAndTranslationCol=None,
        timeout=60.0,
        toLanguage=None,
        toLanguageCol=None,
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
        return "com.microsoft.azure.synapse.ml.cognitive.DictionaryExamples"

    @staticmethod
    def _from_java(java_stage):
        module_name=DictionaryExamples.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".DictionaryExamples"
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
    
    def setFromLanguage(self, value):
        """
        Args:
            fromLanguage: Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setFromLanguage(value)
        return self
    
    def setFromLanguageCol(self, value):
        """
        Args:
            fromLanguage: Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        """
        self._java_obj = self._java_obj.setFromLanguageCol(value)
        return self
    
    def setHandler(self, value):
        """
        Args:
            handler: Which strategy to use when handling requests
        """
        self._set(handler=value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
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
    
    def setSubscriptionRegion(self, value):
        """
        Args:
            subscriptionRegion: the API region to use
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setSubscriptionRegion(value)
        return self
    
    def setSubscriptionRegionCol(self, value):
        """
        Args:
            subscriptionRegion: the API region to use
        """
        self._java_obj = self._java_obj.setSubscriptionRegionCol(value)
        return self
    
    def setTextAndTranslation(self, value):
        """
        Args:
            textAndTranslation:  A string specifying the translated text previously returned by the Dictionary lookup operation.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setTextAndTranslation(value)
        return self
    
    def setTextAndTranslationCol(self, value):
        """
        Args:
            textAndTranslation:  A string specifying the translated text previously returned by the Dictionary lookup operation.
        """
        self._java_obj = self._java_obj.setTextAndTranslationCol(value)
        return self
    
    def setTimeout(self, value):
        """
        Args:
            timeout: number of seconds to wait before closing the connection
        """
        self._set(timeout=value)
        return self
    
    def setToLanguage(self, value):
        """
        Args:
            toLanguage: Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setToLanguage(value)
        return self
    
    def setToLanguageCol(self, value):
        """
        Args:
            toLanguage: Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        """
        self._java_obj = self._java_obj.setToLanguageCol(value)
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
    
    
    def getFromLanguage(self):
        """
        Returns:
            fromLanguage: Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        """
        return self._java_obj.getFromLanguage()
    
    
    def getHandler(self):
        """
        Returns:
            handler: Which strategy to use when handling requests
        """
        return self.getOrDefault(self.handler)
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)
    
    
    def getSubscriptionKey(self):
        """
        Returns:
            subscriptionKey: the API key to use
        """
        return self._java_obj.getSubscriptionKey()
    
    
    def getSubscriptionRegion(self):
        """
        Returns:
            subscriptionRegion: the API region to use
        """
        return self._java_obj.getSubscriptionRegion()
    
    
    def getTextAndTranslation(self):
        """
        Returns:
            textAndTranslation:  A string specifying the translated text previously returned by the Dictionary lookup operation.
        """
        return self._java_obj.getTextAndTranslation()
    
    
    def getTimeout(self):
        """
        Returns:
            timeout: number of seconds to wait before closing the connection
        """
        return self.getOrDefault(self.timeout)
    
    
    def getToLanguage(self):
        """
        Returns:
            toLanguage: Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        """
        return self._java_obj.getToLanguage()
    
    
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
        