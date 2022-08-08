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
    /// <see cref="FixedMiniBatchTransformer"/> implements FixedMiniBatchTransformer
    /// </summary>
    public class FixedMiniBatchTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<FixedMiniBatchTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.FixedMiniBatchTransformer";

        /// <summary>
        /// Creates a <see cref="FixedMiniBatchTransformer"/> without any parameters.
        /// </summary>
        public FixedMiniBatchTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="FixedMiniBatchTransformer"/> with a UID that is used to give the
        /// <see cref="FixedMiniBatchTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public FixedMiniBatchTransformer(string uid) : base(s_className, uid)
        {
        }

        internal FixedMiniBatchTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for batchSize
        /// </summary>
        /// <param name="value">
        /// The max size of the buffer
        /// </param>
        /// <returns> New FixedMiniBatchTransformer object </returns>
        public FixedMiniBatchTransformer SetBatchSize(int value) =>
            WrapAsFixedMiniBatchTransformer(Reference.Invoke("setBatchSize", (object)value));
        
        /// <summary>
        /// Sets value for buffered
        /// </summary>
        /// <param name="value">
        /// Whether or not to buffer batches in memory
        /// </param>
        /// <returns> New FixedMiniBatchTransformer object </returns>
        public FixedMiniBatchTransformer SetBuffered(bool value) =>
            WrapAsFixedMiniBatchTransformer(Reference.Invoke("setBuffered", (object)value));
        
        /// <summary>
        /// Sets value for maxBufferSize
        /// </summary>
        /// <param name="value">
        /// The max size of the buffer
        /// </param>
        /// <returns> New FixedMiniBatchTransformer object </returns>
        public FixedMiniBatchTransformer SetMaxBufferSize(int value) =>
            WrapAsFixedMiniBatchTransformer(Reference.Invoke("setMaxBufferSize", (object)value));
        /// <summary>
        /// Gets batchSize value
        /// </summary>
        /// <returns>
        /// batchSize: The max size of the buffer
        /// </returns>
        public int GetBatchSize() =>
            (int)Reference.Invoke("getBatchSize");
        
        /// <summary>
        /// Gets buffered value
        /// </summary>
        /// <returns>
        /// buffered: Whether or not to buffer batches in memory
        /// </returns>
        public bool GetBuffered() =>
            (bool)Reference.Invoke("getBuffered");
        
        /// <summary>
        /// Gets maxBufferSize value
        /// </summary>
        /// <returns>
        /// maxBufferSize: The max size of the buffer
        /// </returns>
        public int GetMaxBufferSize() =>
            (int)Reference.Invoke("getMaxBufferSize");
        
        /// <summary>
        /// Loads the <see cref="FixedMiniBatchTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="FixedMiniBatchTransformer"/> was saved to</param>
        /// <returns>New <see cref="FixedMiniBatchTransformer"/> object, loaded from path.</returns>
        public static FixedMiniBatchTransformer Load(string path) => WrapAsFixedMiniBatchTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;FixedMiniBatchTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<FixedMiniBatchTransformer> Read() =>
            new JavaMLReader<FixedMiniBatchTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static FixedMiniBatchTransformer WrapAsFixedMiniBatchTransformer(object obj) =>
            new FixedMiniBatchTransformer((JvmObjectReference)obj);
        
    }
}

        