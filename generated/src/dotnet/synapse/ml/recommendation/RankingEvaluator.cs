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


namespace Synapse.ML.Recommendation
{
    /// <summary>
    /// <see cref="RankingEvaluator"/> implements RankingEvaluator
    /// </summary>
    public class RankingEvaluator : JavaEvaluator, IJavaMLWritable, IJavaMLReadable<RankingEvaluator>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.recommendation.RankingEvaluator";

        /// <summary>
        /// Creates a <see cref="RankingEvaluator"/> without any parameters.
        /// </summary>
        public RankingEvaluator() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="RankingEvaluator"/> with a UID that is used to give the
        /// <see cref="RankingEvaluator"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public RankingEvaluator(string uid) : base(s_className, uid)
        {
        }

        internal RankingEvaluator(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for itemCol
        /// </summary>
        /// <param name="value">
        /// Column of items
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetItemCol(string value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setItemCol", (object)value));
        
        /// <summary>
        /// Sets value for k
        /// </summary>
        /// <param name="value">
        /// number of items
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetK(int value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setK", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetLabelCol(string value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for metricName
        /// </summary>
        /// <param name="value">
        /// metric name in evaluation (ndcgAt|map|precisionAtk|recallAtK|diversityAtK|maxDiversity|mrr|fcp)
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetMetricName(string value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setMetricName", (object)value));
        
        /// <summary>
        /// Sets value for nItems
        /// </summary>
        /// <param name="value">
        /// number of items
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetNItems(long value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setNItems", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetPredictionCol(string value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for ratingCol
        /// </summary>
        /// <param name="value">
        /// Column of ratings
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetRatingCol(string value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setRatingCol", (object)value));
        
        /// <summary>
        /// Sets value for userCol
        /// </summary>
        /// <param name="value">
        /// Column of users
        /// </param>
        /// <returns> New RankingEvaluator object </returns>
        public RankingEvaluator SetUserCol(string value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setUserCol", (object)value));
        /// <summary>
        /// Gets itemCol value
        /// </summary>
        /// <returns>
        /// itemCol: Column of items
        /// </returns>
        public string GetItemCol() =>
            (string)Reference.Invoke("getItemCol");
        
        /// <summary>
        /// Gets k value
        /// </summary>
        /// <returns>
        /// k: number of items
        /// </returns>
        public int GetK() =>
            (int)Reference.Invoke("getK");
        
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: label column name
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets metricName value
        /// </summary>
        /// <returns>
        /// metricName: metric name in evaluation (ndcgAt|map|precisionAtk|recallAtK|diversityAtK|maxDiversity|mrr|fcp)
        /// </returns>
        public string GetMetricName() =>
            (string)Reference.Invoke("getMetricName");
        
        /// <summary>
        /// Gets nItems value
        /// </summary>
        /// <returns>
        /// nItems: number of items
        /// </returns>
        public long GetNItems() =>
            (long)Reference.Invoke("getNItems");
        
        /// <summary>
        /// Gets predictionCol value
        /// </summary>
        /// <returns>
        /// predictionCol: prediction column name
        /// </returns>
        public string GetPredictionCol() =>
            (string)Reference.Invoke("getPredictionCol");
        
        /// <summary>
        /// Gets ratingCol value
        /// </summary>
        /// <returns>
        /// ratingCol: Column of ratings
        /// </returns>
        public string GetRatingCol() =>
            (string)Reference.Invoke("getRatingCol");
        
        /// <summary>
        /// Gets userCol value
        /// </summary>
        /// <returns>
        /// userCol: Column of users
        /// </returns>
        public string GetUserCol() =>
            (string)Reference.Invoke("getUserCol");
        
        /// <summary>
        /// Loads the <see cref="RankingEvaluator"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="RankingEvaluator"/> was saved to</param>
        /// <returns>New <see cref="RankingEvaluator"/> object, loaded from path.</returns>
        public static RankingEvaluator Load(string path) => WrapAsRankingEvaluator(
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
        /// <returns>an <see cref="JavaMLReader&lt;RankingEvaluator&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<RankingEvaluator> Read() =>
            new JavaMLReader<RankingEvaluator>((JvmObjectReference)Reference.Invoke("read"));
        private static RankingEvaluator WrapAsRankingEvaluator(object obj) =>
            new RankingEvaluator((JvmObjectReference)obj);
        
    }
}

        