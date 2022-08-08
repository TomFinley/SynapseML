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
    /// <see cref="VectorZipper"/> implements VectorZipper
    /// </summary>
    public class VectorZipper : JavaTransformer, IJavaMLWritable, IJavaMLReadable<VectorZipper>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.vw.VectorZipper";

        /// <summary>
        /// Creates a <see cref="VectorZipper"/> without any parameters.
        /// </summary>
        public VectorZipper() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VectorZipper"/> with a UID that is used to give the
        /// <see cref="VectorZipper"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VectorZipper(string uid) : base(s_className, uid)
        {
        }

        internal VectorZipper(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCols
        /// </summary>
        /// <param name="value">
        /// The names of the input columns
        /// </param>
        /// <returns> New VectorZipper object </returns>
        public VectorZipper SetInputCols(string[] value) =>
            WrapAsVectorZipper(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New VectorZipper object </returns>
        public VectorZipper SetOutputCol(string value) =>
            WrapAsVectorZipper(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets inputCols value
        /// </summary>
        /// <returns>
        /// inputCols: The names of the input columns
        /// </returns>
        public string[] GetInputCols() =>
            (string[])Reference.Invoke("getInputCols");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="VectorZipper"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VectorZipper"/> was saved to</param>
        /// <returns>New <see cref="VectorZipper"/> object, loaded from path.</returns>
        public static VectorZipper Load(string path) => WrapAsVectorZipper(
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
        /// <returns>an <see cref="JavaMLReader&lt;VectorZipper&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VectorZipper> Read() =>
            new JavaMLReader<VectorZipper>((JvmObjectReference)Reference.Invoke("read"));
        private static VectorZipper WrapAsVectorZipper(object obj) =>
            new VectorZipper((JvmObjectReference)obj);
        
    }
}

        