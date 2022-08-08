
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ImageFeaturizer
#'
#' @param cntkModel The internal CNTK model used in the featurizer
#' @param cutOutputLayers The number of layers to cut off the end of the network, 0 leaves the network intact, 1 removes the output layer, etc
#' @param dropNa Whether to drop na values before mapping
#' @param inputCol The name of the input column
#' @param layerNames Array with valid CNTK nodes to choose from, the first entries of this array should be closer to the output node
#' @param outputCol The name of the output column
#' @export

ml_image_featurizer <- function(
    x,
    cntkModel=NULL,
    cutOutputLayers=1,
    dropNa=TRUE,
    inputCol=NULL,
    layerNames=NULL,
    outputCol="ImageFeaturizer_1f1dd0f4c65b_output",
    only.model=FALSE,
    uid=random_string("ml_image_featurizer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cntk.ImageFeaturizer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setCntkModel", cntkModel) %>%
        invoke("setCutOutputLayers", as.integer(cutOutputLayers)) %>%
        invoke("setDropNa", as.logical(dropNa)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setLayerNames", as.array(layerNames)) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
