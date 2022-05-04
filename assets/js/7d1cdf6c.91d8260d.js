"use strict";(self.webpackChunksynapseml=self.webpackChunksynapseml||[]).push([[9859],{3905:function(e,t,r){r.d(t,{Zo:function(){return m},kt:function(){return g}});var n=r(7294);function a(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function i(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function l(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?i(Object(r),!0).forEach((function(t){a(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):i(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function s(e,t){if(null==e)return{};var r,n,a=function(e,t){if(null==e)return{};var r,n,a={},i=Object.keys(e);for(n=0;n<i.length;n++)r=i[n],t.indexOf(r)>=0||(a[r]=e[r]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(n=0;n<i.length;n++)r=i[n],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(a[r]=e[r])}return a}var o=n.createContext({}),p=function(e){var t=n.useContext(o),r=t;return e&&(r="function"==typeof e?e(t):l(l({},t),e)),r},m=function(e){var t=p(e.components);return n.createElement(o.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},c=n.forwardRef((function(e,t){var r=e.components,a=e.mdxType,i=e.originalType,o=e.parentName,m=s(e,["components","mdxType","originalType","parentName"]),c=p(r),g=a,d=c["".concat(o,".").concat(g)]||c[g]||u[g]||i;return r?n.createElement(d,l(l({ref:t},m),{},{components:r})):n.createElement(d,l({ref:t},m))}));function g(e,t){var r=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var i=r.length,l=new Array(i);l[0]=c;var s={};for(var o in t)hasOwnProperty.call(t,o)&&(s[o]=t[o]);s.originalType=e,s.mdxType="string"==typeof e?e:a,l[1]=s;for(var p=2;p<i;p++)l[p]=r[p];return n.createElement.apply(null,l)}return n.createElement.apply(null,r)}c.displayName="MDXCreateElement"},8995:function(e,t,r){r.r(t),r.d(t,{frontMatter:function(){return s},contentTitle:function(){return o},metadata:function(){return p},toc:function(){return m},default:function(){return c}});var n=r(3117),a=r(102),i=(r(7294),r(3905)),l=["components"],s={title:"Interpretability - Image Explainers",hide_title:!0,status:"stable",url_path:"features/responsible_ai/Interpretability - Image Explainers",name:"Interpretability - Image Explainers"},o=void 0,p={unversionedId:"features/responsible_ai/Interpretability - Image Explainers",id:"version-0.9.4/features/responsible_ai/Interpretability - Image Explainers",title:"Interpretability - Image Explainers",description:"Interpretability - Image Explainers",source:"@site/versioned_docs/version-0.9.4/features/responsible_ai/Interpretability - Image Explainers.md",sourceDirName:"features/responsible_ai",slug:"/features/responsible_ai/Interpretability - Image Explainers",permalink:"/SynapseML/docs/0.9.4/features/responsible_ai/Interpretability - Image Explainers",tags:[],version:"0.9.4",frontMatter:{title:"Interpretability - Image Explainers",hide_title:!0,status:"stable",url_path:"features/responsible_ai/Interpretability - Image Explainers",name:"Interpretability - Image Explainers"},sidebar:"version-0.9.4/docs",previous:{title:"Interpretability - Explanation Dashboard",permalink:"/SynapseML/docs/0.9.4/features/responsible_ai/Interpretability - Explanation Dashboard"},next:{title:"Interpretability - Snow Leopard Detection",permalink:"/SynapseML/docs/0.9.4/features/responsible_ai/Interpretability - Snow Leopard Detection"}},m=[{value:"Interpretability - Image Explainers",id:"interpretability---image-explainers",children:[],level:2}],u={toc:m};function c(e){var t=e.components,r=(0,a.Z)(e,l);return(0,i.kt)("wrapper",(0,n.Z)({},u,r,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h2",{id:"interpretability---image-explainers"},"Interpretability - Image Explainers"),(0,i.kt)("p",null,"In this example, we use LIME and Kernel SHAP explainers to explain the ResNet50 model's multi-class output of an image."),(0,i.kt)("p",null,"First we import the packages and define some UDFs and a plotting function we will need later."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},"from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\nfrom synapse.ml.opencv import ImageTransformer\nfrom synapse.ml.io import *\nfrom pyspark.ml import Pipeline\nfrom pyspark.ml.classification import LogisticRegression\nfrom pyspark.ml.feature import StringIndexer\nfrom pyspark.sql.functions import *\nfrom pyspark.sql.types import *\nimport numpy as np\nimport pyspark\nimport urllib.request\nimport matplotlib.pyplot as plt\nimport PIL, io\nfrom PIL import Image\n\nvec_slice = udf(lambda vec, indices: (vec.toArray())[indices].tolist(), ArrayType(FloatType()))\narg_top_k = udf(lambda vec, k: (-vec.toArray()).argsort()[:k].tolist(), ArrayType(IntegerType()))\n\ndef downloadBytes(url: str):\n  with urllib.request.urlopen(url) as url:\n    barr = url.read()\n    return barr\n\ndef rotate_color_channel(bgr_image_array, height, width, nChannels):\n  B, G, R, *_ = np.asarray(bgr_image_array).reshape(height, width, nChannels).T\n  rgb_image_array = np.array((R, G, B)).T\n  return rgb_image_array\n    \ndef plot_superpixels(image_rgb_array, sp_clusters, weights, green_threshold=99):\n    superpixels = sp_clusters\n    green_value = np.percentile(weights, green_threshold)\n    img = Image.fromarray(image_rgb_array, mode='RGB').convert(\"RGBA\")\n    image_array = np.asarray(img).copy()\n    for (sp, v) in zip(superpixels, weights):\n        if v > green_value:\n            for (x, y) in sp:\n                image_array[y, x, 1] = 255\n                image_array[y, x, 3] = 200\n    plt.clf()\n    plt.imshow(image_array)\n    display()\n")),(0,i.kt)("p",null,"Create a dataframe for a testing image, and use the ResNet50 ONNX model to infer the image."),(0,i.kt)("p",null,'The result shows 39.6% probability of "violin" (889), and 38.4% probability of "upright piano" (881).'),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.io import *\n\nimage_df = spark.read.image().load("wasbs://publicwasb@mmlspark.blob.core.windows.net/explainers/images/david-lusvardi-dWcUncxocQY-unsplash.jpg")\ndisplay(image_df)\n\n# Rotate the image array from BGR into RGB channels for visualization later.\nrow = image_df.select("image.height", "image.width", "image.nChannels", "image.data").head()\nlocals().update(row.asDict())\nrgb_image_array = rotate_color_channel(data, height, width, nChannels)\n\n# Download the ONNX model\nmodelPayload = downloadBytes("https://mmlspark.blob.core.windows.net/publicwasb/ONNXModels/resnet50-v2-7.onnx")\n\nfeaturizer = (\n  ImageTransformer(inputCol="image", outputCol="features")\n      .resize(224, True)\n      .centerCrop(224, 224)\n      .normalize(mean=[0.485, 0.456, 0.406], std=[0.229, 0.224, 0.225], color_scale_factor = 1/255)\n      .setTensorElementType(FloatType())\n)\n\nonnx = (\n  ONNXModel()\n      .setModelPayload(modelPayload)\n      .setFeedDict({"data": "features"})\n      .setFetchDict({"rawPrediction": "resnetv24_dense0_fwd"})\n      .setSoftMaxDict({"rawPrediction": "probability"})\n      .setMiniBatchSize(1)\n)\n\nmodel = Pipeline(stages=[featurizer, onnx]).fit(image_df)\n')),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},'predicted = (\n    model.transform(image_df)\n      .withColumn("top2pred", arg_top_k(col("probability"), lit(2)))\n      .withColumn("top2prob", vec_slice(col("probability"), col("top2pred")))\n)\n\ndisplay(predicted.select("top2pred", "top2prob"))\n')),(0,i.kt)("p",null,"First we use the LIME image explainer to explain the model's top 2 classes' probabilities."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},'lime = (\n    ImageLIME()\n    .setModel(model)\n    .setOutputCol("weights")\n    .setInputCol("image")\n    .setCellSize(150.0)\n    .setModifier(50.0)\n    .setNumSamples(500)\n    .setTargetCol("probability")\n    .setTargetClassesCol("top2pred")\n    .setSamplingFraction(0.7)\n)\n\nlime_result = (\n    lime.transform(predicted)\n    .withColumn("weights_violin", col("weights").getItem(0))\n    .withColumn("weights_piano", col("weights").getItem(1))\n    .cache()\n)\n\ndisplay(lime_result.select(col("weights_violin"), col("weights_piano")))\nlime_row = lime_result.head()\n')),(0,i.kt)("p",null,'We plot the LIME weights for "violin" output and "upright piano" output.'),(0,i.kt)("p",null,"Green area are superpixels with LIME weights above 95 percentile."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},'plot_superpixels(rgb_image_array, lime_row["superpixels"]["clusters"], list(lime_row["weights_violin"]), 95)\nplot_superpixels(rgb_image_array, lime_row["superpixels"]["clusters"], list(lime_row["weights_piano"]), 95)\n')),(0,i.kt)("p",null,"Your results will look like:"),(0,i.kt)("img",{src:"https://mmlspark.blob.core.windows.net/graphics/explainers/image-lime-20210811.png"}),(0,i.kt)("p",null,"Then we use the Kernel SHAP image explainer to explain the model's top 2 classes' probabilities."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},'shap = (\n    ImageSHAP()\n    .setModel(model)\n    .setOutputCol("shaps")\n    .setSuperpixelCol("superpixels")\n    .setInputCol("image")\n    .setCellSize(150.0)\n    .setModifier(50.0)\n    .setNumSamples(500)\n    .setTargetCol("probability")\n    .setTargetClassesCol("top2pred")\n)\n\nshap_result = (\n    shap.transform(predicted)\n    .withColumn("shaps_violin", col("shaps").getItem(0))\n    .withColumn("shaps_piano", col("shaps").getItem(1))\n    .cache()\n)\n\ndisplay(shap_result.select(col("shaps_violin"), col("shaps_piano")))\nshap_row = shap_result.head()\n')),(0,i.kt)("p",null,'We plot the SHAP values for "piano" output and "cell" output.'),(0,i.kt)("p",null,"Green area are superpixels with SHAP values above 95 percentile."),(0,i.kt)("blockquote",null,(0,i.kt)("p",{parentName:"blockquote"},"Notice that we drop the base value from the SHAP output before rendering the superpixels. The base value is the model output for the background (all black) image.")),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},'plot_superpixels(rgb_image_array, shap_row["superpixels"]["clusters"], list(shap_row["shaps_violin"][1:]), 95)\nplot_superpixels(rgb_image_array, shap_row["superpixels"]["clusters"], list(shap_row["shaps_piano"][1:]), 95)\n')),(0,i.kt)("p",null,"Your results will look like:"),(0,i.kt)("img",{src:"https://mmlspark.blob.core.windows.net/graphics/explainers/image-shap-20210811.png"}))}c.isMDXComponent=!0}}]);