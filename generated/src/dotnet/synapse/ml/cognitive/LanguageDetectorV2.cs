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
    /// <see cref="LanguageDetectorV2"/> implements LanguageDetectorV2
    /// </summary>
    public class LanguageDetectorV2 : JavaTransformer, IJavaMLWritable, IJavaMLReadable<LanguageDetectorV2>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.LanguageDetectorV2";

        /// <summary>
        /// Creates a <see cref="LanguageDetectorV2"/> without any parameters.
        /// </summary>
        public LanguageDetectorV2() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="LanguageDetectorV2"/> with a UID that is used to give the
        /// <see cref="LanguageDetectorV2"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public LanguageDetectorV2(string uid) : base(s_className, uid)
        {
        }

        internal LanguageDetectorV2(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetConcurrency(int value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetConcurrentTimeout(double value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetErrorCol(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetHandler(object value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetLanguage(string[] value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetLanguageCol(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetOutputCol(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetSubscriptionKey(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetSubscriptionKeyCol(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetText(string[] value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetTextCol(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetTimeout(double value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetUrl(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setUrl", (object)value));
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
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets language value
        /// </summary>
        /// <returns>
        /// language: the language code of the text (optional for some services)
        /// </returns>
        public string[] GetLanguage() =>
            (string[])Reference.Invoke("getLanguage");
        
        
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
        /// Loads the <see cref="LanguageDetectorV2"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="LanguageDetectorV2"/> was saved to</param>
        /// <returns>New <see cref="LanguageDetectorV2"/> object, loaded from path.</returns>
        public static LanguageDetectorV2 Load(string path) => WrapAsLanguageDetectorV2(
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
        /// <returns>an <see cref="JavaMLReader&lt;LanguageDetectorV2&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<LanguageDetectorV2> Read() =>
            new JavaMLReader<LanguageDetectorV2>((JvmObjectReference)Reference.Invoke("read"));
        private static LanguageDetectorV2 WrapAsLanguageDetectorV2(object obj) =>
            new LanguageDetectorV2((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetLocation(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New LanguageDetectorV2 object </returns>
        public LanguageDetectorV2 SetLinkedService(string value) =>
            WrapAsLanguageDetectorV2(Reference.Invoke("setLinkedService", value));
    }
}

        