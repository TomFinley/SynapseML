
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' EntityDetectorSDK
#'
#' @param batchSize The max size of the buffer
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param disableServiceLogs disableServiceLogs option
#' @param errorCol column to hold http errors
#' @param includeStatistics includeStatistics option
#' @param language the language code of the text (optional for some services)
#' @param modelVersion modelVersion option
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param text the text in the request body
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_entity_detector_sdk <- function(
    x,
    batchSize=5,
    concurrency=1,
    concurrentTimeout=NULL,
    disableServiceLogs=NULL,
    disableServiceLogsCol=NULL,
    errorCol="Error",
    includeStatistics=NULL,
    includeStatisticsCol=NULL,
    language=NULL,
    languageCol=NULL,
    modelVersion=NULL,
    modelVersionCol=NULL,
    outputCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    text=NULL,
    textCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_entity_detector_sdk"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.EntityDetectorSDK"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBatchSize", as.integer(batchSize)) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setDisableServiceLogsCol", disableServiceLogsCol) %>%
        invoke("setDisableServiceLogs", disableServiceLogs) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setIncludeStatisticsCol", includeStatisticsCol) %>%
        invoke("setIncludeStatistics", includeStatistics) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setModelVersionCol", modelVersionCol) %>%
        invoke("setModelVersion", modelVersion) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTextCol", textCol) %>%
        invoke("setText", text) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
