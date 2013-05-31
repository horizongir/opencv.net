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

    delegate int CvErrorCallback(int status, string func_name, string err_msg, string file_name, int line, IntPtr userData);

    static class MatHelper
    {
        internal const int MaxDim = 32;
        internal const int MaxChannels = 512;
        internal const int ChannelShift = 3;
        internal const int DepthMax = 1 << ChannelShift;
        internal const int DepthMask = DepthMax - 1;

        internal static int GetMatType(CvMatDepth depth, int channels)
        {
            return ((int)depth & DepthMask) + ((channels - 1) << ChannelShift);
        }

        internal static CvMatDepth GetMatDepth(int type)
        {
            return (CvMatDepth)(type & DepthMask);
        }

        internal static int GetMatNumChannels(int type)
        {
            return ((type >> ChannelShift) & (MaxChannels - 1)) + 1;
        }

        internal static int GetElemSize(int type)
        {
            return ((((Marshal.SizeOf(typeof(UIntPtr)) << 28) | 0x8442211) >> (type & DepthMask) * 4) & 15);
        }
    }
}
