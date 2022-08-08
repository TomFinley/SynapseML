
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' EnsembleByKey
#'
#' @param colNames Names of the result of each col
#' @param collapseGroup Whether to collapse all items in group to one entry
#' @param cols Cols to ensemble
#' @param keys Keys to group by
#' @param strategy How to ensemble the scores, ex: mean
#' @param vectorDims the dimensions of any vector columns, used to avoid materialization
#' @export

ml_ensemble_by_key <- function(
    x,
    colNames=NULL,
    collapseGroup=TRUE,
    cols=NULL,
    keys=NULL,
    strategy="mean",
    vectorDims=NULL,
    only.model=FALSE,
    uid=random_string("ml_ensemble_by_key"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.EnsembleByKey"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setColNames", as.array(colNames)) %>%
        invoke("setCollapseGroup", as.logical(collapseGroup)) %>%
        invoke("setCols", as.array(cols)) %>%
        invoke("setKeys", as.array(keys)) %>%
        invoke("setStrategy", strategy) %>%
        invoke("setVectorDims", vectorDims)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
