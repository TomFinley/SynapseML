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
    /// <see cref="SelectColumns"/> implements SelectColumns
    /// </summary>
    public class SelectColumns : JavaTransformer, IJavaMLWritable, IJavaMLReadable<SelectColumns>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.SelectColumns";

        /// <summary>
        /// Creates a <see cref="SelectColumns"/> without any parameters.
        /// </summary>
        public SelectColumns() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="SelectColumns"/> with a UID that is used to give the
        /// <see cref="SelectColumns"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SelectColumns(string uid) : base(s_className, uid)
        {
        }

        internal SelectColumns(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for cols
        /// </summary>
        /// <param name="value">
        /// Comma separated list of selected column names
        /// </param>
        /// <returns> New SelectColumns object </returns>
        public SelectColumns SetCols(string[] value) =>
            WrapAsSelectColumns(Reference.Invoke("setCols", (object)value));
        /// <summary>
        /// Gets cols value
        /// </summary>
        /// <returns>
        /// cols: Comma separated list of selected column names
        /// </returns>
        public string[] GetCols() =>
            (string[])Reference.Invoke("getCols");
        
        /// <summary>
        /// Loads the <see cref="SelectColumns"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SelectColumns"/> was saved to</param>
        /// <returns>New <see cref="SelectColumns"/> object, loaded from path.</returns>
        public static SelectColumns Load(string path) => WrapAsSelectColumns(
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
        /// <returns>an <see cref="JavaMLReader&lt;SelectColumns&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<SelectColumns> Read() =>
            new JavaMLReader<SelectColumns>((JvmObjectReference)Reference.Invoke("read"));
        private static SelectColumns WrapAsSelectColumns(object obj) =>
            new SelectColumns((JvmObjectReference)obj);
        
    }
}

        