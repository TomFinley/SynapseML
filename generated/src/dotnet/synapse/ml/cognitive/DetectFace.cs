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
    /// <see cref="DetectFace"/> implements DetectFace
    /// </summary>
    public class DetectFace : JavaTransformer, IJavaMLWritable, IJavaMLReadable<DetectFace>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.DetectFace";

        /// <summary>
        /// Creates a <see cref="DetectFace"/> without any parameters.
        /// </summary>
        public DetectFace() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="DetectFace"/> with a UID that is used to give the
        /// <see cref="DetectFace"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public DetectFace(string uid) : base(s_className, uid)
        {
        }

        internal DetectFace(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetConcurrency(int value) =>
            WrapAsDetectFace(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetConcurrentTimeout(double value) =>
            WrapAsDetectFace(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetErrorCol(string value) =>
            WrapAsDetectFace(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetHandler(object value) =>
            WrapAsDetectFace(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetImageUrl(string value) =>
            WrapAsDetectFace(Reference.Invoke("setImageUrl", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl column
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetImageUrlCol(string value) =>
            WrapAsDetectFace(Reference.Invoke("setImageUrlCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetOutputCol(string value) =>
            WrapAsDetectFace(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for returnFaceAttributes
        /// </summary>
        /// <param name="value">
        /// Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetReturnFaceAttributes(string[] value) =>
            WrapAsDetectFace(Reference.Invoke("setReturnFaceAttributes", (object)value));
        
        
        /// <summary>
        /// Sets value for returnFaceAttributes column
        /// </summary>
        /// <param name="value">
        /// Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetReturnFaceAttributesCol(string value) =>
            WrapAsDetectFace(Reference.Invoke("setReturnFaceAttributesCol", value));
        
        
        /// <summary>
        /// Sets value for returnFaceId
        /// </summary>
        /// <param name="value">
        /// Return faceIds of the detected faces or not. The default value is true
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetReturnFaceId(bool value) =>
            WrapAsDetectFace(Reference.Invoke("setReturnFaceId", (object)value));
        
        
        /// <summary>
        /// Sets value for returnFaceId column
        /// </summary>
        /// <param name="value">
        /// Return faceIds of the detected faces or not. The default value is true
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetReturnFaceIdCol(string value) =>
            WrapAsDetectFace(Reference.Invoke("setReturnFaceIdCol", value));
        
        
        /// <summary>
        /// Sets value for returnFaceLandmarks
        /// </summary>
        /// <param name="value">
        /// Return face landmarks of the detected faces or not. The default value is false.
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetReturnFaceLandmarks(bool value) =>
            WrapAsDetectFace(Reference.Invoke("setReturnFaceLandmarks", (object)value));
        
        
        /// <summary>
        /// Sets value for returnFaceLandmarks column
        /// </summary>
        /// <param name="value">
        /// Return face landmarks of the detected faces or not. The default value is false.
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetReturnFaceLandmarksCol(string value) =>
            WrapAsDetectFace(Reference.Invoke("setReturnFaceLandmarksCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetSubscriptionKey(string value) =>
            WrapAsDetectFace(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetSubscriptionKeyCol(string value) =>
            WrapAsDetectFace(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetTimeout(double value) =>
            WrapAsDetectFace(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetUrl(string value) =>
            WrapAsDetectFace(Reference.Invoke("setUrl", (object)value));
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
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets imageUrl value
        /// </summary>
        /// <returns>
        /// imageUrl: the url of the image to use
        /// </returns>
        public string GetImageUrl() =>
            (string)Reference.Invoke("getImageUrl");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets returnFaceAttributes value
        /// </summary>
        /// <returns>
        /// returnFaceAttributes: Analyze and return the one or more specified face attributes Supported face attributes include: age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.
        /// </returns>
        public string[] GetReturnFaceAttributes() =>
            (string[])Reference.Invoke("getReturnFaceAttributes");
        
        
        /// <summary>
        /// Gets returnFaceId value
        /// </summary>
        /// <returns>
        /// returnFaceId: Return faceIds of the detected faces or not. The default value is true
        /// </returns>
        public bool GetReturnFaceId() =>
            (bool)Reference.Invoke("getReturnFaceId");
        
        
        /// <summary>
        /// Gets returnFaceLandmarks value
        /// </summary>
        /// <returns>
        /// returnFaceLandmarks: Return face landmarks of the detected faces or not. The default value is false.
        /// </returns>
        public bool GetReturnFaceLandmarks() =>
            (bool)Reference.Invoke("getReturnFaceLandmarks");
        
        
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
        /// Loads the <see cref="DetectFace"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="DetectFace"/> was saved to</param>
        /// <returns>New <see cref="DetectFace"/> object, loaded from path.</returns>
        public static DetectFace Load(string path) => WrapAsDetectFace(
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
        /// <returns>an <see cref="JavaMLReader&lt;DetectFace&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<DetectFace> Read() =>
            new JavaMLReader<DetectFace>((JvmObjectReference)Reference.Invoke("read"));
        private static DetectFace WrapAsDetectFace(object obj) =>
            new DetectFace((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetLocation(string value) =>
            WrapAsDetectFace(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New DetectFace object </returns>
        public DetectFace SetLinkedService(string value) =>
            WrapAsDetectFace(Reference.Invoke("setLinkedService", value));
    }
}

        