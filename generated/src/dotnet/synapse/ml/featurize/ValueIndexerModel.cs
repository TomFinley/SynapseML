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


namespace Synapse.ML.Featurize
{
    /// <summary>
    /// <see cref="ValueIndexerModel"/> implements ValueIndexerModel
    /// </summary>
    public class ValueIndexerModel : JavaModel<ValueIndexerModel>, IJavaMLWritable, IJavaMLReadable<ValueIndexerModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.featurize.ValueIndexerModel";

        /// <summary>
        /// Creates a <see cref="ValueIndexerModel"/> without any parameters.
        /// </summary>
        public ValueIndexerModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ValueIndexerModel"/> with a UID that is used to give the
        /// <see cref="ValueIndexerModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ValueIndexerModel(string uid) : base(s_className, uid)
        {
        }

        internal ValueIndexerModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for dataType
        /// </summary>
        /// <param name="value">
        /// The datatype of the levels as a Json string
        /// </param>
        /// <returns> New ValueIndexerModel object </returns>
        public ValueIndexerModel SetDataType(string value) =>
            WrapAsValueIndexerModel(Reference.Invoke("setDataType", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ValueIndexerModel object </returns>
        public ValueIndexerModel SetInputCol(string value) =>
            WrapAsValueIndexerModel(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for levels
        /// </summary>
        /// <param name="value">
        /// Levels in categorical array
        /// </param>
        /// <returns> New ValueIndexerModel object </returns>
        public ValueIndexerModel SetLevels(object[] value)
            => WrapAsValueIndexerModel(Reference.Invoke("setLevels", (object)value.ToJavaArrayList()));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ValueIndexerModel object </returns>
        public ValueIndexerModel SetOutputCol(string value) =>
            WrapAsValueIndexerModel(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets dataType value
        /// </summary>
        /// <returns>
        /// dataType: The datatype of the levels as a Json string
        /// </returns>
        public string GetDataType() =>
            (string)Reference.Invoke("getDataType");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets levels value
        /// </summary>
        /// <returns>
        /// levels: Levels in categorical array
        /// </returns>
        public object[] GetLevels()
        {
            var jvmObjects = (JvmObjectReference[])Reference.Invoke("getLevels");
            var result = new object[jvmObjects.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                    "org.apache.spark.api.dotnet.DotnetUtils", "mapScalaToJava", (object)jvmObjects[i]);
            }
            return result;
        }
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="ValueIndexerModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ValueIndexerModel"/> was saved to</param>
        /// <returns>New <see cref="ValueIndexerModel"/> object, loaded from path.</returns>
        public static ValueIndexerModel Load(string path) => WrapAsValueIndexerModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;ValueIndexerModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ValueIndexerModel> Read() =>
            new JavaMLReader<ValueIndexerModel>((JvmObjectReference)Reference.Invoke("read"));
        private static ValueIndexerModel WrapAsValueIndexerModel(object obj) =>
            new ValueIndexerModel((JvmObjectReference)obj);
        
    }
}

        