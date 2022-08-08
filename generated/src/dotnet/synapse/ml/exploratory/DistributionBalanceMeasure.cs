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


namespace Synapse.ML.Exploratory
{
    /// <summary>
    /// <see cref="DistributionBalanceMeasure"/> implements DistributionBalanceMeasure
    /// </summary>
    public class DistributionBalanceMeasure : JavaTransformer, IJavaMLWritable, IJavaMLReadable<DistributionBalanceMeasure>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.exploratory.DistributionBalanceMeasure";

        /// <summary>
        /// Creates a <see cref="DistributionBalanceMeasure"/> without any parameters.
        /// </summary>
        public DistributionBalanceMeasure() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="DistributionBalanceMeasure"/> with a UID that is used to give the
        /// <see cref="DistributionBalanceMeasure"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public DistributionBalanceMeasure(string uid) : base(s_className, uid)
        {
        }

        internal DistributionBalanceMeasure(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for featureNameCol
        /// </summary>
        /// <param name="value">
        /// Output column name for feature names.
        /// </param>
        /// <returns> New DistributionBalanceMeasure object </returns>
        public DistributionBalanceMeasure SetFeatureNameCol(string value) =>
            WrapAsDistributionBalanceMeasure(Reference.Invoke("setFeatureNameCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// output column name
        /// </param>
        /// <returns> New DistributionBalanceMeasure object </returns>
        public DistributionBalanceMeasure SetOutputCol(string value) =>
            WrapAsDistributionBalanceMeasure(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for sensitiveCols
        /// </summary>
        /// <param name="value">
        /// Sensitive columns to use.
        /// </param>
        /// <returns> New DistributionBalanceMeasure object </returns>
        public DistributionBalanceMeasure SetSensitiveCols(string[] value) =>
            WrapAsDistributionBalanceMeasure(Reference.Invoke("setSensitiveCols", (object)value));
        
        /// <summary>
        /// Sets value for verbose
        /// </summary>
        /// <param name="value">
        /// Whether to show intermediate measures and calculations, such as Positive Rate.
        /// </param>
        /// <returns> New DistributionBalanceMeasure object </returns>
        public DistributionBalanceMeasure SetVerbose(bool value) =>
            WrapAsDistributionBalanceMeasure(Reference.Invoke("setVerbose", (object)value));
        /// <summary>
        /// Gets featureNameCol value
        /// </summary>
        /// <returns>
        /// featureNameCol: Output column name for feature names.
        /// </returns>
        public string GetFeatureNameCol() =>
            (string)Reference.Invoke("getFeatureNameCol");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets sensitiveCols value
        /// </summary>
        /// <returns>
        /// sensitiveCols: Sensitive columns to use.
        /// </returns>
        public string[] GetSensitiveCols() =>
            (string[])Reference.Invoke("getSensitiveCols");
        
        /// <summary>
        /// Gets verbose value
        /// </summary>
        /// <returns>
        /// verbose: Whether to show intermediate measures and calculations, such as Positive Rate.
        /// </returns>
        public bool GetVerbose() =>
            (bool)Reference.Invoke("getVerbose");
        
        /// <summary>
        /// Loads the <see cref="DistributionBalanceMeasure"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="DistributionBalanceMeasure"/> was saved to</param>
        /// <returns>New <see cref="DistributionBalanceMeasure"/> object, loaded from path.</returns>
        public static DistributionBalanceMeasure Load(string path) => WrapAsDistributionBalanceMeasure(
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
        /// <returns>an <see cref="JavaMLReader&lt;DistributionBalanceMeasure&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<DistributionBalanceMeasure> Read() =>
            new JavaMLReader<DistributionBalanceMeasure>((JvmObjectReference)Reference.Invoke("read"));
        private static DistributionBalanceMeasure WrapAsDistributionBalanceMeasure(object obj) =>
            new DistributionBalanceMeasure((JvmObjectReference)obj);
        
    }
}

        