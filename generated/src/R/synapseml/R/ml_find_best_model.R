
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' FindBestModel
#'
#' @param evaluationMetric Metric to evaluate models with
#' @param models List of models to be evaluated
#' @export

ml_find_best_model <- function(
    x,
    evaluationMetric="accuracy",
    models=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_find_best_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.automl.FindBestModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setEvaluationMetric", evaluationMetric) %>%
        invoke("setModels", models)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.automl.BestModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
