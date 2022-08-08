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
    /// <see cref="KNNModel"/> implements KNNModel
    /// </summary>
    public class KNNModel : JavaModel<KNNModel>, IJavaMLWritable, IJavaMLReadable<KNNModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.nn.KNNModel";

        /// <summary>
        /// Creates a <see cref="KNNModel"/> without any parameters.
        /// </summary>
        public KNNModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="KNNModel"/> with a UID that is used to give the
        /// <see cref="KNNModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public KNNModel(string uid) : base(s_className, uid)
        {
        }

        internal KNNModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for ballTree
        /// </summary>
        /// <param name="value">
        /// the ballTree model used for performing queries
        /// </param>
        /// <returns> New KNNModel object </returns>
        public KNNModel SetBallTree(object value) =>
            WrapAsKNNModel(Reference.Invoke("setBallTree", (object)value));
        
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// The name of the features column
        /// </param>
        /// <returns> New KNNModel object </returns>
        public KNNModel SetFeaturesCol(string value) =>
            WrapAsKNNModel(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for k
        /// </summary>
        /// <param name="value">
        /// number of matches to return
        /// </param>
        /// <returns> New KNNModel object </returns>
        public KNNModel SetK(int value) =>
            WrapAsKNNModel(Reference.Invoke("setK", (object)value));
        
        /// <summary>
        /// Sets value for leafSize
        /// </summary>
        /// <param name="value">
        /// max size of the leaves of the tree
        /// </param>
        /// <returns> New KNNModel object </returns>
        public KNNModel SetLeafSize(int value) =>
            WrapAsKNNModel(Reference.Invoke("setLeafSize", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New KNNModel object </returns>
        public KNNModel SetOutputCol(string value) =>
            WrapAsKNNModel(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for valuesCol
        /// </summary>
        /// <param name="value">
        /// column holding values for each feature (key) that will be returned when queried
        /// </param>
        /// <returns> New KNNModel object </returns>
        public KNNModel SetValuesCol(string value) =>
            WrapAsKNNModel(Reference.Invoke("setValuesCol", (object)value));
        /// <summary>
        /// Gets ballTree value
        /// </summary>
        /// <returns>
        /// ballTree: the ballTree model used for performing queries
        /// </returns>
        public object GetBallTree() => Reference.Invoke("getBallTree");
        
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
        /// Loads the <see cref="KNNModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="KNNModel"/> was saved to</param>
        /// <returns>New <see cref="KNNModel"/> object, loaded from path.</returns>
        public static KNNModel Load(string path) => WrapAsKNNModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;KNNModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<KNNModel> Read() =>
            new JavaMLReader<KNNModel>((JvmObjectReference)Reference.Invoke("read"));
        private static KNNModel WrapAsKNNModel(object obj) =>
            new KNNModel((JvmObjectReference)obj);
        
    }
}

        