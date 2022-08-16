
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ImageSHAP
#'
#' @param cellSize Number that controls the size of the superpixels
#' @param infWeight The double value to represent infinite weight. Default: 1E8.
#' @param inputCol input column name
#' @param metricsCol Column name for fitting metrics
#' @param model The model to be interpreted.
#' @param modifier Controls the trade-off spatial and color distance
#' @param numSamples Number of samples to generate.
#' @param outputCol output column name
#' @param superpixelCol The column holding the superpixel decompositions
#' @param targetClasses The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
#' @param targetClassesCol The name of the column that specifies the indices of the classes for multinomial classification models.
#' @param targetCol The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
#' @export

ml_image_shap <- function(
    x,
    cellSize=16.0,
    infWeight=1.0E+8,
    inputCol=NULL,
    metricsCol="r2",
    model=NULL,
    modifier=130.0,
    numSamples=NULL,
    outputCol="ImageSHAP_5e1ecd221e49__output",
    superpixelCol="superpixels",
    targetClasses=c(),
    targetClassesCol=NULL,
    targetCol="probability",
    only.model=FALSE,
    uid=random_string("ml_image_shap"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.explainers.ImageSHAP"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setCellSize", as.double(cellSize)) %>%
        invoke("setInfWeight", as.double(infWeight)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setMetricsCol", metricsCol) %>%
        invoke("setModel", model) %>%
        invoke("setModifier", as.double(modifier)) %>%
        invoke("setNumSamples", as.integer(numSamples)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSuperpixelCol", superpixelCol) %>%
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
