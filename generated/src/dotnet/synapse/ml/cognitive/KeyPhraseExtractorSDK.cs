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
    /// <see cref="KeyPhraseExtractorSDK"/> implements KeyPhraseExtractorSDK
    /// </summary>
    public class KeyPhraseExtractorSDK : JavaTransformer, IJavaMLWritable, IJavaMLReadable<KeyPhraseExtractorSDK>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.KeyPhraseExtractorSDK";

        /// <summary>
        /// Creates a <see cref="KeyPhraseExtractorSDK"/> without any parameters.
        /// </summary>
        public KeyPhraseExtractorSDK() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="KeyPhraseExtractorSDK"/> with a UID that is used to give the
        /// <see cref="KeyPhraseExtractorSDK"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public KeyPhraseExtractorSDK(string uid) : base(s_className, uid)
        {
        }

        internal KeyPhraseExtractorSDK(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for batchSize
        /// </summary>
        /// <param name="value">
        /// The max size of the buffer
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetBatchSize(int value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setBatchSize", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetConcurrency(int value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetConcurrentTimeout(double value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for disableServiceLogs
        /// </summary>
        /// <param name="value">
        /// disableServiceLogs option
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetDisableServiceLogs(bool value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setDisableServiceLogs", (object)value));
        
        
        /// <summary>
        /// Sets value for disableServiceLogs column
        /// </summary>
        /// <param name="value">
        /// disableServiceLogs option
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetDisableServiceLogsCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setDisableServiceLogsCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetErrorCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for includeStatistics
        /// </summary>
        /// <param name="value">
        /// includeStatistics option
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetIncludeStatistics(bool value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setIncludeStatistics", (object)value));
        
        
        /// <summary>
        /// Sets value for includeStatistics column
        /// </summary>
        /// <param name="value">
        /// includeStatistics option
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetIncludeStatisticsCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setIncludeStatisticsCol", value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetLanguage(string[] value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetLanguageCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for modelVersion
        /// </summary>
        /// <param name="value">
        /// modelVersion option
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetModelVersion(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setModelVersion", (object)value));
        
        
        /// <summary>
        /// Sets value for modelVersion column
        /// </summary>
        /// <param name="value">
        /// modelVersion option
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetModelVersionCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setModelVersionCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetOutputCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetSubscriptionKey(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetSubscriptionKeyCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetText(string[] value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetTextCol(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetTimeout(double value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetUrl(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets batchSize value
        /// </summary>
        /// <returns>
        /// batchSize: The max size of the buffer
        /// </returns>
        public int GetBatchSize() =>
            (int)Reference.Invoke("getBatchSize");
        
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
        /// Gets disableServiceLogs value
        /// </summary>
        /// <returns>
        /// disableServiceLogs: disableServiceLogs option
        /// </returns>
        public bool GetDisableServiceLogs() =>
            (bool)Reference.Invoke("getDisableServiceLogs");
        
        
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets includeStatistics value
        /// </summary>
        /// <returns>
        /// includeStatistics: includeStatistics option
        /// </returns>
        public bool GetIncludeStatistics() =>
            (bool)Reference.Invoke("getIncludeStatistics");
        
        
        /// <summary>
        /// Gets language value
        /// </summary>
        /// <returns>
        /// language: the language code of the text (optional for some services)
        /// </returns>
        public string[] GetLanguage() =>
            (string[])Reference.Invoke("getLanguage");
        
        
        /// <summary>
        /// Gets modelVersion value
        /// </summary>
        /// <returns>
        /// modelVersion: modelVersion option
        /// </returns>
        public string GetModelVersion() =>
            (string)Reference.Invoke("getModelVersion");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets text value
        /// </summary>
        /// <returns>
        /// text: the text in the request body
        /// </returns>
        public string[] GetText() =>
            (string[])Reference.Invoke("getText");
        
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: number of seconds to wait before closing the connection
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="KeyPhraseExtractorSDK"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="KeyPhraseExtractorSDK"/> was saved to</param>
        /// <returns>New <see cref="KeyPhraseExtractorSDK"/> object, loaded from path.</returns>
        public static KeyPhraseExtractorSDK Load(string path) => WrapAsKeyPhraseExtractorSDK(
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
        /// <returns>an <see cref="JavaMLReader&lt;KeyPhraseExtractorSDK&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<KeyPhraseExtractorSDK> Read() =>
            new JavaMLReader<KeyPhraseExtractorSDK>((JvmObjectReference)Reference.Invoke("read"));
        private static KeyPhraseExtractorSDK WrapAsKeyPhraseExtractorSDK(object obj) =>
            new KeyPhraseExtractorSDK((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New KeyPhraseExtractorSDK object </returns>
        public KeyPhraseExtractorSDK SetLocation(string value) =>
            WrapAsKeyPhraseExtractorSDK(Reference.Invoke("setLocation", value));
    }
}

        