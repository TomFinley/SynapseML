
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' SummarizeData
#'
#' @param basic Compute basic statistics
#' @param counts Compute count statistics
#' @param errorThreshold Threshold for quantiles - 0 is exact
#' @param percentiles Compute percentiles
#' @param sample Compute sample statistics
#' @export

ml_summarize_data <- function(
    x,
    basic=TRUE,
    counts=TRUE,
    errorThreshold=0.0,
    percentiles=TRUE,
    sample=TRUE,
    only.model=FALSE,
    uid=random_string("ml_summarize_data"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.SummarizeData"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBasic", as.logical(basic)) %>%
        invoke("setCounts", as.logical(counts)) %>%
        invoke("setErrorThreshold", as.double(errorThreshold)) %>%
        invoke("setPercentiles", as.logical(percentiles)) %>%
        invoke("setSample", as.logical(sample))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
