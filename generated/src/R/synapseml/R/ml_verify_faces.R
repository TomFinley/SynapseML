
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' VerifyFaces
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param faceId faceId of the face, comes from Face - Detect.
#' @param faceId1 faceId of one face, comes from Face - Detect.
#' @param faceId2 faceId of another face, comes from Face - Detect.
#' @param handler Which strategy to use when handling requests
#' @param largePersonGroupId Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
#' @param outputCol The name of the output column
#' @param personGroupId Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
#' @param personId Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_verify_faces <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="VerifyFaces_a8262836a522_error",
    faceId=NULL,
    faceIdCol=NULL,
    faceId1=NULL,
    faceId1Col=NULL,
    faceId2=NULL,
    faceId2Col=NULL,
    handler=NULL,
    largePersonGroupId=NULL,
    largePersonGroupIdCol=NULL,
    outputCol="VerifyFaces_a8262836a522_output",
    personGroupId=NULL,
    personGroupIdCol=NULL,
    personId=NULL,
    personIdCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_verify_faces"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.VerifyFaces"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFaceIdCol", faceIdCol) %>%
        invoke("setFaceId", faceId) %>%
        invoke("setFaceId1Col", faceId1Col) %>%
        invoke("setFaceId1", faceId1) %>%
        invoke("setFaceId2Col", faceId2Col) %>%
        invoke("setFaceId2", faceId2) %>%
        invoke("setHandler", handler) %>%
        invoke("setLargePersonGroupIdCol", largePersonGroupIdCol) %>%
        invoke("setLargePersonGroupId", largePersonGroupId) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPersonGroupIdCol", personGroupIdCol) %>%
        invoke("setPersonGroupId", personGroupId) %>%
        invoke("setPersonIdCol", personIdCol) %>%
        invoke("setPersonId", personId) %>%
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
