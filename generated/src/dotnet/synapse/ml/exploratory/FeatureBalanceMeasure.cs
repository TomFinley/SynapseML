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
    /// <see cref="FeatureBalanceMeasure"/> implements FeatureBalanceMeasure
    /// </summary>
    public class FeatureBalanceMeasure : JavaTransformer, IJavaMLWritable, IJavaMLReadable<FeatureBalanceMeasure>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.exploratory.FeatureBalanceMeasure";

        /// <summary>
        /// Creates a <see cref="FeatureBalanceMeasure"/> without any parameters.
        /// </summary>
        public FeatureBalanceMeasure() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="FeatureBalanceMeasure"/> with a UID that is used to give the
        /// <see cref="FeatureBalanceMeasure"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public FeatureBalanceMeasure(string uid) : base(s_className, uid)
        {
        }

        internal FeatureBalanceMeasure(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for classACol
        /// </summary>
        /// <param name="value">
        /// Output column name for the first feature value to compare.
        /// </param>
        /// <returns> New FeatureBalanceMeasure object </returns>
        public FeatureBalanceMeasure SetClassACol(string value) =>
            WrapAsFeatureBalanceMeasure(Reference.Invoke("setClassACol", (object)value));
        
        /// <summary>
        /// Sets value for classBCol
        /// </summary>
        /// <param name="value">
        /// Output column name for the second feature value to compare.
        /// </param>
        /// <returns> New FeatureBalanceMeasure object </returns>
        public FeatureBalanceMeasure SetClassBCol(string value) =>
            WrapAsFeatureBalanceMeasure(Reference.Invoke("setClassBCol", (object)value));
        
        /// <summary>
        /// Sets value for featureNameCol
        /// </summary>
        /// <param name="value">
        /// Output column name for feature names.
        /// </param>
        /// <returns> New FeatureBalanceMeasure object </returns>
        public FeatureBalanceMeasure SetFeatureNameCol(string value) =>
            WrapAsFeatureBalanceMeasure(Reference.Invoke("setFeatureNameCol", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New FeatureBalanceMeasure object </returns>
        public FeatureBalanceMeasure SetLabelCol(string value) =>
            WrapAsFeatureBalanceMeasure(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// output column name
        /// </param>
        /// <returns> New FeatureBalanceMeasure object </returns>
        public FeatureBalanceMeasure SetOutputCol(string value) =>
            WrapAsFeatureBalanceMeasure(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for sensitiveCols
        /// </summary>
        /// <param name="value">
        /// Sensitive columns to use.
        /// </param>
        /// <returns> New FeatureBalanceMeasure object </returns>
        public FeatureBalanceMeasure SetSensitiveCols(string[] value) =>
            WrapAsFeatureBalanceMeasure(Reference.Invoke("setSensitiveCols", (object)value));
        
        /// <summary>
        /// Sets value for verbose
        /// </summary>
        /// <param name="value">
        /// Whether to show intermediate measures and calculations, such as Positive Rate.
        /// </param>
        /// <returns> New FeatureBalanceMeasure object </returns>
        public FeatureBalanceMeasure SetVerbose(bool value) =>
            WrapAsFeatureBalanceMeasure(Reference.Invoke("setVerbose", (object)value));
        /// <summary>
        /// Gets classACol value
        /// </summary>
        /// <returns>
        /// classACol: Output column name for the first feature value to compare.
        /// </returns>
        public string GetClassACol() =>
            (string)Reference.Invoke("getClassACol");
        
        /// <summary>
        /// Gets classBCol value
        /// </summary>
        /// <returns>
        /// classBCol: Output column name for the second feature value to compare.
        /// </returns>
        public string GetClassBCol() =>
            (string)Reference.Invoke("getClassBCol");
        
        /// <summary>
        /// Gets featureNameCol value
        /// </summary>
        /// <returns>
        /// featureNameCol: Output column name for feature names.
        /// </returns>
        public string GetFeatureNameCol() =>
            (string)Reference.Invoke("getFeatureNameCol");
        
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: label column name
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
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
        /// Loads the <see cref="FeatureBalanceMeasure"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="FeatureBalanceMeasure"/> was saved to</param>
        /// <returns>New <see cref="FeatureBalanceMeasure"/> object, loaded from path.</returns>
        public static FeatureBalanceMeasure Load(string path) => WrapAsFeatureBalanceMeasure(
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
        /// <returns>an <see cref="JavaMLReader&lt;FeatureBalanceMeasure&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<FeatureBalanceMeasure> Read() =>
            new JavaMLReader<FeatureBalanceMeasure>((JvmObjectReference)Reference.Invoke("read"));
        private static FeatureBalanceMeasure WrapAsFeatureBalanceMeasure(object obj) =>
            new FeatureBalanceMeasure((JvmObjectReference)obj);
        
    }
}

        