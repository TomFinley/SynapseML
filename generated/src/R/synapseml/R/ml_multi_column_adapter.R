
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' MultiColumnAdapter
#'
#' @param baseStage base pipeline stage to apply to every column
#' @param inputCols list of column names encoded as a string
#' @param outputCols list of column names encoded as a string
#' @export

ml_multi_column_adapter <- function(
    x,
    baseStage=NULL,
    inputCols=NULL,
    outputCols=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_multi_column_adapter"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.MultiColumnAdapter"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBaseStage", baseStage) %>%
        invoke("setInputCols", as.array(inputCols)) %>%
        invoke("setOutputCols", as.array(outputCols))
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "org.apache.spark.ml.PipelineModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
