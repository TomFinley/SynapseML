
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' SimpleHTTPTransformer
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param flattenOutputBatches whether to flatten the output batches
#' @param handler Which strategy to use when handling requests
#' @param inputCol The name of the input column
#' @param inputParser format to parse the column to
#' @param miniBatcher Minibatcher to use
#' @param outputCol The name of the output column
#' @param outputParser format to parse the column to
#' @param timeout number of seconds to wait before closing the connection
#' @export

ml_simple_http_transformer <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="SimpleHTTPTransformer_c6a4e3b1f74c_errors",
    flattenOutputBatches=NULL,
    handler=NULL,
    inputCol=NULL,
    inputParser=NULL,
    miniBatcher=NULL,
    outputCol=NULL,
    outputParser=NULL,
    timeout=60.0,
    only.model=FALSE,
    uid=random_string("ml_simple_http_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.io.http.SimpleHTTPTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFlattenOutputBatches", as.logical(flattenOutputBatches)) %>%
        invoke("setHandler", handler) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setInputParser", inputParser) %>%
        invoke("setMiniBatcher", miniBatcher) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setOutputParser", outputParser) %>%
        invoke("setTimeout", as.double(timeout))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
