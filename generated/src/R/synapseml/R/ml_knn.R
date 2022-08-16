
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' KNN
#'
#' @param featuresCol The name of the features column
#' @param k number of matches to return
#' @param leafSize max size of the leaves of the tree
#' @param outputCol The name of the output column
#' @param valuesCol column holding values for each feature (key) that will be returned when queried
#' @export

ml_knn <- function(
    x,
    featuresCol="features",
    k=5,
    leafSize=50,
    outputCol="KNN_a8686cc77f13_output",
    valuesCol="values",
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_knn"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.nn.KNN"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setK", as.integer(k)) %>%
        invoke("setLeafSize", as.integer(leafSize)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setValuesCol", valuesCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.nn.KNNModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
