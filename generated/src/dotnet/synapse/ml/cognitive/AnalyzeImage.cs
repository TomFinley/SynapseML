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
    /// <see cref="AnalyzeImage"/> implements AnalyzeImage
    /// </summary>
    public class AnalyzeImage : JavaTransformer, IJavaMLWritable, IJavaMLReadable<AnalyzeImage>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.AnalyzeImage";

        /// <summary>
        /// Creates a <see cref="AnalyzeImage"/> without any parameters.
        /// </summary>
        public AnalyzeImage() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="AnalyzeImage"/> with a UID that is used to give the
        /// <see cref="AnalyzeImage"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public AnalyzeImage(string uid) : base(s_className, uid)
        {
        }

        internal AnalyzeImage(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetConcurrency(int value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetConcurrentTimeout(double value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for details
        /// </summary>
        /// <param name="value">
        /// what visual feature types to return
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetDetails(string[] value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setDetails", (object)value));
        
        
        /// <summary>
        /// Sets value for details column
        /// </summary>
        /// <param name="value">
        /// what visual feature types to return
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetDetailsCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setDetailsCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetErrorCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetHandler(object value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetImageBytes(byte[] value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setImageBytes", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes column
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetImageBytesCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setImageBytesCol", value));
        
        
        /// <summary>
        /// Sets value for imageUrl
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetImageUrl(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setImageUrl", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl column
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetImageUrlCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setImageUrlCol", value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// the language of the response (en if none given)
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetLanguage(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// the language of the response (en if none given)
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetLanguageCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetOutputCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetSubscriptionKey(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetSubscriptionKeyCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetTimeout(double value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetUrl(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setUrl", (object)value));
        
        /// <summary>
        /// Sets value for visualFeatures
        /// </summary>
        /// <param name="value">
        /// what visual feature types to return
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetVisualFeatures(string[] value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setVisualFeatures", (object)value));
        
        
        /// <summary>
        /// Sets value for visualFeatures column
        /// </summary>
        /// <param name="value">
        /// what visual feature types to return
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetVisualFeaturesCol(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setVisualFeaturesCol", value));
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
        /// Gets details value
        /// </summary>
        /// <returns>
        /// details: what visual feature types to return
        /// </returns>
        public string[] GetDetails() =>
            (string[])Reference.Invoke("getDetails");
        
        
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
        /// Gets imageBytes value
        /// </summary>
        /// <returns>
        /// imageBytes: bytestream of the image to use
        /// </returns>
        public byte[] GetImageBytes() =>
            (byte[])Reference.Invoke("getImageBytes");
        
        
        /// <summary>
        /// Gets imageUrl value
        /// </summary>
        /// <returns>
        /// imageUrl: the url of the image to use
        /// </returns>
        public string GetImageUrl() =>
            (string)Reference.Invoke("getImageUrl");
        
        
        /// <summary>
        /// Gets language value
        /// </summary>
        /// <returns>
        /// language: the language of the response (en if none given)
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
        /// Gets visualFeatures value
        /// </summary>
        /// <returns>
        /// visualFeatures: what visual feature types to return
        /// </returns>
        public string[] GetVisualFeatures() =>
            (string[])Reference.Invoke("getVisualFeatures");
        
        /// <summary>
        /// Loads the <see cref="AnalyzeImage"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="AnalyzeImage"/> was saved to</param>
        /// <returns>New <see cref="AnalyzeImage"/> object, loaded from path.</returns>
        public static AnalyzeImage Load(string path) => WrapAsAnalyzeImage(
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
        /// <returns>an <see cref="JavaMLReader&lt;AnalyzeImage&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<AnalyzeImage> Read() =>
            new JavaMLReader<AnalyzeImage>((JvmObjectReference)Reference.Invoke("read"));
        private static AnalyzeImage WrapAsAnalyzeImage(object obj) =>
            new AnalyzeImage((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetLocation(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New AnalyzeImage object </returns>
        public AnalyzeImage SetLinkedService(string value) =>
            WrapAsAnalyzeImage(Reference.Invoke("setLinkedService", value));
    }
}

        