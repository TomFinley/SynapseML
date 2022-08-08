
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TextFeaturizer
#'
#' @param binary If true, all nonegative word counts are set to 1
#' @param caseSensitiveStopWords  Whether to do a case sensitive comparison over the stop words
#' @param defaultStopWordLanguage Which language to use for the stop word remover, set this to custom to use the stopWords input
#' @param inputCol The name of the input column
#' @param minDocFreq The minimum number of documents in which a term should appear.
#' @param minTokenLength Minimum token length, >= 0.
#' @param nGramLength The size of the Ngrams
#' @param numFeatures Set the number of features to hash each document to
#' @param outputCol The name of the output column
#' @param stopWords The words to be filtered out.
#' @param toLowercase Indicates whether to convert all characters to lowercase before tokenizing.
#' @param tokenizerGaps Indicates whether regex splits on gaps (true) or matches tokens (false).
#' @param tokenizerPattern Regex pattern used to match delimiters if gaps is true or tokens if gaps is false.
#' @param useIDF Whether to scale the Term Frequencies by IDF
#' @param useNGram Whether to enumerate N grams
#' @param useStopWordsRemover Whether to remove stop words from tokenized data
#' @param useTokenizer Whether to tokenize the input
#' @export

ml_text_featurizer <- function(
    x,
    binary=FALSE,
    caseSensitiveStopWords=FALSE,
    defaultStopWordLanguage="english",
    inputCol=NULL,
    minDocFreq=1,
    minTokenLength=0,
    nGramLength=2,
    numFeatures=262144,
    outputCol="TextFeaturizer_9dbd2bc8aa07_output",
    stopWords=NULL,
    toLowercase=TRUE,
    tokenizerGaps=TRUE,
    tokenizerPattern="\\s+",
    useIDF=TRUE,
    useNGram=FALSE,
    useStopWordsRemover=FALSE,
    useTokenizer=TRUE,
    unfit.model=FALSE,
    only.model=FALSE,
    uid=random_string("ml_text_featurizer"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.featurize.text.TextFeaturizer"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setBinary", as.logical(binary)) %>%
        invoke("setCaseSensitiveStopWords", as.logical(caseSensitiveStopWords)) %>%
        invoke("setDefaultStopWordLanguage", defaultStopWordLanguage) %>%
        invoke("setInputCol", inputCol) %>%
        invoke("setMinDocFreq", as.integer(minDocFreq)) %>%
        invoke("setMinTokenLength", as.integer(minTokenLength)) %>%
        invoke("setNGramLength", as.integer(nGramLength)) %>%
        invoke("setNumFeatures", as.integer(numFeatures)) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setStopWords", stopWords) %>%
        invoke("setToLowercase", as.logical(toLowercase)) %>%
        invoke("setTokenizerGaps", as.logical(tokenizerGaps)) %>%
        invoke("setTokenizerPattern", tokenizerPattern) %>%
        invoke("setUseIDF", as.logical(useIDF)) %>%
        invoke("setUseNGram", as.logical(useNGram)) %>%
        invoke("setUseStopWordsRemover", as.logical(useStopWordsRemover)) %>%
        invoke("setUseTokenizer", as.logical(useTokenizer))
    
    if (unfit.model)
        return(mod_parameterized)
    transformer <- mod_parameterized %>%
        invoke("fit", df)
    scala_transformer_class <- "org.apache.spark.ml.PipelineModel"
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
