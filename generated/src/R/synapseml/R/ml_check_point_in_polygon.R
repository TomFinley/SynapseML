
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' CheckPointInPolygon
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param latitude the latitude of location
#' @param longitude the longitude of location
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @param userDataIdentifier the identifier for the user uploaded data
#' @export

ml_check_point_in_polygon <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="CheckPointInPolygon_b61775a669dd_error",
    handler=NULL,
    latitude=NULL,
    latitudeCol=NULL,
    longitude=NULL,
    longitudeCol=NULL,
    outputCol="CheckPointInPolygon_b61775a669dd_output",
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url="https://atlas.microsoft.com/",
    userDataIdentifier=NULL,
    userDataIdentifierCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_check_point_in_polygon"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.geospatial.CheckPointInPolygon"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setLatitudeCol", latitudeCol) %>%
        invoke("setLatitude", latitude) %>%
        invoke("setLongitudeCol", longitudeCol) %>%
        invoke("setLongitude", longitude) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url) %>%
        invoke("setUserDataIdentifierCol", userDataIdentifierCol) %>%
        invoke("setUserDataIdentifier", userDataIdentifier)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
