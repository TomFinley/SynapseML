
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ImageTransformer
#'
#' @param colorScaleFactor The scale factor for color values. Used for normalization. The color values will be multiplied with the scale factor.
#' @param inputCol The name of the input column
#' @param normalizeMean The mean value to use for normalization for each channel. The length of the array must match the number of channels of the input image.
#' @param normalizeStd The standard deviation to use for normalization for each channel. The length of the array must match the number of channels of the input image.
#' @param outputCol The name of the output column
#' @param stages Image transformation stages
#' @param tensorChannelOrder The color channel order of the output channels. Valid values are RGB and GBR. Default: RGB.
#' @param tensorElementType The element data type for the output tensor. Only used when toTensor is set to true. Valid values are DoubleType or FloatType. Default value: FloatType.
#' @param toTensor Convert output image to tensor in the shape of (C * H * W)
#' @export

ml_image_transformer <- function(
    x,
    colorScaleFactor=NULL,
    inputCol="image",
    normalizeMean=NULL,
    normalizeStd=NULL,
    outputCol="ImageTransformer_33fdea758651_output",
    stages=NULL,
    tensorChannelOrder="RGB",
    tensorElementType=NULL,
    toTensor=FALSE,
    only.model=FALSE,
    uid=random_string("ml_image_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.opencv.ImageTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setColorScaleFactor", as.double(colorScaleFactor)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setNormalizeMean", as.array(normalizeMean)) %>%
        invoke("setNormalizeStd", as.array(normalizeStd)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setStages", stages) %>%
        invoke("setTensorChannelOrder", tensorChannelOrder) %>%
        invoke("setTensorElementType", tensorElementType) %>%
        invoke("setToTensor", as.logical(toTensor))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
