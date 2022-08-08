
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' CountSelectorModel
#'
#' @param indices An array of indices to select features from a vector column. There can be no overlap with names.
#' @param inputCol The name of the input column
#' @param outputCol The name of the output column
#' @export

ml_count_selector_model <- function(
    x,
    indices=NULL,
    inputCol=NULL,
    outputCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_count_selector_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.CountSelectorModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setIndices", as.array(indices)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
