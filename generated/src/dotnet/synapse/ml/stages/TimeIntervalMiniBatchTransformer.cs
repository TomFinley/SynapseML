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
    /// <see cref="TimeIntervalMiniBatchTransformer"/> implements TimeIntervalMiniBatchTransformer
    /// </summary>
    public class TimeIntervalMiniBatchTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<TimeIntervalMiniBatchTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.TimeIntervalMiniBatchTransformer";

        /// <summary>
        /// Creates a <see cref="TimeIntervalMiniBatchTransformer"/> without any parameters.
        /// </summary>
        public TimeIntervalMiniBatchTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TimeIntervalMiniBatchTransformer"/> with a UID that is used to give the
        /// <see cref="TimeIntervalMiniBatchTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TimeIntervalMiniBatchTransformer(string uid) : base(s_className, uid)
        {
        }

        internal TimeIntervalMiniBatchTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for maxBatchSize
        /// </summary>
        /// <param name="value">
        /// The max size of the buffer
        /// </param>
        /// <returns> New TimeIntervalMiniBatchTransformer object </returns>
        public TimeIntervalMiniBatchTransformer SetMaxBatchSize(int value) =>
            WrapAsTimeIntervalMiniBatchTransformer(Reference.Invoke("setMaxBatchSize", (object)value));
        
        /// <summary>
        /// Sets value for millisToWait
        /// </summary>
        /// <param name="value">
        /// The time to wait before constructing a batch
        /// </param>
        /// <returns> New TimeIntervalMiniBatchTransformer object </returns>
        public TimeIntervalMiniBatchTransformer SetMillisToWait(int value) =>
            WrapAsTimeIntervalMiniBatchTransformer(Reference.Invoke("setMillisToWait", (object)value));
        /// <summary>
        /// Gets maxBatchSize value
        /// </summary>
        /// <returns>
        /// maxBatchSize: The max size of the buffer
        /// </returns>
        public int GetMaxBatchSize() =>
            (int)Reference.Invoke("getMaxBatchSize");
        
        /// <summary>
        /// Gets millisToWait value
        /// </summary>
        /// <returns>
        /// millisToWait: The time to wait before constructing a batch
        /// </returns>
        public int GetMillisToWait() =>
            (int)Reference.Invoke("getMillisToWait");
        
        /// <summary>
        /// Loads the <see cref="TimeIntervalMiniBatchTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TimeIntervalMiniBatchTransformer"/> was saved to</param>
        /// <returns>New <see cref="TimeIntervalMiniBatchTransformer"/> object, loaded from path.</returns>
        public static TimeIntervalMiniBatchTransformer Load(string path) => WrapAsTimeIntervalMiniBatchTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;TimeIntervalMiniBatchTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TimeIntervalMiniBatchTransformer> Read() =>
            new JavaMLReader<TimeIntervalMiniBatchTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static TimeIntervalMiniBatchTransformer WrapAsTimeIntervalMiniBatchTransformer(object obj) =>
            new TimeIntervalMiniBatchTransformer((JvmObjectReference)obj);
        
    }
}

        