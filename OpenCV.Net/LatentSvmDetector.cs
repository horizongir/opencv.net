using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a trained latent SVM detector.
    /// </summary>
    public class LatentSvmDetector : CVHandle
    {
        internal LatentSvmDetector()
            : base(true)
        {
        }

        /// <summary>
        /// Find rectangular regions in the given image that are likely to contain objects and corresponding confidence levels.
        /// </summary>
        /// <param name="image">The input image on which to detect objects.</param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles.</param>
        /// <param name="overlapThreshold">Threshold for the non-maximum suppression algorithm.</param>
        /// <param name="numThreads">Number of threads used in parallel version of the algorithm.</param>
        /// <returns>A sequence of detected objects of type <see cref="ObjectDetection"/>.</returns>
        public Seq DetectObjects(
            IplImage image,
            MemStorage storage,
            float overlapThreshold = 0.5f,
            int numThreads = -1)
        {
            var objects = NativeMethods.cvLatentSvmDetectObjects(image, this, storage, overlapThreshold, numThreads);
            if (objects.IsInvalid) return null;
            objects.SetOwnerStorage(storage);
            return objects;
        }

        /// <summary>
        /// Loads trained detector from a file.
        /// </summary>
        /// <param name="fileName">Name of the file containing the description of a trained detector.</param>
        /// <returns>A newly created instance of the <see cref="LatentSvmDetector"/> class.</returns>
        public static LatentSvmDetector Load(string fileName)
        {
            return NativeMethods.cvLoadLatentSvmDetector(fileName);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="LatentSvmDetector"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseLatentSvmDetector(ref handle);
            return true;
        }
    }
}
