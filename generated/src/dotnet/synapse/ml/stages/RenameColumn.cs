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
    /// <see cref="RenameColumn"/> implements RenameColumn
    /// </summary>
    public class RenameColumn : JavaTransformer, IJavaMLWritable, IJavaMLReadable<RenameColumn>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.RenameColumn";

        /// <summary>
        /// Creates a <see cref="RenameColumn"/> without any parameters.
        /// </summary>
        public RenameColumn() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="RenameColumn"/> with a UID that is used to give the
        /// <see cref="RenameColumn"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public RenameColumn(string uid) : base(s_className, uid)
        {
        }

        internal RenameColumn(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New RenameColumn object </returns>
        public RenameColumn SetInputCol(string value) =>
            WrapAsRenameColumn(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New RenameColumn object </returns>
        public RenameColumn SetOutputCol(string value) =>
            WrapAsRenameColumn(Reference.Invoke("setOutputCol", (object)value));
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
        /// Loads the <see cref="RenameColumn"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="RenameColumn"/> was saved to</param>
        /// <returns>New <see cref="RenameColumn"/> object, loaded from path.</returns>
        public static RenameColumn Load(string path) => WrapAsRenameColumn(
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
        /// <returns>an <see cref="JavaMLReader&lt;RenameColumn&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<RenameColumn> Read() =>
            new JavaMLReader<RenameColumn>((JvmObjectReference)Reference.Invoke("read"));
        private static RenameColumn WrapAsRenameColumn(object obj) =>
            new RenameColumn((JvmObjectReference)obj);
        
    }
}

        