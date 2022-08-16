
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ValueIndexerModel
#'
#' @param dataType The datatype of the levels as a Json string
#' @param inputCol The name of the input column
#' @param levels Levels in categorical array
#' @param outputCol The name of the output column
#' @export

ml_value_indexer_model <- function(
    x,
    dataType="string",
    inputCol="input",
    levels=NULL,
    outputCol="ValueIndexerModel_c582deb2ff79_output",
    only.model=FALSE,
    uid=random_string("ml_value_indexer_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.ValueIndexerModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setDataType", dataType) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setLevels", levels) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
