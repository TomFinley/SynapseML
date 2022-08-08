
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TuneHyperparameters
#'
#' @param evaluationMetric Metric to evaluate models with
#' @param models Estimators to run
#' @param numFolds Number of folds
#' @param numRuns Termination criteria for randomized search
#' @param parallelism The number of models to run in parallel
#' @param paramSpace Parameter space for generating hyperparameters
#' @param seed Random number generator seed
#' @export

ml_tune_hyperparameters <- function(
    x,
    evaluationMetric=NULL,
    models=NULL,
    numFolds=NULL,
    numRuns=NULL,
    parallelism=NULL,
    paramSpace=NULL,
    seed=0,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_tune_hyperparameters"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.automl.TuneHyperparameters"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setEvaluationMetric", evaluationMetric) %>%
        invoke("setModels", models) %>%
        invoke("setNumFolds", as.integer(numFolds)) %>%
        invoke("setNumRuns", as.integer(numRuns)) %>%
        invoke("setParallelism", as.integer(parallelism)) %>%
        invoke("setParamSpace", paramSpace) %>%
        invoke("setSeed", as.integer(seed))
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "com.microsoft.azure.synapse.ml.automl.TuneHyperparametersModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
