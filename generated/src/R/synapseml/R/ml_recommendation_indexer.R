
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' RecommendationIndexer
#'
#' @param itemInputCol Item Input Col
#' @param itemOutputCol Item Output Col
#' @param ratingCol Rating Col
#' @param userInputCol User Input Col
#' @param userOutputCol User Output Col
#' @export

ml_recommendation_indexer <- function(
    x,
    itemInputCol=NULL,
    itemOutputCol=NULL,
    ratingCol=NULL,
    userInputCol=NULL,
    userOutputCol=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_recommendation_indexer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.recommendation.RecommendationIndexer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setItemInputCol", itemInputCol) %>%
        invoke("setItemOutputCol", itemOutputCol) %>%
        invoke("setRatingCol", ratingCol) %>%
        invoke("setUserInputCol", userInputCol) %>%
        invoke("setUserOutputCol", userOutputCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.recommendation.RecommendationIndexerModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
