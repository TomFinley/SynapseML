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


namespace Synapse.ML.Onnx
{
    /// <summary>
    /// <see cref="ONNXModel"/> implements ONNXModel
    /// </summary>
    public class ONNXModel : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ONNXModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.onnx.ONNXModel";

        /// <summary>
        /// Creates a <see cref="ONNXModel"/> without any parameters.
        /// </summary>
        public ONNXModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ONNXModel"/> with a UID that is used to give the
        /// <see cref="ONNXModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ONNXModel(string uid) : base(s_className, uid)
        {
        }

        internal ONNXModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for argMaxDict
        /// </summary>
        /// <param name="value">
        /// A map between output dataframe columns, where the value column will be computed from taking the argmax of the key column. This can be used to convert probability output to predicted label.
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetArgMaxDict(Dictionary<string, string> value) =>
            WrapAsONNXModel(Reference.Invoke("setArgMaxDict", (object)value.ToJavaHashMap()));
        
        
        /// <summary>
        /// Sets value for deviceType
        /// </summary>
        /// <param name="value">
        /// Specify a device type the model inference runs on. Supported types are: CPU or CUDA.If not specified, auto detection will be used.
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetDeviceType(string value) =>
            WrapAsONNXModel(Reference.Invoke("setDeviceType", (object)value));
        
        /// <summary>
        /// Sets value for feedDict
        /// </summary>
        /// <param name="value">
        ///  Provide a map from CNTK/ONNX model input variable names (keys) to column names of the input dataframe (values)
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetFeedDict(Dictionary<string, string> value) =>
            WrapAsONNXModel(Reference.Invoke("setFeedDict", (object)value.ToJavaHashMap()));
        
        
        /// <summary>
        /// Sets value for fetchDict
        /// </summary>
        /// <param name="value">
        /// Provide a map from column names of the output dataframe (keys) to CNTK/ONNX model output variable names (values)
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetFetchDict(Dictionary<string, string> value) =>
            WrapAsONNXModel(Reference.Invoke("setFetchDict", (object)value.ToJavaHashMap()));
        
        
        /// <summary>
        /// Sets value for miniBatcher
        /// </summary>
        /// <param name="value">
        /// Minibatcher to use
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetMiniBatcher(JavaTransformer value) =>
            WrapAsONNXModel(Reference.Invoke("setMiniBatcher", (object)value));
        
        
        /// <summary>
        /// Sets value for modelPayload
        /// </summary>
        /// <param name="value">
        /// Array of bytes containing the serialized ONNX model.
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetModelPayload(object value) =>
            WrapAsONNXModel(Reference.Invoke("setModelPayload", (object)value));
        
        
        /// <summary>
        /// Sets value for optimizationLevel
        /// </summary>
        /// <param name="value">
        /// Specify the optimization level for the ONNX graph optimizations. Details at https://onnxruntime.ai/docs/resources/graph-optimizations.html#graph-optimization-levels. Supported values are: NO_OPT; BASIC_OPT; EXTENDED_OPT; ALL_OPT. Default: ALL_OPT.
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetOptimizationLevel(string value) =>
            WrapAsONNXModel(Reference.Invoke("setOptimizationLevel", (object)value));
        
        /// <summary>
        /// Sets value for softMaxDict
        /// </summary>
        /// <param name="value">
        /// A map between output dataframe columns, where the value column will be computed from taking the softmax of the key column. If the 'rawPrediction' column contains logits outputs, then one can set softMaxDict to `Map("rawPrediction" -> "probability")` to obtain the probability outputs.
        /// </param>
        /// <returns> New ONNXModel object </returns>
        public ONNXModel SetSoftMaxDict(Dictionary<string, string> value) =>
            WrapAsONNXModel(Reference.Invoke("setSoftMaxDict", (object)value.ToJavaHashMap()));
        /// <summary>
        /// Gets argMaxDict value
        /// </summary>
        /// <returns>
        /// argMaxDict: A map between output dataframe columns, where the value column will be computed from taking the argmax of the key column. This can be used to convert probability output to predicted label.
        /// </returns>
        public Dictionary<string, string> GetArgMaxDict()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getArgMaxDict");
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
        /// Gets deviceType value
        /// </summary>
        /// <returns>
        /// deviceType: Specify a device type the model inference runs on. Supported types are: CPU or CUDA.If not specified, auto detection will be used.
        /// </returns>
        public string GetDeviceType() =>
            (string)Reference.Invoke("getDeviceType");
        
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
        /// Gets modelPayload value
        /// </summary>
        /// <returns>
        /// modelPayload: Array of bytes containing the serialized ONNX model.
        /// </returns>
        public object GetModelPayload() => Reference.Invoke("getModelPayload");
        
        /// <summary>
        /// Gets optimizationLevel value
        /// </summary>
        /// <returns>
        /// optimizationLevel: Specify the optimization level for the ONNX graph optimizations. Details at https://onnxruntime.ai/docs/resources/graph-optimizations.html#graph-optimization-levels. Supported values are: NO_OPT; BASIC_OPT; EXTENDED_OPT; ALL_OPT. Default: ALL_OPT.
        /// </returns>
        public string GetOptimizationLevel() =>
            (string)Reference.Invoke("getOptimizationLevel");
        
        /// <summary>
        /// Gets softMaxDict value
        /// </summary>
        /// <returns>
        /// softMaxDict: A map between output dataframe columns, where the value column will be computed from taking the softmax of the key column. If the 'rawPrediction' column contains logits outputs, then one can set softMaxDict to `Map("rawPrediction" -> "probability")` to obtain the probability outputs.
        /// </returns>
        public Dictionary<string, string> GetSoftMaxDict()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getSoftMaxDict");
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
        /// Loads the <see cref="ONNXModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ONNXModel"/> was saved to</param>
        /// <returns>New <see cref="ONNXModel"/> object, loaded from path.</returns>
        public static ONNXModel Load(string path) => WrapAsONNXModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;ONNXModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ONNXModel> Read() =>
            new JavaMLReader<ONNXModel>((JvmObjectReference)Reference.Invoke("read"));
        private static ONNXModel WrapAsONNXModel(object obj) =>
            new ONNXModel((JvmObjectReference)obj);
        
    }
}

        