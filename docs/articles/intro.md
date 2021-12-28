Getting Started
===============

## 1. What is OpenCV.NET

OpenCV.NET is a .NET interface for the popular [OpenCV](https://opencv.org/) computer vision and image processing library. These bindings were developed from scratch over several years and include many features that have been missing from other attempts, specifically:

* Cross-platform compatibility with a .NET standard API (only P/Invoke is used).
* Very close to 100% support of the C API (including undocumented functions).
* Full documentation/intellisense for all supported methods, classes and enum members (arduously mined from many different sources).
* Support for exceptions.
* Garbage-collector friendly:
  * GC is aware of the actual memory used by matrices and images.
  * Pointers are guaranteed to survive function calls even if concurrent garbage collection happens.
* Object model following C++ API as much as possible (towards future increased support of C++ API).
* Permissive MIT license.

> [!Warning]
> The bindings currently target OpenCV 2.4.8. OpenCV has since moved towards a pure C++ API and has subsequently deprecated its C interface, which means we cannot easily access new features. We are currently exploring different alternatives to generate a comprehensive high-quality wrapper for newer versions of OpenCV, but for now OpenCV.Net will keep targeting the 2.4.x series.

## 2. Installing OpenCV.NET

The easiest way to start using OpenCV.NET in your projects is to install the [NuGet package](https://www.nuget.org/packages/OpenCV.Net) from one of the following sources:
  * **.NET Command-line**: `dotnet add package OpenCV.NET`.
  * **Powershell**: From the NuGet Package Manager Console, type `Install-Package OpenCV.Net`.
  * **PackageReference**: Add the line `<PackageReference Include="OpenCV.Net" Version="3.3.1" />` to your `.csproj` file.

> [!Important]
> **Prerequisites** The [Visual C++ Redistributable for Visual Studio 2012](https://www.microsoft.com/en-us/download/details.aspx?id=30679) may be required on Windows systems to correcty load native dependencies.

