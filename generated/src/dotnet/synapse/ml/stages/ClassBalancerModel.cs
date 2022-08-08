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


namespace Synapse.ML.Stages
{
    /// <summary>
    /// <see cref="ClassBalancerModel"/> implements ClassBalancerModel
    /// </summary>
    public class ClassBalancerModel : JavaModel<ClassBalancerModel>, IJavaMLWritable, IJavaMLReadable<ClassBalancerModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.ClassBalancerModel";

        /// <summary>
        /// Creates a <see cref="ClassBalancerModel"/> without any parameters.
        /// </summary>
        public ClassBalancerModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ClassBalancerModel"/> with a UID that is used to give the
        /// <see cref="ClassBalancerModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ClassBalancerModel(string uid) : base(s_className, uid)
        {
        }

        internal ClassBalancerModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for broadcastJoin
        /// </summary>
        /// <param name="value">
        /// whether to broadcast join
        /// </param>
        /// <returns> New ClassBalancerModel object </returns>
        public ClassBalancerModel SetBroadcastJoin(bool value) =>
            WrapAsClassBalancerModel(Reference.Invoke("setBroadcastJoin", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ClassBalancerModel object </returns>
        public ClassBalancerModel SetInputCol(string value) =>
            WrapAsClassBalancerModel(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ClassBalancerModel object </returns>
        public ClassBalancerModel SetOutputCol(string value) =>
            WrapAsClassBalancerModel(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for weights
        /// </summary>
        /// <param name="value">
        /// the dataframe of weights
        /// </param>
        /// <returns> New ClassBalancerModel object </returns>
        public ClassBalancerModel SetWeights(DataFrame value) =>
            WrapAsClassBalancerModel(Reference.Invoke("setWeights", (object)value));
        /// <summary>
        /// Gets broadcastJoin value
        /// </summary>
        /// <returns>
        /// broadcastJoin: whether to broadcast join
        /// </returns>
        public bool GetBroadcastJoin() =>
            (bool)Reference.Invoke("getBroadcastJoin");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets weights value
        /// </summary>
        /// <returns>
        /// weights: the dataframe of weights
        /// </returns>
        public DataFrame GetWeights() =>
            new DataFrame((JvmObjectReference)Reference.Invoke("getWeights"));
        
        /// <summary>
        /// Loads the <see cref="ClassBalancerModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ClassBalancerModel"/> was saved to</param>
        /// <returns>New <see cref="ClassBalancerModel"/> object, loaded from path.</returns>
        public static ClassBalancerModel Load(string path) => WrapAsClassBalancerModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;ClassBalancerModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ClassBalancerModel> Read() =>
            new JavaMLReader<ClassBalancerModel>((JvmObjectReference)Reference.Invoke("read"));
        private static ClassBalancerModel WrapAsClassBalancerModel(object obj) =>
            new ClassBalancerModel((JvmObjectReference)obj);
        
    }
}

        