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


namespace Synapse.ML.Io.Http
{
    /// <summary>
    /// <see cref="HTTPTransformer"/> implements HTTPTransformer
    /// </summary>
    public class HTTPTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<HTTPTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.io.http.HTTPTransformer";

        /// <summary>
        /// Creates a <see cref="HTTPTransformer"/> without any parameters.
        /// </summary>
        public HTTPTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="HTTPTransformer"/> with a UID that is used to give the
        /// <see cref="HTTPTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public HTTPTransformer(string uid) : base(s_className, uid)
        {
        }

        internal HTTPTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New HTTPTransformer object </returns>
        public HTTPTransformer SetConcurrency(int value) =>
            WrapAsHTTPTransformer(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New HTTPTransformer object </returns>
        public HTTPTransformer SetConcurrentTimeout(double value) =>
            WrapAsHTTPTransformer(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New HTTPTransformer object </returns>
        public HTTPTransformer SetHandler(object value) =>
            WrapAsHTTPTransformer(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New HTTPTransformer object </returns>
        public HTTPTransformer SetInputCol(string value) =>
            WrapAsHTTPTransformer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New HTTPTransformer object </returns>
        public HTTPTransformer SetOutputCol(string value) =>
            WrapAsHTTPTransformer(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New HTTPTransformer object </returns>
        public HTTPTransformer SetTimeout(double value) =>
            WrapAsHTTPTransformer(Reference.Invoke("setTimeout", (object)value));
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
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: number of seconds to wait before closing the connection
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Loads the <see cref="HTTPTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="HTTPTransformer"/> was saved to</param>
        /// <returns>New <see cref="HTTPTransformer"/> object, loaded from path.</returns>
        public static HTTPTransformer Load(string path) => WrapAsHTTPTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;HTTPTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<HTTPTransformer> Read() =>
            new JavaMLReader<HTTPTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static HTTPTransformer WrapAsHTTPTransformer(object obj) =>
            new HTTPTransformer((JvmObjectReference)obj);
        
    }
}

        