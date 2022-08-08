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
    /// <see cref="ReadImage"/> implements ReadImage
    /// </summary>
    public class ReadImage : JavaTransformer, IJavaMLWritable, IJavaMLReadable<ReadImage>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.ReadImage";

        /// <summary>
        /// Creates a <see cref="ReadImage"/> without any parameters.
        /// </summary>
        public ReadImage() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="ReadImage"/> with a UID that is used to give the
        /// <see cref="ReadImage"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public ReadImage(string uid) : base(s_className, uid)
        {
        }

        internal ReadImage(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for backoffs
        /// </summary>
        /// <param name="value">
        /// array of backoffs to use in the handler
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetBackoffs(int[] value) =>
            WrapAsReadImage(Reference.Invoke("setBackoffs", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetConcurrency(int value) =>
            WrapAsReadImage(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetConcurrentTimeout(double value) =>
            WrapAsReadImage(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetErrorCol(string value) =>
            WrapAsReadImage(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for imageBytes
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetImageBytes(byte[] value) =>
            WrapAsReadImage(Reference.Invoke("setImageBytes", (object)value));
        
        
        /// <summary>
        /// Sets value for imageBytes column
        /// </summary>
        /// <param name="value">
        /// bytestream of the image to use
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetImageBytesCol(string value) =>
            WrapAsReadImage(Reference.Invoke("setImageBytesCol", value));
        
        
        /// <summary>
        /// Sets value for imageUrl
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetImageUrl(string value) =>
            WrapAsReadImage(Reference.Invoke("setImageUrl", (object)value));
        
        
        /// <summary>
        /// Sets value for imageUrl column
        /// </summary>
        /// <param name="value">
        /// the url of the image to use
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetImageUrlCol(string value) =>
            WrapAsReadImage(Reference.Invoke("setImageUrlCol", value));
        
        
        /// <summary>
        /// Sets value for initialPollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait before first poll for result
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetInitialPollingDelay(int value) =>
            WrapAsReadImage(Reference.Invoke("setInitialPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for language
        /// </summary>
        /// <param name="value">
        /// IThe BCP-47 language code of the text in the document. Currently, only English (en), Dutch (nl), French (fr), German (de), Italian (it), Portuguese (pt), and Spanish (es) are supported. Read supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetLanguage(string value) =>
            WrapAsReadImage(Reference.Invoke("setLanguage", (object)value));
        
        
        /// <summary>
        /// Sets value for language column
        /// </summary>
        /// <param name="value">
        /// IThe BCP-47 language code of the text in the document. Currently, only English (en), Dutch (nl), French (fr), German (de), Italian (it), Portuguese (pt), and Spanish (es) are supported. Read supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetLanguageCol(string value) =>
            WrapAsReadImage(Reference.Invoke("setLanguageCol", value));
        
        
        /// <summary>
        /// Sets value for maxPollingRetries
        /// </summary>
        /// <param name="value">
        /// number of times to poll
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetMaxPollingRetries(int value) =>
            WrapAsReadImage(Reference.Invoke("setMaxPollingRetries", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetOutputCol(string value) =>
            WrapAsReadImage(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for pollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait between polling
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetPollingDelay(int value) =>
            WrapAsReadImage(Reference.Invoke("setPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetSubscriptionKey(string value) =>
            WrapAsReadImage(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetSubscriptionKeyCol(string value) =>
            WrapAsReadImage(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for suppressMaxRetriesExceededException
        /// </summary>
        /// <param name="value">
        /// set true to suppress the maxumimum retries exception and report in the error column
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetSuppressMaxRetriesExceededException(bool value) =>
            WrapAsReadImage(Reference.Invoke("setSuppressMaxRetriesExceededException", (object)value));
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetTimeout(double value) =>
            WrapAsReadImage(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetUrl(string value) =>
            WrapAsReadImage(Reference.Invoke("setUrl", (object)value));
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
        /// Gets initialPollingDelay value
        /// </summary>
        /// <returns>
        /// initialPollingDelay: number of milliseconds to wait before first poll for result
        /// </returns>
        public int GetInitialPollingDelay() =>
            (int)Reference.Invoke("getInitialPollingDelay");
        
        /// <summary>
        /// Gets language value
        /// </summary>
        /// <returns>
        /// language: IThe BCP-47 language code of the text in the document. Currently, only English (en), Dutch (nl), French (fr), German (de), Italian (it), Portuguese (pt), and Spanish (es) are supported. Read supports auto language identification and multilanguage documents, so only provide a language code if you would like to force the documented to be processed as that specific language.
        /// </returns>
        public string GetLanguage() =>
            (string)Reference.Invoke("getLanguage");
        
        
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
        /// Loads the <see cref="ReadImage"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="ReadImage"/> was saved to</param>
        /// <returns>New <see cref="ReadImage"/> object, loaded from path.</returns>
        public static ReadImage Load(string path) => WrapAsReadImage(
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
        /// <returns>an <see cref="JavaMLReader&lt;ReadImage&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<ReadImage> Read() =>
            new JavaMLReader<ReadImage>((JvmObjectReference)Reference.Invoke("read"));
        private static ReadImage WrapAsReadImage(object obj) =>
            new ReadImage((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetLocation(string value) =>
            WrapAsReadImage(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New ReadImage object </returns>
        public ReadImage SetLinkedService(string value) =>
            WrapAsReadImage(Reference.Invoke("setLinkedService", value));
    }
}

        