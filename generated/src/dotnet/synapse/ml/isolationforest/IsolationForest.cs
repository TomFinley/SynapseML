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
using Synapse.ML.Isolationforest;

namespace Synapse.ML.Isolationforest
{
    /// <summary>
    /// <see cref="IsolationForest"/> implements IsolationForest
    /// </summary>
    public class IsolationForest : JavaEstimator<IsolationForestModel>, IJavaMLWritable, IJavaMLReadable<IsolationForest>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.isolationforest.IsolationForest";

        /// <summary>
        /// Creates a <see cref="IsolationForest"/> without any parameters.
        /// </summary>
        public IsolationForest() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="IsolationForest"/> with a UID that is used to give the
        /// <see cref="IsolationForest"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public IsolationForest(string uid) : base(s_className, uid)
        {
        }

        internal IsolationForest(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for bootstrap
        /// </summary>
        /// <param name="value">
        /// If true, draw sample for each tree with replacement. If false, do not sample with replacement.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetBootstrap(bool value) =>
            WrapAsIsolationForest(Reference.Invoke("setBootstrap", (object)value));
        
        /// <summary>
        /// Sets value for contamination
        /// </summary>
        /// <param name="value">
        /// The fraction of outliers in the training data set. If this is set to 0.0, it speeds up the training and all predicted labels will be false. The model and outlier scores are otherwise unaffected by this parameter.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetContamination(double value) =>
            WrapAsIsolationForest(Reference.Invoke("setContamination", (object)value));
        
        /// <summary>
        /// Sets value for contaminationError
        /// </summary>
        /// <param name="value">
        /// The error allowed when calculating the threshold required to achieve the specified contamination fraction. The default is 0.0, which forces an exact calculation of the threshold. The exact calculation is slow and can fail for large datasets. If there are issues with the exact calculation, a good choice for this parameter is often 1% of the specified contamination value.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetContaminationError(double value) =>
            WrapAsIsolationForest(Reference.Invoke("setContaminationError", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// The feature vector.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetFeaturesCol(string value) =>
            WrapAsIsolationForest(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for maxFeatures
        /// </summary>
        /// <param name="value">
        /// The number of features used to train each tree. If this value is between 0.0 and 1.0, then it is treated as a fraction. If it is >1.0, then it is treated as a count.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetMaxFeatures(double value) =>
            WrapAsIsolationForest(Reference.Invoke("setMaxFeatures", (object)value));
        
        /// <summary>
        /// Sets value for maxSamples
        /// </summary>
        /// <param name="value">
        /// The number of samples used to train each tree. If this value is between 0.0 and 1.0, then it is treated as a fraction. If it is >1.0, then it is treated as a count.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetMaxSamples(double value) =>
            WrapAsIsolationForest(Reference.Invoke("setMaxSamples", (object)value));
        
        /// <summary>
        /// Sets value for numEstimators
        /// </summary>
        /// <param name="value">
        /// The number of trees in the ensemble.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetNumEstimators(int value) =>
            WrapAsIsolationForest(Reference.Invoke("setNumEstimators", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// The predicted label.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetPredictionCol(string value) =>
            WrapAsIsolationForest(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for randomSeed
        /// </summary>
        /// <param name="value">
        /// The seed used for the random number generator.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetRandomSeed(long value) =>
            WrapAsIsolationForest(Reference.Invoke("setRandomSeed", (object)value));
        
        /// <summary>
        /// Sets value for scoreCol
        /// </summary>
        /// <param name="value">
        /// The outlier score.
        /// </param>
        /// <returns> New IsolationForest object </returns>
        public IsolationForest SetScoreCol(string value) =>
            WrapAsIsolationForest(Reference.Invoke("setScoreCol", (object)value));
        /// <summary>
        /// Gets bootstrap value
        /// </summary>
        /// <returns>
        /// bootstrap: If true, draw sample for each tree with replacement. If false, do not sample with replacement.
        /// </returns>
        public bool GetBootstrap() =>
            (bool)Reference.Invoke("getBootstrap");
        
        /// <summary>
        /// Gets contamination value
        /// </summary>
        /// <returns>
        /// contamination: The fraction of outliers in the training data set. If this is set to 0.0, it speeds up the training and all predicted labels will be false. The model and outlier scores are otherwise unaffected by this parameter.
        /// </returns>
        public double GetContamination() =>
            (double)Reference.Invoke("getContamination");
        
        /// <summary>
        /// Gets contaminationError value
        /// </summary>
        /// <returns>
        /// contaminationError: The error allowed when calculating the threshold required to achieve the specified contamination fraction. The default is 0.0, which forces an exact calculation of the threshold. The exact calculation is slow and can fail for large datasets. If there are issues with the exact calculation, a good choice for this parameter is often 1% of the specified contamination value.
        /// </returns>
        public double GetContaminationError() =>
            (double)Reference.Invoke("getContaminationError");
        
        /// <summary>
        /// Gets featuresCol value
        /// </summary>
        /// <returns>
        /// featuresCol: The feature vector.
        /// </returns>
        public string GetFeaturesCol() =>
            (string)Reference.Invoke("getFeaturesCol");
        
        /// <summary>
        /// Gets maxFeatures value
        /// </summary>
        /// <returns>
        /// maxFeatures: The number of features used to train each tree. If this value is between 0.0 and 1.0, then it is treated as a fraction. If it is >1.0, then it is treated as a count.
        /// </returns>
        public double GetMaxFeatures() =>
            (double)Reference.Invoke("getMaxFeatures");
        
        /// <summary>
        /// Gets maxSamples value
        /// </summary>
        /// <returns>
        /// maxSamples: The number of samples used to train each tree. If this value is between 0.0 and 1.0, then it is treated as a fraction. If it is >1.0, then it is treated as a count.
        /// </returns>
        public double GetMaxSamples() =>
            (double)Reference.Invoke("getMaxSamples");
        
        /// <summary>
        /// Gets numEstimators value
        /// </summary>
        /// <returns>
        /// numEstimators: The number of trees in the ensemble.
        /// </returns>
        public int GetNumEstimators() =>
            (int)Reference.Invoke("getNumEstimators");
        
        /// <summary>
        /// Gets predictionCol value
        /// </summary>
        /// <returns>
        /// predictionCol: The predicted label.
        /// </returns>
        public string GetPredictionCol() =>
            (string)Reference.Invoke("getPredictionCol");
        
        /// <summary>
        /// Gets randomSeed value
        /// </summary>
        /// <returns>
        /// randomSeed: The seed used for the random number generator.
        /// </returns>
        public long GetRandomSeed() =>
            (long)Reference.Invoke("getRandomSeed");
        
        /// <summary>
        /// Gets scoreCol value
        /// </summary>
        /// <returns>
        /// scoreCol: The outlier score.
        /// </returns>
        public string GetScoreCol() =>
            (string)Reference.Invoke("getScoreCol");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="IsolationForestModel"/></returns>
        override public IsolationForestModel Fit(DataFrame dataset) =>
            new IsolationForestModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="IsolationForest"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="IsolationForest"/> was saved to</param>
        /// <returns>New <see cref="IsolationForest"/> object, loaded from path.</returns>
        public static IsolationForest Load(string path) => WrapAsIsolationForest(
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
        /// <returns>an <see cref="JavaMLReader&lt;IsolationForest&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<IsolationForest> Read() =>
            new JavaMLReader<IsolationForest>((JvmObjectReference)Reference.Invoke("read"));
        private static IsolationForest WrapAsIsolationForest(object obj) =>
            new IsolationForest((JvmObjectReference)obj);
        
    }
}

        