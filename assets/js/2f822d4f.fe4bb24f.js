"use strict";(self.webpackChunksynapseml=self.webpackChunksynapseml||[]).push([[8817],{3905:function(e,t,n){n.d(t,{Zo:function(){return m},kt:function(){return f}});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function o(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function s(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?o(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):o(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},o=Object.keys(e);for(r=0;r<o.length;r++)n=o[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(r=0;r<o.length;r++)n=o[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var i=r.createContext({}),p=function(e){var t=r.useContext(i),n=t;return e&&(n="function"==typeof e?e(t):s(s({},t),e)),n},m=function(e){var t=p(e.components);return r.createElement(i.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},c=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,o=e.originalType,i=e.parentName,m=l(e,["components","mdxType","originalType","parentName"]),c=p(n),f=a,d=c["".concat(i,".").concat(f)]||c[f]||u[f]||o;return n?r.createElement(d,s(s({ref:t},m),{},{components:n})):r.createElement(d,s({ref:t},m))}));function f(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var o=n.length,s=new Array(o);s[0]=c;var l={};for(var i in t)hasOwnProperty.call(t,i)&&(l[i]=t[i]);l.originalType=e,l.mdxType="string"==typeof e?e:a,s[1]=l;for(var p=2;p<o;p++)s[p]=n[p];return r.createElement.apply(null,s)}return r.createElement.apply(null,n)}c.displayName="MDXCreateElement"},2905:function(e,t,n){n.r(t),n.d(t,{assets:function(){return m},contentTitle:function(){return i},default:function(){return f},frontMatter:function(){return l},metadata:function(){return p},toc:function(){return u}});var r=n(3117),a=n(102),o=(n(7294),n(3905)),s=["components"],l={title:"DeepLearning - Flower Image Classification",hide_title:!0,status:"stable"},i=void 0,p={unversionedId:"features/other/DeepLearning - Flower Image Classification",id:"version-0.9.4/features/other/DeepLearning - Flower Image Classification",title:"DeepLearning - Flower Image Classification",description:"Deep Learning - Flower Image Classification",source:"@site/versioned_docs/version-0.9.4/features/other/DeepLearning - Flower Image Classification.md",sourceDirName:"features/other",slug:"/features/other/DeepLearning - Flower Image Classification",permalink:"/SynapseML/docs/0.9.4/features/other/DeepLearning - Flower Image Classification",tags:[],version:"0.9.4",frontMatter:{title:"DeepLearning - Flower Image Classification",hide_title:!0,status:"stable"},sidebar:"version-0.9.4/docs",previous:{title:"DeepLearning - CIFAR10 Convolutional Network",permalink:"/SynapseML/docs/0.9.4/features/other/DeepLearning - CIFAR10 Convolutional Network"},next:{title:"DeepLearning - Transfer Learning",permalink:"/SynapseML/docs/0.9.4/features/other/DeepLearning - Transfer Learning"}},m={},u=[{value:"Deep Learning - Flower Image Classification",id:"deep-learning---flower-image-classification",level:2},{value:"How does it work?",id:"how-does-it-work",level:3},{value:"Run the experiment",id:"run-the-experiment",level:3},{value:"Plot confusion matrix.",id:"plot-confusion-matrix",level:3}],c={toc:u};function f(e){var t=e.components,n=(0,a.Z)(e,s);return(0,o.kt)("wrapper",(0,r.Z)({},c,n,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h2",{id:"deep-learning---flower-image-classification"},"Deep Learning - Flower Image Classification"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},"from pyspark.ml import Transformer, Estimator, Pipeline\nfrom pyspark.ml.classification import LogisticRegression\nfrom synapse.ml.downloader import ModelDownloader\nimport os, sys, time\n")),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'model = ModelDownloader(spark, "dbfs:/models/").downloadByName("ResNet50")\n')),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'# Load the images\n# use flowers_and_labels.parquet on larger cluster in order to get better results\nimagesWithLabels = spark.read.parquet("wasbs://publicwasb@mmlspark.blob.core.windows.net/flowers_and_labels2.parquet") \\\n    .withColumnRenamed("bytes","image").sample(.1)\n\nimagesWithLabels.printSchema()\n')),(0,o.kt)("p",null,(0,o.kt)("img",{parentName:"p",src:"https://i.imgur.com/p2KgdYL.jpg",alt:"Smiley face"})),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.opencv import ImageTransformer\nfrom synapse.ml.image import UnrollImage\nfrom synapse.ml.cntk import ImageFeaturizer\nfrom synapse.ml.stages import *\n\n# Make some featurizers\nit = ImageTransformer()\\\n    .setOutputCol("scaled")\\\n    .resize(size=(60, 60))\n\nur = UnrollImage()\\\n    .setInputCol("scaled")\\\n    .setOutputCol("features")\n\ndc1 = DropColumns().setCols(["scaled", "image"])\n\nlr1 = LogisticRegression().setMaxIter(8).setFeaturesCol("features").setLabelCol("labels")\n\ndc2 = DropColumns().setCols(["features"])\n\nbasicModel = Pipeline(stages=[it, ur, dc1, lr1, dc2])\n')),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'resnet = ImageFeaturizer()\\\n    .setInputCol("image")\\\n    .setOutputCol("features")\\\n    .setModelLocation(model.uri)\\\n    .setLayerNames(model.layerNames)\\\n    .setCutOutputLayers(1)\n\ndc3 = DropColumns().setCols(["image"])\n\nlr2 = LogisticRegression().setMaxIter(8).setFeaturesCol("features").setLabelCol("labels")\n\ndc4 = DropColumns().setCols(["features"])\n\ndeepModel = Pipeline(stages=[resnet, dc3, lr2, dc4])\n')),(0,o.kt)("p",null,(0,o.kt)("img",{parentName:"p",src:"https://i.imgur.com/Mb4Dyou.png",alt:"Resnet 18"})),(0,o.kt)("h3",{id:"how-does-it-work"},"How does it work?"),(0,o.kt)("p",null,(0,o.kt)("img",{parentName:"p",src:"http://i.stack.imgur.com/Hl2H6.png",alt:"Convolutional network weights"})),(0,o.kt)("h3",{id:"run-the-experiment"},"Run the experiment"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'def timedExperiment(model, train, test):\n  start = time.time()\n  result =  model.fit(train).transform(test).toPandas()\n  print("Experiment took {}s".format(time.time() - start))\n  return result\n')),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},"train, test = imagesWithLabels.randomSplit([.8,.2])\ntrain.count(), test.count()\n")),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},"basicResults = timedExperiment(basicModel, train, test)\n")),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},"deepResults = timedExperiment(deepModel, train, test)\n")),(0,o.kt)("h3",{id:"plot-confusion-matrix"},"Plot confusion matrix."),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'import matplotlib.pyplot as plt\nfrom sklearn.metrics import confusion_matrix\nimport numpy as np\n\ndef evaluate(results, name):\n    y, y_hat = results["labels"],results["prediction"]\n    y = [int(l) for l in y]\n\n    accuracy = np.mean([1. if pred==true else 0. for (pred,true) in zip(y_hat,y)])\n    cm = confusion_matrix(y, y_hat)\n    cm = cm.astype("float") / cm.sum(axis=1)[:, np.newaxis]\n\n    plt.text(40, 10,"$Accuracy$ $=$ ${}\\%$".format(round(accuracy*100,1)),fontsize=14)\n    plt.imshow(cm, interpolation="nearest", cmap=plt.cm.Blues)\n    plt.colorbar()\n    plt.xlabel("$Predicted$ $label$", fontsize=18)\n    plt.ylabel("$True$ $Label$", fontsize=18)\n    plt.title("$Normalized$ $CM$ $for$ ${}$".format(name))\n\nplt.figure(figsize=(12,5))\nplt.subplot(1,2,1)\nevaluate(deepResults,"CNTKModel + LR")\nplt.subplot(1,2,2)\nevaluate(basicResults,"LR")\n# Note that on the larger dataset the accuracy will bump up from 44% to >90%\ndisplay(plt.show())\n')))}f.isMDXComponent=!0}}]);