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
    /// <see cref="VowpalWabbitClassifier"/> implements VowpalWabbitClassifier
    /// </summary>
    public class VowpalWabbitClassifier : JavaEstimator<VowpalWabbitClassificationModel>, IJavaMLWritable, IJavaMLReadable<VowpalWabbitClassifier>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitClassifier";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitClassifier"/> without any parameters.
        /// </summary>
        public VowpalWabbitClassifier() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitClassifier"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitClassifier"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitClassifier(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitClassifier(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for additionalFeatures
        /// </summary>
        /// <param name="value">
        /// Additional feature columns
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetAdditionalFeatures(string[] value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setAdditionalFeatures", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// features column name
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetFeaturesCol(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for hashSeed
        /// </summary>
        /// <param name="value">
        /// Seed used for hashing
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetHashSeed(int value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setHashSeed", (object)value));
        
        /// <summary>
        /// Sets value for ignoreNamespaces
        /// </summary>
        /// <param name="value">
        /// Namespaces to be ignored (first letter only)
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetIgnoreNamespaces(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setIgnoreNamespaces", (object)value));
        
        /// <summary>
        /// Sets value for initialModel
        /// </summary>
        /// <param name="value">
        /// Initial model to start from
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetInitialModel(object value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setInitialModel", (object)value));
        
        
        /// <summary>
        /// Sets value for interactions
        /// </summary>
        /// <param name="value">
        /// Interaction terms as specified by -q
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetInteractions(string[] value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setInteractions", (object)value));
        
        /// <summary>
        /// Sets value for l1
        /// </summary>
        /// <param name="value">
        /// l_1 lambda
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetL1(double value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setL1", (object)value));
        
        /// <summary>
        /// Sets value for l2
        /// </summary>
        /// <param name="value">
        /// l_2 lambda
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetL2(double value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setL2", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetLabelCol(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for labelConversion
        /// </summary>
        /// <param name="value">
        /// Convert 0/1 Spark ML style labels to -1/1 VW style labels. Defaults to true.
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetLabelConversion(bool value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setLabelConversion", (object)value));
        
        /// <summary>
        /// Sets value for learningRate
        /// </summary>
        /// <param name="value">
        /// Learning rate
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetLearningRate(double value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setLearningRate", (object)value));
        
        /// <summary>
        /// Sets value for numBits
        /// </summary>
        /// <param name="value">
        /// Number of bits used
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetNumBits(int value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setNumBits", (object)value));
        
        /// <summary>
        /// Sets value for numPasses
        /// </summary>
        /// <param name="value">
        /// Number of passes over the data
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetNumPasses(int value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setNumPasses", (object)value));
        
        /// <summary>
        /// Sets value for passThroughArgs
        /// </summary>
        /// <param name="value">
        /// VW command line arguments passed
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetPassThroughArgs(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setPassThroughArgs", (object)value));
        
        /// <summary>
        /// Sets value for powerT
        /// </summary>
        /// <param name="value">
        /// t power value
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetPowerT(double value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setPowerT", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetPredictionCol(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for probabilityCol
        /// </summary>
        /// <param name="value">
        /// Column name for predicted class conditional probabilities. Note: Not all models output well-calibrated probability estimates! These probabilities should be treated as confidences, not precise probabilities
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetProbabilityCol(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setProbabilityCol", (object)value));
        
        /// <summary>
        /// Sets value for rawPredictionCol
        /// </summary>
        /// <param name="value">
        /// raw prediction (a.k.a. confidence) column name
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetRawPredictionCol(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setRawPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for thresholds
        /// </summary>
        /// <param name="value">
        /// Thresholds in multi-class classification to adjust the probability of predicting each class. Array must have length equal to the number of classes, with values > 0 excepting that at most one value may be 0. The class with largest value p/t is predicted, where p is the original probability of that class and t is the class's threshold
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetThresholds(double[] value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setThresholds", (object)value));
        
        /// <summary>
        /// Sets value for useBarrierExecutionMode
        /// </summary>
        /// <param name="value">
        /// Use barrier execution mode, on by default.
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetUseBarrierExecutionMode(bool value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setUseBarrierExecutionMode", (object)value));
        
        /// <summary>
        /// Sets value for weightCol
        /// </summary>
        /// <param name="value">
        /// The name of the weight column
        /// </param>
        /// <returns> New VowpalWabbitClassifier object </returns>
        public VowpalWabbitClassifier SetWeightCol(string value) =>
            WrapAsVowpalWabbitClassifier(Reference.Invoke("setWeightCol", (object)value));
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
        /// Gets labelConversion value
        /// </summary>
        /// <returns>
        /// labelConversion: Convert 0/1 Spark ML style labels to -1/1 VW style labels. Defaults to true.
        /// </returns>
        public bool GetLabelConversion() =>
            (bool)Reference.Invoke("getLabelConversion");
        
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
        /// Gets probabilityCol value
        /// </summary>
        /// <returns>
        /// probabilityCol: Column name for predicted class conditional probabilities. Note: Not all models output well-calibrated probability estimates! These probabilities should be treated as confidences, not precise probabilities
        /// </returns>
        public string GetProbabilityCol() =>
            (string)Reference.Invoke("getProbabilityCol");
        
        /// <summary>
        /// Gets rawPredictionCol value
        /// </summary>
        /// <returns>
        /// rawPredictionCol: raw prediction (a.k.a. confidence) column name
        /// </returns>
        public string GetRawPredictionCol() =>
            (string)Reference.Invoke("getRawPredictionCol");
        
        /// <summary>
        /// Gets thresholds value
        /// </summary>
        /// <returns>
        /// thresholds: Thresholds in multi-class classification to adjust the probability of predicting each class. Array must have length equal to the number of classes, with values > 0 excepting that at most one value may be 0. The class with largest value p/t is predicted, where p is the original probability of that class and t is the class's threshold
        /// </returns>
        public double[] GetThresholds() =>
            (double[])Reference.Invoke("getThresholds");
        
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
        /// <returns><see cref="VowpalWabbitClassificationModel"/></returns>
        override public VowpalWabbitClassificationModel Fit(DataFrame dataset) =>
            new VowpalWabbitClassificationModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="VowpalWabbitClassifier"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitClassifier"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitClassifier"/> object, loaded from path.</returns>
        public static VowpalWabbitClassifier Load(string path) => WrapAsVowpalWabbitClassifier(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitClassifier&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitClassifier> Read() =>
            new JavaMLReader<VowpalWabbitClassifier>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitClassifier WrapAsVowpalWabbitClassifier(object obj) =>
            new VowpalWabbitClassifier((JvmObjectReference)obj);
        
    }
}

        