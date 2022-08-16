
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' OpenAICompletion
#'
#' @param apiVersion version of the api
#' @param batchIndexPrompt Sequence of index sequences to complete
#' @param batchPrompt Sequence of prompts to complete
#' @param bestOf How many generations to create server side, and display only the best. Will not stream intermediate progress if best_of > 1. Has maximum value of 128.
#' @param cacheLevel can be used to disable any server-side caching, 0=no cache, 1=prompt prefix enabled, 2=full cache
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param deploymentName The name of the deployment
#' @param echo Echo back the prompt in addition to the completion
#' @param errorCol column to hold http errors
#' @param frequencyPenalty How much to penalize new tokens based on whether they appear in the text so far. Increases the model's likelihood to talk about new topics.
#' @param handler Which strategy to use when handling requests
#' @param indexPrompt Sequence of indexes to complete
#' @param logProbs Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. So for example, if `logprobs` is 10, the API will return a list of the 10 most likely tokens. If `logprobs` is 0, only the chosen tokens will have logprobs returned. Minimum of 0 and maximum of 100 allowed.
#' @param maxTokens The maximum number of tokens to generate. Has minimum of 0.
#' @param model The name of the model to use
#' @param n How many snippets to generate for each prompt. Minimum of 1 and maximum of 128 allowed.
#' @param outputCol The name of the output column
#' @param presencePenalty How much to penalize new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim. Has minimum of -2 and maximum of 2.
#' @param prompt The text to complete
#' @param stop A sequence which indicates the end of the current document.
#' @param subscriptionKey the API key to use
#' @param temperature What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. We generally recommend using this or `top_p` but not both. Minimum of 0 and maximum of 2 allowed.
#' @param timeout number of seconds to wait before closing the connection
#' @param topP An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend using this or `temperature` but not both. Minimum of 0 and maximum of 1 allowed.
#' @param url Url of the service
#' @param user The ID of the end-user, for use in tracking and rate-limiting.
#' @export

ml_open_ai_completion <- function(
    x,
    apiVersion=NULL,
    apiVersionCol=NULL,
    batchIndexPrompt=NULL,
    batchIndexPromptCol=NULL,
    batchPrompt=NULL,
    batchPromptCol=NULL,
    bestOf=NULL,
    bestOfCol=NULL,
    cacheLevel=NULL,
    cacheLevelCol=NULL,
    concurrency=1,
    concurrentTimeout=NULL,
    deploymentName=NULL,
    deploymentNameCol=NULL,
    echo=NULL,
    echoCol=NULL,
    errorCol="OpenAPICompletion_2b7509ab1a17_error",
    frequencyPenalty=NULL,
    frequencyPenaltyCol=NULL,
    handler=NULL,
    indexPrompt=NULL,
    indexPromptCol=NULL,
    logProbs=NULL,
    logProbsCol=NULL,
    maxTokens=NULL,
    maxTokensCol=NULL,
    model=NULL,
    modelCol=NULL,
    n=NULL,
    nCol=NULL,
    outputCol="OpenAPICompletion_2b7509ab1a17_output",
    presencePenalty=NULL,
    presencePenaltyCol=NULL,
    prompt=NULL,
    promptCol=NULL,
    stop=NULL,
    stopCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    temperature=NULL,
    temperatureCol=NULL,
    timeout=60.0,
    topP=NULL,
    topPCol=NULL,
    url=NULL,
    user=NULL,
    userCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_open_ai_completion"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.OpenAICompletion"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setApiVersionCol", apiVersionCol) %>%
        invoke("setApiVersion", apiVersion) %>%
        invoke("setBatchIndexPromptCol", batchIndexPromptCol) %>%
        invoke("setBatchIndexPrompt", batchIndexPrompt) %>%
        invoke("setBatchPromptCol", batchPromptCol) %>%
        invoke("setBatchPrompt", batchPrompt) %>%
        invoke("setBestOfCol", bestOfCol) %>%
        invoke("setBestOf", bestOf) %>%
        invoke("setCacheLevelCol", cacheLevelCol) %>%
        invoke("setCacheLevel", cacheLevel) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setDeploymentNameCol", deploymentNameCol) %>%
        invoke("setDeploymentName", deploymentName) %>%
        invoke("setEchoCol", echoCol) %>%
        invoke("setEcho", echo) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFrequencyPenaltyCol", frequencyPenaltyCol) %>%
        invoke("setFrequencyPenalty", frequencyPenalty) %>%
        invoke("setHandler", handler) %>%
        invoke("setIndexPromptCol", indexPromptCol) %>%
        invoke("setIndexPrompt", indexPrompt) %>%
        invoke("setLogProbsCol", logProbsCol) %>%
        invoke("setLogProbs", logProbs) %>%
        invoke("setMaxTokensCol", maxTokensCol) %>%
        invoke("setMaxTokens", maxTokens) %>%
        invoke("setModelCol", modelCol) %>%
        invoke("setModel", model) %>%
        invoke("setNCol", nCol) %>%
        invoke("setN", n) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setPresencePenaltyCol", presencePenaltyCol) %>%
        invoke("setPresencePenalty", presencePenalty) %>%
        invoke("setPromptCol", promptCol) %>%
        invoke("setPrompt", prompt) %>%
        invoke("setStopCol", stopCol) %>%
        invoke("setStop", stop) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTemperatureCol", temperatureCol) %>%
        invoke("setTemperature", temperature) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setTopPCol", topPCol) %>%
        invoke("setTopP", topP) %>%
        invoke("setUrl", url) %>%
        invoke("setUserCol", userCol) %>%
        invoke("setUser", user)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
