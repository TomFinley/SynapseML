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


namespace Synapse.ML.Lime
{
    /// <summary>
    /// <see cref="TabularLIMEModel"/> implements TabularLIMEModel
    /// </summary>
    public class TabularLIMEModel : JavaModel<TabularLIMEModel>, IJavaMLWritable, IJavaMLReadable<TabularLIMEModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.lime.TabularLIMEModel";

        /// <summary>
        /// Creates a <see cref="TabularLIMEModel"/> without any parameters.
        /// </summary>
        public TabularLIMEModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TabularLIMEModel"/> with a UID that is used to give the
        /// <see cref="TabularLIMEModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TabularLIMEModel(string uid) : base(s_className, uid)
        {
        }

        internal TabularLIMEModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for columnSTDs
        /// </summary>
        /// <param name="value">
        /// the standard deviations of each of the columns for perturbation
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetColumnSTDs(double[] value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setColumnSTDs", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetInputCol(string value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// Model to try to locally approximate
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetModel(JavaTransformer value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for nSamples
        /// </summary>
        /// <param name="value">
        /// The number of samples to generate
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetNSamples(int value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setNSamples", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetOutputCol(string value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetPredictionCol(string value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for regularization
        /// </summary>
        /// <param name="value">
        /// regularization param for the lasso
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetRegularization(double value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setRegularization", (object)value));
        
        /// <summary>
        /// Sets value for samplingFraction
        /// </summary>
        /// <param name="value">
        /// The fraction of superpixels to keep on
        /// </param>
        /// <returns> New TabularLIMEModel object </returns>
        public TabularLIMEModel SetSamplingFraction(double value) =>
            WrapAsTabularLIMEModel(Reference.Invoke("setSamplingFraction", (object)value));
        /// <summary>
        /// Gets columnSTDs value
        /// </summary>
        /// <returns>
        /// columnSTDs: the standard deviations of each of the columns for perturbation
        /// </returns>
        public double[] GetColumnSTDs() =>
            (double[])Reference.Invoke("getColumnSTDs");
        
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
        
        /// <summary>
        /// Loads the <see cref="TabularLIMEModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TabularLIMEModel"/> was saved to</param>
        /// <returns>New <see cref="TabularLIMEModel"/> object, loaded from path.</returns>
        public static TabularLIMEModel Load(string path) => WrapAsTabularLIMEModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;TabularLIMEModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TabularLIMEModel> Read() =>
            new JavaMLReader<TabularLIMEModel>((JvmObjectReference)Reference.Invoke("read"));
        private static TabularLIMEModel WrapAsTabularLIMEModel(object obj) =>
            new TabularLIMEModel((JvmObjectReference)obj);
        
    }
}

        