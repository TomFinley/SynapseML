
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ClassBalancer
#'
#' @param broadcastJoin Whether to broadcast the class to weight mapping to the worker
#' @param inputCol The name of the input column
#' @param outputCol The name of the output column
#' @export

ml_class_balancer <- function(
    x,
    broadcastJoin=TRUE,
    inputCol=NULL,
    outputCol="weight",
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_class_balancer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.ClassBalancer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBroadcastJoin", as.logical(broadcastJoin)) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOutputCol", outputCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.stages.ClassBalancerModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
