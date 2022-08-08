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


namespace Synapse.ML.Lime
{
    /// <summary>
    /// <see cref="SuperpixelTransformer"/> implements SuperpixelTransformer
    /// </summary>
    public class SuperpixelTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<SuperpixelTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.lime.SuperpixelTransformer";

        /// <summary>
        /// Creates a <see cref="SuperpixelTransformer"/> without any parameters.
        /// </summary>
        public SuperpixelTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="SuperpixelTransformer"/> with a UID that is used to give the
        /// <see cref="SuperpixelTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SuperpixelTransformer(string uid) : base(s_className, uid)
        {
        }

        internal SuperpixelTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for cellSize
        /// </summary>
        /// <param name="value">
        /// Number that controls the size of the superpixels
        /// </param>
        /// <returns> New SuperpixelTransformer object </returns>
        public SuperpixelTransformer SetCellSize(double value) =>
            WrapAsSuperpixelTransformer(Reference.Invoke("setCellSize", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New SuperpixelTransformer object </returns>
        public SuperpixelTransformer SetInputCol(string value) =>
            WrapAsSuperpixelTransformer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for modifier
        /// </summary>
        /// <param name="value">
        /// Controls the trade-off spatial and color distance
        /// </param>
        /// <returns> New SuperpixelTransformer object </returns>
        public SuperpixelTransformer SetModifier(double value) =>
            WrapAsSuperpixelTransformer(Reference.Invoke("setModifier", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New SuperpixelTransformer object </returns>
        public SuperpixelTransformer SetOutputCol(string value) =>
            WrapAsSuperpixelTransformer(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets cellSize value
        /// </summary>
        /// <returns>
        /// cellSize: Number that controls the size of the superpixels
        /// </returns>
        public double GetCellSize() =>
            (double)Reference.Invoke("getCellSize");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets modifier value
        /// </summary>
        /// <returns>
        /// modifier: Controls the trade-off spatial and color distance
        /// </returns>
        public double GetModifier() =>
            (double)Reference.Invoke("getModifier");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="SuperpixelTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SuperpixelTransformer"/> was saved to</param>
        /// <returns>New <see cref="SuperpixelTransformer"/> object, loaded from path.</returns>
        public static SuperpixelTransformer Load(string path) => WrapAsSuperpixelTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;SuperpixelTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<SuperpixelTransformer> Read() =>
            new JavaMLReader<SuperpixelTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static SuperpixelTransformer WrapAsSuperpixelTransformer(object obj) =>
            new SuperpixelTransformer((JvmObjectReference)obj);
        
    }
}

        