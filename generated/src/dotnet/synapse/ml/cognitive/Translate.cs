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
    /// <see cref="Translate"/> implements Translate
    /// </summary>
    public class Translate : JavaTransformer, IJavaMLWritable, IJavaMLReadable<Translate>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.Translate";

        /// <summary>
        /// Creates a <see cref="Translate"/> without any parameters.
        /// </summary>
        public Translate() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Translate"/> with a UID that is used to give the
        /// <see cref="Translate"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Translate(string uid) : base(s_className, uid)
        {
        }

        internal Translate(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for allowFallback
        /// </summary>
        /// <param name="value">
        /// Specifies that the service is allowed to fall back to a general system when a custom system does not exist. 
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetAllowFallback(bool value) =>
            WrapAsTranslate(Reference.Invoke("setAllowFallback", (object)value));
        
        
        /// <summary>
        /// Sets value for allowFallback column
        /// </summary>
        /// <param name="value">
        /// Specifies that the service is allowed to fall back to a general system when a custom system does not exist. 
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetAllowFallbackCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setAllowFallbackCol", value));
        
        
        /// <summary>
        /// Sets value for category
        /// </summary>
        /// <param name="value">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations from a customized system built with Custom Translator. Add the Category ID from your Custom Translator project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetCategory(string value) =>
            WrapAsTranslate(Reference.Invoke("setCategory", (object)value));
        
        
        /// <summary>
        /// Sets value for category column
        /// </summary>
        /// <param name="value">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations from a customized system built with Custom Translator. Add the Category ID from your Custom Translator project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetCategoryCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setCategoryCol", value));
        
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetConcurrency(int value) =>
            WrapAsTranslate(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetConcurrentTimeout(double value) =>
            WrapAsTranslate(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetErrorCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for fromLanguage
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the input text. Find which languages are available to translate from by looking up supported languages using the translation scope. If the from parameter is not specified, automatic language detection is applied to determine the source language. You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetFromLanguage(string value) =>
            WrapAsTranslate(Reference.Invoke("setFromLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for fromLanguage column
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the input text. Find which languages are available to translate from by looking up supported languages using the translation scope. If the from parameter is not specified, automatic language detection is applied to determine the source language. You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetFromLanguageCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setFromLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for fromScript
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the input text.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetFromScript(string value) =>
            WrapAsTranslate(Reference.Invoke("setFromScript", (object)value));
        
        
        /// <summary>
        /// Sets value for fromScript column
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the input text.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetFromScriptCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setFromScriptCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetHandler(object value) =>
            WrapAsTranslate(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for includeAlignment
        /// </summary>
        /// <param name="value">
        /// Specifies whether to include alignment projection from source text to translated text.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetIncludeAlignment(bool value) =>
            WrapAsTranslate(Reference.Invoke("setIncludeAlignment", (object)value));
        
        
        /// <summary>
        /// Sets value for includeAlignment column
        /// </summary>
        /// <param name="value">
        /// Specifies whether to include alignment projection from source text to translated text.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetIncludeAlignmentCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setIncludeAlignmentCol", value));
        
        
        /// <summary>
        /// Sets value for includeSentenceLength
        /// </summary>
        /// <param name="value">
        /// Specifies whether to include sentence boundaries for the input text and the translated text. 
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetIncludeSentenceLength(bool value) =>
            WrapAsTranslate(Reference.Invoke("setIncludeSentenceLength", (object)value));
        
        
        /// <summary>
        /// Sets value for includeSentenceLength column
        /// </summary>
        /// <param name="value">
        /// Specifies whether to include sentence boundaries for the input text and the translated text. 
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetIncludeSentenceLengthCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setIncludeSentenceLengthCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetOutputCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for profanityAction
        /// </summary>
        /// <param name="value">
        /// Specifies how profanities should be treated in translations. Possible values are: NoAction (default), Marked or Deleted. 
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetProfanityAction(string value) =>
            WrapAsTranslate(Reference.Invoke("setProfanityAction", (object)value));
        
        
        /// <summary>
        /// Sets value for profanityAction column
        /// </summary>
        /// <param name="value">
        /// Specifies how profanities should be treated in translations. Possible values are: NoAction (default), Marked or Deleted. 
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetProfanityActionCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setProfanityActionCol", value));
        
        
        /// <summary>
        /// Sets value for profanityMarker
        /// </summary>
        /// <param name="value">
        /// Specifies how profanities should be marked in translations. Possible values are: Asterisk (default) or Tag.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetProfanityMarker(string value) =>
            WrapAsTranslate(Reference.Invoke("setProfanityMarker", (object)value));
        
        
        /// <summary>
        /// Sets value for profanityMarker column
        /// </summary>
        /// <param name="value">
        /// Specifies how profanities should be marked in translations. Possible values are: Asterisk (default) or Tag.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetProfanityMarkerCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setProfanityMarkerCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetSubscriptionKey(string value) =>
            WrapAsTranslate(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetSubscriptionKeyCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetSubscriptionRegion(string value) =>
            WrapAsTranslate(Reference.Invoke("setSubscriptionRegion", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionRegion column
        /// </summary>
        /// <param name="value">
        /// the API region to use
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetSubscriptionRegionCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setSubscriptionRegionCol", value));
        
        
        /// <summary>
        /// Sets value for suggestedFrom
        /// </summary>
        /// <param name="value">
        /// Specifies a fallback language if the language of the input text can't be identified. Language autodetection is applied when the from parameter is omitted. If detection fails, the suggestedFrom language will be assumed.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetSuggestedFrom(string value) =>
            WrapAsTranslate(Reference.Invoke("setSuggestedFrom", (object)value));
        
        
        /// <summary>
        /// Sets value for suggestedFrom column
        /// </summary>
        /// <param name="value">
        /// Specifies a fallback language if the language of the input text can't be identified. Language autodetection is applied when the from parameter is omitted. If detection fails, the suggestedFrom language will be assumed.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetSuggestedFromCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setSuggestedFromCol", value));
        
        
        /// <summary>
        /// Sets value for text
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetText(string[] value) =>
            WrapAsTranslate(Reference.Invoke("setText", (object)value));
        
        
        /// <summary>
        /// Sets value for text column
        /// </summary>
        /// <param name="value">
        /// the string to translate
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetTextCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setTextCol", value));
        
        
        /// <summary>
        /// Sets value for textType
        /// </summary>
        /// <param name="value">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed, complete element. Possible values are: plain (default) or html.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetTextType(string value) =>
            WrapAsTranslate(Reference.Invoke("setTextType", (object)value));
        
        
        /// <summary>
        /// Sets value for textType column
        /// </summary>
        /// <param name="value">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed, complete element. Possible values are: plain (default) or html.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetTextTypeCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setTextTypeCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetTimeout(double value) =>
            WrapAsTranslate(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for toLanguage
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the output text. The target language must be one of the supported languages included in the translation scope. For example, use to=de to translate to German. It's possible to translate to multiple languages simultaneously by repeating the parameter in the query string. For example, use to=de and to=it to translate to German and Italian.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetToLanguage(string[] value) =>
            WrapAsTranslate(Reference.Invoke("setToLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for toLanguage column
        /// </summary>
        /// <param name="value">
        /// Specifies the language of the output text. The target language must be one of the supported languages included in the translation scope. For example, use to=de to translate to German. It's possible to translate to multiple languages simultaneously by repeating the parameter in the query string. For example, use to=de and to=it to translate to German and Italian.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetToLanguageCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setToLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for toScript
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the translated text.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetToScript(string value) =>
            WrapAsTranslate(Reference.Invoke("setToScript", (object)value));
        
        
        /// <summary>
        /// Sets value for toScript column
        /// </summary>
        /// <param name="value">
        /// Specifies the script of the translated text.
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetToScriptCol(string value) =>
            WrapAsTranslate(Reference.Invoke("setToScriptCol", value));
        
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetUrl(string value) =>
            WrapAsTranslate(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets allowFallback value
        /// </summary>
        /// <returns>
        /// allowFallback: Specifies that the service is allowed to fall back to a general system when a custom system does not exist. 
        /// </returns>
        public bool GetAllowFallback() =>
            (bool)Reference.Invoke("getAllowFallback");
        
        
        /// <summary>
        /// Gets category value
        /// </summary>
        /// <returns>
        /// category: A string specifying the category (domain) of the translation. This parameter is used to get translations from a customized system built with Custom Translator. Add the Category ID from your Custom Translator project details to this parameter to use your deployed customized system. Default value is: general.
        /// </returns>
        public string GetCategory() =>
            (string)Reference.Invoke("getCategory");
        
        
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
        /// Gets fromLanguage value
        /// </summary>
        /// <returns>
        /// fromLanguage: Specifies the language of the input text. Find which languages are available to translate from by looking up supported languages using the translation scope. If the from parameter is not specified, automatic language detection is applied to determine the source language. You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// </returns>
        public string GetFromLanguage() =>
            (string)Reference.Invoke("getFromLanguage");
        
        
        /// <summary>
        /// Gets fromScript value
        /// </summary>
        /// <returns>
        /// fromScript: Specifies the script of the input text.
        /// </returns>
        public string GetFromScript() =>
            (string)Reference.Invoke("getFromScript");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets includeAlignment value
        /// </summary>
        /// <returns>
        /// includeAlignment: Specifies whether to include alignment projection from source text to translated text.
        /// </returns>
        public bool GetIncludeAlignment() =>
            (bool)Reference.Invoke("getIncludeAlignment");
        
        
        /// <summary>
        /// Gets includeSentenceLength value
        /// </summary>
        /// <returns>
        /// includeSentenceLength: Specifies whether to include sentence boundaries for the input text and the translated text. 
        /// </returns>
        public bool GetIncludeSentenceLength() =>
            (bool)Reference.Invoke("getIncludeSentenceLength");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets profanityAction value
        /// </summary>
        /// <returns>
        /// profanityAction: Specifies how profanities should be treated in translations. Possible values are: NoAction (default), Marked or Deleted. 
        /// </returns>
        public string GetProfanityAction() =>
            (string)Reference.Invoke("getProfanityAction");
        
        
        /// <summary>
        /// Gets profanityMarker value
        /// </summary>
        /// <returns>
        /// profanityMarker: Specifies how profanities should be marked in translations. Possible values are: Asterisk (default) or Tag.
        /// </returns>
        public string GetProfanityMarker() =>
            (string)Reference.Invoke("getProfanityMarker");
        
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets subscriptionRegion value
        /// </summary>
        /// <returns>
        /// subscriptionRegion: the API region to use
        /// </returns>
        public string GetSubscriptionRegion() =>
            (string)Reference.Invoke("getSubscriptionRegion");
        
        
        /// <summary>
        /// Gets suggestedFrom value
        /// </summary>
        /// <returns>
        /// suggestedFrom: Specifies a fallback language if the language of the input text can't be identified. Language autodetection is applied when the from parameter is omitted. If detection fails, the suggestedFrom language will be assumed.
        /// </returns>
        public string GetSuggestedFrom() =>
            (string)Reference.Invoke("getSuggestedFrom");
        
        
        /// <summary>
        /// Gets text value
        /// </summary>
        /// <returns>
        /// text: the string to translate
        /// </returns>
        public string[] GetText() =>
            (string[])Reference.Invoke("getText");
        
        
        /// <summary>
        /// Gets textType value
        /// </summary>
        /// <returns>
        /// textType: Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed, complete element. Possible values are: plain (default) or html.
        /// </returns>
        public string GetTextType() =>
            (string)Reference.Invoke("getTextType");
        
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: number of seconds to wait before closing the connection
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Gets toLanguage value
        /// </summary>
        /// <returns>
        /// toLanguage: Specifies the language of the output text. The target language must be one of the supported languages included in the translation scope. For example, use to=de to translate to German. It's possible to translate to multiple languages simultaneously by repeating the parameter in the query string. For example, use to=de and to=it to translate to German and Italian.
        /// </returns>
        public string[] GetToLanguage() =>
            (string[])Reference.Invoke("getToLanguage");
        
        
        /// <summary>
        /// Gets toScript value
        /// </summary>
        /// <returns>
        /// toScript: Specifies the script of the translated text.
        /// </returns>
        public string GetToScript() =>
            (string)Reference.Invoke("getToScript");
        
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="Translate"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Translate"/> was saved to</param>
        /// <returns>New <see cref="Translate"/> object, loaded from path.</returns>
        public static Translate Load(string path) => WrapAsTranslate(
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
        /// <returns>an <see cref="JavaMLReader&lt;Translate&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Translate> Read() =>
            new JavaMLReader<Translate>((JvmObjectReference)Reference.Invoke("read"));
        private static Translate WrapAsTranslate(object obj) =>
            new Translate((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetLocation(string value) =>
            WrapAsTranslate(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New Translate object </returns>
        public Translate SetLinkedService(string value) =>
            WrapAsTranslate(Reference.Invoke("setLinkedService", value));
    }
}

        