
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ICETransformer
#'
#' @param categoricalFeatures The list of categorical features to explain.
#' @param dependenceNameCol Output column name which corresponds to dependence values of PDP-based-feature-importance option (kind == `feature`)
#' @param featureNameCol Output column name which corresponds to names of the features used in calculation of PDP-based-feature-importance option (kind == `feature`)
#' @param kind Whether to return the partial dependence plot (PDP) averaged across all the samples in the dataset or individual feature importance (ICE) per sample. Allowed values are "average" for PDP, "individual" for ICE and "feature" for PDP-based feature importance.
#' @param model The model to be interpreted.
#' @param numSamples Number of samples to generate.
#' @param numericFeatures The list of numeric features to explain.
#' @param targetClasses The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
#' @param targetClassesCol The name of the column that specifies the indices of the classes for multinomial classification models.
#' @param targetCol The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
#' @export

ml_ice_transformer <- function(
    x,
    categoricalFeatures=c(),
    dependenceNameCol="pdpBasedDependence",
    featureNameCol="featureNames",
    kind="individual",
    model=NULL,
    numSamples=NULL,
    numericFeatures=c(),
    targetClasses=c(),
    targetClassesCol=NULL,
    targetCol="probability",
    only.model=FALSE,
    uid=random_string("ml_ice_transformer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.explainers.ICETransformer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setCategoricalFeatures", categoricalFeatures) %>%
        invoke("setDependenceNameCol", dependenceNameCol) %>%
        invoke("setFeatureNameCol", featureNameCol) %>%
        invoke("setKind", kind) %>%
        invoke("setModel", model) %>%
        invoke("setNumSamples", as.integer(numSamples)) %>%
        invoke("setNumericFeatures", numericFeatures) %>%
        invoke("setTargetClasses", as.array(targetClasses)) %>%
        invoke("setTargetClassesCol", targetClassesCol) %>%
        invoke("setTargetCol", targetCol)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
