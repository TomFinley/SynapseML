
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TimerModel
#'
#' @param disableMaterialization Whether to disable timing (so that one can turn it off for evaluation)
#' @param logToScala Whether to output the time to the scala console
#' @param stage The stage to time
#' @param transformer inner model to time
#' @export

ml_timer_model <- function(
    x,
    disableMaterialization=TRUE,
    logToScala=TRUE,
    stage=NULL,
    transformer=NULL,
    only.model=FALSE,
    uid=random_string("ml_timer_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.TimerModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setDisableMaterialization", as.logical(disableMaterialization)) %>%
        invoke("setLogToScala", as.logical(logToScala)) %>%
        invoke("setStage", stage) %>%
        invoke("setTransformer", transformer)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
