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
    /// <see cref="DescribeImage"/> implements DescribeImage
    /// </summary>
    public class DescribeImage : JavaTransformer, IJavaMLWritable, IJavaMLReadable<DescribeImage>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.DescribeImage";

        /// <summary>
        /// Creates a <see cref="DescribeImage"/> without any parameters.
        /// </summary>
        public DescribeImage() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="DescribeImage"/> with a UID that is used to give the
        /// <see cref="DescribeImage"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public DescribeImage(string uid) : base(s_className, uid)
        {
        }

        internal DescribeImage(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetConcurrency(int value) =>
            WrapAsDescribeImage(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetConcurrentTimeout(double value) =>
            WrapAsDescribeImage(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetErrorCol(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetHandler(object value) =>
            WrapAsDescribeImage(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetImageBytes(byte[] value) =>
            WrapAsDescribeImage(Reference.Invoke("setImageBytes", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes column
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetImageBytesCol(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setImageBytesCol", value));
        
        
        /// <summary>
        /// Sets value for imageUrl
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetImageUrl(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setImageUrl", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl column
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetImageUrlCol(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setImageUrlCol", value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// Language of image description
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetLanguage(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// Language of image description
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetLanguageCol(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for maxCandidates
        /// </summary>
        /// <param name="value">
        /// Maximum candidate descriptions to return
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetMaxCandidates(int value) =>
            WrapAsDescribeImage(Reference.Invoke("setMaxCandidates", (object)value));
        
        
        /// <summary>
        /// Sets value for maxCandidates column
        /// </summary>
        /// <param name="value">
        /// Maximum candidate descriptions to return
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetMaxCandidatesCol(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setMaxCandidatesCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetOutputCol(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetSubscriptionKey(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetSubscriptionKeyCol(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetTimeout(double value) =>
            WrapAsDescribeImage(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetUrl(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setUrl", (object)value));
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
        /// language: Language of image description
        /// </returns>
        public string GetLanguage() =>
            (string)Reference.Invoke("getLanguage");
        
        
        /// <summary>
        /// Gets maxCandidates value
        /// </summary>
        /// <returns>
        /// maxCandidates: Maximum candidate descriptions to return
        /// </returns>
        public int GetMaxCandidates() =>
            (int)Reference.Invoke("getMaxCandidates");
        
        
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
        /// Loads the <see cref="DescribeImage"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="DescribeImage"/> was saved to</param>
        /// <returns>New <see cref="DescribeImage"/> object, loaded from path.</returns>
        public static DescribeImage Load(string path) => WrapAsDescribeImage(
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
        /// <returns>an <see cref="JavaMLReader&lt;DescribeImage&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<DescribeImage> Read() =>
            new JavaMLReader<DescribeImage>((JvmObjectReference)Reference.Invoke("read"));
        private static DescribeImage WrapAsDescribeImage(object obj) =>
            new DescribeImage((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetLocation(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New DescribeImage object </returns>
        public DescribeImage SetLinkedService(string value) =>
            WrapAsDescribeImage(Reference.Invoke("setLinkedService", value));
    }
}

        