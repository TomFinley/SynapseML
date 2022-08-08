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
using Synapse.ML.Vw;

namespace Synapse.ML.Vw
{
    /// <summary>
    /// <see cref="VowpalWabbitRegressor"/> implements VowpalWabbitRegressor
    /// </summary>
    public class VowpalWabbitRegressor : JavaEstimator<VowpalWabbitRegressionModel>, IJavaMLWritable, IJavaMLReadable<VowpalWabbitRegressor>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitRegressor";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitRegressor"/> without any parameters.
        /// </summary>
        public VowpalWabbitRegressor() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitRegressor"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitRegressor"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitRegressor(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitRegressor(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for additionalFeatures
        /// </summary>
        /// <param name="value">
        /// Additional feature columns
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetAdditionalFeatures(string[] value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setAdditionalFeatures", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// features column name
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetFeaturesCol(string value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for hashSeed
        /// </summary>
        /// <param name="value">
        /// Seed used for hashing
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetHashSeed(int value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setHashSeed", (object)value));
        
        /// <summary>
        /// Sets value for ignoreNamespaces
        /// </summary>
        /// <param name="value">
        /// Namespaces to be ignored (first letter only)
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetIgnoreNamespaces(string value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setIgnoreNamespaces", (object)value));
        
        /// <summary>
        /// Sets value for initialModel
        /// </summary>
        /// <param name="value">
        /// Initial model to start from
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetInitialModel(object value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setInitialModel", (object)value));
        
        
        /// <summary>
        /// Sets value for interactions
        /// </summary>
        /// <param name="value">
        /// Interaction terms as specified by -q
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetInteractions(string[] value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setInteractions", (object)value));
        
        /// <summary>
        /// Sets value for l1
        /// </summary>
        /// <param name="value">
        /// l_1 lambda
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetL1(double value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setL1", (object)value));
        
        /// <summary>
        /// Sets value for l2
        /// </summary>
        /// <param name="value">
        /// l_2 lambda
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetL2(double value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setL2", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetLabelCol(string value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for learningRate
        /// </summary>
        /// <param name="value">
        /// Learning rate
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetLearningRate(double value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setLearningRate", (object)value));
        
        /// <summary>
        /// Sets value for numBits
        /// </summary>
        /// <param name="value">
        /// Number of bits used
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetNumBits(int value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setNumBits", (object)value));
        
        /// <summary>
        /// Sets value for numPasses
        /// </summary>
        /// <param name="value">
        /// Number of passes over the data
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetNumPasses(int value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setNumPasses", (object)value));
        
        /// <summary>
        /// Sets value for passThroughArgs
        /// </summary>
        /// <param name="value">
        /// VW command line arguments passed
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetPassThroughArgs(string value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setPassThroughArgs", (object)value));
        
        /// <summary>
        /// Sets value for powerT
        /// </summary>
        /// <param name="value">
        /// t power value
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetPowerT(double value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setPowerT", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetPredictionCol(string value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for useBarrierExecutionMode
        /// </summary>
        /// <param name="value">
        /// Use barrier execution mode, on by default.
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetUseBarrierExecutionMode(bool value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setUseBarrierExecutionMode", (object)value));
        
        /// <summary>
        /// Sets value for weightCol
        /// </summary>
        /// <param name="value">
        /// The name of the weight column
        /// </param>
        /// <returns> New VowpalWabbitRegressor object </returns>
        public VowpalWabbitRegressor SetWeightCol(string value) =>
            WrapAsVowpalWabbitRegressor(Reference.Invoke("setWeightCol", (object)value));
        /// <summary>
        /// Gets additionalFeatures value
        /// </summary>
        /// <returns>
        /// additionalFeatures: Additional feature columns
        /// </returns>
        public string[] GetAdditionalFeatures() =>
            (string[])Reference.Invoke("getAdditionalFeatures");
        
        /// <summary>
        /// Gets featuresCol value
        /// </summary>
        /// <returns>
        /// featuresCol: features column name
        /// </returns>
        public string GetFeaturesCol() =>
            (string)Reference.Invoke("getFeaturesCol");
        
        /// <summary>
        /// Gets hashSeed value
        /// </summary>
        /// <returns>
        /// hashSeed: Seed used for hashing
        /// </returns>
        public int GetHashSeed() =>
            (int)Reference.Invoke("getHashSeed");
        
        /// <summary>
        /// Gets ignoreNamespaces value
        /// </summary>
        /// <returns>
        /// ignoreNamespaces: Namespaces to be ignored (first letter only)
        /// </returns>
        public string GetIgnoreNamespaces() =>
            (string)Reference.Invoke("getIgnoreNamespaces");
        
        /// <summary>
        /// Gets initialModel value
        /// </summary>
        /// <returns>
        /// initialModel: Initial model to start from
        /// </returns>
        public object GetInitialModel() => Reference.Invoke("getInitialModel");
        
        /// <summary>
        /// Gets interactions value
        /// </summary>
        /// <returns>
        /// interactions: Interaction terms as specified by -q
        /// </returns>
        public string[] GetInteractions() =>
            (string[])Reference.Invoke("getInteractions");
        
        /// <summary>
        /// Gets l1 value
        /// </summary>
        /// <returns>
        /// l1: l_1 lambda
        /// </returns>
        public double GetL1() =>
            (double)Reference.Invoke("getL1");
        
        /// <summary>
        /// Gets l2 value
        /// </summary>
        /// <returns>
        /// l2: l_2 lambda
        /// </returns>
        public double GetL2() =>
            (double)Reference.Invoke("getL2");
        
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: label column name
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets learningRate value
        /// </summary>
        /// <returns>
        /// learningRate: Learning rate
        /// </returns>
        public double GetLearningRate() =>
            (double)Reference.Invoke("getLearningRate");
        
        /// <summary>
        /// Gets numBits value
        /// </summary>
        /// <returns>
        /// numBits: Number of bits used
        /// </returns>
        public int GetNumBits() =>
            (int)Reference.Invoke("getNumBits");
        
        /// <summary>
        /// Gets numPasses value
        /// </summary>
        /// <returns>
        /// numPasses: Number of passes over the data
        /// </returns>
        public int GetNumPasses() =>
            (int)Reference.Invoke("getNumPasses");
        
        /// <summary>
        /// Gets passThroughArgs value
        /// </summary>
        /// <returns>
        /// passThroughArgs: VW command line arguments passed
        /// </returns>
        public string GetPassThroughArgs() =>
            (string)Reference.Invoke("getPassThroughArgs");
        
        /// <summary>
        /// Gets powerT value
        /// </summary>
        /// <returns>
        /// powerT: t power value
        /// </returns>
        public double GetPowerT() =>
            (double)Reference.Invoke("getPowerT");
        
        /// <summary>
        /// Gets predictionCol value
        /// </summary>
        /// <returns>
        /// predictionCol: prediction column name
        /// </returns>
        public string GetPredictionCol() =>
            (string)Reference.Invoke("getPredictionCol");
        
        /// <summary>
        /// Gets useBarrierExecutionMode value
        /// </summary>
        /// <returns>
        /// useBarrierExecutionMode: Use barrier execution mode, on by default.
        /// </returns>
        public bool GetUseBarrierExecutionMode() =>
            (bool)Reference.Invoke("getUseBarrierExecutionMode");
        
        /// <summary>
        /// Gets weightCol value
        /// </summary>
        /// <returns>
        /// weightCol: The name of the weight column
        /// </returns>
        public string GetWeightCol() =>
            (string)Reference.Invoke("getWeightCol");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="VowpalWabbitRegressionModel"/></returns>
        override public VowpalWabbitRegressionModel Fit(DataFrame dataset) =>
            new VowpalWabbitRegressionModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="VowpalWabbitRegressor"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitRegressor"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitRegressor"/> object, loaded from path.</returns>
        public static VowpalWabbitRegressor Load(string path) => WrapAsVowpalWabbitRegressor(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitRegressor&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitRegressor> Read() =>
            new JavaMLReader<VowpalWabbitRegressor>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitRegressor WrapAsVowpalWabbitRegressor(object obj) =>
            new VowpalWabbitRegressor((JvmObjectReference)obj);
        
    }
}

        