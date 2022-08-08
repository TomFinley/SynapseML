
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' IsolationForestModel
#'
#' @param bootstrap If true, draw sample for each tree with replacement. If false, do not sample with replacement.
#' @param contamination The fraction of outliers in the training data set. If this is set to 0.0, it speeds up the training and all predicted labels will be false. The model and outlier scores are otherwise unaffected by this parameter.
#' @param contaminationError The error allowed when calculating the threshold required to achieve the specified contamination fraction. The default is 0.0, which forces an exact calculation of the threshold. The exact calculation is slow and can fail for large datasets. If there are issues with the exact calculation, a good choice for this parameter is often 1% of the specified contamination value.
#' @param featuresCol The feature vector.
#' @param innerModel the fit isolation forrest instance
#' @param maxFeatures The number of features used to train each tree. If this value is between 0.0 and 1.0, then it is treated as a fraction. If it is >1.0, then it is treated as a count.
#' @param maxSamples The number of samples used to train each tree. If this value is between 0.0 and 1.0, then it is treated as a fraction. If it is >1.0, then it is treated as a count.
#' @param numEstimators The number of trees in the ensemble.
#' @param predictionCol The predicted label.
#' @param randomSeed The seed used for the random number generator.
#' @param scoreCol The outlier score.
#' @export

ml_isolation_forest_model <- function(
    x,
    bootstrap=FALSE,
    contamination=0.0,
    contaminationError=0.0,
    featuresCol="features",
    innerModel=NULL,
    maxFeatures=1.0,
    maxSamples=256.0,
    numEstimators=100,
    predictionCol="predictedLabel",
    randomSeed=1,
    scoreCol="outlierScore",
    only.model=FALSE,
    uid=random_string("ml_isolation_forest_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.isolationforest.IsolationForestModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBootstrap", as.logical(bootstrap)) %>%
        invoke("setContamination", as.double(contamination)) %>%
        invoke("setContaminationError", as.double(contaminationError)) %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setInnerModel", innerModel) %>%
        invoke("setMaxFeatures", as.double(maxFeatures)) %>%
        invoke("setMaxSamples", as.double(maxSamples)) %>%
        invoke("setNumEstimators", as.integer(numEstimators)) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setRandomSeed", as.integer(randomSeed)) %>%
        invoke("setScoreCol", scoreCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
