using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents the block matching algorithm for computing stereo correspondence.
    /// </summary>
    public class StereoBM : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StereoBM"/> class with the specified
        /// parameter <paramref name="preset"/> and <paramref name="numberOfDisparities"/>.
        /// </summary>
        /// <param name="preset">Specifies the whole set of algorithm parameters.</param>
        /// <param name="numberOfDisparities">
        /// The disparity search range. For each pixel algorithm will find the best disparity from 0
        /// (default minimum disparity) to <paramref name="numberOfDisparities"/>. The search range
        /// can then be shifted by changing the minimum disparity.
        /// </param>
        public StereoBM(StereoBMPreset preset = StereoBMPreset.Basic, int numberOfDisparities = 0)
            : base(true)
        {
            var pState = NativeMethods.cvCreateStereoBMState(preset, numberOfDisparities);
            SetHandle(pState);
        }

        /// <summary>
        /// Gets or sets the block matching pre-filter type.
        /// </summary>
        public StereoBMPreFilterType PreFilterType
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->preFilterType;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->preFilterType = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the pre-filter averaging window size. Must be odd.
        /// </summary>
        public int PreFilterSize
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->preFilterSize;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->preFilterSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the cap for pre-filtering. The output is clipped to be within
        /// [-PreFilterCap,PreFilterCap].
        /// </summary>
        public int PreFilterCap
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->preFilterCap;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->preFilterCap = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Sum of Absolute Differences window size. Must be odd.
        /// </summary>
        public int SadWindowSize
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->SADWindowSize;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->SADWindowSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum disparity (can be negative).
        /// </summary>
        public int MinDisparity
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->minDisparity;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->minDisparity = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the difference between the maximum disparity and minimum disparity.
        /// </summary>
        public int NumberOfDisparities
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->numberOfDisparities;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->numberOfDisparities = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the texture threshold. The disparity is only computed for pixels
        /// with textured enough neighborhood.
        /// </summary>
        public int TextureThreshold
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->textureThreshold;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->textureThreshold = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the uniqueness ratio. The computed computed disparity d* should
        /// only be accepted if SAD(d) >= SAD(d*)*(1 + uniquenessRatio/100) for any
        /// d != d*+/-1 within the search range.
        /// </summary>
        public int UniquenessRatio
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->uniquenessRatio;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->uniquenessRatio = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the disparity variation window.
        /// </summary>
        public int SpeckleWindowSize
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->speckleWindowSize;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->speckleWindowSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the acceptable range of variation in window.
        /// </summary>
        public int SpeckleRange
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->speckleRange;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->speckleRange = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use smaller windows. The results
        /// may be more accurate, at the expense of slower processing.
        /// </summary>
        public bool TrySmallerWindows
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->trySmallerWindows > 0;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->trySmallerWindows = value ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets the clipping ROI for the left image.
        /// </summary>
        public Rect Roi1
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->roi1;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->roi1 = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the clipping ROI for the right image.
        /// </summary>
        public Rect Roi2
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->roi2;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->roi2 = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum allowed difference between the explicitly computed left-to-right
        /// disparity map and the implicitly computed right-to-left disparity. If for some pixel the
        /// difference is larger than the specified threshold, the disparity at the pixel is
        /// invalidated. By default this parameter is set to (-1), which means that the left-right
        /// check is not performed.
        /// </summary>
        public int Disparity12MaxDiff
        {
            get
            {
                unsafe
                {
                    return ((_CvStereoBMState*)handle.ToPointer())->disp12MaxDiff;
                }
            }
            set
            {
                unsafe
                {
                    ((_CvStereoBMState*)handle.ToPointer())->disp12MaxDiff = value;
                }
            }
        }

        /// <summary>
        /// Computes the disparity map using block matching algorithm.
        /// </summary>
        /// <param name="left">The left single-channel, 8-bit image.</param>
        /// <param name="right">The right image of the same size and the same type.</param>
        /// <param name="disparity">
        /// The output single-channel 16-bit signed, or 32-bit floating-point disparity map of the
        /// same size as input images. In the first case the computed disparities are represented
        /// as fixed-point numbers with 4 fractional bits (i.e. the computed disparity values are
        /// multiplied by 16 and rounded to integers).
        /// </param>
        public void FindStereoCorrespondence(Arr left, Arr right, Arr disparity)
        {
            NativeMethods.cvFindStereoCorrespondenceBM(left, right, disparity, this);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="StereoBM"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseStereoBMState(ref handle);
            return true;
        }
    }
}
