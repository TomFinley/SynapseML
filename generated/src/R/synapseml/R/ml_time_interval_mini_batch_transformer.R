
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TimeIntervalMiniBatchTransformer
#'
#' @param maxBatchSize The max size of the buffer
#' @param millisToWait The time to wait before constructing a batch
#' @export

ml_time_interval_mini_batch_transformer <- function(
    x,
    maxBatchSize=2147483647,
    millisToWait=NULL,
    only.model=FALSE,
    uid=random_string("ml_time_interval_mini_batch_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.TimeIntervalMiniBatchTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setMaxBatchSize", as.integer(maxBatchSize)) %>%
        invoke("setMillisToWait", as.integer(millisToWait))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
