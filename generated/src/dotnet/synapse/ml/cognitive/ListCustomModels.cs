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
    /// <see cref="ListCustomModels"/> implements ListCustomModels
    /// </summary>
    public class ListCustomModels : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ListCustomModels>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.ListCustomModels";

        /// <summary>
        /// Creates a <see cref="ListCustomModels"/> without any parameters.
        /// </summary>
        public ListCustomModels() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ListCustomModels"/> with a UID that is used to give the
        /// <see cref="ListCustomModels"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ListCustomModels(string uid) : base(s_className, uid)
        {
        }

        internal ListCustomModels(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetConcurrency(int value) =>
            WrapAsListCustomModels(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetConcurrentTimeout(double value) =>
            WrapAsListCustomModels(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetErrorCol(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetHandler(object value) =>
            WrapAsListCustomModels(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for op
        /// </summary>
        /// <param name="value">
        /// Specify whether to return summary or full list of models.
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetOp(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setOp", (object)value));
        
        
        /// <summary>
        /// Sets value for op column
        /// </summary>
        /// <param name="value">
        /// Specify whether to return summary or full list of models.
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetOpCol(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setOpCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetOutputCol(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetSubscriptionKey(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetSubscriptionKeyCol(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetTimeout(double value) =>
            WrapAsListCustomModels(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetUrl(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setUrl", (object)value));
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
        /// Gets op value
        /// </summary>
        /// <returns>
        /// op: Specify whether to return summary or full list of models.
        /// </returns>
        public string GetOp() =>
            (string)Reference.Invoke("getOp");
        
        
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
        /// Loads the <see cref="ListCustomModels"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ListCustomModels"/> was saved to</param>
        /// <returns>New <see cref="ListCustomModels"/> object, loaded from path.</returns>
        public static ListCustomModels Load(string path) => WrapAsListCustomModels(
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
        /// <returns>an <see cref="JavaMLReader&lt;ListCustomModels&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ListCustomModels> Read() =>
            new JavaMLReader<ListCustomModels>((JvmObjectReference)Reference.Invoke("read"));
        private static ListCustomModels WrapAsListCustomModels(object obj) =>
            new ListCustomModels((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetLocation(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New ListCustomModels object </returns>
        public ListCustomModels SetLinkedService(string value) =>
            WrapAsListCustomModels(Reference.Invoke("setLinkedService", value));
    }
}

        