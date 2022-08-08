
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' LightGBMClassifier
#'
#' @param baggingFraction Bagging fraction
#' @param baggingFreq Bagging frequency
#' @param baggingSeed Bagging seed
#' @param binSampleCount Number of samples considered at computing histogram bins
#' @param boostFromAverage Adjusts initial score to the mean of labels for faster convergence
#' @param boostingType Default gbdt = traditional Gradient Boosting Decision Tree. Options are: gbdt, gbrt, rf (Random Forest), random_forest, dart (Dropouts meet Multiple Additive Regression Trees), goss (Gradient-based One-Side Sampling). 
#' @param catSmooth this can reduce the effect of noises in categorical features, especially for categories with few data
#' @param categoricalSlotIndexes List of categorical column indexes, the slot index in the features column
#' @param categoricalSlotNames List of categorical column slot names, the slot name in the features column
#' @param catl2 L2 regularization in categorical split
#' @param chunkSize Advanced parameter to specify the chunk size for copying Java data to native.  If set too high, memory may be wasted, but if set too low, performance may be reduced during data copy.If dataset size is known beforehand, set to the number of rows in the dataset.
#' @param dataRandomSeed Random seed for sampling data to construct histogram bins.
#' @param defaultListenPort The default listen port on executors, used for testing
#' @param deterministic Used only with cpu devide type. Setting this to true should ensure stable results when using the same data and the same parameters.  Note: setting this to true may slow down training.  To avoid potential instability due to numerical issues, please set force_col_wise=true or force_row_wise=true when setting deterministic=true
#' @param driverListenPort The listen port on a driver. Default value is 0 (random)
#' @param dropRate Dropout rate: a fraction of previous trees to drop during the dropout
#' @param dropSeed Random seed to choose dropping models. Only used in dart.
#' @param earlyStoppingRound Early stopping round
#' @param executionMode Specify how LightGBM is executed.  Values can be streaming, bulk. Default is bulk.
#' @param extraSeed Random seed for selecting threshold when extra_trees is true
#' @param featureFraction Feature fraction
#' @param featureFractionByNode Feature fraction by node
#' @param featureFractionSeed Feature fraction seed
#' @param featuresCol features column name
#' @param featuresShapCol Output SHAP vector column name after prediction containing the feature contribution values
#' @param fobj Customized objective function. Should accept two parameters: preds, train_data, and return (grad, hess).
#' @param improvementTolerance Tolerance to consider improvement in metric
#' @param initScoreCol The name of the initial score column, used for continued training
#' @param isEnableSparse Used to enable/disable sparse optimization
#' @param isProvideTrainingMetric Whether output metric result over training dataset.
#' @param isUnbalance Set to true if training data is unbalanced in binary classification scenario
#' @param labelCol label column name
#' @param lambdaL1 L1 regularization
#' @param lambdaL2 L2 regularization
#' @param leafPredictionCol Predicted leaf indices's column name
#' @param learningRate Learning rate or shrinkage rate
#' @param matrixType Advanced parameter to specify whether the native lightgbm matrix constructed should be sparse or dense.  Values can be auto, sparse or dense. Default value is auto, which samples first ten rows to determine type.
#' @param maxBin Max bin
#' @param maxBinByFeature Max number of bins for each feature
#' @param maxCatThreshold limit number of split points considered for categorical features
#' @param maxCatToOnehot when number of categories of one feature smaller than or equal to this, one-vs-other split algorithm will be used
#' @param maxDeltaStep Used to limit the max output of tree leaves
#' @param maxDepth Max depth
#' @param maxDrop Max number of dropped trees during one boosting iteration
#' @param metric Metrics to be evaluated on the evaluation data.  Options are: empty string or not specified means that metric corresponding to specified objective will be used (this is possible only for pre-defined objective functions, otherwise no evaluation metric will be added). None (string, not a None value) means that no metric will be registered, aliases: na, null, custom. l1, absolute loss, aliases: mean_absolute_error, mae, regression_l1. l2, square loss, aliases: mean_squared_error, mse, regression_l2, regression. rmse, root square loss, aliases: root_mean_squared_error, l2_root. quantile, Quantile regression. mape, MAPE loss, aliases: mean_absolute_percentage_error. huber, Huber loss. fair, Fair loss. poisson, negative log-likelihood for Poisson regression. gamma, negative log-likelihood for Gamma regression. gamma_deviance, residual deviance for Gamma regression. tweedie, negative log-likelihood for Tweedie regression. ndcg, NDCG, aliases: lambdarank. map, MAP, aliases: mean_average_precision. auc, AUC. binary_logloss, log loss, aliases: binary. binary_error, for one sample: 0 for correct classification, 1 for error classification. multi_logloss, log loss for multi-class classification, aliases: multiclass, softmax, multiclassova, multiclass_ova, ova, ovr. multi_error, error rate for multi-class classification. cross_entropy, cross-entropy (with optional linear weights), aliases: xentropy. cross_entropy_lambda, intensity-weighted cross-entropy, aliases: xentlambda. kullback_leibler, Kullback-Leibler divergence, aliases: kldiv. 
#' @param microBatchSize Specify how many elements are sent in a streaming micro-batch.
#' @param minDataInLeaf Minimal number of data in one leaf. Can be used to deal with over-fitting.
#' @param minDataPerBin Minimal number of data inside one bin
#' @param minDataPerGroup minimal number of data per categorical group
#' @param minGainToSplit The minimal gain to perform split
#' @param minSumHessianInLeaf Minimal sum hessian in one leaf
#' @param modelString LightGBM model to retrain
#' @param monotoneConstraints used for constraints of monotonic features. 1 means increasing, -1 means decreasing, 0 means non-constraint. Specify all features in order.
#' @param monotoneConstraintsMethod Monotone constraints method. basic, intermediate, or advanced.
#' @param monotonePenalty A penalization parameter X forbids any monotone splits on the first X (rounded down) level(s) of the tree.
#' @param negBaggingFraction Negative Bagging fraction
#' @param numBatches If greater than 0, splits data into separate batches during training
#' @param numIterations Number of iterations, LightGBM constructs num_class * num_iterations trees
#' @param numLeaves Number of leaves
#' @param numTasks Advanced parameter to specify the number of tasks.  SynapseML tries to guess this based on cluster configuration, but this parameter can be used to override.
#' @param numThreads Number of threads per executor for LightGBM. For the best speed, set this to the number of real CPU cores.
#' @param objective The Objective. For regression applications, this can be: regression_l2, regression_l1, huber, fair, poisson, quantile, mape, gamma or tweedie. For classification applications, this can be: binary, multiclass, or multiclassova. 
#' @param objectiveSeed Random seed for objectives, if random process is needed.  Currently used only for rank_xendcg objective.
#' @param otherRate The retain ratio of small gradient data. Only used in goss.
#' @param parallelism Tree learner parallelism, can be set to data_parallel or voting_parallel
#' @param passThroughArgs Direct string to pass through to LightGBM library (appended with other explicitly set params). Will override any parameters given with explicit setters. Can include multiple parameters in one string.
#' @param posBaggingFraction Positive Bagging fraction
#' @param predictDisableShapeCheck control whether or not LightGBM raises an error when you try to predict on data with a different number of features than the training data
#' @param predictionCol prediction column name
#' @param probabilityCol Column name for predicted class conditional probabilities. Note: Not all models output well-calibrated probability estimates! These probabilities should be treated as confidences, not precise probabilities
#' @param rawPredictionCol raw prediction (a.k.a. confidence) column name
#' @param repartitionByGroupingColumn Repartition training data according to grouping column, on by default.
#' @param seed Main seed, used to generate other seeds
#' @param skipDrop Probability of skipping the dropout procedure during a boosting iteration
#' @param slotNames List of slot names in the features column
#' @param thresholds Thresholds in multi-class classification to adjust the probability of predicting each class. Array must have length equal to the number of classes, with values > 0 excepting that at most one value may be 0. The class with largest value p/t is predicted, where p is the original probability of that class and t is the class's threshold
#' @param timeout Timeout in seconds
#' @param topK The top_k value used in Voting parallel, set this to larger value for more accurate result, but it will slow down the training speed. It should be greater than 0
#' @param topRate The retain ratio of large gradient data. Only used in goss.
#' @param uniformDrop Set this to true to use uniform drop in dart mode
#' @param useBarrierExecutionMode Barrier execution mode which uses a barrier stage, off by default.
#' @param useMissing Set this to false to disable the special handle of missing value
#' @param useSingleDatasetMode Use single dataset execution mode to create a single native dataset per executor (singleton) to reduce memory and communication overhead.
#' @param validationIndicatorCol Indicates whether the row is for training or validation
#' @param verbosity Verbosity where lt 0 is Fatal, eq 0 is Error, eq 1 is Info, gt 1 is Debug
#' @param weightCol The name of the weight column
#' @param xGBoostDartMode Set this to true to use xgboost dart mode
#' @param zeroAsMissing Set to true to treat all zero as missing values (including the unshown values in LibSVM / sparse matrices). Set to false to use na for representing missing values
#' @export

ml_light_gbm_classifier <- function(
    x,
    baggingFraction=1.0,
    baggingFreq=0,
    baggingSeed=3,
    binSampleCount=200000,
    boostFromAverage=TRUE,
    boostingType="gbdt",
    catSmooth=10.0,
    categoricalSlotIndexes=c(),
    categoricalSlotNames=c(),
    catl2=10.0,
    chunkSize=10000,
    dataRandomSeed=1,
    defaultListenPort=12400,
    deterministic=FALSE,
    driverListenPort=0,
    dropRate=0.1,
    dropSeed=4,
    earlyStoppingRound=0,
    executionMode="bulk",
    extraSeed=6,
    featureFraction=1.0,
    featureFractionByNode=NULL,
    featureFractionSeed=2,
    featuresCol="features",
    featuresShapCol="",
    fobj=NULL,
    improvementTolerance=0.0,
    initScoreCol=NULL,
    isEnableSparse=TRUE,
    isProvideTrainingMetric=FALSE,
    isUnbalance=FALSE,
    labelCol="label",
    lambdaL1=0.0,
    lambdaL2=0.0,
    leafPredictionCol="",
    learningRate=0.1,
    matrixType="auto",
    maxBin=255,
    maxBinByFeature=c(),
    maxCatThreshold=32,
    maxCatToOnehot=4,
    maxDeltaStep=0.0,
    maxDepth=-1,
    maxDrop=50,
    metric="",
    microBatchSize=1,
    minDataInLeaf=20,
    minDataPerBin=3,
    minDataPerGroup=100,
    minGainToSplit=0.0,
    minSumHessianInLeaf=0.001,
    modelString="",
    monotoneConstraints=c(),
    monotoneConstraintsMethod="basic",
    monotonePenalty=0.0,
    negBaggingFraction=1.0,
    numBatches=0,
    numIterations=100,
    numLeaves=31,
    numTasks=0,
    numThreads=0,
    objective="binary",
    objectiveSeed=5,
    otherRate=0.1,
    parallelism="data_parallel",
    passThroughArgs="",
    posBaggingFraction=1.0,
    predictDisableShapeCheck=FALSE,
    predictionCol="prediction",
    probabilityCol="probability",
    rawPredictionCol="rawPrediction",
    repartitionByGroupingColumn=TRUE,
    seed=NULL,
    skipDrop=0.5,
    slotNames=c(),
    thresholds=NULL,
    timeout=1200.0,
    topK=20,
    topRate=0.2,
    uniformDrop=FALSE,
    useBarrierExecutionMode=FALSE,
    useMissing=TRUE,
    useSingleDatasetMode=TRUE,
    validationIndicatorCol=NULL,
    verbosity=-1,
    weightCol=NULL,
    xGBoostDartMode=FALSE,
    zeroAsMissing=FALSE,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_light_gbm_classifier"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.lightgbm.LightGBMClassifier"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBaggingFraction", as.double(baggingFraction)) %>%
        invoke("setBaggingFreq", as.integer(baggingFreq)) %>%
        invoke("setBaggingSeed", as.integer(baggingSeed)) %>%
        invoke("setBinSampleCount", as.integer(binSampleCount)) %>%
        invoke("setBoostFromAverage", as.logical(boostFromAverage)) %>%
        invoke("setBoostingType", boostingType) %>%
        invoke("setCatSmooth", as.double(catSmooth)) %>%
        invoke("setCategoricalSlotIndexes", as.array(categoricalSlotIndexes)) %>%
        invoke("setCategoricalSlotNames", as.array(categoricalSlotNames)) %>%
        invoke("setCatl2", as.double(catl2)) %>%
        invoke("setChunkSize", as.integer(chunkSize)) %>%
        invoke("setDataRandomSeed", as.integer(dataRandomSeed)) %>%
        invoke("setDefaultListenPort", as.integer(defaultListenPort)) %>%
        invoke("setDeterministic", as.logical(deterministic)) %>%
        invoke("setDriverListenPort", as.integer(driverListenPort)) %>%
        invoke("setDropRate", as.double(dropRate)) %>%
        invoke("setDropSeed", as.integer(dropSeed)) %>%
        invoke("setEarlyStoppingRound", as.integer(earlyStoppingRound)) %>%
        invoke("setExecutionMode", executionMode) %>%
        invoke("setExtraSeed", as.integer(extraSeed)) %>%
        invoke("setFeatureFraction", as.double(featureFraction)) %>%
        invoke("setFeatureFractionByNode", as.double(featureFractionByNode)) %>%
        invoke("setFeatureFractionSeed", as.integer(featureFractionSeed)) %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setFeaturesShapCol", featuresShapCol) %>%
        invoke("setFobj", fobj) %>%
        invoke("setImprovementTolerance", as.double(improvementTolerance)) %>%
        invoke("setInitScoreCol", initScoreCol) %>%
        invoke("setIsEnableSparse", as.logical(isEnableSparse)) %>%
        invoke("setIsProvideTrainingMetric", as.logical(isProvideTrainingMetric)) %>%
        invoke("setIsUnbalance", as.logical(isUnbalance)) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setLambdaL1", as.double(lambdaL1)) %>%
        invoke("setLambdaL2", as.double(lambdaL2)) %>%
        invoke("setLeafPredictionCol", leafPredictionCol) %>%
        invoke("setLearningRate", as.double(learningRate)) %>%
        invoke("setMatrixType", matrixType) %>%
        invoke("setMaxBin", as.integer(maxBin)) %>%
        invoke("setMaxBinByFeature", as.array(maxBinByFeature)) %>%
        invoke("setMaxCatThreshold", as.integer(maxCatThreshold)) %>%
        invoke("setMaxCatToOnehot", as.integer(maxCatToOnehot)) %>%
        invoke("setMaxDeltaStep", as.double(maxDeltaStep)) %>%
        invoke("setMaxDepth", as.integer(maxDepth)) %>%
        invoke("setMaxDrop", as.integer(maxDrop)) %>%
        invoke("setMetric", metric) %>%
        invoke("setMicroBatchSize", as.integer(microBatchSize)) %>%
        invoke("setMinDataInLeaf", as.integer(minDataInLeaf)) %>%
        invoke("setMinDataPerBin", as.integer(minDataPerBin)) %>%
        invoke("setMinDataPerGroup", as.integer(minDataPerGroup)) %>%
        invoke("setMinGainToSplit", as.double(minGainToSplit)) %>%
        invoke("setMinSumHessianInLeaf", as.double(minSumHessianInLeaf)) %>%
        invoke("setModelString", modelString) %>%
        invoke("setMonotoneConstraints", as.array(monotoneConstraints)) %>%
        invoke("setMonotoneConstraintsMethod", monotoneConstraintsMethod) %>%
        invoke("setMonotonePenalty", as.double(monotonePenalty)) %>%
        invoke("setNegBaggingFraction", as.double(negBaggingFraction)) %>%
        invoke("setNumBatches", as.integer(numBatches)) %>%
        invoke("setNumIterations", as.integer(numIterations)) %>%
        invoke("setNumLeaves", as.integer(numLeaves)) %>%
        invoke("setNumTasks", as.integer(numTasks)) %>%
        invoke("setNumThreads", as.integer(numThreads)) %>%
        invoke("setObjective", objective) %>%
        invoke("setObjectiveSeed", as.integer(objectiveSeed)) %>%
        invoke("setOtherRate", as.double(otherRate)) %>%
        invoke("setParallelism", parallelism) %>%
        invoke("setPassThroughArgs", passThroughArgs) %>%
        invoke("setPosBaggingFraction", as.double(posBaggingFraction)) %>%
        invoke("setPredictDisableShapeCheck", as.logical(predictDisableShapeCheck)) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setProbabilityCol", probabilityCol) %>%
        invoke("setRawPredictionCol", rawPredictionCol) %>%
        invoke("setRepartitionByGroupingColumn", as.logical(repartitionByGroupingColumn)) %>%
        invoke("setSeed", as.integer(seed)) %>%
        invoke("setSkipDrop", as.double(skipDrop)) %>%
        invoke("setSlotNames", as.array(slotNames)) %>%
        invoke("setThresholds", as.array(thresholds)) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setTopK", as.integer(topK)) %>%
        invoke("setTopRate", as.double(topRate)) %>%
        invoke("setUniformDrop", as.logical(uniformDrop)) %>%
        invoke("setUseBarrierExecutionMode", as.logical(useBarrierExecutionMode)) %>%
        invoke("setUseMissing", as.logical(useMissing)) %>%
        invoke("setUseSingleDatasetMode", as.logical(useSingleDatasetMode)) %>%
        invoke("setValidationIndicatorCol", validationIndicatorCol) %>%
        invoke("setVerbosity", as.integer(verbosity)) %>%
        invoke("setWeightCol", weightCol) %>%
        invoke("setXGBoostDartMode", as.logical(xGBoostDartMode)) %>%
        invoke("setZeroAsMissing", as.logical(zeroAsMissing))
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.lightgbm.LightGBMClassificationModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
