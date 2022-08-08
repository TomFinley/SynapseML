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
    /// <see cref="AnalyzeIDDocuments"/> implements AnalyzeIDDocuments
    /// </summary>
    public class AnalyzeIDDocuments : JavaTransformer, IJavaMLWritable, IJavaMLReadable<AnalyzeIDDocuments>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.AnalyzeIDDocuments";

        /// <summary>
        /// Creates a <see cref="AnalyzeIDDocuments"/> without any parameters.
        /// </summary>
        public AnalyzeIDDocuments() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="AnalyzeIDDocuments"/> with a UID that is used to give the
        /// <see cref="AnalyzeIDDocuments"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public AnalyzeIDDocuments(string uid) : base(s_className, uid)
        {
        }

        internal AnalyzeIDDocuments(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for backoffs
        /// </summary>
        /// <param name="value">
        /// array of backoffs to use in the handler
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetBackoffs(int[] value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setBackoffs", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetConcurrency(int value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetConcurrentTimeout(double value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetErrorCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for imageBytes
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetImageBytes(byte[] value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setImageBytes", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes column
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetImageBytesCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setImageBytesCol", value));
        
        
        /// <summary>
        /// Sets value for imageUrl
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetImageUrl(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setImageUrl", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl column
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetImageUrlCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setImageUrlCol", value));
        
        
        /// <summary>
        /// Sets value for includeTextDetails
        /// </summary>
        /// <param name="value">
        /// Include text lines and element references in the result.
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetIncludeTextDetails(bool value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setIncludeTextDetails", (object)value));
        
        
        /// <summary>
        /// Sets value for includeTextDetails column
        /// </summary>
        /// <param name="value">
        /// Include text lines and element references in the result.
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetIncludeTextDetailsCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setIncludeTextDetailsCol", value));
        
        
        /// <summary>
        /// Sets value for initialPollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait before first poll for result
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetInitialPollingDelay(int value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setInitialPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for maxPollingRetries
        /// </summary>
        /// <param name="value">
        /// number of times to poll
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetMaxPollingRetries(int value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setMaxPollingRetries", (object)value));
        
        /// <summary>
        /// Sets value for modelVersion
        /// </summary>
        /// <param name="value">
        /// This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetModelVersion(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setModelVersion", (object)value));
        
        
        /// <summary>
        /// Sets value for modelVersion column
        /// </summary>
        /// <param name="value">
        /// This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version.
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetModelVersionCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setModelVersionCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetOutputCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for pages
        /// </summary>
        /// <param name="value">
        /// The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetPages(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setPages", (object)value));
        
        
        /// <summary>
        /// Sets value for pages column
        /// </summary>
        /// <param name="value">
        /// The page selection only leveraged for multi-page PDF and TIFF documents. Accepted input include single pages (e.g.'1, 2' -> pages 1 and 2 will be processed), finite (e.g. '2-5' -> pages 2 to 5 will be processed) and open-ended ranges (e.g. '5-' -> all the pages from page 5 will be processed; e.g. '-10' -> pages 1 to 10 will be processed). All of these can be mixed together and ranges are allowed to overlap (eg. '-5, 1, 3, 5-10' - pages 1 to 10 will be processed). The service will accept the request if it can process at least one page of the document (e.g. using '5-100' on a 5 page document is a valid input where page 5 will be processed). If no page range is provided, the entire document will be processed.
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetPagesCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setPagesCol", value));
        
        
        /// <summary>
        /// Sets value for pollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait between polling
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetPollingDelay(int value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetSubscriptionKey(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetSubscriptionKeyCol(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for suppressMaxRetriesExceededException
        /// </summary>
        /// <param name="value">
        /// set true to suppress the maxumimum retries exception and report in the error column
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetSuppressMaxRetriesExceededException(bool value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setSuppressMaxRetriesExceededException", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetTimeout(double value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetUrl(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setUrl", (object)value));
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
        /// Loads the <see cref="AnalyzeIDDocuments"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="AnalyzeIDDocuments"/> was saved to</param>
        /// <returns>New <see cref="AnalyzeIDDocuments"/> object, loaded from path.</returns>
        public static AnalyzeIDDocuments Load(string path) => WrapAsAnalyzeIDDocuments(
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
        /// <returns>an <see cref="JavaMLReader&lt;AnalyzeIDDocuments&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<AnalyzeIDDocuments> Read() =>
            new JavaMLReader<AnalyzeIDDocuments>((JvmObjectReference)Reference.Invoke("read"));
        private static AnalyzeIDDocuments WrapAsAnalyzeIDDocuments(object obj) =>
            new AnalyzeIDDocuments((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetLocation(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New AnalyzeIDDocuments object </returns>
        public AnalyzeIDDocuments SetLinkedService(string value) =>
            WrapAsAnalyzeIDDocuments(Reference.Invoke("setLinkedService", value));
    }
}

        