
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' GetCustomModel
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param includeKeys Include list of extracted keys in model information.
#' @param modelId Model identifier.
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_get_custom_model <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="GetCustomModel_fc72220a388b_error",
    handler=NULL,
    includeKeys=NULL,
    includeKeysCol=NULL,
    modelId=NULL,
    modelIdCol=NULL,
    outputCol="GetCustomModel_fc72220a388b_output",
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_get_custom_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.GetCustomModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setIncludeKeysCol", includeKeysCol) %>%
        invoke("setIncludeKeys", includeKeys) %>%
        invoke("setModelIdCol", modelIdCol) %>%
        invoke("setModelId", modelId) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
