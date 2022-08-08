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


namespace Synapse.ML.Explainers
{
    /// <summary>
    /// <see cref="TextSHAP"/> implements TextSHAP
    /// </summary>
    public class TextSHAP : JavaTransformer, IJavaMLWritable, IJavaMLReadable<TextSHAP>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.explainers.TextSHAP";

        /// <summary>
        /// Creates a <see cref="TextSHAP"/> without any parameters.
        /// </summary>
        public TextSHAP() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TextSHAP"/> with a UID that is used to give the
        /// <see cref="TextSHAP"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TextSHAP(string uid) : base(s_className, uid)
        {
        }

        internal TextSHAP(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for infWeight
        /// </summary>
        /// <param name="value">
        /// The double value to represent infinite weight. Default: 1E8.
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetInfWeight(double value) =>
            WrapAsTextSHAP(Reference.Invoke("setInfWeight", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// input column name
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetInputCol(string value) =>
            WrapAsTextSHAP(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for metricsCol
        /// </summary>
        /// <param name="value">
        /// Column name for fitting metrics
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetMetricsCol(string value) =>
            WrapAsTextSHAP(Reference.Invoke("setMetricsCol", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// The model to be interpreted.
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetModel(JavaTransformer value) =>
            WrapAsTextSHAP(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for numSamples
        /// </summary>
        /// <param name="value">
        /// Number of samples to generate.
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetNumSamples(int value) =>
            WrapAsTextSHAP(Reference.Invoke("setNumSamples", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// output column name
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetOutputCol(string value) =>
            WrapAsTextSHAP(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for targetClasses
        /// </summary>
        /// <param name="value">
        /// The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetTargetClasses(int[] value) =>
            WrapAsTextSHAP(Reference.Invoke("setTargetClasses", (object)value));
        
        /// <summary>
        /// Sets value for targetClassesCol
        /// </summary>
        /// <param name="value">
        /// The name of the column that specifies the indices of the classes for multinomial classification models.
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetTargetClassesCol(string value) =>
            WrapAsTextSHAP(Reference.Invoke("setTargetClassesCol", (object)value));
        
        /// <summary>
        /// Sets value for targetCol
        /// </summary>
        /// <param name="value">
        /// The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetTargetCol(string value) =>
            WrapAsTextSHAP(Reference.Invoke("setTargetCol", (object)value));
        
        /// <summary>
        /// Sets value for tokensCol
        /// </summary>
        /// <param name="value">
        /// The column holding the tokens
        /// </param>
        /// <returns> New TextSHAP object </returns>
        public TextSHAP SetTokensCol(string value) =>
            WrapAsTextSHAP(Reference.Invoke("setTokensCol", (object)value));
        /// <summary>
        /// Gets infWeight value
        /// </summary>
        /// <returns>
        /// infWeight: The double value to represent infinite weight. Default: 1E8.
        /// </returns>
        public double GetInfWeight() =>
            (double)Reference.Invoke("getInfWeight");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: input column name
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets metricsCol value
        /// </summary>
        /// <returns>
        /// metricsCol: Column name for fitting metrics
        /// </returns>
        public string GetMetricsCol() =>
            (string)Reference.Invoke("getMetricsCol");
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: The model to be interpreted.
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
        /// Gets numSamples value
        /// </summary>
        /// <returns>
        /// numSamples: Number of samples to generate.
        /// </returns>
        public int GetNumSamples() =>
            (int)Reference.Invoke("getNumSamples");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets targetClasses value
        /// </summary>
        /// <returns>
        /// targetClasses: The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
        /// </returns>
        public int[] GetTargetClasses() =>
            (int[])Reference.Invoke("getTargetClasses");
        
        /// <summary>
        /// Gets targetClassesCol value
        /// </summary>
        /// <returns>
        /// targetClassesCol: The name of the column that specifies the indices of the classes for multinomial classification models.
        /// </returns>
        public string GetTargetClassesCol() =>
            (string)Reference.Invoke("getTargetClassesCol");
        
        /// <summary>
        /// Gets targetCol value
        /// </summary>
        /// <returns>
        /// targetCol: The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
        /// </returns>
        public string GetTargetCol() =>
            (string)Reference.Invoke("getTargetCol");
        
        /// <summary>
        /// Gets tokensCol value
        /// </summary>
        /// <returns>
        /// tokensCol: The column holding the tokens
        /// </returns>
        public string GetTokensCol() =>
            (string)Reference.Invoke("getTokensCol");
        
        /// <summary>
        /// Loads the <see cref="TextSHAP"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TextSHAP"/> was saved to</param>
        /// <returns>New <see cref="TextSHAP"/> object, loaded from path.</returns>
        public static TextSHAP Load(string path) => WrapAsTextSHAP(
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
        /// <returns>an <see cref="JavaMLReader&lt;TextSHAP&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TextSHAP> Read() =>
            new JavaMLReader<TextSHAP>((JvmObjectReference)Reference.Invoke("read"));
        private static TextSHAP WrapAsTextSHAP(object obj) =>
            new TextSHAP((JvmObjectReference)obj);
        
    }
}

        