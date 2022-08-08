
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' CustomInputParser
#'
#' @param inputCol The name of the input column
#' @param outputCol The name of the output column
#' @param udfPython User Defined Python Function to be applied to the DF input col
#' @param udfScala User Defined Function to be applied to the DF input col
#' @export

ml_custom_input_parser <- function(
    x,
    inputCol=NULL,
    outputCol=NULL,
    udfPython=NULL,
    udfScala=NULL,
    only.model=FALSE,
    uid=random_string("ml_custom_input_parser"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.io.http.CustomInputParser"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setUdfPython", udfPython) %>%
        invoke("setUdfScala", udfScala)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
