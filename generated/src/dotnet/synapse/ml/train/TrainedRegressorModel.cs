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
    /// <see cref="TrainedRegressorModel"/> implements TrainedRegressorModel
    /// </summary>
    public class TrainedRegressorModel : JavaModel<TrainedRegressorModel>, IJavaMLWritable, IJavaMLReadable<TrainedRegressorModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.train.TrainedRegressorModel";

        /// <summary>
        /// Creates a <see cref="TrainedRegressorModel"/> without any parameters.
        /// </summary>
        public TrainedRegressorModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TrainedRegressorModel"/> with a UID that is used to give the
        /// <see cref="TrainedRegressorModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TrainedRegressorModel(string uid) : base(s_className, uid)
        {
        }

        internal TrainedRegressorModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// The name of the features column
        /// </param>
        /// <returns> New TrainedRegressorModel object </returns>
        public TrainedRegressorModel SetFeaturesCol(string value) =>
            WrapAsTrainedRegressorModel(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New TrainedRegressorModel object </returns>
        public TrainedRegressorModel SetLabelCol(string value) =>
            WrapAsTrainedRegressorModel(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// model produced by training
        /// </param>
        /// <returns> New TrainedRegressorModel object </returns>
        public TrainedRegressorModel SetModel(JavaTransformer value) =>
            WrapAsTrainedRegressorModel(Reference.Invoke("setModel", (object)value));
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
        /// model: model produced by training
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
        /// Loads the <see cref="TrainedRegressorModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TrainedRegressorModel"/> was saved to</param>
        /// <returns>New <see cref="TrainedRegressorModel"/> object, loaded from path.</returns>
        public static TrainedRegressorModel Load(string path) => WrapAsTrainedRegressorModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;TrainedRegressorModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TrainedRegressorModel> Read() =>
            new JavaMLReader<TrainedRegressorModel>((JvmObjectReference)Reference.Invoke("read"));
        private static TrainedRegressorModel WrapAsTrainedRegressorModel(object obj) =>
            new TrainedRegressorModel((JvmObjectReference)obj);
        
    }
}

        