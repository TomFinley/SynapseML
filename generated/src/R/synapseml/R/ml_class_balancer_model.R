
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ClassBalancerModel
#'
#' @param broadcastJoin whether to broadcast join
#' @param inputCol The name of the input column
#' @param outputCol The name of the output column
#' @param weights the dataframe of weights
#' @export

ml_class_balancer_model <- function(
    x,
    broadcastJoin=NULL,
    inputCol=NULL,
    outputCol=NULL,
    weights=NULL,
    only.model=FALSE,
    uid=random_string("ml_class_balancer_model"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.ClassBalancerModel"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBroadcastJoin", as.logical(broadcastJoin)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setWeights", weights)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
