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
    /// <see cref="VowpalWabbitContextualBandit"/> implements VowpalWabbitContextualBandit
    /// </summary>
    public class VowpalWabbitContextualBandit : JavaEstimator<VowpalWabbitContextualBanditModel>, IJavaMLWritable, IJavaMLReadable<VowpalWabbitContextualBandit>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitContextualBandit";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitContextualBandit"/> without any parameters.
        /// </summary>
        public VowpalWabbitContextualBandit() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitContextualBandit"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitContextualBandit"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitContextualBandit(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitContextualBandit(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for additionalFeatures
        /// </summary>
        /// <param name="value">
        /// Additional feature columns
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetAdditionalFeatures(string[] value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setAdditionalFeatures", (object)value));
        
        /// <summary>
        /// Sets value for additionalSharedFeatures
        /// </summary>
        /// <param name="value">
        /// Additional namespaces for the shared example
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetAdditionalSharedFeatures(string[] value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setAdditionalSharedFeatures", (object)value));
        
        /// <summary>
        /// Sets value for chosenActionCol
        /// </summary>
        /// <param name="value">
        /// Column name of chosen action
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetChosenActionCol(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setChosenActionCol", (object)value));
        
        /// <summary>
        /// Sets value for epsilon
        /// </summary>
        /// <param name="value">
        /// epsilon used for exploration
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetEpsilon(double value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setEpsilon", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// features column name
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetFeaturesCol(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for hashSeed
        /// </summary>
        /// <param name="value">
        /// Seed used for hashing
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetHashSeed(int value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setHashSeed", (object)value));
        
        /// <summary>
        /// Sets value for ignoreNamespaces
        /// </summary>
        /// <param name="value">
        /// Namespaces to be ignored (first letter only)
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetIgnoreNamespaces(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setIgnoreNamespaces", (object)value));
        
        /// <summary>
        /// Sets value for initialModel
        /// </summary>
        /// <param name="value">
        /// Initial model to start from
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetInitialModel(object value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setInitialModel", (object)value));
        
        
        /// <summary>
        /// Sets value for interactions
        /// </summary>
        /// <param name="value">
        /// Interaction terms as specified by -q
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetInteractions(string[] value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setInteractions", (object)value));
        
        /// <summary>
        /// Sets value for l1
        /// </summary>
        /// <param name="value">
        /// l_1 lambda
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetL1(double value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setL1", (object)value));
        
        /// <summary>
        /// Sets value for l2
        /// </summary>
        /// <param name="value">
        /// l_2 lambda
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetL2(double value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setL2", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetLabelCol(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for learningRate
        /// </summary>
        /// <param name="value">
        /// Learning rate
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetLearningRate(double value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setLearningRate", (object)value));
        
        /// <summary>
        /// Sets value for numBits
        /// </summary>
        /// <param name="value">
        /// Number of bits used
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetNumBits(int value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setNumBits", (object)value));
        
        /// <summary>
        /// Sets value for numPasses
        /// </summary>
        /// <param name="value">
        /// Number of passes over the data
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetNumPasses(int value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setNumPasses", (object)value));
        
        /// <summary>
        /// Sets value for parallelism
        /// </summary>
        /// <param name="value">
        /// the number of threads to use when running parallel algorithms
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetParallelism(int value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setParallelism", (object)value));
        
        /// <summary>
        /// Sets value for passThroughArgs
        /// </summary>
        /// <param name="value">
        /// VW command line arguments passed
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetPassThroughArgs(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setPassThroughArgs", (object)value));
        
        /// <summary>
        /// Sets value for powerT
        /// </summary>
        /// <param name="value">
        /// t power value
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetPowerT(double value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setPowerT", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetPredictionCol(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for probabilityCol
        /// </summary>
        /// <param name="value">
        /// Column name of probability of chosen action
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetProbabilityCol(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setProbabilityCol", (object)value));
        
        /// <summary>
        /// Sets value for sharedCol
        /// </summary>
        /// <param name="value">
        /// Column name of shared features
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetSharedCol(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setSharedCol", (object)value));
        
        /// <summary>
        /// Sets value for useBarrierExecutionMode
        /// </summary>
        /// <param name="value">
        /// Use barrier execution mode, on by default.
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetUseBarrierExecutionMode(bool value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setUseBarrierExecutionMode", (object)value));
        
        /// <summary>
        /// Sets value for weightCol
        /// </summary>
        /// <param name="value">
        /// The name of the weight column
        /// </param>
        /// <returns> New VowpalWabbitContextualBandit object </returns>
        public VowpalWabbitContextualBandit SetWeightCol(string value) =>
            WrapAsVowpalWabbitContextualBandit(Reference.Invoke("setWeightCol", (object)value));
        /// <summary>
        /// Gets additionalFeatures value
        /// </summary>
        /// <returns>
        /// additionalFeatures: Additional feature columns
        /// </returns>
        public string[] GetAdditionalFeatures() =>
            (string[])Reference.Invoke("getAdditionalFeatures");
        
        /// <summary>
        /// Gets additionalSharedFeatures value
        /// </summary>
        /// <returns>
        /// additionalSharedFeatures: Additional namespaces for the shared example
        /// </returns>
        public string[] GetAdditionalSharedFeatures() =>
            (string[])Reference.Invoke("getAdditionalSharedFeatures");
        
        /// <summary>
        /// Gets chosenActionCol value
        /// </summary>
        /// <returns>
        /// chosenActionCol: Column name of chosen action
        /// </returns>
        public string GetChosenActionCol() =>
            (string)Reference.Invoke("getChosenActionCol");
        
        /// <summary>
        /// Gets epsilon value
        /// </summary>
        /// <returns>
        /// epsilon: epsilon used for exploration
        /// </returns>
        public double GetEpsilon() =>
            (double)Reference.Invoke("getEpsilon");
        
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
        /// Gets parallelism value
        /// </summary>
        /// <returns>
        /// parallelism: the number of threads to use when running parallel algorithms
        /// </returns>
        public int GetParallelism() =>
            (int)Reference.Invoke("getParallelism");
        
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
        /// probabilityCol: Column name of probability of chosen action
        /// </returns>
        public string GetProbabilityCol() =>
            (string)Reference.Invoke("getProbabilityCol");
        
        /// <summary>
        /// Gets sharedCol value
        /// </summary>
        /// <returns>
        /// sharedCol: Column name of shared features
        /// </returns>
        public string GetSharedCol() =>
            (string)Reference.Invoke("getSharedCol");
        
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
        /// <returns><see cref="VowpalWabbitContextualBanditModel"/></returns>
        override public VowpalWabbitContextualBanditModel Fit(DataFrame dataset) =>
            new VowpalWabbitContextualBanditModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="VowpalWabbitContextualBandit"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitContextualBandit"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitContextualBandit"/> object, loaded from path.</returns>
        public static VowpalWabbitContextualBandit Load(string path) => WrapAsVowpalWabbitContextualBandit(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitContextualBandit&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitContextualBandit> Read() =>
            new JavaMLReader<VowpalWabbitContextualBandit>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitContextualBandit WrapAsVowpalWabbitContextualBandit(object obj) =>
            new VowpalWabbitContextualBandit((JvmObjectReference)obj);
        
    }
}

        