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
    /// <see cref="Cacher"/> implements Cacher
    /// </summary>
    public class Cacher : JavaTransformer, IJavaMLWritable, IJavaMLReadable<Cacher>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.Cacher";

        /// <summary>
        /// Creates a <see cref="Cacher"/> without any parameters.
        /// </summary>
        public Cacher() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Cacher"/> with a UID that is used to give the
        /// <see cref="Cacher"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Cacher(string uid) : base(s_className, uid)
        {
        }

        internal Cacher(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for disable
        /// </summary>
        /// <param name="value">
        /// Whether or disable caching (so that you can turn it off during evaluation)
        /// </param>
        /// <returns> New Cacher object </returns>
        public Cacher SetDisable(bool value) =>
            WrapAsCacher(Reference.Invoke("setDisable", (object)value));
        /// <summary>
        /// Gets disable value
        /// </summary>
        /// <returns>
        /// disable: Whether or disable caching (so that you can turn it off during evaluation)
        /// </returns>
        public bool GetDisable() =>
            (bool)Reference.Invoke("getDisable");
        
        /// <summary>
        /// Loads the <see cref="Cacher"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Cacher"/> was saved to</param>
        /// <returns>New <see cref="Cacher"/> object, loaded from path.</returns>
        public static Cacher Load(string path) => WrapAsCacher(
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
        /// <returns>an <see cref="JavaMLReader&lt;Cacher&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Cacher> Read() =>
            new JavaMLReader<Cacher>((JvmObjectReference)Reference.Invoke("read"));
        private static Cacher WrapAsCacher(object obj) =>
            new Cacher((JvmObjectReference)obj);
        
    }
}

        