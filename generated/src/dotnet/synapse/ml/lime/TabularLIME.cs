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
using Synapse.ML.Lime;

namespace Synapse.ML.Lime
{
    /// <summary>
    /// <see cref="TabularLIME"/> implements TabularLIME
    /// </summary>
    public class TabularLIME : JavaEstimator<TabularLIMEModel>, IJavaMLWritable, IJavaMLReadable<TabularLIME>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.lime.TabularLIME";

        /// <summary>
        /// Creates a <see cref="TabularLIME"/> without any parameters.
        /// </summary>
        public TabularLIME() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TabularLIME"/> with a UID that is used to give the
        /// <see cref="TabularLIME"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TabularLIME(string uid) : base(s_className, uid)
        {
        }

        internal TabularLIME(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New TabularLIME object </returns>
        public TabularLIME SetInputCol(string value) =>
            WrapAsTabularLIME(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// Model to try to locally approximate
        /// </param>
        /// <returns> New TabularLIME object </returns>
        public TabularLIME SetModel(JavaTransformer value) =>
            WrapAsTabularLIME(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for nSamples
        /// </summary>
        /// <param name="value">
        /// The number of samples to generate
        /// </param>
        /// <returns> New TabularLIME object </returns>
        public TabularLIME SetNSamples(int value) =>
            WrapAsTabularLIME(Reference.Invoke("setNSamples", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New TabularLIME object </returns>
        public TabularLIME SetOutputCol(string value) =>
            WrapAsTabularLIME(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New TabularLIME object </returns>
        public TabularLIME SetPredictionCol(string value) =>
            WrapAsTabularLIME(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for regularization
        /// </summary>
        /// <param name="value">
        /// regularization param for the lasso
        /// </param>
        /// <returns> New TabularLIME object </returns>
        public TabularLIME SetRegularization(double value) =>
            WrapAsTabularLIME(Reference.Invoke("setRegularization", (object)value));
        
        /// <summary>
        /// Sets value for samplingFraction
        /// </summary>
        /// <param name="value">
        /// The fraction of superpixels to keep on
        /// </param>
        /// <returns> New TabularLIME object </returns>
        public TabularLIME SetSamplingFraction(double value) =>
            WrapAsTabularLIME(Reference.Invoke("setSamplingFraction", (object)value));
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: Model to try to locally approximate
        /// </returns>
        public JavaTransformer GetModel()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getModel");
            Dictionary<string, Type> classMapping = JvmObjectUtils.ConstructJavaClassMapping(
                        typeof(JavaTransformer),
                        "s_className");
            JvmObjectUtils.TryConstructInstanceFromJvmObject(
                        jvmObject,
                        classMapping,
                        out JavaTransformer instance);
            return instance;
        }
        
        
        /// <summary>
        /// Gets nSamples value
        /// </summary>
        /// <returns>
        /// nSamples: The number of samples to generate
        /// </returns>
        public int GetNSamples() =>
            (int)Reference.Invoke("getNSamples");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets predictionCol value
        /// </summary>
        /// <returns>
        /// predictionCol: prediction column name
        /// </returns>
        public string GetPredictionCol() =>
            (string)Reference.Invoke("getPredictionCol");
        
        /// <summary>
        /// Gets regularization value
        /// </summary>
        /// <returns>
        /// regularization: regularization param for the lasso
        /// </returns>
        public double GetRegularization() =>
            (double)Reference.Invoke("getRegularization");
        
        /// <summary>
        /// Gets samplingFraction value
        /// </summary>
        /// <returns>
        /// samplingFraction: The fraction of superpixels to keep on
        /// </returns>
        public double GetSamplingFraction() =>
            (double)Reference.Invoke("getSamplingFraction");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="TabularLIMEModel"/></returns>
        override public TabularLIMEModel Fit(DataFrame dataset) =>
            new TabularLIMEModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="TabularLIME"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TabularLIME"/> was saved to</param>
        /// <returns>New <see cref="TabularLIME"/> object, loaded from path.</returns>
        public static TabularLIME Load(string path) => WrapAsTabularLIME(
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
        /// <returns>an <see cref="JavaMLReader&lt;TabularLIME&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TabularLIME> Read() =>
            new JavaMLReader<TabularLIME>((JvmObjectReference)Reference.Invoke("read"));
        private static TabularLIME WrapAsTabularLIME(object obj) =>
            new TabularLIME((JvmObjectReference)obj);
        
    }
}

        