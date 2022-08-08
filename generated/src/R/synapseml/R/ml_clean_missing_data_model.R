
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' CleanMissingDataModel
#'
#' @param colsToFill The columns to fill with
#' @param fillValues what to replace in the columns
#' @param inputCols The names of the input columns
#' @param outputCols The names of the output columns
#' @export

ml_clean_missing_data_model <- function(
    x,
    colsToFill=NULL,
    fillValues=NULL,
    inputCols=NULL,
    outputCols=NULL,
    only.model=FALSE,
    uid=random_string("ml_clean_missing_data_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.CleanMissingDataModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setColsToFill", as.array(colsToFill)) %>%
        invoke("setFillValues", fillValues) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setOutputCols", as.array(outputCols))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
