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
    /// <see cref="DictionaryLookup"/> implements DictionaryLookup
    /// </summary>
    public class DictionaryLookup : JavaTransformer, IJavaMLWritable, IJavaMLReadable<DictionaryLookup>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.DictionaryLookup";

        /// <summary>
        /// Creates a <see cref="DictionaryLookup"/> without any parameters.
        /// </summary>
        public DictionaryLookup() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="DictionaryLookup"/> with a UID that is used to give the
        /// <see cref="DictionaryLookup"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public DictionaryLookup(string uid) : base(s_className, uid)
        {
        }

        internal DictionaryLookup(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetConcurrency(int value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetConcurrentTimeout(double value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetErrorCol(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for fromLanguage
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetFromLanguage(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setFromLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for fromLanguage column
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetFromLanguageCol(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setFromLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetHandler(object value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetOutputCol(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetSubscriptionKey(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetSubscriptionKeyCol(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetSubscriptionRegion(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setSubscriptionRegion", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion column
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetSubscriptionRegionCol(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setSubscriptionRegionCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetText(string[] value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetTextCol(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetTimeout(double value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for toLanguage
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetToLanguage(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setToLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for toLanguage column
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetToLanguageCol(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setToLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetUrl(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setUrl", (object)value));
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
        /// Gets fromLanguage value
        /// </summary>
        /// <returns>
        /// fromLanguage: Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        /// </returns>
        public string GetFromLanguage() =>
            (string)Reference.Invoke("getFromLanguage");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
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
        /// Gets subscriptionRegion value
        /// </summary>
        /// <returns>
        /// subscriptionRegion: the API region to use
        /// </returns>
        public string GetSubscriptionRegion() =>
            (string)Reference.Invoke("getSubscriptionRegion");
        
        
        /// <summary>
        /// Gets text value
        /// </summary>
        /// <returns>
        /// text: the string to translate
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
        /// Gets toLanguage value
        /// </summary>
        /// <returns>
        /// toLanguage: Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        /// </returns>
        public string GetToLanguage() =>
            (string)Reference.Invoke("getToLanguage");
        
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="DictionaryLookup"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="DictionaryLookup"/> was saved to</param>
        /// <returns>New <see cref="DictionaryLookup"/> object, loaded from path.</returns>
        public static DictionaryLookup Load(string path) => WrapAsDictionaryLookup(
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
        /// <returns>an <see cref="JavaMLReader&lt;DictionaryLookup&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<DictionaryLookup> Read() =>
            new JavaMLReader<DictionaryLookup>((JvmObjectReference)Reference.Invoke("read"));
        private static DictionaryLookup WrapAsDictionaryLookup(object obj) =>
            new DictionaryLookup((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetLocation(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New DictionaryLookup object </returns>
        public DictionaryLookup SetLinkedService(string value) =>
            WrapAsDictionaryLookup(Reference.Invoke("setLinkedService", value));
    }
}

        