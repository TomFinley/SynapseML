
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' StratifiedRepartition
#'
#' @param labelCol The name of the label column
#' @param mode Specify equal to repartition with replacement across all labels, specify original to keep the ratios in the original dataset, or specify mixed to use a heuristic
#' @param seed random seed
#' @export

ml_stratified_repartition <- function(
    x,
    labelCol=NULL,
    mode="mixed",
    seed=1518410069,
    only.model=FALSE,
    uid=random_string("ml_stratified_repartition"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.stages.StratifiedRepartition"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setMode", mode) %>%
        invoke("setSeed", as.integer(seed))
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
