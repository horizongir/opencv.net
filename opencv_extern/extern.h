#pragma once

#include "opencv2\opencv.hpp"

#if (defined WIN32 || defined _WIN32 || defined WINCE) && defined OPENCV_EXTERN_EXPORTS
#  define CVEXTERN_EXPORTS __declspec(dllexport)
#else
#  define CVEXTERN_EXPORTS
#endif

#ifndef CVEXTERN
#  define CVEXTERN(rettype) CV_EXTERN_C CVEXTERN_EXPORTS rettype CV_CDECL
#endif

template<class T>
inline static T empty(T *obj)
{
	return (obj != NULL) ? *obj : T();
}
