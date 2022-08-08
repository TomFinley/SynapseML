
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' AggregateBalanceMeasure
#'
#' @param epsilon Epsilon value for Atkinson Index. Inverse of alpha (1 - alpha).
#' @param errorTolerance Error tolerance value for Atkinson Index.
#' @param outputCol output column name
#' @param sensitiveCols Sensitive columns to use.
#' @param verbose Whether to show intermediate measures and calculations, such as Positive Rate.
#' @export

ml_aggregate_balance_measure <- function(
    x,
    epsilon=1.0,
    errorTolerance=1.0E-12,
    outputCol="AggregateBalanceMeasure",
    sensitiveCols=NULL,
    verbose=FALSE,
    only.model=FALSE,
    uid=random_string("ml_aggregate_balance_measure"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.exploratory.AggregateBalanceMeasure"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setEpsilon", as.double(epsilon)) %>%
        invoke("setErrorTolerance", as.double(errorTolerance)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setSensitiveCols", as.array(sensitiveCols)) %>%
        invoke("setVerbose", as.logical(verbose))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
