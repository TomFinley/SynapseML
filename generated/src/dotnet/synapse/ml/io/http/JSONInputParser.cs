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
    /// <see cref="JSONInputParser"/> implements JSONInputParser
    /// </summary>
    public class JSONInputParser : JavaTransformer, IJavaMLWritable, IJavaMLReadable<JSONInputParser>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.io.http.JSONInputParser";

        /// <summary>
        /// Creates a <see cref="JSONInputParser"/> without any parameters.
        /// </summary>
        public JSONInputParser() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="JSONInputParser"/> with a UID that is used to give the
        /// <see cref="JSONInputParser"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public JSONInputParser(string uid) : base(s_className, uid)
        {
        }

        internal JSONInputParser(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for headers
        /// </summary>
        /// <param name="value">
        /// headers of the request
        /// </param>
        /// <returns> New JSONInputParser object </returns>
        public JSONInputParser SetHeaders(Dictionary<string, string> value) =>
            WrapAsJSONInputParser(Reference.Invoke("setHeaders", (object)value.ToJavaHashMap()));
        
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New JSONInputParser object </returns>
        public JSONInputParser SetInputCol(string value) =>
            WrapAsJSONInputParser(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for method
        /// </summary>
        /// <param name="value">
        /// method to use for request, (PUT, POST, PATCH)
        /// </param>
        /// <returns> New JSONInputParser object </returns>
        public JSONInputParser SetMethod(string value) =>
            WrapAsJSONInputParser(Reference.Invoke("setMethod", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New JSONInputParser object </returns>
        public JSONInputParser SetOutputCol(string value) =>
            WrapAsJSONInputParser(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New JSONInputParser object </returns>
        public JSONInputParser SetUrl(string value) =>
            WrapAsJSONInputParser(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets headers value
        /// </summary>
        /// <returns>
        /// headers: headers of the request
        /// </returns>
        public Dictionary<string, string> GetHeaders()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getHeaders");
            var hashMap = (JvmObjectReference)SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                "org.apache.spark.api.dotnet.DotnetUtils", "convertToJavaMap", jvmObject);
            var keySet = (JvmObjectReference[])(
                (JvmObjectReference)hashMap.Invoke("keySet")).Invoke("toArray");
            var result = new Dictionary<string, string>();
            foreach (var k in keySet)
            {
                result.Add((string)k.Invoke("toString"), (string)hashMap.Invoke("get", k));
            }
            return result;
        }
        
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets method value
        /// </summary>
        /// <returns>
        /// method: method to use for request, (PUT, POST, PATCH)
        /// </returns>
        public string GetMethod() =>
            (string)Reference.Invoke("getMethod");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="JSONInputParser"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="JSONInputParser"/> was saved to</param>
        /// <returns>New <see cref="JSONInputParser"/> object, loaded from path.</returns>
        public static JSONInputParser Load(string path) => WrapAsJSONInputParser(
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
        /// <returns>an <see cref="JavaMLReader&lt;JSONInputParser&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<JSONInputParser> Read() =>
            new JavaMLReader<JSONInputParser>((JvmObjectReference)Reference.Invoke("read"));
        private static JSONInputParser WrapAsJSONInputParser(object obj) =>
            new JSONInputParser((JvmObjectReference)obj);
        
    }
}

        