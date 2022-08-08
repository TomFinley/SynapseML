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


namespace Synapse.ML.Explainers
{
    /// <summary>
    /// <see cref="ICETransformer"/> implements ICETransformer
    /// </summary>
    public class ICETransformer : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ICETransformer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.explainers.ICETransformer";

        /// <summary>
        /// Creates a <see cref="ICETransformer"/> without any parameters.
        /// </summary>
        public ICETransformer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ICETransformer"/> with a UID that is used to give the
        /// <see cref="ICETransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ICETransformer(string uid) : base(s_className, uid)
        {
        }

        internal ICETransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for categoricalFeatures
        /// </summary>
        /// <param name="value">
        /// The list of categorical features to explain.
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetCategoricalFeatures(object value) =>
            WrapAsICETransformer(Reference.Invoke("setCategoricalFeatures", (object)value));
        
        /// <summary>
        /// Sets value for dependenceNameCol
        /// </summary>
        /// <param name="value">
        /// Output column name which corresponds to dependence values of PDP-based-feature-importance option (kind == `feature`)
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetDependenceNameCol(string value) =>
            WrapAsICETransformer(Reference.Invoke("setDependenceNameCol", (object)value));
        
        /// <summary>
        /// Sets value for featureNameCol
        /// </summary>
        /// <param name="value">
        /// Output column name which corresponds to names of the features used in calculation of PDP-based-feature-importance option (kind == `feature`)
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetFeatureNameCol(string value) =>
            WrapAsICETransformer(Reference.Invoke("setFeatureNameCol", (object)value));
        
        /// <summary>
        /// Sets value for kind
        /// </summary>
        /// <param name="value">
        /// Whether to return the partial dependence plot (PDP) averaged across all the samples in the dataset or individual feature importance (ICE) per sample. Allowed values are "average" for PDP, "individual" for ICE and "feature" for PDP-based feature importance.
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetKind(string value) =>
            WrapAsICETransformer(Reference.Invoke("setKind", (object)value));
        
        /// <summary>
        /// Sets value for model
        /// </summary>
        /// <param name="value">
        /// The model to be interpreted.
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetModel(JavaTransformer value) =>
            WrapAsICETransformer(Reference.Invoke("setModel", (object)value));
        
        
        /// <summary>
        /// Sets value for numSamples
        /// </summary>
        /// <param name="value">
        /// Number of samples to generate.
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetNumSamples(int value) =>
            WrapAsICETransformer(Reference.Invoke("setNumSamples", (object)value));
        
        /// <summary>
        /// Sets value for numericFeatures
        /// </summary>
        /// <param name="value">
        /// The list of numeric features to explain.
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetNumericFeatures(object value) =>
            WrapAsICETransformer(Reference.Invoke("setNumericFeatures", (object)value));
        
        /// <summary>
        /// Sets value for targetClasses
        /// </summary>
        /// <param name="value">
        /// The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetTargetClasses(int[] value) =>
            WrapAsICETransformer(Reference.Invoke("setTargetClasses", (object)value));
        
        /// <summary>
        /// Sets value for targetClassesCol
        /// </summary>
        /// <param name="value">
        /// The name of the column that specifies the indices of the classes for multinomial classification models.
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetTargetClassesCol(string value) =>
            WrapAsICETransformer(Reference.Invoke("setTargetClassesCol", (object)value));
        
        /// <summary>
        /// Sets value for targetCol
        /// </summary>
        /// <param name="value">
        /// The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
        /// </param>
        /// <returns> New ICETransformer object </returns>
        public ICETransformer SetTargetCol(string value) =>
            WrapAsICETransformer(Reference.Invoke("setTargetCol", (object)value));
        /// <summary>
        /// Gets categoricalFeatures value
        /// </summary>
        /// <returns>
        /// categoricalFeatures: The list of categorical features to explain.
        /// </returns>
        public object GetCategoricalFeatures() =>
            (object)Reference.Invoke("getCategoricalFeatures");
        
        /// <summary>
        /// Gets dependenceNameCol value
        /// </summary>
        /// <returns>
        /// dependenceNameCol: Output column name which corresponds to dependence values of PDP-based-feature-importance option (kind == `feature`)
        /// </returns>
        public string GetDependenceNameCol() =>
            (string)Reference.Invoke("getDependenceNameCol");
        
        /// <summary>
        /// Gets featureNameCol value
        /// </summary>
        /// <returns>
        /// featureNameCol: Output column name which corresponds to names of the features used in calculation of PDP-based-feature-importance option (kind == `feature`)
        /// </returns>
        public string GetFeatureNameCol() =>
            (string)Reference.Invoke("getFeatureNameCol");
        
        /// <summary>
        /// Gets kind value
        /// </summary>
        /// <returns>
        /// kind: Whether to return the partial dependence plot (PDP) averaged across all the samples in the dataset or individual feature importance (ICE) per sample. Allowed values are "average" for PDP, "individual" for ICE and "feature" for PDP-based feature importance.
        /// </returns>
        public string GetKind() =>
            (string)Reference.Invoke("getKind");
        
        /// <summary>
        /// Gets model value
        /// </summary>
        /// <returns>
        /// model: The model to be interpreted.
        /// </returns>
        public JavaTransformer GetModel()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getModel");
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
        /// Gets numSamples value
        /// </summary>
        /// <returns>
        /// numSamples: Number of samples to generate.
        /// </returns>
        public int GetNumSamples() =>
            (int)Reference.Invoke("getNumSamples");
        
        /// <summary>
        /// Gets numericFeatures value
        /// </summary>
        /// <returns>
        /// numericFeatures: The list of numeric features to explain.
        /// </returns>
        public object GetNumericFeatures() =>
            (object)Reference.Invoke("getNumericFeatures");
        
        /// <summary>
        /// Gets targetClasses value
        /// </summary>
        /// <returns>
        /// targetClasses: The indices of the classes for multinomial classification models. Default: 0.For regression models this parameter is ignored.
        /// </returns>
        public int[] GetTargetClasses() =>
            (int[])Reference.Invoke("getTargetClasses");
        
        /// <summary>
        /// Gets targetClassesCol value
        /// </summary>
        /// <returns>
        /// targetClassesCol: The name of the column that specifies the indices of the classes for multinomial classification models.
        /// </returns>
        public string GetTargetClassesCol() =>
            (string)Reference.Invoke("getTargetClassesCol");
        
        /// <summary>
        /// Gets targetCol value
        /// </summary>
        /// <returns>
        /// targetCol: The column name of the prediction target to explain (i.e. the response variable). This is usually set to "prediction" for regression models and "probability" for probabilistic classification models. Default value: probability
        /// </returns>
        public string GetTargetCol() =>
            (string)Reference.Invoke("getTargetCol");
        
        /// <summary>
        /// Loads the <see cref="ICETransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ICETransformer"/> was saved to</param>
        /// <returns>New <see cref="ICETransformer"/> object, loaded from path.</returns>
        public static ICETransformer Load(string path) => WrapAsICETransformer(
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
        /// <returns>an <see cref="JavaMLReader&lt;ICETransformer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ICETransformer> Read() =>
            new JavaMLReader<ICETransformer>((JvmObjectReference)Reference.Invoke("read"));
        private static ICETransformer WrapAsICETransformer(object obj) =>
            new ICETransformer((JvmObjectReference)obj);
        
    }
}

        