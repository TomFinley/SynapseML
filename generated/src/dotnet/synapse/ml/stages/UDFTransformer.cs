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
    /// <see cref="UDFTransformer"/> implements UDFTransformer
    /// </summary>
    public class UDFTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<UDFTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.UDFTransformer";

        /// <summary>
        /// Creates a <see cref="UDFTransformer"/> without any parameters.
        /// </summary>
        public UDFTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="UDFTransformer"/> with a UID that is used to give the
        /// <see cref="UDFTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public UDFTransformer(string uid) : base(s_className, uid)
        {
        }

        internal UDFTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New UDFTransformer object </returns>
        public UDFTransformer SetInputCol(string value) =>
            WrapAsUDFTransformer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for inputCols
        /// </summary>
        /// <param name="value">
        /// The names of the input columns
        /// </param>
        /// <returns> New UDFTransformer object </returns>
        public UDFTransformer SetInputCols(string[] value) =>
            WrapAsUDFTransformer(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New UDFTransformer object </returns>
        public UDFTransformer SetOutputCol(string value) =>
            WrapAsUDFTransformer(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for udf
        /// </summary>
        /// <param name="value">
        /// User Defined Python Function to be applied to the DF input col
        /// </param>
        /// <returns> New UDFTransformer object </returns>
        public UDFTransformer SetUdf(object value) =>
            WrapAsUDFTransformer(Reference.Invoke("setUdf", (object)value));
        
        
        /// <summary>
        /// Sets value for udfScala
        /// </summary>
        /// <param name="value">
        /// User Defined Function to be applied to the DF input col
        /// </param>
        /// <returns> New UDFTransformer object </returns>
        public UDFTransformer SetUdfScala(object value) =>
            WrapAsUDFTransformer(Reference.Invoke("setUDF", (object)value));
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
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
        /// Gets udf value
        /// </summary>
        /// <returns>
        /// udf: User Defined Python Function to be applied to the DF input col
        /// </returns>
        public object GetUdf() => Reference.Invoke("getUdf");
        
        /// <summary>
        /// Gets udfScala value
        /// </summary>
        /// <returns>
        /// udfScala: User Defined Function to be applied to the DF input col
        /// </returns>
        public object GetUdfScala() => Reference.Invoke("getUdfScala");
        
        /// <summary>
        /// Loads the <see cref="UDFTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="UDFTransformer"/> was saved to</param>
        /// <returns>New <see cref="UDFTransformer"/> object, loaded from path.</returns>
        public static UDFTransformer Load(string path) => WrapAsUDFTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;UDFTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<UDFTransformer> Read() =>
            new JavaMLReader<UDFTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static UDFTransformer WrapAsUDFTransformer(object obj) =>
            new UDFTransformer((JvmObjectReference)obj);
        
    }
}

        