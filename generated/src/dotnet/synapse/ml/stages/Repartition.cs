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
    /// <see cref="Repartition"/> implements Repartition
    /// </summary>
    public class Repartition : JavaTransformer, IJavaMLWritable, IJavaMLReadable<Repartition>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.Repartition";

        /// <summary>
        /// Creates a <see cref="Repartition"/> without any parameters.
        /// </summary>
        public Repartition() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Repartition"/> with a UID that is used to give the
        /// <see cref="Repartition"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Repartition(string uid) : base(s_className, uid)
        {
        }

        internal Repartition(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for disable
        /// </summary>
        /// <param name="value">
        /// Whether to disable repartitioning (so that one can turn it off for evaluation)
        /// </param>
        /// <returns> New Repartition object </returns>
        public Repartition SetDisable(bool value) =>
            WrapAsRepartition(Reference.Invoke("setDisable", (object)value));
        
        /// <summary>
        /// Sets value for n
        /// </summary>
        /// <param name="value">
        /// Number of partitions
        /// </param>
        /// <returns> New Repartition object </returns>
        public Repartition SetN(int value) =>
            WrapAsRepartition(Reference.Invoke("setN", (object)value));
        /// <summary>
        /// Gets disable value
        /// </summary>
        /// <returns>
        /// disable: Whether to disable repartitioning (so that one can turn it off for evaluation)
        /// </returns>
        public bool GetDisable() =>
            (bool)Reference.Invoke("getDisable");
        
        /// <summary>
        /// Gets n value
        /// </summary>
        /// <returns>
        /// n: Number of partitions
        /// </returns>
        public int GetN() =>
            (int)Reference.Invoke("getN");
        
        /// <summary>
        /// Loads the <see cref="Repartition"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Repartition"/> was saved to</param>
        /// <returns>New <see cref="Repartition"/> object, loaded from path.</returns>
        public static Repartition Load(string path) => WrapAsRepartition(
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
        /// <returns>an <see cref="JavaMLReader&lt;Repartition&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Repartition> Read() =>
            new JavaMLReader<Repartition>((JvmObjectReference)Reference.Invoke("read"));
        private static Repartition WrapAsRepartition(object obj) =>
            new Repartition((JvmObjectReference)obj);
        
    }
}

        