## Sai Nishanth Vaka



import glob
import os

from setuptools import setup

package_name = 'unity_intergration'

setup(
    name=package_name,
    version='0.0.1',
    packages=[],
    data_files=[

        (os.path.join('share', package_name), [
                                                # 'rviz/nav.rviz',
                                                'launch/run.py',
                                                'launch/visual.py'
                                                ])
    ],
    install_requires=['setuptools']
)

if __name__ == '__main__':
    a = 2
