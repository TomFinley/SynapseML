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


namespace Synapse.ML.Vw
{
    /// <summary>
    /// <see cref="VowpalWabbitContextualBanditModel"/> implements VowpalWabbitContextualBanditModel
    /// </summary>
    public class VowpalWabbitContextualBanditModel : JavaModel<VowpalWabbitContextualBanditModel>, IJavaMLWritable, IJavaMLReadable<VowpalWabbitContextualBanditModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitContextualBanditModel";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitContextualBanditModel"/> without any parameters.
        /// </summary>
        public VowpalWabbitContextualBanditModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitContextualBanditModel"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitContextualBanditModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitContextualBanditModel(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitContextualBanditModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for additionalFeatures
        /// </summary>
        /// <param name="value">
        /// Additional feature columns
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetAdditionalFeatures(string[] value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setAdditionalFeatures", (object)value));
        
        /// <summary>
        /// Sets value for additionalSharedFeatures
        /// </summary>
        /// <param name="value">
        /// Additional namespaces for the shared example
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetAdditionalSharedFeatures(string[] value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setAdditionalSharedFeatures", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// features column name
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetFeaturesCol(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for hashSeed
        /// </summary>
        /// <param name="value">
        /// Seed used for hashing
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetHashSeed(int value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setHashSeed", (object)value));
        
        /// <summary>
        /// Sets value for ignoreNamespaces
        /// </summary>
        /// <param name="value">
        /// Namespaces to be ignored (first letter only)
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetIgnoreNamespaces(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setIgnoreNamespaces", (object)value));
        
        /// <summary>
        /// Sets value for initialModel
        /// </summary>
        /// <param name="value">
        /// Initial model to start from
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetInitialModel(object value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setInitialModel", (object)value));
        
        
        /// <summary>
        /// Sets value for interactions
        /// </summary>
        /// <param name="value">
        /// Interaction terms as specified by -q
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetInteractions(string[] value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setInteractions", (object)value));
        
        /// <summary>
        /// Sets value for l1
        /// </summary>
        /// <param name="value">
        /// l_1 lambda
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetL1(double value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setL1", (object)value));
        
        /// <summary>
        /// Sets value for l2
        /// </summary>
        /// <param name="value">
        /// l_2 lambda
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetL2(double value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setL2", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetLabelCol(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for learningRate
        /// </summary>
        /// <param name="value">
        /// Learning rate
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetLearningRate(double value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setLearningRate", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// The VW model....
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetModel(object value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for numBits
        /// </summary>
        /// <param name="value">
        /// Number of bits used
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetNumBits(int value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setNumBits", (object)value));
        
        /// <summary>
        /// Sets value for numPasses
        /// </summary>
        /// <param name="value">
        /// Number of passes over the data
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetNumPasses(int value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setNumPasses", (object)value));
        
        /// <summary>
        /// Sets value for passThroughArgs
        /// </summary>
        /// <param name="value">
        /// VW command line arguments passed
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetPassThroughArgs(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setPassThroughArgs", (object)value));
        
        /// <summary>
        /// Sets value for performanceStatistics
        /// </summary>
        /// <param name="value">
        /// Performance statistics collected during training
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetPerformanceStatistics(DataFrame value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setPerformanceStatistics", (object)value));
        
        
        /// <summary>
        /// Sets value for powerT
        /// </summary>
        /// <param name="value">
        /// t power value
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetPowerT(double value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setPowerT", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetPredictionCol(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for rawPredictionCol
        /// </summary>
        /// <param name="value">
        /// raw prediction (a.k.a. confidence) column name
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetRawPredictionCol(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setRawPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for sharedCol
        /// </summary>
        /// <param name="value">
        /// Column name of shared features
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetSharedCol(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setSharedCol", (object)value));
        
        /// <summary>
        /// Sets value for testArgs
        /// </summary>
        /// <param name="value">
        /// Additional arguments passed to VW at test time
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetTestArgs(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setTestArgs", (object)value));
        
        /// <summary>
        /// Sets value for useBarrierExecutionMode
        /// </summary>
        /// <param name="value">
        /// Use barrier execution mode, on by default.
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetUseBarrierExecutionMode(bool value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setUseBarrierExecutionMode", (object)value));
        
        /// <summary>
        /// Sets value for weightCol
        /// </summary>
        /// <param name="value">
        /// The name of the weight column
        /// </param>
        /// <returns> New VowpalWabbitContextualBanditModel object </returns>
        public VowpalWabbitContextualBanditModel SetWeightCol(string value) =>
            WrapAsVowpalWabbitContextualBanditModel(Reference.Invoke("setWeightCol", (object)value));
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
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: The VW model....
        /// </returns>
        public object GetModel() => Reference.Invoke("getModel");
        
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
        /// Gets performanceStatistics value
        /// </summary>
        /// <returns>
        /// performanceStatistics: Performance statistics collected during training
        /// </returns>
        public DataFrame GetPerformanceStatistics() =>
            new DataFrame((JvmObjectReference)Reference.Invoke("getPerformanceStatistics"));
        
        
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
        /// Gets rawPredictionCol value
        /// </summary>
        /// <returns>
        /// rawPredictionCol: raw prediction (a.k.a. confidence) column name
        /// </returns>
        public string GetRawPredictionCol() =>
            (string)Reference.Invoke("getRawPredictionCol");
        
        /// <summary>
        /// Gets sharedCol value
        /// </summary>
        /// <returns>
        /// sharedCol: Column name of shared features
        /// </returns>
        public string GetSharedCol() =>
            (string)Reference.Invoke("getSharedCol");
        
        /// <summary>
        /// Gets testArgs value
        /// </summary>
        /// <returns>
        /// testArgs: Additional arguments passed to VW at test time
        /// </returns>
        public string GetTestArgs() =>
            (string)Reference.Invoke("getTestArgs");
        
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
        
        /// <summary>
        /// Loads the <see cref="VowpalWabbitContextualBanditModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitContextualBanditModel"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitContextualBanditModel"/> object, loaded from path.</returns>
        public static VowpalWabbitContextualBanditModel Load(string path) => WrapAsVowpalWabbitContextualBanditModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitContextualBanditModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitContextualBanditModel> Read() =>
            new JavaMLReader<VowpalWabbitContextualBanditModel>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitContextualBanditModel WrapAsVowpalWabbitContextualBanditModel(object obj) =>
            new VowpalWabbitContextualBanditModel((JvmObjectReference)obj);
        
    }
}

        