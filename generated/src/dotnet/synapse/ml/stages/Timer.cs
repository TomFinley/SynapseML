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
using Synapse.ML.Stages;

namespace Synapse.ML.Stages
{
    /// <summary>
    /// <see cref="Timer"/> implements Timer
    /// </summary>
    public class Timer : JavaEstimator<TimerModel>, IJavaMLWritable, IJavaMLReadable<Timer>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.stages.Timer";

        /// <summary>
        /// Creates a <see cref="Timer"/> without any parameters.
        /// </summary>
        public Timer() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="Timer"/> with a UID that is used to give the
        /// <see cref="Timer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Timer(string uid) : base(s_className, uid)
        {
        }

        internal Timer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for disableMaterialization
        /// </summary>
        /// <param name="value">
        /// Whether to disable timing (so that one can turn it off for evaluation)
        /// </param>
        /// <returns> New Timer object </returns>
        public Timer SetDisableMaterialization(bool value) =>
            WrapAsTimer(Reference.Invoke("setDisableMaterialization", (object)value));
        
        /// <summary>
        /// Sets value for logToScala
        /// </summary>
        /// <param name="value">
        /// Whether to output the time to the scala console
        /// </param>
        /// <returns> New Timer object </returns>
        public Timer SetLogToScala(bool value) =>
            WrapAsTimer(Reference.Invoke("setLogToScala", (object)value));
        
        /// <summary>
        /// Sets value for stage
        /// </summary>
        /// <param name="value">
        /// The stage to time
        /// </param>
        /// <returns> New Timer object </returns>
        public Timer SetStage(JavaPipelineStage value) =>
            WrapAsTimer(Reference.Invoke("setStage", (object)value));
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
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="TimerModel"/></returns>
        override public TimerModel Fit(DataFrame dataset) =>
            new TimerModel(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="Timer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Timer"/> was saved to</param>
        /// <returns>New <see cref="Timer"/> object, loaded from path.</returns>
        public static Timer Load(string path) => WrapAsTimer(
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
        /// <returns>an <see cref="JavaMLReader&lt;Timer&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<Timer> Read() =>
            new JavaMLReader<Timer>((JvmObjectReference)Reference.Invoke("read"));
        private static Timer WrapAsTimer(object obj) =>
            new Timer((JvmObjectReference)obj);
        
    }
}

        