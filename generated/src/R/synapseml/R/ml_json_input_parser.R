
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' JSONInputParser
#'
#' @param headers headers of the request
#' @param inputCol The name of the input column
#' @param method method to use for request, (PUT, POST, PATCH)
#' @param outputCol The name of the output column
#' @param url Url of the service
#' @export

ml_json_input_parser <- function(
    x,
    headers={},
    inputCol=NULL,
    method="POST",
    outputCol=NULL,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_json_input_parser"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.io.http.JSONInputParser"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setHeaders", headers) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setMethod", method) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
