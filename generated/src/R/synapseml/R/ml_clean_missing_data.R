
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' CleanMissingData
#'
#' @param cleaningMode Cleaning mode
#' @param customValue Custom value for replacement
#' @param inputCols The names of the input columns
#' @param outputCols The names of the output columns
#' @export

ml_clean_missing_data <- function(
    x,
    cleaningMode="Mean",
    customValue=NULL,
    inputCols=NULL,
    outputCols=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_clean_missing_data"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.CleanMissingData"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setCleaningMode", cleaningMode) %>%
        invoke("setCustomValue", customValue) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setOutputCols", as.array(outputCols))
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.featurize.CleanMissingDataModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
