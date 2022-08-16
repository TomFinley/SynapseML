
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' AnalyzeReceipts
#'
#' @param backoffs array of backoffs to use in the handler
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param imageBytes bytestream of the image to use
#' @param imageUrl the url of the image to use
#' @param includeTextDetails Include text lines and element references in the result.
#' @param initialPollingDelay number of milliseconds to wait before first poll for result
#' @param locale Locale of the receipt. Supported locales: en-AU, en-CA, en-GB, en-IN, en-US.
#' @param maxPollingRetries number of times to poll
#' @param modelVersion This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
#' @param outputCol The name of the output column
#' @param pages The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
#' @param pollingDelay number of milliseconds to wait between polling
#' @param subscriptionKey the API key to use
#' @param suppressMaxRetriesExceededException set true to suppress the maxumimum retries exception and report in the error column
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_analyze_receipts <- function(
    x,
    backoffs=c(100,500,1000),
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="AnalyzeReceipts_b93e013bcf7e_error",
    imageBytes=NULL,
    imageBytesCol=NULL,
    imageUrl=NULL,
    imageUrlCol=NULL,
    includeTextDetails=NULL,
    includeTextDetailsCol=NULL,
    initialPollingDelay=300,
    locale=NULL,
    localeCol=NULL,
    maxPollingRetries=1000,
    modelVersion=NULL,
    modelVersionCol=NULL,
    outputCol="AnalyzeReceipts_b93e013bcf7e_output",
    pages=NULL,
    pagesCol=NULL,
    pollingDelay=300,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    suppressMaxRetriesExceededException=FALSE,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_analyze_receipts"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.AnalyzeReceipts"
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
        invoke("setIncludeTextDetailsCol", includeTextDetailsCol) %>%
        invoke("setIncludeTextDetails", includeTextDetails) %>%
        invoke("setInitialPollingDelay", as.integer(initialPollingDelay)) %>%
        invoke("setLocaleCol", localeCol) %>%
        invoke("setLocale", locale) %>%
        invoke("setMaxPollingRetries", as.integer(maxPollingRetries)) %>%
        invoke("setModelVersionCol", modelVersionCol) %>%
        invoke("setModelVersion", modelVersion) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPagesCol", pagesCol) %>%
        invoke("setPages", pages) %>%
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
