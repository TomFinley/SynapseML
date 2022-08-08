
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' RankingTrainValidationSplitModel
#'
#' @param bestModel The internal ALS model used splitter
#' @param validationMetrics Best Model
#' @export

ml_ranking_train_validation_split_model <- function(
    x,
    bestModel=NULL,
    validationMetrics=NULL,
    only.model=FALSE,
    uid=random_string("ml_ranking_train_validation_split_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.recommendation.RankingTrainValidationSplitModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBestModel", bestModel) %>%
        invoke("setValidationMetrics", validationMetrics)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
