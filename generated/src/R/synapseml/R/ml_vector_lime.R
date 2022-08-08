
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' VectorLIME
#'
#' @param backgroundData A dataframe containing background data
#' @param inputCol input column name
#' @param kernelWidth Kernel width. Default value: sqrt (number of features) * 0.75
#' @param metricsCol Column name for fitting metrics
#' @param model The model to be interpreted.
#' @param numSamples Number of samples to generate.
#' @param outputCol output column name
#' @param regularization Regularization param for the lasso. Default value: 0.
#' @param targetClasses The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
#' @param targetClassesCol The name of the column that specifies the indices of the classes for multinomial classification models.
#' @param targetCol The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
#' @export

ml_vector_lime <- function(
    x,
    backgroundData=NULL,
    inputCol=NULL,
    kernelWidth=0.75,
    metricsCol="r2",
    model=NULL,
    numSamples=1000,
    outputCol="VectorLIME_29816ec240d2__output",
    regularization=0.0,
    targetClasses=c(),
    targetClassesCol=NULL,
    targetCol="probability",
    only.model=FALSE,
    uid=random_string("ml_vector_lime"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.explainers.VectorLIME"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBackgroundData", backgroundData) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setKernelWidth", as.double(kernelWidth)) %>%
        invoke("setMetricsCol", metricsCol) %>%
        invoke("setModel", model) %>%
        invoke("setNumSamples", as.integer(numSamples)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setRegularization", as.double(regularization)) %>%
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
