// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.ML.Feature.Param;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.Interop.Internal.Java.Util;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Microsoft.Spark.Utils;
using SynapseML.Dotnet.Utils;
using Synapse.ML.LightGBM.Param;


namespace Synapse.ML.Cognitive
{
    /// <summary>
    /// <see cref="ConversationTranscription"/> implements ConversationTranscription
    /// </summary>
    public class ConversationTranscription : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ConversationTranscription>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.ConversationTranscription";

        /// <summary>
        /// Creates a <see cref="ConversationTranscription"/> without any parameters.
        /// </summary>
        public ConversationTranscription() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ConversationTranscription"/> with a UID that is used to give the
        /// <see cref="ConversationTranscription"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ConversationTranscription(string uid) : base(s_className, uid)
        {
        }

        internal ConversationTranscription(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for audioDataCol
        /// </summary>
        /// <param name="value">
        /// Column holding audio data, must be either ByteArrays or Strings representing file URIs
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetAudioDataCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setAudioDataCol", (object)value));
        
        /// <summary>
        /// Sets value for endpointId
        /// </summary>
        /// <param name="value">
        /// endpoint for custom speech models
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetEndpointId(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setEndpointId", (object)value));
        
        /// <summary>
        /// Sets value for extraFfmpegArgs
        /// </summary>
        /// <param name="value">
        /// extra arguments to for ffmpeg output decoding
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetExtraFfmpegArgs(string[] value) =>
            WrapAsConversationTranscription(Reference.Invoke("setExtraFfmpegArgs", (object)value));
        
        /// <summary>
        /// Sets value for fileType
        /// </summary>
        /// <param name="value">
        /// The file type of the sound files, supported types: wav, ogg, mp3
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetFileType(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setFileType", (object)value));
        
        
        /// <summary>
        /// Sets value for fileType column
        /// </summary>
        /// <param name="value">
        /// The file type of the sound files, supported types: wav, ogg, mp3
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetFileTypeCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setFileTypeCol", value));
        
        
        /// <summary>
        /// Sets value for format
        /// </summary>
        /// <param name="value">
        ///  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetFormat(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setFormat", (object)value));
        
        
        /// <summary>
        /// Sets value for format column
        /// </summary>
        /// <param name="value">
        ///  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetFormatCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setFormatCol", value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        ///  Identifies the spoken language that is being recognized.     
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetLanguage(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        ///  Identifies the spoken language that is being recognized.     
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetLanguageCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetOutputCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for participantsJson
        /// </summary>
        /// <param name="value">
        /// a json representation of a list of conversation participants (email, language, user)
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetParticipantsJson(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setParticipantsJson", (object)value));
        
        
        /// <summary>
        /// Sets value for participantsJson column
        /// </summary>
        /// <param name="value">
        /// a json representation of a list of conversation participants (email, language, user)
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetParticipantsJsonCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setParticipantsJsonCol", value));
        
        
        /// <summary>
        /// Sets value for profanity
        /// </summary>
        /// <param name="value">
        ///  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetProfanity(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setProfanity", (object)value));
        
        
        /// <summary>
        /// Sets value for profanity column
        /// </summary>
        /// <param name="value">
        ///  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetProfanityCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setProfanityCol", value));
        
        
        /// <summary>
        /// Sets value for recordAudioData
        /// </summary>
        /// <param name="value">
        /// Whether to record audio data to a file location, for use only with m3u8 streams
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetRecordAudioData(bool value) =>
            WrapAsConversationTranscription(Reference.Invoke("setRecordAudioData", (object)value));
        
        /// <summary>
        /// Sets value for recordedFileNameCol
        /// </summary>
        /// <param name="value">
        /// Column holding file names to write audio data to if ``recordAudioData'' is set to true
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetRecordedFileNameCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setRecordedFileNameCol", (object)value));
        
        /// <summary>
        /// Sets value for streamIntermediateResults
        /// </summary>
        /// <param name="value">
        /// Whether or not to immediately return itermediate results, or group in a sequence
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetStreamIntermediateResults(bool value) =>
            WrapAsConversationTranscription(Reference.Invoke("setStreamIntermediateResults", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetSubscriptionKey(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetSubscriptionKeyCol(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetUrl(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets audioDataCol value
        /// </summary>
        /// <returns>
        /// audioDataCol: Column holding audio data, must be either ByteArrays or Strings representing file URIs
        /// </returns>
        public string GetAudioDataCol() =>
            (string)Reference.Invoke("getAudioDataCol");
        
        /// <summary>
        /// Gets endpointId value
        /// </summary>
        /// <returns>
        /// endpointId: endpoint for custom speech models
        /// </returns>
        public string GetEndpointId() =>
            (string)Reference.Invoke("getEndpointId");
        
        /// <summary>
        /// Gets extraFfmpegArgs value
        /// </summary>
        /// <returns>
        /// extraFfmpegArgs: extra arguments to for ffmpeg output decoding
        /// </returns>
        public string[] GetExtraFfmpegArgs() =>
            (string[])Reference.Invoke("getExtraFfmpegArgs");
        
        /// <summary>
        /// Gets fileType value
        /// </summary>
        /// <returns>
        /// fileType: The file type of the sound files, supported types: wav, ogg, mp3
        /// </returns>
        public string GetFileType() =>
            (string)Reference.Invoke("getFileType");
        
        
        /// <summary>
        /// Gets format value
        /// </summary>
        /// <returns>
        /// format:  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </returns>
        public string GetFormat() =>
            (string)Reference.Invoke("getFormat");
        
        
        /// <summary>
        /// Gets language value
        /// </summary>
        /// <returns>
        /// language:  Identifies the spoken language that is being recognized.     
        /// </returns>
        public string GetLanguage() =>
            (string)Reference.Invoke("getLanguage");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets participantsJson value
        /// </summary>
        /// <returns>
        /// participantsJson: a json representation of a list of conversation participants (email, language, user)
        /// </returns>
        public string GetParticipantsJson() =>
            (string)Reference.Invoke("getParticipantsJson");
        
        
        /// <summary>
        /// Gets profanity value
        /// </summary>
        /// <returns>
        /// profanity:  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </returns>
        public string GetProfanity() =>
            (string)Reference.Invoke("getProfanity");
        
        
        /// <summary>
        /// Gets recordAudioData value
        /// </summary>
        /// <returns>
        /// recordAudioData: Whether to record audio data to a file location, for use only with m3u8 streams
        /// </returns>
        public bool GetRecordAudioData() =>
            (bool)Reference.Invoke("getRecordAudioData");
        
        /// <summary>
        /// Gets recordedFileNameCol value
        /// </summary>
        /// <returns>
        /// recordedFileNameCol: Column holding file names to write audio data to if ``recordAudioData'' is set to true
        /// </returns>
        public string GetRecordedFileNameCol() =>
            (string)Reference.Invoke("getRecordedFileNameCol");
        
        /// <summary>
        /// Gets streamIntermediateResults value
        /// </summary>
        /// <returns>
        /// streamIntermediateResults: Whether or not to immediately return itermediate results, or group in a sequence
        /// </returns>
        public bool GetStreamIntermediateResults() =>
            (bool)Reference.Invoke("getStreamIntermediateResults");
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="ConversationTranscription"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ConversationTranscription"/> was saved to</param>
        /// <returns>New <see cref="ConversationTranscription"/> object, loaded from path.</returns>
        public static ConversationTranscription Load(string path) => WrapAsConversationTranscription(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_className, "load", path));
        
        /// <summary>
        /// Saves the object so that it can be loaded later using Load. Note that these objects
        /// can be shared with Scala by Loading or Saving in Scala.
        /// </summary>
        /// <param name="path">The path to save the object to</param>
        public void Save(string path) => Reference.Invoke("save", path);
        
        /// <returns>a <see cref="JavaMLWriter"/> instance for this ML instance.</returns>
        public JavaMLWriter Write() =>
            new JavaMLWriter((JvmObjectReference)Reference.Invoke("write"));
        
        /// <summary>
        /// Get the corresponding JavaMLReader instance.
        /// </summary>
        /// <returns>an <see cref="JavaMLReader&lt;ConversationTranscription&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ConversationTranscription> Read() =>
            new JavaMLReader<ConversationTranscription>((JvmObjectReference)Reference.Invoke("read"));
        private static ConversationTranscription WrapAsConversationTranscription(object obj) =>
            new ConversationTranscription((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetLocation(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New ConversationTranscription object </returns>
        public ConversationTranscription SetLinkedService(string value) =>
            WrapAsConversationTranscription(Reference.Invoke("setLinkedService", value));
    }
}

        