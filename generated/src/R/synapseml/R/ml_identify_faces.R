
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' IdentifyFaces
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param confidenceThreshold Optional parameter.Customized identification confidence threshold, in the range of [0, 1].Advanced user can tweak this value to override defaultinternal threshold for better precision on their scenario data.Note there is no guarantee of this threshold value workingon other data and after algorithm updates.
#' @param errorCol column to hold http errors
#' @param faceIds Array of query faces faceIds, created by the Face - Detect. Each of the faces are identified independently. The valid number of faceIds is between [1, 10]. 
#' @param handler Which strategy to use when handling requests
#' @param largePersonGroupId largePersonGroupId of the target large person group, created by LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
#' @param maxNumOfCandidatesReturned The range of maxNumOfCandidatesReturned is between 1 and 100 (default is 10).
#' @param outputCol The name of the output column
#' @param personGroupId personGroupId of the target person group, created by PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_identify_faces <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    confidenceThreshold=NULL,
    confidenceThresholdCol=NULL,
    errorCol="IdentifyFaces_fa79a907095f_error",
    faceIds=NULL,
    faceIdsCol=NULL,
    handler=NULL,
    largePersonGroupId=NULL,
    largePersonGroupIdCol=NULL,
    maxNumOfCandidatesReturned=NULL,
    maxNumOfCandidatesReturnedCol=NULL,
    outputCol="IdentifyFaces_fa79a907095f_output",
    personGroupId=NULL,
    personGroupIdCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_identify_faces"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.IdentifyFaces"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setConfidenceThresholdCol", confidenceThresholdCol) %>%
        invoke("setConfidenceThreshold", confidenceThreshold) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFaceIdsCol", faceIdsCol) %>%
        invoke("setFaceIds", faceIds) %>%
        invoke("setHandler", handler) %>%
        invoke("setLargePersonGroupIdCol", largePersonGroupIdCol) %>%
        invoke("setLargePersonGroupId", largePersonGroupId) %>%
        invoke("setMaxNumOfCandidatesReturnedCol", maxNumOfCandidatesReturnedCol) %>%
        invoke("setMaxNumOfCandidatesReturned", maxNumOfCandidatesReturned) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPersonGroupIdCol", personGroupIdCol) %>%
        invoke("setPersonGroupId", personGroupId) %>%
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
