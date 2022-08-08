
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' TextToSpeech
#'
#' @param errorCol column to hold http errors
#' @param language The name of the language used for synthesis
#' @param locale The locale of the input text
#' @param outputFileCol The location of the saved file as an HDFS compliant URI
#' @param outputFormat The format for the output audio can be one of ArraySeq(Raw8Khz8BitMonoMULaw, Riff16Khz16KbpsMonoSiren, Audio16Khz16KbpsMonoSiren, Audio16Khz32KBitRateMonoMp3, Audio16Khz128KBitRateMonoMp3, Audio16Khz64KBitRateMonoMp3, Audio24Khz48KBitRateMonoMp3, Audio24Khz96KBitRateMonoMp3, Audio24Khz160KBitRateMonoMp3, Raw16Khz16BitMonoTrueSilk, Riff16Khz16BitMonoPcm, Riff8Khz16BitMonoPcm, Riff24Khz16BitMonoPcm, Riff8Khz8BitMonoMULaw, Raw16Khz16BitMonoPcm, Raw24Khz16BitMonoPcm, Raw8Khz16BitMonoPcm, Ogg16Khz16BitMonoOpus, Ogg24Khz16BitMonoOpus)
#' @param subscriptionKey the API key to use
#' @param text The text to synthesize
#' @param url Url of the service
#' @param voiceName The name of the voice used for synthesis
#' @export

ml_text_to_speech <- function(
    x,
    errorCol="TextToSpeech_08bdd3290eac_errors",
    language=NULL,
    languageCol=NULL,
    locale=NULL,
    localeCol=NULL,
    outputFileCol=NULL,
    outputFormat=NULL,
    outputFormatCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    text=NULL,
    textCol=NULL,
    url=NULL,
    voiceName=NULL,
    voiceNameCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_text_to_speech"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.TextToSpeech"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setLocaleCol", localeCol) %>%
        invoke("setLocale", locale) %>%
        invoke("setOutputFileCol", outputFileCol) %>%
        invoke("setOutputFormatCol", outputFormatCol) %>%
        invoke("setOutputFormat", outputFormat) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTextCol", textCol) %>%
        invoke("setText", text) %>%
        invoke("setUrl", url) %>%
        invoke("setVoiceNameCol", voiceNameCol) %>%
        invoke("setVoiceName", voiceName)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
