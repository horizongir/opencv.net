using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    struct _IplImage
    {
        public int nSize;
        public int ID;
        public int nChannels;
        public int alphaChannel;
        public IplDepth depth;
        public byte colorModel0;
        public byte colorModel1;
        public byte colorModel2;
        public byte colorModel3;
        public byte channelSeq0;
        public byte channelSeq1;
        public byte channelSeq2;
        public byte channelSeq3;
        public int dataOrder;
        public int origin;
        public int align;
        public int width;
        public int height;
        public IntPtr roi;
        public IntPtr maskROI;
        public IntPtr imageId;
        public IntPtr tileInfo;
        public int imageSize;
        public IntPtr imageData;
        public int widthStep;
        public int BorderMode0;
        public int BorderMode1;
        public int BorderMode2;
        public int BorderMode3;
        public int BorderConst0;
        public int BorderConst1;
        public int BorderConst2;
        public int BorderConst3;
        public IntPtr imageDataOrigin;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvMat
    {
        public int type;
        public int step;
        public IntPtr refcount;
        public int hdr_refcount;
        public IntPtr data;
        public int rows;
        public int cols;
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct _CvMatND
    {
        public int type;
        public int dims;
        public IntPtr refcount;
        public int hdr_refcount;
        public IntPtr data;
        public fixed long dim[MatHelper.MaxDim];
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct _CvSparseMat
    {
        public int type;
        public int dims;
        public IntPtr refcount;
        public int hdr_refcount;
        public IntPtr heap;
        public IntPtr* hashtable;
        public int hashsize;
        public int valoffset;
        public int idxoffset;
        public fixed int size[MatHelper.MaxDim];
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct _CvSparseNode
    {
        public uint hashval;
        public _CvSparseNode* next;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvSparseMatIterator
    {
        unsafe public _CvSparseMat* mat;
        unsafe public _CvSparseNode* node;
        public int curidx;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvSeq
    {
        public int flags;
        public int header_size;
        public IntPtr h_prev;
        public IntPtr h_next;
        public IntPtr v_prev;
        public IntPtr v_next;
        public int total;
        public int elem_size;
        public IntPtr block_max;
        public IntPtr ptr;
        public int delta_elems;
        public IntPtr storage;
        public IntPtr free_blocks;
        public IntPtr first;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvSet
    {
        public int flags;
        public int header_size;
        public IntPtr h_prev;
        public IntPtr h_next;
        public IntPtr v_prev;
        public IntPtr v_next;
        public int total;
        public int elem_size;
        public IntPtr block_max;
        public IntPtr ptr;
        public int delta_elems;
        public IntPtr storage;
        public IntPtr free_blocks;
        public IntPtr first;

        public IntPtr free_elems;
        public int active_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvGraph
    {
        public int flags;
        public int header_size;
        public IntPtr h_prev;
        public IntPtr h_next;
        public IntPtr v_prev;
        public IntPtr v_next;
        public int total;
        public int elem_size;
        public IntPtr block_max;
        public IntPtr ptr;
        public int delta_elems;
        public IntPtr storage;
        public IntPtr free_blocks;
        public IntPtr first;

        public IntPtr free_elems;
        public int active_count;

        public IntPtr edges;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvChain
    {
        public int flags;
        public int header_size;
        public IntPtr h_prev;
        public IntPtr h_next;
        public IntPtr v_prev;
        public IntPtr v_next;
        public int total;
        public int elem_size;
        public IntPtr block_max;
        public IntPtr ptr;
        public int delta_elems;
        public IntPtr storage;
        public IntPtr free_blocks;
        public IntPtr first;

        public CvPoint origin;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvContour
    {
        public int flags;
        public int header_size;
        public IntPtr h_prev;
        public IntPtr h_next;
        public IntPtr v_prev;
        public IntPtr v_next;
        public int total;
        public int elem_size;
        public IntPtr block_max;
        public IntPtr ptr;
        public int delta_elems;
        public IntPtr storage;
        public IntPtr free_blocks;
        public IntPtr first;

        public CvRect rect;
        public int color;
        public int reserved0;
        public int reserved1;
        public int reserved2;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvString
    {
        public int Len;
        public IntPtr Ptr;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvLineIterator
    {
        public IntPtr ptr;
        public int err;
        public int plus_delta;
        public int minus_delta;
        public int plus_step;
        public int minus_step;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvFont
    {
        IntPtr nameFont;
        CvScalar color;
        int font_face;
        IntPtr ascii;
        IntPtr greek;
        IntPtr cyrillic;
        float hscale, vscale;
        float shear;
        int thickness;
        float dx;
        int line_type;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int CvCmpFunc(IntPtr a, IntPtr b, IntPtr userdata);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    delegate int CvErrorCallback(int status, string func_name, string err_msg, string file_name, int line, IntPtr userData);

    static class MatHelper
    {
        internal const int MaxDim = 32;
        internal const int MaxChannels = 512;
        internal const int ChannelShift = 3;
        internal const int DepthMax = 1 << ChannelShift;
        internal const int DepthMask = DepthMax - 1;

        internal static int GetMatType(CvDepth depth, int channels)
        {
            return ((int)depth & DepthMask) + ((channels - 1) << ChannelShift);
        }

        internal static CvDepth GetMatDepth(int type)
        {
            return (CvDepth)(type & DepthMask);
        }

        internal static int GetMatChannels(int type)
        {
            return ((type >> ChannelShift) & (MaxChannels - 1)) + 1;
        }

        internal static int GetElemSize1(int type)
        {
            return ((((Marshal.SizeOf(typeof(UIntPtr)) << 28) | 0x8442211) >> (type & DepthMask) * 4) & 15);
        }

        internal static int GetElemSize(int type)
        {
            return (GetMatChannels(type) << ((((Marshal.SizeOf(typeof(UIntPtr)) / 4 + 1) * 16384 | 0x3a50) >> (int)GetMatDepth(type) * 2) & 3));
        }
    }

    static class SeqHelper
    {
        internal const int ElementTypeBits = 12;
        internal const int KindBits = 2;
        internal const int KindMask = (((1 << KindBits) - 1) << ElementTypeBits);
        internal const int FlagShift = KindBits + ElementTypeBits;
        internal const int FlagMask = ~((1 << FlagShift) - 1);

        internal static readonly UIntPtr SeqHeaderSize = (UIntPtr)Marshal.SizeOf(typeof(_CvSeq));
        internal static readonly int SetHeaderSize = Marshal.SizeOf(typeof(_CvSet));
        internal static readonly int GraphHeaderSize = Marshal.SizeOf(typeof(_CvGraph));
    }
}
