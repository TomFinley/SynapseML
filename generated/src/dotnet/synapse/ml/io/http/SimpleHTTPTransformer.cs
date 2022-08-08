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
    /// <see cref="SimpleHTTPTransformer"/> implements SimpleHTTPTransformer
    /// </summary>
    public class SimpleHTTPTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<SimpleHTTPTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.io.http.SimpleHTTPTransformer";

        /// <summary>
        /// Creates a <see cref="SimpleHTTPTransformer"/> without any parameters.
        /// </summary>
        public SimpleHTTPTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="SimpleHTTPTransformer"/> with a UID that is used to give the
        /// <see cref="SimpleHTTPTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SimpleHTTPTransformer(string uid) : base(s_className, uid)
        {
        }

        internal SimpleHTTPTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetConcurrency(int value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetConcurrentTimeout(double value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetErrorCol(string value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for flattenOutputBatches
        /// </summary>
        /// <param name="value">
        /// whether to flatten the output batches
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetFlattenOutputBatches(bool value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setFlattenOutputBatches", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetHandler(object value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetInputCol(string value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for inputParser
        /// </summary>
        /// <param name="value">
        /// format to parse the column to
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetInputParser(JavaTransformer value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setInputParser", (object)value));
        
        
        /// <summary>
        /// Sets value for miniBatcher
        /// </summary>
        /// <param name="value">
        /// Minibatcher to use
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetMiniBatcher(JavaTransformer value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setMiniBatcher", (object)value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetOutputCol(string value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputParser
        /// </summary>
        /// <param name="value">
        /// format to parse the column to
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetOutputParser(JavaTransformer value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setOutputParser", (object)value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New SimpleHTTPTransformer object </returns>
        public SimpleHTTPTransformer SetTimeout(double value) =>
            WrapAsSimpleHTTPTransformer(Reference.Invoke("setTimeout", (object)value));
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
        /// Gets flattenOutputBatches value
        /// </summary>
        /// <returns>
        /// flattenOutputBatches: whether to flatten the output batches
        /// </returns>
        public bool GetFlattenOutputBatches() =>
            (bool)Reference.Invoke("getFlattenOutputBatches");
        
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
        /// Gets inputParser value
        /// </summary>
        /// <returns>
        /// inputParser: format to parse the column to
        /// </returns>
        public JavaTransformer GetInputParser()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getInputParser");
            Dictionary<string, Type> classMapping = JvmObjectUtils.ConstructJavaClassMapping(
                        typeof(JavaTransformer),
                        "s_className");
            JvmObjectUtils.TryConstructInstanceFromJvmObject(
                        jvmObject,
                        classMapping,
                        out JavaTransformer instance);
            return instance;
        }
        
        
        /// <summary>
        /// Gets miniBatcher value
        /// </summary>
        /// <returns>
        /// miniBatcher: Minibatcher to use
        /// </returns>
        public JavaTransformer GetMiniBatcher()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getMiniBatcher");
            Dictionary<string, Type> classMapping = JvmObjectUtils.ConstructJavaClassMapping(
                        typeof(JavaTransformer),
                        "s_className");
            JvmObjectUtils.TryConstructInstanceFromJvmObject(
                        jvmObject,
                        classMapping,
                        out JavaTransformer instance);
            return instance;
        }
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets outputParser value
        /// </summary>
        /// <returns>
        /// outputParser: format to parse the column to
        /// </returns>
        public JavaTransformer GetOutputParser()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getOutputParser");
            Dictionary<string, Type> classMapping = JvmObjectUtils.ConstructJavaClassMapping(
                        typeof(JavaTransformer),
                        "s_className");
            JvmObjectUtils.TryConstructInstanceFromJvmObject(
                        jvmObject,
                        classMapping,
                        out JavaTransformer instance);
            return instance;
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
        /// Loads the <see cref="SimpleHTTPTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SimpleHTTPTransformer"/> was saved to</param>
        /// <returns>New <see cref="SimpleHTTPTransformer"/> object, loaded from path.</returns>
        public static SimpleHTTPTransformer Load(string path) => WrapAsSimpleHTTPTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;SimpleHTTPTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<SimpleHTTPTransformer> Read() =>
            new JavaMLReader<SimpleHTTPTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static SimpleHTTPTransformer WrapAsSimpleHTTPTransformer(object obj) =>
            new SimpleHTTPTransformer((JvmObjectReference)obj);
        
    }
}

        