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


namespace Synapse.ML.Train
{
    /// <summary>
    /// <see cref="ComputePerInstanceStatistics"/> implements ComputePerInstanceStatistics
    /// </summary>
    public class ComputePerInstanceStatistics : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ComputePerInstanceStatistics>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.train.ComputePerInstanceStatistics";

        /// <summary>
        /// Creates a <see cref="ComputePerInstanceStatistics"/> without any parameters.
        /// </summary>
        public ComputePerInstanceStatistics() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ComputePerInstanceStatistics"/> with a UID that is used to give the
        /// <see cref="ComputePerInstanceStatistics"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ComputePerInstanceStatistics(string uid) : base(s_className, uid)
        {
        }

        internal ComputePerInstanceStatistics(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for evaluationMetric
        /// </summary>
        /// <param name="value">
        /// Metric to evaluate models with
        /// </param>
        /// <returns> New ComputePerInstanceStatistics object </returns>
        public ComputePerInstanceStatistics SetEvaluationMetric(string value) =>
            WrapAsComputePerInstanceStatistics(Reference.Invoke("setEvaluationMetric", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New ComputePerInstanceStatistics object </returns>
        public ComputePerInstanceStatistics SetLabelCol(string value) =>
            WrapAsComputePerInstanceStatistics(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for scoredLabelsCol
        /// </summary>
        /// <param name="value">
        /// Scored labels column name, only required if using SparkML estimators
        /// </param>
        /// <returns> New ComputePerInstanceStatistics object </returns>
        public ComputePerInstanceStatistics SetScoredLabelsCol(string value) =>
            WrapAsComputePerInstanceStatistics(Reference.Invoke("setScoredLabelsCol", (object)value));
        
        /// <summary>
        /// Sets value for scoredProbabilitiesCol
        /// </summary>
        /// <param name="value">
        /// Scored probabilities, usually calibrated from raw scores, only required if using SparkML estimators
        /// </param>
        /// <returns> New ComputePerInstanceStatistics object </returns>
        public ComputePerInstanceStatistics SetScoredProbabilitiesCol(string value) =>
            WrapAsComputePerInstanceStatistics(Reference.Invoke("setScoredProbabilitiesCol", (object)value));
        
        /// <summary>
        /// Sets value for scoresCol
        /// </summary>
        /// <param name="value">
        /// Scores or raw prediction column name, only required if using SparkML estimators
        /// </param>
        /// <returns> New ComputePerInstanceStatistics object </returns>
        public ComputePerInstanceStatistics SetScoresCol(string value) =>
            WrapAsComputePerInstanceStatistics(Reference.Invoke("setScoresCol", (object)value));
        /// <summary>
        /// Gets evaluationMetric value
        /// </summary>
        /// <returns>
        /// evaluationMetric: Metric to evaluate models with
        /// </returns>
        public string GetEvaluationMetric() =>
            (string)Reference.Invoke("getEvaluationMetric");
        
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: The name of the label column
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets scoredLabelsCol value
        /// </summary>
        /// <returns>
        /// scoredLabelsCol: Scored labels column name, only required if using SparkML estimators
        /// </returns>
        public string GetScoredLabelsCol() =>
            (string)Reference.Invoke("getScoredLabelsCol");
        
        /// <summary>
        /// Gets scoredProbabilitiesCol value
        /// </summary>
        /// <returns>
        /// scoredProbabilitiesCol: Scored probabilities, usually calibrated from raw scores, only required if using SparkML estimators
        /// </returns>
        public string GetScoredProbabilitiesCol() =>
            (string)Reference.Invoke("getScoredProbabilitiesCol");
        
        /// <summary>
        /// Gets scoresCol value
        /// </summary>
        /// <returns>
        /// scoresCol: Scores or raw prediction column name, only required if using SparkML estimators
        /// </returns>
        public string GetScoresCol() =>
            (string)Reference.Invoke("getScoresCol");
        
        /// <summary>
        /// Loads the <see cref="ComputePerInstanceStatistics"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ComputePerInstanceStatistics"/> was saved to</param>
        /// <returns>New <see cref="ComputePerInstanceStatistics"/> object, loaded from path.</returns>
        public static ComputePerInstanceStatistics Load(string path) => WrapAsComputePerInstanceStatistics(
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
        /// <returns>an <see cref="JavaMLReader&lt;ComputePerInstanceStatistics&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ComputePerInstanceStatistics> Read() =>
            new JavaMLReader<ComputePerInstanceStatistics>((JvmObjectReference)Reference.Invoke("read"));
        private static ComputePerInstanceStatistics WrapAsComputePerInstanceStatistics(object obj) =>
            new ComputePerInstanceStatistics((JvmObjectReference)obj);
        
    }
}

        