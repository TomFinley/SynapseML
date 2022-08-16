
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' SpeechToText
#'
#' @param audioData  The data sent to the service must be a .wav files     
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param format  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
#' @param handler Which strategy to use when handling requests
#' @param language  Identifies the spoken language that is being recognized.     
#' @param outputCol The name of the output column
#' @param profanity  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_speech_to_text <- function(
    x,
    audioData=NULL,
    audioDataCol=NULL,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="SpeechToText_dcf2df573a8d_error",
    format=NULL,
    formatCol=NULL,
    handler=NULL,
    language=NULL,
    languageCol=NULL,
    outputCol="SpeechToText_dcf2df573a8d_output",
    profanity=NULL,
    profanityCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_speech_to_text"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.SpeechToText"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAudioDataCol", audioDataCol) %>%
        invoke("setAudioData", audioData) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFormatCol", formatCol) %>%
        invoke("setFormat", format) %>%
        invoke("setHandler", handler) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setProfanityCol", profanityCol) %>%
        invoke("setProfanity", profanity) %>%
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
