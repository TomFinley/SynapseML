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


namespace Synapse.ML.Cntk
{
    /// <summary>
    /// <see cref="ImageFeaturizer"/> implements ImageFeaturizer
    /// </summary>
    public class ImageFeaturizer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ImageFeaturizer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cntk.ImageFeaturizer";

        /// <summary>
        /// Creates a <see cref="ImageFeaturizer"/> without any parameters.
        /// </summary>
        public ImageFeaturizer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ImageFeaturizer"/> with a UID that is used to give the
        /// <see cref="ImageFeaturizer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ImageFeaturizer(string uid) : base(s_className, uid)
        {
        }

        internal ImageFeaturizer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for cntkModel
        /// </summary>
        /// <param name="value">
        /// The internal CNTK model used in the featurizer
        /// </param>
        /// <returns> New ImageFeaturizer object </returns>
        public ImageFeaturizer SetCntkModel(JavaTransformer value) =>
            WrapAsImageFeaturizer(Reference.Invoke("setCntkModel", (object)value));
        
        
        /// <summary>
        /// Sets value for cutOutputLayers
        /// </summary>
        /// <param name="value">
        /// The number of layers to cut off the end of the network, 0 leaves the network intact, 1 removes the output layer, etc
        /// </param>
        /// <returns> New ImageFeaturizer object </returns>
        public ImageFeaturizer SetCutOutputLayers(int value) =>
            WrapAsImageFeaturizer(Reference.Invoke("setCutOutputLayers", (object)value));
        
        /// <summary>
        /// Sets value for dropNa
        /// </summary>
        /// <param name="value">
        /// Whether to drop na values before mapping
        /// </param>
        /// <returns> New ImageFeaturizer object </returns>
        public ImageFeaturizer SetDropNa(bool value) =>
            WrapAsImageFeaturizer(Reference.Invoke("setDropNa", (object)value));
        
        /// <summary>
        /// Sets value for inputCol
        /// </summary>
        /// <param name="value">
        /// The name of the input column
        /// </param>
        /// <returns> New ImageFeaturizer object </returns>
        public ImageFeaturizer SetInputCol(string value) =>
            WrapAsImageFeaturizer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets value for layerNames
        /// </summary>
        /// <param name="value">
        /// Array with valid CNTK nodes to choose from, the first entries of this array should be closer to the output node
        /// </param>
        /// <returns> New ImageFeaturizer object </returns>
        public ImageFeaturizer SetLayerNames(string[] value) =>
            WrapAsImageFeaturizer(Reference.Invoke("setLayerNames", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ImageFeaturizer object </returns>
        public ImageFeaturizer SetOutputCol(string value) =>
            WrapAsImageFeaturizer(Reference.Invoke("setOutputCol", (object)value));
        /// <summary>
        /// Gets cntkModel value
        /// </summary>
        /// <returns>
        /// cntkModel: The internal CNTK model used in the featurizer
        /// </returns>
        public JavaTransformer GetCntkModel()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getCntkModel");
            Dictionary<string, Type> classMapping = JvmObjectUtils.ConstructJavaClassMapping(
                        typeof(JavaTransformer),
                        "s_className");
            JvmObjectUtils.TryConstructInstanceFromJvmObject(
                        jvmObject,
                        classMapping,
                        out JavaTransformer instance);
            return instance;
        }
        
        
        /// <summary>
        /// Gets cutOutputLayers value
        /// </summary>
        /// <returns>
        /// cutOutputLayers: The number of layers to cut off the end of the network, 0 leaves the network intact, 1 removes the output layer, etc
        /// </returns>
        public int GetCutOutputLayers() =>
            (int)Reference.Invoke("getCutOutputLayers");
        
        /// <summary>
        /// Gets dropNa value
        /// </summary>
        /// <returns>
        /// dropNa: Whether to drop na values before mapping
        /// </returns>
        public bool GetDropNa() =>
            (bool)Reference.Invoke("getDropNa");
        
        /// <summary>
        /// Gets inputCol value
        /// </summary>
        /// <returns>
        /// inputCol: The name of the input column
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets layerNames value
        /// </summary>
        /// <returns>
        /// layerNames: Array with valid CNTK nodes to choose from, the first entries of this array should be closer to the output node
        /// </returns>
        public string[] GetLayerNames() =>
            (string[])Reference.Invoke("getLayerNames");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Loads the <see cref="ImageFeaturizer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ImageFeaturizer"/> was saved to</param>
        /// <returns>New <see cref="ImageFeaturizer"/> object, loaded from path.</returns>
        public static ImageFeaturizer Load(string path) => WrapAsImageFeaturizer(
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
        /// <returns>an <see cref="JavaMLReader&lt;ImageFeaturizer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ImageFeaturizer> Read() =>
            new JavaMLReader<ImageFeaturizer>((JvmObjectReference)Reference.Invoke("read"));
        private static ImageFeaturizer WrapAsImageFeaturizer(object obj) =>
            new ImageFeaturizer((JvmObjectReference)obj);
        
    }
}

        