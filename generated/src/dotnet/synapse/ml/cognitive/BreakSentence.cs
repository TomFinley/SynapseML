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
    /// <see cref="BreakSentence"/> implements BreakSentence
    /// </summary>
    public class BreakSentence : JavaTransformer, IJavaMLWritable, IJavaMLReadable<BreakSentence>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.BreakSentence";

        /// <summary>
        /// Creates a <see cref="BreakSentence"/> without any parameters.
        /// </summary>
        public BreakSentence() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="BreakSentence"/> with a UID that is used to give the
        /// <see cref="BreakSentence"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public BreakSentence(string uid) : base(s_className, uid)
        {
        }

        internal BreakSentence(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetConcurrency(int value) =>
            WrapAsBreakSentence(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetConcurrentTimeout(double value) =>
            WrapAsBreakSentence(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetErrorCol(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetHandler(object value) =>
            WrapAsBreakSentence(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// Language tag identifying the language of the input text. If a code is not specified, automatic language detection will be applied.
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetLanguage(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// Language tag identifying the language of the input text. If a code is not specified, automatic language detection will be applied.
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetLanguageCol(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetOutputCol(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for script
        /// </summary>
        /// <param name="value">
        /// Script tag identifying the script used by the input text. If a script is not specified, the default script of the language will be assumed.
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetScript(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setScript", (object)value));
        
        
        /// <summary>
        /// Sets value for script column
        /// </summary>
        /// <param name="value">
        /// Script tag identifying the script used by the input text. If a script is not specified, the default script of the language will be assumed.
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetScriptCol(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setScriptCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetSubscriptionKey(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetSubscriptionKeyCol(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetSubscriptionRegion(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setSubscriptionRegion", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion column
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetSubscriptionRegionCol(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setSubscriptionRegionCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetText(string[] value) =>
            WrapAsBreakSentence(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetTextCol(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetTimeout(double value) =>
            WrapAsBreakSentence(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetUrl(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setUrl", (object)value));
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
        /// Gets script value
        /// </summary>
        /// <returns>
        /// script: Script tag identifying the script used by the input text. If a script is not specified, the default script of the language will be assumed.
        /// </returns>
        public string GetScript() =>
            (string)Reference.Invoke("getScript");
        
        
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
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="BreakSentence"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="BreakSentence"/> was saved to</param>
        /// <returns>New <see cref="BreakSentence"/> object, loaded from path.</returns>
        public static BreakSentence Load(string path) => WrapAsBreakSentence(
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
        /// <returns>an <see cref="JavaMLReader&lt;BreakSentence&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<BreakSentence> Read() =>
            new JavaMLReader<BreakSentence>((JvmObjectReference)Reference.Invoke("read"));
        private static BreakSentence WrapAsBreakSentence(object obj) =>
            new BreakSentence((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetLocation(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New BreakSentence object </returns>
        public BreakSentence SetLinkedService(string value) =>
            WrapAsBreakSentence(Reference.Invoke("setLinkedService", value));
    }
}

        