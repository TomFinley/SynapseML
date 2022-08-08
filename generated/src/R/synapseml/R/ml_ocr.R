
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' OCR
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param detectOrientation whether to detect image orientation prior to processing
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param imageBytes bytestream of the image to use
#' @param imageUrl the url of the image to use
#' @param language the language to use
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_ocr <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    detectOrientation=NULL,
    detectOrientationCol=NULL,
    errorCol="OCR_61fc359ed99e_error",
    handler=NULL,
    imageBytes=NULL,
    imageBytesCol=NULL,
    imageUrl=NULL,
    imageUrlCol=NULL,
    language=NULL,
    languageCol=NULL,
    outputCol="OCR_61fc359ed99e_output",
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_ocr"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.OCR"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setDetectOrientationCol", detectOrientationCol) %>%
        invoke("setDetectOrientation", detectOrientation) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setImageBytesCol", imageBytesCol) %>%
        invoke("setImageBytes", imageBytes) %>%
        invoke("setImageUrlCol", imageUrlCol) %>%
        invoke("setImageUrl", imageUrl) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setOutputCol", outputCol) %>%
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
