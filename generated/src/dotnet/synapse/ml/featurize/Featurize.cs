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
using Microsoft.Spark.ML;

namespace Synapse.ML.Featurize
{
    /// <summary>
    /// <see cref="Featurize"/> implements Featurize
    /// </summary>
    public class Featurize : JavaEstimator<PipelineModel>, IJavaMLWritable, IJavaMLReadable<Featurize>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.featurize.Featurize";

        /// <summary>
        /// Creates a <see cref="Featurize"/> without any parameters.
        /// </summary>
        public Featurize() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Featurize"/> with a UID that is used to give the
        /// <see cref="Featurize"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Featurize(string uid) : base(s_className, uid)
        {
        }

        internal Featurize(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for imputeMissing
        /// </summary>
        /// <param name="value">
        /// Whether to impute missing values
        /// </param>
        /// <returns> New Featurize object </returns>
        public Featurize SetImputeMissing(bool value) =>
            WrapAsFeaturize(Reference.Invoke("setImputeMissing", (object)value));
        
        /// <summary>
        /// Sets value for inputCols
        /// </summary>
        /// <param name="value">
        /// The names of the input columns
        /// </param>
        /// <returns> New Featurize object </returns>
        public Featurize SetInputCols(string[] value) =>
            WrapAsFeaturize(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets value for numFeatures
        /// </summary>
        /// <param name="value">
        /// Number of features to hash string columns to
        /// </param>
        /// <returns> New Featurize object </returns>
        public Featurize SetNumFeatures(int value) =>
            WrapAsFeaturize(Reference.Invoke("setNumFeatures", (object)value));
        
        /// <summary>
        /// Sets value for oneHotEncodeCategoricals
        /// </summary>
        /// <param name="value">
        /// One-hot encode categorical columns
        /// </param>
        /// <returns> New Featurize object </returns>
        public Featurize SetOneHotEncodeCategoricals(bool value) =>
            WrapAsFeaturize(Reference.Invoke("setOneHotEncodeCategoricals", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New Featurize object </returns>
        public Featurize SetOutputCol(string value) =>
            WrapAsFeaturize(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets imputeMissing value
        /// </summary>
        /// <returns>
        /// imputeMissing: Whether to impute missing values
        /// </returns>
        public bool GetImputeMissing() =>
            (bool)Reference.Invoke("getImputeMissing");
        
        /// <summary>
        /// Gets inputCols value
        /// </summary>
        /// <returns>
        /// inputCols: The names of the input columns
        /// </returns>
        public string[] GetInputCols() =>
            (string[])Reference.Invoke("getInputCols");
        
        /// <summary>
        /// Gets numFeatures value
        /// </summary>
        /// <returns>
        /// numFeatures: Number of features to hash string columns to
        /// </returns>
        public int GetNumFeatures() =>
            (int)Reference.Invoke("getNumFeatures");
        
        /// <summary>
        /// Gets oneHotEncodeCategoricals value
        /// </summary>
        /// <returns>
        /// oneHotEncodeCategoricals: One-hot encode categorical columns
        /// </returns>
        public bool GetOneHotEncodeCategoricals() =>
            (bool)Reference.Invoke("getOneHotEncodeCategoricals");
        
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
        /// <returns><see cref="PipelineModel"/></returns>
        override public PipelineModel Fit(DataFrame dataset) =>
            new PipelineModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="Featurize"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Featurize"/> was saved to</param>
        /// <returns>New <see cref="Featurize"/> object, loaded from path.</returns>
        public static Featurize Load(string path) => WrapAsFeaturize(
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
        /// <returns>an <see cref="JavaMLReader&lt;Featurize&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Featurize> Read() =>
            new JavaMLReader<Featurize>((JvmObjectReference)Reference.Invoke("read"));
        private static Featurize WrapAsFeaturize(object obj) =>
            new Featurize((JvmObjectReference)obj);
        
    }
}

        