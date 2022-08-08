
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' ConversationTranscription
#'
#' @param audioDataCol Column holding audio data, must be either ByteArrays or Strings representing file URIs
#' @param endpointId endpoint for custom speech models
#' @param extraFfmpegArgs extra arguments to for ffmpeg output decoding
#' @param fileType The file type of the sound files, supported types: wav, ogg, mp3
#' @param format  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
#' @param language  Identifies the spoken language that is being recognized.     
#' @param outputCol The name of the output column
#' @param participantsJson a json representation of a list of conversation participants (email, language, user)
#' @param profanity  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
#' @param recordAudioData Whether to record audio data to a file location, for use only with m3u8 streams
#' @param recordedFileNameCol Column holding file names to write audio data to if ``recordAudioData'' is set to true
#' @param streamIntermediateResults Whether or not to immediately return itermediate results, or group in a sequence
#' @param subscriptionKey the API key to use
#' @param url Url of the service
#' @export

ml_conversation_transcription <- function(
    x,
    audioDataCol=NULL,
    endpointId=NULL,
    extraFfmpegArgs=c(),
    fileType=NULL,
    fileTypeCol=NULL,
    format=NULL,
    formatCol=NULL,
    language=NULL,
    languageCol=NULL,
    outputCol=NULL,
    participantsJson=NULL,
    participantsJsonCol=NULL,
    profanity=NULL,
    profanityCol=NULL,
    recordAudioData=FALSE,
    recordedFileNameCol=NULL,
    streamIntermediateResults=TRUE,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_conversation_transcription"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.ConversationTranscription"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAudioDataCol", audioDataCol) %>%
        invoke("setEndpointId", endpointId) %>%
        invoke("setExtraFfmpegArgs", as.array(extraFfmpegArgs)) %>%
        invoke("setFileTypeCol", fileTypeCol) %>%
        invoke("setFileType", fileType) %>%
        invoke("setFormatCol", formatCol) %>%
        invoke("setFormat", format) %>%
        invoke("setLanguageCol", languageCol) %>%
        invoke("setLanguage", language) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setParticipantsJsonCol", participantsJsonCol) %>%
        invoke("setParticipantsJson", participantsJson) %>%
        invoke("setProfanityCol", profanityCol) %>%
        invoke("setProfanity", profanity) %>%
        invoke("setRecordAudioData", as.logical(recordAudioData)) %>%
        invoke("setRecordedFileNameCol", recordedFileNameCol) %>%
        invoke("setStreamIntermediateResults", as.logical(streamIntermediateResults)) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
