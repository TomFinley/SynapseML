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


namespace Synapse.ML.Cognitive
{
    /// <summary>
    /// <see cref="IdentifyFaces"/> implements IdentifyFaces
    /// </summary>
    public class IdentifyFaces : JavaTransformer, IJavaMLWritable, IJavaMLReadable<IdentifyFaces>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.IdentifyFaces";

        /// <summary>
        /// Creates a <see cref="IdentifyFaces"/> without any parameters.
        /// </summary>
        public IdentifyFaces() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="IdentifyFaces"/> with a UID that is used to give the
        /// <see cref="IdentifyFaces"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public IdentifyFaces(string uid) : base(s_className, uid)
        {
        }

        internal IdentifyFaces(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetConcurrency(int value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetConcurrentTimeout(double value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for confidenceThreshold
        /// </summary>
        /// <param name="value">
        /// Optional parameter.Customized identification confidence threshold, in the range of [0, 1].Advanced user can tweak this value to override defaultinternal threshold for better precision on their scenario data.Note there is no guarantee of this threshold value workingon other data and after algorithm updates.
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetConfidenceThreshold(double value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setConfidenceThreshold", (object)value));
        
        
        /// <summary>
        /// Sets value for confidenceThreshold column
        /// </summary>
        /// <param name="value">
        /// Optional parameter.Customized identification confidence threshold, in the range of [0, 1].Advanced user can tweak this value to override defaultinternal threshold for better precision on their scenario data.Note there is no guarantee of this threshold value workingon other data and after algorithm updates.
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetConfidenceThresholdCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setConfidenceThresholdCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetErrorCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for faceIds
        /// </summary>
        /// <param name="value">
        /// Array of query faces faceIds, created by the Face - Detect. Each of the faces are identified independently. The valid number of faceIds is between [1, 10]. 
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetFaceIds(string[] value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setFaceIds", (object)value));
        
        
        /// <summary>
        /// Sets value for faceIds column
        /// </summary>
        /// <param name="value">
        /// Array of query faces faceIds, created by the Face - Detect. Each of the faces are identified independently. The valid number of faceIds is between [1, 10]. 
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetFaceIdsCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setFaceIdsCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetHandler(object value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for largePersonGroupId
        /// </summary>
        /// <param name="value">
        /// largePersonGroupId of the target large person group, created by LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetLargePersonGroupId(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setLargePersonGroupId", (object)value));
        
        
        /// <summary>
        /// Sets value for largePersonGroupId column
        /// </summary>
        /// <param name="value">
        /// largePersonGroupId of the target large person group, created by LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetLargePersonGroupIdCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setLargePersonGroupIdCol", value));
        
        
        /// <summary>
        /// Sets value for maxNumOfCandidatesReturned
        /// </summary>
        /// <param name="value">
        /// The range of maxNumOfCandidatesReturned is between 1 and 100 (default is 10).
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetMaxNumOfCandidatesReturned(int value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setMaxNumOfCandidatesReturned", (object)value));
        
        
        /// <summary>
        /// Sets value for maxNumOfCandidatesReturned column
        /// </summary>
        /// <param name="value">
        /// The range of maxNumOfCandidatesReturned is between 1 and 100 (default is 10).
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetMaxNumOfCandidatesReturnedCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setMaxNumOfCandidatesReturnedCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetOutputCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for personGroupId
        /// </summary>
        /// <param name="value">
        /// personGroupId of the target person group, created by PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetPersonGroupId(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setPersonGroupId", (object)value));
        
        
        /// <summary>
        /// Sets value for personGroupId column
        /// </summary>
        /// <param name="value">
        /// personGroupId of the target person group, created by PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetPersonGroupIdCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setPersonGroupIdCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetSubscriptionKey(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetSubscriptionKeyCol(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetTimeout(double value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetUrl(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets concurrency value
        /// </summary>
        /// <returns>
        /// concurrency: max number of concurrent calls
        /// </returns>
        public int GetConcurrency() =>
            (int)Reference.Invoke("getConcurrency");
        
        /// <summary>
        /// Gets concurrentTimeout value
        /// </summary>
        /// <returns>
        /// concurrentTimeout: max number seconds to wait on futures if concurrency >= 1
        /// </returns>
        public double GetConcurrentTimeout() =>
            (double)Reference.Invoke("getConcurrentTimeout");
        
        /// <summary>
        /// Gets confidenceThreshold value
        /// </summary>
        /// <returns>
        /// confidenceThreshold: Optional parameter.Customized identification confidence threshold, in the range of [0, 1].Advanced user can tweak this value to override defaultinternal threshold for better precision on their scenario data.Note there is no guarantee of this threshold value workingon other data and after algorithm updates.
        /// </returns>
        public double GetConfidenceThreshold() =>
            (double)Reference.Invoke("getConfidenceThreshold");
        
        
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets faceIds value
        /// </summary>
        /// <returns>
        /// faceIds: Array of query faces faceIds, created by the Face - Detect. Each of the faces are identified independently. The valid number of faceIds is between [1, 10]. 
        /// </returns>
        public string[] GetFaceIds() =>
            (string[])Reference.Invoke("getFaceIds");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets largePersonGroupId value
        /// </summary>
        /// <returns>
        /// largePersonGroupId: largePersonGroupId of the target large person group, created by LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </returns>
        public string GetLargePersonGroupId() =>
            (string)Reference.Invoke("getLargePersonGroupId");
        
        
        /// <summary>
        /// Gets maxNumOfCandidatesReturned value
        /// </summary>
        /// <returns>
        /// maxNumOfCandidatesReturned: The range of maxNumOfCandidatesReturned is between 1 and 100 (default is 10).
        /// </returns>
        public int GetMaxNumOfCandidatesReturned() =>
            (int)Reference.Invoke("getMaxNumOfCandidatesReturned");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets personGroupId value
        /// </summary>
        /// <returns>
        /// personGroupId: personGroupId of the target person group, created by PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </returns>
        public string GetPersonGroupId() =>
            (string)Reference.Invoke("getPersonGroupId");
        
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets timeout value
        /// </summary>
        /// <returns>
        /// timeout: number of seconds to wait before closing the connection
        /// </returns>
        public double GetTimeout() =>
            (double)Reference.Invoke("getTimeout");
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        
        /// <summary>
        /// Loads the <see cref="IdentifyFaces"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="IdentifyFaces"/> was saved to</param>
        /// <returns>New <see cref="IdentifyFaces"/> object, loaded from path.</returns>
        public static IdentifyFaces Load(string path) => WrapAsIdentifyFaces(
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
        /// <returns>an <see cref="JavaMLReader&lt;IdentifyFaces&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<IdentifyFaces> Read() =>
            new JavaMLReader<IdentifyFaces>((JvmObjectReference)Reference.Invoke("read"));
        private static IdentifyFaces WrapAsIdentifyFaces(object obj) =>
            new IdentifyFaces((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetLocation(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New IdentifyFaces object </returns>
        public IdentifyFaces SetLinkedService(string value) =>
            WrapAsIdentifyFaces(Reference.Invoke("setLinkedService", value));
    }
}

        