
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TabularSHAP
#'
#' @param backgroundData A dataframe containing background data
#' @param infWeight The double value to represent infinite weight. Default: 1E8.
#' @param inputCols input column names
#' @param metricsCol Column name for fitting metrics
#' @param model The model to be interpreted.
#' @param numSamples Number of samples to generate.
#' @param outputCol output column name
#' @param targetClasses The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
#' @param targetClassesCol The name of the column that specifies the indices of the classes for multinomial classification models.
#' @param targetCol The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
#' @export

ml_tabular_shap <- function(
    x,
    backgroundData=NULL,
    infWeight=1.0E+8,
    inputCols=NULL,
    metricsCol="r2",
    model=NULL,
    numSamples=NULL,
    outputCol="TabularSHAP_dd0da21e09cf__output",
    targetClasses=c(),
    targetClassesCol=NULL,
    targetCol="probability",
    only.model=FALSE,
    uid=random_string("ml_tabular_shap"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.explainers.TabularSHAP"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBackgroundData", backgroundData) %>%
        invoke("setInfWeight", as.double(infWeight)) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setMetricsCol", metricsCol) %>%
        invoke("setModel", model) %>%
        invoke("setNumSamples", as.integer(numSamples)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setTargetClasses", as.array(targetClasses)) %>%
        invoke("setTargetClassesCol", targetClassesCol) %>%
        invoke("setTargetCol", targetCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
