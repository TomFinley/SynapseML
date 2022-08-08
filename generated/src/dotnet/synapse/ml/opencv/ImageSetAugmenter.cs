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


namespace Synapse.ML.Opencv
{
    /// <summary>
    /// <see cref="ImageSetAugmenter"/> implements ImageSetAugmenter
    /// </summary>
    public class ImageSetAugmenter : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ImageSetAugmenter>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.opencv.ImageSetAugmenter";

        /// <summary>
        /// Creates a <see cref="ImageSetAugmenter"/> without any parameters.
        /// </summary>
        public ImageSetAugmenter() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ImageSetAugmenter"/> with a UID that is used to give the
        /// <see cref="ImageSetAugmenter"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ImageSetAugmenter(string uid) : base(s_className, uid)
        {
        }

        internal ImageSetAugmenter(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for flipLeftRight
        /// </summary>
        /// <param name="value">
        /// Symmetric Left-Right
        /// </param>
        /// <returns> New ImageSetAugmenter object </returns>
        public ImageSetAugmenter SetFlipLeftRight(bool value) =>
            WrapAsImageSetAugmenter(Reference.Invoke("setFlipLeftRight", (object)value));
        
        /// <summary>
        /// Sets value for flipUpDown
        /// </summary>
        /// <param name="value">
        /// Symmetric Up-Down
        /// </param>
        /// <returns> New ImageSetAugmenter object </returns>
        public ImageSetAugmenter SetFlipUpDown(bool value) =>
            WrapAsImageSetAugmenter(Reference.Invoke("setFlipUpDown", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ImageSetAugmenter object </returns>
        public ImageSetAugmenter SetInputCol(string value) =>
            WrapAsImageSetAugmenter(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ImageSetAugmenter object </returns>
        public ImageSetAugmenter SetOutputCol(string value) =>
            WrapAsImageSetAugmenter(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets flipLeftRight value
        /// </summary>
        /// <returns>
        /// flipLeftRight: Symmetric Left-Right
        /// </returns>
        public bool GetFlipLeftRight() =>
            (bool)Reference.Invoke("getFlipLeftRight");
        
        /// <summary>
        /// Gets flipUpDown value
        /// </summary>
        /// <returns>
        /// flipUpDown: Symmetric Up-Down
        /// </returns>
        public bool GetFlipUpDown() =>
            (bool)Reference.Invoke("getFlipUpDown");
        
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
        /// Loads the <see cref="ImageSetAugmenter"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ImageSetAugmenter"/> was saved to</param>
        /// <returns>New <see cref="ImageSetAugmenter"/> object, loaded from path.</returns>
        public static ImageSetAugmenter Load(string path) => WrapAsImageSetAugmenter(
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
        /// <returns>an <see cref="JavaMLReader&lt;ImageSetAugmenter&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ImageSetAugmenter> Read() =>
            new JavaMLReader<ImageSetAugmenter>((JvmObjectReference)Reference.Invoke("read"));
        private static ImageSetAugmenter WrapAsImageSetAugmenter(object obj) =>
            new ImageSetAugmenter((JvmObjectReference)obj);
        
    }
}

        