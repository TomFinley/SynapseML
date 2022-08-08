
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' PartitionConsolidator
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param inputCol The name of the input column
#' @param outputCol The name of the output column
#' @param timeout number of seconds to wait before closing the connection
#' @export

ml_partition_consolidator <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    inputCol=NULL,
    outputCol=NULL,
    timeout=60.0,
    only.model=FALSE,
    uid=random_string("ml_partition_consolidator"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.PartitionConsolidator"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setTimeout", as.double(timeout))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
