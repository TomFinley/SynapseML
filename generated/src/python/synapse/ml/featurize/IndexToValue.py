# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.


import sys
if sys.version >= '3':
    basestring = str

from pyspark import SparkContext, SQLContext
from pyspark.sql import DataFrame
from pyspark.ml.param.shared import *
from pyspark import keyword_only
from pyspark.ml.util import JavaMLReadable, JavaMLWritable
from synapse.ml.core.serialize.java_params_patch import *
from pyspark.ml.wrapper import JavaTransformer, JavaEstimator, JavaModel
from pyspark.ml.evaluation import JavaEvaluator
from pyspark.ml.common import inherit_doc
from synapse.ml.core.schema.Utils import *
from pyspark.ml.param import TypeConverters
from synapse.ml.core.schema.TypeConversionUtils import generateTypeConverter, complexTypeConverter
from py4j.java_collections import SetConverter, MapConverter, ListConverter
from typing import List, Optional


@inherit_doc
class IndexToValue(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        inputCol (str): The name of the input column
        outputCol (str): The name of the output column
    """

    inputCol = Param(Params._dummy(), "inputCol", "The name of the input column", typeConverter=TypeConverters.toString)
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        inputCol=None,
        outputCol=None
        ):
        super(IndexToValue, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.featurize.IndexToValue", self.uid)
        else:
            self._java_obj = java_obj
        
        if hasattr(self, "_input_kwargs"):
            kwargs = self._input_kwargs
        else:
            kwargs = self.__init__._input_kwargs
    
        if java_obj is None:
            for k,v in kwargs.items():
                if v is not None:
                    getattr(self, "set" + k[0].upper() + k[1:])(v)

    @keyword_only
    def setParams(
        self,
        inputCol=None,
        outputCol=None
        ):
        """
        Set the (keyword only) parameters
        """
        if hasattr(self, "_input_kwargs"):
            kwargs = self._input_kwargs
        else:
            kwargs = self.__init__._input_kwargs
        return self._set(**kwargs)

    @classmethod
    def read(cls):
        """ Returns an MLReader instance for this class. """
        return JavaMMLReader(cls)

    @staticmethod
    def getJavaPackage():
        """ Returns package name String. """
        return "com.microsoft.azure.synapse.ml.featurize.IndexToValue"

    @staticmethod
    def _from_java(java_stage):
        module_name=IndexToValue.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".IndexToValue"
        return from_java(java_stage, module_name)

    def setInputCol(self, value):
        """
        Args:
            inputCol: The name of the input column
        """
        self._set(inputCol=value)
        return self
    
    def setOutputCol(self, value):
        """
        Args:
            outputCol: The name of the output column
        """
        self._set(outputCol=value)
        return self

    
    def getInputCol(self):
        """
        Returns:
            inputCol: The name of the input column
        """
        return self.getOrDefault(self.inputCol)
    
    
    def getOutputCol(self):
        """
        Returns:
            outputCol: The name of the output column
        """
        return self.getOrDefault(self.outputCol)

    

    
    
        