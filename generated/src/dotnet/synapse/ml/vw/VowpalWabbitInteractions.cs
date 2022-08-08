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
    /// <see cref="VowpalWabbitInteractions"/> implements VowpalWabbitInteractions
    /// </summary>
    public class VowpalWabbitInteractions : JavaTransformer, IJavaMLWritable, IJavaMLReadable<VowpalWabbitInteractions>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VowpalWabbitInteractions";

        /// <summary>
        /// Creates a <see cref="VowpalWabbitInteractions"/> without any parameters.
        /// </summary>
        public VowpalWabbitInteractions() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VowpalWabbitInteractions"/> with a UID that is used to give the
        /// <see cref="VowpalWabbitInteractions"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VowpalWabbitInteractions(string uid) : base(s_className, uid)
        {
        }

        internal VowpalWabbitInteractions(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCols
        /// </summary>
        /// <param name="value">
        /// The names of the input columns
        /// </param>
        /// <returns> New VowpalWabbitInteractions object </returns>
        public VowpalWabbitInteractions SetInputCols(string[] value) =>
            WrapAsVowpalWabbitInteractions(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets value for numBits
        /// </summary>
        /// <param name="value">
        /// Number of bits used to mask
        /// </param>
        /// <returns> New VowpalWabbitInteractions object </returns>
        public VowpalWabbitInteractions SetNumBits(int value) =>
            WrapAsVowpalWabbitInteractions(Reference.Invoke("setNumBits", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New VowpalWabbitInteractions object </returns>
        public VowpalWabbitInteractions SetOutputCol(string value) =>
            WrapAsVowpalWabbitInteractions(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for sumCollisions
        /// </summary>
        /// <param name="value">
        /// Sums collisions if true, otherwise removes them
        /// </param>
        /// <returns> New VowpalWabbitInteractions object </returns>
        public VowpalWabbitInteractions SetSumCollisions(bool value) =>
            WrapAsVowpalWabbitInteractions(Reference.Invoke("setSumCollisions", (object)value));
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
        /// Gets sumCollisions value
        /// </summary>
        /// <returns>
        /// sumCollisions: Sums collisions if true, otherwise removes them
        /// </returns>
        public bool GetSumCollisions() =>
            (bool)Reference.Invoke("getSumCollisions");
        
        /// <summary>
        /// Loads the <see cref="VowpalWabbitInteractions"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VowpalWabbitInteractions"/> was saved to</param>
        /// <returns>New <see cref="VowpalWabbitInteractions"/> object, loaded from path.</returns>
        public static VowpalWabbitInteractions Load(string path) => WrapAsVowpalWabbitInteractions(
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
        /// <returns>an <see cref="JavaMLReader&lt;VowpalWabbitInteractions&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VowpalWabbitInteractions> Read() =>
            new JavaMLReader<VowpalWabbitInteractions>((JvmObjectReference)Reference.Invoke("read"));
        private static VowpalWabbitInteractions WrapAsVowpalWabbitInteractions(object obj) =>
            new VowpalWabbitInteractions((JvmObjectReference)obj);
        
    }
}

        