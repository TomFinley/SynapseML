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
    /// <see cref="AddDocuments"/> implements AddDocuments
    /// </summary>
    public class AddDocuments : JavaTransformer, IJavaMLWritable, IJavaMLReadable<AddDocuments>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.AddDocuments";

        /// <summary>
        /// Creates a <see cref="AddDocuments"/> without any parameters.
        /// </summary>
        public AddDocuments() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="AddDocuments"/> with a UID that is used to give the
        /// <see cref="AddDocuments"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public AddDocuments(string uid) : base(s_className, uid)
        {
        }

        internal AddDocuments(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for actionCol
        /// </summary>
        /// <param name="value">
        ///  You can combine actions, such as an upload and a delete, in the same batch.  upload: An upload action is similar to an 'upsert' where the document will be inserted if it is new and updated/replaced if it exists. Note that all fields are replaced in the update case.  merge: Merge updates an existing document with the specified fields. If the document doesn't exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This includes fields of type Collection(Edm.String). For example, if the document contains a field 'tags' with value ['budget'] and you execute a merge with value ['economy', 'pool'] for 'tags', the final value of the 'tags' field will be ['economy', 'pool'].  It will not be ['budget', 'economy', 'pool'].  mergeOrUpload: This action behaves like merge if a document  with the given key already exists in the index.  If the document does not exist, it behaves like upload with a new document.  delete: Delete removes the specified document from the index.  Note that any field you specify in a delete operation,  other than the key field, will be ignored. If you want to   remove an individual field from a document, use merge   instead and simply set the field explicitly to null.     
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetActionCol(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setActionCol", (object)value));
        
        /// <summary>
        /// Sets value for batchSize
        /// </summary>
        /// <param name="value">
        /// The max size of the buffer
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetBatchSize(int value) =>
            WrapAsAddDocuments(Reference.Invoke("setBatchSize", (object)value));
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetConcurrency(int value) =>
            WrapAsAddDocuments(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetConcurrentTimeout(double value) =>
            WrapAsAddDocuments(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetErrorCol(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetHandler(object value) =>
            WrapAsAddDocuments(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for indexName
        /// </summary>
        /// <param name="value">
        /// 
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetIndexName(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setIndexName", (object)value));
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetOutputCol(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for serviceName
        /// </summary>
        /// <param name="value">
        /// 
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetServiceName(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setServiceName", (object)value));
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetSubscriptionKey(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetSubscriptionKeyCol(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetTimeout(double value) =>
            WrapAsAddDocuments(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New AddDocuments object </returns>
        public AddDocuments SetUrl(string value) =>
            WrapAsAddDocuments(Reference.Invoke("setUrl", (object)value));
        /// <summary>
        /// Gets actionCol value
        /// </summary>
        /// <returns>
        /// actionCol:  You can combine actions, such as an upload and a delete, in the same batch.  upload: An upload action is similar to an 'upsert' where the document will be inserted if it is new and updated/replaced if it exists. Note that all fields are replaced in the update case.  merge: Merge updates an existing document with the specified fields. If the document doesn't exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This includes fields of type Collection(Edm.String). For example, if the document contains a field 'tags' with value ['budget'] and you execute a merge with value ['economy', 'pool'] for 'tags', the final value of the 'tags' field will be ['economy', 'pool'].  It will not be ['budget', 'economy', 'pool'].  mergeOrUpload: This action behaves like merge if a document  with the given key already exists in the index.  If the document does not exist, it behaves like upload with a new document.  delete: Delete removes the specified document from the index.  Note that any field you specify in a delete operation,  other than the key field, will be ignored. If you want to   remove an individual field from a document, use merge   instead and simply set the field explicitly to null.     
        /// </returns>
        public string GetActionCol() =>
            (string)Reference.Invoke("getActionCol");
        
        /// <summary>
        /// Gets batchSize value
        /// </summary>
        /// <returns>
        /// batchSize: The max size of the buffer
        /// </returns>
        public int GetBatchSize() =>
            (int)Reference.Invoke("getBatchSize");
        
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
        /// Gets indexName value
        /// </summary>
        /// <returns>
        /// indexName: 
        /// </returns>
        public string GetIndexName() =>
            (string)Reference.Invoke("getIndexName");
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets serviceName value
        /// </summary>
        /// <returns>
        /// serviceName: 
        /// </returns>
        public string GetServiceName() =>
            (string)Reference.Invoke("getServiceName");
        
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
        /// Loads the <see cref="AddDocuments"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="AddDocuments"/> was saved to</param>
        /// <returns>New <see cref="AddDocuments"/> object, loaded from path.</returns>
        public static AddDocuments Load(string path) => WrapAsAddDocuments(
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
        /// <returns>an <see cref="JavaMLReader&lt;AddDocuments&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<AddDocuments> Read() =>
            new JavaMLReader<AddDocuments>((JvmObjectReference)Reference.Invoke("read"));
        private static AddDocuments WrapAsAddDocuments(object obj) =>
            new AddDocuments((JvmObjectReference)obj);
        
    }
}

        