using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string externLib = "opencv_extern" + libSuffix;

        #region Vector<int>

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_int_new();

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_int_new_array([In]int[] data, IntPtr length);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_int_size(Int32Collection vector);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_int_copy(Int32Collection vector, [Out]int[] data);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_int_iterator_new(Int32Collection vector);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cv_vector_int_iterator_next(IntPtr iterator);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool cv_vector_int_iterator_hasNext(IntPtr iterator);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_int_iterator_delete(IntPtr iterator);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_int_delete(IntPtr vector);

        #endregion

        #region Vector<Point2f>

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_Point2f_new();

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_Point2f_new_array([In]Point2f[] data, IntPtr length);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_Point2f_size(Point2fCollection vector);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_Point2f_copy(Point2fCollection vector, [Out]Point2f[] data);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_Point2f_iterator_new(Point2fCollection vector);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Point2f cv_vector_Point2f_iterator_next(IntPtr iterator);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool cv_vector_Point2f_iterator_hasNext(IntPtr iterator);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_Point2f_iterator_delete(IntPtr iterator);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_Point2f_delete(IntPtr vector);

        #endregion

        #region Vector<KeyPoint>

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_KeyPoint_new();

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_KeyPoint_new_array([In]KeyPoint[] data, IntPtr length);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_KeyPoint_size(KeyPointCollection vector);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_KeyPoint_copy(KeyPointCollection vector, [Out]KeyPoint[] data);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_vector_KeyPoint_iterator_new(KeyPointCollection vector);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern KeyPoint cv_vector_KeyPoint_iterator_next(IntPtr iterator);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool cv_vector_KeyPoint_iterator_hasNext(IntPtr iterator);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_KeyPoint_iterator_delete(IntPtr iterator);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_vector_KeyPoint_delete(IntPtr vector);

        #endregion
    }
}
