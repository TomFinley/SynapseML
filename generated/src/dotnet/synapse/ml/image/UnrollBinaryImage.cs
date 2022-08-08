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
    /// <see cref="UnrollBinaryImage"/> implements UnrollBinaryImage
    /// </summary>
    public class UnrollBinaryImage : JavaTransformer, IJavaMLWritable, IJavaMLReadable<UnrollBinaryImage>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.image.UnrollBinaryImage";

        /// <summary>
        /// Creates a <see cref="UnrollBinaryImage"/> without any parameters.
        /// </summary>
        public UnrollBinaryImage() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="UnrollBinaryImage"/> with a UID that is used to give the
        /// <see cref="UnrollBinaryImage"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public UnrollBinaryImage(string uid) : base(s_className, uid)
        {
        }

        internal UnrollBinaryImage(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for height
        /// </summary>
        /// <param name="value">
        /// the width of the image
        /// </param>
        /// <returns> New UnrollBinaryImage object </returns>
        public UnrollBinaryImage SetHeight(int value) =>
            WrapAsUnrollBinaryImage(Reference.Invoke("setHeight", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New UnrollBinaryImage object </returns>
        public UnrollBinaryImage SetInputCol(string value) =>
            WrapAsUnrollBinaryImage(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for nChannels
        /// </summary>
        /// <param name="value">
        /// the number of channels of the target image
        /// </param>
        /// <returns> New UnrollBinaryImage object </returns>
        public UnrollBinaryImage SetNChannels(int value) =>
            WrapAsUnrollBinaryImage(Reference.Invoke("setNChannels", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New UnrollBinaryImage object </returns>
        public UnrollBinaryImage SetOutputCol(string value) =>
            WrapAsUnrollBinaryImage(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for width
        /// </summary>
        /// <param name="value">
        /// the width of the image
        /// </param>
        /// <returns> New UnrollBinaryImage object </returns>
        public UnrollBinaryImage SetWidth(int value) =>
            WrapAsUnrollBinaryImage(Reference.Invoke("setWidth", (object)value));
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
        /// Loads the <see cref="UnrollBinaryImage"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="UnrollBinaryImage"/> was saved to</param>
        /// <returns>New <see cref="UnrollBinaryImage"/> object, loaded from path.</returns>
        public static UnrollBinaryImage Load(string path) => WrapAsUnrollBinaryImage(
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
        /// <returns>an <see cref="JavaMLReader&lt;UnrollBinaryImage&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<UnrollBinaryImage> Read() =>
            new JavaMLReader<UnrollBinaryImage>((JvmObjectReference)Reference.Invoke("read"));
        private static UnrollBinaryImage WrapAsUnrollBinaryImage(object obj) =>
            new UnrollBinaryImage((JvmObjectReference)obj);
        
    }
}

        