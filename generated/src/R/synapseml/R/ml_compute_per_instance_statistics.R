
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ComputePerInstanceStatistics
#'
#' @param evaluationMetric Metric to evaluate models with
#' @param labelCol The name of the label column
#' @param scoredLabelsCol Scored labels column name, only required if using SparkML estimators
#' @param scoredProbabilitiesCol Scored probabilities, usually calibrated from raw scores, only required if using SparkML estimators
#' @param scoresCol Scores or raw prediction column name, only required if using SparkML estimators
#' @export

ml_compute_per_instance_statistics <- function(
    x,
    evaluationMetric="all",
    labelCol=NULL,
    scoredLabelsCol=NULL,
    scoredProbabilitiesCol=NULL,
    scoresCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_compute_per_instance_statistics"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.train.ComputePerInstanceStatistics"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setEvaluationMetric", evaluationMetric) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setScoredLabelsCol", scoredLabelsCol) %>%
        invoke("setScoredProbabilitiesCol", scoredProbabilitiesCol) %>%
        invoke("setScoresCol", scoresCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
