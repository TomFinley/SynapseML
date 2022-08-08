# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.


"""
SynapseML is an ecosystem of tools aimed towards expanding the distributed computing framework
Apache Spark in several new directions. SynapseML adds many deep learning and data science tools to the Spark
ecosystem, including seamless integration of Spark Machine Learning pipelines with
Microsoft Cognitive Toolkit (CNTK), LightGBM and OpenCV. These tools enable powerful and
highly-scalable predictive and analytical models for a variety of datasources.

SynapseML also brings new networking capabilities to the Spark Ecosystem. With the HTTP on Spark project,
users can embed any web service into their SparkML models. In this vein, SynapseML provides easy to use SparkML
transformers for a wide variety of Microsoft Cognitive Services. For production grade deployment,
the Spark Serving project enables high throughput, sub-millisecond latency web services,
backed by your Spark cluster.

SynapseML requires Scala 2.12, Spark 3.0+, and Python 3.6+.
"""

__version__ = "0.10.0.dev1"
__spark_package_version__ = "0.10.0-1-db95a104-SNAPSHOT"

from synapse.ml.recommendation.RankingAdapter import *
from synapse.ml.recommendation.RankingAdapterModel import *
from synapse.ml.recommendation.RankingEvaluator import *
from synapse.ml.recommendation.RankingTrainValidationSplit import *
from synapse.ml.recommendation.RankingTrainValidationSplitModel import *
from synapse.ml.recommendation.RecommendationIndexer import *
from synapse.ml.recommendation.RecommendationIndexerModel import *
from synapse.ml.recommendation.SAR import *
from synapse.ml.recommendation.SARModel import *

