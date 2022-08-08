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


@inherit_doc
class ImageSetAugmenter(ComplexParamsMixin, JavaMLReadable, JavaMLWritable, JavaTransformer):
    """
    Args:
        flipLeftRight (bool): Symmetric Left-Right
        flipUpDown (bool): Symmetric Up-Down
        inputCol (str): The name of the input column
        outputCol (str): The name of the output column
    """

    flipLeftRight = Param(Params._dummy(), "flipLeftRight", "Symmetric Left-Right", typeConverter=TypeConverters.toBoolean)
    
    flipUpDown = Param(Params._dummy(), "flipUpDown", "Symmetric Up-Down", typeConverter=TypeConverters.toBoolean)
    
    inputCol = Param(Params._dummy(), "inputCol", "The name of the input column", typeConverter=TypeConverters.toString)
    
    outputCol = Param(Params._dummy(), "outputCol", "The name of the output column", typeConverter=TypeConverters.toString)

    
    @keyword_only
    def __init__(
        self,
        java_obj=None,
        flipLeftRight=True,
        flipUpDown=False,
        inputCol="image",
        outputCol="ImageSetAugmenter_b4e6a4da48ee_output"
        ):
        super(ImageSetAugmenter, self).__init__()
        if java_obj is None:
            self._java_obj = self._new_java_obj("com.microsoft.azure.synapse.ml.opencv.ImageSetAugmenter", self.uid)
        else:
            self._java_obj = java_obj
        self._setDefault(flipLeftRight=True)
        self._setDefault(flipUpDown=False)
        self._setDefault(inputCol="image")
        self._setDefault(outputCol="ImageSetAugmenter_b4e6a4da48ee_output")
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
        flipLeftRight=True,
        flipUpDown=False,
        inputCol="image",
        outputCol="ImageSetAugmenter_b4e6a4da48ee_output"
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
        return "com.microsoft.azure.synapse.ml.opencv.ImageSetAugmenter"

    @staticmethod
    def _from_java(java_stage):
        module_name=ImageSetAugmenter.__module__
        module_name=module_name.rsplit(".", 1)[0] + ".ImageSetAugmenter"
        return from_java(java_stage, module_name)

    def setFlipLeftRight(self, value):
        """
        Args:
            flipLeftRight: Symmetric Left-Right
        """
        self._set(flipLeftRight=value)
        return self
    
    def setFlipUpDown(self, value):
        """
        Args:
            flipUpDown: Symmetric Up-Down
        """
        self._set(flipUpDown=value)
        return self
    
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

    
    def getFlipLeftRight(self):
        """
        Returns:
            flipLeftRight: Symmetric Left-Right
        """
        return self.getOrDefault(self.flipLeftRight)
    
    
    def getFlipUpDown(self):
        """
        Returns:
            flipUpDown: Symmetric Up-Down
        """
        return self.getOrDefault(self.flipUpDown)
    
    
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

    

    
        