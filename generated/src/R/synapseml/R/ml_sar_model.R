
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' SARModel
#'
#' @param activityTimeFormat Time format for events, default: yyyy/MM/dd'T'h:mm:ss
#' @param alpha alpha for implicit preference
#' @param blockSize block size for stacking input data in matrices. Data is stacked within partitions. If block size is more than remaining data in a partition then it is adjusted to the size of this data.
#' @param checkpointInterval set checkpoint interval (>= 1) or disable checkpoint (-1). E.g. 10 means that the cache will get checkpointed every 10 iterations. Note: this setting will be ignored if the checkpoint directory is not set in the SparkContext
#' @param coldStartStrategy strategy for dealing with unknown or new users/items at prediction time. This may be useful in cross-validation or production scenarios, for handling user/item ids the model has not seen in the training data. Supported values: nan,drop.
#' @param finalStorageLevel StorageLevel for ALS model factors.
#' @param implicitPrefs whether to use implicit preference
#' @param intermediateStorageLevel StorageLevel for intermediate datasets. Cannot be 'NONE'.
#' @param itemCol column name for item ids. Ids must be within the integer value range.
#' @param itemDataFrame Time of activity
#' @param maxIter maximum number of iterations (>= 0)
#' @param nonnegative whether to use nonnegative constraint for least squares
#' @param numItemBlocks number of item blocks
#' @param numUserBlocks number of user blocks
#' @param predictionCol prediction column name
#' @param rank rank of the factorization
#' @param ratingCol column name for ratings
#' @param regParam regularization parameter (>= 0)
#' @param seed random seed
#' @param similarityFunction Defines the similarity function to be used by the model. Lift favors serendipity, Co-occurrence favors predictability, and Jaccard is a nice compromise between the two.
#' @param startTime Set time custom now time if using historical data
#' @param startTimeFormat Format for start time
#' @param supportThreshold Minimum number of ratings per item
#' @param timeCol Time of activity
#' @param timeDecayCoeff Use to scale time decay coeff to different half life dur
#' @param userCol column name for user ids. Ids must be within the integer value range.
#' @param userDataFrame Time of activity
#' @export

ml_sar_model <- function(
    x,
    activityTimeFormat="yyyy/MM/dd'T'h:mm:ss",
    alpha=1.0,
    blockSize=4096,
    checkpointInterval=10,
    coldStartStrategy="nan",
    finalStorageLevel="MEMORY_AND_DISK",
    implicitPrefs=FALSE,
    intermediateStorageLevel="MEMORY_AND_DISK",
    itemCol="item",
    itemDataFrame=NULL,
    maxIter=10,
    nonnegative=FALSE,
    numItemBlocks=10,
    numUserBlocks=10,
    predictionCol="prediction",
    rank=10,
    ratingCol="rating",
    regParam=0.1,
    seed=-1453370660,
    similarityFunction="jaccard",
    startTime=NULL,
    startTimeFormat="EEE MMM dd HH:mm:ss Z yyyy",
    supportThreshold=4,
    timeCol="time",
    timeDecayCoeff=30,
    userCol="user",
    userDataFrame=NULL,
    only.model=FALSE,
    uid=random_string("ml_sar_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.recommendation.SARModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setActivityTimeFormat", activityTimeFormat) %>%
        invoke("setAlpha", as.double(alpha)) %>%
        invoke("setBlockSize", as.integer(blockSize)) %>%
        invoke("setCheckpointInterval", as.integer(checkpointInterval)) %>%
        invoke("setColdStartStrategy", coldStartStrategy) %>%
        invoke("setFinalStorageLevel", finalStorageLevel) %>%
        invoke("setImplicitPrefs", as.logical(implicitPrefs)) %>%
        invoke("setIntermediateStorageLevel", intermediateStorageLevel) %>%
        invoke("setItemCol", itemCol) %>%
        invoke("setItemDataFrame", itemDataFrame) %>%
        invoke("setMaxIter", as.integer(maxIter)) %>%
        invoke("setNonnegative", as.logical(nonnegative)) %>%
        invoke("setNumItemBlocks", as.integer(numItemBlocks)) %>%
        invoke("setNumUserBlocks", as.integer(numUserBlocks)) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setRank", as.integer(rank)) %>%
        invoke("setRatingCol", ratingCol) %>%
        invoke("setRegParam", as.double(regParam)) %>%
        invoke("setSeed", as.integer(seed)) %>%
        invoke("setSimilarityFunction", similarityFunction) %>%
        invoke("setStartTime", startTime) %>%
        invoke("setStartTimeFormat", startTimeFormat) %>%
        invoke("setSupportThreshold", as.integer(supportThreshold)) %>%
        invoke("setTimeCol", timeCol) %>%
        invoke("setTimeDecayCoeff", as.integer(timeDecayCoeff)) %>%
        invoke("setUserCol", userCol) %>%
        invoke("setUserDataFrame", userDataFrame)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
