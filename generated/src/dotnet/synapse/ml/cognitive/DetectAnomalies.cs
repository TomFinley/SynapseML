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
    /// <see cref="DetectAnomalies"/> implements DetectAnomalies
    /// </summary>
    public class DetectAnomalies : JavaTransformer, IJavaMLWritable, IJavaMLReadable<DetectAnomalies>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.DetectAnomalies";

        /// <summary>
        /// Creates a <see cref="DetectAnomalies"/> without any parameters.
        /// </summary>
        public DetectAnomalies() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="DetectAnomalies"/> with a UID that is used to give the
        /// <see cref="DetectAnomalies"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public DetectAnomalies(string uid) : base(s_className, uid)
        {
        }

        internal DetectAnomalies(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetConcurrency(int value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetConcurrentTimeout(double value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for customInterval
        /// </summary>
        /// <param name="value">
        ///  Custom Interval is used to set non-standard time interval, for example, if the series is 5 minutes,  request can be set as granularity=minutely, customInterval=5.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetCustomInterval(int value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setCustomInterval", (object)value));
        
        
        /// <summary>
        /// Sets value for customInterval column
        /// </summary>
        /// <param name="value">
        ///  Custom Interval is used to set non-standard time interval, for example, if the series is 5 minutes,  request can be set as granularity=minutely, customInterval=5.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetCustomIntervalCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setCustomIntervalCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetErrorCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for granularity
        /// </summary>
        /// <param name="value">
        ///  Can only be one of yearly, monthly, weekly, daily, hourly or minutely. Granularity is used for verify whether input series is valid.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetGranularity(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setGranularity", (object)value));
        
        
        /// <summary>
        /// Sets value for granularity column
        /// </summary>
        /// <param name="value">
        ///  Can only be one of yearly, monthly, weekly, daily, hourly or minutely. Granularity is used for verify whether input series is valid.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetGranularityCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setGranularityCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetHandler(object value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for imputeFixedValue
        /// </summary>
        /// <param name="value">
        ///  Optional argument, fixed value to use when imputeMode is set to "fixed"     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetImputeFixedValue(double value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setImputeFixedValue", (object)value));
        
        
        /// <summary>
        /// Sets value for imputeFixedValue column
        /// </summary>
        /// <param name="value">
        ///  Optional argument, fixed value to use when imputeMode is set to "fixed"     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetImputeFixedValueCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setImputeFixedValueCol", value));
        
        
        /// <summary>
        /// Sets value for imputeMode
        /// </summary>
        /// <param name="value">
        ///  Optional argument, impute mode of a time series. Possible values: auto, previous, linear, fixed, zero, notFill     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetImputeMode(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setImputeMode", (object)value));
        
        
        /// <summary>
        /// Sets value for imputeMode column
        /// </summary>
        /// <param name="value">
        ///  Optional argument, impute mode of a time series. Possible values: auto, previous, linear, fixed, zero, notFill     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetImputeModeCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setImputeModeCol", value));
        
        
        /// <summary>
        /// Sets value for maxAnomalyRatio
        /// </summary>
        /// <param name="value">
        ///  Optional argument, advanced model parameter, max anomaly ratio in a time series.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetMaxAnomalyRatio(double value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setMaxAnomalyRatio", (object)value));
        
        
        /// <summary>
        /// Sets value for maxAnomalyRatio column
        /// </summary>
        /// <param name="value">
        ///  Optional argument, advanced model parameter, max anomaly ratio in a time series.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetMaxAnomalyRatioCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setMaxAnomalyRatioCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetOutputCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for period
        /// </summary>
        /// <param name="value">
        ///  Optional argument, periodic value of a time series. If the value is null or does not present, the API will determine the period automatically.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetPeriod(int value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setPeriod", (object)value));
        
        
        /// <summary>
        /// Sets value for period column
        /// </summary>
        /// <param name="value">
        ///  Optional argument, periodic value of a time series. If the value is null or does not present, the API will determine the period automatically.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetPeriodCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setPeriodCol", value));
        
        
        /// <summary>
        /// Sets value for sensitivity
        /// </summary>
        /// <param name="value">
        ///  Optional argument, advanced model parameter, between 0-99, the lower the value is, the larger the margin value will be which means less anomalies will be accepted     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetSensitivity(int value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setSensitivity", (object)value));
        
        
        /// <summary>
        /// Sets value for sensitivity column
        /// </summary>
        /// <param name="value">
        ///  Optional argument, advanced model parameter, between 0-99, the lower the value is, the larger the margin value will be which means less anomalies will be accepted     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetSensitivityCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setSensitivityCol", value));
        
        
        /// <summary>
        /// Sets value for series
        /// </summary>
        /// <param name="value">
        ///  Time series data points. Points should be sorted by timestamp in ascending order to match the anomaly detection result. If the data is not sorted correctly or there is duplicated timestamp, the API will not work. In such case, an error message will be returned.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetSeries(TimeSeriesPoint[] value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setSeries", (object)value));
        
        
        /// <summary>
        /// Sets value for series column
        /// </summary>
        /// <param name="value">
        ///  Time series data points. Points should be sorted by timestamp in ascending order to match the anomaly detection result. If the data is not sorted correctly or there is duplicated timestamp, the API will not work. In such case, an error message will be returned.     
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetSeriesCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setSeriesCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetSubscriptionKey(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetSubscriptionKeyCol(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetTimeout(double value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetUrl(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setUrl", (object)value));
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
        /// Gets customInterval value
        /// </summary>
        /// <returns>
        /// customInterval:  Custom Interval is used to set non-standard time interval, for example, if the series is 5 minutes,  request can be set as granularity=minutely, customInterval=5.     
        /// </returns>
        public int GetCustomInterval() =>
            (int)Reference.Invoke("getCustomInterval");
        
        
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets granularity value
        /// </summary>
        /// <returns>
        /// granularity:  Can only be one of yearly, monthly, weekly, daily, hourly or minutely. Granularity is used for verify whether input series is valid.     
        /// </returns>
        public string GetGranularity() =>
            (string)Reference.Invoke("getGranularity");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets imputeFixedValue value
        /// </summary>
        /// <returns>
        /// imputeFixedValue:  Optional argument, fixed value to use when imputeMode is set to "fixed"     
        /// </returns>
        public double GetImputeFixedValue() =>
            (double)Reference.Invoke("getImputeFixedValue");
        
        
        /// <summary>
        /// Gets imputeMode value
        /// </summary>
        /// <returns>
        /// imputeMode:  Optional argument, impute mode of a time series. Possible values: auto, previous, linear, fixed, zero, notFill     
        /// </returns>
        public string GetImputeMode() =>
            (string)Reference.Invoke("getImputeMode");
        
        
        /// <summary>
        /// Gets maxAnomalyRatio value
        /// </summary>
        /// <returns>
        /// maxAnomalyRatio:  Optional argument, advanced model parameter, max anomaly ratio in a time series.     
        /// </returns>
        public double GetMaxAnomalyRatio() =>
            (double)Reference.Invoke("getMaxAnomalyRatio");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets period value
        /// </summary>
        /// <returns>
        /// period:  Optional argument, periodic value of a time series. If the value is null or does not present, the API will determine the period automatically.     
        /// </returns>
        public int GetPeriod() =>
            (int)Reference.Invoke("getPeriod");
        
        
        /// <summary>
        /// Gets sensitivity value
        /// </summary>
        /// <returns>
        /// sensitivity:  Optional argument, advanced model parameter, between 0-99, the lower the value is, the larger the margin value will be which means less anomalies will be accepted     
        /// </returns>
        public int GetSensitivity() =>
            (int)Reference.Invoke("getSensitivity");
        
        
        /// <summary>
        /// Gets series value
        /// </summary>
        /// <returns>
        /// series:  Time series data points. Points should be sorted by timestamp in ascending order to match the anomaly detection result. If the data is not sorted correctly or there is duplicated timestamp, the API will not work. In such case, an error message will be returned.     
        /// </returns>
        public TimeSeriesPoint[] GetSeries()
        {
            var jvmObject = (JvmObjectReference)Reference.Invoke("getSeries");
            var jvmObjects = (JvmObjectReference[])jvmObject.Invoke("array");
            TimeSeriesPoint[] result =
                new TimeSeriesPoint[jvmObjects.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new TimeSeriesPoint(jvmObjects[i]);
            }
            return result;
        }
        
        
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
        /// Loads the <see cref="DetectAnomalies"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="DetectAnomalies"/> was saved to</param>
        /// <returns>New <see cref="DetectAnomalies"/> object, loaded from path.</returns>
        public static DetectAnomalies Load(string path) => WrapAsDetectAnomalies(
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
        /// <returns>an <see cref="JavaMLReader&lt;DetectAnomalies&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<DetectAnomalies> Read() =>
            new JavaMLReader<DetectAnomalies>((JvmObjectReference)Reference.Invoke("read"));
        private static DetectAnomalies WrapAsDetectAnomalies(object obj) =>
            new DetectAnomalies((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for location
        /// </summary>
        /// <param name="value">
        /// Location of the cognitive service
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetLocation(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setLocation", value));
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New DetectAnomalies object </returns>
        public DetectAnomalies SetLinkedService(string value) =>
            WrapAsDetectAnomalies(Reference.Invoke("setLinkedService", value));
    }
}

        