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
    /// <see cref="GenerateThumbnails"/> implements GenerateThumbnails
    /// </summary>
    public class GenerateThumbnails : JavaTransformer, IJavaMLWritable, IJavaMLReadable<GenerateThumbnails>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.GenerateThumbnails";

        /// <summary>
        /// Creates a <see cref="GenerateThumbnails"/> without any parameters.
        /// </summary>
        public GenerateThumbnails() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="GenerateThumbnails"/> with a UID that is used to give the
        /// <see cref="GenerateThumbnails"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public GenerateThumbnails(string uid) : base(s_className, uid)
        {
        }

        internal GenerateThumbnails(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetConcurrency(int value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetConcurrentTimeout(double value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetErrorCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetHandler(object value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for height
        /// </summary>
        /// <param name="value">
        /// the desired height of the image
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetHeight(int value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setHeight", (object)value));
        
        
        /// <summary>
        /// Sets value for height column
        /// </summary>
        /// <param name="value">
        /// the desired height of the image
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetHeightCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setHeightCol", value));
        
        
        /// <summary>
        /// Sets value for imageBytes
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetImageBytes(byte[] value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setImageBytes", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes column
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetImageBytesCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setImageBytesCol", value));
        
        
        /// <summary>
        /// Sets value for imageUrl
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetImageUrl(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setImageUrl", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl column
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetImageUrlCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setImageUrlCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetOutputCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for smartCropping
        /// </summary>
        /// <param name="value">
        /// whether to intelligently crop the image
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetSmartCropping(bool value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setSmartCropping", (object)value));
        
        
        /// <summary>
        /// Sets value for smartCropping column
        /// </summary>
        /// <param name="value">
        /// whether to intelligently crop the image
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetSmartCroppingCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setSmartCroppingCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetSubscriptionKey(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetSubscriptionKeyCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetTimeout(double value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetUrl(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setUrl", (object)value));
        
        /// <summary>
        /// Sets value for width
        /// </summary>
        /// <param name="value">
        /// the desired width of the image
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetWidth(int value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setWidth", (object)value));
        
        
        /// <summary>
        /// Sets value for width column
        /// </summary>
        /// <param name="value">
        /// the desired width of the image
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetWidthCol(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setWidthCol", value));
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
        /// Gets height value
        /// </summary>
        /// <returns>
        /// height: the desired height of the image
        /// </returns>
        public int GetHeight() =>
            (int)Reference.Invoke("getHeight");
        
        
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
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets smartCropping value
        /// </summary>
        /// <returns>
        /// smartCropping: whether to intelligently crop the image
        /// </returns>
        public bool GetSmartCropping() =>
            (bool)Reference.Invoke("getSmartCropping");
        
        
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
        /// Gets width value
        /// </summary>
        /// <returns>
        /// width: the desired width of the image
        /// </returns>
        public int GetWidth() =>
            (int)Reference.Invoke("getWidth");
        
        /// <summary>
        /// Loads the <see cref="GenerateThumbnails"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="GenerateThumbnails"/> was saved to</param>
        /// <returns>New <see cref="GenerateThumbnails"/> object, loaded from path.</returns>
        public static GenerateThumbnails Load(string path) => WrapAsGenerateThumbnails(
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
        /// <returns>an <see cref="JavaMLReader&lt;GenerateThumbnails&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<GenerateThumbnails> Read() =>
            new JavaMLReader<GenerateThumbnails>((JvmObjectReference)Reference.Invoke("read"));
        private static GenerateThumbnails WrapAsGenerateThumbnails(object obj) =>
            new GenerateThumbnails((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetLocation(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New GenerateThumbnails object </returns>
        public GenerateThumbnails SetLinkedService(string value) =>
            WrapAsGenerateThumbnails(Reference.Invoke("setLinkedService", value));
    }
}

        