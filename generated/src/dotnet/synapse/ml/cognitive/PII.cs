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
    /// <see cref="PII"/> implements PII
    /// </summary>
    public class PII : JavaTransformer, IJavaMLWritable, IJavaMLReadable<PII>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.PII";

        /// <summary>
        /// Creates a <see cref="PII"/> without any parameters.
        /// </summary>
        public PII() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="PII"/> with a UID that is used to give the
        /// <see cref="PII"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public PII(string uid) : base(s_className, uid)
        {
        }

        internal PII(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetConcurrency(int value) =>
            WrapAsPII(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetConcurrentTimeout(double value) =>
            WrapAsPII(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for domain
        /// </summary>
        /// <param name="value">
        /// if specified, will set the PII domain to include only a subset of the entity categories. Possible values include: 'PHI', 'none'.
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetDomain(string value) =>
            WrapAsPII(Reference.Invoke("setDomain", (object)value));
        
        
        /// <summary>
        /// Sets value for domain column
        /// </summary>
        /// <param name="value">
        /// if specified, will set the PII domain to include only a subset of the entity categories. Possible values include: 'PHI', 'none'.
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetDomainCol(string value) =>
            WrapAsPII(Reference.Invoke("setDomainCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetErrorCol(string value) =>
            WrapAsPII(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetHandler(object value) =>
            WrapAsPII(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetLanguage(string[] value) =>
            WrapAsPII(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// the language code of the text (optional for some services)
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetLanguageCol(string value) =>
            WrapAsPII(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for modelVersion
        /// </summary>
        /// <param name="value">
        /// This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetModelVersion(string value) =>
            WrapAsPII(Reference.Invoke("setModelVersion", (object)value));
        
        
        /// <summary>
        /// Sets value for modelVersion column
        /// </summary>
        /// <param name="value">
        /// This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetModelVersionCol(string value) =>
            WrapAsPII(Reference.Invoke("setModelVersionCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetOutputCol(string value) =>
            WrapAsPII(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for piiCategories
        /// </summary>
        /// <param name="value">
        /// describes the PII categories to return
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetPiiCategories(string[] value) =>
            WrapAsPII(Reference.Invoke("setPiiCategories", (object)value));
        
        
        /// <summary>
        /// Sets value for piiCategories column
        /// </summary>
        /// <param name="value">
        /// describes the PII categories to return
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetPiiCategoriesCol(string value) =>
            WrapAsPII(Reference.Invoke("setPiiCategoriesCol", value));
        
        
        /// <summary>
        /// Sets value for showStats
        /// </summary>
        /// <param name="value">
        /// if set to true, response will contain input and document level statistics.
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetShowStats(bool value) =>
            WrapAsPII(Reference.Invoke("setShowStats", (object)value));
        
        
        /// <summary>
        /// Sets value for showStats column
        /// </summary>
        /// <param name="value">
        /// if set to true, response will contain input and document level statistics.
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetShowStatsCol(string value) =>
            WrapAsPII(Reference.Invoke("setShowStatsCol", value));
        
        
        /// <summary>
        /// Sets value for stringIndexType
        /// </summary>
        /// <param name="value">
        /// Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes) according to Unicode v8.0.0. For additional information see https://aka.ms/text-analytics-offsets
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetStringIndexType(string value) =>
            WrapAsPII(Reference.Invoke("setStringIndexType", (object)value));
        
        
        /// <summary>
        /// Sets value for stringIndexType column
        /// </summary>
        /// <param name="value">
        /// Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes) according to Unicode v8.0.0. For additional information see https://aka.ms/text-analytics-offsets
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetStringIndexTypeCol(string value) =>
            WrapAsPII(Reference.Invoke("setStringIndexTypeCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetSubscriptionKey(string value) =>
            WrapAsPII(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetSubscriptionKeyCol(string value) =>
            WrapAsPII(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetText(string[] value) =>
            WrapAsPII(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the text in the request body
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetTextCol(string value) =>
            WrapAsPII(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetTimeout(double value) =>
            WrapAsPII(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetUrl(string value) =>
            WrapAsPII(Reference.Invoke("setUrl", (object)value));
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
        /// Gets domain value
        /// </summary>
        /// <returns>
        /// domain: if specified, will set the PII domain to include only a subset of the entity categories. Possible values include: 'PHI', 'none'.
        /// </returns>
        public string GetDomain() =>
            (string)Reference.Invoke("getDomain");
        
        
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
        /// Gets modelVersion value
        /// </summary>
        /// <returns>
        /// modelVersion: This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
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
        /// Gets piiCategories value
        /// </summary>
        /// <returns>
        /// piiCategories: describes the PII categories to return
        /// </returns>
        public string[] GetPiiCategories() =>
            (string[])Reference.Invoke("getPiiCategories");
        
        
        /// <summary>
        /// Gets showStats value
        /// </summary>
        /// <returns>
        /// showStats: if set to true, response will contain input and document level statistics.
        /// </returns>
        public bool GetShowStats() =>
            (bool)Reference.Invoke("getShowStats");
        
        
        /// <summary>
        /// Gets stringIndexType value
        /// </summary>
        /// <returns>
        /// stringIndexType: Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes) according to Unicode v8.0.0. For additional information see https://aka.ms/text-analytics-offsets
        /// </returns>
        public string GetStringIndexType() =>
            (string)Reference.Invoke("getStringIndexType");
        
        
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
        /// Loads the <see cref="PII"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="PII"/> was saved to</param>
        /// <returns>New <see cref="PII"/> object, loaded from path.</returns>
        public static PII Load(string path) => WrapAsPII(
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
        /// <returns>an <see cref="JavaMLReader&lt;PII&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<PII> Read() =>
            new JavaMLReader<PII>((JvmObjectReference)Reference.Invoke("read"));
        private static PII WrapAsPII(object obj) =>
            new PII((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetLocation(string value) =>
            WrapAsPII(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New PII object </returns>
        public PII SetLinkedService(string value) =>
            WrapAsPII(Reference.Invoke("setLinkedService", value));
    }
}

        