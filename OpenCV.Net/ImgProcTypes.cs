using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public enum HoughTransformMethod : int
    {
        Standard = 0,
        Probabilistic = 1,
        MultiScale = 2,
        Gradient = 3
    }

    public enum StructuringElementShape : int
    {
        Rectangle = 0,
        Cross = 1,
        Ellipse = 2,
        Custom = 100
    }

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

    public enum PolygonApproximation : int
    {
        POLY_APPROX_DP = 0
    }

    /* Shape orientation */
    public enum ShapeOrientation
    {
        Clockwise = 1,
        CounterClockwise = 2
    }

    /* Convexity defect */
    [StructLayout(LayoutKind.Sequential)]
    public struct CvConvexityDefect
    {
        IntPtr start; /* point of the contour where the defect begins */
        IntPtr end; /* point of the contour where the defect ends */
        IntPtr depth_point; /* the farthest from the convex hull point within the defect */
        float depth; /* distance between the farthest point and the convex hull */

        public CvPoint Start
        {
            get
            {
                unsafe
                {
                    return *((CvPoint*)start.ToPointer());
                }
            }
        }

        public CvPoint End
        {
            get
            {
                unsafe
                {
                    return *((CvPoint*)end.ToPointer());
                }
            }
        }

        public CvPoint DepthPoint
        {
            get
            {
                unsafe
                {
                    return *((CvPoint*)depth_point.ToPointer());
                }
            }
        }

        public float Depth
        {
            get { return depth; }
        }
    }

    public enum AdaptiveThresholdMethod : int
    {
        MEAN_C = 0,
        GAUSSIAN_C = 1
    }

    public enum DistanceLabel : int
    {
        ConnectedComponent = 0,
        Pixel = 1
    }

    public enum DistanceType : int
    {
        User = -1,  /* User defined distance */
        L1 = 1,   /* distance = |x1-x2| + |y1-y2| */
        L2 = 2,   /* the simple euclidean distance */
        C = 3,   /* distance = max(|x1-x2|,|y1-y2|) */
        L12 = 4,   /* L1-L2 metric: distance = 2(sqrt(1+x*x/2) - 1)) */
        Fair = 5,   /* distance = c^2(|x|/c-log(1+|x|/c)), c = 1.3998 */
        Welsch = 6,   /* distance = c^2/2(1-exp(-(x/c)^2)), c = 2.9846 */
        Huber = 7    /* distance = |x|<c ? x^2/2 : c(|x|-c/2), c=1.345 */
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

    public enum SmoothMethod : int
    {
        BlurNoScale = 0,
        Blur = 1,
        Gaussian = 2,
        Median = 3,
        Bilateral = 4
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

        BayerBG2GRAY = 86,
        BayerGB2GRAY = 87,
        BayerRG2GRAY = 88,
        BayerGR2GRAY = 89,

        //YUV 4:2:0 formats family
        YUV2RGB_NV12 = 90,
        YUV2BGR_NV12 = 91,
        YUV2RGB_NV21 = 92,
        YUV2BGR_NV21 = 93,
        YUV420sp2RGB = YUV2RGB_NV21,
        YUV420sp2BGR = YUV2BGR_NV21,

        YUV2RGBA_NV12 = 94,
        YUV2BGRA_NV12 = 95,
        YUV2RGBA_NV21 = 96,
        YUV2BGRA_NV21 = 97,
        YUV420sp2RGBA = YUV2RGBA_NV21,
        YUV420sp2BGRA = YUV2BGRA_NV21,

        YUV2RGB_YV12 = 98,
        YUV2BGR_YV12 = 99,
        YUV2RGB_IYUV = 100,
        YUV2BGR_IYUV = 101,
        YUV2RGB_I420 = YUV2RGB_IYUV,
        YUV2BGR_I420 = YUV2BGR_IYUV,
        YUV420p2RGB = YUV2RGB_YV12,
        YUV420p2BGR = YUV2BGR_YV12,

        YUV2RGBA_YV12 = 102,
        YUV2BGRA_YV12 = 103,
        YUV2RGBA_IYUV = 104,
        YUV2BGRA_IYUV = 105,
        YUV2RGBA_I420 = YUV2RGBA_IYUV,
        YUV2BGRA_I420 = YUV2BGRA_IYUV,
        YUV420p2RGBA = YUV2RGBA_YV12,
        YUV420p2BGRA = YUV2BGRA_YV12,

        YUV2GRAY_420 = 106,
        YUV2GRAY_NV21 = YUV2GRAY_420,
        YUV2GRAY_NV12 = YUV2GRAY_420,
        YUV2GRAY_YV12 = YUV2GRAY_420,
        YUV2GRAY_IYUV = YUV2GRAY_420,
        YUV2GRAY_I420 = YUV2GRAY_420,
        YUV420sp2GRAY = YUV2GRAY_420,
        YUV420p2GRAY = YUV2GRAY_420,

        //YUV 4:2:2 formats family
        YUV2RGB_UYVY = 107,
        YUV2BGR_UYVY = 108,
        //YUV2RGB_VYUY = 109,
        //YUV2BGR_VYUY = 110,
        YUV2RGB_Y422 = YUV2RGB_UYVY,
        YUV2BGR_Y422 = YUV2BGR_UYVY,
        YUV2RGB_UYNV = YUV2RGB_UYVY,
        YUV2BGR_UYNV = YUV2BGR_UYVY,

        YUV2RGBA_UYVY = 111,
        YUV2BGRA_UYVY = 112,
        //YUV2RGBA_VYUY = 113,
        //YUV2BGRA_VYUY = 114,
        YUV2RGBA_Y422 = YUV2RGBA_UYVY,
        YUV2BGRA_Y422 = YUV2BGRA_UYVY,
        YUV2RGBA_UYNV = YUV2RGBA_UYVY,
        YUV2BGRA_UYNV = YUV2BGRA_UYVY,

        YUV2RGB_YUY2 = 115,
        YUV2BGR_YUY2 = 116,
        YUV2RGB_YVYU = 117,
        YUV2BGR_YVYU = 118,
        YUV2RGB_YUYV = YUV2RGB_YUY2,
        YUV2BGR_YUYV = YUV2BGR_YUY2,
        YUV2RGB_YUNV = YUV2RGB_YUY2,
        YUV2BGR_YUNV = YUV2BGR_YUY2,

        YUV2RGBA_YUY2 = 119,
        YUV2BGRA_YUY2 = 120,
        YUV2RGBA_YVYU = 121,
        YUV2BGRA_YVYU = 122,
        YUV2RGBA_YUYV = YUV2RGBA_YUY2,
        YUV2BGRA_YUYV = YUV2BGRA_YUY2,
        YUV2RGBA_YUNV = YUV2RGBA_YUY2,
        YUV2BGRA_YUNV = YUV2BGRA_YUY2,

        YUV2GRAY_UYVY = 123,
        YUV2GRAY_YUY2 = 124,
        //YUV2GRAY_VYUY = YUV2GRAY_UYVY,
        YUV2GRAY_Y422 = YUV2GRAY_UYVY,
        YUV2GRAY_UYNV = YUV2GRAY_UYVY,
        YUV2GRAY_YVYU = YUV2GRAY_YUY2,
        YUV2GRAY_YUYV = YUV2GRAY_YUY2,
        YUV2GRAY_YUNV = YUV2GRAY_YUY2,

        // alpha premultiplication
        RGBA2mRGBA = 125,
        mRGBA2RGBA = 126,

        COLORCVT_MAX = 127
    }
}
