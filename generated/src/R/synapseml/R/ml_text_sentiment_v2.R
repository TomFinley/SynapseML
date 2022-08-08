
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TextSentimentV2
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param language the language code of the text (optional for some services)
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param text the text in the request body
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_text_sentiment_v2 <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="TextSentimentV2_0e944fcbb27a_error",
    handler=NULL,
    language=NULL,
    languageCol=NULL,
    outputCol="TextSentimentV2_0e944fcbb27a_output",
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    text=NULL,
    textCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_text_sentiment_v2"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.TextSentimentV2"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
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
