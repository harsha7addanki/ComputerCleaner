# File for setup if works on my machine because I set the path to python310
# CHANGE IT IF YOU USE ANOTHER VERSION

print("Loading dependencies...")
from distutils._msvccompiler import MSVCCompiler    # "from distutils.msvccompiler" did not work for me!
from os import system
from Cython.Build import cythonize
print("Transpiling...")
system("py cython_freeze.py main tempfilecleaner -o build/cc.c")
cythonize([
    "tempfilecleaner.pyx",
    "main.pyx"
], build_dir="build")
print("Compiling...")
compiler = MSVCCompiler()

compiler.initialize()
compiler.compile(["build/cc.c"], include_dirs=["C:/Program Files/Python310/include"])
compiler.compile(["build/tempfilecleaner.c"], include_dirs=["C:/Program Files/Python310/include"])
compiler.compile(["build/main.c"], include_dirs=["C:/Program Files/Python310/include"])
print("Linking...")

compiler.link_executable([
    "build/cc.obj",
    "build/tempfilecleaner.obj",
    "build/main.obj",
], "cc", libraries=["python310"], library_dirs=["C:/Program Files/Python310/libs"], output_dir="build", extra_preargs=["/NOIMPLIB", "/NOEXP", "/ENTRY:wmainCRTStartup", "/subsystem:windows"]) # For development remove "/subsystem:windows" because it remove the console
print("Done")