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
    /// <see cref="TimerModel"/> implements TimerModel
    /// </summary>
    public class TimerModel : JavaModel<TimerModel>, IJavaMLWritable, IJavaMLReadable<TimerModel>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.TimerModel";

        /// <summary>
        /// Creates a <see cref="TimerModel"/> without any parameters.
        /// </summary>
        public TimerModel() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="TimerModel"/> with a UID that is used to give the
        /// <see cref="TimerModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public TimerModel(string uid) : base(s_className, uid)
        {
        }

        internal TimerModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for disableMaterialization
        /// </summary>
        /// <param name="value">
        /// Whether to disable timing (so that one can turn it off for evaluation)
        /// </param>
        /// <returns> New TimerModel object </returns>
        public TimerModel SetDisableMaterialization(bool value) =>
            WrapAsTimerModel(Reference.Invoke("setDisableMaterialization", (object)value));
        
        /// <summary>
        /// Sets value for logToScala
        /// </summary>
        /// <param name="value">
        /// Whether to output the time to the scala console
        /// </param>
        /// <returns> New TimerModel object </returns>
        public TimerModel SetLogToScala(bool value) =>
            WrapAsTimerModel(Reference.Invoke("setLogToScala", (object)value));
        
        /// <summary>
        /// Sets value for stage
        /// </summary>
        /// <param name="value">
        /// The stage to time
        /// </param>
        /// <returns> New TimerModel object </returns>
        public TimerModel SetStage(JavaPipelineStage value) =>
            WrapAsTimerModel(Reference.Invoke("setStage", (object)value));
        
        
        /// <summary>
        /// Sets value for transformer
        /// </summary>
        /// <param name="value">
        /// inner model to time
        /// </param>
        /// <returns> New TimerModel object </returns>
        public TimerModel SetTransformer(JavaTransformer value) =>
            WrapAsTimerModel(Reference.Invoke("setTransformer", (object)value));
        /// <summary>
        /// Gets disableMaterialization value
        /// </summary>
        /// <returns>
        /// disableMaterialization: Whether to disable timing (so that one can turn it off for evaluation)
        /// </returns>
        public bool GetDisableMaterialization() =>
            (bool)Reference.Invoke("getDisableMaterialization");
        
        /// <summary>
        /// Gets logToScala value
        /// </summary>
        /// <returns>
        /// logToScala: Whether to output the time to the scala console
        /// </returns>
        public bool GetLogToScala() =>
            (bool)Reference.Invoke("getLogToScala");
        
        /// <summary>
        /// Gets stage value
        /// </summary>
        /// <returns>
        /// stage: The stage to time
        /// </returns>
        public JavaPipelineStage GetStage()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getStage");
            Dictionary<string, Type> classMapping = JvmObjectUtils.ConstructJavaClassMapping(
                        typeof(JavaPipelineStage),
                        "s_className");
            JvmObjectUtils.TryConstructInstanceFromJvmObject(
                        jvmObject,
                        classMapping,
                        out JavaPipelineStage instance);
            return instance;
        }
        
        
        /// <summary>
        /// Gets transformer value
        /// </summary>
        /// <returns>
        /// transformer: inner model to time
        /// </returns>
        public JavaTransformer GetTransformer()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getTransformer");
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
        /// Loads the <see cref="TimerModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="TimerModel"/> was saved to</param>
        /// <returns>New <see cref="TimerModel"/> object, loaded from path.</returns>
        public static TimerModel Load(string path) => WrapAsTimerModel(
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
        /// <returns>an <see cref="JavaMLReader&lt;TimerModel&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<TimerModel> Read() =>
            new JavaMLReader<TimerModel>((JvmObjectReference)Reference.Invoke("read"));
        private static TimerModel WrapAsTimerModel(object obj) =>
            new TimerModel((JvmObjectReference)obj);
        
    }
}

        