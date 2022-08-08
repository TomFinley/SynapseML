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
    /// <see cref="SpeechToTextSDK"/> implements SpeechToTextSDK
    /// </summary>
    public class SpeechToTextSDK : JavaTransformer, IJavaMLWritable, IJavaMLReadable<SpeechToTextSDK>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.SpeechToTextSDK";

        /// <summary>
        /// Creates a <see cref="SpeechToTextSDK"/> without any parameters.
        /// </summary>
        public SpeechToTextSDK() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="SpeechToTextSDK"/> with a UID that is used to give the
        /// <see cref="SpeechToTextSDK"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SpeechToTextSDK(string uid) : base(s_className, uid)
        {
        }

        internal SpeechToTextSDK(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for audioDataCol
        /// </summary>
        /// <param name="value">
        /// Column holding audio data, must be either ByteArrays or Strings representing file URIs
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetAudioDataCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setAudioDataCol", (object)value));
        
        /// <summary>
        /// Sets value for endpointId
        /// </summary>
        /// <param name="value">
        /// endpoint for custom speech models
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetEndpointId(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setEndpointId", (object)value));
        
        /// <summary>
        /// Sets value for extraFfmpegArgs
        /// </summary>
        /// <param name="value">
        /// extra arguments to for ffmpeg output decoding
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetExtraFfmpegArgs(string[] value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setExtraFfmpegArgs", (object)value));
        
        /// <summary>
        /// Sets value for fileType
        /// </summary>
        /// <param name="value">
        /// The file type of the sound files, supported types: wav, ogg, mp3
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetFileType(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setFileType", (object)value));
        
        
        /// <summary>
        /// Sets value for fileType column
        /// </summary>
        /// <param name="value">
        /// The file type of the sound files, supported types: wav, ogg, mp3
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetFileTypeCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setFileTypeCol", value));
        
        
        /// <summary>
        /// Sets value for format
        /// </summary>
        /// <param name="value">
        ///  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetFormat(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setFormat", (object)value));
        
        
        /// <summary>
        /// Sets value for format column
        /// </summary>
        /// <param name="value">
        ///  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetFormatCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setFormatCol", value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        ///  Identifies the spoken language that is being recognized.     
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetLanguage(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        ///  Identifies the spoken language that is being recognized.     
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetLanguageCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetOutputCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for participantsJson
        /// </summary>
        /// <param name="value">
        /// a json representation of a list of conversation participants (email, language, user)
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetParticipantsJson(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setParticipantsJson", (object)value));
        
        
        /// <summary>
        /// Sets value for participantsJson column
        /// </summary>
        /// <param name="value">
        /// a json representation of a list of conversation participants (email, language, user)
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetParticipantsJsonCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setParticipantsJsonCol", value));
        
        
        /// <summary>
        /// Sets value for profanity
        /// </summary>
        /// <param name="value">
        ///  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetProfanity(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setProfanity", (object)value));
        
        
        /// <summary>
        /// Sets value for profanity column
        /// </summary>
        /// <param name="value">
        ///  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetProfanityCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setProfanityCol", value));
        
        
        /// <summary>
        /// Sets value for recordAudioData
        /// </summary>
        /// <param name="value">
        /// Whether to record audio data to a file location, for use only with m3u8 streams
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetRecordAudioData(bool value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setRecordAudioData", (object)value));
        
        /// <summary>
        /// Sets value for recordedFileNameCol
        /// </summary>
        /// <param name="value">
        /// Column holding file names to write audio data to if ``recordAudioData'' is set to true
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetRecordedFileNameCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setRecordedFileNameCol", (object)value));
        
        /// <summary>
        /// Sets value for streamIntermediateResults
        /// </summary>
        /// <param name="value">
        /// Whether or not to immediately return itermediate results, or group in a sequence
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetStreamIntermediateResults(bool value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setStreamIntermediateResults", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetSubscriptionKey(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetSubscriptionKeyCol(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetUrl(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setUrl", (object)value));
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
        /// Loads the <see cref="SpeechToTextSDK"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SpeechToTextSDK"/> was saved to</param>
        /// <returns>New <see cref="SpeechToTextSDK"/> object, loaded from path.</returns>
        public static SpeechToTextSDK Load(string path) => WrapAsSpeechToTextSDK(
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
        /// <returns>an <see cref="JavaMLReader&lt;SpeechToTextSDK&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<SpeechToTextSDK> Read() =>
            new JavaMLReader<SpeechToTextSDK>((JvmObjectReference)Reference.Invoke("read"));
        private static SpeechToTextSDK WrapAsSpeechToTextSDK(object obj) =>
            new SpeechToTextSDK((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetLocation(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New SpeechToTextSDK object </returns>
        public SpeechToTextSDK SetLinkedService(string value) =>
            WrapAsSpeechToTextSDK(Reference.Invoke("setLinkedService", value));
    }
}

        