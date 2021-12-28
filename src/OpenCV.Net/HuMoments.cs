using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents the seven invariant Hu image moments.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HuMoments
    {
        /// <summary>
        /// The seven Hu moments invariant to image scale, rotation, and reflection except
        /// the seventh one, whose sign is changed by reflection.
        /// </summary>
        public double Hu1, Hu2, Hu3, Hu4, Hu5, Hu6, Hu7;
    }
}
