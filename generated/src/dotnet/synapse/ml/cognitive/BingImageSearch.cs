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
    /// <see cref="BingImageSearch"/> implements BingImageSearch
    /// </summary>
    public class BingImageSearch : JavaTransformer, IJavaMLWritable, IJavaMLReadable<BingImageSearch>
    {
        private static readonly string s_className = "com.microsoft.azure.synapse.ml.cognitive.BingImageSearch";

        /// <summary>
        /// Creates a <see cref="BingImageSearch"/> without any parameters.
        /// </summary>
        public BingImageSearch() : base(s_className)
        {
        }

        /// <summary>
        /// Creates a <see cref="BingImageSearch"/> with a UID that is used to give the
        /// <see cref="BingImageSearch"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public BingImageSearch(string uid) : base(s_className, uid)
        {
        }

        internal BingImageSearch(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets value for aspect
        /// </summary>
        /// <param name="value">
        /// Filter images by the following aspect ratios: Square: Return images with standard aspect ratioWide: Return images with wide screen aspect ratioTall: Return images with tall aspect ratioAll: Do not filter by aspect. Specifying this value is the same as not specifying the aspect parameter.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetAspect(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setAspect", (object)value));
        
        
        /// <summary>
        /// Sets value for aspect column
        /// </summary>
        /// <param name="value">
        /// Filter images by the following aspect ratios: Square: Return images with standard aspect ratioWide: Return images with wide screen aspect ratioTall: Return images with tall aspect ratioAll: Do not filter by aspect. Specifying this value is the same as not specifying the aspect parameter.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetAspectCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setAspectCol", value));
        
        
        /// <summary>
        /// Sets value for color
        /// </summary>
        /// <param name="value">
        /// Filter images by the following color options:ColorOnly: Return color imagesMonochrome: Return black and white imagesReturn images with one of the following dominant colors:Black,Blue,Brown,Gray,Green,Orange,Pink,Purple,Red,Teal,White,Yellow
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetColor(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setColor", (object)value));
        
        
        /// <summary>
        /// Sets value for color column
        /// </summary>
        /// <param name="value">
        /// Filter images by the following color options:ColorOnly: Return color imagesMonochrome: Return black and white imagesReturn images with one of the following dominant colors:Black,Blue,Brown,Gray,Green,Orange,Pink,Purple,Red,Teal,White,Yellow
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetColorCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setColorCol", value));
        
        
        /// <summary>
        /// Sets value for concurrency
        /// </summary>
        /// <param name="value">
        /// max number of concurrent calls
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetConcurrency(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setConcurrency", (object)value));
        
        /// <summary>
        /// Sets value for concurrentTimeout
        /// </summary>
        /// <param name="value">
        /// max number seconds to wait on futures if concurrency >= 1
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetConcurrentTimeout(double value) =>
            WrapAsBingImageSearch(Reference.Invoke("setConcurrentTimeout", (object)value));
        
        /// <summary>
        /// Sets value for count
        /// </summary>
        /// <param name="value">
        /// The number of image results to return in the response. The actual number delivered may be less than requested.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetCount(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setCount", (object)value));
        
        
        /// <summary>
        /// Sets value for count column
        /// </summary>
        /// <param name="value">
        /// The number of image results to return in the response. The actual number delivered may be less than requested.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetCountCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setCountCol", value));
        
        
        /// <summary>
        /// Sets value for errorCol
        /// </summary>
        /// <param name="value">
        /// column to hold http errors
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetErrorCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setErrorCol", (object)value));
        
        /// <summary>
        /// Sets value for freshness
        /// </summary>
        /// <param name="value">
        /// Filter images by the following discovery options:Day: Return images discovered by Bing within the last 24 hoursWeek: Return images discovered by Bing within the last 7 daysMonth: Return images discovered by Bing within the last 30 daysYear: Return images discovered within the last year2017-06-15..2018-06-15: Return images discovered within the specified range of dates
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetFreshness(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setFreshness", (object)value));
        
        
        /// <summary>
        /// Sets value for freshness column
        /// </summary>
        /// <param name="value">
        /// Filter images by the following discovery options:Day: Return images discovered by Bing within the last 24 hoursWeek: Return images discovered by Bing within the last 7 daysMonth: Return images discovered by Bing within the last 30 daysYear: Return images discovered within the last year2017-06-15..2018-06-15: Return images discovered within the specified range of dates
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetFreshnessCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setFreshnessCol", value));
        
        
        /// <summary>
        /// Sets value for handler
        /// </summary>
        /// <param name="value">
        /// Which strategy to use when handling requests
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetHandler(object value) =>
            WrapAsBingImageSearch(Reference.Invoke("setHandler", (object)value));
        
        
        /// <summary>
        /// Sets value for height
        /// </summary>
        /// <param name="value">
        /// Filter images that have the specified height, in pixels.You may use this filter with the size filter to return small images that have a height of 150 pixels.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetHeight(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setHeight", (object)value));
        
        
        /// <summary>
        /// Sets value for height column
        /// </summary>
        /// <param name="value">
        /// Filter images that have the specified height, in pixels.You may use this filter with the size filter to return small images that have a height of 150 pixels.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetHeightCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setHeightCol", value));
        
        
        /// <summary>
        /// Sets value for imageContent
        /// </summary>
        /// <param name="value">
        /// Filter images by the following content types:Face: Return images that show only a person's facePortrait: Return images that show only a person's head and shoulders
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetImageContent(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setImageContent", (object)value));
        
        
        /// <summary>
        /// Sets value for imageContent column
        /// </summary>
        /// <param name="value">
        /// Filter images by the following content types:Face: Return images that show only a person's facePortrait: Return images that show only a person's head and shoulders
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetImageContentCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setImageContentCol", value));
        
        
        /// <summary>
        /// Sets value for imageType
        /// </summary>
        /// <param name="value">
        /// Filter images by the following image types:AnimatedGif: return animated gif imagesAnimatedGifHttps: return animated gif images that are from an https addressClipart: Return only clip art imagesLine: Return only line drawingsPhoto: Return only photographs (excluding line drawings, animated Gifs, and clip art)Shopping: Return only images that contain items where Bing knows of a merchant that is selling the items. This option is valid in the en-US market only. Transparent: Return only images with a transparent background.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetImageType(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setImageType", (object)value));
        
        
        /// <summary>
        /// Sets value for imageType column
        /// </summary>
        /// <param name="value">
        /// Filter images by the following image types:AnimatedGif: return animated gif imagesAnimatedGifHttps: return animated gif images that are from an https addressClipart: Return only clip art imagesLine: Return only line drawingsPhoto: Return only photographs (excluding line drawings, animated Gifs, and clip art)Shopping: Return only images that contain items where Bing knows of a merchant that is selling the items. This option is valid in the en-US market only. Transparent: Return only images with a transparent background.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetImageTypeCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setImageTypeCol", value));
        
        
        /// <summary>
        /// Sets value for license
        /// </summary>
        /// <param name="value">
        /// Filter images by the following license types:Any: Return images that are under any license type. The response doesn't include images that do not specify a license or the license is unknown.Public: Return images where the creator has waived their exclusive rights, to the fullest extent allowed by law.Share: Return images that may be shared with others. Changing or editing the image might not be allowed. Also, modifying, sharing, and using the image for commercial purposes might not be allowed. Typically, this option returns the most images.ShareCommercially: Return images that may be shared with others for personal or commercial purposes. Changing or editing the image might not be allowed.Modify: Return images that may be modified, shared, and used. Changing or editing the image might not be allowed. Modifying, sharing, and using the image for commercial purposes might not be allowed. ModifyCommercially: Return images that may be modified, shared, and used for personal or commercial purposes. Typically, this option returns the fewest images.All: Do not filter by license type. Specifying this value is the same as not specifying the license parameter. For more information about these license types, see Filter Images By License Type.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetLicense(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setLicense", (object)value));
        
        
        /// <summary>
        /// Sets value for license column
        /// </summary>
        /// <param name="value">
        /// Filter images by the following license types:Any: Return images that are under any license type. The response doesn't include images that do not specify a license or the license is unknown.Public: Return images where the creator has waived their exclusive rights, to the fullest extent allowed by law.Share: Return images that may be shared with others. Changing or editing the image might not be allowed. Also, modifying, sharing, and using the image for commercial purposes might not be allowed. Typically, this option returns the most images.ShareCommercially: Return images that may be shared with others for personal or commercial purposes. Changing or editing the image might not be allowed.Modify: Return images that may be modified, shared, and used. Changing or editing the image might not be allowed. Modifying, sharing, and using the image for commercial purposes might not be allowed. ModifyCommercially: Return images that may be modified, shared, and used for personal or commercial purposes. Typically, this option returns the fewest images.All: Do not filter by license type. Specifying this value is the same as not specifying the license parameter. For more information about these license types, see Filter Images By License Type.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetLicenseCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setLicenseCol", value));
        
        
        /// <summary>
        /// Sets value for maxFileSize
        /// </summary>
        /// <param name="value">
        /// Filter images that are less than or equal to the specified file size.The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly larger than the specified maximum.You may specify this filter and minFileSize to filter images within a range of file sizes.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMaxFileSize(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMaxFileSize", (object)value));
        
        
        /// <summary>
        /// Sets value for maxFileSize column
        /// </summary>
        /// <param name="value">
        /// Filter images that are less than or equal to the specified file size.The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly larger than the specified maximum.You may specify this filter and minFileSize to filter images within a range of file sizes.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMaxFileSizeCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMaxFileSizeCol", value));
        
        
        /// <summary>
        /// Sets value for maxHeight
        /// </summary>
        /// <param name="value">
        /// Filter images that have a height that is less than or equal to the specified height. Specify the height in pixels.You may specify this filter and minHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMaxHeight(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMaxHeight", (object)value));
        
        
        /// <summary>
        /// Sets value for maxHeight column
        /// </summary>
        /// <param name="value">
        /// Filter images that have a height that is less than or equal to the specified height. Specify the height in pixels.You may specify this filter and minHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMaxHeightCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMaxHeightCol", value));
        
        
        /// <summary>
        /// Sets value for maxWidth
        /// </summary>
        /// <param name="value">
        /// Filter images that have a width that is less than or equal to the specified width. Specify the width in pixels.You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMaxWidth(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMaxWidth", (object)value));
        
        
        /// <summary>
        /// Sets value for maxWidth column
        /// </summary>
        /// <param name="value">
        /// Filter images that have a width that is less than or equal to the specified width. Specify the width in pixels.You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMaxWidthCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMaxWidthCol", value));
        
        
        /// <summary>
        /// Sets value for minFileSize
        /// </summary>
        /// <param name="value">
        /// Filter images that are greater than or equal to the specified file size. The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly smaller than the specified minimum. You may specify this filter and maxFileSize to filter images within a range of file sizes.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMinFileSize(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMinFileSize", (object)value));
        
        
        /// <summary>
        /// Sets value for minFileSize column
        /// </summary>
        /// <param name="value">
        /// Filter images that are greater than or equal to the specified file size. The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly smaller than the specified minimum. You may specify this filter and maxFileSize to filter images within a range of file sizes.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMinFileSizeCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMinFileSizeCol", value));
        
        
        /// <summary>
        /// Sets value for minHeight
        /// </summary>
        /// <param name="value">
        /// Filter images that have a height that is greater than or equal to the specified height. Specify the height in pixels.You may specify this filter and maxHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMinHeight(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMinHeight", (object)value));
        
        
        /// <summary>
        /// Sets value for minHeight column
        /// </summary>
        /// <param name="value">
        /// Filter images that have a height that is greater than or equal to the specified height. Specify the height in pixels.You may specify this filter and maxHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMinHeightCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMinHeightCol", value));
        
        
        /// <summary>
        /// Sets value for minWidth
        /// </summary>
        /// <param name="value">
        /// Filter images that have a width that is greater than or equal to the specified width. Specify the width in pixels. You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMinWidth(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMinWidth", (object)value));
        
        
        /// <summary>
        /// Sets value for minWidth column
        /// </summary>
        /// <param name="value">
        /// Filter images that have a width that is greater than or equal to the specified width. Specify the width in pixels. You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMinWidthCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMinWidthCol", value));
        
        
        /// <summary>
        /// Sets value for mkt
        /// </summary>
        /// <param name="value">
        /// The market where the results come from. Typically, this is the country where the user is making the request from; however, it could be a different country if the user is not located in a country where Bing delivers results. The market must be in the form -. For example, en-US. Full list of supported markets: es-AR,en-AU,de-AT,nl-BE,fr-BE,pt-BR,en-CA,fr-CA,es-CL,da-DK,fi-FI,fr-FR,de-DE,zh-HK,en-IN,en-ID,en-IE,it-IT,ja-JP,ko-KR,en-MY,es-MX,nl-NL,en-NZ,no-NO,zh-CN,pl-PL,pt-PT,en-PH,ru-RU,ar-SA,en-ZA,es-ES,sv-SE,fr-CH,de-CH,zh-TW,tr-TR,en-GB,en-US,es-US
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMkt(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMkt", (object)value));
        
        
        /// <summary>
        /// Sets value for mkt column
        /// </summary>
        /// <param name="value">
        /// The market where the results come from. Typically, this is the country where the user is making the request from; however, it could be a different country if the user is not located in a country where Bing delivers results. The market must be in the form -. For example, en-US. Full list of supported markets: es-AR,en-AU,de-AT,nl-BE,fr-BE,pt-BR,en-CA,fr-CA,es-CL,da-DK,fi-FI,fr-FR,de-DE,zh-HK,en-IN,en-ID,en-IE,it-IT,ja-JP,ko-KR,en-MY,es-MX,nl-NL,en-NZ,no-NO,zh-CN,pl-PL,pt-PT,en-PH,ru-RU,ar-SA,en-ZA,es-ES,sv-SE,fr-CH,de-CH,zh-TW,tr-TR,en-GB,en-US,es-US
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetMktCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setMktCol", value));
        
        
        /// <summary>
        /// Sets value for offset
        /// </summary>
        /// <param name="value">
        /// The zero-based offset that indicates the number of image results to skip before returning results
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetOffset(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setOffset", (object)value));
        
        
        /// <summary>
        /// Sets value for offset column
        /// </summary>
        /// <param name="value">
        /// The zero-based offset that indicates the number of image results to skip before returning results
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetOffsetCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setOffsetCol", value));
        
        
        /// <summary>
        /// Sets value for outputCol
        /// </summary>
        /// <param name="value">
        /// The name of the output column
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetOutputCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets value for q
        /// </summary>
        /// <param name="value">
        /// The user's search query string
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetQ(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setQ", (object)value));
        
        
        /// <summary>
        /// Sets value for q column
        /// </summary>
        /// <param name="value">
        /// The user's search query string
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetQCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setQCol", value));
        
        
        /// <summary>
        /// Sets value for size
        /// </summary>
        /// <param name="value">
        /// Filter images by the following sizes:Small: Return images that are less than 200x200 pixelsMedium: Return images that are greater than or equal to 200x200 pixels but less than 500x500 pixelsLarge: Return images that are 500x500 pixels or largerWallpaper: Return wallpaper images.AllDo not filter by size. Specifying this value is the same as not specifying the size parameter.You may use this parameter along with the height or width parameters. For example, you may use height and size to request small images that are 150 pixels tall.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetSize(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setSize", (object)value));
        
        
        /// <summary>
        /// Sets value for size column
        /// </summary>
        /// <param name="value">
        /// Filter images by the following sizes:Small: Return images that are less than 200x200 pixelsMedium: Return images that are greater than or equal to 200x200 pixels but less than 500x500 pixelsLarge: Return images that are 500x500 pixels or largerWallpaper: Return wallpaper images.AllDo not filter by size. Specifying this value is the same as not specifying the size parameter.You may use this parameter along with the height or width parameters. For example, you may use height and size to request small images that are 150 pixels tall.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetSizeCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setSizeCol", value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetSubscriptionKey(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setSubscriptionKey", (object)value));
        
        
        /// <summary>
        /// Sets value for subscriptionKey column
        /// </summary>
        /// <param name="value">
        /// the API key to use
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetSubscriptionKeyCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setSubscriptionKeyCol", value));
        
        
        /// <summary>
        /// Sets value for timeout
        /// </summary>
        /// <param name="value">
        /// number of seconds to wait before closing the connection
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetTimeout(double value) =>
            WrapAsBingImageSearch(Reference.Invoke("setTimeout", (object)value));
        
        /// <summary>
        /// Sets value for url
        /// </summary>
        /// <param name="value">
        /// Url of the service
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetUrl(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setUrl", (object)value));
        
        /// <summary>
        /// Sets value for width
        /// </summary>
        /// <param name="value">
        /// Filter images that have the specified width, in pixels.You may use this filter with the size filter to return small images that have a width of 150 pixels.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetWidth(int value) =>
            WrapAsBingImageSearch(Reference.Invoke("setWidth", (object)value));
        
        
        /// <summary>
        /// Sets value for width column
        /// </summary>
        /// <param name="value">
        /// Filter images that have the specified width, in pixels.You may use this filter with the size filter to return small images that have a width of 150 pixels.
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetWidthCol(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setWidthCol", value));
        /// <summary>
        /// Gets aspect value
        /// </summary>
        /// <returns>
        /// aspect: Filter images by the following aspect ratios: Square: Return images with standard aspect ratioWide: Return images with wide screen aspect ratioTall: Return images with tall aspect ratioAll: Do not filter by aspect. Specifying this value is the same as not specifying the aspect parameter.
        /// </returns>
        public string GetAspect() =>
            (string)Reference.Invoke("getAspect");
        
        
        /// <summary>
        /// Gets color value
        /// </summary>
        /// <returns>
        /// color: Filter images by the following color options:ColorOnly: Return color imagesMonochrome: Return black and white imagesReturn images with one of the following dominant colors:Black,Blue,Brown,Gray,Green,Orange,Pink,Purple,Red,Teal,White,Yellow
        /// </returns>
        public string GetColor() =>
            (string)Reference.Invoke("getColor");
        
        
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
        /// Gets count value
        /// </summary>
        /// <returns>
        /// count: The number of image results to return in the response. The actual number delivered may be less than requested.
        /// </returns>
        public int GetCount() =>
            (int)Reference.Invoke("getCount");
        
        
        /// <summary>
        /// Gets errorCol value
        /// </summary>
        /// <returns>
        /// errorCol: column to hold http errors
        /// </returns>
        public string GetErrorCol() =>
            (string)Reference.Invoke("getErrorCol");
        
        /// <summary>
        /// Gets freshness value
        /// </summary>
        /// <returns>
        /// freshness: Filter images by the following discovery options:Day: Return images discovered by Bing within the last 24 hoursWeek: Return images discovered by Bing within the last 7 daysMonth: Return images discovered by Bing within the last 30 daysYear: Return images discovered within the last year2017-06-15..2018-06-15: Return images discovered within the specified range of dates
        /// </returns>
        public string GetFreshness() =>
            (string)Reference.Invoke("getFreshness");
        
        
        /// <summary>
        /// Gets handler value
        /// </summary>
        /// <returns>
        /// handler: Which strategy to use when handling requests
        /// </returns>
        public object GetHandler() => Reference.Invoke("getHandler");
        
        /// <summary>
        /// Gets height value
        /// </summary>
        /// <returns>
        /// height: Filter images that have the specified height, in pixels.You may use this filter with the size filter to return small images that have a height of 150 pixels.
        /// </returns>
        public int GetHeight() =>
            (int)Reference.Invoke("getHeight");
        
        
        /// <summary>
        /// Gets imageContent value
        /// </summary>
        /// <returns>
        /// imageContent: Filter images by the following content types:Face: Return images that show only a person's facePortrait: Return images that show only a person's head and shoulders
        /// </returns>
        public string GetImageContent() =>
            (string)Reference.Invoke("getImageContent");
        
        
        /// <summary>
        /// Gets imageType value
        /// </summary>
        /// <returns>
        /// imageType: Filter images by the following image types:AnimatedGif: return animated gif imagesAnimatedGifHttps: return animated gif images that are from an https addressClipart: Return only clip art imagesLine: Return only line drawingsPhoto: Return only photographs (excluding line drawings, animated Gifs, and clip art)Shopping: Return only images that contain items where Bing knows of a merchant that is selling the items. This option is valid in the en-US market only. Transparent: Return only images with a transparent background.
        /// </returns>
        public string GetImageType() =>
            (string)Reference.Invoke("getImageType");
        
        
        /// <summary>
        /// Gets license value
        /// </summary>
        /// <returns>
        /// license: Filter images by the following license types:Any: Return images that are under any license type. The response doesn't include images that do not specify a license or the license is unknown.Public: Return images where the creator has waived their exclusive rights, to the fullest extent allowed by law.Share: Return images that may be shared with others. Changing or editing the image might not be allowed. Also, modifying, sharing, and using the image for commercial purposes might not be allowed. Typically, this option returns the most images.ShareCommercially: Return images that may be shared with others for personal or commercial purposes. Changing or editing the image might not be allowed.Modify: Return images that may be modified, shared, and used. Changing or editing the image might not be allowed. Modifying, sharing, and using the image for commercial purposes might not be allowed. ModifyCommercially: Return images that may be modified, shared, and used for personal or commercial purposes. Typically, this option returns the fewest images.All: Do not filter by license type. Specifying this value is the same as not specifying the license parameter. For more information about these license types, see Filter Images By License Type.
        /// </returns>
        public string GetLicense() =>
            (string)Reference.Invoke("getLicense");
        
        
        /// <summary>
        /// Gets maxFileSize value
        /// </summary>
        /// <returns>
        /// maxFileSize: Filter images that are less than or equal to the specified file size.The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly larger than the specified maximum.You may specify this filter and minFileSize to filter images within a range of file sizes.
        /// </returns>
        public int GetMaxFileSize() =>
            (int)Reference.Invoke("getMaxFileSize");
        
        
        /// <summary>
        /// Gets maxHeight value
        /// </summary>
        /// <returns>
        /// maxHeight: Filter images that have a height that is less than or equal to the specified height. Specify the height in pixels.You may specify this filter and minHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
        /// </returns>
        public int GetMaxHeight() =>
            (int)Reference.Invoke("getMaxHeight");
        
        
        /// <summary>
        /// Gets maxWidth value
        /// </summary>
        /// <returns>
        /// maxWidth: Filter images that have a width that is less than or equal to the specified width. Specify the width in pixels.You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
        /// </returns>
        public int GetMaxWidth() =>
            (int)Reference.Invoke("getMaxWidth");
        
        
        /// <summary>
        /// Gets minFileSize value
        /// </summary>
        /// <returns>
        /// minFileSize: Filter images that are greater than or equal to the specified file size. The maximum file size that you may specify is 520,192 bytes. If you specify a larger value, the API uses 520,192. It is possible that the response may include images that are slightly smaller than the specified minimum. You may specify this filter and maxFileSize to filter images within a range of file sizes.
        /// </returns>
        public int GetMinFileSize() =>
            (int)Reference.Invoke("getMinFileSize");
        
        
        /// <summary>
        /// Gets minHeight value
        /// </summary>
        /// <returns>
        /// minHeight: Filter images that have a height that is greater than or equal to the specified height. Specify the height in pixels.You may specify this filter and maxHeight to filter images within a range of heights. This filter and the height filter are mutually exclusive.
        /// </returns>
        public int GetMinHeight() =>
            (int)Reference.Invoke("getMinHeight");
        
        
        /// <summary>
        /// Gets minWidth value
        /// </summary>
        /// <returns>
        /// minWidth: Filter images that have a width that is greater than or equal to the specified width. Specify the width in pixels. You may specify this filter and maxWidth to filter images within a range of widths. This filter and the width filter are mutually exclusive.
        /// </returns>
        public int GetMinWidth() =>
            (int)Reference.Invoke("getMinWidth");
        
        
        /// <summary>
        /// Gets mkt value
        /// </summary>
        /// <returns>
        /// mkt: The market where the results come from. Typically, this is the country where the user is making the request from; however, it could be a different country if the user is not located in a country where Bing delivers results. The market must be in the form -. For example, en-US. Full list of supported markets: es-AR,en-AU,de-AT,nl-BE,fr-BE,pt-BR,en-CA,fr-CA,es-CL,da-DK,fi-FI,fr-FR,de-DE,zh-HK,en-IN,en-ID,en-IE,it-IT,ja-JP,ko-KR,en-MY,es-MX,nl-NL,en-NZ,no-NO,zh-CN,pl-PL,pt-PT,en-PH,ru-RU,ar-SA,en-ZA,es-ES,sv-SE,fr-CH,de-CH,zh-TW,tr-TR,en-GB,en-US,es-US
        /// </returns>
        public string GetMkt() =>
            (string)Reference.Invoke("getMkt");
        
        
        /// <summary>
        /// Gets offset value
        /// </summary>
        /// <returns>
        /// offset: The zero-based offset that indicates the number of image results to skip before returning results
        /// </returns>
        public int GetOffset() =>
            (int)Reference.Invoke("getOffset");
        
        
        /// <summary>
        /// Gets outputCol value
        /// </summary>
        /// <returns>
        /// outputCol: The name of the output column
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets q value
        /// </summary>
        /// <returns>
        /// q: The user's search query string
        /// </returns>
        public string GetQ() =>
            (string)Reference.Invoke("getQ");
        
        
        /// <summary>
        /// Gets size value
        /// </summary>
        /// <returns>
        /// size: Filter images by the following sizes:Small: Return images that are less than 200x200 pixelsMedium: Return images that are greater than or equal to 200x200 pixels but less than 500x500 pixelsLarge: Return images that are 500x500 pixels or largerWallpaper: Return wallpaper images.AllDo not filter by size. Specifying this value is the same as not specifying the size parameter.You may use this parameter along with the height or width parameters. For example, you may use height and size to request small images that are 150 pixels tall.
        /// </returns>
        public string GetSize() =>
            (string)Reference.Invoke("getSize");
        
        
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
        /// Gets width value
        /// </summary>
        /// <returns>
        /// width: Filter images that have the specified width, in pixels.You may use this filter with the size filter to return small images that have a width of 150 pixels.
        /// </returns>
        public int GetWidth() =>
            (int)Reference.Invoke("getWidth");
        
        /// <summary>
        /// Loads the <see cref="BingImageSearch"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="BingImageSearch"/> was saved to</param>
        /// <returns>New <see cref="BingImageSearch"/> object, loaded from path.</returns>
        public static BingImageSearch Load(string path) => WrapAsBingImageSearch(
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
        /// <returns>an <see cref="JavaMLReader&lt;BingImageSearch&gt;"/> instance for this ML instance.</returns>
        public JavaMLReader<BingImageSearch> Read() =>
            new JavaMLReader<BingImageSearch>((JvmObjectReference)Reference.Invoke("read"));
        private static BingImageSearch WrapAsBingImageSearch(object obj) =>
            new BingImageSearch((JvmObjectReference)obj);
        /// <summary>
        /// Sets value for linkedService
        /// </summary>
        /// <param name="value">
        /// linkedService name
        /// </param>
        /// <returns> New BingImageSearch object </returns>
        public BingImageSearch SetLinkedService(string value) =>
            WrapAsBingImageSearch(Reference.Invoke("setLinkedService", value));
    }
}

        