using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    [Flags]
    public enum SubPixelInterpolation : int
    {
        NearestNeighbor = 0,
        Linear = 1,
        Cubic = 2,
        Area = 3,
        Lanczos4 = 4
    }

    [Flags]
    public enum WarpFlags : int
    {
        NearestNeighbor = 0,
        Linear = 1,
        Cubic = 2,
        Area = 3,
        Lanczos4 = 4,
        FillOutliers = 8,
        InverseMap = 16
    }

    public enum HistogramType : int
    {
        Array = 0,
        Sparse = 1,
        Tree = Sparse
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvMoments
    {
        public double m00, m10, m01, m20, m11, m02, m30, m21, m12, m03; /* spatial moments */
        public double mu20, mu11, mu02, mu30, mu21, mu12, mu03; /* central moments */
        public double inv_sqrt_m00; /* m00 != 0 ? 1/sqrt(m00) : 0 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvConnectedComp
    {
        public double area;    /* area of the segmented component */
        public CvScalar value; /* average color of the connected component */
        public CvRect rect;    /* ROI of the segmented component */
        public IntPtr contour; /* optional component boundary
                                  (the contour might have child contours corresponding to the holes) */
    }

    public enum ContourRetrieval : int
    {
        External = 0,
        List = 1,
        CComp = 2,
        Tree = 3
    }

    public enum ContourApproximation : int
    {
        CHAIN_CODE = 0,
        CHAIN_APPROX_NONE = 1,
        CHAIN_APPROX_SIMPLE = 2,
        CHAIN_APPROX_TC89_L1 = 3,
        CHAIN_APPROX_TC89_KCOS = 4,
        LINK_RUNS = 5
    }

    public enum AdaptiveThresholdMethod : int
    {
        MEAN_C = 0,
        GAUSSIAN_C = 1
    }

    public enum ThresholdType : int
    {
        Binary = 0,  /* value = value > threshold ? max_value : 0       */
        BinaryInv = 1,  /* value = value > threshold ? 0 : max_value       */
        Truncate = 2,  /* value = value > threshold ? threshold : value   */
        ToZero = 3,  /* value = value > threshold ? value : 0           */
        ToZeroInv = 4,  /* value = value > threshold ? 0 : value           */
        //Mask = 7,     /* Figure out what it does */
        Otsu = 8  /* use Otsu algorithm to choose the optimal threshold value;
                                 combine the flag with one of the above * values */
    }

    public enum ColorConversion : int
    {
        BGR2BGRA = 0,
        RGB2RGBA = BGR2BGRA,

        BGRA2BGR = 1,
        RGBA2RGB = BGRA2BGR,

        BGR2RGBA = 2,
        RGB2BGRA = BGR2RGBA,

        RGBA2BGR = 3,
        BGRA2RGB = RGBA2BGR,

        BGR2RGB = 4,
        RGB2BGR = BGR2RGB,

        BGRA2RGBA = 5,
        RGBA2BGRA = BGRA2RGBA,

        BGR2GRAY = 6,
        RGB2GRAY = 7,
        GRAY2BGR = 8,
        GRAY2RGB = GRAY2BGR,
        GRAY2BGRA = 9,
        GRAY2RGBA = GRAY2BGRA,
        BGRA2GRAY = 10,
        RGBA2GRAY = 11,

        BGR2BGR565 = 12,
        RGB2BGR565 = 13,
        BGR5652BGR = 14,
        BGR5652RGB = 15,
        BGRA2BGR565 = 16,
        RGBA2BGR565 = 17,
        BGR5652BGRA = 18,
        BGR5652RGBA = 19,

        GRAY2BGR565 = 20,
        BGR5652GRAY = 21,

        BGR2BGR555 = 22,
        RGB2BGR555 = 23,
        BGR5552BGR = 24,
        BGR5552RGB = 25,
        BGRA2BGR555 = 26,
        RGBA2BGR555 = 27,
        BGR5552BGRA = 28,
        BGR5552RGBA = 29,

        GRAY2BGR555 = 30,
        BGR5552GRAY = 31,

        BGR2XYZ = 32,
        RGB2XYZ = 33,
        XYZ2BGR = 34,
        XYZ2RGB = 35,

        BGR2YCrCb = 36,
        RGB2YCrCb = 37,
        YCrCb2BGR = 38,
        YCrCb2RGB = 39,

        BGR2HSV = 40,
        RGB2HSV = 41,

        BGR2Lab = 44,
        RGB2Lab = 45,

        BayerBG2BGR = 46,
        BayerGB2BGR = 47,
        BayerRG2BGR = 48,
        BayerGR2BGR = 49,

        BayerBG2RGB = BayerRG2BGR,
        BayerGB2RGB = BayerGR2BGR,
        BayerRG2RGB = BayerBG2BGR,
        BayerGR2RGB = BayerGB2BGR,

        BGR2Luv = 50,
        RGB2Luv = 51,
        BGR2HLS = 52,
        RGB2HLS = 53,

        HSV2BGR = 54,
        HSV2RGB = 55,

        Lab2BGR = 56,
        Lab2RGB = 57,
        Luv2BGR = 58,
        Luv2RGB = 59,
        HLS2BGR = 60,
        HLS2RGB = 61,

        BayerBG2BGR_VNG = 62,
        BayerGB2BGR_VNG = 63,
        BayerRG2BGR_VNG = 64,
        BayerGR2BGR_VNG = 65,

        BayerBG2RGB_VNG = BayerRG2BGR_VNG,
        BayerGB2RGB_VNG = BayerGR2BGR_VNG,
        BayerRG2RGB_VNG = BayerBG2BGR_VNG,
        BayerGR2RGB_VNG = BayerGB2BGR_VNG,

        BGR2HSV_FULL = 66,
        RGB2HSV_FULL = 67,
        BGR2HLS_FULL = 68,
        RGB2HLS_FULL = 69,

        HSV2BGR_FULL = 70,
        HSV2RGB_FULL = 71,
        HLS2BGR_FULL = 72,
        HLS2RGB_FULL = 73,

        LBGR2Lab = 74,
        LRGB2Lab = 75,
        LBGR2Luv = 76,
        LRGB2Luv = 77,

        Lab2LBGR = 78,
        Lab2LRGB = 79,
        Luv2LBGR = 80,
        Luv2LRGB = 81,

        BGR2YUV = 82,
        RGB2YUV = 83,
        YUV2BGR = 84,
        YUV2RGB = 85,

        COLORCVT_MAX = 100
    }
}
