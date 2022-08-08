
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' CNTKModel
#'
#' @param batchInput whether to use a batcher
#' @param convertOutputToDenseVector whether to convert the output to dense vectors
#' @param feedDict  Provide a map from CNTK/ONNX model input variable names (keys) to column names of the input dataframe (values)
#' @param fetchDict Provide a map from column names of the output dataframe (keys) to CNTK/ONNX model output variable names (values)
#' @param miniBatcher Minibatcher to use
#' @param model Array of bytes containing the serialized CNTKModel
#' @export

ml_cntk_model <- function(
    x,
    batchInput=TRUE,
    convertOutputToDenseVector=TRUE,
    feedDict={"ARGUMENT_0":"ARGUMENT_0"},
    fetchDict={"OUTPUT_0":"OUTPUT_0"},
    miniBatcher=NULL,
    model=NULL,
    only.model=FALSE,
    uid=random_string("ml_cntk_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cntk.CNTKModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBatchInput", as.logical(batchInput)) %>%
        invoke("setConvertOutputToDenseVector", as.logical(convertOutputToDenseVector)) %>%
        invoke("setFeedDict", feedDict) %>%
        invoke("setFetchDict", fetchDict) %>%
        invoke("setMiniBatcher", miniBatcher) %>%
        invoke("setModel", model)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
