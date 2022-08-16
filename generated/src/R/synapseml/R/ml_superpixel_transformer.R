
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' SuperpixelTransformer
#'
#' @param cellSize Number that controls the size of the superpixels
#' @param inputCol The name of the input column
#' @param modifier Controls the trade-off spatial and color distance
#' @param outputCol The name of the output column
#' @export

ml_superpixel_transformer <- function(
    x,
    cellSize=16.0,
    inputCol=NULL,
    modifier=130.0,
    outputCol="SuperpixelTransformer_37e156ff6ac7_output",
    only.model=FALSE,
    uid=random_string("ml_superpixel_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.lime.SuperpixelTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setCellSize", as.double(cellSize)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setModifier", as.double(modifier)) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
