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
    /// <see cref="AggregateBalanceMeasure"/> implements AggregateBalanceMeasure
    /// </summary>
    public class AggregateBalanceMeasure : JavaTransformer, IJavaMLWritable, IJavaMLReadable<AggregateBalanceMeasure>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.exploratory.AggregateBalanceMeasure";

        /// <summary>
        /// Creates a <see cref="AggregateBalanceMeasure"/> without any parameters.
        /// </summary>
        public AggregateBalanceMeasure() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="AggregateBalanceMeasure"/> with a UID that is used to give the
        /// <see cref="AggregateBalanceMeasure"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public AggregateBalanceMeasure(string uid) : base(s_className, uid)
        {
        }

        internal AggregateBalanceMeasure(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for epsilon
        /// </summary>
        /// <param name="value">
        /// Epsilon value for Atkinson Index. Inverse of alpha (1 - alpha).
        /// </param>
        /// <returns> New AggregateBalanceMeasure object </returns>
        public AggregateBalanceMeasure SetEpsilon(double value) =>
            WrapAsAggregateBalanceMeasure(Reference.Invoke("setEpsilon", (object)value));
        
        /// <summary>
        /// Sets value for errorTolerance
        /// </summary>
        /// <param name="value">
        /// Error tolerance value for Atkinson Index.
        /// </param>
        /// <returns> New AggregateBalanceMeasure object </returns>
        public AggregateBalanceMeasure SetErrorTolerance(double value) =>
            WrapAsAggregateBalanceMeasure(Reference.Invoke("setErrorTolerance", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// output column name
        /// </param>
        /// <returns> New AggregateBalanceMeasure object </returns>
        public AggregateBalanceMeasure SetOutputCol(string value) =>
            WrapAsAggregateBalanceMeasure(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for sensitiveCols
        /// </summary>
        /// <param name="value">
        /// Sensitive columns to use.
        /// </param>
        /// <returns> New AggregateBalanceMeasure object </returns>
        public AggregateBalanceMeasure SetSensitiveCols(string[] value) =>
            WrapAsAggregateBalanceMeasure(Reference.Invoke("setSensitiveCols", (object)value));
        
        /// <summary>
        /// Sets value for verbose
        /// </summary>
        /// <param name="value">
        /// Whether to show intermediate measures and calculations, such as Positive Rate.
        /// </param>
        /// <returns> New AggregateBalanceMeasure object </returns>
        public AggregateBalanceMeasure SetVerbose(bool value) =>
            WrapAsAggregateBalanceMeasure(Reference.Invoke("setVerbose", (object)value));
        /// <summary>
        /// Gets epsilon value
        /// </summary>
        /// <returns>
        /// epsilon: Epsilon value for Atkinson Index. Inverse of alpha (1 - alpha).
        /// </returns>
        public double GetEpsilon() =>
            (double)Reference.Invoke("getEpsilon");
        
        /// <summary>
        /// Gets errorTolerance value
        /// </summary>
        /// <returns>
        /// errorTolerance: Error tolerance value for Atkinson Index.
        /// </returns>
        public double GetErrorTolerance() =>
            (double)Reference.Invoke("getErrorTolerance");
        
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
        /// Loads the <see cref="AggregateBalanceMeasure"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="AggregateBalanceMeasure"/> was saved to</param>
        /// <returns>New <see cref="AggregateBalanceMeasure"/> object, loaded from path.</returns>
        public static AggregateBalanceMeasure Load(string path) => WrapAsAggregateBalanceMeasure(
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
        /// <returns>an <see cref="JavaMLReader&lt;AggregateBalanceMeasure&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<AggregateBalanceMeasure> Read() =>
            new JavaMLReader<AggregateBalanceMeasure>((JvmObjectReference)Reference.Invoke("read"));
        private static AggregateBalanceMeasure WrapAsAggregateBalanceMeasure(object obj) =>
            new AggregateBalanceMeasure((JvmObjectReference)obj);
        
    }
}

        