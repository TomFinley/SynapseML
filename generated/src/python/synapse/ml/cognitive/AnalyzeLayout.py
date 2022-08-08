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
class AnalyzeLayout(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        backoffs (list): array of backoffs to use in the handler
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        errorCol (str): column to hold http errors
        imageBytes (object): bytestream of the image to use
        imageUrl (object): the url of the image to use
        initialPollingDelay (int): number of milliseconds to wait before first poll for result
        language (object): The BCP-47 language code of the text in the document. Layout supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
        maxPollingRetries (int): number of times to poll
        modelVersion (object): This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        outputCol (str): The name of the output column
        pages (object): The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        pollingDelay (int): number of milliseconds to wait between polling
        readingOrder (object): Optional parameter to specify which reading order algorithm should be applied when ordering the extract text elements. Can be either 'basic' or 'natural'. Will default to basic if not specified
        subscriptionKey (object): the API key to use
        suppressMaxRetriesExceededException (bool): set true to suppress the maxumimum retries exception and report in the error column
        timeout (float): number of seconds to wait before closing the connection
        url (str): Url of the service
    """

    backoffs = Param(Params._dummy(), "backoffs", "array of backoffs to use in the handler", typeConverter=TypeConverters.toListInt)
    
    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    imageBytes = Param(Params._dummy(), "imageBytes", "ServiceParam: bytestream of the image to use")
    
    imageUrl = Param(Params._dummy(), "imageUrl", "ServiceParam: the url of the image to use")
    
    initialPollingDelay = Param(Params._dummy(), "initialPollingDelay", "number of milliseconds to wait before first poll for result", typeConverter=TypeConverters.toInt)
    
    language = Param(Params._dummy(), "language", "ServiceParam: The BCP-47 language code of the text in the document. Layout supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.")
    
    maxPollingRetries = Param(Params._dummy(), "maxPollingRetries", "number of times to poll", typeConverter=TypeConverters.toInt)
    
    modelVersion = Param(Params._dummy(), "modelVersion", "ServiceParam: This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.")
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    pages = Param(Params._dummy(), "pages", "ServiceParam: The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.")
    
    pollingDelay = Param(Params._dummy(), "pollingDelay", "number of milliseconds to wait between polling", typeConverter=TypeConverters.toInt)
    
    readingOrder = Param(Params._dummy(), "readingOrder", "ServiceParam: Optional parameter to specify which reading order algorithm should be applied when ordering the extract text elements. Can be either 'basic' or 'natural'. Will default to basic if not specified")
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    suppressMaxRetriesExceededException = Param(Params._dummy(), "suppressMaxRetriesExceededException", "set true to suppress the maxumimum retries exception and report in the error column", typeConverter=TypeConverters.toBoolean)
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        backoffs=[100,500,1000],
        concurrency=1,
        concurrentTimeout=None,
        errorCol="AnalyzeLayout_7b070ea68d02_error",
        imageBytes=None,
        imageBytesCol=None,
        imageUrl=None,
        imageUrlCol=None,
        initialPollingDelay=300,
        language=None,
        languageCol=None,
        maxPollingRetries=1000,
        modelVersion=None,
        modelVersionCol=None,
        outputCol="AnalyzeLayout_7b070ea68d02_output",
        pages=None,
        pagesCol=None,
        pollingDelay=300,
        readingOrder=None,
        readingOrderCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        suppressMaxRetriesExceededException=False,
        timeout=60.0,
        url=None
        ):
        super(AnalyzeLayout, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.AnalyzeLayout", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(backoffs=[100,500,1000])
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="AnalyzeLayout_7b070ea68d02_error")
        self._setDefault(initialPollingDelay=300)
        self._setDefault(maxPollingRetries=1000)
        self._setDefault(outputCol="AnalyzeLayout_7b070ea68d02_output")
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
        errorCol="AnalyzeLayout_7b070ea68d02_error",
        imageBytes=None,
        imageBytesCol=None,
        imageUrl=None,
        imageUrlCol=None,
        initialPollingDelay=300,
        language=None,
        languageCol=None,
        maxPollingRetries=1000,
        modelVersion=None,
        modelVersionCol=None,
        outputCol="AnalyzeLayout_7b070ea68d02_output",
        pages=None,
        pagesCol=None,
        pollingDelay=300,
        readingOrder=None,
        readingOrderCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        suppressMaxRetriesExceededException=False,
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
        return "com.microsoft.azure.synapse.ml.cognitive.AnalyzeLayout"

    @staticmethod
    def _from_java(java_stage):
        module_name=AnalyzeLayout.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".AnalyzeLayout"
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
    
    def setInitialPollingDelay(self, value):
        """
        Args:
            initialPollingDelay: number of milliseconds to wait before first poll for result
        """
        self._set(initialPollingDelay=value)
        return self
    
    def setLanguage(self, value):
        """
        Args:
            language: The BCP-47 language code of the text in the document. Layout supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setLanguage(value)
        return self
    
    def setLanguageCol(self, value):
        """
        Args:
            language: The BCP-47 language code of the text in the document. Layout supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
        """
        self._java_obj = self._java_obj.setLanguageCol(value)
        return self
    
    def setMaxPollingRetries(self, value):
        """
        Args:
            maxPollingRetries: number of times to poll
        """
        self._set(maxPollingRetries=value)
        return self
    
    def setModelVersion(self, value):
        """
        Args:
            modelVersion: This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setModelVersion(value)
        return self
    
    def setModelVersionCol(self, value):
        """
        Args:
            modelVersion: This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        """
        self._java_obj = self._java_obj.setModelVersionCol(value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
        return self
    
    def setPages(self, value):
        """
        Args:
            pages: The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setPages(value)
        return self
    
    def setPagesCol(self, value):
        """
        Args:
            pages: The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        """
        self._java_obj = self._java_obj.setPagesCol(value)
        return self
    
    def setPollingDelay(self, value):
        """
        Args:
            pollingDelay: number of milliseconds to wait between polling
        """
        self._set(pollingDelay=value)
        return self
    
    def setReadingOrder(self, value):
        """
        Args:
            readingOrder: Optional parameter to specify which reading order algorithm should be applied when ordering the extract text elements. Can be either 'basic' or 'natural'. Will default to basic if not specified
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setReadingOrder(value)
        return self
    
    def setReadingOrderCol(self, value):
        """
        Args:
            readingOrder: Optional parameter to specify which reading order algorithm should be applied when ordering the extract text elements. Can be either 'basic' or 'natural'. Will default to basic if not specified
        """
        self._java_obj = self._java_obj.setReadingOrderCol(value)
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
    
    
    def getInitialPollingDelay(self):
        """
        Returns:
            initialPollingDelay: number of milliseconds to wait before first poll for result
        """
        return self.getOrDefault(self.initialPollingDelay)
    
    
    def getLanguage(self):
        """
        Returns:
            language: The BCP-47 language code of the text in the document. Layout supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
        """
        return self._java_obj.getLanguage()
    
    
    def getMaxPollingRetries(self):
        """
        Returns:
            maxPollingRetries: number of times to poll
        """
        return self.getOrDefault(self.maxPollingRetries)
    
    
    def getModelVersion(self):
        """
        Returns:
            modelVersion: This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        """
        return self._java_obj.getModelVersion()
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)
    
    
    def getPages(self):
        """
        Returns:
            pages: The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        """
        return self._java_obj.getPages()
    
    
    def getPollingDelay(self):
        """
        Returns:
            pollingDelay: number of milliseconds to wait between polling
        """
        return self.getOrDefault(self.pollingDelay)
    
    
    def getReadingOrder(self):
        """
        Returns:
            readingOrder: Optional parameter to specify which reading order algorithm should be applied when ordering the extract text elements. Can be either 'basic' or 'natural'. Will default to basic if not specified
        """
        return self._java_obj.getReadingOrder()
    
    
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
        