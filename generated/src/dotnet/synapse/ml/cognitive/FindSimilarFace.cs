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
    /// <see cref="FindSimilarFace"/> implements FindSimilarFace
    /// </summary>
    public class FindSimilarFace : JavaTransformer, IJavaMLWritable, IJavaMLReadable<FindSimilarFace>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.FindSimilarFace";

        /// <summary>
        /// Creates a <see cref="FindSimilarFace"/> without any parameters.
        /// </summary>
        public FindSimilarFace() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="FindSimilarFace"/> with a UID that is used to give the
        /// <see cref="FindSimilarFace"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public FindSimilarFace(string uid) : base(s_className, uid)
        {
        }

        internal FindSimilarFace(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetConcurrency(int value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetConcurrentTimeout(double value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetErrorCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for faceId
        /// </summary>
        /// <param name="value">
        /// faceId of the query face. User needs to call FaceDetect first to get a valid faceId. Note that this faceId is not persisted and will expire 24 hours after the detection call.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetFaceId(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setFaceId", (object)value));
        
        
        /// <summary>
        /// Sets value for faceId column
        /// </summary>
        /// <param name="value">
        /// faceId of the query face. User needs to call FaceDetect first to get a valid faceId. Note that this faceId is not persisted and will expire 24 hours after the detection call.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetFaceIdCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setFaceIdCol", value));
        
        
        /// <summary>
        /// Sets value for faceIds
        /// </summary>
        /// <param name="value">
        ///  An array of candidate faceIds. All of them are created by FaceDetect and the faceIds will expire 24 hours after the detection call. The number of faceIds is limited to 1000. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetFaceIds(string[] value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setFaceIds", (object)value));
        
        
        /// <summary>
        /// Sets value for faceIds column
        /// </summary>
        /// <param name="value">
        ///  An array of candidate faceIds. All of them are created by FaceDetect and the faceIds will expire 24 hours after the detection call. The number of faceIds is limited to 1000. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetFaceIdsCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setFaceIdsCol", value));
        
        
        /// <summary>
        /// Sets value for faceListId
        /// </summary>
        /// <param name="value">
        ///  An existing user-specified unique candidate face list, created in FaceList - Create. Face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetFaceListId(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setFaceListId", (object)value));
        
        
        /// <summary>
        /// Sets value for faceListId column
        /// </summary>
        /// <param name="value">
        ///  An existing user-specified unique candidate face list, created in FaceList - Create. Face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetFaceListIdCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setFaceListIdCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetHandler(object value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for largeFaceListId
        /// </summary>
        /// <param name="value">
        ///  An existing user-specified unique candidate large face list, created in LargeFaceList - Create. Large face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetLargeFaceListId(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setLargeFaceListId", (object)value));
        
        
        /// <summary>
        /// Sets value for largeFaceListId column
        /// </summary>
        /// <param name="value">
        ///  An existing user-specified unique candidate large face list, created in LargeFaceList - Create. Large face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetLargeFaceListIdCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setLargeFaceListIdCol", value));
        
        
        /// <summary>
        /// Sets value for maxNumOfCandidatesReturned
        /// </summary>
        /// <param name="value">
        ///  Optional parameter. The number of top similar faces returned. The valid range is [1, 1000].It defaults to 20.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetMaxNumOfCandidatesReturned(int value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setMaxNumOfCandidatesReturned", (object)value));
        
        
        /// <summary>
        /// Sets value for maxNumOfCandidatesReturned column
        /// </summary>
        /// <param name="value">
        ///  Optional parameter. The number of top similar faces returned. The valid range is [1, 1000].It defaults to 20.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetMaxNumOfCandidatesReturnedCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setMaxNumOfCandidatesReturnedCol", value));
        
        
        /// <summary>
        /// Sets value for mode
        /// </summary>
        /// <param name="value">
        ///  Optional parameter. Similar face searching mode. It can be 'matchPerson' or 'matchFace'. It defaults to 'matchPerson'.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetMode(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setMode", (object)value));
        
        
        /// <summary>
        /// Sets value for mode column
        /// </summary>
        /// <param name="value">
        ///  Optional parameter. Similar face searching mode. It can be 'matchPerson' or 'matchFace'. It defaults to 'matchPerson'.
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetModeCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setModeCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetOutputCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetSubscriptionKey(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetSubscriptionKeyCol(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetTimeout(double value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetUrl(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setUrl", (object)value));
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
        /// faceId: faceId of the query face. User needs to call FaceDetect first to get a valid faceId. Note that this faceId is not persisted and will expire 24 hours after the detection call.
        /// </returns>
        public string GetFaceId() =>
            (string)Reference.Invoke("getFaceId");
        
        
        /// <summary>
        /// Gets faceIds value
        /// </summary>
        /// <returns>
        /// faceIds:  An array of candidate faceIds. All of them are created by FaceDetect and the faceIds will expire 24 hours after the detection call. The number of faceIds is limited to 1000. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </returns>
        public string[] GetFaceIds() =>
            (string[])Reference.Invoke("getFaceIds");
        
        
        /// <summary>
        /// Gets faceListId value
        /// </summary>
        /// <returns>
        /// faceListId:  An existing user-specified unique candidate face list, created in FaceList - Create. Face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </returns>
        public string GetFaceListId() =>
            (string)Reference.Invoke("getFaceListId");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets largeFaceListId value
        /// </summary>
        /// <returns>
        /// largeFaceListId:  An existing user-specified unique candidate large face list, created in LargeFaceList - Create. Large face list contains a set of persistedFaceIds which are persisted and will never expire. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.
        /// </returns>
        public string GetLargeFaceListId() =>
            (string)Reference.Invoke("getLargeFaceListId");
        
        
        /// <summary>
        /// Gets maxNumOfCandidatesReturned value
        /// </summary>
        /// <returns>
        /// maxNumOfCandidatesReturned:  Optional parameter. The number of top similar faces returned. The valid range is [1, 1000].It defaults to 20.
        /// </returns>
        public int GetMaxNumOfCandidatesReturned() =>
            (int)Reference.Invoke("getMaxNumOfCandidatesReturned");
        
        
        /// <summary>
        /// Gets mode value
        /// </summary>
        /// <returns>
        /// mode:  Optional parameter. Similar face searching mode. It can be 'matchPerson' or 'matchFace'. It defaults to 'matchPerson'.
        /// </returns>
        public string GetMode() =>
            (string)Reference.Invoke("getMode");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
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
        /// Loads the <see cref="FindSimilarFace"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="FindSimilarFace"/> was saved to</param>
        /// <returns>New <see cref="FindSimilarFace"/> object, loaded from path.</returns>
        public static FindSimilarFace Load(string path) => WrapAsFindSimilarFace(
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
        /// <returns>an <see cref="JavaMLReader&lt;FindSimilarFace&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<FindSimilarFace> Read() =>
            new JavaMLReader<FindSimilarFace>((JvmObjectReference)Reference.Invoke("read"));
        private static FindSimilarFace WrapAsFindSimilarFace(object obj) =>
            new FindSimilarFace((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetLocation(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New FindSimilarFace object </returns>
        public FindSimilarFace SetLinkedService(string value) =>
            WrapAsFindSimilarFace(Reference.Invoke("setLinkedService", value));
    }
}

        