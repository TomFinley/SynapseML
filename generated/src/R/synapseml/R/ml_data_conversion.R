
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' DataConversion
#'
#' @param cols Comma separated list of columns whose type will be converted
#' @param convertTo The result type
#' @param dateTimeFormat Format for DateTime when making DateTime:String conversions
#' @export

ml_data_conversion <- function(
    x,
    cols=NULL,
    convertTo="",
    dateTimeFormat="yyyy-MM-dd HH:mm:ss",
    only.model=FALSE,
    uid=random_string("ml_data_conversion"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.DataConversion"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setCols", as.array(cols)) %>%
        invoke("setConvertTo", convertTo) %>%
        invoke("setDateTimeFormat", dateTimeFormat)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
