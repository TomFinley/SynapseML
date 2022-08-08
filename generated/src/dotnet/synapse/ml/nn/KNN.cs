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
using Synapse.ML.Nn;

namespace Synapse.ML.Nn
{
    /// <summary>
    /// <see cref="KNN"/> implements KNN
    /// </summary>
    public class KNN : JavaEstimator<KNNModel>, IJavaMLWritable, IJavaMLReadable<KNN>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.nn.KNN";

        /// <summary>
        /// Creates a <see cref="KNN"/> without any parameters.
        /// </summary>
        public KNN() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="KNN"/> with a UID that is used to give the
        /// <see cref="KNN"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public KNN(string uid) : base(s_className, uid)
        {
        }

        internal KNN(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for featuresCol
        /// </summary>
        /// <param name="value">
        /// The name of the features column
        /// </param>
        /// <returns> New KNN object </returns>
        public KNN SetFeaturesCol(string value) =>
            WrapAsKNN(Reference.Invoke("setFeaturesCol", (object)value));
        
        /// <summary>
        /// Sets value for k
        /// </summary>
        /// <param name="value">
        /// number of matches to return
        /// </param>
        /// <returns> New KNN object </returns>
        public KNN SetK(int value) =>
            WrapAsKNN(Reference.Invoke("setK", (object)value));
        
        /// <summary>
        /// Sets value for leafSize
        /// </summary>
        /// <param name="value">
        /// max size of the leaves of the tree
        /// </param>
        /// <returns> New KNN object </returns>
        public KNN SetLeafSize(int value) =>
            WrapAsKNN(Reference.Invoke("setLeafSize", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New KNN object </returns>
        public KNN SetOutputCol(string value) =>
            WrapAsKNN(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for valuesCol
        /// </summary>
        /// <param name="value">
        /// column holding values for each feature (key) that will be returned when queried
        /// </param>
        /// <returns> New KNN object </returns>
        public KNN SetValuesCol(string value) =>
            WrapAsKNN(Reference.Invoke("setValuesCol", (object)value));
        /// <summary>
        /// Gets featuresCol value
        /// </summary>
        /// <returns>
        /// featuresCol: The name of the features column
        /// </returns>
        public string GetFeaturesCol() =>
            (string)Reference.Invoke("getFeaturesCol");
        
        /// <summary>
        /// Gets k value
        /// </summary>
        /// <returns>
        /// k: number of matches to return
        /// </returns>
        public int GetK() =>
            (int)Reference.Invoke("getK");
        
        /// <summary>
        /// Gets leafSize value
        /// </summary>
        /// <returns>
        /// leafSize: max size of the leaves of the tree
        /// </returns>
        public int GetLeafSize() =>
            (int)Reference.Invoke("getLeafSize");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets valuesCol value
        /// </summary>
        /// <returns>
        /// valuesCol: column holding values for each feature (key) that will be returned when queried
        /// </returns>
        public string GetValuesCol() =>
            (string)Reference.Invoke("getValuesCol");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="KNNModel"/></returns>
        override public KNNModel Fit(DataFrame dataset) =>
            new KNNModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="KNN"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="KNN"/> was saved to</param>
        /// <returns>New <see cref="KNN"/> object, loaded from path.</returns>
        public static KNN Load(string path) => WrapAsKNN(
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
        /// <returns>an <see cref="JavaMLReader&lt;KNN&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<KNN> Read() =>
            new JavaMLReader<KNN>((JvmObjectReference)Reference.Invoke("read"));
        private static KNN WrapAsKNN(object obj) =>
            new KNN((JvmObjectReference)obj);
        
    }
}

        