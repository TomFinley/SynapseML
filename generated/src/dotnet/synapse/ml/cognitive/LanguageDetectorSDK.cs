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
    /// <see cref="LanguageDetectorSDK"/> implements LanguageDetectorSDK
    /// </summary>
    public class LanguageDetectorSDK : JavaTransformer, IJavaMLWritable, IJavaMLReadable<LanguageDetectorSDK>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.LanguageDetectorSDK";

        /// <summary>
        /// Creates a <see cref="LanguageDetectorSDK"/> without any parameters.
        /// </summary>
        public LanguageDetectorSDK() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="LanguageDetectorSDK"/> with a UID that is used to give the
        /// <see cref="LanguageDetectorSDK"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public LanguageDetectorSDK(string uid) : base(s_className, uid)
        {
        }

        internal LanguageDetectorSDK(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for batchSize
        /// </summary>
        /// <param name="value">
        /// The max size of the buffer
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetBatchSize(int value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setBatchSize", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetConcurrency(int value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetConcurrentTimeout(double value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for disableServiceLogs
        /// </summary>
        /// <param name="value">
        /// disableServiceLogs option
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetDisableServiceLogs(bool value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setDisableServiceLogs", (object)value));
        
        
        /// <summary>
        /// Sets value for disableServiceLogs column
        /// </summary>
        /// <param name="value">
        /// disableServiceLogs option
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetDisableServiceLogsCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setDisableServiceLogsCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetErrorCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for includeStatistics
        /// </summary>
        /// <param name="value">
        /// includeStatistics option
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetIncludeStatistics(bool value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setIncludeStatistics", (object)value));
        
        
        /// <summary>
        /// Sets value for includeStatistics column
        /// </summary>
        /// <param name="value">
        /// includeStatistics option
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetIncludeStatisticsCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setIncludeStatisticsCol", value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetLanguage(string[] value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetLanguageCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for modelVersion
        /// </summary>
        /// <param name="value">
        /// modelVersion option
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetModelVersion(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setModelVersion", (object)value));
        
        
        /// <summary>
        /// Sets value for modelVersion column
        /// </summary>
        /// <param name="value">
        /// modelVersion option
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetModelVersionCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setModelVersionCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetOutputCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetSubscriptionKey(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetSubscriptionKeyCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetText(string[] value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetTextCol(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetTimeout(double value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetUrl(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setUrl", (object)value));
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
        /// Loads the <see cref="LanguageDetectorSDK"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="LanguageDetectorSDK"/> was saved to</param>
        /// <returns>New <see cref="LanguageDetectorSDK"/> object, loaded from path.</returns>
        public static LanguageDetectorSDK Load(string path) => WrapAsLanguageDetectorSDK(
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
        /// <returns>an <see cref="JavaMLReader&lt;LanguageDetectorSDK&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<LanguageDetectorSDK> Read() =>
            new JavaMLReader<LanguageDetectorSDK>((JvmObjectReference)Reference.Invoke("read"));
        private static LanguageDetectorSDK WrapAsLanguageDetectorSDK(object obj) =>
            new LanguageDetectorSDK((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New LanguageDetectorSDK object </returns>
        public LanguageDetectorSDK SetLocation(string value) =>
            WrapAsLanguageDetectorSDK(Reference.Invoke("setLocation", value));
    }
}

        