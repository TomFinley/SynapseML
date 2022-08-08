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
class OpenAICompletion(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        apiVersion (object): version of the api
        batchIndexPrompt (object): Sequence of index sequences to complete
        batchPrompt (object): Sequence of prompts to complete
        bestOf (object): How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
        cacheLevel (object): can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
        concurrency (int): max number of concurrent calls
        concurrentTimeout (float): max number seconds to wait on futures if concurrency >= 1
        deploymentName (object): The name of the deployment
        echo (object): Echo back the prompt in addition to the completion
        errorCol (str): column to hold http errors
        frequencyPenalty (object): How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
        handler (object): Which strategy to use when handling requests
        indexPrompt (object): Sequence of indexes to complete
        logProbs (object): Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        maxTokens (object): The maximum number of tokens to generate. Has minimum of 0.
        model (object): The name of the model to use
        n (object): How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
        outputCol (str): The name of the output column
        presencePenalty (object): How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
        prompt (object): The text to complete
        stop (object): A sequence which indicates the end of the current document.
        subscriptionKey (object): the API key to use
        temperature (object): What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
        timeout (float): number of seconds to wait before closing the connection
        topP (object): An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
        url (str): Url of the service
        user (object): The ID of the end-user, for use in tracking and rate-limiting.
    """

    apiVersion = Param(Params._dummy(), "apiVersion", "ServiceParam: version of the api")
    
    batchIndexPrompt = Param(Params._dummy(), "batchIndexPrompt", "ServiceParam: Sequence of index sequences to complete")
    
    batchPrompt = Param(Params._dummy(), "batchPrompt", "ServiceParam: Sequence of prompts to complete")
    
    bestOf = Param(Params._dummy(), "bestOf", "ServiceParam: How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.")
    
    cacheLevel = Param(Params._dummy(), "cacheLevel", "ServiceParam: can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache")
    
    concurrency = Param(Params._dummy(), "concurrency", "max number of concurrent calls", typeConverter=TypeConverters.toInt)
    
    concurrentTimeout = Param(Params._dummy(), "concurrentTimeout", "max number seconds to wait on futures if concurrency >= 1", typeConverter=TypeConverters.toFloat)
    
    deploymentName = Param(Params._dummy(), "deploymentName", "ServiceParam: The name of the deployment")
    
    echo = Param(Params._dummy(), "echo", "ServiceParam: Echo back the prompt in addition to the completion")
    
    errorCol = Param(Params._dummy(), "errorCol", "column to hold http errors", typeConverter=TypeConverters.toString)
    
    frequencyPenalty = Param(Params._dummy(), "frequencyPenalty", "ServiceParam: How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.")
    
    handler = Param(Params._dummy(), "handler", "Which strategy to use when handling requests")
    
    indexPrompt = Param(Params._dummy(), "indexPrompt", "ServiceParam: Sequence of indexes to complete")
    
    logProbs = Param(Params._dummy(), "logProbs", "ServiceParam: Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.")
    
    maxTokens = Param(Params._dummy(), "maxTokens", "ServiceParam: The maximum number of tokens to generate. Has minimum of 0.")
    
    model = Param(Params._dummy(), "model", "ServiceParam: The name of the model to use")
    
    n = Param(Params._dummy(), "n", "ServiceParam: How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.")
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)
    
    presencePenalty = Param(Params._dummy(), "presencePenalty", "ServiceParam: How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.")
    
    prompt = Param(Params._dummy(), "prompt", "ServiceParam: The text to complete")
    
    stop = Param(Params._dummy(), "stop", "ServiceParam: A sequence which indicates the end of the current document.")
    
    subscriptionKey = Param(Params._dummy(), "subscriptionKey", "ServiceParam: the API key to use")
    
    temperature = Param(Params._dummy(), "temperature", "ServiceParam: What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.")
    
    timeout = Param(Params._dummy(), "timeout", "number of seconds to wait before closing the connection", typeConverter=TypeConverters.toFloat)
    
    topP = Param(Params._dummy(), "topP", "ServiceParam: An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.")
    
    url = Param(Params._dummy(), "url", "Url of the service", typeConverter=TypeConverters.toString)
    
    user = Param(Params._dummy(), "user", "ServiceParam: The ID of the end-user, for use in tracking and rate-limiting.")

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        apiVersion=None,
        apiVersionCol=None,
        batchIndexPrompt=None,
        batchIndexPromptCol=None,
        batchPrompt=None,
        batchPromptCol=None,
        bestOf=None,
        bestOfCol=None,
        cacheLevel=None,
        cacheLevelCol=None,
        concurrency=1,
        concurrentTimeout=None,
        deploymentName=None,
        deploymentNameCol=None,
        echo=None,
        echoCol=None,
        errorCol="OpenAPICompletion_573e10118713_error",
        frequencyPenalty=None,
        frequencyPenaltyCol=None,
        handler=None,
        indexPrompt=None,
        indexPromptCol=None,
        logProbs=None,
        logProbsCol=None,
        maxTokens=None,
        maxTokensCol=None,
        model=None,
        modelCol=None,
        n=None,
        nCol=None,
        outputCol="OpenAPICompletion_573e10118713_output",
        presencePenalty=None,
        presencePenaltyCol=None,
        prompt=None,
        promptCol=None,
        stop=None,
        stopCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        temperature=None,
        temperatureCol=None,
        timeout=60.0,
        topP=None,
        topPCol=None,
        url=None,
        user=None,
        userCol=None
        ):
        super(OpenAICompletion, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.cognitive.OpenAICompletion", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(concurrency=1)
        self._setDefault(errorCol="OpenAPICompletion_573e10118713_error")
        self._setDefault(outputCol="OpenAPICompletion_573e10118713_output")
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
        apiVersion=None,
        apiVersionCol=None,
        batchIndexPrompt=None,
        batchIndexPromptCol=None,
        batchPrompt=None,
        batchPromptCol=None,
        bestOf=None,
        bestOfCol=None,
        cacheLevel=None,
        cacheLevelCol=None,
        concurrency=1,
        concurrentTimeout=None,
        deploymentName=None,
        deploymentNameCol=None,
        echo=None,
        echoCol=None,
        errorCol="OpenAPICompletion_573e10118713_error",
        frequencyPenalty=None,
        frequencyPenaltyCol=None,
        handler=None,
        indexPrompt=None,
        indexPromptCol=None,
        logProbs=None,
        logProbsCol=None,
        maxTokens=None,
        maxTokensCol=None,
        model=None,
        modelCol=None,
        n=None,
        nCol=None,
        outputCol="OpenAPICompletion_573e10118713_output",
        presencePenalty=None,
        presencePenaltyCol=None,
        prompt=None,
        promptCol=None,
        stop=None,
        stopCol=None,
        subscriptionKey=None,
        subscriptionKeyCol=None,
        temperature=None,
        temperatureCol=None,
        timeout=60.0,
        topP=None,
        topPCol=None,
        url=None,
        user=None,
        userCol=None
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
        return "com.microsoft.azure.synapse.ml.cognitive.OpenAICompletion"

    @staticmethod
    def _from_java(java_stage):
        module_name=OpenAICompletion.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".OpenAICompletion"
        return from_java(java_stage, module_name)

    def setApiVersion(self, value):
        """
        Args:
            apiVersion: version of the api
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setApiVersion(value)
        return self
    
    def setApiVersionCol(self, value):
        """
        Args:
            apiVersion: version of the api
        """
        self._java_obj = self._java_obj.setApiVersionCol(value)
        return self
    
    def setBatchIndexPrompt(self, value):
        """
        Args:
            batchIndexPrompt: Sequence of index sequences to complete
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setBatchIndexPrompt(value)
        return self
    
    def setBatchIndexPromptCol(self, value):
        """
        Args:
            batchIndexPrompt: Sequence of index sequences to complete
        """
        self._java_obj = self._java_obj.setBatchIndexPromptCol(value)
        return self
    
    def setBatchPrompt(self, value):
        """
        Args:
            batchPrompt: Sequence of prompts to complete
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setBatchPrompt(value)
        return self
    
    def setBatchPromptCol(self, value):
        """
        Args:
            batchPrompt: Sequence of prompts to complete
        """
        self._java_obj = self._java_obj.setBatchPromptCol(value)
        return self
    
    def setBestOf(self, value):
        """
        Args:
            bestOf: How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setBestOf(value)
        return self
    
    def setBestOfCol(self, value):
        """
        Args:
            bestOf: How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
        """
        self._java_obj = self._java_obj.setBestOfCol(value)
        return self
    
    def setCacheLevel(self, value):
        """
        Args:
            cacheLevel: can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setCacheLevel(value)
        return self
    
    def setCacheLevelCol(self, value):
        """
        Args:
            cacheLevel: can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
        """
        self._java_obj = self._java_obj.setCacheLevelCol(value)
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
    
    def setDeploymentName(self, value):
        """
        Args:
            deploymentName: The name of the deployment
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setDeploymentName(value)
        return self
    
    def setDeploymentNameCol(self, value):
        """
        Args:
            deploymentName: The name of the deployment
        """
        self._java_obj = self._java_obj.setDeploymentNameCol(value)
        return self
    
    def setEcho(self, value):
        """
        Args:
            echo: Echo back the prompt in addition to the completion
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setEcho(value)
        return self
    
    def setEchoCol(self, value):
        """
        Args:
            echo: Echo back the prompt in addition to the completion
        """
        self._java_obj = self._java_obj.setEchoCol(value)
        return self
    
    def setErrorCol(self, value):
        """
        Args:
            errorCol: column to hold http errors
        """
        self._set(errorCol=value)
        return self
    
    def setFrequencyPenalty(self, value):
        """
        Args:
            frequencyPenalty: How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setFrequencyPenalty(value)
        return self
    
    def setFrequencyPenaltyCol(self, value):
        """
        Args:
            frequencyPenalty: How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
        """
        self._java_obj = self._java_obj.setFrequencyPenaltyCol(value)
        return self
    
    def setHandler(self, value):
        """
        Args:
            handler: Which strategy to use when handling requests
        """
        self._set(handler=value)
        return self
    
    def setIndexPrompt(self, value):
        """
        Args:
            indexPrompt: Sequence of indexes to complete
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setIndexPrompt(value)
        return self
    
    def setIndexPromptCol(self, value):
        """
        Args:
            indexPrompt: Sequence of indexes to complete
        """
        self._java_obj = self._java_obj.setIndexPromptCol(value)
        return self
    
    def setLogProbs(self, value):
        """
        Args:
            logProbs: Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setLogProbs(value)
        return self
    
    def setLogProbsCol(self, value):
        """
        Args:
            logProbs: Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        """
        self._java_obj = self._java_obj.setLogProbsCol(value)
        return self
    
    def setMaxTokens(self, value):
        """
        Args:
            maxTokens: The maximum number of tokens to generate. Has minimum of 0.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setMaxTokens(value)
        return self
    
    def setMaxTokensCol(self, value):
        """
        Args:
            maxTokens: The maximum number of tokens to generate. Has minimum of 0.
        """
        self._java_obj = self._java_obj.setMaxTokensCol(value)
        return self
    
    def setModel(self, value):
        """
        Args:
            model: The name of the model to use
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setModel(value)
        return self
    
    def setModelCol(self, value):
        """
        Args:
            model: The name of the model to use
        """
        self._java_obj = self._java_obj.setModelCol(value)
        return self
    
    def setN(self, value):
        """
        Args:
            n: How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setN(value)
        return self
    
    def setNCol(self, value):
        """
        Args:
            n: How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
        """
        self._java_obj = self._java_obj.setNCol(value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
        return self
    
    def setPresencePenalty(self, value):
        """
        Args:
            presencePenalty: How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setPresencePenalty(value)
        return self
    
    def setPresencePenaltyCol(self, value):
        """
        Args:
            presencePenalty: How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
        """
        self._java_obj = self._java_obj.setPresencePenaltyCol(value)
        return self
    
    def setPrompt(self, value):
        """
        Args:
            prompt: The text to complete
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setPrompt(value)
        return self
    
    def setPromptCol(self, value):
        """
        Args:
            prompt: The text to complete
        """
        self._java_obj = self._java_obj.setPromptCol(value)
        return self
    
    def setStop(self, value):
        """
        Args:
            stop: A sequence which indicates the end of the current document.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setStop(value)
        return self
    
    def setStopCol(self, value):
        """
        Args:
            stop: A sequence which indicates the end of the current document.
        """
        self._java_obj = self._java_obj.setStopCol(value)
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
    
    def setTemperature(self, value):
        """
        Args:
            temperature: What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setTemperature(value)
        return self
    
    def setTemperatureCol(self, value):
        """
        Args:
            temperature: What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
        """
        self._java_obj = self._java_obj.setTemperatureCol(value)
        return self
    
    def setTimeout(self, value):
        """
        Args:
            timeout: number of seconds to wait before closing the connection
        """
        self._set(timeout=value)
        return self
    
    def setTopP(self, value):
        """
        Args:
            topP: An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setTopP(value)
        return self
    
    def setTopPCol(self, value):
        """
        Args:
            topP: An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
        """
        self._java_obj = self._java_obj.setTopPCol(value)
        return self
    
    def setUrl(self, value):
        """
        Args:
            url: Url of the service
        """
        self._set(url=value)
        return self
    
    def setUser(self, value):
        """
        Args:
            user: The ID of the end-user, for use in tracking and rate-limiting.
        """
        if isinstance(value, list):
            value = SparkContext._active_spark_context._jvm.com.microsoft.azure.synapse.ml.param.ServiceParam.toSeq(value)
        self._java_obj = self._java_obj.setUser(value)
        return self
    
    def setUserCol(self, value):
        """
        Args:
            user: The ID of the end-user, for use in tracking and rate-limiting.
        """
        self._java_obj = self._java_obj.setUserCol(value)
        return self

    
    def getApiVersion(self):
        """
        Returns:
            apiVersion: version of the api
        """
        return self._java_obj.getApiVersion()
    
    
    def getBatchIndexPrompt(self):
        """
        Returns:
            batchIndexPrompt: Sequence of index sequences to complete
        """
        return self._java_obj.getBatchIndexPrompt()
    
    
    def getBatchPrompt(self):
        """
        Returns:
            batchPrompt: Sequence of prompts to complete
        """
        return self._java_obj.getBatchPrompt()
    
    
    def getBestOf(self):
        """
        Returns:
            bestOf: How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
        """
        return self._java_obj.getBestOf()
    
    
    def getCacheLevel(self):
        """
        Returns:
            cacheLevel: can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
        """
        return self._java_obj.getCacheLevel()
    
    
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
    
    
    def getDeploymentName(self):
        """
        Returns:
            deploymentName: The name of the deployment
        """
        return self._java_obj.getDeploymentName()
    
    
    def getEcho(self):
        """
        Returns:
            echo: Echo back the prompt in addition to the completion
        """
        return self._java_obj.getEcho()
    
    
    def getErrorCol(self):
        """
        Returns:
            errorCol: column to hold http errors
        """
        return self.getOrDefault(self.errorCol)
    
    
    def getFrequencyPenalty(self):
        """
        Returns:
            frequencyPenalty: How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
        """
        return self._java_obj.getFrequencyPenalty()
    
    
    def getHandler(self):
        """
        Returns:
            handler: Which strategy to use when handling requests
        """
        return self.getOrDefault(self.handler)
    
    
    def getIndexPrompt(self):
        """
        Returns:
            indexPrompt: Sequence of indexes to complete
        """
        return self._java_obj.getIndexPrompt()
    
    
    def getLogProbs(self):
        """
        Returns:
            logProbs: Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        """
        return self._java_obj.getLogProbs()
    
    
    def getMaxTokens(self):
        """
        Returns:
            maxTokens: The maximum number of tokens to generate. Has minimum of 0.
        """
        return self._java_obj.getMaxTokens()
    
    
    def getModel(self):
        """
        Returns:
            model: The name of the model to use
        """
        return self._java_obj.getModel()
    
    
    def getN(self):
        """
        Returns:
            n: How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
        """
        return self._java_obj.getN()
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)
    
    
    def getPresencePenalty(self):
        """
        Returns:
            presencePenalty: How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
        """
        return self._java_obj.getPresencePenalty()
    
    
    def getPrompt(self):
        """
        Returns:
            prompt: The text to complete
        """
        return self._java_obj.getPrompt()
    
    
    def getStop(self):
        """
        Returns:
            stop: A sequence which indicates the end of the current document.
        """
        return self._java_obj.getStop()
    
    
    def getSubscriptionKey(self):
        """
        Returns:
            subscriptionKey: the API key to use
        """
        return self._java_obj.getSubscriptionKey()
    
    
    def getTemperature(self):
        """
        Returns:
            temperature: What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
        """
        return self._java_obj.getTemperature()
    
    
    def getTimeout(self):
        """
        Returns:
            timeout: number of seconds to wait before closing the connection
        """
        return self.getOrDefault(self.timeout)
    
    
    def getTopP(self):
        """
        Returns:
            topP: An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
        """
        return self._java_obj.getTopP()
    
    
    def getUrl(self):
        """
        Returns:
            url: Url of the service
        """
        return self.getOrDefault(self.url)
    
    
    def getUser(self):
        """
        Returns:
            user: The ID of the end-user, for use in tracking and rate-limiting.
        """
        return self._java_obj.getUser()

    

    
    def setServiceName(self, value):
        self._java_obj = self._java_obj.setServiceName(value)
        return self
        