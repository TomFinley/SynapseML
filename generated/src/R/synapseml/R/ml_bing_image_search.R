
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.



#' BingImageSearch
#'
#' @param aspect Filter images by the following aspect ratios: Square: Return images with standard aspect ratioWide: Return images with wide screen aspect ratioTall: Return images with tall aspect ratioAll: Do not filter by aspect. Specifying this value is the same as not specifying the aspect parameter.
#' @param color Filter images by the following color options:ColorOnly: Return color imagesMonochrome: Return black and white imagesReturn images with one of the following dominant colors:Black,Blue,Brown,Gray,Green,Orange,Pink,Purple,Red,Teal,White,Yellow
#' @param concurrency max number of concurrent calls
#' @param concurrentTimeout max number seconds to wait on futures if concurrency >= 1
#' @param count The number of image results to return in the response. The actual number delivered may be less than requested.
#' @param errorCol column to hold http errors
#' @param freshness Filter images by the following discovery options:Day: Return images discovered by Bing within the last 24 hoursWeek: Return images discovered by Bing within the last 7 daysMonth: Return images discovered by Bing within the last 30 daysYear: Return images discovered within the last year2017-06-15..2018-06-15: Return images discovered within the specified range of dates
#' @param handler Which strategy to use when handling requests
#' @param height Filter images that have the specified height, in pixels.You may use this filter with the size filter to return small images that have a height of 150 pixels.
#' @param imageContent Filter images by the following content types:Face: Return images that show only a person's facePortrait: Return images that show only a person's head and shoulders
#' @param imageType Filter images by the following image types:AnimatedGif: return animated gif imagesAnimatedGifHttps: return animated gif images that are from an https addressClipart: Return only clip art imagesLine: Return only line drawingsPhoto: Return only photographs (excluding line drawings, animated Gifs, and clip art)Shopping: Return only images that contain items where Bing knows of a merchant that is selling the items. This option is valid in the en-US market only. Transparent: Return only images with a transparent background.
#' @param license Filter images by the following license types:Any: Return images that are under any license type. The response doesn't include images that do not specify a license or the license is unknown.Public: Return images where the creator has waived their exclusive rights, to the fullest extent allowed by law.Share: Return images that may be shared with others. Changing or editing the image might not be allowed. Also, modifying, sharing, and using the image for commercial purposes might not be allowed. Typically, this option returns the most images.ShareCommercially: Return images that may be shared with others for personal or commercial purposes. Changing or editing the image might not be allowed.Modify: Return images that may be modified, shared, and used. Changing or editing the image might not be allowed. Modifying, sharing, and using the image for commercial purposes might not be allowed. ModifyCommercially: Return images that may be modified, shared, and used for personal or commercial purposes. Typically, this option returns the fewest images.All: Do not filter by license type. Specifying this value is the same as not specifying the license parameter. For more information about these license types, see Filter Images By License Type.
#' @param maxFileSize Filter images that are less than or equal to the specified file size.The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly larger than the specified maximum.You may specify this filter and minFileSize to filter images within a range of file sizes.
#' @param maxHeight Filter images that have a height that is less than or equal to the specified height. Specify the height in pixels.You may specify this filter and minHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
#' @param maxWidth Filter images that have a width that is less than or equal to the specified width. Specify the width in pixels.You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
#' @param minFileSize Filter images that are greater than or equal to the specified file size. The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly smaller than the specified minimum. You may specify this filter and maxFileSize to filter images within a range of file sizes.
#' @param minHeight Filter images that have a height that is greater than or equal to the specified height. Specify the height in pixels.You may specify this filter and maxHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
#' @param minWidth Filter images that have a width that is greater than or equal to the specified width. Specify the width in pixels. You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
#' @param mkt The market where the results come from. Typically, this is the country where the user is making the request from; however, it could be a different country if the user is not located in a country where Bing delivers results. The market must be in the form -. For example, en-US. Full list of supported markets: es-AR,en-AU,de-AT,nl-BE,fr-BE,pt-BR,en-CA,fr-CA,es-CL,da-DK,fi-FI,fr-FR,de-DE,zh-HK,en-IN,en-ID,en-IE,it-IT,ja-JP,ko-KR,en-MY,es-MX,nl-NL,en-NZ,no-NO,zh-CN,pl-PL,pt-PT,en-PH,ru-RU,ar-SA,en-ZA,es-ES,sv-SE,fr-CH,de-CH,zh-TW,tr-TR,en-GB,en-US,es-US
#' @param offset The zero-based offset that indicates the number of image results to skip before returning results
#' @param outputCol The name of the output column
#' @param q The user's search query string
#' @param size Filter images by the following sizes:Small: Return images that are less than 200x200 pixelsMedium: Return images that are greater than or equal to 200x200 pixels but less than 500x500 pixelsLarge: Return images that are 500x500 pixels or largerWallpaper: Return wallpaper images.AllDo not filter by size. Specifying this value is the same as not specifying the size parameter.You may use this parameter along with the height or width parameters. For example, you may use height and size to request small images that are 150 pixels tall.
#' @param subscriptionKey the API key to use
#' @param timeout number of seconds to wait before closing the connection
#' @param url Url of the service
#' @param width Filter images that have the specified width, in pixels.You may use this filter with the size filter to return small images that have a width of 150 pixels.
#' @export

ml_bing_image_search <- function(
    x,
    aspect=NULL,
    aspectCol=NULL,
    color=NULL,
    colorCol=NULL,
    concurrency=1,
    concurrentTimeout=NULL,
    count=NULL,
    countCol=NULL,
    errorCol="BingImageSearch_d870a3bc9812_error",
    freshness=NULL,
    freshnessCol=NULL,
    handler=NULL,
    height=NULL,
    heightCol=NULL,
    imageContent=NULL,
    imageContentCol=NULL,
    imageType=NULL,
    imageTypeCol=NULL,
    license=NULL,
    licenseCol=NULL,
    maxFileSize=NULL,
    maxFileSizeCol=NULL,
    maxHeight=NULL,
    maxHeightCol=NULL,
    maxWidth=NULL,
    maxWidthCol=NULL,
    minFileSize=NULL,
    minFileSizeCol=NULL,
    minHeight=NULL,
    minHeightCol=NULL,
    minWidth=NULL,
    minWidthCol=NULL,
    mkt=NULL,
    mktCol=NULL,
    offset=NULL,
    offsetCol=NULL,
    outputCol="BingImageSearch_d870a3bc9812_output",
    q=NULL,
    qCol=NULL,
    size=NULL,
    sizeCol=NULL,
    subscriptionKey=NULL,
    subscriptionKeyCol=NULL,
    timeout=60.0,
    url="https://api.bing.microsoft.com/v7.0/images/search",
    width=NULL,
    widthCol=NULL,
    only.model=FALSE,
    uid=random_string("ml_bing_image_search"),
    ...)
{
    if (unfit.model) {
        sc <- x
    } else {
        df <- spark_dataframe(x)
        sc <- spark_connection(df)
    }
    scala_class <- "com.microsoft.azure.synapse.ml.cognitive.BingImageSearch"
    mod <- invoke_new(sc, scala_class, uid = uid)
    mod_parameterized <- mod %>%
        invoke("setAspectCol", aspectCol) %>%
        invoke("setAspect", aspect) %>%
        invoke("setColorCol", colorCol) %>%
        invoke("setColor", color) %>%
        invoke("setConcurrency", as.integer(concurrency)) %>%
        invoke("setConcurrentTimeout", as.double(concurrentTimeout)) %>%
        invoke("setCountCol", countCol) %>%
        invoke("setCount", count) %>%
        invoke("setErrorCol", errorCol) %>%
        invoke("setFreshnessCol", freshnessCol) %>%
        invoke("setFreshness", freshness) %>%
        invoke("setHandler", handler) %>%
        invoke("setHeightCol", heightCol) %>%
        invoke("setHeight", height) %>%
        invoke("setImageContentCol", imageContentCol) %>%
        invoke("setImageContent", imageContent) %>%
        invoke("setImageTypeCol", imageTypeCol) %>%
        invoke("setImageType", imageType) %>%
        invoke("setLicenseCol", licenseCol) %>%
        invoke("setLicense", license) %>%
        invoke("setMaxFileSizeCol", maxFileSizeCol) %>%
        invoke("setMaxFileSize", maxFileSize) %>%
        invoke("setMaxHeightCol", maxHeightCol) %>%
        invoke("setMaxHeight", maxHeight) %>%
        invoke("setMaxWidthCol", maxWidthCol) %>%
        invoke("setMaxWidth", maxWidth) %>%
        invoke("setMinFileSizeCol", minFileSizeCol) %>%
        invoke("setMinFileSize", minFileSize) %>%
        invoke("setMinHeightCol", minHeightCol) %>%
        invoke("setMinHeight", minHeight) %>%
        invoke("setMinWidthCol", minWidthCol) %>%
        invoke("setMinWidth", minWidth) %>%
        invoke("setMktCol", mktCol) %>%
        invoke("setMkt", mkt) %>%
        invoke("setOffsetCol", offsetCol) %>%
        invoke("setOffset", offset) %>%
        invoke("setOutputCol", outputCol) %>%
        invoke("setQCol", qCol) %>%
        invoke("setQ", q) %>%
        invoke("setSizeCol", sizeCol) %>%
        invoke("setSize", size) %>%
        invoke("setSubscriptionKeyCol", subscriptionKeyCol) %>%
        invoke("setSubscriptionKey", subscriptionKey) %>%
        invoke("setTimeout", as.double(timeout)) %>%
        invoke("setUrl", url) %>%
        invoke("setWidthCol", widthCol) %>%
        invoke("setWidth", width)
    
    transformer <- mod_parameterized
    scala_transformer_class <- scala_class
    if (only.model)
        return(sparklyr:::new_ml_transformer(transformer, class=scala_transformer_class))
    transformed <- invoke(transformer, "transform", df)
    sdf_register(transformed)
}
