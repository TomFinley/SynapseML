
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' DocumentTranslator
#'
#' @param backoffs array of backoffs to use in the handler
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param filterPrefix A case-sensitive prefix string to filter documents in the source path for translation. For example, when using an Azure storage blob Uri, use the prefix to restrict sub folders for translation.
#' @param filterSuffix A case-sensitive suffix string to filter documents in the source path for translation. This is most often use for file extensions.
#' @param initialPollingDelay number of milliseconds to wait before first poll for result
#' @param maxPollingRetries number of times to poll
#' @param outputCol The name of the output column
#' @param pollingDelay number of milliseconds to wait between polling
#' @param serviceName 
#' @param sourceLanguage Language code. If none is specified, we will perform auto detect on the document.
#' @param sourceStorageSource Storage source of source input.
#' @param sourceUrl Location of the folder / container or single file with your documents.
#' @param storageType Storage type of the input documents source string. Required for single document translation only.
#' @param subscriptionKey the API key to use
#' @param suppressMaxRetriesExceededException set true to suppress the maxumimum retries exception and report in the error column
#' @param targets Destination for the finished translated documents.
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_document_translator <- function(
    x,
    backoffs=c(100,500,1000),
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="DocumentTranslator_bbeec2dfd941_error",
    filterPrefix=NULL,
    filterPrefixCol=NULL,
    filterSuffix=NULL,
    filterSuffixCol=NULL,
    initialPollingDelay=300,
    maxPollingRetries=1000,
    outputCol="DocumentTranslator_bbeec2dfd941_output",
    pollingDelay=300,
    serviceName=NULL,
    sourceLanguage=NULL,
    sourceLanguageCol=NULL,
    sourceStorageSource=NULL,
    sourceStorageSourceCol=NULL,
    sourceUrl=NULL,
    sourceUrlCol=NULL,
    storageType=NULL,
    storageTypeCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    suppressMaxRetriesExceededException=FALSE,
    targets=NULL,
    targetsCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_document_translator"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.DocumentTranslator"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBackoffs", as.array(backoffs)) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFilterPrefixCol", filterPrefixCol) %>%
        invoke("setFilterPrefix", filterPrefix) %>%
        invoke("setFilterSuffixCol", filterSuffixCol) %>%
        invoke("setFilterSuffix", filterSuffix) %>%
        invoke("setInitialPollingDelay", as.integer(initialPollingDelay)) %>%
        invoke("setMaxPollingRetries", as.integer(maxPollingRetries)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPollingDelay", as.integer(pollingDelay)) %>%
        invoke("setServiceName", serviceName) %>%
        invoke("setSourceLanguageCol", sourceLanguageCol) %>%
        invoke("setSourceLanguage", sourceLanguage) %>%
        invoke("setSourceStorageSourceCol", sourceStorageSourceCol) %>%
        invoke("setSourceStorageSource", sourceStorageSource) %>%
        invoke("setSourceUrlCol", sourceUrlCol) %>%
        invoke("setSourceUrl", sourceUrl) %>%
        invoke("setStorageTypeCol", storageTypeCol) %>%
        invoke("setStorageType", storageType) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSuppressMaxRetriesExceededException", as.logical(suppressMaxRetriesExceededException)) %>%
        invoke("setTargetsCol", targetsCol) %>%
        invoke("setTargets", targets) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
