
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' UnicodeNormalize
#'
#' @param form Unicode normalization form: NFC, NFD, NFKC, NFKD
#' @param inputCol The name of the input column
#' @param lower Lowercase text
#' @param outputCol The name of the output column
#' @export

ml_unicode_normalize <- function(
    x,
    form=NULL,
    inputCol=NULL,
    lower=NULL,
    outputCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_unicode_normalize"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.UnicodeNormalize"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setForm", form) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setLower", as.logical(lower)) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
