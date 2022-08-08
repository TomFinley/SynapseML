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
    /// <see cref="DictionaryExamples"/> implements DictionaryExamples
    /// </summary>
    public class DictionaryExamples : JavaTransformer, IJavaMLWritable, IJavaMLReadable<DictionaryExamples>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.DictionaryExamples";

        /// <summary>
        /// Creates a <see cref="DictionaryExamples"/> without any parameters.
        /// </summary>
        public DictionaryExamples() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="DictionaryExamples"/> with a UID that is used to give the
        /// <see cref="DictionaryExamples"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public DictionaryExamples(string uid) : base(s_className, uid)
        {
        }

        internal DictionaryExamples(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetConcurrency(int value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetConcurrentTimeout(double value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetErrorCol(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for fromLanguage
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetFromLanguage(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setFromLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for fromLanguage column
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetFromLanguageCol(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setFromLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetHandler(object value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetOutputCol(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetSubscriptionKey(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetSubscriptionKeyCol(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetSubscriptionRegion(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setSubscriptionRegion", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion column
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetSubscriptionRegionCol(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setSubscriptionRegionCol", value));
        
        
        /// <summary>
        /// Sets value for textAndTranslation
        /// </summary>
        /// <param name="value">
        ///  A string specifying the translated text previously returned by the Dictionary lookup operation.
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetTextAndTranslation(TextAndTranslation[] value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setTextAndTranslation", (object)value));
        
        
        /// <summary>
        /// Sets value for textAndTranslation column
        /// </summary>
        /// <param name="value">
        ///  A string specifying the translated text previously returned by the Dictionary lookup operation.
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetTextAndTranslationCol(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setTextAndTranslationCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetTimeout(double value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for toLanguage
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetToLanguage(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setToLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for toLanguage column
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetToLanguageCol(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setToLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetUrl(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setUrl", (object)value));
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
        /// Gets textAndTranslation value
        /// </summary>
        /// <returns>
        /// textAndTranslation:  A string specifying the translated text previously returned by the Dictionary lookup operation.
        /// </returns>
        public TextAndTranslation[] GetTextAndTranslation()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getTextAndTranslation");
            var jvmObjects = (JvmObjectReference[])jvmObject.Invoke("array");
            TextAndTranslation[] result =
                new TextAndTranslation[jvmObjects.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new TextAndTranslation(jvmObjects[i]);
            }
            return result;
        }
        
        
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
        /// Loads the <see cref="DictionaryExamples"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="DictionaryExamples"/> was saved to</param>
        /// <returns>New <see cref="DictionaryExamples"/> object, loaded from path.</returns>
        public static DictionaryExamples Load(string path) => WrapAsDictionaryExamples(
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
        /// <returns>an <see cref="JavaMLReader&lt;DictionaryExamples&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<DictionaryExamples> Read() =>
            new JavaMLReader<DictionaryExamples>((JvmObjectReference)Reference.Invoke("read"));
        private static DictionaryExamples WrapAsDictionaryExamples(object obj) =>
            new DictionaryExamples((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetLocation(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New DictionaryExamples object </returns>
        public DictionaryExamples SetLinkedService(string value) =>
            WrapAsDictionaryExamples(Reference.Invoke("setLinkedService", value));
    }
}

        