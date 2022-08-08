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
    /// <see cref="Explode"/> implements Explode
    /// </summary>
    public class Explode : JavaTransformer, IJavaMLWritable, IJavaMLReadable<Explode>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.Explode";

        /// <summary>
        /// Creates a <see cref="Explode"/> without any parameters.
        /// </summary>
        public Explode() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Explode"/> with a UID that is used to give the
        /// <see cref="Explode"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Explode(string uid) : base(s_className, uid)
        {
        }

        internal Explode(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New Explode object </returns>
        public Explode SetInputCol(string value) =>
            WrapAsExplode(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New Explode object </returns>
        public Explode SetOutputCol(string value) =>
            WrapAsExplode(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="Explode"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Explode"/> was saved to</param>
        /// <returns>New <see cref="Explode"/> object, loaded from path.</returns>
        public static Explode Load(string path) => WrapAsExplode(
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
        /// <returns>an <see cref="JavaMLReader&lt;Explode&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Explode> Read() =>
            new JavaMLReader<Explode>((JvmObjectReference)Reference.Invoke("read"));
        private static Explode WrapAsExplode(object obj) =>
            new Explode((JvmObjectReference)obj);
        
    }
}

        