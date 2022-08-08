
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ReadImage
#'
#' @param backoffs array of backoffs to use in the handler
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param imageBytes bytestream of the image to use
#' @param imageUrl the url of the image to use
#' @param initialPollingDelay number of milliseconds to wait before first poll for result
#' @param language IThe BCP-47 language code of the text in the document. Currently, only English (en), Dutch (nl), French (fr), German (de), Italian (it), Portuguese (pt), and Spanish (es) are supported. Read supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
#' @param maxPollingRetries number of times to poll
#' @param outputCol The name of the output column
#' @param pollingDelay number of milliseconds to wait between polling
#' @param subscriptionKey the API key to use
#' @param suppressMaxRetriesExceededException set true to suppress the maxumimum retries exception and report in the error column
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_read_image <- function(
    x,
    backoffs=c(100,500,1000),
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="ReadImage_3baafd9e293a_error",
    imageBytes=NULL,
    imageBytesCol=NULL,
    imageUrl=NULL,
    imageUrlCol=NULL,
    initialPollingDelay=300,
    language=NULL,
    languageCol=NULL,
    maxPollingRetries=1000,
    outputCol="ReadImage_3baafd9e293a_output",
    pollingDelay=300,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    suppressMaxRetriesExceededException=FALSE,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_read_image"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.ReadImage"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBackoffs", as.array(backoffs)) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setImageBytesCol", imageBytesCol) %>%
        invoke("setImageBytes", imageBytes) %>%
        invoke("setImageUrlCol", imageUrlCol) %>%
        invoke("setImageUrl", imageUrl) %>%
        invoke("setInitialPollingDelay", as.integer(initialPollingDelay)) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setMaxPollingRetries", as.integer(maxPollingRetries)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPollingDelay", as.integer(pollingDelay)) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSuppressMaxRetriesExceededException", as.logical(suppressMaxRetriesExceededException)) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
