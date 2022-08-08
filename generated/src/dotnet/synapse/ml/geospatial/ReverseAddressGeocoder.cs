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
    /// <see cref="ReverseAddressGeocoder"/> implements ReverseAddressGeocoder
    /// </summary>
    public class ReverseAddressGeocoder : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ReverseAddressGeocoder>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.geospatial.ReverseAddressGeocoder";

        /// <summary>
        /// Creates a <see cref="ReverseAddressGeocoder"/> without any parameters.
        /// </summary>
        public ReverseAddressGeocoder() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ReverseAddressGeocoder"/> with a UID that is used to give the
        /// <see cref="ReverseAddressGeocoder"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ReverseAddressGeocoder(string uid) : base(s_className, uid)
        {
        }

        internal ReverseAddressGeocoder(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for backoffs
        /// </summary>
        /// <param name="value">
        /// array of backoffs to use in the handler
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetBackoffs(int[] value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setBackoffs", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetConcurrency(int value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetConcurrentTimeout(double value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetErrorCol(string value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for initialPollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait before first poll for result
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetInitialPollingDelay(int value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setInitialPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for latitude
        /// </summary>
        /// <param name="value">
        /// the latitude of location
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetLatitude(double[] value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setLatitude", (object)value));
        
        
        /// <summary>
        /// Sets value for latitude column
        /// </summary>
        /// <param name="value">
        /// the latitude of location
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetLatitudeCol(string value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setLatitudeCol", value));
        
        
        /// <summary>
        /// Sets value for longitude
        /// </summary>
        /// <param name="value">
        /// the longitude of location
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetLongitude(double[] value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setLongitude", (object)value));
        
        
        /// <summary>
        /// Sets value for longitude column
        /// </summary>
        /// <param name="value">
        /// the longitude of location
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetLongitudeCol(string value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setLongitudeCol", value));
        
        
        /// <summary>
        /// Sets value for maxPollingRetries
        /// </summary>
        /// <param name="value">
        /// number of times to poll
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetMaxPollingRetries(int value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setMaxPollingRetries", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetOutputCol(string value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for pollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait between polling
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetPollingDelay(int value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetSubscriptionKey(string value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetSubscriptionKeyCol(string value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for suppressMaxRetriesExceededException
        /// </summary>
        /// <param name="value">
        /// set true to suppress the maxumimum retries exception and report in the error column
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetSuppressMaxRetriesExceededException(bool value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setSuppressMaxRetriesExceededException", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetTimeout(double value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New ReverseAddressGeocoder object </returns>
        public ReverseAddressGeocoder SetUrl(string value) =>
            WrapAsReverseAddressGeocoder(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets backoffs value
        /// </summary>
        /// <returns>
        /// backoffs: array of backoffs to use in the handler
        /// </returns>
        public int[] GetBackoffs() =>
            (int[])Reference.Invoke("getBackoffs");
        
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
        /// Gets initialPollingDelay value
        /// </summary>
        /// <returns>
        /// initialPollingDelay: number of milliseconds to wait before first poll for result
        /// </returns>
        public int GetInitialPollingDelay() =>
            (int)Reference.Invoke("getInitialPollingDelay");
        
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
        /// Gets maxPollingRetries value
        /// </summary>
        /// <returns>
        /// maxPollingRetries: number of times to poll
        /// </returns>
        public int GetMaxPollingRetries() =>
            (int)Reference.Invoke("getMaxPollingRetries");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets pollingDelay value
        /// </summary>
        /// <returns>
        /// pollingDelay: number of milliseconds to wait between polling
        /// </returns>
        public int GetPollingDelay() =>
            (int)Reference.Invoke("getPollingDelay");
        
        /// <summary>
        /// Gets subscriptionKey value
        /// </summary>
        /// <returns>
        /// subscriptionKey: the API key to use
        /// </returns>
        public string GetSubscriptionKey() =>
            (string)Reference.Invoke("getSubscriptionKey");
        
        
        /// <summary>
        /// Gets suppressMaxRetriesExceededException value
        /// </summary>
        /// <returns>
        /// suppressMaxRetriesExceededException: set true to suppress the maxumimum retries exception and report in the error column
        /// </returns>
        public bool GetSuppressMaxRetriesExceededException() =>
            (bool)Reference.Invoke("getSuppressMaxRetriesExceededException");
        
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
        /// Loads the <see cref="ReverseAddressGeocoder"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ReverseAddressGeocoder"/> was saved to</param>
        /// <returns>New <see cref="ReverseAddressGeocoder"/> object, loaded from path.</returns>
        public static ReverseAddressGeocoder Load(string path) => WrapAsReverseAddressGeocoder(
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
        /// <returns>an <see cref="JavaMLReader&lt;ReverseAddressGeocoder&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ReverseAddressGeocoder> Read() =>
            new JavaMLReader<ReverseAddressGeocoder>((JvmObjectReference)Reference.Invoke("read"));
        private static ReverseAddressGeocoder WrapAsReverseAddressGeocoder(object obj) =>
            new ReverseAddressGeocoder((JvmObjectReference)obj);
        
    }
}

        