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


namespace Synapse.ML.Nn
{
    /// <summary>
    /// <see cref="ConditionalKNNModel"/> implements ConditionalKNNModel
    /// </summary>
    public class ConditionalKNNModel : JavaModel<ConditionalKNNModel>, IJavaMLWritable, IJavaMLReadable<ConditionalKNNModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.nn.ConditionalKNNModel";

        /// <summary>
        /// Creates a <see cref="ConditionalKNNModel"/> without any parameters.
        /// </summary>
        public ConditionalKNNModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ConditionalKNNModel"/> with a UID that is used to give the
        /// <see cref="ConditionalKNNModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ConditionalKNNModel(string uid) : base(s_className, uid)
        {
        }

        internal ConditionalKNNModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for ballTree
        /// </summary>
        /// <param name="value">
        /// the ballTree model used for perfoming queries
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetBallTree(object value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setBallTree", (object)value));
        
        
        /// <summary>
        /// Sets value for conditionerCol
        /// </summary>
        /// <param name="value">
        /// column holding identifiers for features that will be returned when queried
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetConditionerCol(string value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setConditionerCol", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// The name of the features column
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetFeaturesCol(string value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for k
        /// </summary>
        /// <param name="value">
        /// number of matches to return
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetK(int value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setK", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetLabelCol(string value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for leafSize
        /// </summary>
        /// <param name="value">
        /// max size of the leaves of the tree
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetLeafSize(int value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setLeafSize", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetOutputCol(string value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for valuesCol
        /// </summary>
        /// <param name="value">
        /// column holding values for each feature (key) that will be returned when queried
        /// </param>
        /// <returns> New ConditionalKNNModel object </returns>
        public ConditionalKNNModel SetValuesCol(string value) =>
            WrapAsConditionalKNNModel(Reference.Invoke("setValuesCol", (object)value));
        /// <summary>
        /// Gets ballTree value
        /// </summary>
        /// <returns>
        /// ballTree: the ballTree model used for perfoming queries
        /// </returns>
        public object GetBallTree() => Reference.Invoke("getBallTree");
        
        /// <summary>
        /// Gets conditionerCol value
        /// </summary>
        /// <returns>
        /// conditionerCol: column holding identifiers for features that will be returned when queried
        /// </returns>
        public string GetConditionerCol() =>
            (string)Reference.Invoke("getConditionerCol");
        
        /// <summary>
        /// Gets featuresCol value
        /// </summary>
        /// <returns>
        /// featuresCol: The name of the features column
        /// </returns>
        public string GetFeaturesCol() =>
            (string)Reference.Invoke("getFeaturesCol");
        
        /// <summary>
        /// Gets k value
        /// </summary>
        /// <returns>
        /// k: number of matches to return
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
        /// Gets leafSize value
        /// </summary>
        /// <returns>
        /// leafSize: max size of the leaves of the tree
        /// </returns>
        public int GetLeafSize() =>
            (int)Reference.Invoke("getLeafSize");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets valuesCol value
        /// </summary>
        /// <returns>
        /// valuesCol: column holding values for each feature (key) that will be returned when queried
        /// </returns>
        public string GetValuesCol() =>
            (string)Reference.Invoke("getValuesCol");
        
        /// <summary>
        /// Loads the <see cref="ConditionalKNNModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ConditionalKNNModel"/> was saved to</param>
        /// <returns>New <see cref="ConditionalKNNModel"/> object, loaded from path.</returns>
        public static ConditionalKNNModel Load(string path) => WrapAsConditionalKNNModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;ConditionalKNNModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ConditionalKNNModel> Read() =>
            new JavaMLReader<ConditionalKNNModel>((JvmObjectReference)Reference.Invoke("read"));
        private static ConditionalKNNModel WrapAsConditionalKNNModel(object obj) =>
            new ConditionalKNNModel((JvmObjectReference)obj);
        
    }
}

        