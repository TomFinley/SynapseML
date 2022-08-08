
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' RankingTrainValidationSplit
#'
#' @param alpha alpha for implicit preference
#' @param blockSize block size for stacking input data in matrices. Data is stacked within partitions. If block size is more than remaining data in a partition then it is adjusted to the size of this data.
#' @param checkpointInterval set checkpoint interval (>= 1) or disable checkpoint (-1). E.g. 10 means that the cache will get checkpointed every 10 iterations. Note: this setting will be ignored if the checkpoint directory is not set in the SparkContext
#' @param coldStartStrategy strategy for dealing with unknown or new users/items at prediction time. This may be useful in cross-validation or production scenarios, for handling user/item ids the model has not seen in the training data. Supported values: nan,drop.
#' @param estimator estimator for selection
#' @param estimatorParamMaps param maps for the estimator
#' @param evaluator evaluator used to select hyper-parameters that maximize the validated metric
#' @param finalStorageLevel StorageLevel for ALS model factors.
#' @param implicitPrefs whether to use implicit preference
#' @param intermediateStorageLevel StorageLevel for intermediate datasets. Cannot be 'NONE'.
#' @param itemCol column name for item ids. Ids must be within the integer value range.
#' @param maxIter maximum number of iterations (>= 0)
#' @param minRatingsI min ratings for items > 0
#' @param minRatingsU min ratings for users > 0
#' @param nonnegative whether to use nonnegative constraint for least squares
#' @param numItemBlocks number of item blocks
#' @param numUserBlocks number of user blocks
#' @param parallelism the number of threads to use when running parallel algorithms
#' @param predictionCol prediction column name
#' @param rank rank of the factorization
#' @param ratingCol column name for ratings
#' @param regParam regularization parameter (>= 0)
#' @param seed random seed
#' @param trainRatio ratio between training set and validation set (>= 0 and <= 1)
#' @param userCol column name for user ids. Ids must be within the integer value range.
#' @export

ml_ranking_train_validation_split <- function(
    x,
    alpha=1.0,
    blockSize=4096,
    checkpointInterval=10,
    coldStartStrategy="nan",
    estimator=NULL,
    estimatorParamMaps=NULL,
    evaluator=NULL,
    finalStorageLevel="MEMORY_AND_DISK",
    implicitPrefs=FALSE,
    intermediateStorageLevel="MEMORY_AND_DISK",
    itemCol="item",
    maxIter=10,
    minRatingsI=1,
    minRatingsU=1,
    nonnegative=FALSE,
    numItemBlocks=10,
    numUserBlocks=10,
    parallelism=1,
    predictionCol="prediction",
    rank=10,
    ratingCol="rating",
    regParam=0.1,
    seed=-492944968,
    trainRatio=0.75,
    userCol="user",
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_ranking_train_validation_split"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.recommendation.RankingTrainValidationSplit"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAlpha", as.double(alpha)) %>%
        invoke("setBlockSize", as.integer(blockSize)) %>%
        invoke("setCheckpointInterval", as.integer(checkpointInterval)) %>%
        invoke("setColdStartStrategy", coldStartStrategy) %>%
        invoke("setEstimator", estimator) %>%
        invoke("setEstimatorParamMaps", estimatorParamMaps) %>%
        invoke("setEvaluator", evaluator) %>%
        invoke("setFinalStorageLevel", finalStorageLevel) %>%
        invoke("setImplicitPrefs", as.logical(implicitPrefs)) %>%
        invoke("setIntermediateStorageLevel", intermediateStorageLevel) %>%
        invoke("setItemCol", itemCol) %>%
        invoke("setMaxIter", as.integer(maxIter)) %>%
        invoke("setMinRatingsI", as.integer(minRatingsI)) %>%
        invoke("setMinRatingsU", as.integer(minRatingsU)) %>%
        invoke("setNonnegative", as.logical(nonnegative)) %>%
        invoke("setNumItemBlocks", as.integer(numItemBlocks)) %>%
        invoke("setNumUserBlocks", as.integer(numUserBlocks)) %>%
        invoke("setParallelism", as.integer(parallelism)) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setRank", as.integer(rank)) %>%
        invoke("setRatingCol", ratingCol) %>%
        invoke("setRegParam", as.double(regParam)) %>%
        invoke("setSeed", as.integer(seed)) %>%
        invoke("setTrainRatio", as.double(trainRatio)) %>%
        invoke("setUserCol", userCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.recommendation.RankingTrainValidationSplitModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
