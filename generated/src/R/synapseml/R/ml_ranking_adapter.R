
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' RankingAdapter
#'
#' @param itemCol Column of items
#' @param k number of items
#' @param labelCol The name of the label column
#' @param minRatingsPerItem min ratings for items > 0
#' @param minRatingsPerUser min ratings for users > 0
#' @param mode recommendation mode
#' @param ratingCol Column of ratings
#' @param recommender estimator for selection
#' @param userCol Column of users
#' @export

ml_ranking_adapter <- function(
    x,
    itemCol=NULL,
    k=10,
    labelCol="label",
    minRatingsPerItem=1,
    minRatingsPerUser=1,
    mode="allUsers",
    ratingCol=NULL,
    recommender=NULL,
    userCol=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_ranking_adapter"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.recommendation.RankingAdapter"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setItemCol", itemCol) %>%
        invoke("setK", as.integer(k)) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setMinRatingsPerItem", as.integer(minRatingsPerItem)) %>%
        invoke("setMinRatingsPerUser", as.integer(minRatingsPerUser)) %>%
        invoke("setMode", mode) %>%
        invoke("setRatingCol", ratingCol) %>%
        invoke("setRecommender", recommender) %>%
        invoke("setUserCol", userCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.recommendation.RankingAdapterModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
