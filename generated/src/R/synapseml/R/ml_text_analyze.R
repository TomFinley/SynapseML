
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TextAnalyze
#'
#' @param backoffs array of backoffs to use in the handler
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param entityLinkingTasks the entity linking tasks to perform on submitted documents
#' @param entityRecognitionPiiTasks the entity recognition pii tasks to perform on submitted documents
#' @param entityRecognitionTasks the entity recognition tasks to perform on submitted documents
#' @param errorCol column to hold http errors
#' @param initialPollingDelay number of milliseconds to wait before first poll for result
#' @param keyPhraseExtractionTasks the key phrase extraction tasks to perform on submitted documents
#' @param language the language code of the text (optional for some services)
#' @param maxPollingRetries number of times to poll
#' @param outputCol The name of the output column
#' @param pollingDelay number of milliseconds to wait between polling
#' @param sentimentAnalysisTasks the sentiment analysis tasks to perform on submitted documents
#' @param subscriptionKey the API key to use
#' @param suppressMaxRetriesExceededException set true to suppress the maxumimum retries exception and report in the error column
#' @param text the text in the request body
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_text_analyze <- function(
    x,
    backoffs=c(100,500,1000),
    concurrency=1,
    concurrentTimeout=NULL,
    entityLinkingTasks=c(),
    entityRecognitionPiiTasks=c(),
    entityRecognitionTasks=c(),
    errorCol="TextAnalyze_860c6162465b_error",
    initialPollingDelay=300,
    keyPhraseExtractionTasks=c(),
    language=NULL,
    languageCol=NULL,
    maxPollingRetries=1000,
    outputCol="TextAnalyze_860c6162465b_output",
    pollingDelay=300,
    sentimentAnalysisTasks=c(),
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    suppressMaxRetriesExceededException=FALSE,
    text=NULL,
    textCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_text_analyze"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.TextAnalyze"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBackoffs", as.array(backoffs)) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setEntityLinkingTasks", entityLinkingTasks) %>%
        invoke("setEntityRecognitionPiiTasks", entityRecognitionPiiTasks) %>%
        invoke("setEntityRecognitionTasks", entityRecognitionTasks) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setInitialPollingDelay", as.integer(initialPollingDelay)) %>%
        invoke("setKeyPhraseExtractionTasks", keyPhraseExtractionTasks) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setMaxPollingRetries", as.integer(maxPollingRetries)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPollingDelay", as.integer(pollingDelay)) %>%
        invoke("setSentimentAnalysisTasks", sentimentAnalysisTasks) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSuppressMaxRetriesExceededException", as.logical(suppressMaxRetriesExceededException)) %>%
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
