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
    /// <see cref="ComputeModelStatistics"/> implements ComputeModelStatistics
    /// </summary>
    public class ComputeModelStatistics : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ComputeModelStatistics>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.train.ComputeModelStatistics";

        /// <summary>
        /// Creates a <see cref="ComputeModelStatistics"/> without any parameters.
        /// </summary>
        public ComputeModelStatistics() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ComputeModelStatistics"/> with a UID that is used to give the
        /// <see cref="ComputeModelStatistics"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ComputeModelStatistics(string uid) : base(s_className, uid)
        {
        }

        internal ComputeModelStatistics(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for evaluationMetric
        /// </summary>
        /// <param name="value">
        /// Metric to evaluate models with
        /// </param>
        /// <returns> New ComputeModelStatistics object </returns>
        public ComputeModelStatistics SetEvaluationMetric(string value) =>
            WrapAsComputeModelStatistics(Reference.Invoke("setEvaluationMetric", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New ComputeModelStatistics object </returns>
        public ComputeModelStatistics SetLabelCol(string value) =>
            WrapAsComputeModelStatistics(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for scoredLabelsCol
        /// </summary>
        /// <param name="value">
        /// Scored labels column name, only required if using SparkML estimators
        /// </param>
        /// <returns> New ComputeModelStatistics object </returns>
        public ComputeModelStatistics SetScoredLabelsCol(string value) =>
            WrapAsComputeModelStatistics(Reference.Invoke("setScoredLabelsCol", (object)value));
        
        /// <summary>
        /// Sets value for scoresCol
        /// </summary>
        /// <param name="value">
        /// Scores or raw prediction column name, only required if using SparkML estimators
        /// </param>
        /// <returns> New ComputeModelStatistics object </returns>
        public ComputeModelStatistics SetScoresCol(string value) =>
            WrapAsComputeModelStatistics(Reference.Invoke("setScoresCol", (object)value));
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
        /// Gets scoresCol value
        /// </summary>
        /// <returns>
        /// scoresCol: Scores or raw prediction column name, only required if using SparkML estimators
        /// </returns>
        public string GetScoresCol() =>
            (string)Reference.Invoke("getScoresCol");
        
        /// <summary>
        /// Loads the <see cref="ComputeModelStatistics"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ComputeModelStatistics"/> was saved to</param>
        /// <returns>New <see cref="ComputeModelStatistics"/> object, loaded from path.</returns>
        public static ComputeModelStatistics Load(string path) => WrapAsComputeModelStatistics(
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
        /// <returns>an <see cref="JavaMLReader&lt;ComputeModelStatistics&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ComputeModelStatistics> Read() =>
            new JavaMLReader<ComputeModelStatistics>((JvmObjectReference)Reference.Invoke("read"));
        private static ComputeModelStatistics WrapAsComputeModelStatistics(object obj) =>
            new ComputeModelStatistics((JvmObjectReference)obj);
        
    }
}

        