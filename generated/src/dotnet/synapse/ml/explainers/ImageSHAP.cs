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


namespace Synapse.ML.Explainers
{
    /// <summary>
    /// <see cref="ImageSHAP"/> implements ImageSHAP
    /// </summary>
    public class ImageSHAP : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ImageSHAP>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.explainers.ImageSHAP";

        /// <summary>
        /// Creates a <see cref="ImageSHAP"/> without any parameters.
        /// </summary>
        public ImageSHAP() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ImageSHAP"/> with a UID that is used to give the
        /// <see cref="ImageSHAP"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ImageSHAP(string uid) : base(s_className, uid)
        {
        }

        internal ImageSHAP(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for cellSize
        /// </summary>
        /// <param name="value">
        /// Number that controls the size of the superpixels
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetCellSize(double value) =>
            WrapAsImageSHAP(Reference.Invoke("setCellSize", (object)value));
        
        /// <summary>
        /// Sets value for infWeight
        /// </summary>
        /// <param name="value">
        /// The double value to represent infinite weight. Default: 1E8.
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetInfWeight(double value) =>
            WrapAsImageSHAP(Reference.Invoke("setInfWeight", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// input column name
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetInputCol(string value) =>
            WrapAsImageSHAP(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for metricsCol
        /// </summary>
        /// <param name="value">
        /// Column name for fitting metrics
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetMetricsCol(string value) =>
            WrapAsImageSHAP(Reference.Invoke("setMetricsCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// The model to be interpreted.
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetModel(JavaTransformer value) =>
            WrapAsImageSHAP(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for modifier
        /// </summary>
        /// <param name="value">
        /// Controls the trade-off spatial and color distance
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetModifier(double value) =>
            WrapAsImageSHAP(Reference.Invoke("setModifier", (object)value));
        
        /// <summary>
        /// Sets value for numSamples
        /// </summary>
        /// <param name="value">
        /// Number of samples to generate.
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetNumSamples(int value) =>
            WrapAsImageSHAP(Reference.Invoke("setNumSamples", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// output column name
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetOutputCol(string value) =>
            WrapAsImageSHAP(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for superpixelCol
        /// </summary>
        /// <param name="value">
        /// The column holding the superpixel decompositions
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetSuperpixelCol(string value) =>
            WrapAsImageSHAP(Reference.Invoke("setSuperpixelCol", (object)value));
        
        /// <summary>
        /// Sets value for targetClasses
        /// </summary>
        /// <param name="value">
        /// The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetTargetClasses(int[] value) =>
            WrapAsImageSHAP(Reference.Invoke("setTargetClasses", (object)value));
        
        /// <summary>
        /// Sets value for targetClassesCol
        /// </summary>
        /// <param name="value">
        /// The name of the column that specifies the indices of the classes for multinomial classification models.
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetTargetClassesCol(string value) =>
            WrapAsImageSHAP(Reference.Invoke("setTargetClassesCol", (object)value));
        
        /// <summary>
        /// Sets value for targetCol
        /// </summary>
        /// <param name="value">
        /// The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
        /// </param>
        /// <returns> New ImageSHAP object </returns>
        public ImageSHAP SetTargetCol(string value) =>
            WrapAsImageSHAP(Reference.Invoke("setTargetCol", (object)value));
        /// <summary>
        /// Gets cellSize value
        /// </summary>
        /// <returns>
        /// cellSize: Number that controls the size of the superpixels
        /// </returns>
        public double GetCellSize() =>
            (double)Reference.Invoke("getCellSize");
        
        /// <summary>
        /// Gets infWeight value
        /// </summary>
        /// <returns>
        /// infWeight: The double value to represent infinite weight. Default: 1E8.
        /// </returns>
        public double GetInfWeight() =>
            (double)Reference.Invoke("getInfWeight");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: input column name
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets metricsCol value
        /// </summary>
        /// <returns>
        /// metricsCol: Column name for fitting metrics
        /// </returns>
        public string GetMetricsCol() =>
            (string)Reference.Invoke("getMetricsCol");
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: The model to be interpreted.
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
        /// Gets numSamples value
        /// </summary>
        /// <returns>
        /// numSamples: Number of samples to generate.
        /// </returns>
        public int GetNumSamples() =>
            (int)Reference.Invoke("getNumSamples");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets superpixelCol value
        /// </summary>
        /// <returns>
        /// superpixelCol: The column holding the superpixel decompositions
        /// </returns>
        public string GetSuperpixelCol() =>
            (string)Reference.Invoke("getSuperpixelCol");
        
        /// <summary>
        /// Gets targetClasses value
        /// </summary>
        /// <returns>
        /// targetClasses: The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
        /// </returns>
        public int[] GetTargetClasses() =>
            (int[])Reference.Invoke("getTargetClasses");
        
        /// <summary>
        /// Gets targetClassesCol value
        /// </summary>
        /// <returns>
        /// targetClassesCol: The name of the column that specifies the indices of the classes for multinomial classification models.
        /// </returns>
        public string GetTargetClassesCol() =>
            (string)Reference.Invoke("getTargetClassesCol");
        
        /// <summary>
        /// Gets targetCol value
        /// </summary>
        /// <returns>
        /// targetCol: The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
        /// </returns>
        public string GetTargetCol() =>
            (string)Reference.Invoke("getTargetCol");
        
        /// <summary>
        /// Loads the <see cref="ImageSHAP"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ImageSHAP"/> was saved to</param>
        /// <returns>New <see cref="ImageSHAP"/> object, loaded from path.</returns>
        public static ImageSHAP Load(string path) => WrapAsImageSHAP(
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
        /// <returns>an <see cref="JavaMLReader&lt;ImageSHAP&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ImageSHAP> Read() =>
            new JavaMLReader<ImageSHAP>((JvmObjectReference)Reference.Invoke("read"));
        private static ImageSHAP WrapAsImageSHAP(object obj) =>
            new ImageSHAP((JvmObjectReference)obj);
        
    }
}

        