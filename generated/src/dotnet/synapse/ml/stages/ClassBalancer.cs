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
using Synapse.ML.Stages;

namespace Synapse.ML.Stages
{
    /// <summary>
    /// <see cref="ClassBalancer"/> implements ClassBalancer
    /// </summary>
    public class ClassBalancer : JavaEstimator<ClassBalancerModel>, IJavaMLWritable, IJavaMLReadable<ClassBalancer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.ClassBalancer";

        /// <summary>
        /// Creates a <see cref="ClassBalancer"/> without any parameters.
        /// </summary>
        public ClassBalancer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ClassBalancer"/> with a UID that is used to give the
        /// <see cref="ClassBalancer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ClassBalancer(string uid) : base(s_className, uid)
        {
        }

        internal ClassBalancer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for broadcastJoin
        /// </summary>
        /// <param name="value">
        /// Whether to broadcast the class to weight mapping to the worker
        /// </param>
        /// <returns> New ClassBalancer object </returns>
        public ClassBalancer SetBroadcastJoin(bool value) =>
            WrapAsClassBalancer(Reference.Invoke("setBroadcastJoin", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ClassBalancer object </returns>
        public ClassBalancer SetInputCol(string value) =>
            WrapAsClassBalancer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ClassBalancer object </returns>
        public ClassBalancer SetOutputCol(string value) =>
            WrapAsClassBalancer(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets broadcastJoin value
        /// </summary>
        /// <returns>
        /// broadcastJoin: Whether to broadcast the class to weight mapping to the worker
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
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="ClassBalancerModel"/></returns>
        override public ClassBalancerModel Fit(DataFrame dataset) =>
            new ClassBalancerModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="ClassBalancer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ClassBalancer"/> was saved to</param>
        /// <returns>New <see cref="ClassBalancer"/> object, loaded from path.</returns>
        public static ClassBalancer Load(string path) => WrapAsClassBalancer(
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
        /// <returns>an <see cref="JavaMLReader&lt;ClassBalancer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ClassBalancer> Read() =>
            new JavaMLReader<ClassBalancer>((JvmObjectReference)Reference.Invoke("read"));
        private static ClassBalancer WrapAsClassBalancer(object obj) =>
            new ClassBalancer((JvmObjectReference)obj);
        
    }
}

        