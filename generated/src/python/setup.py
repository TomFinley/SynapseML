
# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.

import os
from setuptools import setup, find_namespace_packages
import codecs
import os.path

setup(
    name="synapseml-vw",
    version="0.10.0.dev1",
    description="Synapse Machine Learning",
    long_description="SynapseML contains Microsoft's open source "
                     + "contributions to the Apache Spark ecosystem",
    license="MIT",
    packages=find_namespace_packages(include=['synapse.ml.*']) ,
    url="https://github.com/Microsoft/SynapseML",
    author="Microsoft",
    author_email="synapseml-support@microsoft.com",
    classifiers=[
        "Development Status :: 4 - Beta",
        "Intended Audience :: Developers",
        "Intended Audience :: Science/Research",
        "Topic :: Software Development :: Libraries",
        "License :: OSI Approved :: MIT License",
        "Programming Language :: Python :: 2",
        "Programming Language :: Python :: 3",
    ],
    zip_safe=True,
    package_data={"synapseml": ["../LICENSE.txt", "../README.txt"]},
)

