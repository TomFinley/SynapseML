
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TrainClassifier
#'
#' @param featuresCol The name of the features column
#' @param labelCol The name of the label column
#' @param labels Sorted label values on the labels column
#' @param model Classifier to run
#' @param numFeatures Number of features to hash to
#' @param reindexLabel Re-index the label column
#' @export

ml_train_classifier <- function(
    x,
    featuresCol="TrainClassifier_49f28fbfe05b_features",
    labelCol=NULL,
    labels=NULL,
    model=NULL,
    numFeatures=0,
    reindexLabel=TRUE,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_train_classifier"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.train.TrainClassifier"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setLabels", as.array(labels)) %>%
        invoke("setModel", model) %>%
        invoke("setNumFeatures", as.integer(numFeatures)) %>%
        invoke("setReindexLabel", as.logical(reindexLabel))
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.train.TrainedClassifierModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
