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


namespace Synapse.ML.Geospatial
{
    /// <summary>
    /// <see cref="CheckPointInPolygon"/> implements CheckPointInPolygon
    /// </summary>
    public class CheckPointInPolygon : JavaTransformer, IJavaMLWritable, IJavaMLReadable<CheckPointInPolygon>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.geospatial.CheckPointInPolygon";

        /// <summary>
        /// Creates a <see cref="CheckPointInPolygon"/> without any parameters.
        /// </summary>
        public CheckPointInPolygon() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="CheckPointInPolygon"/> with a UID that is used to give the
        /// <see cref="CheckPointInPolygon"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public CheckPointInPolygon(string uid) : base(s_className, uid)
        {
        }

        internal CheckPointInPolygon(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetConcurrency(int value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetConcurrentTimeout(double value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetErrorCol(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetHandler(object value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for latitude
        /// </summary>
        /// <param name="value">
        /// the latitude of location
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetLatitude(double[] value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setLatitude", (object)value));
        
        
        /// <summary>
        /// Sets value for latitude column
        /// </summary>
        /// <param name="value">
        /// the latitude of location
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetLatitudeCol(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setLatitudeCol", value));
        
        
        /// <summary>
        /// Sets value for longitude
        /// </summary>
        /// <param name="value">
        /// the longitude of location
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetLongitude(double[] value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setLongitude", (object)value));
        
        
        /// <summary>
        /// Sets value for longitude column
        /// </summary>
        /// <param name="value">
        /// the longitude of location
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetLongitudeCol(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setLongitudeCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetOutputCol(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetSubscriptionKey(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetSubscriptionKeyCol(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetTimeout(double value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetUrl(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setUrl", (object)value));
        
        /// <summary>
        /// Sets value for userDataIdentifier
        /// </summary>
        /// <param name="value">
        /// the identifier for the user uploaded data
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetUserDataIdentifier(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setUserDataIdentifier", (object)value));
        
        
        /// <summary>
        /// Sets value for userDataIdentifier column
        /// </summary>
        /// <param name="value">
        /// the identifier for the user uploaded data
        /// </param>
        /// <returns> New CheckPointInPolygon object </returns>
        public CheckPointInPolygon SetUserDataIdentifierCol(string value) =>
            WrapAsCheckPointInPolygon(Reference.Invoke("setUserDataIdentifierCol", value));
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
        /// Gets latitude value
        /// </summary>
        /// <returns>
        /// latitude: the latitude of location
        /// </returns>
        public double[] GetLatitude() =>
            (double[])Reference.Invoke("getLatitude");
        
        
        /// <summary>
        /// Gets longitude value
        /// </summary>
        /// <returns>
        /// longitude: the longitude of location
        /// </returns>
        public double[] GetLongitude() =>
            (double[])Reference.Invoke("getLongitude");
        
        
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
        /// Gets userDataIdentifier value
        /// </summary>
        /// <returns>
        /// userDataIdentifier: the identifier for the user uploaded data
        /// </returns>
        public string GetUserDataIdentifier() =>
            (string)Reference.Invoke("getUserDataIdentifier");
        
        /// <summary>
        /// Loads the <see cref="CheckPointInPolygon"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="CheckPointInPolygon"/> was saved to</param>
        /// <returns>New <see cref="CheckPointInPolygon"/> object, loaded from path.</returns>
        public static CheckPointInPolygon Load(string path) => WrapAsCheckPointInPolygon(
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
        /// <returns>an <see cref="JavaMLReader&lt;CheckPointInPolygon&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<CheckPointInPolygon> Read() =>
            new JavaMLReader<CheckPointInPolygon>((JvmObjectReference)Reference.Invoke("read"));
        private static CheckPointInPolygon WrapAsCheckPointInPolygon(object obj) =>
            new CheckPointInPolygon((JvmObjectReference)obj);
        
    }
}

        