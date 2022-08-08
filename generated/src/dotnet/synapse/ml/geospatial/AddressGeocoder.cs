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
    /// <see cref="AddressGeocoder"/> implements AddressGeocoder
    /// </summary>
    public class AddressGeocoder : JavaTransformer, IJavaMLWritable, IJavaMLReadable<AddressGeocoder>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.geospatial.AddressGeocoder";

        /// <summary>
        /// Creates a <see cref="AddressGeocoder"/> without any parameters.
        /// </summary>
        public AddressGeocoder() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="AddressGeocoder"/> with a UID that is used to give the
        /// <see cref="AddressGeocoder"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public AddressGeocoder(string uid) : base(s_className, uid)
        {
        }

        internal AddressGeocoder(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for address
        /// </summary>
        /// <param name="value">
        /// the address to geocode
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetAddress(string[] value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setAddress", (object)value));
        
        
        /// <summary>
        /// Sets value for address column
        /// </summary>
        /// <param name="value">
        /// the address to geocode
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetAddressCol(string value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setAddressCol", value));
        
        
        /// <summary>
        /// Sets value for backoffs
        /// </summary>
        /// <param name="value">
        /// array of backoffs to use in the handler
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetBackoffs(int[] value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setBackoffs", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetConcurrency(int value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetConcurrentTimeout(double value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetErrorCol(string value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for initialPollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait before first poll for result
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetInitialPollingDelay(int value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setInitialPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for maxPollingRetries
        /// </summary>
        /// <param name="value">
        /// number of times to poll
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetMaxPollingRetries(int value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setMaxPollingRetries", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetOutputCol(string value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for pollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait between polling
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetPollingDelay(int value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetSubscriptionKey(string value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetSubscriptionKeyCol(string value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for suppressMaxRetriesExceededException
        /// </summary>
        /// <param name="value">
        /// set true to suppress the maxumimum retries exception and report in the error column
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetSuppressMaxRetriesExceededException(bool value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setSuppressMaxRetriesExceededException", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetTimeout(double value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New AddressGeocoder object </returns>
        public AddressGeocoder SetUrl(string value) =>
            WrapAsAddressGeocoder(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets address value
        /// </summary>
        /// <returns>
        /// address: the address to geocode
        /// </returns>
        public string[] GetAddress() =>
            (string[])Reference.Invoke("getAddress");
        
        
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
        /// Loads the <see cref="AddressGeocoder"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="AddressGeocoder"/> was saved to</param>
        /// <returns>New <see cref="AddressGeocoder"/> object, loaded from path.</returns>
        public static AddressGeocoder Load(string path) => WrapAsAddressGeocoder(
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
        /// <returns>an <see cref="JavaMLReader&lt;AddressGeocoder&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<AddressGeocoder> Read() =>
            new JavaMLReader<AddressGeocoder>((JvmObjectReference)Reference.Invoke("read"));
        private static AddressGeocoder WrapAsAddressGeocoder(object obj) =>
            new AddressGeocoder((JvmObjectReference)obj);
        
    }
}

        