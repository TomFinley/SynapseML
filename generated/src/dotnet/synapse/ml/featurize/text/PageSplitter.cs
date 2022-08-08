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


namespace Synapse.ML.Featurize.Text
{
    /// <summary>
    /// <see cref="PageSplitter"/> implements PageSplitter
    /// </summary>
    public class PageSplitter : JavaTransformer, IJavaMLWritable, IJavaMLReadable<PageSplitter>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.featurize.text.PageSplitter";

        /// <summary>
        /// Creates a <see cref="PageSplitter"/> without any parameters.
        /// </summary>
        public PageSplitter() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="PageSplitter"/> with a UID that is used to give the
        /// <see cref="PageSplitter"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public PageSplitter(string uid) : base(s_className, uid)
        {
        }

        internal PageSplitter(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for boundaryRegex
        /// </summary>
        /// <param name="value">
        /// how to split into words
        /// </param>
        /// <returns> New PageSplitter object </returns>
        public PageSplitter SetBoundaryRegex(string value) =>
            WrapAsPageSplitter(Reference.Invoke("setBoundaryRegex", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New PageSplitter object </returns>
        public PageSplitter SetInputCol(string value) =>
            WrapAsPageSplitter(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for maximumPageLength
        /// </summary>
        /// <param name="value">
        /// the maximum number of characters to be in a page
        /// </param>
        /// <returns> New PageSplitter object </returns>
        public PageSplitter SetMaximumPageLength(int value) =>
            WrapAsPageSplitter(Reference.Invoke("setMaximumPageLength", (object)value));
        
        /// <summary>
        /// Sets value for minimumPageLength
        /// </summary>
        /// <param name="value">
        /// the the minimum number of characters to have on a page in order to preserve work boundaries
        /// </param>
        /// <returns> New PageSplitter object </returns>
        public PageSplitter SetMinimumPageLength(int value) =>
            WrapAsPageSplitter(Reference.Invoke("setMinimumPageLength", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New PageSplitter object </returns>
        public PageSplitter SetOutputCol(string value) =>
            WrapAsPageSplitter(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets boundaryRegex value
        /// </summary>
        /// <returns>
        /// boundaryRegex: how to split into words
        /// </returns>
        public string GetBoundaryRegex() =>
            (string)Reference.Invoke("getBoundaryRegex");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets maximumPageLength value
        /// </summary>
        /// <returns>
        /// maximumPageLength: the maximum number of characters to be in a page
        /// </returns>
        public int GetMaximumPageLength() =>
            (int)Reference.Invoke("getMaximumPageLength");
        
        /// <summary>
        /// Gets minimumPageLength value
        /// </summary>
        /// <returns>
        /// minimumPageLength: the the minimum number of characters to have on a page in order to preserve work boundaries
        /// </returns>
        public int GetMinimumPageLength() =>
            (int)Reference.Invoke("getMinimumPageLength");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="PageSplitter"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="PageSplitter"/> was saved to</param>
        /// <returns>New <see cref="PageSplitter"/> object, loaded from path.</returns>
        public static PageSplitter Load(string path) => WrapAsPageSplitter(
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
        /// <returns>an <see cref="JavaMLReader&lt;PageSplitter&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<PageSplitter> Read() =>
            new JavaMLReader<PageSplitter>((JvmObjectReference)Reference.Invoke("read"));
        private static PageSplitter WrapAsPageSplitter(object obj) =>
            new PageSplitter((JvmObjectReference)obj);
        
    }
}

        