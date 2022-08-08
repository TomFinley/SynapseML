
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' FormOntologyTransformer
#'
#' @param inputCol The name of the input column
#' @param ontology The ontology to cast values to
#' @param outputCol The name of the output column
#' @export

ml_form_ontology_transformer <- function(
    x,
    inputCol=NULL,
    ontology=NULL,
    outputCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_form_ontology_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.FormOntologyTransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setOntology", ontology) %>%
        invoke("setOutputCol", outputCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
