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


namespace Synapse.ML.Featurize
{
    /// <summary>
    /// <see cref="CountSelectorModel"/> implements CountSelectorModel
    /// </summary>
    public class CountSelectorModel : JavaModel<CountSelectorModel>, IJavaMLWritable, IJavaMLReadable<CountSelectorModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.featurize.CountSelectorModel";

        /// <summary>
        /// Creates a <see cref="CountSelectorModel"/> without any parameters.
        /// </summary>
        public CountSelectorModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="CountSelectorModel"/> with a UID that is used to give the
        /// <see cref="CountSelectorModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public CountSelectorModel(string uid) : base(s_className, uid)
        {
        }

        internal CountSelectorModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for indices
        /// </summary>
        /// <param name="value">
        /// An array of indices to select features from a vector column. There can be no overlap with names.
        /// </param>
        /// <returns> New CountSelectorModel object </returns>
        public CountSelectorModel SetIndices(int[] value) =>
            WrapAsCountSelectorModel(Reference.Invoke("setIndices", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New CountSelectorModel object </returns>
        public CountSelectorModel SetInputCol(string value) =>
            WrapAsCountSelectorModel(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New CountSelectorModel object </returns>
        public CountSelectorModel SetOutputCol(string value) =>
            WrapAsCountSelectorModel(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets indices value
        /// </summary>
        /// <returns>
        /// indices: An array of indices to select features from a vector column. There can be no overlap with names.
        /// </returns>
        public int[] GetIndices() =>
            (int[])Reference.Invoke("getIndices");
        
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
        /// Loads the <see cref="CountSelectorModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="CountSelectorModel"/> was saved to</param>
        /// <returns>New <see cref="CountSelectorModel"/> object, loaded from path.</returns>
        public static CountSelectorModel Load(string path) => WrapAsCountSelectorModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;CountSelectorModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<CountSelectorModel> Read() =>
            new JavaMLReader<CountSelectorModel>((JvmObjectReference)Reference.Invoke("read"));
        private static CountSelectorModel WrapAsCountSelectorModel(object obj) =>
            new CountSelectorModel((JvmObjectReference)obj);
        
    }
}

        