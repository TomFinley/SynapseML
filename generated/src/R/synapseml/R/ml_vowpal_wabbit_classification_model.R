
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' VowpalWabbitClassificationModel
#'
#' @param additionalFeatures Additional feature columns
#' @param featuresCol features column name
#' @param labelCol label column name
#' @param model The VW model....
#' @param performanceStatistics Performance statistics collected during training
#' @param predictionCol prediction column name
#' @param probabilityCol Column name for predicted class conditional probabilities. Note: Not all models output well-calibrated probability estimates! These probabilities should be treated as confidences, not precise probabilities
#' @param rawPredictionCol raw prediction (a.k.a. confidence) column name
#' @param testArgs Additional arguments passed to VW at test time
#' @param thresholds Thresholds in multi-class classification to adjust the probability of predicting each class. Array must have length equal to the number of classes, with values > 0 excepting that at most one value may be 0. The class with largest value p/t is predicted, where p is the original probability of that class and t is the class's threshold
#' @export

ml_vowpal_wabbit_classification_model <- function(
    x,
    additionalFeatures=NULL,
    featuresCol="features",
    labelCol="label",
    model=NULL,
    performanceStatistics=NULL,
    predictionCol="prediction",
    probabilityCol="probability",
    rawPredictionCol="rawPrediction",
    testArgs="",
    thresholds=NULL,
    only.model=FALSE,
    uid=random_string("ml_vowpal_wabbit_classification_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.vw.VowpalWabbitClassificationModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAdditionalFeatures", as.array(additionalFeatures)) %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setModel", model) %>%
        invoke("setPerformanceStatistics", performanceStatistics) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setProbabilityCol", probabilityCol) %>%
        invoke("setRawPredictionCol", rawPredictionCol) %>%
        invoke("setTestArgs", testArgs) %>%
        invoke("setThresholds", as.array(thresholds))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
