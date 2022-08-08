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
    /// <see cref="SummarizeData"/> implements SummarizeData
    /// </summary>
    public class SummarizeData : JavaTransformer, IJavaMLWritable, IJavaMLReadable<SummarizeData>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.SummarizeData";

        /// <summary>
        /// Creates a <see cref="SummarizeData"/> without any parameters.
        /// </summary>
        public SummarizeData() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="SummarizeData"/> with a UID that is used to give the
        /// <see cref="SummarizeData"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SummarizeData(string uid) : base(s_className, uid)
        {
        }

        internal SummarizeData(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for basic
        /// </summary>
        /// <param name="value">
        /// Compute basic statistics
        /// </param>
        /// <returns> New SummarizeData object </returns>
        public SummarizeData SetBasic(bool value) =>
            WrapAsSummarizeData(Reference.Invoke("setBasic", (object)value));
        
        /// <summary>
        /// Sets value for counts
        /// </summary>
        /// <param name="value">
        /// Compute count statistics
        /// </param>
        /// <returns> New SummarizeData object </returns>
        public SummarizeData SetCounts(bool value) =>
            WrapAsSummarizeData(Reference.Invoke("setCounts", (object)value));
        
        /// <summary>
        /// Sets value for errorThreshold
        /// </summary>
        /// <param name="value">
        /// Threshold for quantiles - 0 is exact
        /// </param>
        /// <returns> New SummarizeData object </returns>
        public SummarizeData SetErrorThreshold(double value) =>
            WrapAsSummarizeData(Reference.Invoke("setErrorThreshold", (object)value));
        
        /// <summary>
        /// Sets value for percentiles
        /// </summary>
        /// <param name="value">
        /// Compute percentiles
        /// </param>
        /// <returns> New SummarizeData object </returns>
        public SummarizeData SetPercentiles(bool value) =>
            WrapAsSummarizeData(Reference.Invoke("setPercentiles", (object)value));
        
        /// <summary>
        /// Sets value for sample
        /// </summary>
        /// <param name="value">
        /// Compute sample statistics
        /// </param>
        /// <returns> New SummarizeData object </returns>
        public SummarizeData SetSample(bool value) =>
            WrapAsSummarizeData(Reference.Invoke("setSample", (object)value));
        /// <summary>
        /// Gets basic value
        /// </summary>
        /// <returns>
        /// basic: Compute basic statistics
        /// </returns>
        public bool GetBasic() =>
            (bool)Reference.Invoke("getBasic");
        
        /// <summary>
        /// Gets counts value
        /// </summary>
        /// <returns>
        /// counts: Compute count statistics
        /// </returns>
        public bool GetCounts() =>
            (bool)Reference.Invoke("getCounts");
        
        /// <summary>
        /// Gets errorThreshold value
        /// </summary>
        /// <returns>
        /// errorThreshold: Threshold for quantiles - 0 is exact
        /// </returns>
        public double GetErrorThreshold() =>
            (double)Reference.Invoke("getErrorThreshold");
        
        /// <summary>
        /// Gets percentiles value
        /// </summary>
        /// <returns>
        /// percentiles: Compute percentiles
        /// </returns>
        public bool GetPercentiles() =>
            (bool)Reference.Invoke("getPercentiles");
        
        /// <summary>
        /// Gets sample value
        /// </summary>
        /// <returns>
        /// sample: Compute sample statistics
        /// </returns>
        public bool GetSample() =>
            (bool)Reference.Invoke("getSample");
        
        /// <summary>
        /// Loads the <see cref="SummarizeData"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SummarizeData"/> was saved to</param>
        /// <returns>New <see cref="SummarizeData"/> object, loaded from path.</returns>
        public static SummarizeData Load(string path) => WrapAsSummarizeData(
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
        /// <returns>an <see cref="JavaMLReader&lt;SummarizeData&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<SummarizeData> Read() =>
            new JavaMLReader<SummarizeData>((JvmObjectReference)Reference.Invoke("read"));
        private static SummarizeData WrapAsSummarizeData(object obj) =>
            new SummarizeData((JvmObjectReference)obj);
        
    }
}

        