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
    /// <see cref="AnalyzeInvoices"/> implements AnalyzeInvoices
    /// </summary>
    public class AnalyzeInvoices : JavaTransformer, IJavaMLWritable, IJavaMLReadable<AnalyzeInvoices>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.AnalyzeInvoices";

        /// <summary>
        /// Creates a <see cref="AnalyzeInvoices"/> without any parameters.
        /// </summary>
        public AnalyzeInvoices() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="AnalyzeInvoices"/> with a UID that is used to give the
        /// <see cref="AnalyzeInvoices"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public AnalyzeInvoices(string uid) : base(s_className, uid)
        {
        }

        internal AnalyzeInvoices(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for backoffs
        /// </summary>
        /// <param name="value">
        /// array of backoffs to use in the handler
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetBackoffs(int[] value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setBackoffs", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetConcurrency(int value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetConcurrentTimeout(double value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetErrorCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for imageBytes
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetImageBytes(byte[] value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setImageBytes", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes column
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetImageBytesCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setImageBytesCol", value));
        
        
        /// <summary>
        /// Sets value for imageUrl
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetImageUrl(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setImageUrl", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl column
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetImageUrlCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setImageUrlCol", value));
        
        
        /// <summary>
        /// Sets value for includeTextDetails
        /// </summary>
        /// <param name="value">
        /// Include text lines and element references in the result.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetIncludeTextDetails(bool value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setIncludeTextDetails", (object)value));
        
        
        /// <summary>
        /// Sets value for includeTextDetails column
        /// </summary>
        /// <param name="value">
        /// Include text lines and element references in the result.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetIncludeTextDetailsCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setIncludeTextDetailsCol", value));
        
        
        /// <summary>
        /// Sets value for initialPollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait before first poll for result
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetInitialPollingDelay(int value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setInitialPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for locale
        /// </summary>
        /// <param name="value">
        /// Locale of the receipt. Supported locales: en-AU, en-CA, en-GB, en-IN, en-US.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetLocale(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setLocale", (object)value));
        
        
        /// <summary>
        /// Sets value for locale column
        /// </summary>
        /// <param name="value">
        /// Locale of the receipt. Supported locales: en-AU, en-CA, en-GB, en-IN, en-US.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetLocaleCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setLocaleCol", value));
        
        
        /// <summary>
        /// Sets value for maxPollingRetries
        /// </summary>
        /// <param name="value">
        /// number of times to poll
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetMaxPollingRetries(int value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setMaxPollingRetries", (object)value));
        
        /// <summary>
        /// Sets value for modelVersion
        /// </summary>
        /// <param name="value">
        /// This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetModelVersion(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setModelVersion", (object)value));
        
        
        /// <summary>
        /// Sets value for modelVersion column
        /// </summary>
        /// <param name="value">
        /// This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetModelVersionCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setModelVersionCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetOutputCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for pages
        /// </summary>
        /// <param name="value">
        /// The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetPages(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setPages", (object)value));
        
        
        /// <summary>
        /// Sets value for pages column
        /// </summary>
        /// <param name="value">
        /// The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetPagesCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setPagesCol", value));
        
        
        /// <summary>
        /// Sets value for pollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait between polling
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetPollingDelay(int value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetSubscriptionKey(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetSubscriptionKeyCol(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for suppressMaxRetriesExceededException
        /// </summary>
        /// <param name="value">
        /// set true to suppress the maxumimum retries exception and report in the error column
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetSuppressMaxRetriesExceededException(bool value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setSuppressMaxRetriesExceededException", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetTimeout(double value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetUrl(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setUrl", (object)value));
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
        /// Gets imageBytes value
        /// </summary>
        /// <returns>
        /// imageBytes: bytestream of the image to use
        /// </returns>
        public byte[] GetImageBytes() =>
            (byte[])Reference.Invoke("getImageBytes");
        
        
        /// <summary>
        /// Gets imageUrl value
        /// </summary>
        /// <returns>
        /// imageUrl: the url of the image to use
        /// </returns>
        public string GetImageUrl() =>
            (string)Reference.Invoke("getImageUrl");
        
        
        /// <summary>
        /// Gets includeTextDetails value
        /// </summary>
        /// <returns>
        /// includeTextDetails: Include text lines and element references in the result.
        /// </returns>
        public bool GetIncludeTextDetails() =>
            (bool)Reference.Invoke("getIncludeTextDetails");
        
        
        /// <summary>
        /// Gets initialPollingDelay value
        /// </summary>
        /// <returns>
        /// initialPollingDelay: number of milliseconds to wait before first poll for result
        /// </returns>
        public int GetInitialPollingDelay() =>
            (int)Reference.Invoke("getInitialPollingDelay");
        
        /// <summary>
        /// Gets locale value
        /// </summary>
        /// <returns>
        /// locale: Locale of the receipt. Supported locales: en-AU, en-CA, en-GB, en-IN, en-US.
        /// </returns>
        public string GetLocale() =>
            (string)Reference.Invoke("getLocale");
        
        
        /// <summary>
        /// Gets maxPollingRetries value
        /// </summary>
        /// <returns>
        /// maxPollingRetries: number of times to poll
        /// </returns>
        public int GetMaxPollingRetries() =>
            (int)Reference.Invoke("getMaxPollingRetries");
        
        /// <summary>
        /// Gets modelVersion value
        /// </summary>
        /// <returns>
        /// modelVersion: This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        /// </returns>
        public string GetModelVersion() =>
            (string)Reference.Invoke("getModelVersion");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets pages value
        /// </summary>
        /// <returns>
        /// pages: The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        /// </returns>
        public string GetPages() =>
            (string)Reference.Invoke("getPages");
        
        
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
        /// Loads the <see cref="AnalyzeInvoices"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="AnalyzeInvoices"/> was saved to</param>
        /// <returns>New <see cref="AnalyzeInvoices"/> object, loaded from path.</returns>
        public static AnalyzeInvoices Load(string path) => WrapAsAnalyzeInvoices(
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
        /// <returns>an <see cref="JavaMLReader&lt;AnalyzeInvoices&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<AnalyzeInvoices> Read() =>
            new JavaMLReader<AnalyzeInvoices>((JvmObjectReference)Reference.Invoke("read"));
        private static AnalyzeInvoices WrapAsAnalyzeInvoices(object obj) =>
            new AnalyzeInvoices((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetLocation(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New AnalyzeInvoices object </returns>
        public AnalyzeInvoices SetLinkedService(string value) =>
            WrapAsAnalyzeInvoices(Reference.Invoke("setLinkedService", value));
    }
}

        