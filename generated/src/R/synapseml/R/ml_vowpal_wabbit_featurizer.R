
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' VowpalWabbitFeaturizer
#'
#' @param inputCols The names of the input columns
#' @param numBits Number of bits used to mask
#' @param outputCol The name of the output column
#' @param prefixStringsWithColumnName Prefix string features with column name
#' @param preserveOrderNumBits Number of bits used to preserve the feature order. This will reduce the hash size. Needs to be large enough to fit count the maximum number of words
#' @param seed Hash seed
#' @param stringSplitInputCols Input cols that should be split at word boundaries
#' @param sumCollisions Sums collisions if true, otherwise removes them
#' @export

ml_vowpal_wabbit_featurizer <- function(
    x,
    inputCols=c(),
    numBits=30,
    outputCol="features",
    prefixStringsWithColumnName=TRUE,
    preserveOrderNumBits=0,
    seed=0,
    stringSplitInputCols=c(),
    sumCollisions=TRUE,
    only.model=FALSE,
    uid=random_string("ml_vowpal_wabbit_featurizer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.vw.VowpalWabbitFeaturizer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setNumBits", as.integer(numBits)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPrefixStringsWithColumnName", as.logical(prefixStringsWithColumnName)) %>%
        invoke("setPreserveOrderNumBits", as.integer(preserveOrderNumBits)) %>%
        invoke("setSeed", as.integer(seed)) %>%
        invoke("setStringSplitInputCols", as.array(stringSplitInputCols)) %>%
        invoke("setSumCollisions", as.logical(sumCollisions))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
