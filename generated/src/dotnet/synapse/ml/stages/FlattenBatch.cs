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
    /// <see cref="FlattenBatch"/> implements FlattenBatch
    /// </summary>
    public class FlattenBatch : JavaTransformer, IJavaMLWritable, IJavaMLReadable<FlattenBatch>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.FlattenBatch";

        /// <summary>
        /// Creates a <see cref="FlattenBatch"/> without any parameters.
        /// </summary>
        public FlattenBatch() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="FlattenBatch"/> with a UID that is used to give the
        /// <see cref="FlattenBatch"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public FlattenBatch(string uid) : base(s_className, uid)
        {
        }

        internal FlattenBatch(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        
        
        
        /// <summary>
        /// Loads the <see cref="FlattenBatch"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="FlattenBatch"/> was saved to</param>
        /// <returns>New <see cref="FlattenBatch"/> object, loaded from path.</returns>
        public static FlattenBatch Load(string path) => WrapAsFlattenBatch(
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
        /// <returns>an <see cref="JavaMLReader&lt;FlattenBatch&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<FlattenBatch> Read() =>
            new JavaMLReader<FlattenBatch>((JvmObjectReference)Reference.Invoke("read"));
        private static FlattenBatch WrapAsFlattenBatch(object obj) =>
            new FlattenBatch((JvmObjectReference)obj);
        
    }
}

        