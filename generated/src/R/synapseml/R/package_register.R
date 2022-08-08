#' @import sparklyr
spark_dependencies <- function(spark_version, scala_version, ...) {
    spark_dependency(
        jars = c(),
        packages = c(
           "com.microsoft.azure:synapseml-vw_2.12:0.10.0-1-db95a104-SNAPSHOT"
        ),
        repositories = c("https://mmlspark.azureedge.net/maven")
    )
}

#' @import sparklyr
.onLoad <- function(libname, pkgname) {
    sparklyr::register_extension(pkgname)
}
