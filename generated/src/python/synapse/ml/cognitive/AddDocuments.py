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
class AddDocuments(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        actionCol (str):  You can combine actions, such as an upload and a delete, in the same batch.  upload: An upload action is similar to an 'upsert' where the document will be inserted if it is new and updated/replaced if it exists. Note that all fields are replaced in the update case.  merge: Merge updates an existing document with the specified fields. If the document doesn't exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This includes fields of type Collection(Edm.String). For example, if the document contains a field 'tags' with value ['budget'] and you execute a merge with value ['economy', 'pool'] for 'tags', the final value of the 'tags' field will be ['economy', 'pool'].  It will not be ['budget', 'economy', 'pool'].  mergeOrUpload: This action behaves like merge if a document  with the given key already exists in the index.  If the document does not exist, it behaves like upload with a new document.  delete: Delete removes the specified document from the index.  Note that any field you specify in a delete operation,  other than the key field, will be ignored. If you want to   remove an individual field from a document, use merge   instead and simply set the field explicitly to null.     
        batchSize (int): The max size of the buffer
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        errorCol (str): column to hold http errors
        handler (object): Which strategy to use when handling requests
        indexName (str): 
        outputCol (str): The name of the output column
        serviceName (str): 
        subscriptionKey (object): the API key to use
        timeout (float): number of seconds to wait before closing the connection
        url (str): Url of the service
    """

    actionCol = Param(Params._dummy(), "actionCol", " You can combine actions, such as an upload and a delete, in the same batch.  upload: An upload action is similar to an 'upsert' where the document will be inserted if it is new and updated/replaced if it exists. Note that all fields are replaced in the update case.  merge: Merge updates an existing document with the specified fields. If the document doesn't exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This includes fields of type Collection(Edm.String). For example, if the document contains a field 'tags' with value ['budget'] and you execute a merge with value ['economy', 'pool'] for 'tags', the final value of the 'tags' field will be ['economy', 'pool'].  It will not be ['budget', 'economy', 'pool'].  mergeOrUpload: This action behaves like merge if a document  with the given key already exists in the index.  If the document does not exist, it behaves like upload with a new document.  delete: Delete removes the specified document from the index.  Note that any field you specify in a delete operation,  other than the key field, will be ignored. If you want to   remove an individual field from a document, use merge   instead and simply set the field explicitly to null.     ", typeConverter=TypeConverters.toString)
    
    batchSize = Param(Params._dummy(), "batchSize", "The max size of the buffer", typeConverter=TypeConverters.toInt)
    
    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    handler = Param(Params._dummy(), "handler", "Which strategy to use when handling requests")
    
    indexName = Param(Params._dummy(), "indexName", "", typeConverter=TypeConverters.toString)
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    serviceName = Param(Params._dummy(), "serviceName", "", typeConverter=TypeConverters.toString)
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        actionCol="@search.action",
        batchSize=100,
        concurrency=1,
        concurrentTimeout=None,
        errorCol="AddDocuments_654362e03462_error",
        handler=None,
        indexName=None,
        outputCol="AddDocuments_654362e03462_output",
        serviceName=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        timeout=60.0,
        url=None
        ):
        super(AddDocuments, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.AddDocuments", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(actionCol="@search.action")
        self._setDefault(batchSize=100)
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="AddDocuments_654362e03462_error")
        self._setDefault(outputCol="AddDocuments_654362e03462_output")
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
        actionCol="@search.action",
        batchSize=100,
        concurrency=1,
        concurrentTimeout=None,
        errorCol="AddDocuments_654362e03462_error",
        handler=None,
        indexName=None,
        outputCol="AddDocuments_654362e03462_output",
        serviceName=None,
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
        return "com.microsoft.azure.synapse.ml.cognitive.AddDocuments"

    @staticmethod
    def _from_java(java_stage):
        module_name=AddDocuments.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".AddDocuments"
        return from_java(java_stage, module_name)

    def setActionCol(self, value):
        """
        Args:
            actionCol:  You can combine actions, such as an upload and a delete, in the same batch.  upload: An upload action is similar to an 'upsert' where the document will be inserted if it is new and updated/replaced if it exists. Note that all fields are replaced in the update case.  merge: Merge updates an existing document with the specified fields. If the document doesn't exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This includes fields of type Collection(Edm.String). For example, if the document contains a field 'tags' with value ['budget'] and you execute a merge with value ['economy', 'pool'] for 'tags', the final value of the 'tags' field will be ['economy', 'pool'].  It will not be ['budget', 'economy', 'pool'].  mergeOrUpload: This action behaves like merge if a document  with the given key already exists in the index.  If the document does not exist, it behaves like upload with a new document.  delete: Delete removes the specified document from the index.  Note that any field you specify in a delete operation,  other than the key field, will be ignored. If you want to   remove an individual field from a document, use merge   instead and simply set the field explicitly to null.     
        """
        self._set(actionCol=value)
        return self
    
    def setBatchSize(self, value):
        """
        Args:
            batchSize: The max size of the buffer
        """
        self._set(batchSize=value)
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
    
    def setHandler(self, value):
        """
        Args:
            handler: Which strategy to use when handling requests
        """
        self._set(handler=value)
        return self
    
    def setIndexName(self, value):
        """
        Args:
            indexName: 
        """
        self._set(indexName=value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
        return self
    
    def setServiceName(self, value):
        """
        Args:
            serviceName: 
        """
        self._set(serviceName=value)
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

    
    def getActionCol(self):
        """
        Returns:
            actionCol:  You can combine actions, such as an upload and a delete, in the same batch.  upload: An upload action is similar to an 'upsert' where the document will be inserted if it is new and updated/replaced if it exists. Note that all fields are replaced in the update case.  merge: Merge updates an existing document with the specified fields. If the document doesn't exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This includes fields of type Collection(Edm.String). For example, if the document contains a field 'tags' with value ['budget'] and you execute a merge with value ['economy', 'pool'] for 'tags', the final value of the 'tags' field will be ['economy', 'pool'].  It will not be ['budget', 'economy', 'pool'].  mergeOrUpload: This action behaves like merge if a document  with the given key already exists in the index.  If the document does not exist, it behaves like upload with a new document.  delete: Delete removes the specified document from the index.  Note that any field you specify in a delete operation,  other than the key field, will be ignored. If you want to   remove an individual field from a document, use merge   instead and simply set the field explicitly to null.     
        """
        return self.getOrDefault(self.actionCol)
    
    
    def getBatchSize(self):
        """
        Returns:
            batchSize: The max size of the buffer
        """
        return self.getOrDefault(self.batchSize)
    
    
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
    
    
    def getIndexName(self):
        """
        Returns:
            indexName: 
        """
        return self.getOrDefault(self.indexName)
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)
    
    
    def getServiceName(self):
        """
        Returns:
            serviceName: 
        """
        return self.getOrDefault(self.serviceName)
    
    
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

    

    
    
        