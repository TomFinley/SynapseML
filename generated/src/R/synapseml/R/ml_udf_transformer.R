
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' UDFTransformer
#'
#' @param inputCol The name of the input column
#' @param inputCols The names of the input columns
#' @param outputCol The name of the output column
#' @param udf User Defined Python Function to be applied to the DF input col
#' @param udfScala User Defined Function to be applied to the DF input col
#' @export

ml_udf_transformer <- function(
    x,
    inputCol=NULL,
    inputCols=NULL,
    outputCol="UDFTransformer_34e044568beb_output",
    udf=NULL,
    udfScala=NULL,
    only.model=FALSE,
    uid=random_string("ml_udf_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.UDFTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setUdf", udf) %>%
        invoke("setUdfScala", udfScala)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
