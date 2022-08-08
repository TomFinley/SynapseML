
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' VowpalWabbitInteractions
#'
#' @param inputCols The names of the input columns
#' @param numBits Number of bits used to mask
#' @param outputCol The name of the output column
#' @param sumCollisions Sums collisions if true, otherwise removes them
#' @export

ml_vowpal_wabbit_interactions <- function(
    x,
    inputCols=NULL,
    numBits=30,
    outputCol=NULL,
    sumCollisions=TRUE,
    only.model=FALSE,
    uid=random_string("ml_vowpal_wabbit_interactions"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.vw.VowpalWabbitInteractions"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setNumBits", as.integer(numBits)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSumCollisions", as.logical(sumCollisions))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
