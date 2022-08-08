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
    /// <see cref="SpeechToText"/> implements SpeechToText
    /// </summary>
    public class SpeechToText : JavaTransformer, IJavaMLWritable, IJavaMLReadable<SpeechToText>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.SpeechToText";

        /// <summary>
        /// Creates a <see cref="SpeechToText"/> without any parameters.
        /// </summary>
        public SpeechToText() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="SpeechToText"/> with a UID that is used to give the
        /// <see cref="SpeechToText"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SpeechToText(string uid) : base(s_className, uid)
        {
        }

        internal SpeechToText(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for audioData
        /// </summary>
        /// <param name="value">
        ///  The data sent to the service must be a .wav files     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetAudioData(byte[] value) =>
            WrapAsSpeechToText(Reference.Invoke("setAudioData", (object)value));
        
        
        /// <summary>
        /// Sets value for audioData column
        /// </summary>
        /// <param name="value">
        ///  The data sent to the service must be a .wav files     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetAudioDataCol(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setAudioDataCol", value));
        
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetConcurrency(int value) =>
            WrapAsSpeechToText(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetConcurrentTimeout(double value) =>
            WrapAsSpeechToText(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetErrorCol(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for format
        /// </summary>
        /// <param name="value">
        ///  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetFormat(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setFormat", (object)value));
        
        
        /// <summary>
        /// Sets value for format column
        /// </summary>
        /// <param name="value">
        ///  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetFormatCol(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setFormatCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetHandler(object value) =>
            WrapAsSpeechToText(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        ///  Identifies the spoken language that is being recognized.     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetLanguage(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        ///  Identifies the spoken language that is being recognized.     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetLanguageCol(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetOutputCol(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for profanity
        /// </summary>
        /// <param name="value">
        ///  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetProfanity(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setProfanity", (object)value));
        
        
        /// <summary>
        /// Sets value for profanity column
        /// </summary>
        /// <param name="value">
        ///  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetProfanityCol(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setProfanityCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetSubscriptionKey(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetSubscriptionKeyCol(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetTimeout(double value) =>
            WrapAsSpeechToText(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetUrl(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets audioData value
        /// </summary>
        /// <returns>
        /// audioData:  The data sent to the service must be a .wav files     
        /// </returns>
        public byte[] GetAudioData() =>
            (byte[])Reference.Invoke("getAudioData");
        
        
        /// <summary>
        /// Gets concurrency value
        /// </summary>
        /// <returns>
        /// concurrency: max number of concurrent calls
        /// </returns>
        public int GetConcurrency() =>
            (int)Reference.Invoke("getConcurrency");
        
        /// <summary>
        /// Gets concurrentTimeout value
        /// </summary>
        /// <returns>
        /// concurrentTimeout: max number seconds to wait on futures if concurrency >= 1
        /// </returns>
        public double GetConcurrentTimeout() =>
            (double)Reference.Invoke("getConcurrentTimeout");
        
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets format value
        /// </summary>
        /// <returns>
        /// format:  Specifies the result format. Accepted values are simple and detailed. Default is simple.     
        /// </returns>
        public string GetFormat() =>
            (string)Reference.Invoke("getFormat");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
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
        /// Gets profanity value
        /// </summary>
        /// <returns>
        /// profanity:  Specifies how to handle profanity in recognition results. Accepted values are masked, which replaces profanity with asterisks, removed, which remove all profanity from the result, or raw, which includes the profanity in the result. The default setting is masked.     
        /// </returns>
        public string GetProfanity() =>
            (string)Reference.Invoke("getProfanity");
        
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: number of seconds to wait before closing the connection
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="SpeechToText"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SpeechToText"/> was saved to</param>
        /// <returns>New <see cref="SpeechToText"/> object, loaded from path.</returns>
        public static SpeechToText Load(string path) => WrapAsSpeechToText(
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
        /// <returns>an <see cref="JavaMLReader&lt;SpeechToText&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<SpeechToText> Read() =>
            new JavaMLReader<SpeechToText>((JvmObjectReference)Reference.Invoke("read"));
        private static SpeechToText WrapAsSpeechToText(object obj) =>
            new SpeechToText((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetLocation(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New SpeechToText object </returns>
        public SpeechToText SetLinkedService(string value) =>
            WrapAsSpeechToText(Reference.Invoke("setLinkedService", value));
    }
}

        