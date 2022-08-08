
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' GenerateThumbnails
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param height the desired height of the image
#' @param imageBytes bytestream of the image to use
#' @param imageUrl the url of the image to use
#' @param outputCol The name of the output column
#' @param smartCropping whether to intelligently crop the image
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @param width the desired width of the image
#' @export

ml_generate_thumbnails <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="GenerateThumbnails_40fd311b7519_error",
    handler=NULL,
    height=NULL,
    heightCol=NULL,
    imageBytes=NULL,
    imageBytesCol=NULL,
    imageUrl=NULL,
    imageUrlCol=NULL,
    outputCol="GenerateThumbnails_40fd311b7519_output",
    smartCropping=NULL,
    smartCroppingCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    width=NULL,
    widthCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_generate_thumbnails"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.GenerateThumbnails"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setHeightCol", heightCol) %>%
        invoke("setHeight", height) %>%
        invoke("setImageBytesCol", imageBytesCol) %>%
        invoke("setImageBytes", imageBytes) %>%
        invoke("setImageUrlCol", imageUrlCol) %>%
        invoke("setImageUrl", imageUrl) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSmartCroppingCol", smartCroppingCol) %>%
        invoke("setSmartCropping", smartCropping) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url) %>%
        invoke("setWidthCol", widthCol) %>%
        invoke("setWidth", width)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
