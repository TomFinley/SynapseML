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
    /// <see cref="Transliterate"/> implements Transliterate
    /// </summary>
    public class Transliterate : JavaTransformer, IJavaMLWritable, IJavaMLReadable<Transliterate>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.Transliterate";

        /// <summary>
        /// Creates a <see cref="Transliterate"/> without any parameters.
        /// </summary>
        public Transliterate() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Transliterate"/> with a UID that is used to give the
        /// <see cref="Transliterate"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Transliterate(string uid) : base(s_className, uid)
        {
        }

        internal Transliterate(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetConcurrency(int value) =>
            WrapAsTransliterate(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetConcurrentTimeout(double value) =>
            WrapAsTransliterate(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetErrorCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for fromScript
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the input text.
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetFromScript(string value) =>
            WrapAsTransliterate(Reference.Invoke("setFromScript", (object)value));
        
        
        /// <summary>
        /// Sets value for fromScript column
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the input text.
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetFromScriptCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setFromScriptCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetHandler(object value) =>
            WrapAsTransliterate(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// Language tag identifying the language of the input text. If a code is not specified, automatic language detection will be applied.
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetLanguage(string value) =>
            WrapAsTransliterate(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// Language tag identifying the language of the input text. If a code is not specified, automatic language detection will be applied.
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetLanguageCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetOutputCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetSubscriptionKey(string value) =>
            WrapAsTransliterate(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetSubscriptionKeyCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetSubscriptionRegion(string value) =>
            WrapAsTransliterate(Reference.Invoke("setSubscriptionRegion", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion column
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetSubscriptionRegionCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setSubscriptionRegionCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetText(string[] value) =>
            WrapAsTransliterate(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetTextCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetTimeout(double value) =>
            WrapAsTransliterate(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for toScript
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the translated text.
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetToScript(string value) =>
            WrapAsTransliterate(Reference.Invoke("setToScript", (object)value));
        
        
        /// <summary>
        /// Sets value for toScript column
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the translated text.
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetToScriptCol(string value) =>
            WrapAsTransliterate(Reference.Invoke("setToScriptCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetUrl(string value) =>
            WrapAsTransliterate(Reference.Invoke("setUrl", (object)value));
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
        /// Gets fromScript value
        /// </summary>
        /// <returns>
        /// fromScript: Specifies the script of the input text.
        /// </returns>
        public string GetFromScript() =>
            (string)Reference.Invoke("getFromScript");
        
        
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
        /// language: Language tag identifying the language of the input text. If a code is not specified, automatic language detection will be applied.
        /// </returns>
        public string GetLanguage() =>
            (string)Reference.Invoke("getLanguage");
        
        
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
        /// Gets toScript value
        /// </summary>
        /// <returns>
        /// toScript: Specifies the script of the translated text.
        /// </returns>
        public string GetToScript() =>
            (string)Reference.Invoke("getToScript");
        
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="Transliterate"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Transliterate"/> was saved to</param>
        /// <returns>New <see cref="Transliterate"/> object, loaded from path.</returns>
        public static Transliterate Load(string path) => WrapAsTransliterate(
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
        /// <returns>an <see cref="JavaMLReader&lt;Transliterate&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Transliterate> Read() =>
            new JavaMLReader<Transliterate>((JvmObjectReference)Reference.Invoke("read"));
        private static Transliterate WrapAsTransliterate(object obj) =>
            new Transliterate((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetLocation(string value) =>
            WrapAsTransliterate(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New Transliterate object </returns>
        public Transliterate SetLinkedService(string value) =>
            WrapAsTransliterate(Reference.Invoke("setLinkedService", value));
    }
}

        