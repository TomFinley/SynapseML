
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' JSONOutputParser
#'
#' @param dataType format to parse the column to
#' @param inputCol The name of the input column
#' @param outputCol The name of the output column
#' @param postProcessor optional transformation to postprocess json output
#' @export

ml_json_output_parser <- function(
    x,
    dataType=NULL,
    inputCol=NULL,
    outputCol=NULL,
    postProcessor=NULL,
    only.model=FALSE,
    uid=random_string("ml_json_output_parser"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.io.http.JSONOutputParser"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setDataType", dataType) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPostProcessor", postProcessor)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
