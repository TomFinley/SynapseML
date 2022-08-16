
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' MultiNGram
#'
#' @param inputCol The name of the input column
#' @param lengths the collection of lengths to use for ngram extraction
#' @param outputCol The name of the output column
#' @export

ml_multi_n_gram <- function(
    x,
    inputCol=NULL,
    lengths=NULL,
    outputCol="MultiNGram_66226d2face4_output",
    only.model=FALSE,
    uid=random_string("ml_multi_n_gram"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.text.MultiNGram"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setLengths", lengths) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
