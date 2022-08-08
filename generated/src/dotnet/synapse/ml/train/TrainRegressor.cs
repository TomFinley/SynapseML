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
using Synapse.ML.Train;

namespace Synapse.ML.Train
{
    /// <summary>
    /// <see cref="TrainRegressor"/> implements TrainRegressor
    /// </summary>
    public class TrainRegressor : JavaEstimator<TrainedRegressorModel>, IJavaMLWritable, IJavaMLReadable<TrainRegressor>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.train.TrainRegressor";

        /// <summary>
        /// Creates a <see cref="TrainRegressor"/> without any parameters.
        /// </summary>
        public TrainRegressor() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TrainRegressor"/> with a UID that is used to give the
        /// <see cref="TrainRegressor"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TrainRegressor(string uid) : base(s_className, uid)
        {
        }

        internal TrainRegressor(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// The name of the features column
        /// </param>
        /// <returns> New TrainRegressor object </returns>
        public TrainRegressor SetFeaturesCol(string value) =>
            WrapAsTrainRegressor(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New TrainRegressor object </returns>
        public TrainRegressor SetLabelCol(string value) =>
            WrapAsTrainRegressor(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// Regressor to run
        /// </param>
        /// <returns> New TrainRegressor object </returns>
        public TrainRegressor SetModel<M>(JavaEstimator<M> value) where M : JavaModel<M> =>
            WrapAsTrainRegressor(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for numFeatures
        /// </summary>
        /// <param name="value">
        /// Number of features to hash to
        /// </param>
        /// <returns> New TrainRegressor object </returns>
        public TrainRegressor SetNumFeatures(int value) =>
            WrapAsTrainRegressor(Reference.Invoke("setNumFeatures", (object)value));
        /// <summary>
        /// Gets featuresCol value
        /// </summary>
        /// <returns>
        /// featuresCol: The name of the features column
        /// </returns>
        public string GetFeaturesCol() =>
            (string)Reference.Invoke("getFeaturesCol");
        
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: The name of the label column
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: Regressor to run
        /// </returns>
        public IEstimator<object> GetModel()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getModel");
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
        /// Gets numFeatures value
        /// </summary>
        /// <returns>
        /// numFeatures: Number of features to hash to
        /// </returns>
        public int GetNumFeatures() =>
            (int)Reference.Invoke("getNumFeatures");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="TrainedRegressorModel"/></returns>
        override public TrainedRegressorModel Fit(DataFrame dataset) =>
            new TrainedRegressorModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="TrainRegressor"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TrainRegressor"/> was saved to</param>
        /// <returns>New <see cref="TrainRegressor"/> object, loaded from path.</returns>
        public static TrainRegressor Load(string path) => WrapAsTrainRegressor(
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
        /// <returns>an <see cref="JavaMLReader&lt;TrainRegressor&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TrainRegressor> Read() =>
            new JavaMLReader<TrainRegressor>((JvmObjectReference)Reference.Invoke("read"));
        private static TrainRegressor WrapAsTrainRegressor(object obj) =>
            new TrainRegressor((JvmObjectReference)obj);
        
    }
}

        