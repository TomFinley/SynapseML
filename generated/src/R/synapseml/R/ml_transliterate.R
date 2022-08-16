
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' Transliterate
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param fromScript Specifies the script of the input text.
#' @param handler Which strategy to use when handling requests
#' @param language Language tag identifying the language of the input text. If a code is not specified, automatic language detection will be applied.
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param subscriptionRegion the API region to use
#' @param text the string to translate
#' @param timeout number of seconds to wait before closing the connection
#' @param toScript Specifies the script of the translated text.
#' @param url Url of the service
#' @export

ml_transliterate <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="Transliterate_dc309950d114_error",
    fromScript=NULL,
    fromScriptCol=NULL,
    handler=NULL,
    language=NULL,
    languageCol=NULL,
    outputCol="Transliterate_dc309950d114_output",
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    subscriptionRegion=NULL,
    subscriptionRegionCol=NULL,
    text=NULL,
    textCol=NULL,
    timeout=60.0,
    toScript=NULL,
    toScriptCol=NULL,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_transliterate"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.Transliterate"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFromScriptCol", fromScriptCol) %>%
        invoke("setFromScript", fromScript) %>%
        invoke("setHandler", handler) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSubscriptionRegionCol", subscriptionRegionCol) %>%
        invoke("setSubscriptionRegion", subscriptionRegion) %>%
        invoke("setTextCol", textCol) %>%
        invoke("setText", text) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setToScriptCol", toScriptCol) %>%
        invoke("setToScript", toScript) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
