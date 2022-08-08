
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TextSentiment
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param language the language code of the text (optional for some services)
#' @param modelVersion This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
#' @param opinionMining if set to true, response will contain not only sentiment prediction but also opinion mining (aspect-based sentiment analysis) results.
#' @param outputCol The name of the output column
#' @param showStats if set to true, response will contain input and document level statistics.
#' @param stringIndexType Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes) according to Unicode v8.0.0. For additional information see https://aka.ms/text-analytics-offsets
#' @param subscriptionKey the API key to use
#' @param text the text in the request body
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_text_sentiment <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="TextSentiment_6d655371106c_error",
    handler=NULL,
    language=NULL,
    languageCol=NULL,
    modelVersion=NULL,
    modelVersionCol=NULL,
    opinionMining=NULL,
    opinionMiningCol=NULL,
    outputCol="TextSentiment_6d655371106c_output",
    showStats=NULL,
    showStatsCol=NULL,
    stringIndexType=NULL,
    stringIndexTypeCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    text=NULL,
    textCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_text_sentiment"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.TextSentiment"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setModelVersionCol", modelVersionCol) %>%
        invoke("setModelVersion", modelVersion) %>%
        invoke("setOpinionMiningCol", opinionMiningCol) %>%
        invoke("setOpinionMining", opinionMining) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setShowStatsCol", showStatsCol) %>%
        invoke("setShowStats", showStats) %>%
        invoke("setStringIndexTypeCol", stringIndexTypeCol) %>%
        invoke("setStringIndexType", stringIndexType) %>%
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
