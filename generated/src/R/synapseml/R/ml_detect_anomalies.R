
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' DetectAnomalies
#'
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param customInterval  Custom Interval is used to set non-standard time interval, for example, if the series is 5 minutes,  request can be set as granularity=minutely, customInterval=5.     
#' @param errorCol column to hold http errors
#' @param granularity  Can only be one of yearly, monthly, weekly, daily, hourly or minutely. Granularity is used for verify whether input series is valid.     
#' @param handler Which strategy to use when handling requests
#' @param imputeFixedValue  Optional argument, fixed value to use when imputeMode is set to "fixed"     
#' @param imputeMode  Optional argument, impute mode of a time series. Possible values: auto, previous, linear, fixed, zero, notFill     
#' @param maxAnomalyRatio  Optional argument, advanced model parameter, max anomaly ratio in a time series.     
#' @param outputCol The name of the output column
#' @param period  Optional argument, periodic value of a time series. If the value is null or does not present, the API will determine the period automatically.     
#' @param sensitivity  Optional argument, advanced model parameter, between 0-99, the lower the value is, the larger the margin value will be which means less anomalies will be accepted     
#' @param series  Time series data points. Points should be sorted by timestamp in ascending order to match the anomaly detection result. If the data is not sorted correctly or there is duplicated timestamp, the API will not work. In such case, an error message will be returned.     
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_detect_anomalies <- function(
    x,
    concurrency=1,
    concurrentTimeout=NULL,
    customInterval=NULL,
    customIntervalCol=NULL,
    errorCol="DetectAnomalies_2a8106b4f070_error",
    granularity=NULL,
    granularityCol=NULL,
    handler=NULL,
    imputeFixedValue=NULL,
    imputeFixedValueCol=NULL,
    imputeMode=NULL,
    imputeModeCol=NULL,
    maxAnomalyRatio=NULL,
    maxAnomalyRatioCol=NULL,
    outputCol="DetectAnomalies_2a8106b4f070_output",
    period=NULL,
    periodCol=NULL,
    sensitivity=NULL,
    sensitivityCol=NULL,
    series=NULL,
    seriesCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_detect_anomalies"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.DetectAnomalies"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setCustomIntervalCol", customIntervalCol) %>%
        invoke("setCustomInterval", customInterval) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setGranularityCol", granularityCol) %>%
        invoke("setGranularity", granularity) %>%
        invoke("setHandler", handler) %>%
        invoke("setImputeFixedValueCol", imputeFixedValueCol) %>%
        invoke("setImputeFixedValue", imputeFixedValue) %>%
        invoke("setImputeModeCol", imputeModeCol) %>%
        invoke("setImputeMode", imputeMode) %>%
        invoke("setMaxAnomalyRatioCol", maxAnomalyRatioCol) %>%
        invoke("setMaxAnomalyRatio", maxAnomalyRatio) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPeriodCol", periodCol) %>%
        invoke("setPeriod", period) %>%
        invoke("setSensitivityCol", sensitivityCol) %>%
        invoke("setSensitivity", sensitivity) %>%
        invoke("setSeriesCol", seriesCol) %>%
        invoke("setSeries", series) %>%
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
