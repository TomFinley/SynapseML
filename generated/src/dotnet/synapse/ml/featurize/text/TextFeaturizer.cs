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
using Microsoft.Spark.ML;

namespace Synapse.ML.Featurize.Text
{
    /// <summary>
    /// <see cref="TextFeaturizer"/> implements TextFeaturizer
    /// </summary>
    public class TextFeaturizer : JavaEstimator<PipelineModel>, IJavaMLWritable, IJavaMLReadable<TextFeaturizer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.featurize.text.TextFeaturizer";

        /// <summary>
        /// Creates a <see cref="TextFeaturizer"/> without any parameters.
        /// </summary>
        public TextFeaturizer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TextFeaturizer"/> with a UID that is used to give the
        /// <see cref="TextFeaturizer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TextFeaturizer(string uid) : base(s_className, uid)
        {
        }

        internal TextFeaturizer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for binary
        /// </summary>
        /// <param name="value">
        /// If true, all nonegative word counts are set to 1
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetBinary(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setBinary", (object)value));
        
        /// <summary>
        /// Sets value for caseSensitiveStopWords
        /// </summary>
        /// <param name="value">
        ///  Whether to do a case sensitive comparison over the stop words
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetCaseSensitiveStopWords(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setCaseSensitiveStopWords", (object)value));
        
        /// <summary>
        /// Sets value for defaultStopWordLanguage
        /// </summary>
        /// <param name="value">
        /// Which language to use for the stop word remover, set this to custom to use the stopWords input
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetDefaultStopWordLanguage(string value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setDefaultStopWordLanguage", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetInputCol(string value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for minDocFreq
        /// </summary>
        /// <param name="value">
        /// The minimum number of documents in which a term should appear.
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetMinDocFreq(int value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setMinDocFreq", (object)value));
        
        /// <summary>
        /// Sets value for minTokenLength
        /// </summary>
        /// <param name="value">
        /// Minimum token length, >= 0.
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetMinTokenLength(int value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setMinTokenLength", (object)value));
        
        /// <summary>
        /// Sets value for nGramLength
        /// </summary>
        /// <param name="value">
        /// The size of the Ngrams
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetNGramLength(int value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setNGramLength", (object)value));
        
        /// <summary>
        /// Sets value for numFeatures
        /// </summary>
        /// <param name="value">
        /// Set the number of features to hash each document to
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetNumFeatures(int value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setNumFeatures", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetOutputCol(string value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for stopWords
        /// </summary>
        /// <param name="value">
        /// The words to be filtered out.
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetStopWords(string value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setStopWords", (object)value));
        
        /// <summary>
        /// Sets value for toLowercase
        /// </summary>
        /// <param name="value">
        /// Indicates whether to convert all characters to lowercase before tokenizing.
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetToLowercase(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setToLowercase", (object)value));
        
        /// <summary>
        /// Sets value for tokenizerGaps
        /// </summary>
        /// <param name="value">
        /// Indicates whether regex splits on gaps (true) or matches tokens (false).
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetTokenizerGaps(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setTokenizerGaps", (object)value));
        
        /// <summary>
        /// Sets value for tokenizerPattern
        /// </summary>
        /// <param name="value">
        /// Regex pattern used to match delimiters if gaps is true or tokens if gaps is false.
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetTokenizerPattern(string value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setTokenizerPattern", (object)value));
        
        /// <summary>
        /// Sets value for useIDF
        /// </summary>
        /// <param name="value">
        /// Whether to scale the Term Frequencies by IDF
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetUseIDF(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setUseIDF", (object)value));
        
        /// <summary>
        /// Sets value for useNGram
        /// </summary>
        /// <param name="value">
        /// Whether to enumerate N grams
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetUseNGram(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setUseNGram", (object)value));
        
        /// <summary>
        /// Sets value for useStopWordsRemover
        /// </summary>
        /// <param name="value">
        /// Whether to remove stop words from tokenized data
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetUseStopWordsRemover(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setUseStopWordsRemover", (object)value));
        
        /// <summary>
        /// Sets value for useTokenizer
        /// </summary>
        /// <param name="value">
        /// Whether to tokenize the input
        /// </param>
        /// <returns> New TextFeaturizer object </returns>
        public TextFeaturizer SetUseTokenizer(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setUseTokenizer", (object)value));
        /// <summary>
        /// Gets binary value
        /// </summary>
        /// <returns>
        /// binary: If true, all nonegative word counts are set to 1
        /// </returns>
        public bool GetBinary() =>
            (bool)Reference.Invoke("getBinary");
        
        /// <summary>
        /// Gets caseSensitiveStopWords value
        /// </summary>
        /// <returns>
        /// caseSensitiveStopWords:  Whether to do a case sensitive comparison over the stop words
        /// </returns>
        public bool GetCaseSensitiveStopWords() =>
            (bool)Reference.Invoke("getCaseSensitiveStopWords");
        
        /// <summary>
        /// Gets defaultStopWordLanguage value
        /// </summary>
        /// <returns>
        /// defaultStopWordLanguage: Which language to use for the stop word remover, set this to custom to use the stopWords input
        /// </returns>
        public string GetDefaultStopWordLanguage() =>
            (string)Reference.Invoke("getDefaultStopWordLanguage");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets minDocFreq value
        /// </summary>
        /// <returns>
        /// minDocFreq: The minimum number of documents in which a term should appear.
        /// </returns>
        public int GetMinDocFreq() =>
            (int)Reference.Invoke("getMinDocFreq");
        
        /// <summary>
        /// Gets minTokenLength value
        /// </summary>
        /// <returns>
        /// minTokenLength: Minimum token length, >= 0.
        /// </returns>
        public int GetMinTokenLength() =>
            (int)Reference.Invoke("getMinTokenLength");
        
        /// <summary>
        /// Gets nGramLength value
        /// </summary>
        /// <returns>
        /// nGramLength: The size of the Ngrams
        /// </returns>
        public int GetNGramLength() =>
            (int)Reference.Invoke("getNGramLength");
        
        /// <summary>
        /// Gets numFeatures value
        /// </summary>
        /// <returns>
        /// numFeatures: Set the number of features to hash each document to
        /// </returns>
        public int GetNumFeatures() =>
            (int)Reference.Invoke("getNumFeatures");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets stopWords value
        /// </summary>
        /// <returns>
        /// stopWords: The words to be filtered out.
        /// </returns>
        public string GetStopWords() =>
            (string)Reference.Invoke("getStopWords");
        
        /// <summary>
        /// Gets toLowercase value
        /// </summary>
        /// <returns>
        /// toLowercase: Indicates whether to convert all characters to lowercase before tokenizing.
        /// </returns>
        public bool GetToLowercase() =>
            (bool)Reference.Invoke("getToLowercase");
        
        /// <summary>
        /// Gets tokenizerGaps value
        /// </summary>
        /// <returns>
        /// tokenizerGaps: Indicates whether regex splits on gaps (true) or matches tokens (false).
        /// </returns>
        public bool GetTokenizerGaps() =>
            (bool)Reference.Invoke("getTokenizerGaps");
        
        /// <summary>
        /// Gets tokenizerPattern value
        /// </summary>
        /// <returns>
        /// tokenizerPattern: Regex pattern used to match delimiters if gaps is true or tokens if gaps is false.
        /// </returns>
        public string GetTokenizerPattern() =>
            (string)Reference.Invoke("getTokenizerPattern");
        
        /// <summary>
        /// Gets useIDF value
        /// </summary>
        /// <returns>
        /// useIDF: Whether to scale the Term Frequencies by IDF
        /// </returns>
        public bool GetUseIDF() =>
            (bool)Reference.Invoke("getUseIDF");
        
        /// <summary>
        /// Gets useNGram value
        /// </summary>
        /// <returns>
        /// useNGram: Whether to enumerate N grams
        /// </returns>
        public bool GetUseNGram() =>
            (bool)Reference.Invoke("getUseNGram");
        
        /// <summary>
        /// Gets useStopWordsRemover value
        /// </summary>
        /// <returns>
        /// useStopWordsRemover: Whether to remove stop words from tokenized data
        /// </returns>
        public bool GetUseStopWordsRemover() =>
            (bool)Reference.Invoke("getUseStopWordsRemover");
        
        /// <summary>
        /// Gets useTokenizer value
        /// </summary>
        /// <returns>
        /// useTokenizer: Whether to tokenize the input
        /// </returns>
        public bool GetUseTokenizer() =>
            (bool)Reference.Invoke("getUseTokenizer");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="PipelineModel"/></returns>
        override public PipelineModel Fit(DataFrame dataset) =>
            new PipelineModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="TextFeaturizer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TextFeaturizer"/> was saved to</param>
        /// <returns>New <see cref="TextFeaturizer"/> object, loaded from path.</returns>
        public static TextFeaturizer Load(string path) => WrapAsTextFeaturizer(
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
        /// <returns>an <see cref="JavaMLReader&lt;TextFeaturizer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TextFeaturizer> Read() =>
            new JavaMLReader<TextFeaturizer>((JvmObjectReference)Reference.Invoke("read"));
        private static TextFeaturizer WrapAsTextFeaturizer(object obj) =>
            new TextFeaturizer((JvmObjectReference)obj);
        
    }
}

        