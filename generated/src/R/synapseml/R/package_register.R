#' @import sparklyr
spark_dependencies <- function(spark_version, scala_version, ...) {
    spark_dependency(
        jars = c(),
        packages = c(
           "com.microsoft.azure:synapseml-vw_2.12:0.10.0-3-511c1382-20220816-1208-SNAPSHOT"
        ),
        repositories = c("https://mmlspark.azureedge.net/maven")
    )
}

#' @import sparklyr
.onLoad <- function(libname, pkgname) {
    sparklyr::register_extension(pkgname)
}
