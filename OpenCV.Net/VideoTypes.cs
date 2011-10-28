using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    [Flags]
    public enum LKFlowFlags : int
    {
        None = 0,
        PyrAReady = 1,
        PyrBReady = 2,
        InitialGuesses = 4,
        GetMinEigenVals = 8
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvFGDStatModelParams
    {
        public int Lc;			/* Quantized levels per 'color' component. Power of two, typically 32, 64 or 128.				*/
        public int N1c;			/* Number of color vectors used to model normal background color variation at a given pixel.			*/
        public int N2c;			/* Number of color vectors retained at given pixel.  Must be > N1c, typically ~ 5/3 of N1c.			*/
        /* Used to allow the first N1c vectors to adapt over time to changing background.				*/

        public int Lcc;			/* Quantized levels per 'color co-occurrence' component.  Power of two, typically 16, 32 or 64.			*/
        public int N1cc;		/* Number of color co-occurrence vectors used to model normal background color variation at a given pixel.	*/
        public int N2cc;		/* Number of color co-occurrence vectors retained at given pixel.  Must be > N1cc, typically ~ 5/3 of N1cc.	*/
        /* Used to allow the first N1cc vectors to adapt over time to changing background.				*/

        public int is_obj_without_holes;/* If TRUE we ignore holes within foreground blobs. Defaults to TRUE.						*/
        public int perform_morphing;	/* Number of erode-dilate-erode foreground-blob cleanup iterations.						*/
        /* These erase one-pixel junk blobs and merge almost-touching blobs. Default value is 1.			*/

        public float alpha1;		/* How quickly we forget old background pixel values seen.  Typically set to 0.1  				*/
        public float alpha2;		/* "Controls speed of feature learning". Depends on T. Typical value circa 0.005. 				*/
        public float alpha3;		/* Alternate to alpha2, used (e.g.) for quicker initial convergence. Typical value 0.1.				*/

        public float delta;		/* Affects color and color co-occurrence quantization, typically set to 2.					*/
        public float T;			/* "A percentage value which determines when new features can be recognized as new background." (Typically 0.9).*/
        public float minArea;		/* Discard foreground blobs whose bounding box is smaller than this threshold.					*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvGaussBGStatModelParams
    {
        public int win_size;               /* = 1/alpha */
        public int n_gauss;
        public double bg_threshold, std_threshold, minArea;
        public double weight_init, variance_init;
    }
}
