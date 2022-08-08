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


namespace Synapse.ML.Vw
{
    /// <summary>
    /// <see cref="VowpalWabbitFeaturizer"/> implements VowpalWabbitFeaturizer
    /// </summary>
    public class VowpalWabbitFeaturizer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<VowpalWabbitFeaturizer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitFeaturizer";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitFeaturizer"/> without any parameters.
        /// </summary>
        public VowpalWabbitFeaturizer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitFeaturizer"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitFeaturizer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitFeaturizer(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitFeaturizer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCols
        /// </summary>
        /// <param name="value">
        /// The names of the input columns
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetInputCols(string[] value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets value for numBits
        /// </summary>
        /// <param name="value">
        /// Number of bits used to mask
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetNumBits(int value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setNumBits", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetOutputCol(string value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for prefixStringsWithColumnName
        /// </summary>
        /// <param name="value">
        /// Prefix string features with column name
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetPrefixStringsWithColumnName(bool value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setPrefixStringsWithColumnName", (object)value));
        
        /// <summary>
        /// Sets value for preserveOrderNumBits
        /// </summary>
        /// <param name="value">
        /// Number of bits used to preserve the feature order. This will reduce the hash size. Needs to be large enough to fit count the maximum number of words
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetPreserveOrderNumBits(int value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setPreserveOrderNumBits", (object)value));
        
        /// <summary>
        /// Sets value for seed
        /// </summary>
        /// <param name="value">
        /// Hash seed
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetSeed(int value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setSeed", (object)value));
        
        /// <summary>
        /// Sets value for stringSplitInputCols
        /// </summary>
        /// <param name="value">
        /// Input cols that should be split at word boundaries
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetStringSplitInputCols(string[] value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setStringSplitInputCols", (object)value));
        
        /// <summary>
        /// Sets value for sumCollisions
        /// </summary>
        /// <param name="value">
        /// Sums collisions if true, otherwise removes them
        /// </param>
        /// <returns> New VowpalWabbitFeaturizer object </returns>
        public VowpalWabbitFeaturizer SetSumCollisions(bool value) =>
            WrapAsVowpalWabbitFeaturizer(Reference.Invoke("setSumCollisions", (object)value));
        /// <summary>
        /// Gets inputCols value
        /// </summary>
        /// <returns>
        /// inputCols: The names of the input columns
        /// </returns>
        public string[] GetInputCols() =>
            (string[])Reference.Invoke("getInputCols");
        
        /// <summary>
        /// Gets numBits value
        /// </summary>
        /// <returns>
        /// numBits: Number of bits used to mask
        /// </returns>
        public int GetNumBits() =>
            (int)Reference.Invoke("getNumBits");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets prefixStringsWithColumnName value
        /// </summary>
        /// <returns>
        /// prefixStringsWithColumnName: Prefix string features with column name
        /// </returns>
        public bool GetPrefixStringsWithColumnName() =>
            (bool)Reference.Invoke("getPrefixStringsWithColumnName");
        
        /// <summary>
        /// Gets preserveOrderNumBits value
        /// </summary>
        /// <returns>
        /// preserveOrderNumBits: Number of bits used to preserve the feature order. This will reduce the hash size. Needs to be large enough to fit count the maximum number of words
        /// </returns>
        public int GetPreserveOrderNumBits() =>
            (int)Reference.Invoke("getPreserveOrderNumBits");
        
        /// <summary>
        /// Gets seed value
        /// </summary>
        /// <returns>
        /// seed: Hash seed
        /// </returns>
        public int GetSeed() =>
            (int)Reference.Invoke("getSeed");
        
        /// <summary>
        /// Gets stringSplitInputCols value
        /// </summary>
        /// <returns>
        /// stringSplitInputCols: Input cols that should be split at word boundaries
        /// </returns>
        public string[] GetStringSplitInputCols() =>
            (string[])Reference.Invoke("getStringSplitInputCols");
        
        /// <summary>
        /// Gets sumCollisions value
        /// </summary>
        /// <returns>
        /// sumCollisions: Sums collisions if true, otherwise removes them
        /// </returns>
        public bool GetSumCollisions() =>
            (bool)Reference.Invoke("getSumCollisions");
        
        /// <summary>
        /// Loads the <see cref="VowpalWabbitFeaturizer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitFeaturizer"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitFeaturizer"/> object, loaded from path.</returns>
        public static VowpalWabbitFeaturizer Load(string path) => WrapAsVowpalWabbitFeaturizer(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitFeaturizer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitFeaturizer> Read() =>
            new JavaMLReader<VowpalWabbitFeaturizer>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitFeaturizer WrapAsVowpalWabbitFeaturizer(object obj) =>
            new VowpalWabbitFeaturizer((JvmObjectReference)obj);
        
    }
}

        