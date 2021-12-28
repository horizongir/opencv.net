using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a termination criteria for iterative algorithms.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TermCriteria
    {
        /// <summary>
        /// Specifies the particular combination of criteria to use.
        /// </summary>
        public TermCriteriaType Type;

        /// <summary>
        /// The maximum number of iterations.
        /// </summary>
        public int MaxIter;

        /// <summary>
        /// The minimum required accuracy.
        /// </summary>
        public double Epsilon;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermCriteria"/> structure
        /// with the specified termination mode, maximum number of iterations and
        /// required accuracy.
        /// </summary>
        /// <param name="type">The particular combination of criteria to use.</param>
        /// <param name="maxIter">The maximum number of iterations.</param>
        /// <param name="epsilon">The minimum required accuracy.</param>
        public TermCriteria(TermCriteriaType type, int maxIter, double epsilon)
        {
            Type = type;
            MaxIter = maxIter;
            Epsilon = epsilon;
        }
    }
}
