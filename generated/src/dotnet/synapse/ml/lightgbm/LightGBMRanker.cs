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
using Synapse.ML.Lightgbm;

namespace Synapse.ML.Lightgbm
{
    /// <summary>
    /// <see cref="LightGBMRanker"/> implements LightGBMRanker
    /// </summary>
    public class LightGBMRanker : JavaEstimator<LightGBMRankerModel>, IJavaMLWritable, IJavaMLReadable<LightGBMRanker>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.lightgbm.LightGBMRanker";

        /// <summary>
        /// Creates a <see cref="LightGBMRanker"/> without any parameters.
        /// </summary>
        public LightGBMRanker() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="LightGBMRanker"/> with a UID that is used to give the
        /// <see cref="LightGBMRanker"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public LightGBMRanker(string uid) : base(s_className, uid)
        {
        }

        internal LightGBMRanker(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for baggingFraction
        /// </summary>
        /// <param name="value">
        /// Bagging fraction
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetBaggingFraction(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setBaggingFraction", (object)value));
        
        /// <summary>
        /// Sets value for baggingFreq
        /// </summary>
        /// <param name="value">
        /// Bagging frequency
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetBaggingFreq(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setBaggingFreq", (object)value));
        
        /// <summary>
        /// Sets value for baggingSeed
        /// </summary>
        /// <param name="value">
        /// Bagging seed
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetBaggingSeed(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setBaggingSeed", (object)value));
        
        /// <summary>
        /// Sets value for binSampleCount
        /// </summary>
        /// <param name="value">
        /// Number of samples considered at computing histogram bins
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetBinSampleCount(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setBinSampleCount", (object)value));
        
        /// <summary>
        /// Sets value for boostFromAverage
        /// </summary>
        /// <param name="value">
        /// Adjusts initial score to the mean of labels for faster convergence
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetBoostFromAverage(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setBoostFromAverage", (object)value));
        
        /// <summary>
        /// Sets value for boostingType
        /// </summary>
        /// <param name="value">
        /// Default gbdt = traditional Gradient Boosting Decision Tree. Options are: gbdt, gbrt, rf (Random Forest), random_forest, dart (Dropouts meet Multiple Additive Regression Trees), goss (Gradient-based One-Side Sampling). 
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetBoostingType(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setBoostingType", (object)value));
        
        /// <summary>
        /// Sets value for catSmooth
        /// </summary>
        /// <param name="value">
        /// this can reduce the effect of noises in categorical features, especially for categories with few data
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetCatSmooth(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setCatSmooth", (object)value));
        
        /// <summary>
        /// Sets value for categoricalSlotIndexes
        /// </summary>
        /// <param name="value">
        /// List of categorical column indexes, the slot index in the features column
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetCategoricalSlotIndexes(int[] value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setCategoricalSlotIndexes", (object)value));
        
        /// <summary>
        /// Sets value for categoricalSlotNames
        /// </summary>
        /// <param name="value">
        /// List of categorical column slot names, the slot name in the features column
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetCategoricalSlotNames(string[] value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setCategoricalSlotNames", (object)value));
        
        /// <summary>
        /// Sets value for catl2
        /// </summary>
        /// <param name="value">
        /// L2 regularization in categorical split
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetCatl2(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setCatl2", (object)value));
        
        /// <summary>
        /// Sets value for chunkSize
        /// </summary>
        /// <param name="value">
        /// Advanced parameter to specify the chunk size for copying Java data to native.  If set too high, memory may be wasted, but if set too low, performance may be reduced during data copy.If dataset size is known beforehand, set to the number of rows in the dataset.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetChunkSize(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setChunkSize", (object)value));
        
        /// <summary>
        /// Sets value for dataRandomSeed
        /// </summary>
        /// <param name="value">
        /// Random seed for sampling data to construct histogram bins.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetDataRandomSeed(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setDataRandomSeed", (object)value));
        
        /// <summary>
        /// Sets value for defaultListenPort
        /// </summary>
        /// <param name="value">
        /// The default listen port on executors, used for testing
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetDefaultListenPort(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setDefaultListenPort", (object)value));
        
        /// <summary>
        /// Sets value for deterministic
        /// </summary>
        /// <param name="value">
        /// Used only with cpu devide type. Setting this to true should ensure stable results when using the same data and the same parameters.  Note: setting this to true may slow down training.  To avoid potential instability due to numerical issues, please set force_col_wise=true or force_row_wise=true when setting deterministic=true
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetDeterministic(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setDeterministic", (object)value));
        
        /// <summary>
        /// Sets value for driverListenPort
        /// </summary>
        /// <param name="value">
        /// The listen port on a driver. Default value is 0 (random)
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetDriverListenPort(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setDriverListenPort", (object)value));
        
        /// <summary>
        /// Sets value for dropRate
        /// </summary>
        /// <param name="value">
        /// Dropout rate: a fraction of previous trees to drop during the dropout
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetDropRate(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setDropRate", (object)value));
        
        /// <summary>
        /// Sets value for dropSeed
        /// </summary>
        /// <param name="value">
        /// Random seed to choose dropping models. Only used in dart.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetDropSeed(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setDropSeed", (object)value));
        
        /// <summary>
        /// Sets value for earlyStoppingRound
        /// </summary>
        /// <param name="value">
        /// Early stopping round
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetEarlyStoppingRound(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setEarlyStoppingRound", (object)value));
        
        /// <summary>
        /// Sets value for evalAt
        /// </summary>
        /// <param name="value">
        /// NDCG and MAP evaluation positions, separated by comma
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetEvalAt(int[] value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setEvalAt", (object)value));
        
        /// <summary>
        /// Sets value for executionMode
        /// </summary>
        /// <param name="value">
        /// Specify how LightGBM is executed.  Values can be streaming, bulk. Default is bulk.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetExecutionMode(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setExecutionMode", (object)value));
        
        /// <summary>
        /// Sets value for extraSeed
        /// </summary>
        /// <param name="value">
        /// Random seed for selecting threshold when extra_trees is true
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetExtraSeed(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setExtraSeed", (object)value));
        
        /// <summary>
        /// Sets value for featureFraction
        /// </summary>
        /// <param name="value">
        /// Feature fraction
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetFeatureFraction(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setFeatureFraction", (object)value));
        
        /// <summary>
        /// Sets value for featureFractionByNode
        /// </summary>
        /// <param name="value">
        /// Feature fraction by node
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetFeatureFractionByNode(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setFeatureFractionByNode", (object)value));
        
        /// <summary>
        /// Sets value for featureFractionSeed
        /// </summary>
        /// <param name="value">
        /// Feature fraction seed
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetFeatureFractionSeed(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setFeatureFractionSeed", (object)value));
        
        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// features column name
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetFeaturesCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for featuresShapCol
        /// </summary>
        /// <param name="value">
        /// Output SHAP vector column name after prediction containing the feature contribution values
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetFeaturesShapCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setFeaturesShapCol", (object)value));
        
        /// <summary>
        /// Sets value for fobj
        /// </summary>
        /// <param name="value">
        /// Customized objective function. Should accept two parameters: preds, train_data, and return (grad, hess).
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetFobj(object value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setFobj", (object)value));
        
        
        /// <summary>
        /// Sets value for groupCol
        /// </summary>
        /// <param name="value">
        /// The name of the group column
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetGroupCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setGroupCol", (object)value));
        
        /// <summary>
        /// Sets value for improvementTolerance
        /// </summary>
        /// <param name="value">
        /// Tolerance to consider improvement in metric
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetImprovementTolerance(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setImprovementTolerance", (object)value));
        
        /// <summary>
        /// Sets value for initScoreCol
        /// </summary>
        /// <param name="value">
        /// The name of the initial score column, used for continued training
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetInitScoreCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setInitScoreCol", (object)value));
        
        /// <summary>
        /// Sets value for isEnableSparse
        /// </summary>
        /// <param name="value">
        /// Used to enable/disable sparse optimization
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetIsEnableSparse(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setIsEnableSparse", (object)value));
        
        /// <summary>
        /// Sets value for isProvideTrainingMetric
        /// </summary>
        /// <param name="value">
        /// Whether output metric result over training dataset.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetIsProvideTrainingMetric(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setIsProvideTrainingMetric", (object)value));
        
        /// <summary>
        /// Sets value for labelCol
        /// </summary>
        /// <param name="value">
        /// label column name
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetLabelCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setLabelCol", (object)value));
        
        /// <summary>
        /// Sets value for labelGain
        /// </summary>
        /// <param name="value">
        /// graded relevance for each label in NDCG
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetLabelGain(double[] value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setLabelGain", (object)value));
        
        /// <summary>
        /// Sets value for lambdaL1
        /// </summary>
        /// <param name="value">
        /// L1 regularization
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetLambdaL1(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setLambdaL1", (object)value));
        
        /// <summary>
        /// Sets value for lambdaL2
        /// </summary>
        /// <param name="value">
        /// L2 regularization
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetLambdaL2(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setLambdaL2", (object)value));
        
        /// <summary>
        /// Sets value for leafPredictionCol
        /// </summary>
        /// <param name="value">
        /// Predicted leaf indices's column name
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetLeafPredictionCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setLeafPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for learningRate
        /// </summary>
        /// <param name="value">
        /// Learning rate or shrinkage rate
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetLearningRate(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setLearningRate", (object)value));
        
        /// <summary>
        /// Sets value for matrixType
        /// </summary>
        /// <param name="value">
        /// Advanced parameter to specify whether the native lightgbm matrix constructed should be sparse or dense.  Values can be auto, sparse or dense. Default value is auto, which samples first ten rows to determine type.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMatrixType(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMatrixType", (object)value));
        
        /// <summary>
        /// Sets value for maxBin
        /// </summary>
        /// <param name="value">
        /// Max bin
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxBin(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxBin", (object)value));
        
        /// <summary>
        /// Sets value for maxBinByFeature
        /// </summary>
        /// <param name="value">
        /// Max number of bins for each feature
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxBinByFeature(int[] value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxBinByFeature", (object)value));
        
        /// <summary>
        /// Sets value for maxCatThreshold
        /// </summary>
        /// <param name="value">
        /// limit number of split points considered for categorical features
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxCatThreshold(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxCatThreshold", (object)value));
        
        /// <summary>
        /// Sets value for maxCatToOnehot
        /// </summary>
        /// <param name="value">
        /// when number of categories of one feature smaller than or equal to this, one-vs-other split algorithm will be used
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxCatToOnehot(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxCatToOnehot", (object)value));
        
        /// <summary>
        /// Sets value for maxDeltaStep
        /// </summary>
        /// <param name="value">
        /// Used to limit the max output of tree leaves
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxDeltaStep(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxDeltaStep", (object)value));
        
        /// <summary>
        /// Sets value for maxDepth
        /// </summary>
        /// <param name="value">
        /// Max depth
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxDepth(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxDepth", (object)value));
        
        /// <summary>
        /// Sets value for maxDrop
        /// </summary>
        /// <param name="value">
        /// Max number of dropped trees during one boosting iteration
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxDrop(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxDrop", (object)value));
        
        /// <summary>
        /// Sets value for maxPosition
        /// </summary>
        /// <param name="value">
        /// optimized NDCG at this position
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMaxPosition(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMaxPosition", (object)value));
        
        /// <summary>
        /// Sets value for metric
        /// </summary>
        /// <param name="value">
        /// Metrics to be evaluated on the evaluation data.  Options are: empty string or not specified means that metric corresponding to specified objective will be used (this is possible only for pre-defined objective functions, otherwise no evaluation metric will be added). None (string, not a None value) means that no metric will be registered, aliases: na, null, custom. l1, absolute loss, aliases: mean_absolute_error, mae, regression_l1. l2, square loss, aliases: mean_squared_error, mse, regression_l2, regression. rmse, root square loss, aliases: root_mean_squared_error, l2_root. quantile, Quantile regression. mape, MAPE loss, aliases: mean_absolute_percentage_error. huber, Huber loss. fair, Fair loss. poisson, negative log-likelihood for Poisson regression. gamma, negative log-likelihood for Gamma regression. gamma_deviance, residual deviance for Gamma regression. tweedie, negative log-likelihood for Tweedie regression. ndcg, NDCG, aliases: lambdarank. map, MAP, aliases: mean_average_precision. auc, AUC. binary_logloss, log loss, aliases: binary. binary_error, for one sample: 0 for correct classification, 1 for error classification. multi_logloss, log loss for multi-class classification, aliases: multiclass, softmax, multiclassova, multiclass_ova, ova, ovr. multi_error, error rate for multi-class classification. cross_entropy, cross-entropy (with optional linear weights), aliases: xentropy. cross_entropy_lambda, intensity-weighted cross-entropy, aliases: xentlambda. kullback_leibler, Kullback-Leibler divergence, aliases: kldiv. 
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMetric(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMetric", (object)value));
        
        /// <summary>
        /// Sets value for microBatchSize
        /// </summary>
        /// <param name="value">
        /// Specify how many elements are sent in a streaming micro-batch.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMicroBatchSize(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMicroBatchSize", (object)value));
        
        /// <summary>
        /// Sets value for minDataInLeaf
        /// </summary>
        /// <param name="value">
        /// Minimal number of data in one leaf. Can be used to deal with over-fitting.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMinDataInLeaf(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMinDataInLeaf", (object)value));
        
        /// <summary>
        /// Sets value for minDataPerBin
        /// </summary>
        /// <param name="value">
        /// Minimal number of data inside one bin
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMinDataPerBin(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMinDataPerBin", (object)value));
        
        /// <summary>
        /// Sets value for minDataPerGroup
        /// </summary>
        /// <param name="value">
        /// minimal number of data per categorical group
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMinDataPerGroup(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMinDataPerGroup", (object)value));
        
        /// <summary>
        /// Sets value for minGainToSplit
        /// </summary>
        /// <param name="value">
        /// The minimal gain to perform split
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMinGainToSplit(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMinGainToSplit", (object)value));
        
        /// <summary>
        /// Sets value for minSumHessianInLeaf
        /// </summary>
        /// <param name="value">
        /// Minimal sum hessian in one leaf
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMinSumHessianInLeaf(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMinSumHessianInLeaf", (object)value));
        
        /// <summary>
        /// Sets value for modelString
        /// </summary>
        /// <param name="value">
        /// LightGBM model to retrain
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetModelString(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setModelString", (object)value));
        
        /// <summary>
        /// Sets value for monotoneConstraints
        /// </summary>
        /// <param name="value">
        /// used for constraints of monotonic features. 1 means increasing, -1 means decreasing, 0 means non-constraint. Specify all features in order.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMonotoneConstraints(int[] value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMonotoneConstraints", (object)value));
        
        /// <summary>
        /// Sets value for monotoneConstraintsMethod
        /// </summary>
        /// <param name="value">
        /// Monotone constraints method. basic, intermediate, or advanced.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMonotoneConstraintsMethod(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMonotoneConstraintsMethod", (object)value));
        
        /// <summary>
        /// Sets value for monotonePenalty
        /// </summary>
        /// <param name="value">
        /// A penalization parameter X forbids any monotone splits on the first X (rounded down) level(s) of the tree.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetMonotonePenalty(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setMonotonePenalty", (object)value));
        
        /// <summary>
        /// Sets value for negBaggingFraction
        /// </summary>
        /// <param name="value">
        /// Negative Bagging fraction
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetNegBaggingFraction(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setNegBaggingFraction", (object)value));
        
        /// <summary>
        /// Sets value for numBatches
        /// </summary>
        /// <param name="value">
        /// If greater than 0, splits data into separate batches during training
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetNumBatches(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setNumBatches", (object)value));
        
        /// <summary>
        /// Sets value for numIterations
        /// </summary>
        /// <param name="value">
        /// Number of iterations, LightGBM constructs num_class * num_iterations trees
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetNumIterations(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setNumIterations", (object)value));
        
        /// <summary>
        /// Sets value for numLeaves
        /// </summary>
        /// <param name="value">
        /// Number of leaves
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetNumLeaves(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setNumLeaves", (object)value));
        
        /// <summary>
        /// Sets value for numTasks
        /// </summary>
        /// <param name="value">
        /// Advanced parameter to specify the number of tasks.  SynapseML tries to guess this based on cluster configuration, but this parameter can be used to override.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetNumTasks(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setNumTasks", (object)value));
        
        /// <summary>
        /// Sets value for numThreads
        /// </summary>
        /// <param name="value">
        /// Number of threads per executor for LightGBM. For the best speed, set this to the number of real CPU cores.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetNumThreads(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setNumThreads", (object)value));
        
        /// <summary>
        /// Sets value for objective
        /// </summary>
        /// <param name="value">
        /// The Objective. For regression applications, this can be: regression_l2, regression_l1, huber, fair, poisson, quantile, mape, gamma or tweedie. For classification applications, this can be: binary, multiclass, or multiclassova. 
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetObjective(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setObjective", (object)value));
        
        /// <summary>
        /// Sets value for objectiveSeed
        /// </summary>
        /// <param name="value">
        /// Random seed for objectives, if random process is needed.  Currently used only for rank_xendcg objective.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetObjectiveSeed(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setObjectiveSeed", (object)value));
        
        /// <summary>
        /// Sets value for otherRate
        /// </summary>
        /// <param name="value">
        /// The retain ratio of small gradient data. Only used in goss.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetOtherRate(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setOtherRate", (object)value));
        
        /// <summary>
        /// Sets value for parallelism
        /// </summary>
        /// <param name="value">
        /// Tree learner parallelism, can be set to data_parallel or voting_parallel
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetParallelism(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setParallelism", (object)value));
        
        /// <summary>
        /// Sets value for passThroughArgs
        /// </summary>
        /// <param name="value">
        /// Direct string to pass through to LightGBM library (appended with other explicitly set params). Will override any parameters given with explicit setters. Can include multiple parameters in one string.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetPassThroughArgs(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setPassThroughArgs", (object)value));
        
        /// <summary>
        /// Sets value for posBaggingFraction
        /// </summary>
        /// <param name="value">
        /// Positive Bagging fraction
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetPosBaggingFraction(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setPosBaggingFraction", (object)value));
        
        /// <summary>
        /// Sets value for predictDisableShapeCheck
        /// </summary>
        /// <param name="value">
        /// control whether or not LightGBM raises an error when you try to predict on data with a different number of features than the training data
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetPredictDisableShapeCheck(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setPredictDisableShapeCheck", (object)value));
        
        /// <summary>
        /// Sets value for predictionCol
        /// </summary>
        /// <param name="value">
        /// prediction column name
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetPredictionCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setPredictionCol", (object)value));
        
        /// <summary>
        /// Sets value for repartitionByGroupingColumn
        /// </summary>
        /// <param name="value">
        /// Repartition training data according to grouping column, on by default.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetRepartitionByGroupingColumn(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setRepartitionByGroupingColumn", (object)value));
        
        /// <summary>
        /// Sets value for seed
        /// </summary>
        /// <param name="value">
        /// Main seed, used to generate other seeds
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetSeed(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setSeed", (object)value));
        
        /// <summary>
        /// Sets value for skipDrop
        /// </summary>
        /// <param name="value">
        /// Probability of skipping the dropout procedure during a boosting iteration
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetSkipDrop(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setSkipDrop", (object)value));
        
        /// <summary>
        /// Sets value for slotNames
        /// </summary>
        /// <param name="value">
        /// List of slot names in the features column
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetSlotNames(string[] value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setSlotNames", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// Timeout in seconds
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetTimeout(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for topK
        /// </summary>
        /// <param name="value">
        /// The top_k value used in Voting parallel, set this to larger value for more accurate result, but it will slow down the training speed. It should be greater than 0
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetTopK(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setTopK", (object)value));
        
        /// <summary>
        /// Sets value for topRate
        /// </summary>
        /// <param name="value">
        /// The retain ratio of large gradient data. Only used in goss.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetTopRate(double value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setTopRate", (object)value));
        
        /// <summary>
        /// Sets value for uniformDrop
        /// </summary>
        /// <param name="value">
        /// Set this to true to use uniform drop in dart mode
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetUniformDrop(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setUniformDrop", (object)value));
        
        /// <summary>
        /// Sets value for useBarrierExecutionMode
        /// </summary>
        /// <param name="value">
        /// Barrier execution mode which uses a barrier stage, off by default.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetUseBarrierExecutionMode(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setUseBarrierExecutionMode", (object)value));
        
        /// <summary>
        /// Sets value for useMissing
        /// </summary>
        /// <param name="value">
        /// Set this to false to disable the special handle of missing value
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetUseMissing(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setUseMissing", (object)value));
        
        /// <summary>
        /// Sets value for useSingleDatasetMode
        /// </summary>
        /// <param name="value">
        /// Use single dataset execution mode to create a single native dataset per executor (singleton) to reduce memory and communication overhead.
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetUseSingleDatasetMode(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setUseSingleDatasetMode", (object)value));
        
        /// <summary>
        /// Sets value for validationIndicatorCol
        /// </summary>
        /// <param name="value">
        /// Indicates whether the row is for training or validation
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetValidationIndicatorCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setValidationIndicatorCol", (object)value));
        
        /// <summary>
        /// Sets value for verbosity
        /// </summary>
        /// <param name="value">
        /// Verbosity where lt 0 is Fatal, eq 0 is Error, eq 1 is Info, gt 1 is Debug
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetVerbosity(int value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setVerbosity", (object)value));
        
        /// <summary>
        /// Sets value for weightCol
        /// </summary>
        /// <param name="value">
        /// The name of the weight column
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetWeightCol(string value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setWeightCol", (object)value));
        
        /// <summary>
        /// Sets value for xGBoostDartMode
        /// </summary>
        /// <param name="value">
        /// Set this to true to use xgboost dart mode
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetXGBoostDartMode(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setXGBoostDartMode", (object)value));
        
        /// <summary>
        /// Sets value for zeroAsMissing
        /// </summary>
        /// <param name="value">
        /// Set to true to treat all zero as missing values (including the unshown values in LibSVM / sparse matrices). Set to false to use na for representing missing values
        /// </param>
        /// <returns> New LightGBMRanker object </returns>
        public LightGBMRanker SetZeroAsMissing(bool value) =>
            WrapAsLightGBMRanker(Reference.Invoke("setZeroAsMissing", (object)value));
        /// <summary>
        /// Gets baggingFraction value
        /// </summary>
        /// <returns>
        /// baggingFraction: Bagging fraction
        /// </returns>
        public double GetBaggingFraction() =>
            (double)Reference.Invoke("getBaggingFraction");
        
        /// <summary>
        /// Gets baggingFreq value
        /// </summary>
        /// <returns>
        /// baggingFreq: Bagging frequency
        /// </returns>
        public int GetBaggingFreq() =>
            (int)Reference.Invoke("getBaggingFreq");
        
        /// <summary>
        /// Gets baggingSeed value
        /// </summary>
        /// <returns>
        /// baggingSeed: Bagging seed
        /// </returns>
        public int GetBaggingSeed() =>
            (int)Reference.Invoke("getBaggingSeed");
        
        /// <summary>
        /// Gets binSampleCount value
        /// </summary>
        /// <returns>
        /// binSampleCount: Number of samples considered at computing histogram bins
        /// </returns>
        public int GetBinSampleCount() =>
            (int)Reference.Invoke("getBinSampleCount");
        
        /// <summary>
        /// Gets boostFromAverage value
        /// </summary>
        /// <returns>
        /// boostFromAverage: Adjusts initial score to the mean of labels for faster convergence
        /// </returns>
        public bool GetBoostFromAverage() =>
            (bool)Reference.Invoke("getBoostFromAverage");
        
        /// <summary>
        /// Gets boostingType value
        /// </summary>
        /// <returns>
        /// boostingType: Default gbdt = traditional Gradient Boosting Decision Tree. Options are: gbdt, gbrt, rf (Random Forest), random_forest, dart (Dropouts meet Multiple Additive Regression Trees), goss (Gradient-based One-Side Sampling). 
        /// </returns>
        public string GetBoostingType() =>
            (string)Reference.Invoke("getBoostingType");
        
        /// <summary>
        /// Gets catSmooth value
        /// </summary>
        /// <returns>
        /// catSmooth: this can reduce the effect of noises in categorical features, especially for categories with few data
        /// </returns>
        public double GetCatSmooth() =>
            (double)Reference.Invoke("getCatSmooth");
        
        /// <summary>
        /// Gets categoricalSlotIndexes value
        /// </summary>
        /// <returns>
        /// categoricalSlotIndexes: List of categorical column indexes, the slot index in the features column
        /// </returns>
        public int[] GetCategoricalSlotIndexes() =>
            (int[])Reference.Invoke("getCategoricalSlotIndexes");
        
        /// <summary>
        /// Gets categoricalSlotNames value
        /// </summary>
        /// <returns>
        /// categoricalSlotNames: List of categorical column slot names, the slot name in the features column
        /// </returns>
        public string[] GetCategoricalSlotNames() =>
            (string[])Reference.Invoke("getCategoricalSlotNames");
        
        /// <summary>
        /// Gets catl2 value
        /// </summary>
        /// <returns>
        /// catl2: L2 regularization in categorical split
        /// </returns>
        public double GetCatl2() =>
            (double)Reference.Invoke("getCatl2");
        
        /// <summary>
        /// Gets chunkSize value
        /// </summary>
        /// <returns>
        /// chunkSize: Advanced parameter to specify the chunk size for copying Java data to native.  If set too high, memory may be wasted, but if set too low, performance may be reduced during data copy.If dataset size is known beforehand, set to the number of rows in the dataset.
        /// </returns>
        public int GetChunkSize() =>
            (int)Reference.Invoke("getChunkSize");
        
        /// <summary>
        /// Gets dataRandomSeed value
        /// </summary>
        /// <returns>
        /// dataRandomSeed: Random seed for sampling data to construct histogram bins.
        /// </returns>
        public int GetDataRandomSeed() =>
            (int)Reference.Invoke("getDataRandomSeed");
        
        /// <summary>
        /// Gets defaultListenPort value
        /// </summary>
        /// <returns>
        /// defaultListenPort: The default listen port on executors, used for testing
        /// </returns>
        public int GetDefaultListenPort() =>
            (int)Reference.Invoke("getDefaultListenPort");
        
        /// <summary>
        /// Gets deterministic value
        /// </summary>
        /// <returns>
        /// deterministic: Used only with cpu devide type. Setting this to true should ensure stable results when using the same data and the same parameters.  Note: setting this to true may slow down training.  To avoid potential instability due to numerical issues, please set force_col_wise=true or force_row_wise=true when setting deterministic=true
        /// </returns>
        public bool GetDeterministic() =>
            (bool)Reference.Invoke("getDeterministic");
        
        /// <summary>
        /// Gets driverListenPort value
        /// </summary>
        /// <returns>
        /// driverListenPort: The listen port on a driver. Default value is 0 (random)
        /// </returns>
        public int GetDriverListenPort() =>
            (int)Reference.Invoke("getDriverListenPort");
        
        /// <summary>
        /// Gets dropRate value
        /// </summary>
        /// <returns>
        /// dropRate: Dropout rate: a fraction of previous trees to drop during the dropout
        /// </returns>
        public double GetDropRate() =>
            (double)Reference.Invoke("getDropRate");
        
        /// <summary>
        /// Gets dropSeed value
        /// </summary>
        /// <returns>
        /// dropSeed: Random seed to choose dropping models. Only used in dart.
        /// </returns>
        public int GetDropSeed() =>
            (int)Reference.Invoke("getDropSeed");
        
        /// <summary>
        /// Gets earlyStoppingRound value
        /// </summary>
        /// <returns>
        /// earlyStoppingRound: Early stopping round
        /// </returns>
        public int GetEarlyStoppingRound() =>
            (int)Reference.Invoke("getEarlyStoppingRound");
        
        /// <summary>
        /// Gets evalAt value
        /// </summary>
        /// <returns>
        /// evalAt: NDCG and MAP evaluation positions, separated by comma
        /// </returns>
        public int[] GetEvalAt() =>
            (int[])Reference.Invoke("getEvalAt");
        
        /// <summary>
        /// Gets executionMode value
        /// </summary>
        /// <returns>
        /// executionMode: Specify how LightGBM is executed.  Values can be streaming, bulk. Default is bulk.
        /// </returns>
        public string GetExecutionMode() =>
            (string)Reference.Invoke("getExecutionMode");
        
        /// <summary>
        /// Gets extraSeed value
        /// </summary>
        /// <returns>
        /// extraSeed: Random seed for selecting threshold when extra_trees is true
        /// </returns>
        public int GetExtraSeed() =>
            (int)Reference.Invoke("getExtraSeed");
        
        /// <summary>
        /// Gets featureFraction value
        /// </summary>
        /// <returns>
        /// featureFraction: Feature fraction
        /// </returns>
        public double GetFeatureFraction() =>
            (double)Reference.Invoke("getFeatureFraction");
        
        /// <summary>
        /// Gets featureFractionByNode value
        /// </summary>
        /// <returns>
        /// featureFractionByNode: Feature fraction by node
        /// </returns>
        public double GetFeatureFractionByNode() =>
            (double)Reference.Invoke("getFeatureFractionByNode");
        
        /// <summary>
        /// Gets featureFractionSeed value
        /// </summary>
        /// <returns>
        /// featureFractionSeed: Feature fraction seed
        /// </returns>
        public int GetFeatureFractionSeed() =>
            (int)Reference.Invoke("getFeatureFractionSeed");
        
        /// <summary>
        /// Gets featuresCol value
        /// </summary>
        /// <returns>
        /// featuresCol: features column name
        /// </returns>
        public string GetFeaturesCol() =>
            (string)Reference.Invoke("getFeaturesCol");
        
        /// <summary>
        /// Gets featuresShapCol value
        /// </summary>
        /// <returns>
        /// featuresShapCol: Output SHAP vector column name after prediction containing the feature contribution values
        /// </returns>
        public string GetFeaturesShapCol() =>
            (string)Reference.Invoke("getFeaturesShapCol");
        
        /// <summary>
        /// Gets fobj value
        /// </summary>
        /// <returns>
        /// fobj: Customized objective function. Should accept two parameters: preds, train_data, and return (grad, hess).
        /// </returns>
        public object GetFobj() => Reference.Invoke("getFobj");
        
        /// <summary>
        /// Gets groupCol value
        /// </summary>
        /// <returns>
        /// groupCol: The name of the group column
        /// </returns>
        public string GetGroupCol() =>
            (string)Reference.Invoke("getGroupCol");
        
        /// <summary>
        /// Gets improvementTolerance value
        /// </summary>
        /// <returns>
        /// improvementTolerance: Tolerance to consider improvement in metric
        /// </returns>
        public double GetImprovementTolerance() =>
            (double)Reference.Invoke("getImprovementTolerance");
        
        /// <summary>
        /// Gets initScoreCol value
        /// </summary>
        /// <returns>
        /// initScoreCol: The name of the initial score column, used for continued training
        /// </returns>
        public string GetInitScoreCol() =>
            (string)Reference.Invoke("getInitScoreCol");
        
        /// <summary>
        /// Gets isEnableSparse value
        /// </summary>
        /// <returns>
        /// isEnableSparse: Used to enable/disable sparse optimization
        /// </returns>
        public bool GetIsEnableSparse() =>
            (bool)Reference.Invoke("getIsEnableSparse");
        
        /// <summary>
        /// Gets isProvideTrainingMetric value
        /// </summary>
        /// <returns>
        /// isProvideTrainingMetric: Whether output metric result over training dataset.
        /// </returns>
        public bool GetIsProvideTrainingMetric() =>
            (bool)Reference.Invoke("getIsProvideTrainingMetric");
        
        /// <summary>
        /// Gets labelCol value
        /// </summary>
        /// <returns>
        /// labelCol: label column name
        /// </returns>
        public string GetLabelCol() =>
            (string)Reference.Invoke("getLabelCol");
        
        /// <summary>
        /// Gets labelGain value
        /// </summary>
        /// <returns>
        /// labelGain: graded relevance for each label in NDCG
        /// </returns>
        public double[] GetLabelGain() =>
            (double[])Reference.Invoke("getLabelGain");
        
        /// <summary>
        /// Gets lambdaL1 value
        /// </summary>
        /// <returns>
        /// lambdaL1: L1 regularization
        /// </returns>
        public double GetLambdaL1() =>
            (double)Reference.Invoke("getLambdaL1");
        
        /// <summary>
        /// Gets lambdaL2 value
        /// </summary>
        /// <returns>
        /// lambdaL2: L2 regularization
        /// </returns>
        public double GetLambdaL2() =>
            (double)Reference.Invoke("getLambdaL2");
        
        /// <summary>
        /// Gets leafPredictionCol value
        /// </summary>
        /// <returns>
        /// leafPredictionCol: Predicted leaf indices's column name
        /// </returns>
        public string GetLeafPredictionCol() =>
            (string)Reference.Invoke("getLeafPredictionCol");
        
        /// <summary>
        /// Gets learningRate value
        /// </summary>
        /// <returns>
        /// learningRate: Learning rate or shrinkage rate
        /// </returns>
        public double GetLearningRate() =>
            (double)Reference.Invoke("getLearningRate");
        
        /// <summary>
        /// Gets matrixType value
        /// </summary>
        /// <returns>
        /// matrixType: Advanced parameter to specify whether the native lightgbm matrix constructed should be sparse or dense.  Values can be auto, sparse or dense. Default value is auto, which samples first ten rows to determine type.
        /// </returns>
        public string GetMatrixType() =>
            (string)Reference.Invoke("getMatrixType");
        
        /// <summary>
        /// Gets maxBin value
        /// </summary>
        /// <returns>
        /// maxBin: Max bin
        /// </returns>
        public int GetMaxBin() =>
            (int)Reference.Invoke("getMaxBin");
        
        /// <summary>
        /// Gets maxBinByFeature value
        /// </summary>
        /// <returns>
        /// maxBinByFeature: Max number of bins for each feature
        /// </returns>
        public int[] GetMaxBinByFeature() =>
            (int[])Reference.Invoke("getMaxBinByFeature");
        
        /// <summary>
        /// Gets maxCatThreshold value
        /// </summary>
        /// <returns>
        /// maxCatThreshold: limit number of split points considered for categorical features
        /// </returns>
        public int GetMaxCatThreshold() =>
            (int)Reference.Invoke("getMaxCatThreshold");
        
        /// <summary>
        /// Gets maxCatToOnehot value
        /// </summary>
        /// <returns>
        /// maxCatToOnehot: when number of categories of one feature smaller than or equal to this, one-vs-other split algorithm will be used
        /// </returns>
        public int GetMaxCatToOnehot() =>
            (int)Reference.Invoke("getMaxCatToOnehot");
        
        /// <summary>
        /// Gets maxDeltaStep value
        /// </summary>
        /// <returns>
        /// maxDeltaStep: Used to limit the max output of tree leaves
        /// </returns>
        public double GetMaxDeltaStep() =>
            (double)Reference.Invoke("getMaxDeltaStep");
        
        /// <summary>
        /// Gets maxDepth value
        /// </summary>
        /// <returns>
        /// maxDepth: Max depth
        /// </returns>
        public int GetMaxDepth() =>
            (int)Reference.Invoke("getMaxDepth");
        
        /// <summary>
        /// Gets maxDrop value
        /// </summary>
        /// <returns>
        /// maxDrop: Max number of dropped trees during one boosting iteration
        /// </returns>
        public int GetMaxDrop() =>
            (int)Reference.Invoke("getMaxDrop");
        
        /// <summary>
        /// Gets maxPosition value
        /// </summary>
        /// <returns>
        /// maxPosition: optimized NDCG at this position
        /// </returns>
        public int GetMaxPosition() =>
            (int)Reference.Invoke("getMaxPosition");
        
        /// <summary>
        /// Gets metric value
        /// </summary>
        /// <returns>
        /// metric: Metrics to be evaluated on the evaluation data.  Options are: empty string or not specified means that metric corresponding to specified objective will be used (this is possible only for pre-defined objective functions, otherwise no evaluation metric will be added). None (string, not a None value) means that no metric will be registered, aliases: na, null, custom. l1, absolute loss, aliases: mean_absolute_error, mae, regression_l1. l2, square loss, aliases: mean_squared_error, mse, regression_l2, regression. rmse, root square loss, aliases: root_mean_squared_error, l2_root. quantile, Quantile regression. mape, MAPE loss, aliases: mean_absolute_percentage_error. huber, Huber loss. fair, Fair loss. poisson, negative log-likelihood for Poisson regression. gamma, negative log-likelihood for Gamma regression. gamma_deviance, residual deviance for Gamma regression. tweedie, negative log-likelihood for Tweedie regression. ndcg, NDCG, aliases: lambdarank. map, MAP, aliases: mean_average_precision. auc, AUC. binary_logloss, log loss, aliases: binary. binary_error, for one sample: 0 for correct classification, 1 for error classification. multi_logloss, log loss for multi-class classification, aliases: multiclass, softmax, multiclassova, multiclass_ova, ova, ovr. multi_error, error rate for multi-class classification. cross_entropy, cross-entropy (with optional linear weights), aliases: xentropy. cross_entropy_lambda, intensity-weighted cross-entropy, aliases: xentlambda. kullback_leibler, Kullback-Leibler divergence, aliases: kldiv. 
        /// </returns>
        public string GetMetric() =>
            (string)Reference.Invoke("getMetric");
        
        /// <summary>
        /// Gets microBatchSize value
        /// </summary>
        /// <returns>
        /// microBatchSize: Specify how many elements are sent in a streaming micro-batch.
        /// </returns>
        public int GetMicroBatchSize() =>
            (int)Reference.Invoke("getMicroBatchSize");
        
        /// <summary>
        /// Gets minDataInLeaf value
        /// </summary>
        /// <returns>
        /// minDataInLeaf: Minimal number of data in one leaf. Can be used to deal with over-fitting.
        /// </returns>
        public int GetMinDataInLeaf() =>
            (int)Reference.Invoke("getMinDataInLeaf");
        
        /// <summary>
        /// Gets minDataPerBin value
        /// </summary>
        /// <returns>
        /// minDataPerBin: Minimal number of data inside one bin
        /// </returns>
        public int GetMinDataPerBin() =>
            (int)Reference.Invoke("getMinDataPerBin");
        
        /// <summary>
        /// Gets minDataPerGroup value
        /// </summary>
        /// <returns>
        /// minDataPerGroup: minimal number of data per categorical group
        /// </returns>
        public int GetMinDataPerGroup() =>
            (int)Reference.Invoke("getMinDataPerGroup");
        
        /// <summary>
        /// Gets minGainToSplit value
        /// </summary>
        /// <returns>
        /// minGainToSplit: The minimal gain to perform split
        /// </returns>
        public double GetMinGainToSplit() =>
            (double)Reference.Invoke("getMinGainToSplit");
        
        /// <summary>
        /// Gets minSumHessianInLeaf value
        /// </summary>
        /// <returns>
        /// minSumHessianInLeaf: Minimal sum hessian in one leaf
        /// </returns>
        public double GetMinSumHessianInLeaf() =>
            (double)Reference.Invoke("getMinSumHessianInLeaf");
        
        /// <summary>
        /// Gets modelString value
        /// </summary>
        /// <returns>
        /// modelString: LightGBM model to retrain
        /// </returns>
        public string GetModelString() =>
            (string)Reference.Invoke("getModelString");
        
        /// <summary>
        /// Gets monotoneConstraints value
        /// </summary>
        /// <returns>
        /// monotoneConstraints: used for constraints of monotonic features. 1 means increasing, -1 means decreasing, 0 means non-constraint. Specify all features in order.
        /// </returns>
        public int[] GetMonotoneConstraints() =>
            (int[])Reference.Invoke("getMonotoneConstraints");
        
        /// <summary>
        /// Gets monotoneConstraintsMethod value
        /// </summary>
        /// <returns>
        /// monotoneConstraintsMethod: Monotone constraints method. basic, intermediate, or advanced.
        /// </returns>
        public string GetMonotoneConstraintsMethod() =>
            (string)Reference.Invoke("getMonotoneConstraintsMethod");
        
        /// <summary>
        /// Gets monotonePenalty value
        /// </summary>
        /// <returns>
        /// monotonePenalty: A penalization parameter X forbids any monotone splits on the first X (rounded down) level(s) of the tree.
        /// </returns>
        public double GetMonotonePenalty() =>
            (double)Reference.Invoke("getMonotonePenalty");
        
        /// <summary>
        /// Gets negBaggingFraction value
        /// </summary>
        /// <returns>
        /// negBaggingFraction: Negative Bagging fraction
        /// </returns>
        public double GetNegBaggingFraction() =>
            (double)Reference.Invoke("getNegBaggingFraction");
        
        /// <summary>
        /// Gets numBatches value
        /// </summary>
        /// <returns>
        /// numBatches: If greater than 0, splits data into separate batches during training
        /// </returns>
        public int GetNumBatches() =>
            (int)Reference.Invoke("getNumBatches");
        
        /// <summary>
        /// Gets numIterations value
        /// </summary>
        /// <returns>
        /// numIterations: Number of iterations, LightGBM constructs num_class * num_iterations trees
        /// </returns>
        public int GetNumIterations() =>
            (int)Reference.Invoke("getNumIterations");
        
        /// <summary>
        /// Gets numLeaves value
        /// </summary>
        /// <returns>
        /// numLeaves: Number of leaves
        /// </returns>
        public int GetNumLeaves() =>
            (int)Reference.Invoke("getNumLeaves");
        
        /// <summary>
        /// Gets numTasks value
        /// </summary>
        /// <returns>
        /// numTasks: Advanced parameter to specify the number of tasks.  SynapseML tries to guess this based on cluster configuration, but this parameter can be used to override.
        /// </returns>
        public int GetNumTasks() =>
            (int)Reference.Invoke("getNumTasks");
        
        /// <summary>
        /// Gets numThreads value
        /// </summary>
        /// <returns>
        /// numThreads: Number of threads per executor for LightGBM. For the best speed, set this to the number of real CPU cores.
        /// </returns>
        public int GetNumThreads() =>
            (int)Reference.Invoke("getNumThreads");
        
        /// <summary>
        /// Gets objective value
        /// </summary>
        /// <returns>
        /// objective: The Objective. For regression applications, this can be: regression_l2, regression_l1, huber, fair, poisson, quantile, mape, gamma or tweedie. For classification applications, this can be: binary, multiclass, or multiclassova. 
        /// </returns>
        public string GetObjective() =>
            (string)Reference.Invoke("getObjective");
        
        /// <summary>
        /// Gets objectiveSeed value
        /// </summary>
        /// <returns>
        /// objectiveSeed: Random seed for objectives, if random process is needed.  Currently used only for rank_xendcg objective.
        /// </returns>
        public int GetObjectiveSeed() =>
            (int)Reference.Invoke("getObjectiveSeed");
        
        /// <summary>
        /// Gets otherRate value
        /// </summary>
        /// <returns>
        /// otherRate: The retain ratio of small gradient data. Only used in goss.
        /// </returns>
        public double GetOtherRate() =>
            (double)Reference.Invoke("getOtherRate");
        
        /// <summary>
        /// Gets parallelism value
        /// </summary>
        /// <returns>
        /// parallelism: Tree learner parallelism, can be set to data_parallel or voting_parallel
        /// </returns>
        public string GetParallelism() =>
            (string)Reference.Invoke("getParallelism");
        
        /// <summary>
        /// Gets passThroughArgs value
        /// </summary>
        /// <returns>
        /// passThroughArgs: Direct string to pass through to LightGBM library (appended with other explicitly set params). Will override any parameters given with explicit setters. Can include multiple parameters in one string.
        /// </returns>
        public string GetPassThroughArgs() =>
            (string)Reference.Invoke("getPassThroughArgs");
        
        /// <summary>
        /// Gets posBaggingFraction value
        /// </summary>
        /// <returns>
        /// posBaggingFraction: Positive Bagging fraction
        /// </returns>
        public double GetPosBaggingFraction() =>
            (double)Reference.Invoke("getPosBaggingFraction");
        
        /// <summary>
        /// Gets predictDisableShapeCheck value
        /// </summary>
        /// <returns>
        /// predictDisableShapeCheck: control whether or not LightGBM raises an error when you try to predict on data with a different number of features than the training data
        /// </returns>
        public bool GetPredictDisableShapeCheck() =>
            (bool)Reference.Invoke("getPredictDisableShapeCheck");
        
        /// <summary>
        /// Gets predictionCol value
        /// </summary>
        /// <returns>
        /// predictionCol: prediction column name
        /// </returns>
        public string GetPredictionCol() =>
            (string)Reference.Invoke("getPredictionCol");
        
        /// <summary>
        /// Gets repartitionByGroupingColumn value
        /// </summary>
        /// <returns>
        /// repartitionByGroupingColumn: Repartition training data according to grouping column, on by default.
        /// </returns>
        public bool GetRepartitionByGroupingColumn() =>
            (bool)Reference.Invoke("getRepartitionByGroupingColumn");
        
        /// <summary>
        /// Gets seed value
        /// </summary>
        /// <returns>
        /// seed: Main seed, used to generate other seeds
        /// </returns>
        public int GetSeed() =>
            (int)Reference.Invoke("getSeed");
        
        /// <summary>
        /// Gets skipDrop value
        /// </summary>
        /// <returns>
        /// skipDrop: Probability of skipping the dropout procedure during a boosting iteration
        /// </returns>
        public double GetSkipDrop() =>
            (double)Reference.Invoke("getSkipDrop");
        
        /// <summary>
        /// Gets slotNames value
        /// </summary>
        /// <returns>
        /// slotNames: List of slot names in the features column
        /// </returns>
        public string[] GetSlotNames() =>
            (string[])Reference.Invoke("getSlotNames");
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: Timeout in seconds
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Gets topK value
        /// </summary>
        /// <returns>
        /// topK: The top_k value used in Voting parallel, set this to larger value for more accurate result, but it will slow down the training speed. It should be greater than 0
        /// </returns>
        public int GetTopK() =>
            (int)Reference.Invoke("getTopK");
        
        /// <summary>
        /// Gets topRate value
        /// </summary>
        /// <returns>
        /// topRate: The retain ratio of large gradient data. Only used in goss.
        /// </returns>
        public double GetTopRate() =>
            (double)Reference.Invoke("getTopRate");
        
        /// <summary>
        /// Gets uniformDrop value
        /// </summary>
        /// <returns>
        /// uniformDrop: Set this to true to use uniform drop in dart mode
        /// </returns>
        public bool GetUniformDrop() =>
            (bool)Reference.Invoke("getUniformDrop");
        
        /// <summary>
        /// Gets useBarrierExecutionMode value
        /// </summary>
        /// <returns>
        /// useBarrierExecutionMode: Barrier execution mode which uses a barrier stage, off by default.
        /// </returns>
        public bool GetUseBarrierExecutionMode() =>
            (bool)Reference.Invoke("getUseBarrierExecutionMode");
        
        /// <summary>
        /// Gets useMissing value
        /// </summary>
        /// <returns>
        /// useMissing: Set this to false to disable the special handle of missing value
        /// </returns>
        public bool GetUseMissing() =>
            (bool)Reference.Invoke("getUseMissing");
        
        /// <summary>
        /// Gets useSingleDatasetMode value
        /// </summary>
        /// <returns>
        /// useSingleDatasetMode: Use single dataset execution mode to create a single native dataset per executor (singleton) to reduce memory and communication overhead.
        /// </returns>
        public bool GetUseSingleDatasetMode() =>
            (bool)Reference.Invoke("getUseSingleDatasetMode");
        
        /// <summary>
        /// Gets validationIndicatorCol value
        /// </summary>
        /// <returns>
        /// validationIndicatorCol: Indicates whether the row is for training or validation
        /// </returns>
        public string GetValidationIndicatorCol() =>
            (string)Reference.Invoke("getValidationIndicatorCol");
        
        /// <summary>
        /// Gets verbosity value
        /// </summary>
        /// <returns>
        /// verbosity: Verbosity where lt 0 is Fatal, eq 0 is Error, eq 1 is Info, gt 1 is Debug
        /// </returns>
        public int GetVerbosity() =>
            (int)Reference.Invoke("getVerbosity");
        
        /// <summary>
        /// Gets weightCol value
        /// </summary>
        /// <returns>
        /// weightCol: The name of the weight column
        /// </returns>
        public string GetWeightCol() =>
            (string)Reference.Invoke("getWeightCol");
        
        /// <summary>
        /// Gets xGBoostDartMode value
        /// </summary>
        /// <returns>
        /// xGBoostDartMode: Set this to true to use xgboost dart mode
        /// </returns>
        public bool GetXGBoostDartMode() =>
            (bool)Reference.Invoke("getXGBoostDartMode");
        
        /// <summary>
        /// Gets zeroAsMissing value
        /// </summary>
        /// <returns>
        /// zeroAsMissing: Set to true to treat all zero as missing values (including the unshown values in LibSVM / sparse matrices). Set to false to use na for representing missing values
        /// </returns>
        public bool GetZeroAsMissing() =>
            (bool)Reference.Invoke("getZeroAsMissing");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="LightGBMRankerModel"/></returns>
        override public LightGBMRankerModel Fit(DataFrame dataset) =>
            new LightGBMRankerModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="LightGBMRanker"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="LightGBMRanker"/> was saved to</param>
        /// <returns>New <see cref="LightGBMRanker"/> object, loaded from path.</returns>
        public static LightGBMRanker Load(string path) => WrapAsLightGBMRanker(
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
        /// <returns>an <see cref="JavaMLReader&lt;LightGBMRanker&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<LightGBMRanker> Read() =>
            new JavaMLReader<LightGBMRanker>((JvmObjectReference)Reference.Invoke("read"));
        private static LightGBMRanker WrapAsLightGBMRanker(object obj) =>
            new LightGBMRanker((JvmObjectReference)obj);
        
    }
}

        