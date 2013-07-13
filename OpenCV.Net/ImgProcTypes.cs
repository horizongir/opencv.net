using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies the type of smoothing used by <see cref="cv.Smooth"/>.
    /// </summary>
    public enum SmoothMethod : int
    {
        /// <summary>
        /// Specifies a linear convolution with size1 x size2 box kernel (all 1’s).
        /// If you want to smooth different pixels with different-size box kernels,
        /// you can use the integral image that is computed using <see cref="cv.Integral"/>.
        /// </summary>
        BlurNoScale = 0,

        /// <summary>
        /// Specifies a linear convolution with size1 x size2 box kernel (all 1’s)
        /// with subsequent scaling by 1 / (size1 x size2).
        /// </summary>
        Blur = 1,

        /// <summary>
        /// Specifies a linear convolution with a size1 x size2 Gaussian kernel.
        /// </summary>
        Gaussian = 2,

        /// <summary>
        /// Specifies a median filter with a size1 x size2 square aperture.
        /// </summary>
        Median = 3,

        /// <summary>
        /// Specifies a bilateral filter with a size1 x size2 square aperture,
        /// color sigma = sigma1 and spatial sigma = sigma2.
        /// </summary>
        Bilateral = 4
    }

    /// <summary>
    /// Specifies the type of linear filter used for pyramid up and downsampling.
    /// </summary>
    public enum PyramidDecompositionFilter : int
    {
        /// <summary>
        /// Specifies a 5x5 gaussian filter.
        /// </summary>
        Gaussian5x5 = 7
    }

    /// <summary>
    /// Specifies the color space conversion used by <see cref="cv.CvtColor"/>.
    /// </summary>
    public enum ColorConversion : int
    {
        /// <summary>
        /// Specifies a conversion from the BGR color space to BGRA.
        /// </summary>
        Bgr2Bgra = 0,

        /// <summary>
        /// Specifies a conversion from the RGB color space to RGBA.
        /// </summary>
        Rgb2Rgba = Bgr2Bgra,

        /// <summary>
        /// Specifies a conversion from the BGRA color space to BGR.
        /// </summary>
        Bgra2Bgr = 1,

        /// <summary>
        /// Specifies a conversion from the RGBA color space to RGB.
        /// </summary>
        Rgba2Rgb = Bgra2Bgr,

        /// <summary>
        /// Specifies a conversion from the BGR color space to RGBA.
        /// </summary>
        Bgr2Rgba = 2,

        /// <summary>
        /// Specifies a conversion from the RGB color space to BGRA.
        /// </summary>
        Rgb2Bgra = Bgr2Rgba,

        /// <summary>
        /// Specifies a conversion from the RGBA color space to BGR.
        /// </summary>
        Rgba2Bgr = 3,

        /// <summary>
        /// Specifies a conversion from the BGRA color space to RGB.
        /// </summary>
        Bgra2Rgb = Rgba2Bgr,

        /// <summary>
        /// Specifies a conversion from the BGR color space to RGB.
        /// </summary>
        Bgr2Rgb = 4,

        /// <summary>
        /// Specifies a conversion from the RGB color space to BGR.
        /// </summary>
        Rgb2Bgr = Bgr2Rgb,

        /// <summary>
        /// Specifies a conversion from the BGRA color space to RGBA.
        /// </summary>
        Bgra2Rgba = 5,

        /// <summary>
        /// Specifies a conversion from the RGBA color space to BGRA.
        /// </summary>
        Rgba2Bgra = Bgra2Rgba,

        /// <summary>
        /// Specifies a conversion from the BGR color space to grayscale.
        /// </summary>
        Bgr2Gray = 6,

        /// <summary>
        /// Specifies a conversion from the RGB color space to grayscale.
        /// </summary>
        Rgb2Gray = 7,

        /// <summary>
        /// Specifies a conversion from grayscale to the BGR color space.
        /// </summary>
        Gray2Bgr = 8,

        /// <summary>
        /// Specifies a conversion from grayscale to the RGB color space.
        /// </summary>
        Gray2Rgb = Gray2Bgr,

        /// <summary>
        /// Specifies a conversion from grayscale to the BGRA color space.
        /// </summary>
        Gray2Bgra = 9,

        /// <summary>
        /// Specifies a conversion from grayscale to the RGBA color space.
        /// </summary>
        Gray2Rgba = Gray2Bgra,

        /// <summary>
        /// Specifies a conversion from the BGRA color space to grayscale.
        /// </summary>
        Bgra2Gray = 10,

        /// <summary>
        /// Specifies a conversion from the RGBA color space to grayscale.
        /// </summary>
        Rgba2Gray = 11,

        /// <summary>
        /// Specifies a conversion from the BGR color space to 16-bit BGR565.
        /// </summary>
        Bgr2Bgr565 = 12,

        /// <summary>
        /// Specifies a conversion from the RGB color space to 16-bit BGR565.
        /// </summary>
        Rgb2Bgr565 = 13,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR565 color space to BGR.
        /// </summary>
        Bgr5652Bgr = 14,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR565 color space to RGB.
        /// </summary>
        Bgr5652Rgb = 15,

        /// <summary>
        /// Specifies a conversion from the BGRA color space to 16-bit BGR565.
        /// </summary>
        Bgra2Bgr565 = 16,

        /// <summary>
        /// Specifies a conversion from the RGBA color space to 16-bit BGR565.
        /// </summary>
        Rgba2Bgr565 = 17,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR565 color space to BGRA.
        /// </summary>
        Bgr5652Bgra = 18,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR565 color space to RGBA.
        /// </summary>
        Bgr5652Rgba = 19,

        /// <summary>
        /// Specifies a conversion from grayscale to the 16-bit BGR565 color space.
        /// </summary>
        Gray2Bgr565 = 20,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR565 color space to grayscale.
        /// </summary>
        Bgr5652Gray = 21,

        /// <summary>
        /// Specifies a conversion from the BGR color space to 16-bit BGR555.
        /// </summary>
        Bgr2Bgr555 = 22,

        /// <summary>
        /// Specifies a conversion from the RGB color space to 16-bit BGR555.
        /// </summary>
        Rgb2Bgr555 = 23,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR555 color space to BGR.
        /// </summary>
        Bgr5552Bgr = 24,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR555 color space to RGB.
        /// </summary>
        Bgr5552Rgb = 25,

        /// <summary>
        /// Specifies a conversion from the BGRA color space to 16-bit BGR555.
        /// </summary>
        Bgra2Bgr555 = 26,

        /// <summary>
        /// Specifies a conversion from the RGBA color space to 16-bit BGR555.
        /// </summary>
        Rgba2Bgr555 = 27,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR555 color space to BGRA.
        /// </summary>
        Bgr5552Bgra = 28,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR555 color space to RGBA.
        /// </summary>
        Bgr5552Rgba = 29,

        /// <summary>
        /// Specifies a conversion from grayscale to the 16-bit BGR555 color space.
        /// </summary>
        Gray2Bgr555 = 30,

        /// <summary>
        /// Specifies a conversion from the 16-bit BGR555 color space to grayscale.
        /// </summary>
        Bgr5552Gray = 31,

        /// <summary>
        /// Specifies a conversion from the BGR color space to CIE XYZ Rec. 709.
        /// </summary>
        Bgr2Xyz = 32,

        /// <summary>
        /// Specifies a conversion from the RGB color space to CIE XYZ Rec. 709.
        /// </summary>
        Rgb2Xyz = 33,

        /// <summary>
        /// Specifies a conversion from the CIE XYZ Rec. 709 color space to BGR.
        /// </summary>
        Xyz2Bgr = 34,

        /// <summary>
        /// Specifies a conversion from the CIE XYZ Rec. 709 color space to RGB.
        /// </summary>
        Xyz2Rgb = 35,

        /// <summary>
        /// Specifies a conversion from the BGR color space to YCrCb.
        /// </summary>
        Bgr2YCrCb = 36,

        /// <summary>
        /// Specifies a conversion from the RGB color space to YCrCb.
        /// </summary>
        Rgb2YCrCb = 37,

        /// <summary>
        /// Specifies a conversion from the YCrCb color space to BGR.
        /// </summary>
        YCrCb2Bgr = 38,

        /// <summary>
        /// Specifies a conversion from the YCrCb color space to RGB.
        /// </summary>
        YCrCb2Rgb = 39,

        /// <summary>
        /// Specifies a conversion from the BGR color space to HSV.
        /// </summary>
        Bgr2Hsv = 40,

        /// <summary>
        /// Specifies a conversion from the RGB color space to HSV.
        /// </summary>
        Rgb2Hsv = 41,

        /// <summary>
        /// Specifies a conversion from the BGR color space to CIE L*a*b*.
        /// </summary>
        Bgr2Lab = 44,

        /// <summary>
        /// Specifies a conversion from the RGB color space to CIE L*a*b*.
        /// </summary>
        Rgb2Lab = 45,

        /// <summary>
        /// Specifies a conversion from the Bayer "BG" color space to BGR.
        /// </summary>
        BayerBG2Bgr = 46,

        /// <summary>
        /// Specifies a conversion from the Bayer "GB" color space to BGR.
        /// </summary>
        BayerGB2Bgr = 47,

        /// <summary>
        /// Specifies a conversion from the Bayer "RG" color space to BGR.
        /// </summary>
        BayerRG2Bgr = 48,

        /// <summary>
        /// Specifies a conversion from the Bayer "GR" color space to BGR.
        /// </summary>
        BayerGR2Bgr = 49,

        /// <summary>
        /// Specifies a conversion from the Bayer "BG" color space to RGB.
        /// </summary>
        BayerBG2Rgb = BayerRG2Bgr,

        /// <summary>
        /// Specifies a conversion from the Bayer "GB" color space to RGB.
        /// </summary>
        BayerGB2Rgb = BayerGR2Bgr,

        /// <summary>
        /// Specifies a conversion from the Bayer "RG" color space to RGB.
        /// </summary>
        BayerRG2Rgb = BayerBG2Bgr,

        /// <summary>
        /// Specifies a conversion from the Bayer "GR" color space to RGB.
        /// </summary>
        BayerGR2Rgb = BayerGB2Bgr,

        /// <summary>
        /// Specifies a conversion from the BGR color space to CIE L*u*v*.
        /// </summary>
        Bgr2Luv = 50,

        /// <summary>
        /// Specifies a conversion from the RGB color space to CIE L*u*v*.
        /// </summary>
        Rgb2Luv = 51,

        /// <summary>
        /// Specifies a conversion from the BGR color space to HLS.
        /// </summary>
        Bgr2Hls = 52,

        /// <summary>
        /// Specifies a conversion from the RGB color space to HLS.
        /// </summary>
        Rgb2Hls = 53,

        /// <summary>
        /// Specifies a conversion from the HSV color space to BGR.
        /// </summary>
        Hsv2Bgr = 54,

        /// <summary>
        /// Specifies a conversion from the HSV color space to RGB.
        /// </summary>
        Hsv2Rgb = 55,

        /// <summary>
        /// Specifies a conversion from the CIE L*a*b* color space to BGR.
        /// </summary>
        Lab2Bgr = 56,

        /// <summary>
        /// Specifies a conversion from the CIE L*a*b* color space to RGB.
        /// </summary>
        Lab2Rgb = 57,

        /// <summary>
        /// Specifies a conversion from the CIE L*u*v* color space to BGR.
        /// </summary>
        Luv2Bgr = 58,

        /// <summary>
        /// Specifies a conversion from the CIE L*u*v* color space to RGB.
        /// </summary>
        Luv2Rgb = 59,

        /// <summary>
        /// Specifies a conversion from the HLS color space to BGR.
        /// </summary>
        Hls2Bgr = 60,

        /// <summary>
        /// Specifies a conversion from the HLS color space to RGB.
        /// </summary>
        Hls2Rgb = 61,

        /// <summary>
        /// Specifies a conversion from the Bayer "BG" color space to BGR using the VNG demosaicing algorithm.
        /// </summary>
        BayerBG2BgrVng = 62,

        /// <summary>
        /// Specifies a conversion from the Bayer "GB" color space to BGR using the VNG demosaicing algorithm.
        /// </summary>
        BayerGB2BgrVng = 63,

        /// <summary>
        /// Specifies a conversion from the Bayer "RG" color space to BGR using the VNG demosaicing algorithm.
        /// </summary>
        BayerRG2BgrVng = 64,

        /// <summary>
        /// Specifies a conversion from the Bayer "GR" color space to BGR using the VNG demosaicing algorithm.
        /// </summary>
        BayerGR2BgrVng = 65,

        /// <summary>
        /// Specifies a conversion from the Bayer "BG" color space to RGB using the VNG demosaicing algorithm.
        /// </summary>
        BayerBG2RgbVng = BayerRG2BgrVng,

        /// <summary>
        /// Specifies a conversion from the Bayer "GB" color space to RGB using the VNG demosaicing algorithm.
        /// </summary>
        BayerGB2RgbVng = BayerGR2BgrVng,

        /// <summary>
        /// Specifies a conversion from the Bayer "RG" color space to RGB using the VNG demosaicing algorithm.
        /// </summary>
        BayerRG2RgbVng = BayerBG2BgrVng,

        /// <summary>
        /// Specifies a conversion from the Bayer "GR" color space to RGB using the VNG demosaicing algorithm.
        /// </summary>
        BayerGR2RgbVng = BayerGB2BgrVng,

        /// <summary>
        /// Specifies a conversion from the BGR color space to HSV using the full 8-bit range for H ([0,255]).
        /// </summary>
        Bgr2HsvFull = 66,

        /// <summary>
        /// Specifies a conversion from the RGB color space to HSV using the full 8-bit range for H ([0,255]).
        /// </summary>
        Rgb2HsvFull = 67,

        /// <summary>
        /// Specifies a conversion from the BGR color space to HLS using the full 8-bit range for H ([0,255]).
        /// </summary>
        Bgr2HlsFull = 68,

        /// <summary>
        /// Specifies a conversion from the RGB color space to HLS using the full 8-bit range for H ([0,255]).
        /// </summary>
        Rgb2HlsFull = 69,

        /// <summary>
        /// Specifies a conversion from the HSV color space to BGR using the full 8-bit range for H ([0,255]).
        /// </summary>
        Hsv2BgrFull = 70,

        /// <summary>
        /// Specifies a conversion from the HSV color space to RGB using the full 8-bit range for H ([0,255]).
        /// </summary>
        Hsv2RgbFull = 71,

        /// <summary>
        /// Specifies a conversion from the HLS color space to BGR using the full 8-bit range for H ([0,255]).
        /// </summary>
        Hls2BgrFull = 72,

        /// <summary>
        /// Specifies a conversion from the HLS color space to RGB using the full 8-bit range for H ([0,255]).
        /// </summary>
        Hls2RgbFull = 73,

        /// <summary>
        /// Specifies a conversion from the Luminance BGR color space to CIE L*a*b*.
        /// </summary>
        LBgr2Lab = 74,

        /// <summary>
        /// Specifies a conversion from the Luminance RGB color space to CIE L*a*b*.
        /// </summary>
        LRgb2Lab = 75,

        /// <summary>
        /// Specifies a conversion from the Luminance BGR color space to CIE L*u*v*.
        /// </summary>
        LBgr2Luv = 76,

        /// <summary>
        /// Specifies a conversion from the Luminance RGB color space to CIE L*u*v*.
        /// </summary>
        LRgb2Luv = 77,

        /// <summary>
        /// Specifies a conversion from the CIE L*a*b* color space to Luminance BGR.
        /// </summary>
        Lab2LBgr = 78,

        /// <summary>
        /// Specifies a conversion from the CIE L*a*b* color space to Luminance RGB.
        /// </summary>
        Lab2LRgb = 79,

        /// <summary>
        /// Specifies a conversion from the CIE L*u*v* color space to Luminance BGR.
        /// </summary>
        Luv2LBgr = 80,

        /// <summary>
        /// Specifies a conversion from the CIE L*u*v* color space to Luminance RGB.
        /// </summary>
        Luv2LRgb = 81,

        /// <summary>
        /// Specifies a conversion from the BGR color space to YUV.
        /// </summary>
        Bgr2Yuv = 82,

        /// <summary>
        /// Specifies a conversion from the RGB color space to YUV.
        /// </summary>
        Rgb2Yuv = 83,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR.
        /// </summary>
        Yuv2Bgr = 84,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB.
        /// </summary>
        Yuv2Rgb = 85,

        /// <summary>
        /// Specifies a conversion from the Bayer "BG" color space to grayscale.
        /// </summary>
        BayerBG2Gray = 86,

        /// <summary>
        /// Specifies a conversion from the Bayer "GB" color space to grayscale.
        /// </summary>
        BayerGB2Gray = 87,

        /// <summary>
        /// Specifies a conversion from the Bayer "RG" color space to grayscale.
        /// </summary>
        BayerRG2Gray = 88,

        /// <summary>
        /// Specifies a conversion from the Bayer "GR" color space to grayscale.
        /// </summary>
        BayerGR2Gray = 89,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with interleaved U/V plane with 2x2 subsampling.
        /// </summary>
        Yuv2RgbNV12 = 90,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with interleaved U/V plane with 2x2 subsampling.
        /// </summary>
        Yuv2BgrNV12 = 91,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with U/V reversed in the interleaved plane with 2x2 subsampling.
        /// </summary>
        Yuv2RgbNV21 = 92,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with U/V reversed in the interleaved plane with 2x2 subsampling.
        /// </summary>
        Yuv2BgrNV21 = 93,

        /// <summary>
        /// Specifies a conversion from the YUV 420 semi-planar color space to RGB. Same as <see cref="Yuv2RgbNV21"/>.
        /// </summary>
        Yuv420sp2Rgb = Yuv2RgbNV21,

        /// <summary>
        /// Specifies a conversion from the YUV 420 semi-planar color space to BGR. Same as <see cref="Yuv2BgrNV21"/>.
        /// </summary>
        Yuv420sp2Bgr = Yuv2BgrNV21,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with interleaved U/V plane with 2x2 subsampling.
        /// </summary>
        Yuv2RgbaNV12 = 94,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with interleaved U/V plane with 2x2 subsampling.
        /// </summary>
        Yuv2BgraNV12 = 95,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with U/V reversed in the interleaved plane with 2x2 subsampling.
        /// </summary>
        Yuv2RgbaNV21 = 96,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with U/V reversed in the interleaved plane with 2x2 subsampling.
        /// </summary>
        Yuv2BgraNV21 = 97,

        /// <summary>
        /// Specifies a conversion from the YUV 420 semi-planar color space to RGBA. Same as <see cref="Yuv2RgbaNV21"/>.
        /// </summary>
        Yuv420sp2Rgba = Yuv2RgbaNV21,

        /// <summary>
        /// Specifies a conversion from the YUV 420 semi-planar color space to BGRA. Same as <see cref="Yuv2BgraNV21"/>.
        /// </summary>
        Yuv420sp2Bgra = Yuv2BgraNV21,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled V and U planes.
        /// </summary>
        Yuv2RgbYV12 = 98,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled V and U planes.
        /// </summary>
        Yuv2BgrYV12 = 99,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2RgbIYuv = 100,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2BgrIYuv = 101,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2RgbI420 = Yuv2RgbIYuv,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2BgrI420 = Yuv2BgrIYuv,

        /// <summary>
        /// Specifies a conversion from the YUV 420 planar color space to RGB. Same as <see cref="Yuv2RgbYV12"/>.
        /// </summary>
        Yuv420p2Rgb = Yuv2RgbYV12,

        /// <summary>
        /// Specifies a conversion from the YUV 420 planar color space to BGR. Same as <see cref="Yuv2BgrYV12"/>.
        /// </summary>
        Yuv420p2Bgr = Yuv2BgrYV12,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled V and U planes.
        /// </summary>
        Yuv2RgbaYV12 = 102,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled V and U planes.
        /// </summary>
        Yuv2BgraYV12 = 103,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2RgbaIYuv = 104,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2BgraIYuv = 105,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2RgbaI420 = Yuv2RgbaIYuv,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA where the 8-bit Y plane is followed
        /// by two 8-bit 2x2 subsampled U and V planes.
        /// </summary>
        Yuv2BgraI420 = Yuv2BgraIYuv,

        /// <summary>
        /// Specifies a conversion from the YUV 420 planar color space to RGBA. Same as <see cref="Yuv2RgbaYV12"/>.
        /// </summary>
        Yuv420p2Rgba = Yuv2RgbaYV12,

        /// <summary>
        /// Specifies a conversion from the YUV 420 planar color space to BGRA. Same as <see cref="Yuv2BgraYV12"/>.
        /// </summary>
        Yuv420p2Bgra = Yuv2BgraYV12,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv2Gray420 = 106,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv2GrayNV21 = Yuv2Gray420,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv2GrayNV12 = Yuv2Gray420,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv2GrayYV12 = Yuv2Gray420,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv2GrayIYuv = Yuv2Gray420,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv2GrayI420 = Yuv2Gray420,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv420sp2Gray = Yuv2Gray420,

        /// <summary>
        /// Specifies a conversion from the YUV 420 color space to grayscale.
        /// </summary>
        Yuv420p2Gray = Yuv2Gray420,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2RgbUyvy = 107,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2BgrUyvy = 108,

        /// <summary>
        /// Specifies a conversion from the YUV 422 color space to RGB.
        /// </summary>
        Yuv2RgbY422 = Yuv2RgbUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV 422 color space to BGR.
        /// </summary>
        Yuv2BgrY422 = Yuv2BgrUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2RgbUynv = Yuv2RgbUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2BgrUynv = Yuv2BgrUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2RgbaUyvy = 111,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2BgraUyvy = 112,

        /// <summary>
        /// Specifies a conversion from the YUV 422 color space to RGBA.
        /// </summary>
        Yuv2RgbaY422 = Yuv2RgbaUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV 422 color space to BGRA.
        /// </summary>
        Yuv2BgraY422 = Yuv2BgraUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2RgbaUynv = Yuv2RgbaUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2BgraUynv = Yuv2BgraUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2RgbYuy2 = 115,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2BgrYuy2 = 116,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with two luminance samples for each chroma period
        /// in the pattern YVYU.
        /// </summary>
        Yuv2RgbYvyu = 117,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with two luminance samples for each chroma period
        /// in the pattern YVYU.
        /// </summary>
        Yuv2BgrYvyu = 118,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2RgbYuyv = Yuv2RgbYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2BgrYuyv = Yuv2BgrYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGB with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2RgbYunv = Yuv2RgbYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGR with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2BgrYunv = Yuv2BgrYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2RgbaYuy2 = 119,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2BgraYuy2 = 120,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with two luminance samples for each chroma period
        /// in the pattern YVYU.
        /// </summary>
        Yuv2RgbaYvyu = 121,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with two luminance samples for each chroma period
        /// in the pattern YVYU.
        /// </summary>
        Yuv2BgraYvyu = 122,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2RgbaYuyv = Yuv2RgbaYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2BgraYuyv = Yuv2BgraYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to RGBA with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2RgbaYunv = Yuv2RgbaYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to BGRA with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2BgraYunv = Yuv2BgraYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to grayscale with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2GrayUyvy = 123,

        /// <summary>
        /// Specifies a conversion from the YUV color space to grayscale with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2GrayYuy2 = 124,

        /// <summary>
        /// Specifies a conversion from the YUV 422 color space to grayscale.
        /// </summary>
        Yuv2GrayY422 = Yuv2GrayUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to grayscale with two luminance samples for each chroma period
        /// in the pattern UYVY.
        /// </summary>
        Yuv2GrayUynv = Yuv2GrayUyvy,

        /// <summary>
        /// Specifies a conversion from the YUV color space to grayscale with two luminance samples for each chroma period
        /// in the pattern YVYU.
        /// </summary>
        Yuv2GrayYvyu = Yuv2GrayYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to grayscale with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2GrayYuyv = Yuv2GrayYuy2,

        /// <summary>
        /// Specifies a conversion from the YUV color space to grayscale with two luminance samples for each chroma period
        /// in the pattern YUYV.
        /// </summary>
        Yuv2GrayYunv = Yuv2GrayYuy2,

        /// <summary>
        /// Specifies a conversion from non-premultiplied RGBA color space to premultiplied alpha RGB.
        /// </summary>
        Rgba2mRgba = 125,

        /// <summary>
        /// Specifies a conversion from premultiplied alpha RGB color space to non-premultiplied RGBA.
        /// </summary>
        mRgba2Rgba = 126
    }

    /// <summary>
    /// Specifies the interpolation method used by <see cref="cv.Resize"/>.
    /// </summary>
    public enum SubPixelInterpolation : int
    {
        /// <summary>
        /// Specifies a nearest-neighbor interpolation.
        /// </summary>
        NearestNeighbor = 0,

        /// <summary>
        /// Specifies a bilinear interpolation.
        /// </summary>
        Linear = 1,

        /// <summary>
        /// Specifies a bicubic interpolation over a 4x4 pixel neighborhood.
        /// </summary>
        Cubic = 2,

        /// <summary>
        /// Specifies resampling using pixel area relation. It may be a preferred method for image decimation,
        /// as it gives moire’-free results. Similar to <see cref="NearestNeighbor"/> when image is zoomed.
        /// </summary>
        Area = 3,

        /// <summary>
        /// Specifies a Lanczos interpolation over an 8x8 pixel neighborhood.
        /// </summary>
        Lanczos4 = 4
    }

    /// <summary>
    /// Specifies interpolation and operational flags for image warp methods.
    /// </summary>
    [Flags]
    public enum WarpFlags : int
    {
        /// <summary>
        /// Specifies a nearest-neighbor interpolation.
        /// </summary>
        NearestNeighbor = 0,

        /// <summary>
        /// Specifies a bilinear interpolation.
        /// </summary>
        Linear = 1,

        /// <summary>
        /// Specifies a bicubic interpolation over a 4x4 pixel neighborhood.
        /// </summary>
        Cubic = 2,

        /// <summary>
        /// Specifies resampling using pixel area relation. It may be a preferred method for image decimation,
        /// as it gives moire’-free results. Similar to <see cref="NearestNeighbor"/> when image is zoomed.
        /// </summary>
        Area = 3,

        /// <summary>
        /// Specifies a Lanczos interpolation over an 8x8 pixel neighborhood.
        /// </summary>
        Lanczos4 = 4,

        /// <summary>
        /// Specifies that all destination pixels should be filled. If some correspond to outliers in the
        /// source image, they are set to a constant value.
        /// </summary>
        FillOutliers = 8,

        /// <summary>
        /// Specifies that the map matrix is inversely transformed from the destination image to the source
        /// and can thus be used directly for pixel interpolation.
        /// </summary>
        InverseMap = 16
    }

    /// <summary>
    /// Specifies the type of morphological operation used by <see cref="cv.MorphologyEx"/>.
    /// </summary>
    public enum MorphologicalOperation : int
    {
        /// <summary>
        /// Specifies the primitive erosion morphological operation.
        /// </summary>
        Erode = 0,

        /// <summary>
        /// Specifies the primitive dilation morphological operation.
        /// </summary>
        Dilate = 1,

        /// <summary>
        /// Specifies a morphological operation performed by first eroding and then dilating the image.
        /// </summary>
        Open = 2,

        /// <summary>
        /// Specifies a morphological operation performed by first dilating and then eroding the image.
        /// </summary>
        Close = 3,

        /// <summary>
        /// Specifies a morphological operation obtained by subtracting the result of the <see cref="Erode"/> operator
        /// from the result of the <see cref="Dilate"/> operator.
        /// </summary>
        Gradient = 4,

        /// <summary>
        /// Specifies a morphological operation obtained by subtracting the result of the <see cref="Open"/> operator
        /// from the input image.
        /// </summary>
        TopHat = 5,

        /// <summary>
        /// Specifies a morphological operation obtained by subtracting the input image
        /// from the result of the <see cref="Close"/> operator.
        /// </summary>
        BlackHat = 6
    }

    /// <summary>
    /// Specifies the shape of the structuring element kernel.
    /// </summary>
    public enum StructuringElementShape : int
    {
        /// <summary>
        /// Specifies a rectangular structuring element.
        /// </summary>
        Rectangle = 0,

        /// <summary>
        /// Specifies a cross-shaped structuring element.
        /// </summary>
        Cross = 1,

        /// <summary>
        /// Specifies an elliptical structuring element.
        /// </summary>
        Ellipse = 2,

        /// <summary>
        /// Specifies a user-defined structuring element. In this case the kernel values are passed
        /// explicitly to the constructor method.
        /// </summary>
        Custom = 100
    }

    /// <summary>
    /// Specifies the way the template is compared with image regions in <see cref="cv.MatchTemplate"/>.
    /// </summary>
    public enum TemplateMatchingMethod : int
    {
        /// <summary>
        /// Specifies that the sum of squared differences between region and template will be used.
        /// </summary>
        SquareDifference = 0,

        /// <summary>
        /// Specifies that the normed sum of squared differences between region and template will be used.
        /// </summary>
        SquareDifferenceNormed = 1,

        /// <summary>
        /// Specifies that the cross correlation between region and template will be used.
        /// </summary>
        CrossCorrelation = 2,

        /// <summary>
        /// Specifies that the normed cross correlation between region and template will be used.
        /// </summary>
        CrossCorrelationNormed = 3,

        /// <summary>
        /// Specifies that the correlaton coefficient between region and template will be used.
        /// </summary>
        CorrelationCoefficient = 4,

        /// <summary>
        /// Specifies that the normed correlaton coefficient between region and template will be used.
        /// </summary>
        CorrelationCoefficientNormed = 5
    }

    /// <summary>
    /// Specifies the available types of distance functions.
    /// </summary>
    public enum DistanceType : int
    {
        /// <summary>
        /// Specifies that a user defined distance should be used.
        /// </summary>
        User = -1,

        /// <summary>
        /// Specifies the L1 or Manhattan distance.
        /// </summary>
        L1 = 1,

        /// <summary>
        /// Specifies the L2 or Euclidean distance.
        /// </summary>
        L2 = 2,

        /// <summary>
        /// Specifies the elementwise max distance.
        /// </summary>
        C = 3,

        /// <summary>
        /// Specifies the L1-L2 metric.
        /// </summary>
        L12 = 4,

        /// <summary>
        /// Specifies the Fair metric given by c^2(|x|/c-log(1+|x|/c)), c = 1.3998.
        /// </summary>
        Fair = 5,

        /// <summary>
        /// Specifies the Welsch metric given by distance = c^2/2(1-exp(-(x/c)^2)), c = 2.9846.
        /// </summary>
        Welsch = 6,

        /// <summary>
        /// Specifies the Huber metric given by distance = x^2/2 if |x| is less than c, else c(|x|-c/2), c=1.345.
        /// </summary>
        Huber = 7
    }

    /// <summary>
    /// Specifies the available contour retrieval modes.
    /// </summary>
    public enum ContourRetrieval : int
    {
        /// <summary>
        /// Specifies that only the extreme outer contours should be retrieved.
        /// </summary>
        External = 0,

        /// <summary>
        /// Specifies that all the contours should be retrieved and stored in a list.
        /// </summary>
        List = 1,

        /// <summary>
        /// Specifies that all the contours should be retrieved and organized into a two-level
        /// hierarchy: on the top level are the external boundaries of the components, on the
        /// second level are the boundaries of the holes.
        /// </summary>
        ConnectedComponent = 2,

        /// <summary>
        /// Specifies that all the contours should be retrieved with the full hierarchy of nested contours.
        /// </summary>
        Tree = 3,

        /// <summary>
        /// Specifies that all the contours should be retrieved using the flood fill algorithm.
        /// </summary>
        FloodFill = 4
    }

    /// <summary>
    /// Specifies the available contour approximation methods.
    /// </summary>
    public enum ContourApproximation : int
    {
        /// <summary>
        /// Specifies that contours should be output in the Freeman chain code.
        /// </summary>
        ChainCode = 0,

        /// <summary>
        /// Specifies that all the elements of the chain code should be translated into points.
        /// </summary>
        ChainApproxNone = 1,

        /// <summary>
        /// Specifies that all horizontal, vertical, and diagonal segments should be compressed,
        /// leaving only their end points.
        /// </summary>
        ChainApproxSimple = 2,

        /// <summary>
        /// Specifies that Teh-Chin's L1 chain approximation algorithm should be used.
        /// </summary>
        ChainApproxTC89L1 = 3,

        /// <summary>
        /// Specifies that Teh-Chin's K cosines chain approximation algorithm should be used.
        /// </summary>
        ChainApproxTC89KCos = 4,

        /// <summary>
        /// Specifies a completely different contour retrieval algorithm by linking horizontal segments of ones.
        /// Only the <see cref="ContourRetrieval.List"/> retrieval mode can be used with this method.
        /// </summary>
        LinkRuns = 5
    }

    /// <summary>
    /// Specifies the available polygon approximation algorithms.
    /// </summary>
    public enum PolygonApproximation : int
    {
        /// <summary>
        /// Specifies that the Douglas-Peucker polygon approximation algorithm should be used.
        /// </summary>
        DouglasPeucker = 0
    }

    /// <summary>
    /// Specifies the available shape comparison methods.
    /// </summary>
    public enum ShapeMatchingMethod : int
    {
        /// <summary>
        /// Specifies that the match should be computed as I2(A,B) = sum{i}(|1/miA - 1/miB|).
        /// mi = sign(hi).log(hi) where hi is the ith Hu moment.
        /// </summary>
        MatchI1 = 1,

        /// <summary>
        /// Specifies that the match should be computed as I2(A,B) = sum{i}(|miA - miB|).
        /// mi = sign(hi).log(hi) where hi is the ith Hu moment.
        /// </summary>
        MatchI2 = 2,

        /// <summary>
        /// Specifies that the match should be computed as I2(A,B) = sum{i}(|miA - miB| / |miA|).
        /// mi = sign(hi).log(hi) where hi is the ith Hu moment.
        /// </summary>
        MatchI3 = 3
    }

    /// <summary>
    /// Specifies the desired orientation of the convex hull.
    /// </summary>
    public enum ShapeOrientation
    {
        /// <summary>
        /// Specifies that the convex hull should be oriented clockwise.
        /// </summary>
        Clockwise = 1,

        /// <summary>
        /// Specifies that the convex hull should be oriented counterclockwise.
        /// </summary>
        CounterClockwise = 2
    }

    /// <summary>
    /// Specifies the available histogram types.
    /// </summary>
    public enum HistogramType : int
    {
        /// <summary>
        /// Specifies that histogram data is represented as a multi-dimensional dense array <see cref="CvMatND"/>.
        /// </summary>
        Array = 0,

        /// <summary>
        /// Specifies that histogram data is represented as a multi-dimensional sparse array <see cref="CvSparseMat"/>.
        /// </summary>
        Sparse = 1,

        /// <summary>
        /// Specifies that histogram data is represented as a multi-dimensional sparse array <see cref="CvSparseMat"/>.
        /// </summary>
        Tree = Sparse
    }

    /// <summary>
    /// Specifies the available histogram comparison methods.
    /// </summary>
    public enum HistogramComparison : int
    {
        /// <summary>
        /// Specifies that the histograms should be compared using a correlation measure.
        /// </summary>
        Correlation = 0,

        /// <summary>
        /// Specifies that the histograms should be compared using a chi-squared statistic.
        /// </summary>
        ChiSquare = 1,

        /// <summary>
        /// Specifies that the histograms should be compared using bin intersection.
        /// </summary>
        Intersection = 2,

        /// <summary>
        /// Specifies that the histograms should be compared using the Bhattacharyya distance.
        /// This method only works on normalized histograms.
        /// </summary>
        Bhattacharyya = 3,

        /// <summary>
        /// Specifies that the histograms should be compared using the Bhattacharyya distance.
        /// This method only works on normalized histograms.
        /// </summary>
        Hellinger = Bhattacharyya
    }

    /// <summary>
    /// Specifies the available threshold types.
    /// </summary>
    [Flags]
    public enum ThresholdTypes : int
    {
        /// <summary>
        /// Specifies that all values above threshold should be set to a fixed max value
        /// while all other values should be set to 0.
        /// </summary>
        Binary = 0,

        /// <summary>
        /// Specifies that all values above threshold should be set to 0 while all other
        /// values should be set to a fixed max value.
        /// </summary>
        BinaryInv = 1,

        /// <summary>
        /// Specifies that all values above threshold should be set to the threshold value
        /// while all other values should be left as they are.
        /// </summary>
        Truncate = 2,

        /// <summary>
        /// Specifies that all values above threshold should be left as they are while all
        /// other values should be set to 0.
        /// </summary>
        ToZero = 3,

        /// <summary>
        /// Specifies that all values above threshold should be set to 0 while all other
        /// values should be left as they are.
        /// </summary>
        ToZeroInv = 4,

        /// <summary>
        /// Specifies that the Otsu algorithm should be used to choose the optimal
        /// threshold value. Combine the flag with one of the other values.
        /// </summary>
        Otsu = 8
    }

    /// <summary>
    /// Specifies the content of the output label array in <see cref="cv.DistTransform"/>.
    /// </summary>
    public enum DistanceLabel : int
    {
        /// <summary>
        /// Specifies that the content of the output label array are connected components.
        /// </summary>
        ConnectedComponent = 0,

        /// <summary>
        /// Specifies that the content of the output label array are pixel values.
        /// </summary>
        Pixel = 1
    }

    /// <summary>
    /// Specifies the available adaptive threshold methods.
    /// </summary>
    public enum AdaptiveThresholdMethod : int
    {
        /// <summary>
        /// Specifies that the threshold value is the mean of the pixel neighborhood
        /// minus a constant.
        /// </summary>
        MeanC = 0,

        /// <summary>
        /// Specifies that the threshold value is the weighted sum (i.e. cross-correlation
        /// with a Gaussian window) of the pixel neighborhood minus a constant.
        /// </summary>
        GaussianC = 1
    }

    /// <summary>
    /// Specifies flags for the flood fill algorithm.
    /// </summary>
    [Flags]
    public enum FloodFillFlags : int
    {
        /// <summary>
        /// Specifies the 8-connected flood fill algorithm.
        /// </summary>
        Connected8 = 8,

        /// <summary>
        /// Specifies the 4-connected flood fill algorithm.
        /// </summary>
        Connected4 = 4,

        /// <summary>
        /// Specifies that the difference between the current pixel and seed pixel is
        /// considered for flooding. Otherwise, the difference between neighbor pixels
        /// is considered (i.e. the range is floating).
        /// </summary>
        FixedRange = (1 << 16),

        /// <summary>
        /// Specifies that the method does not change the image but fills the mask.
        /// </summary>
        MaskOnly = (1 << 17)
    }

    /// <summary>
    /// Specifies available Hough transform variants for line detection.
    /// </summary>
    public enum HoughLinesMethod : int
    {
        /// <summary>
        /// Classical or standard Hough transform. Every line is represented by two
        /// floating-point numbers rho and theta, where rho is a distance between (0,0)
        /// point and the line, and theta is the angle between x-axis and the normal to
        /// the line.
        /// </summary>
        Standard = 0,

        /// <summary>
        /// Probabilistic Hough transform (more efficient in case the picture contains
        /// a few long linear segments). It returns line segments rather than the whole
        /// line. Each segment is represented by starting and ending points.
        /// </summary>
        Probabilistic = 1,

        /// <summary>
        /// Multi-scale variant of the classical Hough transform. The lines are encoded
        /// the same way as <see cref="Standard"/>.
        /// </summary>
        MultiScale = 2,
    }

    /// <summary>
    /// Specifies available Hough transform variants for circle detection.
    /// </summary>
    public enum HoughCirclesMethod : int
    {
        /// <summary>
        /// Implements the 2-1 Hough Transform for circle detection.
        /// </summary>
        Gradient = 3
    }
}
