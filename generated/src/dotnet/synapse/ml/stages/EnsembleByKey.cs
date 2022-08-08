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
    /// <see cref="EnsembleByKey"/> implements EnsembleByKey
    /// </summary>
    public class EnsembleByKey : JavaTransformer, IJavaMLWritable, IJavaMLReadable<EnsembleByKey>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.EnsembleByKey";

        /// <summary>
        /// Creates a <see cref="EnsembleByKey"/> without any parameters.
        /// </summary>
        public EnsembleByKey() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="EnsembleByKey"/> with a UID that is used to give the
        /// <see cref="EnsembleByKey"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public EnsembleByKey(string uid) : base(s_className, uid)
        {
        }

        internal EnsembleByKey(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for colNames
        /// </summary>
        /// <param name="value">
        /// Names of the result of each col
        /// </param>
        /// <returns> New EnsembleByKey object </returns>
        public EnsembleByKey SetColNames(string[] value) =>
            WrapAsEnsembleByKey(Reference.Invoke("setColNames", (object)value));
        
        /// <summary>
        /// Sets value for collapseGroup
        /// </summary>
        /// <param name="value">
        /// Whether to collapse all items in group to one entry
        /// </param>
        /// <returns> New EnsembleByKey object </returns>
        public EnsembleByKey SetCollapseGroup(bool value) =>
            WrapAsEnsembleByKey(Reference.Invoke("setCollapseGroup", (object)value));
        
        /// <summary>
        /// Sets value for cols
        /// </summary>
        /// <param name="value">
        /// Cols to ensemble
        /// </param>
        /// <returns> New EnsembleByKey object </returns>
        public EnsembleByKey SetCols(string[] value) =>
            WrapAsEnsembleByKey(Reference.Invoke("setCols", (object)value));
        
        /// <summary>
        /// Sets value for keys
        /// </summary>
        /// <param name="value">
        /// Keys to group by
        /// </param>
        /// <returns> New EnsembleByKey object </returns>
        public EnsembleByKey SetKeys(string[] value) =>
            WrapAsEnsembleByKey(Reference.Invoke("setKeys", (object)value));
        
        /// <summary>
        /// Sets value for strategy
        /// </summary>
        /// <param name="value">
        /// How to ensemble the scores, ex: mean
        /// </param>
        /// <returns> New EnsembleByKey object </returns>
        public EnsembleByKey SetStrategy(string value) =>
            WrapAsEnsembleByKey(Reference.Invoke("setStrategy", (object)value));
        
        /// <summary>
        /// Sets value for vectorDims
        /// </summary>
        /// <param name="value">
        /// the dimensions of any vector columns, used to avoid materialization
        /// </param>
        /// <returns> New EnsembleByKey object </returns>
        public EnsembleByKey SetVectorDims(Dictionary<string, int> value) =>
            WrapAsEnsembleByKey(Reference.Invoke("setVectorDims", (object)value.ToJavaHashMap()));
        /// <summary>
        /// Gets colNames value
        /// </summary>
        /// <returns>
        /// colNames: Names of the result of each col
        /// </returns>
        public string[] GetColNames() =>
            (string[])Reference.Invoke("getColNames");
        
        /// <summary>
        /// Gets collapseGroup value
        /// </summary>
        /// <returns>
        /// collapseGroup: Whether to collapse all items in group to one entry
        /// </returns>
        public bool GetCollapseGroup() =>
            (bool)Reference.Invoke("getCollapseGroup");
        
        /// <summary>
        /// Gets cols value
        /// </summary>
        /// <returns>
        /// cols: Cols to ensemble
        /// </returns>
        public string[] GetCols() =>
            (string[])Reference.Invoke("getCols");
        
        /// <summary>
        /// Gets keys value
        /// </summary>
        /// <returns>
        /// keys: Keys to group by
        /// </returns>
        public string[] GetKeys() =>
            (string[])Reference.Invoke("getKeys");
        
        /// <summary>
        /// Gets strategy value
        /// </summary>
        /// <returns>
        /// strategy: How to ensemble the scores, ex: mean
        /// </returns>
        public string GetStrategy() =>
            (string)Reference.Invoke("getStrategy");
        
        /// <summary>
        /// Gets vectorDims value
        /// </summary>
        /// <returns>
        /// vectorDims: the dimensions of any vector columns, used to avoid materialization
        /// </returns>
        public Dictionary<string, int> GetVectorDims()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getVectorDims");
            var hashMap = (JvmObjectReference)SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                "org.apache.spark.api.dotnet.DotnetUtils", "convertToJavaMap", jvmObject);
            var keySet = (JvmObjectReference[])(
                (JvmObjectReference)hashMap.Invoke("keySet")).Invoke("toArray");
            var result = new Dictionary<string, int>();
            foreach (var k in keySet)
            {
                result.Add((string)k.Invoke("toString"), (int)hashMap.Invoke("get", k));
            }
            return result;
        }
        
        /// <summary>
        /// Loads the <see cref="EnsembleByKey"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="EnsembleByKey"/> was saved to</param>
        /// <returns>New <see cref="EnsembleByKey"/> object, loaded from path.</returns>
        public static EnsembleByKey Load(string path) => WrapAsEnsembleByKey(
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
        /// <returns>an <see cref="JavaMLReader&lt;EnsembleByKey&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<EnsembleByKey> Read() =>
            new JavaMLReader<EnsembleByKey>((JvmObjectReference)Reference.Invoke("read"));
        private static EnsembleByKey WrapAsEnsembleByKey(object obj) =>
            new EnsembleByKey((JvmObjectReference)obj);
        
    }
}

        