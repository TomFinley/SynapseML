
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' LightGBMRegressionModel
#'
#' @param featuresCol features column name
#' @param featuresShapCol Output SHAP vector column name after prediction containing the feature contribution values
#' @param labelCol label column name
#' @param leafPredictionCol Predicted leaf indices's column name
#' @param lightGBMBooster The trained LightGBM booster
#' @param numIterations Sets the total number of iterations used in the prediction.If <= 0, all iterations from ``start_iteration`` are used (no limits).
#' @param predictDisableShapeCheck control whether or not LightGBM raises an error when you try to predict on data with a different number of features than the training data
#' @param predictionCol prediction column name
#' @param startIteration Sets the start index of the iteration to predict. If <= 0, starts from the first iteration.
#' @export

ml_light_gbm_regression_model <- function(
    x,
    featuresCol="features",
    featuresShapCol="",
    labelCol="label",
    leafPredictionCol="",
    lightGBMBooster=NULL,
    numIterations=-1,
    predictDisableShapeCheck=FALSE,
    predictionCol="prediction",
    startIteration=0,
    only.model=FALSE,
    uid=random_string("ml_light_gbm_regression_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.lightgbm.LightGBMRegressionModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setFeaturesShapCol", featuresShapCol) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setLeafPredictionCol", leafPredictionCol) %>%
        invoke("setLightGBMBooster", lightGBMBooster) %>%
        invoke("setNumIterations", as.integer(numIterations)) %>%
        invoke("setPredictDisableShapeCheck", as.logical(predictDisableShapeCheck)) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setStartIteration", as.integer(startIteration))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
