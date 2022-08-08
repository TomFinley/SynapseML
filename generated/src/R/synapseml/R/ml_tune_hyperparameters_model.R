
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TuneHyperparametersModel
#'
#' @param bestMetric the best metric from the runs
#' @param bestModel the best model found
#' @export

ml_tune_hyperparameters_model <- function(
    x,
    bestMetric=NULL,
    bestModel=NULL,
    only.model=FALSE,
    uid=random_string("ml_tune_hyperparameters_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.automl.TuneHyperparametersModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBestMetric", as.double(bestMetric)) %>%
        invoke("setBestModel", bestModel)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
