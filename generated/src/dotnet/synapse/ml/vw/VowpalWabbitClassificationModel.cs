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
    /// <see cref="VowpalWabbitClassificationModel"/> implements VowpalWabbitClassificationModel
    /// </summary>
    public class VowpalWabbitClassificationModel : JavaModel<VowpalWabbitClassificationModel>, IJavaMLWritable, IJavaMLReadable<VowpalWabbitClassificationModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitClassificationModel";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitClassificationModel"/> without any parameters.
        /// </summary>
        public VowpalWabbitClassificationModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitClassificationModel"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitClassificationModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitClassificationModel(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitClassificationModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for additionalFeatures
        /// </summary>
        /// <param name="value">
        /// Additional feature columns
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetAdditionalFeatures(string[] value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setAdditionalFeatures", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// features column name
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetFeaturesCol(string value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetLabelCol(string value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// The VW model....
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetModel(object value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for performanceStatistics
        /// </summary>
        /// <param name="value">
        /// Performance statistics collected during training
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetPerformanceStatistics(DataFrame value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setPerformanceStatistics", (object)value));
        
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetPredictionCol(string value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for probabilityCol
        /// </summary>
        /// <param name="value">
        /// Column name for predicted class conditional probabilities. Note: Not all models output well-calibrated probability estimates! These probabilities should be treated as confidences, not precise probabilities
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetProbabilityCol(string value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setProbabilityCol", (object)value));
        
        /// <summary>
        /// Sets value for rawPredictionCol
        /// </summary>
        /// <param name="value">
        /// raw prediction (a.k.a. confidence) column name
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetRawPredictionCol(string value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setRawPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for testArgs
        /// </summary>
        /// <param name="value">
        /// Additional arguments passed to VW at test time
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetTestArgs(string value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setTestArgs", (object)value));
        
        /// <summary>
        /// Sets value for thresholds
        /// </summary>
        /// <param name="value">
        /// Thresholds in multi-class classification to adjust the probability of predicting each class. Array must have length equal to the number of classes, with values > 0 excepting that at most one value may be 0. The class with largest value p/t is predicted, where p is the original probability of that class and t is the class's threshold
        /// </param>
        /// <returns> New VowpalWabbitClassificationModel object </returns>
        public VowpalWabbitClassificationModel SetThresholds(double[] value) =>
            WrapAsVowpalWabbitClassificationModel(Reference.Invoke("setThresholds", (object)value));
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
        /// Gets probabilityCol value
        /// </summary>
        /// <returns>
        /// probabilityCol: Column name for predicted class conditional probabilities. Note: Not all models output well-calibrated probability estimates! These probabilities should be treated as confidences, not precise probabilities
        /// </returns>
        public string GetProbabilityCol() =>
            (string)Reference.Invoke("getProbabilityCol");
        
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
        /// Gets thresholds value
        /// </summary>
        /// <returns>
        /// thresholds: Thresholds in multi-class classification to adjust the probability of predicting each class. Array must have length equal to the number of classes, with values > 0 excepting that at most one value may be 0. The class with largest value p/t is predicted, where p is the original probability of that class and t is the class's threshold
        /// </returns>
        public double[] GetThresholds() =>
            (double[])Reference.Invoke("getThresholds");
        
        /// <summary>
        /// Loads the <see cref="VowpalWabbitClassificationModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitClassificationModel"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitClassificationModel"/> object, loaded from path.</returns>
        public static VowpalWabbitClassificationModel Load(string path) => WrapAsVowpalWabbitClassificationModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitClassificationModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitClassificationModel> Read() =>
            new JavaMLReader<VowpalWabbitClassificationModel>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitClassificationModel WrapAsVowpalWabbitClassificationModel(object obj) =>
            new VowpalWabbitClassificationModel((JvmObjectReference)obj);
        
    }
}

        