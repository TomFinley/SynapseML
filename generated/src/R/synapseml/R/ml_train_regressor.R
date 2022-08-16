
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TrainRegressor
#'
#' @param featuresCol The name of the features column
#' @param labelCol The name of the label column
#' @param model Regressor to run
#' @param numFeatures Number of features to hash to
#' @export

ml_train_regressor <- function(
    x,
    featuresCol="TrainRegressor_3b7ad7c39704_features",
    labelCol=NULL,
    model=NULL,
    numFeatures=0,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_train_regressor"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.train.TrainRegressor"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setModel", model) %>%
        invoke("setNumFeatures", as.integer(numFeatures))
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.train.TrainedRegressorModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
