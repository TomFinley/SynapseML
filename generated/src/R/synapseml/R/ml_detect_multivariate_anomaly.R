
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' DetectMultivariateAnomaly
#'
#' @param backoffs array of backoffs to use in the handler
#' @param connectionString Connection String for your storage account used for uploading files.
#' @param containerName Container that will be used to upload files to.
#' @param endTime A required field, end time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
#' @param endpoint End Point for your storage account used for uploading files.
#' @param errorCol column to hold http errors
#' @param initialPollingDelay number of milliseconds to wait before first poll for result
#' @param inputCols The names of the input columns
#' @param intermediateSaveDir Directory name of which you want to save the intermediate data produced while training.
#' @param maxPollingRetries number of times to poll
#' @param modelId Format - uuid. Model identifier.
#' @param outputCol The name of the output column
#' @param pollingDelay number of milliseconds to wait between polling
#' @param sasToken SAS Token for your storage account used for uploading files.
#' @param startTime A required field, start time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
#' @param storageKey Storage Key for your storage account used for uploading files.
#' @param storageName Storage Name for your storage account used for uploading files.
#' @param subscriptionKey the API key to use
#' @param suppressMaxRetriesExceededException set true to suppress the maxumimum retries exception and report in the error column
#' @param timestampCol Timestamp column name
#' @param url Url of the service
#' @export

ml_detect_multivariate_anomaly <- function(
    x,
    backoffs=c(100,500,1000),
    connectionString=NULL,
    containerName=NULL,
    endTime=NULL,
    endpoint=NULL,
    errorCol="DetectMultivariateAnomaly_7b0917a708bb_error",
    initialPollingDelay=300,
    inputCols=NULL,
    intermediateSaveDir=NULL,
    maxPollingRetries=1000,
    modelId=NULL,
    outputCol="DetectMultivariateAnomaly_7b0917a708bb_output",
    pollingDelay=300,
    sasToken=NULL,
    startTime=NULL,
    storageKey=NULL,
    storageName=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    suppressMaxRetriesExceededException=FALSE,
    timestampCol="timestamp",
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_detect_multivariate_anomaly"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.DetectMultivariateAnomaly"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBackoffs", as.array(backoffs)) %>%
        invoke("setConnectionString", connectionString) %>%
        invoke("setContainerName", containerName) %>%
        invoke("setEndTime", endTime) %>%
        invoke("setEndpoint", endpoint) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setInitialPollingDelay", as.integer(initialPollingDelay)) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setIntermediateSaveDir", intermediateSaveDir) %>%
        invoke("setMaxPollingRetries", as.integer(maxPollingRetries)) %>%
        invoke("setModelId", modelId) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPollingDelay", as.integer(pollingDelay)) %>%
        invoke("setSasToken", sasToken) %>%
        invoke("setStartTime", startTime) %>%
        invoke("setStorageKey", storageKey) %>%
        invoke("setStorageName", storageName) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSuppressMaxRetriesExceededException", as.logical(suppressMaxRetriesExceededException)) %>%
        invoke("setTimestampCol", timestampCol) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
