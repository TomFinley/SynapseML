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


namespace Synapse.ML.Lime
{
    /// <summary>
    /// <see cref="ImageLIME"/> implements ImageLIME
    /// </summary>
    public class ImageLIME : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ImageLIME>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.lime.ImageLIME";

        /// <summary>
        /// Creates a <see cref="ImageLIME"/> without any parameters.
        /// </summary>
        public ImageLIME() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ImageLIME"/> with a UID that is used to give the
        /// <see cref="ImageLIME"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ImageLIME(string uid) : base(s_className, uid)
        {
        }

        internal ImageLIME(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for cellSize
        /// </summary>
        /// <param name="value">
        /// Number that controls the size of the superpixels
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetCellSize(double value) =>
            WrapAsImageLIME(Reference.Invoke("setCellSize", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetInputCol(string value) =>
            WrapAsImageLIME(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// Model to try to locally approximate
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetModel(JavaTransformer value) =>
            WrapAsImageLIME(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for modifier
        /// </summary>
        /// <param name="value">
        /// Controls the trade-off spatial and color distance
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetModifier(double value) =>
            WrapAsImageLIME(Reference.Invoke("setModifier", (object)value));
        
        /// <summary>
        /// Sets value for nSamples
        /// </summary>
        /// <param name="value">
        /// The number of samples to generate
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetNSamples(int value) =>
            WrapAsImageLIME(Reference.Invoke("setNSamples", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetOutputCol(string value) =>
            WrapAsImageLIME(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetPredictionCol(string value) =>
            WrapAsImageLIME(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for regularization
        /// </summary>
        /// <param name="value">
        /// regularization param for the lasso
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetRegularization(double value) =>
            WrapAsImageLIME(Reference.Invoke("setRegularization", (object)value));
        
        /// <summary>
        /// Sets value for samplingFraction
        /// </summary>
        /// <param name="value">
        /// The fraction of superpixels to keep on
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetSamplingFraction(double value) =>
            WrapAsImageLIME(Reference.Invoke("setSamplingFraction", (object)value));
        
        /// <summary>
        /// Sets value for superpixelCol
        /// </summary>
        /// <param name="value">
        /// The column holding the superpixel decompositions
        /// </param>
        /// <returns> New ImageLIME object </returns>
        public ImageLIME SetSuperpixelCol(string value) =>
            WrapAsImageLIME(Reference.Invoke("setSuperpixelCol", (object)value));
        /// <summary>
        /// Gets cellSize value
        /// </summary>
        /// <returns>
        /// cellSize: Number that controls the size of the superpixels
        /// </returns>
        public double GetCellSize() =>
            (double)Reference.Invoke("getCellSize");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: Model to try to locally approximate
        /// </returns>
        public JavaTransformer GetModel()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getModel");
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
        /// Gets modifier value
        /// </summary>
        /// <returns>
        /// modifier: Controls the trade-off spatial and color distance
        /// </returns>
        public double GetModifier() =>
            (double)Reference.Invoke("getModifier");
        
        /// <summary>
        /// Gets nSamples value
        /// </summary>
        /// <returns>
        /// nSamples: The number of samples to generate
        /// </returns>
        public int GetNSamples() =>
            (int)Reference.Invoke("getNSamples");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets predictionCol value
        /// </summary>
        /// <returns>
        /// predictionCol: prediction column name
        /// </returns>
        public string GetPredictionCol() =>
            (string)Reference.Invoke("getPredictionCol");
        
        /// <summary>
        /// Gets regularization value
        /// </summary>
        /// <returns>
        /// regularization: regularization param for the lasso
        /// </returns>
        public double GetRegularization() =>
            (double)Reference.Invoke("getRegularization");
        
        /// <summary>
        /// Gets samplingFraction value
        /// </summary>
        /// <returns>
        /// samplingFraction: The fraction of superpixels to keep on
        /// </returns>
        public double GetSamplingFraction() =>
            (double)Reference.Invoke("getSamplingFraction");
        
        /// <summary>
        /// Gets superpixelCol value
        /// </summary>
        /// <returns>
        /// superpixelCol: The column holding the superpixel decompositions
        /// </returns>
        public string GetSuperpixelCol() =>
            (string)Reference.Invoke("getSuperpixelCol");
        
        /// <summary>
        /// Loads the <see cref="ImageLIME"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ImageLIME"/> was saved to</param>
        /// <returns>New <see cref="ImageLIME"/> object, loaded from path.</returns>
        public static ImageLIME Load(string path) => WrapAsImageLIME(
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
        /// <returns>an <see cref="JavaMLReader&lt;ImageLIME&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ImageLIME> Read() =>
            new JavaMLReader<ImageLIME>((JvmObjectReference)Reference.Invoke("read"));
        private static ImageLIME WrapAsImageLIME(object obj) =>
            new ImageLIME((JvmObjectReference)obj);
        
    }
}

        