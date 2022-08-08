
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' DictionaryLookup
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param fromLanguage Specifies the language of the input text. The source language must be one of the supported languages included in the dictionary scope.
#' @param handler Which strategy to use when handling requests
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param subscriptionRegion the API region to use
#' @param text the string to translate
#' @param timeout number of seconds to wait before closing the connection
#' @param toLanguage Specifies the language of the output text. The target language must be one of the supported languages included in the dictionary scope.
#' @param url Url of the service
#' @export

ml_dictionary_lookup <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="DictionaryLookup_f74635439239_error",
    fromLanguage=NULL,
    fromLanguageCol=NULL,
    handler=NULL,
    outputCol="DictionaryLookup_f74635439239_output",
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    subscriptionRegion=NULL,
    subscriptionRegionCol=NULL,
    text=NULL,
    textCol=NULL,
    timeout=60.0,
    toLanguage=NULL,
    toLanguageCol=NULL,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_dictionary_lookup"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.DictionaryLookup"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFromLanguageCol", fromLanguageCol) %>%
        invoke("setFromLanguage", fromLanguage) %>%
        invoke("setHandler", handler) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSubscriptionRegionCol", subscriptionRegionCol) %>%
        invoke("setSubscriptionRegion", subscriptionRegion) %>%
        invoke("setTextCol", textCol) %>%
        invoke("setText", text) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setToLanguageCol", toLanguageCol) %>%
        invoke("setToLanguage", toLanguage) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
