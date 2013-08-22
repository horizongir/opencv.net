using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a cascade or tree of boosted Haar stage classifiers.
    /// </summary>
    public class HaarClassifierCascade : CVHandle
    {
        internal HaarClassifierCascade(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        /// <summary>
        /// Loads a boosted Haar classifier cascade from a file. This method ensures that all dependencies are loaded
        /// and is a temporary workaround to ensure <see cref="CV.Load(string,MemStorage,string)"/> does not throw
        /// an error.
        /// </summary>
        /// <param name="fileName">The path to the trained classifier cascade.</param>
        /// <returns>A new instance of the <see cref="HaarClassifierCascade"/> class.</returns>
        public static HaarClassifierCascade Load(string fileName)
        {
            IntPtr ptr = IntPtr.Zero;
            NativeMethods.cvReleaseHaarClassifierCascade(ref ptr);
            return CV.Load<HaarClassifierCascade>(fileName);
        }

        /// <summary>
        /// Detects objects in the image.
        /// </summary>
        /// <param name="image">Image to detect objects in.</param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles.</param>
        /// <param name="scaleFactor">
        /// The factor by which the search window is scaled between the subsequent scans, 1.1 means increasing window by 10%.
        /// </param>
        /// <param name="minNeighbors">
        /// Minimum number (minus 1) of neighbor rectangles that make up an object. All the groups of a smaller number of
        /// rectangles than <paramref name="minNeighbors"/>-1 are rejected. If it is 0, the method does not do any grouping
        /// at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a
        /// customized grouping procedure.
        /// </param>
        /// <param name="flags">Mode of operation.</param>
        /// <param name="minSize">
        /// Minimum window size. By default, it is set to the size of samples the classifier has been trained on
        /// (20x20 for face detection).
        /// </param>
        /// <param name="maxSize">Maximum window size. By default, it is set to the total image size.</param>
        /// <returns>The sequence of grouped (or ungrouped) object rectangles.</returns>
        public Seq DetectObjects(
            Arr image,
            MemStorage storage,
            double scaleFactor = 1.1,
            int minNeighbors = 3,
            HaarDetectObjectFlags flags = HaarDetectObjectFlags.None,
            Size minSize = default(Size),
            Size maxSize = default(Size))
        {
            var objects = NativeMethods.cvHaarDetectObjects(image, this, storage, scaleFactor, minNeighbors, flags, minSize, maxSize);
            if (objects.IsInvalid) return null;
            objects.SetOwnerStorage(storage);
            return objects;
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="HaarClassifierCascade"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseHaarClassifierCascade(ref handle);
            return true;
        }
    }
}
