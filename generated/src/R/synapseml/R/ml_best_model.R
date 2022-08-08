
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' BestModel
#'
#' @param allModelMetrics all model metrics
#' @param bestModel the best model found
#' @param bestModelMetrics the metrics from the best model
#' @param rocCurve the roc curve of the best model
#' @param scoredDataset dataset scored by best model
#' @export

ml_best_model <- function(
    x,
    allModelMetrics=NULL,
    bestModel=NULL,
    bestModelMetrics=NULL,
    rocCurve=NULL,
    scoredDataset=NULL,
    only.model=FALSE,
    uid=random_string("ml_best_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.automl.BestModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAllModelMetrics", allModelMetrics) %>%
        invoke("setBestModel", bestModel) %>%
        invoke("setBestModelMetrics", bestModelMetrics) %>%
        invoke("setRocCurve", rocCurve) %>%
        invoke("setScoredDataset", scoredDataset)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
