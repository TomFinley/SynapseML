
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TrainedClassifierModel
#'
#' @param featuresCol The name of the features column
#' @param labelCol The name of the label column
#' @param levels the levels
#' @param model model produced by training
#' @export

ml_trained_classifier_model <- function(
    x,
    featuresCol=NULL,
    labelCol=NULL,
    levels=NULL,
    model=NULL,
    only.model=FALSE,
    uid=random_string("ml_trained_classifier_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.train.TrainedClassifierModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setLevels", levels) %>%
        invoke("setModel", model)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
