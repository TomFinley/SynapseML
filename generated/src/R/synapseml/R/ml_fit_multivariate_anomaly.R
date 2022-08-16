
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' FitMultivariateAnomaly
#'
#' @param alignMode An optional field, indicates how we align different variables into the same time-range which is required by the model.{Inner, Outer}
#' @param backoffs array of backoffs to use in the handler
#' @param connectionString Connection String for your storage account used for uploading files.
#' @param containerName Container that will be used to upload files to.
#' @param diagnosticsInfo diagnosticsInfo for training a multivariate anomaly detection model
#' @param displayName optional field, name of the model
#' @param endTime A required field, end time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
#' @param endpoint End Point for your storage account used for uploading files.
#' @param errorCol column to hold http errors
#' @param fillNAMethod An optional field, indicates how missed values will be filled with. Can not be set to NotFill, when alignMode is Outer.{Previous, Subsequent, Linear, Zero, Fixed}
#' @param initialPollingDelay number of milliseconds to wait before first poll for result
#' @param inputCols The names of the input columns
#' @param intermediateSaveDir Directory name of which you want to save the intermediate data produced while training.
#' @param maxPollingRetries number of times to poll
#' @param outputCol The name of the output column
#' @param paddingValue optional field, is only useful if FillNAMethod is set to Fixed.
#' @param pollingDelay number of milliseconds to wait between polling
#' @param sasToken SAS Token for your storage account used for uploading files.
#' @param slidingWindow An optional field, indicates how many history points will be used to determine the anomaly score of one subsequent point.
#' @param startTime A required field, start time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
#' @param storageKey Storage Key for your storage account used for uploading files.
#' @param storageName Storage Name for your storage account used for uploading files.
#' @param subscriptionKey the API key to use
#' @param suppressMaxRetriesExceededException set true to suppress the maxumimum retries exception and report in the error column
#' @param timestampCol Timestamp column name
#' @param url Url of the service
#' @export

ml_fit_multivariate_anomaly <- function(
    x,
    alignMode=NULL,
    backoffs=c(100,500,1000),
    connectionString=NULL,
    containerName=NULL,
    diagnosticsInfo=NULL,
    displayName=NULL,
    endTime=NULL,
    endpoint=NULL,
    errorCol="FitMultivariateAnomaly_046dee412c89_error",
    fillNAMethod=NULL,
    initialPollingDelay=300,
    inputCols=NULL,
    intermediateSaveDir=NULL,
    maxPollingRetries=1000,
    outputCol="FitMultivariateAnomaly_046dee412c89_output",
    paddingValue=NULL,
    pollingDelay=300,
    sasToken=NULL,
    slidingWindow=NULL,
    startTime=NULL,
    storageKey=NULL,
    storageName=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    suppressMaxRetriesExceededException=FALSE,
    timestampCol="timestamp",
    url=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_fit_multivariate_anomaly"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.FitMultivariateAnomaly"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAlignMode", alignMode) %>%
        invoke("setBackoffs", as.array(backoffs)) %>%
        invoke("setConnectionString", connectionString) %>%
        invoke("setContainerName", containerName) %>%
        invoke("setDiagnosticsInfo", diagnosticsInfo) %>%
        invoke("setDisplayName", displayName) %>%
        invoke("setEndTime", endTime) %>%
        invoke("setEndpoint", endpoint) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFillNAMethod", fillNAMethod) %>%
        invoke("setInitialPollingDelay", as.integer(initialPollingDelay)) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setIntermediateSaveDir", intermediateSaveDir) %>%
        invoke("setMaxPollingRetries", as.integer(maxPollingRetries)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPaddingValue", as.integer(paddingValue)) %>%
        invoke("setPollingDelay", as.integer(pollingDelay)) %>%
        invoke("setSasToken", sasToken) %>%
        invoke("setSlidingWindow", as.integer(slidingWindow)) %>%
        invoke("setStartTime", startTime) %>%
        invoke("setStorageKey", storageKey) %>%
        invoke("setStorageName", storageName) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSuppressMaxRetriesExceededException", as.logical(suppressMaxRetriesExceededException)) %>%
        invoke("setTimestampCol", timestampCol) %>%
        invoke("setUrl", url)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.cognitive.DetectMultivariateAnomaly"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
