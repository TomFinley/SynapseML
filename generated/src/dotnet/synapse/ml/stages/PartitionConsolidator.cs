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
    /// <see cref="PartitionConsolidator"/> implements PartitionConsolidator
    /// </summary>
    public class PartitionConsolidator : JavaTransformer, IJavaMLWritable, IJavaMLReadable<PartitionConsolidator>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.PartitionConsolidator";

        /// <summary>
        /// Creates a <see cref="PartitionConsolidator"/> without any parameters.
        /// </summary>
        public PartitionConsolidator() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="PartitionConsolidator"/> with a UID that is used to give the
        /// <see cref="PartitionConsolidator"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public PartitionConsolidator(string uid) : base(s_className, uid)
        {
        }

        internal PartitionConsolidator(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New PartitionConsolidator object </returns>
        public PartitionConsolidator SetConcurrency(int value) =>
            WrapAsPartitionConsolidator(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New PartitionConsolidator object </returns>
        public PartitionConsolidator SetConcurrentTimeout(double value) =>
            WrapAsPartitionConsolidator(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New PartitionConsolidator object </returns>
        public PartitionConsolidator SetInputCol(string value) =>
            WrapAsPartitionConsolidator(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New PartitionConsolidator object </returns>
        public PartitionConsolidator SetOutputCol(string value) =>
            WrapAsPartitionConsolidator(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New PartitionConsolidator object </returns>
        public PartitionConsolidator SetTimeout(double value) =>
            WrapAsPartitionConsolidator(Reference.Invoke("setTimeout", (object)value));
        /// <summary>
        /// Gets concurrency value
        /// </summary>
        /// <returns>
        /// concurrency: max number of concurrent calls
        /// </returns>
        public int GetConcurrency() =>
            (int)Reference.Invoke("getConcurrency");
        
        /// <summary>
        /// Gets concurrentTimeout value
        /// </summary>
        /// <returns>
        /// concurrentTimeout: max number seconds to wait on futures if concurrency >= 1
        /// </returns>
        public double GetConcurrentTimeout() =>
            (double)Reference.Invoke("getConcurrentTimeout");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: number of seconds to wait before closing the connection
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Loads the <see cref="PartitionConsolidator"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="PartitionConsolidator"/> was saved to</param>
        /// <returns>New <see cref="PartitionConsolidator"/> object, loaded from path.</returns>
        public static PartitionConsolidator Load(string path) => WrapAsPartitionConsolidator(
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
        /// <returns>an <see cref="JavaMLReader&lt;PartitionConsolidator&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<PartitionConsolidator> Read() =>
            new JavaMLReader<PartitionConsolidator>((JvmObjectReference)Reference.Invoke("read"));
        private static PartitionConsolidator WrapAsPartitionConsolidator(object obj) =>
            new PartitionConsolidator((JvmObjectReference)obj);
        
    }
}

        