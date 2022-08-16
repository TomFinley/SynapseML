
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' AddDocuments
#'
#' @param actionCol  You can combine actions, such as an upload and a delete, in the same batch.  upload: An upload action is similar to an 'upsert' where the document will be inserted if it is new and updated/replaced if it exists. Note that all fields are replaced in the update case.  merge: Merge updates an existing document with the specified fields. If the document doesn't exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This includes fields of type Collection(Edm.String). For example, if the document contains a field 'tags' with value ['budget'] and you execute a merge with value ['economy', 'pool'] for 'tags', the final value of the 'tags' field will be ['economy', 'pool'].  It will not be ['budget', 'economy', 'pool'].  mergeOrUpload: This action behaves like merge if a document  with the given key already exists in the index.  If the document does not exist, it behaves like upload with a new document.  delete: Delete removes the specified document from the index.  Note that any field you specify in a delete operation,  other than the key field, will be ignored. If you want to   remove an individual field from a document, use merge   instead and simply set the field explicitly to null.     
#' @param batchSize The max size of the buffer
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param errorCol column to hold http errors
#' @param handler Which strategy to use when handling requests
#' @param indexName 
#' @param outputCol The name of the output column
#' @param serviceName 
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @export

ml_add_documents <- function(
    x,
    actionCol="@search.action",
    batchSize=100,
    concurrency=1,
    concurrentTimeout=NULL,
    errorCol="AddDocuments_1138f4e64ab4_error",
    handler=NULL,
    indexName=NULL,
    outputCol="AddDocuments_1138f4e64ab4_output",
    serviceName=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url=NULL,
    only.model=FALSE,
    uid=random_string("ml_add_documents"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.AddDocuments"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setActionCol", actionCol) %>%
        invoke("setBatchSize", as.integer(batchSize)) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setHandler", handler) %>%
        invoke("setIndexName", indexName) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setServiceName", serviceName) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
