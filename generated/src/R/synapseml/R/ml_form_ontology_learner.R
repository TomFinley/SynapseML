
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' FormOntologyLearner
#'
#' @param inputCol The name of the input column
#' @param outputCol The name of the output column
#' @export

ml_form_ontology_learner <- function(
    x,
    inputCol=NULL,
    outputCol=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_form_ontology_learner"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.FormOntologyLearner"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOutputCol", outputCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.cognitive.FormOntologyTransformer"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
