using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents all the moments up to the third order of a polygon or rasterized shape.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Moments
    {
        /// <summary>
        /// The spatial moments of the polygon or rasterized shape.
        /// </summary>
        public double M00, M10, M01, M20, M11, M02, M30, M21, M12, M03;

        /// <summary>
        /// The central moments of the polygon or rasterized shape.
        /// </summary>
        public double Mu20, Mu11, Mu02, Mu30, Mu21, Mu12, Mu03;

        /// <summary>
        /// The inverse of the square root of the first spatial moment.
        /// </summary>
        public double InvSqrtM00;

        /// <summary>
        /// Initializes a new instance of the <see cref="Moments"/> structure from the
        /// specified polygon or rasterized shape.
        /// </summary>
        /// <param name="arr">
        /// The handle to the polygon (<see cref="Seq"/>) or rasterized shape (<see cref="IplImage"/>)
        /// from which to compute the moments.
        /// </param>
        /// <param name="binary">
        /// If <b>true</b>, all non-zero image pixels are treated as one.
        /// Used for images only.
        /// </param>
        public Moments(CVHandle arr, bool binary = false)
        {
            NativeMethods.cvMoments(arr, out this, binary ? 1 : 0);
        }

        /// <summary>
        /// Gets the spatial moment with the specified <paramref name="xOrder"/> and <paramref name="yOrder"/>.
        /// </summary>
        /// <param name="xOrder">The x-order of the retrieved moment.</param>
        /// <param name="yOrder">The y-order of the retrieved moment.</param>
        /// <returns>
        /// The spatial moment with the specified <paramref name="xOrder"/> and <paramref name="yOrder"/>.
        /// </returns>
        public double GetSpatialMoment(int xOrder, int yOrder)
        {
            return NativeMethods.cvGetSpatialMoment(ref this, xOrder, yOrder);
        }

        /// <summary>
        /// Gets the central moment with the specified <paramref name="xOrder"/> and <paramref name="yOrder"/>.
        /// </summary>
        /// <param name="xOrder">The x-order of the retrieved moment.</param>
        /// <param name="yOrder">The y-order of the retrieved moment.</param>
        /// <returns>
        /// The central moment with the specified <paramref name="xOrder"/> and <paramref name="yOrder"/>.
        /// </returns>
        public double GetCentralMoment(int xOrder, int yOrder)
        {
            return NativeMethods.cvGetCentralMoment(ref this, xOrder, yOrder);
        }

        /// <summary>
        /// Gets the normalized central moment with the specified <paramref name="xOrder"/> and
        /// <paramref name="yOrder"/>.
        /// </summary>
        /// <param name="xOrder">The x-order of the retrieved moment.</param>
        /// <param name="yOrder">The y-order of the retrieved moment.</param>
        /// <returns>
        /// The normalized central moment with the specified <paramref name="xOrder"/> and
        /// <paramref name="yOrder"/>.
        /// </returns>
        public double GetNormalizedCentralMoment(int xOrder, int yOrder)
        {
            return NativeMethods.cvGetNormalizedCentralMoment(ref this, xOrder, yOrder);
        }

        /// <summary>
        /// Computes the seven Hu moments invariant to image scale, rotation, and reflection except
        /// the seventh one, whose sign is changed by reflection.
        /// </summary>
        /// <returns>An instance of <see cref="HuMoments"/> containing the seven Hu moments.</returns>
        public HuMoments GetHuMoments()
        {
            HuMoments huMoments;
            NativeMethods.cvGetHuMoments(ref this, out huMoments);
            return huMoments;
        }
    }
}
