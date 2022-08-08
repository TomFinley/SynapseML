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
    /// <see cref="TrainedClassifierModel"/> implements TrainedClassifierModel
    /// </summary>
    public class TrainedClassifierModel : JavaModel<TrainedClassifierModel>, IJavaMLWritable, IJavaMLReadable<TrainedClassifierModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.train.TrainedClassifierModel";

        /// <summary>
        /// Creates a <see cref="TrainedClassifierModel"/> without any parameters.
        /// </summary>
        public TrainedClassifierModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TrainedClassifierModel"/> with a UID that is used to give the
        /// <see cref="TrainedClassifierModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TrainedClassifierModel(string uid) : base(s_className, uid)
        {
        }

        internal TrainedClassifierModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// The name of the features column
        /// </param>
        /// <returns> New TrainedClassifierModel object </returns>
        public TrainedClassifierModel SetFeaturesCol(string value) =>
            WrapAsTrainedClassifierModel(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New TrainedClassifierModel object </returns>
        public TrainedClassifierModel SetLabelCol(string value) =>
            WrapAsTrainedClassifierModel(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for levels
        /// </summary>
        /// <param name="value">
        /// the levels
        /// </param>
        /// <returns> New TrainedClassifierModel object </returns>
        public TrainedClassifierModel SetLevels(object[] value)
            => WrapAsTrainedClassifierModel(Reference.Invoke("setLevels", (object)value.ToJavaArrayList()));
        
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// model produced by training
        /// </param>
        /// <returns> New TrainedClassifierModel object </returns>
        public TrainedClassifierModel SetModel(JavaTransformer value) =>
            WrapAsTrainedClassifierModel(Reference.Invoke("setModel", (object)value));
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
        /// Gets levels value
        /// </summary>
        /// <returns>
        /// levels: the levels
        /// </returns>
        public object[] GetLevels()
        {
            var jvmObjects = (JvmObjectReference[])Reference.Invoke("getLevels");
            var result = new object[jvmObjects.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                    "org.apache.spark.api.dotnet.DotnetUtils", "mapScalaToJava", (object)jvmObjects[i]);
            }
            return result;
        }
        
        
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
        /// Loads the <see cref="TrainedClassifierModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TrainedClassifierModel"/> was saved to</param>
        /// <returns>New <see cref="TrainedClassifierModel"/> object, loaded from path.</returns>
        public static TrainedClassifierModel Load(string path) => WrapAsTrainedClassifierModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;TrainedClassifierModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TrainedClassifierModel> Read() =>
            new JavaMLReader<TrainedClassifierModel>((JvmObjectReference)Reference.Invoke("read"));
        private static TrainedClassifierModel WrapAsTrainedClassifierModel(object obj) =>
            new TrainedClassifierModel((JvmObjectReference)obj);
        
    }
}

        