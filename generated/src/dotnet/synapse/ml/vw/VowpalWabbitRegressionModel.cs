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


namespace Synapse.ML.Vw
{
    /// <summary>
    /// <see cref="VowpalWabbitRegressionModel"/> implements VowpalWabbitRegressionModel
    /// </summary>
    public class VowpalWabbitRegressionModel : JavaModel<VowpalWabbitRegressionModel>, IJavaMLWritable, IJavaMLReadable<VowpalWabbitRegressionModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitRegressionModel";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitRegressionModel"/> without any parameters.
        /// </summary>
        public VowpalWabbitRegressionModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitRegressionModel"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitRegressionModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitRegressionModel(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitRegressionModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for additionalFeatures
        /// </summary>
        /// <param name="value">
        /// Additional feature columns
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetAdditionalFeatures(string[] value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setAdditionalFeatures", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// features column name
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetFeaturesCol(string value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetLabelCol(string value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// The VW model....
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetModel(object value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for performanceStatistics
        /// </summary>
        /// <param name="value">
        /// Performance statistics collected during training
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetPerformanceStatistics(DataFrame value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setPerformanceStatistics", (object)value));
        
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetPredictionCol(string value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for rawPredictionCol
        /// </summary>
        /// <param name="value">
        /// raw prediction (a.k.a. confidence) column name
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetRawPredictionCol(string value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setRawPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for testArgs
        /// </summary>
        /// <param name="value">
        /// Additional arguments passed to VW at test time
        /// </param>
        /// <returns> New VowpalWabbitRegressionModel object </returns>
        public VowpalWabbitRegressionModel SetTestArgs(string value) =>
            WrapAsVowpalWabbitRegressionModel(Reference.Invoke("setTestArgs", (object)value));
        /// <summary>
        /// Gets additionalFeatures value
        /// </summary>
        /// <returns>
        /// additionalFeatures: Additional feature columns
        /// </returns>
        public string[] GetAdditionalFeatures() =>
            (string[])Reference.Invoke("getAdditionalFeatures");
        
        /// <summary>
        /// Gets featuresCol value
        /// </summary>
        /// <returns>
        /// featuresCol: features column name
        /// </returns>
        public string GetFeaturesCol() =>
            (string)Reference.Invoke("getFeaturesCol");
        
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: label column name
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: The VW model....
        /// </returns>
        public object GetModel() => Reference.Invoke("getModel");
        
        /// <summary>
        /// Gets performanceStatistics value
        /// </summary>
        /// <returns>
        /// performanceStatistics: Performance statistics collected during training
        /// </returns>
        public DataFrame GetPerformanceStatistics() =>
            new DataFrame((JvmObjectReference)Reference.Invoke("getPerformanceStatistics"));
        
        
        /// <summary>
        /// Gets predictionCol value
        /// </summary>
        /// <returns>
        /// predictionCol: prediction column name
        /// </returns>
        public string GetPredictionCol() =>
            (string)Reference.Invoke("getPredictionCol");
        
        /// <summary>
        /// Gets rawPredictionCol value
        /// </summary>
        /// <returns>
        /// rawPredictionCol: raw prediction (a.k.a. confidence) column name
        /// </returns>
        public string GetRawPredictionCol() =>
            (string)Reference.Invoke("getRawPredictionCol");
        
        /// <summary>
        /// Gets testArgs value
        /// </summary>
        /// <returns>
        /// testArgs: Additional arguments passed to VW at test time
        /// </returns>
        public string GetTestArgs() =>
            (string)Reference.Invoke("getTestArgs");
        
        /// <summary>
        /// Loads the <see cref="VowpalWabbitRegressionModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitRegressionModel"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitRegressionModel"/> object, loaded from path.</returns>
        public static VowpalWabbitRegressionModel Load(string path) => WrapAsVowpalWabbitRegressionModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitRegressionModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitRegressionModel> Read() =>
            new JavaMLReader<VowpalWabbitRegressionModel>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitRegressionModel WrapAsVowpalWabbitRegressionModel(object obj) =>
            new VowpalWabbitRegressionModel((JvmObjectReference)obj);
        
    }
}

        