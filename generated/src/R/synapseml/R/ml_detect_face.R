
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' DetectFace
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param imageUrl the url of the image to use
#' @param outputCol The name of the output column
#' @param returnFaceAttributes Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
#' @param returnFaceId Return faceIds of the detected faces or not. The default value is true
#' @param returnFaceLandmarks Return face landmarks of the detected faces or not. The default value is false.
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_detect_face <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="DetectFace_2125bac2f530_error",
    handler=NULL,
    imageUrl=NULL,
    imageUrlCol=NULL,
    outputCol="DetectFace_2125bac2f530_output",
    returnFaceAttributes=NULL,
    returnFaceAttributesCol=NULL,
    returnFaceId=NULL,
    returnFaceIdCol=NULL,
    returnFaceLandmarks=NULL,
    returnFaceLandmarksCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_detect_face"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.DetectFace"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setImageUrlCol", imageUrlCol) %>%
        invoke("setImageUrl", imageUrl) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setReturnFaceAttributesCol", returnFaceAttributesCol) %>%
        invoke("setReturnFaceAttributes", returnFaceAttributes) %>%
        invoke("setReturnFaceIdCol", returnFaceIdCol) %>%
        invoke("setReturnFaceId", returnFaceId) %>%
        invoke("setReturnFaceLandmarksCol", returnFaceLandmarksCol) %>%
        invoke("setReturnFaceLandmarks", returnFaceLandmarks) %>%
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
