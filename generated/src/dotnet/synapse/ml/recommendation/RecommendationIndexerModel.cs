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
    /// <see cref="RecommendationIndexerModel"/> implements RecommendationIndexerModel
    /// </summary>
    public class RecommendationIndexerModel : JavaModel<RecommendationIndexerModel>, IJavaMLWritable, IJavaMLReadable<RecommendationIndexerModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.recommendation.RecommendationIndexerModel";

        /// <summary>
        /// Creates a <see cref="RecommendationIndexerModel"/> without any parameters.
        /// </summary>
        public RecommendationIndexerModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="RecommendationIndexerModel"/> with a UID that is used to give the
        /// <see cref="RecommendationIndexerModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public RecommendationIndexerModel(string uid) : base(s_className, uid)
        {
        }

        internal RecommendationIndexerModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for itemIndexModel
        /// </summary>
        /// <param name="value">
        /// itemIndexModel
        /// </param>
        /// <returns> New RecommendationIndexerModel object </returns>
        public RecommendationIndexerModel SetItemIndexModel(JavaTransformer value) =>
            WrapAsRecommendationIndexerModel(Reference.Invoke("setItemIndexModel", (object)value));
        
        
        /// <summary>
        /// Sets value for itemInputCol
        /// </summary>
        /// <param name="value">
        /// Item Input Col
        /// </param>
        /// <returns> New RecommendationIndexerModel object </returns>
        public RecommendationIndexerModel SetItemInputCol(string value) =>
            WrapAsRecommendationIndexerModel(Reference.Invoke("setItemInputCol", (object)value));
        
        /// <summary>
        /// Sets value for itemOutputCol
        /// </summary>
        /// <param name="value">
        /// Item Output Col
        /// </param>
        /// <returns> New RecommendationIndexerModel object </returns>
        public RecommendationIndexerModel SetItemOutputCol(string value) =>
            WrapAsRecommendationIndexerModel(Reference.Invoke("setItemOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for ratingCol
        /// </summary>
        /// <param name="value">
        /// Rating Col
        /// </param>
        /// <returns> New RecommendationIndexerModel object </returns>
        public RecommendationIndexerModel SetRatingCol(string value) =>
            WrapAsRecommendationIndexerModel(Reference.Invoke("setRatingCol", (object)value));
        
        /// <summary>
        /// Sets value for userIndexModel
        /// </summary>
        /// <param name="value">
        /// userIndexModel
        /// </param>
        /// <returns> New RecommendationIndexerModel object </returns>
        public RecommendationIndexerModel SetUserIndexModel(JavaTransformer value) =>
            WrapAsRecommendationIndexerModel(Reference.Invoke("setUserIndexModel", (object)value));
        
        
        /// <summary>
        /// Sets value for userInputCol
        /// </summary>
        /// <param name="value">
        /// User Input Col
        /// </param>
        /// <returns> New RecommendationIndexerModel object </returns>
        public RecommendationIndexerModel SetUserInputCol(string value) =>
            WrapAsRecommendationIndexerModel(Reference.Invoke("setUserInputCol", (object)value));
        
        /// <summary>
        /// Sets value for userOutputCol
        /// </summary>
        /// <param name="value">
        /// User Output Col
        /// </param>
        /// <returns> New RecommendationIndexerModel object </returns>
        public RecommendationIndexerModel SetUserOutputCol(string value) =>
            WrapAsRecommendationIndexerModel(Reference.Invoke("setUserOutputCol", (object)value));
        /// <summary>
        /// Gets itemIndexModel value
        /// </summary>
        /// <returns>
        /// itemIndexModel: itemIndexModel
        /// </returns>
        public JavaTransformer GetItemIndexModel()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getItemIndexModel");
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
        /// Gets itemInputCol value
        /// </summary>
        /// <returns>
        /// itemInputCol: Item Input Col
        /// </returns>
        public string GetItemInputCol() =>
            (string)Reference.Invoke("getItemInputCol");
        
        /// <summary>
        /// Gets itemOutputCol value
        /// </summary>
        /// <returns>
        /// itemOutputCol: Item Output Col
        /// </returns>
        public string GetItemOutputCol() =>
            (string)Reference.Invoke("getItemOutputCol");
        
        /// <summary>
        /// Gets ratingCol value
        /// </summary>
        /// <returns>
        /// ratingCol: Rating Col
        /// </returns>
        public string GetRatingCol() =>
            (string)Reference.Invoke("getRatingCol");
        
        /// <summary>
        /// Gets userIndexModel value
        /// </summary>
        /// <returns>
        /// userIndexModel: userIndexModel
        /// </returns>
        public JavaTransformer GetUserIndexModel()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getUserIndexModel");
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
        /// Gets userInputCol value
        /// </summary>
        /// <returns>
        /// userInputCol: User Input Col
        /// </returns>
        public string GetUserInputCol() =>
            (string)Reference.Invoke("getUserInputCol");
        
        /// <summary>
        /// Gets userOutputCol value
        /// </summary>
        /// <returns>
        /// userOutputCol: User Output Col
        /// </returns>
        public string GetUserOutputCol() =>
            (string)Reference.Invoke("getUserOutputCol");
        
        /// <summary>
        /// Loads the <see cref="RecommendationIndexerModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="RecommendationIndexerModel"/> was saved to</param>
        /// <returns>New <see cref="RecommendationIndexerModel"/> object, loaded from path.</returns>
        public static RecommendationIndexerModel Load(string path) => WrapAsRecommendationIndexerModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;RecommendationIndexerModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<RecommendationIndexerModel> Read() =>
            new JavaMLReader<RecommendationIndexerModel>((JvmObjectReference)Reference.Invoke("read"));
        private static RecommendationIndexerModel WrapAsRecommendationIndexerModel(object obj) =>
            new RecommendationIndexerModel((JvmObjectReference)obj);
        
    }
}

        