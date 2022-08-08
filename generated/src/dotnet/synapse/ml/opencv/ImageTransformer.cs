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


namespace Synapse.ML.Opencv
{
    /// <summary>
    /// <see cref="ImageTransformer"/> implements ImageTransformer
    /// </summary>
    public class ImageTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ImageTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.opencv.ImageTransformer";

        /// <summary>
        /// Creates a <see cref="ImageTransformer"/> without any parameters.
        /// </summary>
        public ImageTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ImageTransformer"/> with a UID that is used to give the
        /// <see cref="ImageTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ImageTransformer(string uid) : base(s_className, uid)
        {
        }

        internal ImageTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for colorScaleFactor
        /// </summary>
        /// <param name="value">
        /// The scale factor for color values. Used for normalization. The color values will be multiplied with the scale factor.
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetColorScaleFactor(double value) =>
            WrapAsImageTransformer(Reference.Invoke("setColorScaleFactor", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetInputCol(string value) =>
            WrapAsImageTransformer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for normalizeMean
        /// </summary>
        /// <param name="value">
        /// The mean value to use for normalization for each channel. The length of the array must match the number of channels of the input image.
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetNormalizeMean(double[] value) =>
            WrapAsImageTransformer(Reference.Invoke("setNormalizeMean", (object)value));
        
        /// <summary>
        /// Sets value for normalizeStd
        /// </summary>
        /// <param name="value">
        /// The standard deviation to use for normalization for each channel. The length of the array must match the number of channels of the input image.
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetNormalizeStd(double[] value) =>
            WrapAsImageTransformer(Reference.Invoke("setNormalizeStd", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetOutputCol(string value) =>
            WrapAsImageTransformer(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for stages
        /// </summary>
        /// <param name="value">
        /// Image transformation stages
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetStages(Dictionary<string, object>[] value)
            => WrapAsImageTransformer(Reference.Invoke("setStages",
                (object)value.Select(_ => _.ToJavaHashMap()).ToArray().ToJavaArrayList()));
        
        
        /// <summary>
        /// Sets value for tensorChannelOrder
        /// </summary>
        /// <param name="value">
        /// The color channel order of the output channels. Valid values are RGB and GBR. Default: RGB.
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetTensorChannelOrder(string value) =>
            WrapAsImageTransformer(Reference.Invoke("setTensorChannelOrder", (object)value));
        
        /// <summary>
        /// Sets value for tensorElementType
        /// </summary>
        /// <param name="value">
        /// The element data type for the output tensor. Only used when toTensor is set to true. Valid values are DoubleType or FloatType. Default value: FloatType.
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetTensorElementType(DataType value) =>
            WrapAsImageTransformer(Reference.Invoke("setTensorElementType",
            DataType.FromJson(Reference.Jvm, value.Json)));
        
        
        /// <summary>
        /// Sets value for toTensor
        /// </summary>
        /// <param name="value">
        /// Convert output image to tensor in the shape of (C * H * W)
        /// </param>
        /// <returns> New ImageTransformer object </returns>
        public ImageTransformer SetToTensor(bool value) =>
            WrapAsImageTransformer(Reference.Invoke("setToTensor", (object)value));
        /// <summary>
        /// Gets colorScaleFactor value
        /// </summary>
        /// <returns>
        /// colorScaleFactor: The scale factor for color values. Used for normalization. The color values will be multiplied with the scale factor.
        /// </returns>
        public double GetColorScaleFactor() =>
            (double)Reference.Invoke("getColorScaleFactor");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets normalizeMean value
        /// </summary>
        /// <returns>
        /// normalizeMean: The mean value to use for normalization for each channel. The length of the array must match the number of channels of the input image.
        /// </returns>
        public double[] GetNormalizeMean() =>
            (double[])Reference.Invoke("getNormalizeMean");
        
        /// <summary>
        /// Gets normalizeStd value
        /// </summary>
        /// <returns>
        /// normalizeStd: The standard deviation to use for normalization for each channel. The length of the array must match the number of channels of the input image.
        /// </returns>
        public double[] GetNormalizeStd() =>
            (double[])Reference.Invoke("getNormalizeStd");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets stages value
        /// </summary>
        /// <returns>
        /// stages: Image transformation stages
        /// </returns>
        public Dictionary<string, object>[] GetStages()
        {
            var jvmObjects = (JvmObjectReference[])Reference.Invoke("getStages");
            var result = new Dictionary<string, object>[jvmObjects.Length];
            JvmObjectReference hashMap;
            JvmObjectReference[] keySet;
            Dictionary<string, object> dic;
            object value;
            for (int i = 0; i < result.Length; i++)
            {
                hashMap = (JvmObjectReference)SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                    "org.apache.spark.api.dotnet.DotnetUtils", "convertToJavaMap", jvmObjects[i]);
                keySet = (JvmObjectReference[])(
                    (JvmObjectReference)hashMap.Invoke("keySet")).Invoke("toArray");
                dic = new Dictionary<string, object>();
                foreach (var k in keySet)
                {
                    value = SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                        "org.apache.spark.api.dotnet.DotnetUtils",
                        "mapScalaToJava", hashMap.Invoke("get", k));
                    dic.Add((string)k.Invoke("toString"), value);
                }
                result[i] = dic;
            }
            return result;
        }
        
        
        /// <summary>
        /// Gets tensorChannelOrder value
        /// </summary>
        /// <returns>
        /// tensorChannelOrder: The color channel order of the output channels. Valid values are RGB and GBR. Default: RGB.
        /// </returns>
        public string GetTensorChannelOrder() =>
            (string)Reference.Invoke("getTensorChannelOrder");
        
        /// <summary>
        /// Gets tensorElementType value
        /// </summary>
        /// <returns>
        /// tensorElementType: The element data type for the output tensor. Only used when toTensor is set to true. Valid values are DoubleType or FloatType. Default value: FloatType.
        /// </returns>
        public DataType GetTensorElementType()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getTensorElementType");
            var json = (string)jvmObject.Invoke("json");
            return DataType.ParseDataType(json);
        }
        
        
        /// <summary>
        /// Gets toTensor value
        /// </summary>
        /// <returns>
        /// toTensor: Convert output image to tensor in the shape of (C * H * W)
        /// </returns>
        public bool GetToTensor() =>
            (bool)Reference.Invoke("getToTensor");
        
        /// <summary>
        /// Loads the <see cref="ImageTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ImageTransformer"/> was saved to</param>
        /// <returns>New <see cref="ImageTransformer"/> object, loaded from path.</returns>
        public static ImageTransformer Load(string path) => WrapAsImageTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;ImageTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ImageTransformer> Read() =>
            new JavaMLReader<ImageTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static ImageTransformer WrapAsImageTransformer(object obj) =>
            new ImageTransformer((JvmObjectReference)obj);
        
    }
}

        