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


namespace Synapse.ML.Stages
{
    /// <summary>
    /// <see cref="UnicodeNormalize"/> implements UnicodeNormalize
    /// </summary>
    public class UnicodeNormalize : JavaTransformer, IJavaMLWritable, IJavaMLReadable<UnicodeNormalize>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.UnicodeNormalize";

        /// <summary>
        /// Creates a <see cref="UnicodeNormalize"/> without any parameters.
        /// </summary>
        public UnicodeNormalize() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="UnicodeNormalize"/> with a UID that is used to give the
        /// <see cref="UnicodeNormalize"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public UnicodeNormalize(string uid) : base(s_className, uid)
        {
        }

        internal UnicodeNormalize(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for form
        /// </summary>
        /// <param name="value">
        /// Unicode normalization form: NFC, NFD, NFKC, NFKD
        /// </param>
        /// <returns> New UnicodeNormalize object </returns>
        public UnicodeNormalize SetForm(string value) =>
            WrapAsUnicodeNormalize(Reference.Invoke("setForm", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New UnicodeNormalize object </returns>
        public UnicodeNormalize SetInputCol(string value) =>
            WrapAsUnicodeNormalize(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for lower
        /// </summary>
        /// <param name="value">
        /// Lowercase text
        /// </param>
        /// <returns> New UnicodeNormalize object </returns>
        public UnicodeNormalize SetLower(bool value) =>
            WrapAsUnicodeNormalize(Reference.Invoke("setLower", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New UnicodeNormalize object </returns>
        public UnicodeNormalize SetOutputCol(string value) =>
            WrapAsUnicodeNormalize(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets form value
        /// </summary>
        /// <returns>
        /// form: Unicode normalization form: NFC, NFD, NFKC, NFKD
        /// </returns>
        public string GetForm() =>
            (string)Reference.Invoke("getForm");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets lower value
        /// </summary>
        /// <returns>
        /// lower: Lowercase text
        /// </returns>
        public bool GetLower() =>
            (bool)Reference.Invoke("getLower");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="UnicodeNormalize"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="UnicodeNormalize"/> was saved to</param>
        /// <returns>New <see cref="UnicodeNormalize"/> object, loaded from path.</returns>
        public static UnicodeNormalize Load(string path) => WrapAsUnicodeNormalize(
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
        /// <returns>an <see cref="JavaMLReader&lt;UnicodeNormalize&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<UnicodeNormalize> Read() =>
            new JavaMLReader<UnicodeNormalize>((JvmObjectReference)Reference.Invoke("read"));
        private static UnicodeNormalize WrapAsUnicodeNormalize(object obj) =>
            new UnicodeNormalize((JvmObjectReference)obj);
        
    }
}

        