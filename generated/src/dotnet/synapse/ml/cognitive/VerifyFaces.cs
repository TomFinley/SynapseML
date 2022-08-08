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
    /// <see cref="VerifyFaces"/> implements VerifyFaces
    /// </summary>
    public class VerifyFaces : JavaTransformer, IJavaMLWritable, IJavaMLReadable<VerifyFaces>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.VerifyFaces";

        /// <summary>
        /// Creates a <see cref="VerifyFaces"/> without any parameters.
        /// </summary>
        public VerifyFaces() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="VerifyFaces"/> with a UID that is used to give the
        /// <see cref="VerifyFaces"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VerifyFaces(string uid) : base(s_className, uid)
        {
        }

        internal VerifyFaces(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetConcurrency(int value) =>
            WrapAsVerifyFaces(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetConcurrentTimeout(double value) =>
            WrapAsVerifyFaces(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetErrorCol(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for faceId
        /// </summary>
        /// <param name="value">
        /// faceId of the face, comes from Face - Detect.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetFaceId(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setFaceId", (object)value));
        
        
        /// <summary>
        /// Sets value for faceId column
        /// </summary>
        /// <param name="value">
        /// faceId of the face, comes from Face - Detect.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetFaceIdCol(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setFaceIdCol", value));
        
        
        /// <summary>
        /// Sets value for faceId1
        /// </summary>
        /// <param name="value">
        /// faceId of one face, comes from Face - Detect.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetFaceId1(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setFaceId1", (object)value));
        
        
        /// <summary>
        /// Sets value for faceId1 column
        /// </summary>
        /// <param name="value">
        /// faceId of one face, comes from Face - Detect.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetFaceId1Col(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setFaceId1Col", value));
        
        
        /// <summary>
        /// Sets value for faceId2
        /// </summary>
        /// <param name="value">
        /// faceId of another face, comes from Face - Detect.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetFaceId2(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setFaceId2", (object)value));
        
        
        /// <summary>
        /// Sets value for faceId2 column
        /// </summary>
        /// <param name="value">
        /// faceId of another face, comes from Face - Detect.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetFaceId2Col(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setFaceId2Col", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetHandler(object value) =>
            WrapAsVerifyFaces(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for largePersonGroupId
        /// </summary>
        /// <param name="value">
        /// Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetLargePersonGroupId(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setLargePersonGroupId", (object)value));
        
        
        /// <summary>
        /// Sets value for largePersonGroupId column
        /// </summary>
        /// <param name="value">
        /// Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetLargePersonGroupIdCol(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setLargePersonGroupIdCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetOutputCol(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for personGroupId
        /// </summary>
        /// <param name="value">
        /// Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetPersonGroupId(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setPersonGroupId", (object)value));
        
        
        /// <summary>
        /// Sets value for personGroupId column
        /// </summary>
        /// <param name="value">
        /// Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetPersonGroupIdCol(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setPersonGroupIdCol", value));
        
        
        /// <summary>
        /// Sets value for personId
        /// </summary>
        /// <param name="value">
        /// Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetPersonId(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setPersonId", (object)value));
        
        
        /// <summary>
        /// Sets value for personId column
        /// </summary>
        /// <param name="value">
        /// Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetPersonIdCol(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setPersonIdCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetSubscriptionKey(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetSubscriptionKeyCol(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetTimeout(double value) =>
            WrapAsVerifyFaces(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetUrl(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setUrl", (object)value));
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
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets faceId value
        /// </summary>
        /// <returns>
        /// faceId: faceId of the face, comes from Face - Detect.
        /// </returns>
        public string GetFaceId() =>
            (string)Reference.Invoke("getFaceId");
        
        
        /// <summary>
        /// Gets faceId1 value
        /// </summary>
        /// <returns>
        /// faceId1: faceId of one face, comes from Face - Detect.
        /// </returns>
        public string GetFaceId1() =>
            (string)Reference.Invoke("getFaceId1");
        
        
        /// <summary>
        /// Gets faceId2 value
        /// </summary>
        /// <returns>
        /// faceId2: faceId of another face, comes from Face - Detect.
        /// </returns>
        public string GetFaceId2() =>
            (string)Reference.Invoke("getFaceId2");
        
        
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
        /// largePersonGroupId: Using existing largePersonGroupId and personId for fast adding a specified person. largePersonGroupId is created in LargePersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </returns>
        public string GetLargePersonGroupId() =>
            (string)Reference.Invoke("getLargePersonGroupId");
        
        
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
        /// personGroupId: Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in PersonGroup - Create. Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </returns>
        public string GetPersonGroupId() =>
            (string)Reference.Invoke("getPersonGroupId");
        
        
        /// <summary>
        /// Gets personId value
        /// </summary>
        /// <returns>
        /// personId: Specify a certain person in a person group or a large person group. personId is created in PersonGroup Person - Create or LargePersonGroup Person - Create.
        /// </returns>
        public string GetPersonId() =>
            (string)Reference.Invoke("getPersonId");
        
        
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
        /// Loads the <see cref="VerifyFaces"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VerifyFaces"/> was saved to</param>
        /// <returns>New <see cref="VerifyFaces"/> object, loaded from path.</returns>
        public static VerifyFaces Load(string path) => WrapAsVerifyFaces(
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
        /// <returns>an <see cref="JavaMLReader&lt;VerifyFaces&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<VerifyFaces> Read() =>
            new JavaMLReader<VerifyFaces>((JvmObjectReference)Reference.Invoke("read"));
        private static VerifyFaces WrapAsVerifyFaces(object obj) =>
            new VerifyFaces((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetLocation(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New VerifyFaces object </returns>
        public VerifyFaces SetLinkedService(string value) =>
            WrapAsVerifyFaces(Reference.Invoke("setLinkedService", value));
    }
}

        