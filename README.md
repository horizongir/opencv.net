OpenCV.NET is a .NET interface for the popular OpenCV computer vision and image processing library. These bindings were developed over the course of a year and include many features that have been missing from other attempts, namely:

* Very close to 100% support of the latest C API (including undocumented functions)
* Full documentation/intellisense for all supported methods, classes and enum members (arduously mined from many different sources)
* Support for exceptions
* Garbage-collector friendly:
    * GC is aware of the actual memory used by matrices and images
    * Pointers are guaranteed to survive function calls even if concurrent garbage collection happens
* Object model following C++ API as much as possible (towards future increased support of C++ API)
* BSD-style license (MIT)