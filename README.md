# OpenCV.NET

OpenCV.NET is a .NET interface for the popular [OpenCV](https://opencv.org/) computer vision and image processing library. These bindings were developed over the course of a year and include many features that have been missing from other attempts, namely:

* Cross-platform Mono compatibility (only P/Invoke is used)
* Very close to 100% support of the latest C API (including undocumented functions)
* Full documentation/intellisense for all supported methods, classes and enum members (arduously mined from many different sources)
* Support for exceptions
* Garbage-collector friendly:
    * GC is aware of the actual memory used by matrices and images
    * Pointers are guaranteed to survive function calls even if concurrent garbage collection happens
* Object model following C++ API as much as possible (towards future increased support of C++ API)
* BSD-style license (MIT)

## How to build

OpenCV.NET includes native runtime package projects which depend on the official OpenCV redistributable binaries. These are downloaded and installed automatically by the `build.ps1` file. Assuming a Windows system, to build the project with full runtime packages:

### PowerShell
```powershell
./build.ps1
```

### Command-line
```
powershell ./build.ps1
```