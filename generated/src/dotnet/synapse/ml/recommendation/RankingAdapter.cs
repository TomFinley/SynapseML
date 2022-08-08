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
using Synapse.ML.Recommendation;

namespace Synapse.ML.Recommendation
{
    /// <summary>
    /// <see cref="RankingAdapter"/> implements RankingAdapter
    /// </summary>
    public class RankingAdapter : JavaEstimator<RankingAdapterModel>, IJavaMLWritable, IJavaMLReadable<RankingAdapter>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.recommendation.RankingAdapter";

        /// <summary>
        /// Creates a <see cref="RankingAdapter"/> without any parameters.
        /// </summary>
        public RankingAdapter() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="RankingAdapter"/> with a UID that is used to give the
        /// <see cref="RankingAdapter"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public RankingAdapter(string uid) : base(s_className, uid)
        {
        }

        internal RankingAdapter(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for itemCol
        /// </summary>
        /// <param name="value">
        /// Column of items
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetItemCol(string value) =>
            WrapAsRankingAdapter(Reference.Invoke("setItemCol", (object)value));
        
        /// <summary>
        /// Sets value for k
        /// </summary>
        /// <param name="value">
        /// number of items
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetK(int value) =>
            WrapAsRankingAdapter(Reference.Invoke("setK", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetLabelCol(string value) =>
            WrapAsRankingAdapter(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for minRatingsPerItem
        /// </summary>
        /// <param name="value">
        /// min ratings for items > 0
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetMinRatingsPerItem(int value) =>
            WrapAsRankingAdapter(Reference.Invoke("setMinRatingsPerItem", (object)value));
        
        /// <summary>
        /// Sets value for minRatingsPerUser
        /// </summary>
        /// <param name="value">
        /// min ratings for users > 0
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetMinRatingsPerUser(int value) =>
            WrapAsRankingAdapter(Reference.Invoke("setMinRatingsPerUser", (object)value));
        
        /// <summary>
        /// Sets value for mode
        /// </summary>
        /// <param name="value">
        /// recommendation mode
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetMode(string value) =>
            WrapAsRankingAdapter(Reference.Invoke("setMode", (object)value));
        
        /// <summary>
        /// Sets value for ratingCol
        /// </summary>
        /// <param name="value">
        /// Column of ratings
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetRatingCol(string value) =>
            WrapAsRankingAdapter(Reference.Invoke("setRatingCol", (object)value));
        
        /// <summary>
        /// Sets value for recommender
        /// </summary>
        /// <param name="value">
        /// estimator for selection
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetRecommender<M>(JavaEstimator<M> value) where M : JavaModel<M> =>
            WrapAsRankingAdapter(Reference.Invoke("setRecommender", (object)value));
        
        
        /// <summary>
        /// Sets value for userCol
        /// </summary>
        /// <param name="value">
        /// Column of users
        /// </param>
        /// <returns> New RankingAdapter object </returns>
        public RankingAdapter SetUserCol(string value) =>
            WrapAsRankingAdapter(Reference.Invoke("setUserCol", (object)value));
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
        /// labelCol: The name of the label column
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets minRatingsPerItem value
        /// </summary>
        /// <returns>
        /// minRatingsPerItem: min ratings for items > 0
        /// </returns>
        public int GetMinRatingsPerItem() =>
            (int)Reference.Invoke("getMinRatingsPerItem");
        
        /// <summary>
        /// Gets minRatingsPerUser value
        /// </summary>
        /// <returns>
        /// minRatingsPerUser: min ratings for users > 0
        /// </returns>
        public int GetMinRatingsPerUser() =>
            (int)Reference.Invoke("getMinRatingsPerUser");
        
        /// <summary>
        /// Gets mode value
        /// </summary>
        /// <returns>
        /// mode: recommendation mode
        /// </returns>
        public string GetMode() =>
            (string)Reference.Invoke("getMode");
        
        /// <summary>
        /// Gets ratingCol value
        /// </summary>
        /// <returns>
        /// ratingCol: Column of ratings
        /// </returns>
        public string GetRatingCol() =>
            (string)Reference.Invoke("getRatingCol");
        
        /// <summary>
        /// Gets recommender value
        /// </summary>
        /// <returns>
        /// recommender: estimator for selection
        /// </returns>
        public IEstimator<object> GetRecommender()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getRecommender");
            Dictionary<string, Type> classMapping = JvmObjectUtils.ConstructJavaClassMapping(
                        typeof(JavaPipelineStage),
                        "s_className");
            JvmObjectUtils.TryConstructInstanceFromJvmObject(
                        jvmObject,
                        classMapping,
                        out IEstimator<object> instance);
            return instance;
        }
        
        
        /// <summary>
        /// Gets userCol value
        /// </summary>
        /// <returns>
        /// userCol: Column of users
        /// </returns>
        public string GetUserCol() =>
            (string)Reference.Invoke("getUserCol");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="RankingAdapterModel"/></returns>
        override public RankingAdapterModel Fit(DataFrame dataset) =>
            new RankingAdapterModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="RankingAdapter"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="RankingAdapter"/> was saved to</param>
        /// <returns>New <see cref="RankingAdapter"/> object, loaded from path.</returns>
        public static RankingAdapter Load(string path) => WrapAsRankingAdapter(
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
        /// <returns>an <see cref="JavaMLReader&lt;RankingAdapter&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<RankingAdapter> Read() =>
            new JavaMLReader<RankingAdapter>((JvmObjectReference)Reference.Invoke("read"));
        private static RankingAdapter WrapAsRankingAdapter(object obj) =>
            new RankingAdapter((JvmObjectReference)obj);
        
    }
}

        