
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ImageLIME
#'
#' @param cellSize Number that controls the size of the superpixels
#' @param inputCol The name of the input column
#' @param model Model to try to locally approximate
#' @param modifier Controls the trade-off spatial and color distance
#' @param nSamples The number of samples to generate
#' @param outputCol The name of the output column
#' @param predictionCol prediction column name
#' @param regularization regularization param for the lasso
#' @param samplingFraction The fraction of superpixels to keep on
#' @param superpixelCol The column holding the superpixel decompositions
#' @export

ml_image_lime <- function(
    x,
    cellSize=16.0,
    inputCol=NULL,
    model=NULL,
    modifier=130.0,
    nSamples=900,
    outputCol=NULL,
    predictionCol="prediction",
    regularization=0.0,
    samplingFraction=0.3,
    superpixelCol="superpixels",
    only.model=FALSE,
    uid=random_string("ml_image_lime"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.lime.ImageLIME"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setCellSize", as.double(cellSize)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setModel", model) %>%
        invoke("setModifier", as.double(modifier)) %>%
        invoke("setNSamples", as.integer(nSamples)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setRegularization", as.double(regularization)) %>%
        invoke("setSamplingFraction", as.double(samplingFraction)) %>%
        invoke("setSuperpixelCol", superpixelCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
