
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' VowpalWabbitRegressor
#'
#' @param additionalFeatures Additional feature columns
#' @param featuresCol features column name
#' @param hashSeed Seed used for hashing
#' @param ignoreNamespaces Namespaces to be ignored (first letter only)
#' @param initialModel Initial model to start from
#' @param interactions Interaction terms as specified by -q
#' @param l1 l_1 lambda
#' @param l2 l_2 lambda
#' @param labelCol label column name
#' @param learningRate Learning rate
#' @param numBits Number of bits used
#' @param numPasses Number of passes over the data
#' @param passThroughArgs VW command line arguments passed
#' @param powerT t power value
#' @param predictionCol prediction column name
#' @param useBarrierExecutionMode Use barrier execution mode, on by default.
#' @param weightCol The name of the weight column
#' @export

ml_vowpal_wabbit_regressor <- function(
    x,
    additionalFeatures=c(),
    featuresCol="features",
    hashSeed=0,
    ignoreNamespaces=NULL,
    initialModel=NULL,
    interactions=NULL,
    l1=NULL,
    l2=NULL,
    labelCol="label",
    learningRate=NULL,
    numBits=18,
    numPasses=1,
    passThroughArgs="",
    powerT=NULL,
    predictionCol="prediction",
    useBarrierExecutionMode=TRUE,
    weightCol=NULL,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_vowpal_wabbit_regressor"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.vw.VowpalWabbitRegressor"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAdditionalFeatures", as.array(additionalFeatures)) %>%
        invoke("setFeaturesCol", featuresCol) %>%
        invoke("setHashSeed", as.integer(hashSeed)) %>%
        invoke("setIgnoreNamespaces", ignoreNamespaces) %>%
        invoke("setInitialModel", initialModel) %>%
        invoke("setInteractions", as.array(interactions)) %>%
        invoke("setL1", as.double(l1)) %>%
        invoke("setL2", as.double(l2)) %>%
        invoke("setLabelCol", labelCol) %>%
        invoke("setLearningRate", as.double(learningRate)) %>%
        invoke("setNumBits", as.integer(numBits)) %>%
        invoke("setNumPasses", as.integer(numPasses)) %>%
        invoke("setPassThroughArgs", passThroughArgs) %>%
        invoke("setPowerT", as.double(powerT)) %>%
        invoke("setPredictionCol", predictionCol) %>%
        invoke("setUseBarrierExecutionMode", as.logical(useBarrierExecutionMode)) %>%
        invoke("setWeightCol", weightCol)
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.vw.VowpalWabbitRegressionModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
