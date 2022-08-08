
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' DynamicMiniBatchTransformer
#'
#' @param maxBatchSize The max size of the buffer
#' @export

ml_dynamic_mini_batch_transformer <- function(
    x,
    maxBatchSize=2147483647,
    only.model=FALSE,
    uid=random_string("ml_dynamic_mini_batch_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.DynamicMiniBatchTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setMaxBatchSize", as.integer(maxBatchSize))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
