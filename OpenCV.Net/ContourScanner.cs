using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a contour scanning process.
    /// </summary>
    public sealed class ContourScanner : SafeHandleZeroOrMinusOneIsInvalid
    {
        MemStorage owner;

        internal ContourScanner()
            : base(true)
        {
        }

        internal void SetOwnerStorage(MemStorage storage)
        {
            owner = storage;
        }

        /// <summary>
        /// Finds the next contour in the image.
        /// </summary>
        /// <returns>
        /// The next contour in the image or <b>null</b> if there are no more contours.
        /// </returns>
        public Seq FindNextContour()
        {
            var contour = NativeMethods.cvFindNextContour(this);
            if (contour.IsInvalid) return null;
            contour.SetOwnerStorage(owner);
            return contour;
        }

        /// <summary>
        /// Replaces the currently retrieved contour.
        /// </summary>
        /// <param name="newContour">The substituting contour.</param>
        public void SubstituteContour(Seq newContour)
        {
            NativeMethods.cvSubstituteContour(this, newContour ?? Seq.Null);
        }

        /// <summary>
        /// Finishes the scanning process.
        /// </summary>
        /// <returns>
        /// The first contour on the highest level.
        /// </returns>
        public Seq EndFindContours()
        {
            try
            {
                var contours = NativeMethods.cvEndFindContours(ref handle);
                if (contours.IsInvalid) return null;
                contours.SetOwnerStorage(owner);
                return contours;
            }
            finally { SetHandleAsInvalid(); }
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="ContourScanner"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            if (!IsClosed) EndFindContours();
            owner = null;
            return true;
        }
    }
}
