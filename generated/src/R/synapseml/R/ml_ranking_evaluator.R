
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' RankingEvaluator
#'
#' @param itemCol Column of items
#' @param k number of items
#' @param labelCol label column name
#' @param metricName metric name in evaluation (ndcgAt|map|precisionAtk|recallAtK|diversityAtK|maxDiversity|mrr|fcp)
#' @param nItems number of items
#' @param predictionCol prediction column name
#' @param ratingCol Column of ratings
#' @param userCol Column of users
#' @export

ml_ranking_evaluator <- function(
    x,
    itemCol=NULL,
    k=10,
    labelCol="label",
    metricName="ndcgAt",
    nItems=-1,
    predictionCol="prediction",
    ratingCol=NULL,
    userCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_ranking_evaluator"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.recommendation.RankingEvaluator"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setItemCol", itemCol) %>%
        invoke("setK", as.integer(k)) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setMetricName", metricName) %>%
        invoke("setNItems", as.integer(nItems)) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setRatingCol", ratingCol) %>%
        invoke("setUserCol", userCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
