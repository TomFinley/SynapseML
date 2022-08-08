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


namespace Synapse.ML.Stages
{
    /// <summary>
    /// <see cref="TextPreprocessor"/> implements TextPreprocessor
    /// </summary>
    public class TextPreprocessor : JavaTransformer, IJavaMLWritable, IJavaMLReadable<TextPreprocessor>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.TextPreprocessor";

        /// <summary>
        /// Creates a <see cref="TextPreprocessor"/> without any parameters.
        /// </summary>
        public TextPreprocessor() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TextPreprocessor"/> with a UID that is used to give the
        /// <see cref="TextPreprocessor"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TextPreprocessor(string uid) : base(s_className, uid)
        {
        }

        internal TextPreprocessor(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New TextPreprocessor object </returns>
        public TextPreprocessor SetInputCol(string value) =>
            WrapAsTextPreprocessor(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for map
        /// </summary>
        /// <param name="value">
        /// Map of substring match to replacement
        /// </param>
        /// <returns> New TextPreprocessor object </returns>
        public TextPreprocessor SetMap(Dictionary<string, string> value) =>
            WrapAsTextPreprocessor(Reference.Invoke("setMap", (object)value.ToJavaHashMap()));
        
        
        /// <summary>
        /// Sets value for normFunc
        /// </summary>
        /// <param name="value">
        /// Name of normalization function to apply
        /// </param>
        /// <returns> New TextPreprocessor object </returns>
        public TextPreprocessor SetNormFunc(string value) =>
            WrapAsTextPreprocessor(Reference.Invoke("setNormFunc", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New TextPreprocessor object </returns>
        public TextPreprocessor SetOutputCol(string value) =>
            WrapAsTextPreprocessor(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets map value
        /// </summary>
        /// <returns>
        /// map: Map of substring match to replacement
        /// </returns>
        public Dictionary<string, string> GetMap()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getMap");
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
        /// Gets normFunc value
        /// </summary>
        /// <returns>
        /// normFunc: Name of normalization function to apply
        /// </returns>
        public string GetNormFunc() =>
            (string)Reference.Invoke("getNormFunc");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="TextPreprocessor"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TextPreprocessor"/> was saved to</param>
        /// <returns>New <see cref="TextPreprocessor"/> object, loaded from path.</returns>
        public static TextPreprocessor Load(string path) => WrapAsTextPreprocessor(
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
        /// <returns>an <see cref="JavaMLReader&lt;TextPreprocessor&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TextPreprocessor> Read() =>
            new JavaMLReader<TextPreprocessor>((JvmObjectReference)Reference.Invoke("read"));
        private static TextPreprocessor WrapAsTextPreprocessor(object obj) =>
            new TextPreprocessor((JvmObjectReference)obj);
        
    }
}

        