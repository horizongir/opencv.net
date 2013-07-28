using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents information about a 3D object model for camera pose estimation.
    /// </summary>
    public class CvPOSITObject : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CvPOSITObject"/> class with the
        /// specified 3D object model points.
        /// </summary>
        /// <param name="points">
        /// The points representing the vertices of the 3D model.
        /// </param>
        public CvPOSITObject(CvPoint3D32f[] points)
            : base(true)
        {
            var pPosit = NativeMethods.cvCreatePOSITObject(points, points.Length);
            SetHandle(pPosit);
        }

        /// <summary>
        /// Implements the POSIT algorithm.
        /// </summary>
        /// <param name="imagePoints">Pointer to the object point projections on the 2D image plane.</param>
        /// <param name="focalLength">Focal length of the camera used.</param>
        /// <param name="criteria">Termination criteria of the iterative POSIT algorithm.</param>
        /// <param name="rotationMatrix">The output rotation matrix representing the estimated pose.</param>
        /// <param name="translationVector">The output translation vector representing the estimated pose.</param>
        public void POSIT(
            CvPoint2D32f[] imagePoints,
            double focalLength,
            CvTermCriteria criteria,
            float[] rotationMatrix,
            float[] translationVector)
        {
            NativeMethods.cvPOSIT(this, imagePoints, focalLength, criteria, rotationMatrix, translationVector);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvPOSITObject"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleasePOSITObject(ref handle);
            return true;
        }
    }
}
