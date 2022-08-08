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
    /// <see cref="StratifiedRepartition"/> implements StratifiedRepartition
    /// </summary>
    public class StratifiedRepartition : JavaTransformer, IJavaMLWritable, IJavaMLReadable<StratifiedRepartition>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.StratifiedRepartition";

        /// <summary>
        /// Creates a <see cref="StratifiedRepartition"/> without any parameters.
        /// </summary>
        public StratifiedRepartition() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="StratifiedRepartition"/> with a UID that is used to give the
        /// <see cref="StratifiedRepartition"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public StratifiedRepartition(string uid) : base(s_className, uid)
        {
        }

        internal StratifiedRepartition(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// The name of the label column
        /// </param>
        /// <returns> New StratifiedRepartition object </returns>
        public StratifiedRepartition SetLabelCol(string value) =>
            WrapAsStratifiedRepartition(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for mode
        /// </summary>
        /// <param name="value">
        /// Specify equal to repartition with replacement across all labels, specify original to keep the ratios in the original dataset, or specify mixed to use a heuristic
        /// </param>
        /// <returns> New StratifiedRepartition object </returns>
        public StratifiedRepartition SetMode(string value) =>
            WrapAsStratifiedRepartition(Reference.Invoke("setMode", (object)value));
        
        /// <summary>
        /// Sets value for seed
        /// </summary>
        /// <param name="value">
        /// random seed
        /// </param>
        /// <returns> New StratifiedRepartition object </returns>
        public StratifiedRepartition SetSeed(long value) =>
            WrapAsStratifiedRepartition(Reference.Invoke("setSeed", (object)value));
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: The name of the label column
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets mode value
        /// </summary>
        /// <returns>
        /// mode: Specify equal to repartition with replacement across all labels, specify original to keep the ratios in the original dataset, or specify mixed to use a heuristic
        /// </returns>
        public string GetMode() =>
            (string)Reference.Invoke("getMode");
        
        /// <summary>
        /// Gets seed value
        /// </summary>
        /// <returns>
        /// seed: random seed
        /// </returns>
        public long GetSeed() =>
            (long)Reference.Invoke("getSeed");
        
        /// <summary>
        /// Loads the <see cref="StratifiedRepartition"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="StratifiedRepartition"/> was saved to</param>
        /// <returns>New <see cref="StratifiedRepartition"/> object, loaded from path.</returns>
        public static StratifiedRepartition Load(string path) => WrapAsStratifiedRepartition(
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
        /// <returns>an <see cref="JavaMLReader&lt;StratifiedRepartition&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<StratifiedRepartition> Read() =>
            new JavaMLReader<StratifiedRepartition>((JvmObjectReference)Reference.Invoke("read"));
        private static StratifiedRepartition WrapAsStratifiedRepartition(object obj) =>
            new StratifiedRepartition((JvmObjectReference)obj);
        
    }
}

        