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


namespace Synapse.ML.Image
{
    /// <summary>
    /// <see cref="ResizeImageTransformer"/> implements ResizeImageTransformer
    /// </summary>
    public class ResizeImageTransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ResizeImageTransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.image.ResizeImageTransformer";

        /// <summary>
        /// Creates a <see cref="ResizeImageTransformer"/> without any parameters.
        /// </summary>
        public ResizeImageTransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ResizeImageTransformer"/> with a UID that is used to give the
        /// <see cref="ResizeImageTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ResizeImageTransformer(string uid) : base(s_className, uid)
        {
        }

        internal ResizeImageTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for height
        /// </summary>
        /// <param name="value">
        /// the width of the image
        /// </param>
        /// <returns> New ResizeImageTransformer object </returns>
        public ResizeImageTransformer SetHeight(int value) =>
            WrapAsResizeImageTransformer(Reference.Invoke("setHeight", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ResizeImageTransformer object </returns>
        public ResizeImageTransformer SetInputCol(string value) =>
            WrapAsResizeImageTransformer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for nChannels
        /// </summary>
        /// <param name="value">
        /// the number of channels of the target image
        /// </param>
        /// <returns> New ResizeImageTransformer object </returns>
        public ResizeImageTransformer SetNChannels(int value) =>
            WrapAsResizeImageTransformer(Reference.Invoke("setNChannels", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ResizeImageTransformer object </returns>
        public ResizeImageTransformer SetOutputCol(string value) =>
            WrapAsResizeImageTransformer(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for width
        /// </summary>
        /// <param name="value">
        /// the width of the image
        /// </param>
        /// <returns> New ResizeImageTransformer object </returns>
        public ResizeImageTransformer SetWidth(int value) =>
            WrapAsResizeImageTransformer(Reference.Invoke("setWidth", (object)value));
        /// <summary>
        /// Gets height value
        /// </summary>
        /// <returns>
        /// height: the width of the image
        /// </returns>
        public int GetHeight() =>
            (int)Reference.Invoke("getHeight");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets nChannels value
        /// </summary>
        /// <returns>
        /// nChannels: the number of channels of the target image
        /// </returns>
        public int GetNChannels() =>
            (int)Reference.Invoke("getNChannels");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets width value
        /// </summary>
        /// <returns>
        /// width: the width of the image
        /// </returns>
        public int GetWidth() =>
            (int)Reference.Invoke("getWidth");
        
        /// <summary>
        /// Loads the <see cref="ResizeImageTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ResizeImageTransformer"/> was saved to</param>
        /// <returns>New <see cref="ResizeImageTransformer"/> object, loaded from path.</returns>
        public static ResizeImageTransformer Load(string path) => WrapAsResizeImageTransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;ResizeImageTransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ResizeImageTransformer> Read() =>
            new JavaMLReader<ResizeImageTransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static ResizeImageTransformer WrapAsResizeImageTransformer(object obj) =>
            new ResizeImageTransformer((JvmObjectReference)obj);
        
    }
}

        