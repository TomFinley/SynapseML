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
using Synapse.ML.Featurize;

namespace Synapse.ML.Featurize
{
    /// <summary>
    /// <see cref="CountSelector"/> implements CountSelector
    /// </summary>
    public class CountSelector : JavaEstimator<CountSelectorModel>, IJavaMLWritable, IJavaMLReadable<CountSelector>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.featurize.CountSelector";

        /// <summary>
        /// Creates a <see cref="CountSelector"/> without any parameters.
        /// </summary>
        public CountSelector() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="CountSelector"/> with a UID that is used to give the
        /// <see cref="CountSelector"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public CountSelector(string uid) : base(s_className, uid)
        {
        }

        internal CountSelector(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New CountSelector object </returns>
        public CountSelector SetInputCol(string value) =>
            WrapAsCountSelector(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New CountSelector object </returns>
        public CountSelector SetOutputCol(string value) =>
            WrapAsCountSelector(Reference.Invoke("setOutputCol", (object)value));
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
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="CountSelectorModel"/></returns>
        override public CountSelectorModel Fit(DataFrame dataset) =>
            new CountSelectorModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="CountSelector"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="CountSelector"/> was saved to</param>
        /// <returns>New <see cref="CountSelector"/> object, loaded from path.</returns>
        public static CountSelector Load(string path) => WrapAsCountSelector(
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
        /// <returns>an <see cref="JavaMLReader&lt;CountSelector&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<CountSelector> Read() =>
            new JavaMLReader<CountSelector>((JvmObjectReference)Reference.Invoke("read"));
        private static CountSelector WrapAsCountSelector(object obj) =>
            new CountSelector((JvmObjectReference)obj);
        
    }
}

        