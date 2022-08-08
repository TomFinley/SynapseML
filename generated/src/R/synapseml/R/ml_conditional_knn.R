
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ConditionalKNN
#'
#' @param conditionerCol column holding identifiers for features that will be returned when queried
#' @param featuresCol The name of the features column
#' @param k number of matches to return
#' @param labelCol The name of the label column
#' @param leafSize max size of the leaves of the tree
#' @param outputCol The name of the output column
#' @param valuesCol column holding values for each feature (key) that will be returned when queried
#' @export

ml_conditional_knn <- function(
    x,
    conditionerCol="conditioner",
    featuresCol="features",
    k=5,
    labelCol="labels",
    leafSize=50,
    outputCol="ConditionalKNN_57b679597047_output",
    valuesCol="values",
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_conditional_knn"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.nn.ConditionalKNN"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setConditionerCol", conditionerCol) %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setK", as.integer(k)) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setLeafSize", as.integer(leafSize)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setValuesCol", valuesCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.nn.ConditionalKNNModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
