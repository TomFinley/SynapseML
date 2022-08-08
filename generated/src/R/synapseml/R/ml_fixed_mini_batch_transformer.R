
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' FixedMiniBatchTransformer
#'
#' @param batchSize The max size of the buffer
#' @param buffered Whether or not to buffer batches in memory
#' @param maxBufferSize The max size of the buffer
#' @export

ml_fixed_mini_batch_transformer <- function(
    x,
    batchSize=NULL,
    buffered=FALSE,
    maxBufferSize=2147483647,
    only.model=FALSE,
    uid=random_string("ml_fixed_mini_batch_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.FixedMiniBatchTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBatchSize", as.integer(batchSize)) %>%
        invoke("setBuffered", as.logical(buffered)) %>%
        invoke("setMaxBufferSize", as.integer(maxBufferSize))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
