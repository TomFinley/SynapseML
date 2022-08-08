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
using Synapse.ML.Cognitive;

namespace Synapse.ML.Cognitive
{
    /// <summary>
    /// <see cref="FitMultivariateAnomaly"/> implements FitMultivariateAnomaly
    /// </summary>
    public class FitMultivariateAnomaly : JavaEstimator<DetectMultivariateAnomaly>, IJavaMLWritable, IJavaMLReadable<FitMultivariateAnomaly>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.FitMultivariateAnomaly";

        /// <summary>
        /// Creates a <see cref="FitMultivariateAnomaly"/> without any parameters.
        /// </summary>
        public FitMultivariateAnomaly() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="FitMultivariateAnomaly"/> with a UID that is used to give the
        /// <see cref="FitMultivariateAnomaly"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public FitMultivariateAnomaly(string uid) : base(s_className, uid)
        {
        }

        internal FitMultivariateAnomaly(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for alignMode
        /// </summary>
        /// <param name="value">
        /// An optional field, indicates how we align different variables into the same time-range which is required by the model.{Inner, Outer}
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetAlignMode(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setAlignMode", (object)value));
        
        /// <summary>
        /// Sets value for backoffs
        /// </summary>
        /// <param name="value">
        /// array of backoffs to use in the handler
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetBackoffs(int[] value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setBackoffs", (object)value));
        
        /// <summary>
        /// Sets value for connectionString
        /// </summary>
        /// <param name="value">
        /// Connection String for your storage account used for uploading files.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetConnectionString(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setConnectionString", (object)value));
        
        /// <summary>
        /// Sets value for containerName
        /// </summary>
        /// <param name="value">
        /// Container that will be used to upload files to.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetContainerName(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setContainerName", (object)value));
        
        /// <summary>
        /// Sets value for diagnosticsInfo
        /// </summary>
        /// <param name="value">
        /// diagnosticsInfo for training a multivariate anomaly detection model
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetDiagnosticsInfo(object value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setDiagnosticsInfo", (object)value));
        
        
        /// <summary>
        /// Sets value for displayName
        /// </summary>
        /// <param name="value">
        /// optional field, name of the model
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetDisplayName(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setDisplayName", (object)value));
        
        /// <summary>
        /// Sets value for endTime
        /// </summary>
        /// <param name="value">
        /// A required field, end time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetEndTime(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setEndTime", (object)value));
        
        /// <summary>
        /// Sets value for endpoint
        /// </summary>
        /// <param name="value">
        /// End Point for your storage account used for uploading files.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetEndpoint(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setEndpoint", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetErrorCol(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for fillNAMethod
        /// </summary>
        /// <param name="value">
        /// An optional field, indicates how missed values will be filled with. Can not be set to NotFill, when alignMode is Outer.{Previous, Subsequent, Linear, Zero, Fixed}
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetFillNAMethod(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setFillNAMethod", (object)value));
        
        /// <summary>
        /// Sets value for initialPollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait before first poll for result
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetInitialPollingDelay(int value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setInitialPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for inputCols
        /// </summary>
        /// <param name="value">
        /// The names of the input columns
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetInputCols(string[] value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets value for intermediateSaveDir
        /// </summary>
        /// <param name="value">
        /// Directory name of which you want to save the intermediate data produced while training.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetIntermediateSaveDir(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setIntermediateSaveDir", (object)value));
        
        /// <summary>
        /// Sets value for maxPollingRetries
        /// </summary>
        /// <param name="value">
        /// number of times to poll
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetMaxPollingRetries(int value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setMaxPollingRetries", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetOutputCol(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for paddingValue
        /// </summary>
        /// <param name="value">
        /// optional field, is only useful if FillNAMethod is set to Fixed.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetPaddingValue(int value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setPaddingValue", (object)value));
        
        /// <summary>
        /// Sets value for pollingDelay
        /// </summary>
        /// <param name="value">
        /// number of milliseconds to wait between polling
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetPollingDelay(int value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setPollingDelay", (object)value));
        
        /// <summary>
        /// Sets value for sasToken
        /// </summary>
        /// <param name="value">
        /// SAS Token for your storage account used for uploading files.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetSasToken(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setSasToken", (object)value));
        
        /// <summary>
        /// Sets value for slidingWindow
        /// </summary>
        /// <param name="value">
        /// An optional field, indicates how many history points will be used to determine the anomaly score of one subsequent point.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetSlidingWindow(int value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setSlidingWindow", (object)value));
        
        /// <summary>
        /// Sets value for startTime
        /// </summary>
        /// <param name="value">
        /// A required field, start time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetStartTime(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setStartTime", (object)value));
        
        /// <summary>
        /// Sets value for storageKey
        /// </summary>
        /// <param name="value">
        /// Storage Key for your storage account used for uploading files.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetStorageKey(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setStorageKey", (object)value));
        
        /// <summary>
        /// Sets value for storageName
        /// </summary>
        /// <param name="value">
        /// Storage Name for your storage account used for uploading files.
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetStorageName(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setStorageName", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetSubscriptionKey(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetSubscriptionKeyCol(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for suppressMaxRetriesExceededException
        /// </summary>
        /// <param name="value">
        /// set true to suppress the maxumimum retries exception and report in the error column
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetSuppressMaxRetriesExceededException(bool value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setSuppressMaxRetriesExceededException", (object)value));
        
        /// <summary>
        /// Sets value for timestampCol
        /// </summary>
        /// <param name="value">
        /// Timestamp column name
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetTimestampCol(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setTimestampCol", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetUrl(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets alignMode value
        /// </summary>
        /// <returns>
        /// alignMode: An optional field, indicates how we align different variables into the same time-range which is required by the model.{Inner, Outer}
        /// </returns>
        public string GetAlignMode() =>
            (string)Reference.Invoke("getAlignMode");
        
        /// <summary>
        /// Gets backoffs value
        /// </summary>
        /// <returns>
        /// backoffs: array of backoffs to use in the handler
        /// </returns>
        public int[] GetBackoffs() =>
            (int[])Reference.Invoke("getBackoffs");
        
        /// <summary>
        /// Gets connectionString value
        /// </summary>
        /// <returns>
        /// connectionString: Connection String for your storage account used for uploading files.
        /// </returns>
        public string GetConnectionString() =>
            (string)Reference.Invoke("getConnectionString");
        
        /// <summary>
        /// Gets containerName value
        /// </summary>
        /// <returns>
        /// containerName: Container that will be used to upload files to.
        /// </returns>
        public string GetContainerName() =>
            (string)Reference.Invoke("getContainerName");
        
        /// <summary>
        /// Gets diagnosticsInfo value
        /// </summary>
        /// <returns>
        /// diagnosticsInfo: diagnosticsInfo for training a multivariate anomaly detection model
        /// </returns>
        public object GetDiagnosticsInfo() =>
            (object)Reference.Invoke("getDiagnosticsInfo");
        
        
        /// <summary>
        /// Gets displayName value
        /// </summary>
        /// <returns>
        /// displayName: optional field, name of the model
        /// </returns>
        public string GetDisplayName() =>
            (string)Reference.Invoke("getDisplayName");
        
        /// <summary>
        /// Gets endTime value
        /// </summary>
        /// <returns>
        /// endTime: A required field, end time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
        /// </returns>
        public string GetEndTime() =>
            (string)Reference.Invoke("getEndTime");
        
        /// <summary>
        /// Gets endpoint value
        /// </summary>
        /// <returns>
        /// endpoint: End Point for your storage account used for uploading files.
        /// </returns>
        public string GetEndpoint() =>
            (string)Reference.Invoke("getEndpoint");
        
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets fillNAMethod value
        /// </summary>
        /// <returns>
        /// fillNAMethod: An optional field, indicates how missed values will be filled with. Can not be set to NotFill, when alignMode is Outer.{Previous, Subsequent, Linear, Zero, Fixed}
        /// </returns>
        public string GetFillNAMethod() =>
            (string)Reference.Invoke("getFillNAMethod");
        
        /// <summary>
        /// Gets initialPollingDelay value
        /// </summary>
        /// <returns>
        /// initialPollingDelay: number of milliseconds to wait before first poll for result
        /// </returns>
        public int GetInitialPollingDelay() =>
            (int)Reference.Invoke("getInitialPollingDelay");
        
        /// <summary>
        /// Gets inputCols value
        /// </summary>
        /// <returns>
        /// inputCols: The names of the input columns
        /// </returns>
        public string[] GetInputCols() =>
            (string[])Reference.Invoke("getInputCols");
        
        /// <summary>
        /// Gets intermediateSaveDir value
        /// </summary>
        /// <returns>
        /// intermediateSaveDir: Directory name of which you want to save the intermediate data produced while training.
        /// </returns>
        public string GetIntermediateSaveDir() =>
            (string)Reference.Invoke("getIntermediateSaveDir");
        
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
        /// Gets paddingValue value
        /// </summary>
        /// <returns>
        /// paddingValue: optional field, is only useful if FillNAMethod is set to Fixed.
        /// </returns>
        public int GetPaddingValue() =>
            (int)Reference.Invoke("getPaddingValue");
        
        /// <summary>
        /// Gets pollingDelay value
        /// </summary>
        /// <returns>
        /// pollingDelay: number of milliseconds to wait between polling
        /// </returns>
        public int GetPollingDelay() =>
            (int)Reference.Invoke("getPollingDelay");
        
        /// <summary>
        /// Gets sasToken value
        /// </summary>
        /// <returns>
        /// sasToken: SAS Token for your storage account used for uploading files.
        /// </returns>
        public string GetSasToken() =>
            (string)Reference.Invoke("getSasToken");
        
        /// <summary>
        /// Gets slidingWindow value
        /// </summary>
        /// <returns>
        /// slidingWindow: An optional field, indicates how many history points will be used to determine the anomaly score of one subsequent point.
        /// </returns>
        public int GetSlidingWindow() =>
            (int)Reference.Invoke("getSlidingWindow");
        
        /// <summary>
        /// Gets startTime value
        /// </summary>
        /// <returns>
        /// startTime: A required field, start time of data to be used for detection/generating multivariate anomaly detection model, should be date-time.
        /// </returns>
        public string GetStartTime() =>
            (string)Reference.Invoke("getStartTime");
        
        /// <summary>
        /// Gets storageKey value
        /// </summary>
        /// <returns>
        /// storageKey: Storage Key for your storage account used for uploading files.
        /// </returns>
        public string GetStorageKey() =>
            (string)Reference.Invoke("getStorageKey");
        
        /// <summary>
        /// Gets storageName value
        /// </summary>
        /// <returns>
        /// storageName: Storage Name for your storage account used for uploading files.
        /// </returns>
        public string GetStorageName() =>
            (string)Reference.Invoke("getStorageName");
        
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
        /// Gets timestampCol value
        /// </summary>
        /// <returns>
        /// timestampCol: Timestamp column name
        /// </returns>
        public string GetTimestampCol() =>
            (string)Reference.Invoke("getTimestampCol");
        
        /// <summary>
        /// Gets url value
        /// </summary>
        /// <returns>
        /// url: Url of the service
        /// </returns>
        public string GetUrl() =>
            (string)Reference.Invoke("getUrl");
        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="DetectMultivariateAnomaly"/></returns>
        override public DetectMultivariateAnomaly Fit(DataFrame dataset) =>
            new DetectMultivariateAnomaly(
                (JvmObjectReference)Reference.Invoke("fit", dataset));
        /// <summary>
        /// Loads the <see cref="FitMultivariateAnomaly"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="FitMultivariateAnomaly"/> was saved to</param>
        /// <returns>New <see cref="FitMultivariateAnomaly"/> object, loaded from path.</returns>
        public static FitMultivariateAnomaly Load(string path) => WrapAsFitMultivariateAnomaly(
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
        /// <returns>an <see cref="JavaMLReader&lt;FitMultivariateAnomaly&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<FitMultivariateAnomaly> Read() =>
            new JavaMLReader<FitMultivariateAnomaly>((JvmObjectReference)Reference.Invoke("read"));
        private static FitMultivariateAnomaly WrapAsFitMultivariateAnomaly(object obj) =>
            new FitMultivariateAnomaly((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New FitMultivariateAnomaly object </returns>
        public FitMultivariateAnomaly SetLocation(string value) =>
            WrapAsFitMultivariateAnomaly(Reference.Invoke("setLocation", value));
    }
}

        