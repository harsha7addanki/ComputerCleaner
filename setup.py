# File for setup if works on my machine because I set the path to python310
# CHANGE IT IF YOU USE ANOTHER VERSION

print("Loading dependencies...")
from distutils._msvccompiler import MSVCCompiler    # "from distutils.msvccompiler" did not work for me!
from Cython.Compiler import Options
from Cython.Build import cythonize

print("Transpiling...")
Options.embed = "main"
cythonize(r'main.pyx', build_dir="build")

print("Compiling...")
compiler = MSVCCompiler()
compiler.compile([r"build\main.c"], include_dirs=["C:/Program Files/Python310/include"])
print("Linking...")
compiler.link_executable([r"build\main.obj"], "app", libraries=["python310"], library_dirs=["C:/Program Files/Python310/libs"], output_dir="build", extra_preargs=["/NOIMPLIB", "/NOEXP"])