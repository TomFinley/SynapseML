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


namespace Synapse.ML.Cntk
{
    /// <summary>
    /// <see cref="CNTKModel"/> implements CNTKModel
    /// </summary>
    public class CNTKModel : JavaModel<CNTKModel>, IJavaMLWritable, IJavaMLReadable<CNTKModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cntk.CNTKModel";

        /// <summary>
        /// Creates a <see cref="CNTKModel"/> without any parameters.
        /// </summary>
        public CNTKModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="CNTKModel"/> with a UID that is used to give the
        /// <see cref="CNTKModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public CNTKModel(string uid) : base(s_className, uid)
        {
        }

        internal CNTKModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for batchInput
        /// </summary>
        /// <param name="value">
        /// whether to use a batcher
        /// </param>
        /// <returns> New CNTKModel object </returns>
        public CNTKModel SetBatchInput(bool value) =>
            WrapAsCNTKModel(Reference.Invoke("setBatchInput", (object)value));
        
        /// <summary>
        /// Sets value for convertOutputToDenseVector
        /// </summary>
        /// <param name="value">
        /// whether to convert the output to dense vectors
        /// </param>
        /// <returns> New CNTKModel object </returns>
        public CNTKModel SetConvertOutputToDenseVector(bool value) =>
            WrapAsCNTKModel(Reference.Invoke("setConvertOutputToDenseVector", (object)value));
        
        /// <summary>
        /// Sets value for feedDict
        /// </summary>
        /// <param name="value">
        ///  Provide a map from CNTK/ONNX model input variable names (keys) to column names of the input dataframe (values)
        /// </param>
        /// <returns> New CNTKModel object </returns>
        public CNTKModel SetFeedDict(Dictionary<string, string> value) =>
            WrapAsCNTKModel(Reference.Invoke("setFeedDict", (object)value.ToJavaHashMap()));
        
        
        /// <summary>
        /// Sets value for fetchDict
        /// </summary>
        /// <param name="value">
        /// Provide a map from column names of the output dataframe (keys) to CNTK/ONNX model output variable names (values)
        /// </param>
        /// <returns> New CNTKModel object </returns>
        public CNTKModel SetFetchDict(Dictionary<string, string> value) =>
            WrapAsCNTKModel(Reference.Invoke("setFetchDict", (object)value.ToJavaHashMap()));
        
        
        /// <summary>
        /// Sets value for miniBatcher
        /// </summary>
        /// <param name="value">
        /// Minibatcher to use
        /// </param>
        /// <returns> New CNTKModel object </returns>
        public CNTKModel SetMiniBatcher(JavaTransformer value) =>
            WrapAsCNTKModel(Reference.Invoke("setMiniBatcher", (object)value));
        
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// Array of bytes containing the serialized CNTKModel
        /// </param>
        /// <returns> New CNTKModel object </returns>
        public CNTKModel SetModelLocation(string value) =>
            WrapAsCNTKModel(Reference.Invoke("setModelLocation", value));
        /// <summary>
        /// Gets batchInput value
        /// </summary>
        /// <returns>
        /// batchInput: whether to use a batcher
        /// </returns>
        public bool GetBatchInput() =>
            (bool)Reference.Invoke("getBatchInput");
        
        /// <summary>
        /// Gets convertOutputToDenseVector value
        /// </summary>
        /// <returns>
        /// convertOutputToDenseVector: whether to convert the output to dense vectors
        /// </returns>
        public bool GetConvertOutputToDenseVector() =>
            (bool)Reference.Invoke("getConvertOutputToDenseVector");
        
        /// <summary>
        /// Gets feedDict value
        /// </summary>
        /// <returns>
        /// feedDict:  Provide a map from CNTK/ONNX model input variable names (keys) to column names of the input dataframe (values)
        /// </returns>
        public Dictionary<string, string> GetFeedDict()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getFeedDict");
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
        /// Gets fetchDict value
        /// </summary>
        /// <returns>
        /// fetchDict: Provide a map from column names of the output dataframe (keys) to CNTK/ONNX model output variable names (values)
        /// </returns>
        public Dictionary<string, string> GetFetchDict()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getFetchDict");
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
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: Array of bytes containing the serialized CNTKModel
        /// </returns>
        public object GetModel() => Reference.Invoke("getModel");
        
        /// <summary>
        /// Loads the <see cref="CNTKModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="CNTKModel"/> was saved to</param>
        /// <returns>New <see cref="CNTKModel"/> object, loaded from path.</returns>
        public static CNTKModel Load(string path) => WrapAsCNTKModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;CNTKModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<CNTKModel> Read() =>
            new JavaMLReader<CNTKModel>((JvmObjectReference)Reference.Invoke("read"));
        private static CNTKModel WrapAsCNTKModel(object obj) =>
            new CNTKModel((JvmObjectReference)obj);
        
    }
}

        