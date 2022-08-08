
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ONNXModel
#'
#' @param argMaxDict A map between output dataframe columns, where the value column will be computed from taking the argmax of the key column. This can be used to convert probability output to predicted label.
#' @param deviceType Specify a device type the model inference runs on. Supported types are: CPU or CUDA.If not specified, auto detection will be used.
#' @param feedDict  Provide a map from CNTK/ONNX model input variable names (keys) to column names of the input dataframe (values)
#' @param fetchDict Provide a map from column names of the output dataframe (keys) to CNTK/ONNX model output variable names (values)
#' @param miniBatcher Minibatcher to use
#' @param modelPayload Array of bytes containing the serialized ONNX model.
#' @param optimizationLevel Specify the optimization level for the ONNX graph optimizations. Details at https://onnxruntime.ai/docs/resources/graph-optimizations.html#graph-optimization-levels. Supported values are: NO_OPT; BASIC_OPT; EXTENDED_OPT; ALL_OPT. Default: ALL_OPT.
#' @param softMaxDict A map between output dataframe columns, where the value column will be computed from taking the softmax of the key column. If the 'rawPrediction' column contains logits outputs, then one can set softMaxDict to `Map("rawPrediction" -> "probability")` to obtain the probability outputs.
#' @export

ml_onnx_model <- function(
    x,
    argMaxDict=NULL,
    deviceType=NULL,
    feedDict=NULL,
    fetchDict=NULL,
    miniBatcher=NULL,
    modelPayload=NULL,
    optimizationLevel="ALL_OPT",
    softMaxDict=NULL,
    only.model=FALSE,
    uid=random_string("ml_onnx_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.onnx.ONNXModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setArgMaxDict", argMaxDict) %>%
        invoke("setDeviceType", deviceType) %>%
        invoke("setFeedDict", feedDict) %>%
        invoke("setFetchDict", fetchDict) %>%
        invoke("setMiniBatcher", miniBatcher) %>%
        invoke("setModelPayload", modelPayload) %>%
        invoke("setOptimizationLevel", optimizationLevel) %>%
        invoke("setSoftMaxDict", softMaxDict)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
