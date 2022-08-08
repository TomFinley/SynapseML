
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' Featurize
#'
#' @param imputeMissing Whether to impute missing values
#' @param inputCols The names of the input columns
#' @param numFeatures Number of features to hash string columns to
#' @param oneHotEncodeCategoricals One-hot encode categorical columns
#' @param outputCol The name of the output column
#' @export

ml_featurize <- function(
    x,
    imputeMissing=TRUE,
    inputCols=NULL,
    numFeatures=262144,
    oneHotEncodeCategoricals=TRUE,
    outputCol=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_featurize"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.Featurize"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setImputeMissing", as.logical(imputeMissing)) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setNumFeatures", as.integer(numFeatures)) %>%
        invoke("setOneHotEncodeCategoricals", as.logical(oneHotEncodeCategoricals)) %>%
        invoke("setOutputCol", outputCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "org.apache.spark.ml.PipelineModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
