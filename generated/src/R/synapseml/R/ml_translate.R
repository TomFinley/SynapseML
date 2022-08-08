
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' Translate
#'
#' @param allowFallback Specifies that the service is allowed to fall back to a general system when a custom system does not exist. 
#' @param category A string specifying the category (domain) of the translation. This parameter is used to get translations from a customized system built with Custom Translator. Add the Category ID from your Custom Translator project details to this parameter to use your deployed customized system. Default value is: general.
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param fromLanguage Specifies the language of the input text. Find which languages are available to translate from by looking up supported languages using the translation scope. If the from parameter is not specified, automatic language detection is applied to determine the source language. You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
#' @param fromScript Specifies the script of the input text.
#' @param handler Which strategy to use when handling requests
#' @param includeAlignment Specifies whether to include alignment projection from source text to translated text.
#' @param includeSentenceLength Specifies whether to include sentence boundaries for the input text and the translated text. 
#' @param outputCol The name of the output column
#' @param profanityAction Specifies how profanities should be treated in translations. Possible values are: NoAction (default), Marked or Deleted. 
#' @param profanityMarker Specifies how profanities should be marked in translations. Possible values are: Asterisk (default) or Tag.
#' @param subscriptionKey the API key to use
#' @param subscriptionRegion the API region to use
#' @param suggestedFrom Specifies a fallback language if the language of the input text can't be identified. Language autodetection is applied when the from parameter is omitted. If detection fails, the suggestedFrom language will be assumed.
#' @param text the string to translate
#' @param textType Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed, complete element. Possible values are: plain (default) or html.
#' @param timeout number of seconds to wait before closing the connection
#' @param toLanguage Specifies the language of the output text. The target language must be one of the supported languages included in the translation scope. For example, use to=de to translate to German. It's possible to translate to multiple languages simultaneously by repeating the parameter in the query string. For example, use to=de and to=it to translate to German and Italian.
#' @param toScript Specifies the script of the translated text.
#' @param url Url of the service
#' @export

ml_translate <- function(
    x,
    allowFallback=NULL,
    allowFallbackCol=NULL,
    category=NULL,
    categoryCol=NULL,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="Translate_43738c7718a0_error",
    fromLanguage=NULL,
    fromLanguageCol=NULL,
    fromScript=NULL,
    fromScriptCol=NULL,
    handler=NULL,
    includeAlignment=NULL,
    includeAlignmentCol=NULL,
    includeSentenceLength=NULL,
    includeSentenceLengthCol=NULL,
    outputCol="Translate_43738c7718a0_output",
    profanityAction=NULL,
    profanityActionCol=NULL,
    profanityMarker=NULL,
    profanityMarkerCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    subscriptionRegion=NULL,
    subscriptionRegionCol=NULL,
    suggestedFrom=NULL,
    suggestedFromCol=NULL,
    text=NULL,
    textCol=NULL,
    textType=NULL,
    textTypeCol=NULL,
    timeout=60.0,
    toLanguage=NULL,
    toLanguageCol=NULL,
    toScript=NULL,
    toScriptCol=NULL,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_translate"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.Translate"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAllowFallbackCol", allowFallbackCol) %>%
        invoke("setAllowFallback", allowFallback) %>%
        invoke("setCategoryCol", categoryCol) %>%
        invoke("setCategory", category) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFromLanguageCol", fromLanguageCol) %>%
        invoke("setFromLanguage", fromLanguage) %>%
        invoke("setFromScriptCol", fromScriptCol) %>%
        invoke("setFromScript", fromScript) %>%
        invoke("setHandler", handler) %>%
        invoke("setIncludeAlignmentCol", includeAlignmentCol) %>%
        invoke("setIncludeAlignment", includeAlignment) %>%
        invoke("setIncludeSentenceLengthCol", includeSentenceLengthCol) %>%
        invoke("setIncludeSentenceLength", includeSentenceLength) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setProfanityActionCol", profanityActionCol) %>%
        invoke("setProfanityAction", profanityAction) %>%
        invoke("setProfanityMarkerCol", profanityMarkerCol) %>%
        invoke("setProfanityMarker", profanityMarker) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setSubscriptionRegionCol", subscriptionRegionCol) %>%
        invoke("setSubscriptionRegion", subscriptionRegion) %>%
        invoke("setSuggestedFromCol", suggestedFromCol) %>%
        invoke("setSuggestedFrom", suggestedFrom) %>%
        invoke("setTextCol", textCol) %>%
        invoke("setText", text) %>%
        invoke("setTextTypeCol", textTypeCol) %>%
        invoke("setTextType", textType) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setToLanguageCol", toLanguageCol) %>%
        invoke("setToLanguage", toLanguage) %>%
        invoke("setToScriptCol", toScriptCol) %>%
        invoke("setToScript", toScript) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
