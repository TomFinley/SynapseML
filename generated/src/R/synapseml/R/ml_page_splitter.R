
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' PageSplitter
#'
#' @param boundaryRegex how to split into words
#' @param inputCol The name of the input column
#' @param maximumPageLength the maximum number of characters to be in a page
#' @param minimumPageLength the the minimum number of characters to have on a page in order to preserve work boundaries
#' @param outputCol The name of the output column
#' @export

ml_page_splitter <- function(
    x,
    boundaryRegex="\\s",
    inputCol=NULL,
    maximumPageLength=5000,
    minimumPageLength=4500,
    outputCol="PageSplitter_17dbb50b30cf_output",
    only.model=FALSE,
    uid=random_string("ml_page_splitter"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.text.PageSplitter"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBoundaryRegex", boundaryRegex) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setMaximumPageLength", as.integer(maximumPageLength)) %>%
        invoke("setMinimumPageLength", as.integer(minimumPageLength)) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
