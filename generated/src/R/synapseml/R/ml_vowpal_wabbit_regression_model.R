
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' VowpalWabbitRegressionModel
#'
#' @param additionalFeatures Additional feature columns
#' @param featuresCol features column name
#' @param labelCol label column name
#' @param model The VW model....
#' @param performanceStatistics Performance statistics collected during training
#' @param predictionCol prediction column name
#' @param rawPredictionCol raw prediction (a.k.a. confidence) column name
#' @param testArgs Additional arguments passed to VW at test time
#' @export

ml_vowpal_wabbit_regression_model <- function(
    x,
    additionalFeatures=NULL,
    featuresCol="features",
    labelCol="label",
    model=NULL,
    performanceStatistics=NULL,
    predictionCol="prediction",
    rawPredictionCol="rawPrediction",
    testArgs="",
    only.model=FALSE,
    uid=random_string("ml_vowpal_wabbit_regression_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.vw.VowpalWabbitRegressionModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAdditionalFeatures", as.array(additionalFeatures)) %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setModel", model) %>%
        invoke("setPerformanceStatistics", performanceStatistics) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setRawPredictionCol", rawPredictionCol) %>%
        invoke("setTestArgs", testArgs)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
