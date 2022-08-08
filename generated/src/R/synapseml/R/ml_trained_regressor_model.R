
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TrainedRegressorModel
#'
#' @param featuresCol The name of the features column
#' @param labelCol The name of the label column
#' @param model model produced by training
#' @export

ml_trained_regressor_model <- function(
    x,
    featuresCol=NULL,
    labelCol=NULL,
    model=NULL,
    only.model=FALSE,
    uid=random_string("ml_trained_regressor_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.train.TrainedRegressorModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setModel", model)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
