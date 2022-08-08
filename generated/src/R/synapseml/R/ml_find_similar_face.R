
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' FindSimilarFace
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param faceId faceId of the query face. User needs to call FaceDetect first to get a valid faceId. Note that this faceId is not persisted and will expire 24 hours after the detection call.
#' @param faceIds  An array of candidate faceIds. All of them are created by FaceDetect and the faceIds will expire 24 hours after the detection call. The number of faceIds is limited to 1000. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
#' @param faceListId  An existing user-specified unique candidate face list, created in FaceList - Create. Face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
#' @param handler Which strategy to use when handling requests
#' @param largeFaceListId  An existing user-specified unique candidate large face list, created in LargeFaceList - Create. Large face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
#' @param maxNumOfCandidatesReturned  Optional parameter. The number of top similar faces returned. The valid range is [1, 1000].It defaults to 20.
#' @param mode  Optional parameter. Similar face searching mode. It can be 'matchPerson' or 'matchFace'. It defaults to 'matchPerson'.
#' @param outputCol The name of the output column
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_find_similar_face <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="FindSimilarFace_e8730a1e1399_error",
    faceId=NULL,
    faceIdCol=NULL,
    faceIds=NULL,
    faceIdsCol=NULL,
    faceListId=NULL,
    faceListIdCol=NULL,
    handler=NULL,
    largeFaceListId=NULL,
    largeFaceListIdCol=NULL,
    maxNumOfCandidatesReturned=NULL,
    maxNumOfCandidatesReturnedCol=NULL,
    mode=NULL,
    modeCol=NULL,
    outputCol="FindSimilarFace_e8730a1e1399_output",
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_find_similar_face"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.FindSimilarFace"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFaceIdCol", faceIdCol) %>%
        invoke("setFaceId", faceId) %>%
        invoke("setFaceIdsCol", faceIdsCol) %>%
        invoke("setFaceIds", faceIds) %>%
        invoke("setFaceListIdCol", faceListIdCol) %>%
        invoke("setFaceListId", faceListId) %>%
        invoke("setHandler", handler) %>%
        invoke("setLargeFaceListIdCol", largeFaceListIdCol) %>%
        invoke("setLargeFaceListId", largeFaceListId) %>%
        invoke("setMaxNumOfCandidatesReturnedCol", maxNumOfCandidatesReturnedCol) %>%
        invoke("setMaxNumOfCandidatesReturned", maxNumOfCandidatesReturned) %>%
        invoke("setModeCol", modeCol) %>%
        invoke("setMode", mode) %>%
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
