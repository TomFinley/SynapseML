// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.ML.Feature.Param;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.Interop.Internal.Java.Util;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Microsoft.Spark.Utils;
using SynapseML.Dotnet.Utils;
using Synapse.ML.LightGBM.Param;


namespace Synapse.ML.Cognitive
{
    /// <summary>
    /// <see cref="OpenAICompletion"/> implements OpenAICompletion
    /// </summary>
    public class OpenAICompletion : JavaTransformer, IJavaMLWritable, IJavaMLReadable<OpenAICompletion>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.OpenAICompletion";

        /// <summary>
        /// Creates a <see cref="OpenAICompletion"/> without any parameters.
        /// </summary>
        public OpenAICompletion() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="OpenAICompletion"/> with a UID that is used to give the
        /// <see cref="OpenAICompletion"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public OpenAICompletion(string uid) : base(s_className, uid)
        {
        }

        internal OpenAICompletion(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for apiVersion
        /// </summary>
        /// <param name="value">
        /// version of the api
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetApiVersion(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setApiVersion", (object)value));
        
        
        /// <summary>
        /// Sets value for apiVersion column
        /// </summary>
        /// <param name="value">
        /// version of the api
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetApiVersionCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setApiVersionCol", value));
        
        
        /// <summary>
        /// Sets value for batchIndexPrompt
        /// </summary>
        /// <param name="value">
        /// Sequence of index sequences to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetBatchIndexPrompt(int[][] value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setBatchIndexPrompt", (object)value));
        
        
        /// <summary>
        /// Sets value for batchIndexPrompt column
        /// </summary>
        /// <param name="value">
        /// Sequence of index sequences to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetBatchIndexPromptCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setBatchIndexPromptCol", value));
        
        
        /// <summary>
        /// Sets value for batchPrompt
        /// </summary>
        /// <param name="value">
        /// Sequence of prompts to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetBatchPrompt(string[] value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setBatchPrompt", (object)value));
        
        
        /// <summary>
        /// Sets value for batchPrompt column
        /// </summary>
        /// <param name="value">
        /// Sequence of prompts to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetBatchPromptCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setBatchPromptCol", value));
        
        
        /// <summary>
        /// Sets value for bestOf
        /// </summary>
        /// <param name="value">
        /// How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetBestOf(int value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setBestOf", (object)value));
        
        
        /// <summary>
        /// Sets value for bestOf column
        /// </summary>
        /// <param name="value">
        /// How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetBestOfCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setBestOfCol", value));
        
        
        /// <summary>
        /// Sets value for cacheLevel
        /// </summary>
        /// <param name="value">
        /// can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetCacheLevel(int value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setCacheLevel", (object)value));
        
        
        /// <summary>
        /// Sets value for cacheLevel column
        /// </summary>
        /// <param name="value">
        /// can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetCacheLevelCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setCacheLevelCol", value));
        
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetConcurrency(int value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetConcurrentTimeout(double value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for deploymentName
        /// </summary>
        /// <param name="value">
        /// The name of the deployment
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetDeploymentName(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setDeploymentName", (object)value));
        
        
        /// <summary>
        /// Sets value for deploymentName column
        /// </summary>
        /// <param name="value">
        /// The name of the deployment
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetDeploymentNameCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setDeploymentNameCol", value));
        
        
        /// <summary>
        /// Sets value for echo
        /// </summary>
        /// <param name="value">
        /// Echo back the prompt in addition to the completion
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetEcho(bool value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setEcho", (object)value));
        
        
        /// <summary>
        /// Sets value for echo column
        /// </summary>
        /// <param name="value">
        /// Echo back the prompt in addition to the completion
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetEchoCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setEchoCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetErrorCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for frequencyPenalty
        /// </summary>
        /// <param name="value">
        /// How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetFrequencyPenalty(double value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setFrequencyPenalty", (object)value));
        
        
        /// <summary>
        /// Sets value for frequencyPenalty column
        /// </summary>
        /// <param name="value">
        /// How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetFrequencyPenaltyCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setFrequencyPenaltyCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetHandler(object value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for indexPrompt
        /// </summary>
        /// <param name="value">
        /// Sequence of indexes to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetIndexPrompt(int[] value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setIndexPrompt", (object)value));
        
        
        /// <summary>
        /// Sets value for indexPrompt column
        /// </summary>
        /// <param name="value">
        /// Sequence of indexes to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetIndexPromptCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setIndexPromptCol", value));
        
        
        /// <summary>
        /// Sets value for logProbs
        /// </summary>
        /// <param name="value">
        /// Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetLogProbs(int value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setLogProbs", (object)value));
        
        
        /// <summary>
        /// Sets value for logProbs column
        /// </summary>
        /// <param name="value">
        /// Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetLogProbsCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setLogProbsCol", value));
        
        
        /// <summary>
        /// Sets value for maxTokens
        /// </summary>
        /// <param name="value">
        /// The maximum number of tokens to generate. Has minimum of 0.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetMaxTokens(int value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setMaxTokens", (object)value));
        
        
        /// <summary>
        /// Sets value for maxTokens column
        /// </summary>
        /// <param name="value">
        /// The maximum number of tokens to generate. Has minimum of 0.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetMaxTokensCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setMaxTokensCol", value));
        
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// The name of the model to use
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetModel(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for model column
        /// </summary>
        /// <param name="value">
        /// The name of the model to use
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetModelCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setModelCol", value));
        
        
        /// <summary>
        /// Sets value for n
        /// </summary>
        /// <param name="value">
        /// How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetN(int value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setN", (object)value));
        
        
        /// <summary>
        /// Sets value for n column
        /// </summary>
        /// <param name="value">
        /// How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetNCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setNCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetOutputCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for presencePenalty
        /// </summary>
        /// <param name="value">
        /// How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetPresencePenalty(double value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setPresencePenalty", (object)value));
        
        
        /// <summary>
        /// Sets value for presencePenalty column
        /// </summary>
        /// <param name="value">
        /// How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetPresencePenaltyCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setPresencePenaltyCol", value));
        
        
        /// <summary>
        /// Sets value for prompt
        /// </summary>
        /// <param name="value">
        /// The text to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetPrompt(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setPrompt", (object)value));
        
        
        /// <summary>
        /// Sets value for prompt column
        /// </summary>
        /// <param name="value">
        /// The text to complete
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetPromptCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setPromptCol", value));
        
        
        /// <summary>
        /// Sets value for stop
        /// </summary>
        /// <param name="value">
        /// A sequence which indicates the end of the current document.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetStop(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setStop", (object)value));
        
        
        /// <summary>
        /// Sets value for stop column
        /// </summary>
        /// <param name="value">
        /// A sequence which indicates the end of the current document.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetStopCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setStopCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetSubscriptionKey(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetSubscriptionKeyCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for temperature
        /// </summary>
        /// <param name="value">
        /// What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetTemperature(double value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setTemperature", (object)value));
        
        
        /// <summary>
        /// Sets value for temperature column
        /// </summary>
        /// <param name="value">
        /// What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetTemperatureCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setTemperatureCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetTimeout(double value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for topP
        /// </summary>
        /// <param name="value">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetTopP(double value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setTopP", (object)value));
        
        
        /// <summary>
        /// Sets value for topP column
        /// </summary>
        /// <param name="value">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetTopPCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setTopPCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetUrl(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setUrl", (object)value));
        
        /// <summary>
        /// Sets value for user
        /// </summary>
        /// <param name="value">
        /// The ID of the end-user, for use in tracking and rate-limiting.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetUser(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setUser", (object)value));
        
        
        /// <summary>
        /// Sets value for user column
        /// </summary>
        /// <param name="value">
        /// The ID of the end-user, for use in tracking and rate-limiting.
        /// </param>
        /// <returns> New OpenAICompletion object </returns>
        public OpenAICompletion SetUserCol(string value) =>
            WrapAsOpenAICompletion(Reference.Invoke("setUserCol", value));
        /// <summary>
        /// Gets apiVersion value
        /// </summary>
        /// <returns>
        /// apiVersion: version of the api
        /// </returns>
        public string GetApiVersion() =>
            (string)Reference.Invoke("getApiVersion");
        
        
        /// <summary>
        /// Gets batchIndexPrompt value
        /// </summary>
        /// <returns>
        /// batchIndexPrompt: Sequence of index sequences to complete
        /// </returns>
        public int[][] GetBatchIndexPrompt() =>
            (int[][])Reference.Invoke("getBatchIndexPrompt");
        
        
        /// <summary>
        /// Gets batchPrompt value
        /// </summary>
        /// <returns>
        /// batchPrompt: Sequence of prompts to complete
        /// </returns>
        public string[] GetBatchPrompt() =>
            (string[])Reference.Invoke("getBatchPrompt");
        
        
        /// <summary>
        /// Gets bestOf value
        /// </summary>
        /// <returns>
        /// bestOf: How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
        /// </returns>
        public int GetBestOf() =>
            (int)Reference.Invoke("getBestOf");
        
        
        /// <summary>
        /// Gets cacheLevel value
        /// </summary>
        /// <returns>
        /// cacheLevel: can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
        /// </returns>
        public int GetCacheLevel() =>
            (int)Reference.Invoke("getCacheLevel");
        
        
        /// <summary>
        /// Gets concurrency value
        /// </summary>
        /// <returns>
        /// concurrency: max number of concurrent calls
        /// </returns>
        public int GetConcurrency() =>
            (int)Reference.Invoke("getConcurrency");
        
        /// <summary>
        /// Gets concurrentTimeout value
        /// </summary>
        /// <returns>
        /// concurrentTimeout: max number seconds to wait on futures if concurrency >= 1
        /// </returns>
        public double GetConcurrentTimeout() =>
            (double)Reference.Invoke("getConcurrentTimeout");
        
        /// <summary>
        /// Gets deploymentName value
        /// </summary>
        /// <returns>
        /// deploymentName: The name of the deployment
        /// </returns>
        public string GetDeploymentName() =>
            (string)Reference.Invoke("getDeploymentName");
        
        
        /// <summary>
        /// Gets echo value
        /// </summary>
        /// <returns>
        /// echo: Echo back the prompt in addition to the completion
        /// </returns>
        public bool GetEcho() =>
            (bool)Reference.Invoke("getEcho");
        
        
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets frequencyPenalty value
        /// </summary>
        /// <returns>
        /// frequencyPenalty: How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
        /// </returns>
        public double GetFrequencyPenalty() =>
            (double)Reference.Invoke("getFrequencyPenalty");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets indexPrompt value
        /// </summary>
        /// <returns>
        /// indexPrompt: Sequence of indexes to complete
        /// </returns>
        public int[] GetIndexPrompt() =>
            (int[])Reference.Invoke("getIndexPrompt");
        
        
        /// <summary>
        /// Gets logProbs value
        /// </summary>
        /// <returns>
        /// logProbs: Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
        /// </returns>
        public int GetLogProbs() =>
            (int)Reference.Invoke("getLogProbs");
        
        
        /// <summary>
        /// Gets maxTokens value
        /// </summary>
        /// <returns>
        /// maxTokens: The maximum number of tokens to generate. Has minimum of 0.
        /// </returns>
        public int GetMaxTokens() =>
            (int)Reference.Invoke("getMaxTokens");
        
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: The name of the model to use
        /// </returns>
        public string GetModel() =>
            (string)Reference.Invoke("getModel");
        
        
        /// <summary>
        /// Gets n value
        /// </summary>
        /// <returns>
        /// n: How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
        /// </returns>
        public int GetN() =>
            (int)Reference.Invoke("getN");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets presencePenalty value
        /// </summary>
        /// <returns>
        /// presencePenalty: How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
        /// </returns>
        public double GetPresencePenalty() =>
            (double)Reference.Invoke("getPresencePenalty");
        
        
        /// <summary>
        /// Gets prompt value
        /// </summary>
        /// <returns>
        /// prompt: The text to complete
        /// </returns>
        public string GetPrompt() =>
            (string)Reference.Invoke("getPrompt");
        
        
        /// <summary>
        /// Gets stop value
        /// </summary>
        /// <returns>
        /// stop: A sequence which indicates the end of the current document.
        /// </returns>
        public string GetStop() =>
            (string)Reference.Invoke("getStop");
        
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets temperature value
        /// </summary>
        /// <returns>
        /// temperature: What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
        /// </returns>
        public double GetTemperature() =>
            (double)Reference.Invoke("getTemperature");
        
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: number of seconds to wait before closing the connection
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Gets topP value
        /// </summary>
        /// <returns>
        /// topP: An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
        /// </returns>
        public double GetTopP() =>
            (double)Reference.Invoke("getTopP");
        
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Gets user value
        /// </summary>
        /// <returns>
        /// user: The ID of the end-user, for use in tracking and rate-limiting.
        /// </returns>
        public string GetUser() =>
            (string)Reference.Invoke("getUser");
        
        /// <summary>
        /// Loads the <see cref="OpenAICompletion"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="OpenAICompletion"/> was saved to</param>
        /// <returns>New <see cref="OpenAICompletion"/> object, loaded from path.</returns>
        public static OpenAICompletion Load(string path) => WrapAsOpenAICompletion(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_className, "load", path));
        
        /// <summary>
        /// Saves the object so that it can be loaded later using Load. Note that these objects
        /// can be shared with Scala by Loading or Saving in Scala.
        /// </summary>
        /// <param name="path">The path to save the object to</param>
        public void Save(string path) => Reference.Invoke("save", path);
        
        /// <returns>a <see cref="JavaMLWriter"/> instance for this ML instance.</returns>
        public JavaMLWriter Write() =>
            new JavaMLWriter((JvmObjectReference)Reference.Invoke("write"));
        
        /// <summary>
        /// Get the corresponding JavaMLReader instance.
        /// </summary>
        /// <returns>an <see cref="JavaMLReader&lt;OpenAICompletion&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<OpenAICompletion> Read() =>
            new JavaMLReader<OpenAICompletion>((JvmObjectReference)Reference.Invoke("read"));
        private static OpenAICompletion WrapAsOpenAICompletion(object obj) =>
            new OpenAICompletion((JvmObjectReference)obj);
        
    }
}

        