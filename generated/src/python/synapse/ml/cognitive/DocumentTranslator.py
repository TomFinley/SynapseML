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
class DocumentTranslator(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        backoffs (list): array of backoffs to use in the handler
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        errorCol (str): column to hold http errors
        filterPrefix (object): A case-sensitive prefix string to filter documents in the source path for translation. For example, when using an Azure storage blob Uri, use the prefix to restrict sub folders for translation.
        filterSuffix (object): A case-sensitive suffix string to filter documents in the source path for translation. This is most often use for file extensions.
        initialPollingDelay (int): number of milliseconds to wait before first poll for result
        maxPollingRetries (int): number of times to poll
        outputCol (str): The name of the output column
        pollingDelay (int): number of milliseconds to wait between polling
        serviceName (str): 
        sourceLanguage (object): Language code. If none is specified, we will perform auto detect on the document.
        sourceStorageSource (object): Storage source of source input.
        sourceUrl (object): Location of the folder / container or single file with your documents.
        storageType (object): Storage type of the input documents source string. Required for single document translation only.
        subscriptionKey (object): the API key to use
        suppressMaxRetriesExceededException (bool): set true to suppress the maxumimum retries exception and report in the error column
        targets (object): Destination for the finished translated documents.
        timeout (float): number of seconds to wait before closing the connection
        url (str): Url of the service
    """

    backoffs = Param(Params._dummy(), "backoffs", "array of backoffs to use in the handler", typeConverter=TypeConverters.toListInt)
    
    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    filterPrefix = Param(Params._dummy(), "filterPrefix", "ServiceParam: A case-sensitive prefix string to filter documents in the source path for translation. For example, when using an Azure storage blob Uri, use the prefix to restrict sub folders for translation.")
    
    filterSuffix = Param(Params._dummy(), "filterSuffix", "ServiceParam: A case-sensitive suffix string to filter documents in the source path for translation. This is most often use for file extensions.")
    
    initialPollingDelay = Param(Params._dummy(), "initialPollingDelay", "number of milliseconds to wait before first poll for result", typeConverter=TypeConverters.toInt)
    
    maxPollingRetries = Param(Params._dummy(), "maxPollingRetries", "number of times to poll", typeConverter=TypeConverters.toInt)
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    pollingDelay = Param(Params._dummy(), "pollingDelay", "number of milliseconds to wait between polling", typeConverter=TypeConverters.toInt)
    
    serviceName = Param(Params._dummy(), "serviceName", "", typeConverter=TypeConverters.toString)
    
    sourceLanguage = Param(Params._dummy(), "sourceLanguage", "ServiceParam: Language code. If none is specified, we will perform auto detect on the document.")
    
    sourceStorageSource = Param(Params._dummy(), "sourceStorageSource", "ServiceParam: Storage source of source input.")
    
    sourceUrl = Param(Params._dummy(), "sourceUrl", "ServiceParam: Location of the folder / container or single file with your documents.")
    
    storageType = Param(Params._dummy(), "storageType", "ServiceParam: Storage type of the input documents source string. Required for single document translation only.")
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    suppressMaxRetriesExceededException = Param(Params._dummy(), "suppressMaxRetriesExceededException", "set true to suppress the maxumimum retries exception and report in the error column", typeConverter=TypeConverters.toBoolean)
    
    targets = Param(Params._dummy(), "targets", "ServiceParam: Destination for the finished translated documents.")
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        backoffs=[100,500,1000],
        concurrency=1,
        concurrentTimeout=None,
        errorCol="DocumentTranslator_55d7fba51969_error",
        filterPrefix=None,
        filterPrefixCol=None,
        filterSuffix=None,
        filterSuffixCol=None,
        initialPollingDelay=300,
        maxPollingRetries=1000,
        outputCol="DocumentTranslator_55d7fba51969_output",
        pollingDelay=300,
        serviceName=None,
        sourceLanguage=None,
        sourceLanguageCol=None,
        sourceStorageSource=None,
        sourceStorageSourceCol=None,
        sourceUrl=None,
        sourceUrlCol=None,
        storageType=None,
        storageTypeCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        suppressMaxRetriesExceededException=False,
        targets=None,
        targetsCol=None,
        timeout=60.0,
        url=None
        ):
        super(DocumentTranslator, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.DocumentTranslator", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(backoffs=[100,500,1000])
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="DocumentTranslator_55d7fba51969_error")
        self._setDefault(initialPollingDelay=300)
        self._setDefault(maxPollingRetries=1000)
        self._setDefault(outputCol="DocumentTranslator_55d7fba51969_output")
        self._setDefault(pollingDelay=300)
        self._setDefault(suppressMaxRetriesExceededException=False)
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
        backoffs=[100,500,1000],
        concurrency=1,
        concurrentTimeout=None,
        errorCol="DocumentTranslator_55d7fba51969_error",
        filterPrefix=None,
        filterPrefixCol=None,
        filterSuffix=None,
        filterSuffixCol=None,
        initialPollingDelay=300,
        maxPollingRetries=1000,
        outputCol="DocumentTranslator_55d7fba51969_output",
        pollingDelay=300,
        serviceName=None,
        sourceLanguage=None,
        sourceLanguageCol=None,
        sourceStorageSource=None,
        sourceStorageSourceCol=None,
        sourceUrl=None,
        sourceUrlCol=None,
        storageType=None,
        storageTypeCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        suppressMaxRetriesExceededException=False,
        targets=None,
        targetsCol=None,
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
        return "com.microsoft.azure.synapse.ml.cognitive.DocumentTranslator"

    @staticmethod
    def _from_java(java_stage):
        module_name=DocumentTranslator.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".DocumentTranslator"
        return from_java(java_stage, module_name)

    def setBackoffs(self, value):
        """
        Args:
            backoffs: array of backoffs to use in the handler
        """
        self._set(backoffs=value)
        return self
    
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
    
    def setFilterPrefix(self, value):
        """
        Args:
            filterPrefix: A case-sensitive prefix string to filter documents in the source path for translation. For example, when using an Azure storage blob Uri, use the prefix to restrict sub folders for translation.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setFilterPrefix(value)
        return self
    
    def setFilterPrefixCol(self, value):
        """
        Args:
            filterPrefix: A case-sensitive prefix string to filter documents in the source path for translation. For example, when using an Azure storage blob Uri, use the prefix to restrict sub folders for translation.
        """
        self._java_obj = self._java_obj.setFilterPrefixCol(value)
        return self
    
    def setFilterSuffix(self, value):
        """
        Args:
            filterSuffix: A case-sensitive suffix string to filter documents in the source path for translation. This is most often use for file extensions.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setFilterSuffix(value)
        return self
    
    def setFilterSuffixCol(self, value):
        """
        Args:
            filterSuffix: A case-sensitive suffix string to filter documents in the source path for translation. This is most often use for file extensions.
        """
        self._java_obj = self._java_obj.setFilterSuffixCol(value)
        return self
    
    def setInitialPollingDelay(self, value):
        """
        Args:
            initialPollingDelay: number of milliseconds to wait before first poll for result
        """
        self._set(initialPollingDelay=value)
        return self
    
    def setMaxPollingRetries(self, value):
        """
        Args:
            maxPollingRetries: number of times to poll
        """
        self._set(maxPollingRetries=value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
        return self
    
    def setPollingDelay(self, value):
        """
        Args:
            pollingDelay: number of milliseconds to wait between polling
        """
        self._set(pollingDelay=value)
        return self
    
    def setServiceName(self, value):
        """
        Args:
            serviceName: 
        """
        self._set(serviceName=value)
        return self
    
    def setSourceLanguage(self, value):
        """
        Args:
            sourceLanguage: Language code. If none is specified, we will perform auto detect on the document.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setSourceLanguage(value)
        return self
    
    def setSourceLanguageCol(self, value):
        """
        Args:
            sourceLanguage: Language code. If none is specified, we will perform auto detect on the document.
        """
        self._java_obj = self._java_obj.setSourceLanguageCol(value)
        return self
    
    def setSourceStorageSource(self, value):
        """
        Args:
            sourceStorageSource: Storage source of source input.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setSourceStorageSource(value)
        return self
    
    def setSourceStorageSourceCol(self, value):
        """
        Args:
            sourceStorageSource: Storage source of source input.
        """
        self._java_obj = self._java_obj.setSourceStorageSourceCol(value)
        return self
    
    def setSourceUrl(self, value):
        """
        Args:
            sourceUrl: Location of the folder / container or single file with your documents.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setSourceUrl(value)
        return self
    
    def setSourceUrlCol(self, value):
        """
        Args:
            sourceUrl: Location of the folder / container or single file with your documents.
        """
        self._java_obj = self._java_obj.setSourceUrlCol(value)
        return self
    
    def setStorageType(self, value):
        """
        Args:
            storageType: Storage type of the input documents source string. Required for single document translation only.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setStorageType(value)
        return self
    
    def setStorageTypeCol(self, value):
        """
        Args:
            storageType: Storage type of the input documents source string. Required for single document translation only.
        """
        self._java_obj = self._java_obj.setStorageTypeCol(value)
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
    
    def setSuppressMaxRetriesExceededException(self, value):
        """
        Args:
            suppressMaxRetriesExceededException: set true to suppress the maxumimum retries exception and report in the error column
        """
        self._set(suppressMaxRetriesExceededException=value)
        return self
    
    def setTargets(self, value):
        """
        Args:
            targets: Destination for the finished translated documents.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setTargets(value)
        return self
    
    def setTargetsCol(self, value):
        """
        Args:
            targets: Destination for the finished translated documents.
        """
        self._java_obj = self._java_obj.setTargetsCol(value)
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

    
    def getBackoffs(self):
        """
        Returns:
            backoffs: array of backoffs to use in the handler
        """
        return self.getOrDefault(self.backoffs)
    
    
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
    
    
    def getFilterPrefix(self):
        """
        Returns:
            filterPrefix: A case-sensitive prefix string to filter documents in the source path for translation. For example, when using an Azure storage blob Uri, use the prefix to restrict sub folders for translation.
        """
        return self._java_obj.getFilterPrefix()
    
    
    def getFilterSuffix(self):
        """
        Returns:
            filterSuffix: A case-sensitive suffix string to filter documents in the source path for translation. This is most often use for file extensions.
        """
        return self._java_obj.getFilterSuffix()
    
    
    def getInitialPollingDelay(self):
        """
        Returns:
            initialPollingDelay: number of milliseconds to wait before first poll for result
        """
        return self.getOrDefault(self.initialPollingDelay)
    
    
    def getMaxPollingRetries(self):
        """
        Returns:
            maxPollingRetries: number of times to poll
        """
        return self.getOrDefault(self.maxPollingRetries)
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)
    
    
    def getPollingDelay(self):
        """
        Returns:
            pollingDelay: number of milliseconds to wait between polling
        """
        return self.getOrDefault(self.pollingDelay)
    
    
    def getServiceName(self):
        """
        Returns:
            serviceName: 
        """
        return self.getOrDefault(self.serviceName)
    
    
    def getSourceLanguage(self):
        """
        Returns:
            sourceLanguage: Language code. If none is specified, we will perform auto detect on the document.
        """
        return self._java_obj.getSourceLanguage()
    
    
    def getSourceStorageSource(self):
        """
        Returns:
            sourceStorageSource: Storage source of source input.
        """
        return self._java_obj.getSourceStorageSource()
    
    
    def getSourceUrl(self):
        """
        Returns:
            sourceUrl: Location of the folder / container or single file with your documents.
        """
        return self._java_obj.getSourceUrl()
    
    
    def getStorageType(self):
        """
        Returns:
            storageType: Storage type of the input documents source string. Required for single document translation only.
        """
        return self._java_obj.getStorageType()
    
    
    def getSubscriptionKey(self):
        """
        Returns:
            subscriptionKey: the API key to use
        """
        return self._java_obj.getSubscriptionKey()
    
    
    def getSuppressMaxRetriesExceededException(self):
        """
        Returns:
            suppressMaxRetriesExceededException: set true to suppress the maxumimum retries exception and report in the error column
        """
        return self.getOrDefault(self.suppressMaxRetriesExceededException)
    
    
    def getTargets(self):
        """
        Returns:
            targets: Destination for the finished translated documents.
        """
        return self._java_obj.getTargets()
    
    
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

    

    
    
    def setLinkedService(self, value):
        self._java_obj = self._java_obj.setLinkedService(value)
        return self
        