
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' AddressGeocoder
#'
#' @param address the address to geocode
#' @param backoffs array of backoffs to use in the handler
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param initialPollingDelay number of milliseconds to wait before first poll for result
#' @param maxPollingRetries number of times to poll
#' @param outputCol The name of the output column
#' @param pollingDelay number of milliseconds to wait between polling
#' @param subscriptionKey the API key to use
#' @param suppressMaxRetriesExceededException set true to suppress the maxumimum retries exception and report in the error column
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_address_geocoder <- function(
    x,
    address=NULL,
    addressCol=NULL,
    backoffs=c(100,500,1000),
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="AddressGeocoder_5fb9310a65e7_error",
    initialPollingDelay=300,
    maxPollingRetries=1000,
    outputCol="AddressGeocoder_5fb9310a65e7_output",
    pollingDelay=300,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    suppressMaxRetriesExceededException=FALSE,
    timeout=60.0,
    url="https://atlas.microsoft.com/search/address/batch/json",
    only.model=FALSE,
    uid=random_string("ml_address_geocoder"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.geospatial.AddressGeocoder"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAddressCol", addressCol) %>%
        invoke("setAddress", address) %>%
        invoke("setBackoffs", as.array(backoffs)) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setInitialPollingDelay", as.integer(initialPollingDelay)) %>%
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
