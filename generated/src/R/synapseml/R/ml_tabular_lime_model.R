
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TabularLIMEModel
#'
#' @param columnSTDs the standard deviations of each of the columns for perturbation
#' @param inputCol The name of the input column
#' @param model Model to try to locally approximate
#' @param nSamples The number of samples to generate
#' @param outputCol The name of the output column
#' @param predictionCol prediction column name
#' @param regularization regularization param for the lasso
#' @param samplingFraction The fraction of superpixels to keep on
#' @export

ml_tabular_lime_model <- function(
    x,
    columnSTDs=NULL,
    inputCol=NULL,
    model=NULL,
    nSamples=NULL,
    outputCol=NULL,
    predictionCol="prediction",
    regularization=NULL,
    samplingFraction=NULL,
    only.model=FALSE,
    uid=random_string("ml_tabular_lime_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.lime.TabularLIMEModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setColumnSTDs", as.array(columnSTDs)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setModel", model) %>%
        invoke("setNSamples", as.integer(nSamples)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setRegularization", as.double(regularization)) %>%
        invoke("setSamplingFraction", as.double(samplingFraction))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
