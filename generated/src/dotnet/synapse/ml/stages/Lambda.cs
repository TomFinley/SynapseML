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
    /// <see cref="Lambda"/> implements Lambda
    /// </summary>
    public class Lambda : JavaTransformer, IJavaMLWritable, IJavaMLReadable<Lambda>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.Lambda";

        /// <summary>
        /// Creates a <see cref="Lambda"/> without any parameters.
        /// </summary>
        public Lambda() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Lambda"/> with a UID that is used to give the
        /// <see cref="Lambda"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Lambda(string uid) : base(s_className, uid)
        {
        }

        internal Lambda(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for transformFunc
        /// </summary>
        /// <param name="value">
        /// holder for dataframe function
        /// </param>
        /// <returns> New Lambda object </returns>
        public Lambda SetTransformFunc(object value) =>
            WrapAsLambda(Reference.Invoke("setTransform", (object)value));
        
        
        /// <summary>
        /// Sets value for transformSchemaFunc
        /// </summary>
        /// <param name="value">
        /// the output schema after the transformation
        /// </param>
        /// <returns> New Lambda object </returns>
        public Lambda SetTransformSchemaFunc(object value) =>
            WrapAsLambda(Reference.Invoke("setTransformSchema", (object)value));
        /// <summary>
        /// Gets transformFunc value
        /// </summary>
        /// <returns>
        /// transformFunc: holder for dataframe function
        /// </returns>
        public object GetTransformFunc() => Reference.Invoke("getTransformFunc");
        
        /// <summary>
        /// Gets transformSchemaFunc value
        /// </summary>
        /// <returns>
        /// transformSchemaFunc: the output schema after the transformation
        /// </returns>
        public object GetTransformSchemaFunc() => Reference.Invoke("getTransformSchemaFunc");
        
        /// <summary>
        /// Loads the <see cref="Lambda"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Lambda"/> was saved to</param>
        /// <returns>New <see cref="Lambda"/> object, loaded from path.</returns>
        public static Lambda Load(string path) => WrapAsLambda(
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
        /// <returns>an <see cref="JavaMLReader&lt;Lambda&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Lambda> Read() =>
            new JavaMLReader<Lambda>((JvmObjectReference)Reference.Invoke("read"));
        private static Lambda WrapAsLambda(object obj) =>
            new Lambda((JvmObjectReference)obj);
        
    }
}

        