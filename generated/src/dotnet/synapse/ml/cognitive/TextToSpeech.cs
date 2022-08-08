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
    /// <see cref="TextToSpeech"/> implements TextToSpeech
    /// </summary>
    public class TextToSpeech : JavaTransformer, IJavaMLWritable, IJavaMLReadable<TextToSpeech>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.TextToSpeech";

        /// <summary>
        /// Creates a <see cref="TextToSpeech"/> without any parameters.
        /// </summary>
        public TextToSpeech() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TextToSpeech"/> with a UID that is used to give the
        /// <see cref="TextToSpeech"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TextToSpeech(string uid) : base(s_className, uid)
        {
        }

        internal TextToSpeech(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetErrorCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// The name of the language used for synthesis
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetLanguage(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// The name of the language used for synthesis
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetLanguageCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for locale
        /// </summary>
        /// <param name="value">
        /// The locale of the input text
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetLocale(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setLocale", (object)value));
        
        
        /// <summary>
        /// Sets value for locale column
        /// </summary>
        /// <param name="value">
        /// The locale of the input text
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetLocaleCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setLocaleCol", value));
        
        
        /// <summary>
        /// Sets value for outputFileCol
        /// </summary>
        /// <param name="value">
        /// The location of the saved file as an HDFS compliant URI
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetOutputFileCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setOutputFileCol", (object)value));
        
        /// <summary>
        /// Sets value for outputFormat
        /// </summary>
        /// <param name="value">
        /// The format for the output audio can be one of ArraySeq(Raw8Khz8BitMonoMULaw, Riff16Khz16KbpsMonoSiren, Audio16Khz16KbpsMonoSiren, Audio16Khz32KBitRateMonoMp3, Audio16Khz128KBitRateMonoMp3, Audio16Khz64KBitRateMonoMp3, Audio24Khz48KBitRateMonoMp3, Audio24Khz96KBitRateMonoMp3, Audio24Khz160KBitRateMonoMp3, Raw16Khz16BitMonoTrueSilk, Riff16Khz16BitMonoPcm, Riff8Khz16BitMonoPcm, Riff24Khz16BitMonoPcm, Riff8Khz8BitMonoMULaw, Raw16Khz16BitMonoPcm, Raw24Khz16BitMonoPcm, Raw8Khz16BitMonoPcm, Ogg16Khz16BitMonoOpus, Ogg24Khz16BitMonoOpus)
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetOutputFormat(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setOutputFormat", (object)value));
        
        
        /// <summary>
        /// Sets value for outputFormat column
        /// </summary>
        /// <param name="value">
        /// The format for the output audio can be one of ArraySeq(Raw8Khz8BitMonoMULaw, Riff16Khz16KbpsMonoSiren, Audio16Khz16KbpsMonoSiren, Audio16Khz32KBitRateMonoMp3, Audio16Khz128KBitRateMonoMp3, Audio16Khz64KBitRateMonoMp3, Audio24Khz48KBitRateMonoMp3, Audio24Khz96KBitRateMonoMp3, Audio24Khz160KBitRateMonoMp3, Raw16Khz16BitMonoTrueSilk, Riff16Khz16BitMonoPcm, Riff8Khz16BitMonoPcm, Riff24Khz16BitMonoPcm, Riff8Khz8BitMonoMULaw, Raw16Khz16BitMonoPcm, Raw24Khz16BitMonoPcm, Raw8Khz16BitMonoPcm, Ogg16Khz16BitMonoOpus, Ogg24Khz16BitMonoOpus)
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetOutputFormatCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setOutputFormatCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetSubscriptionKey(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetSubscriptionKeyCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// The text to synthesize
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetText(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// The text to synthesize
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetTextCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetUrl(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setUrl", (object)value));
        
        /// <summary>
        /// Sets value for voiceName
        /// </summary>
        /// <param name="value">
        /// The name of the voice used for synthesis
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetVoiceName(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setVoiceName", (object)value));
        
        
        /// <summary>
        /// Sets value for voiceName column
        /// </summary>
        /// <param name="value">
        /// The name of the voice used for synthesis
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetVoiceNameCol(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setVoiceNameCol", value));
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets language value
        /// </summary>
        /// <returns>
        /// language: The name of the language used for synthesis
        /// </returns>
        public string GetLanguage() =>
            (string)Reference.Invoke("getLanguage");
        
        
        /// <summary>
        /// Gets locale value
        /// </summary>
        /// <returns>
        /// locale: The locale of the input text
        /// </returns>
        public string GetLocale() =>
            (string)Reference.Invoke("getLocale");
        
        
        /// <summary>
        /// Gets outputFileCol value
        /// </summary>
        /// <returns>
        /// outputFileCol: The location of the saved file as an HDFS compliant URI
        /// </returns>
        public string GetOutputFileCol() =>
            (string)Reference.Invoke("getOutputFileCol");
        
        /// <summary>
        /// Gets outputFormat value
        /// </summary>
        /// <returns>
        /// outputFormat: The format for the output audio can be one of ArraySeq(Raw8Khz8BitMonoMULaw, Riff16Khz16KbpsMonoSiren, Audio16Khz16KbpsMonoSiren, Audio16Khz32KBitRateMonoMp3, Audio16Khz128KBitRateMonoMp3, Audio16Khz64KBitRateMonoMp3, Audio24Khz48KBitRateMonoMp3, Audio24Khz96KBitRateMonoMp3, Audio24Khz160KBitRateMonoMp3, Raw16Khz16BitMonoTrueSilk, Riff16Khz16BitMonoPcm, Riff8Khz16BitMonoPcm, Riff24Khz16BitMonoPcm, Riff8Khz8BitMonoMULaw, Raw16Khz16BitMonoPcm, Raw24Khz16BitMonoPcm, Raw8Khz16BitMonoPcm, Ogg16Khz16BitMonoOpus, Ogg24Khz16BitMonoOpus)
        /// </returns>
        public string GetOutputFormat() =>
            (string)Reference.Invoke("getOutputFormat");
        
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets text value
        /// </summary>
        /// <returns>
        /// text: The text to synthesize
        /// </returns>
        public string GetText() =>
            (string)Reference.Invoke("getText");
        
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Gets voiceName value
        /// </summary>
        /// <returns>
        /// voiceName: The name of the voice used for synthesis
        /// </returns>
        public string GetVoiceName() =>
            (string)Reference.Invoke("getVoiceName");
        
        /// <summary>
        /// Loads the <see cref="TextToSpeech"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TextToSpeech"/> was saved to</param>
        /// <returns>New <see cref="TextToSpeech"/> object, loaded from path.</returns>
        public static TextToSpeech Load(string path) => WrapAsTextToSpeech(
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
        /// <returns>an <see cref="JavaMLReader&lt;TextToSpeech&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TextToSpeech> Read() =>
            new JavaMLReader<TextToSpeech>((JvmObjectReference)Reference.Invoke("read"));
        private static TextToSpeech WrapAsTextToSpeech(object obj) =>
            new TextToSpeech((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetLocation(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New TextToSpeech object </returns>
        public TextToSpeech SetLinkedService(string value) =>
            WrapAsTextToSpeech(Reference.Invoke("setLinkedService", value));
    }
}

        