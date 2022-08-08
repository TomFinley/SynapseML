
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' BreakSentence
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param language Language tag identifying the language of the input text. If a code is not specified, automatic language detection will be applied.
#' @param outputCol The name of the output column
#' @param script Script tag identifying the script used by the input text. If a script is not specified, the default script of the language will be assumed.
#' @param subscriptionKey the API key to use
#' @param subscriptionRegion the API region to use
#' @param text the string to translate
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_break_sentence <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="BreakSentence_174f16595ef7_error",
    handler=NULL,
    language=NULL,
    languageCol=NULL,
    outputCol="BreakSentence_174f16595ef7_output",
    script=NULL,
    scriptCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    subscriptionRegion=NULL,
    subscriptionRegionCol=NULL,
    text=NULL,
    textCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_break_sentence"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.BreakSentence"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setScriptCol", scriptCol) %>%
        invoke("setScript", script) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSubscriptionRegionCol", subscriptionRegionCol) %>%
        invoke("setSubscriptionRegion", subscriptionRegion) %>%
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
