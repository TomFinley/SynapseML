
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' RecommendationIndexerModel
#'
#' @param itemIndexModel itemIndexModel
#' @param itemInputCol Item Input Col
#' @param itemOutputCol Item Output Col
#' @param ratingCol Rating Col
#' @param userIndexModel userIndexModel
#' @param userInputCol User Input Col
#' @param userOutputCol User Output Col
#' @export

ml_recommendation_indexer_model <- function(
    x,
    itemIndexModel=NULL,
    itemInputCol=NULL,
    itemOutputCol=NULL,
    ratingCol=NULL,
    userIndexModel=NULL,
    userInputCol=NULL,
    userOutputCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_recommendation_indexer_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.recommendation.RecommendationIndexerModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setItemIndexModel", itemIndexModel) %>%
        invoke("setItemInputCol", itemInputCol) %>%
        invoke("setItemOutputCol", itemOutputCol) %>%
        invoke("setRatingCol", ratingCol) %>%
        invoke("setUserIndexModel", userIndexModel) %>%
        invoke("setUserInputCol", userInputCol) %>%
        invoke("setUserOutputCol", userOutputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
