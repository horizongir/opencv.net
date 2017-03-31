using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an implementation of a brute-force descriptor matcher.
    /// </summary>
    public class BFMatcher : DescriptorMatcher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BFMatcher"/> class.
        /// </summary>
        /// <param name="normType">The norm used for matching descriptors.</param>
        /// <param name="crossCheck">Specifies whether kNN matching should return only consistent pairs.</param>
        public BFMatcher(NormTypes normType = NormTypes.L2, bool crossCheck = false)
        {
            var handle = NativeMethods.cv_features2d_BFMatcher_new(normType, crossCheck);
            SetHandle(handle);
        }

        /// <summary>
        /// Finds the best match for each descriptor in <paramref name="queryDescriptors"/>.
        /// </summary>
        /// <param name="queryDescriptors">The set of descriptors for which to find the best match.</param>
        /// <param name="trainDescriptors">The training set of descriptors.</param>
        /// <param name="matches">
        /// The collection of best matches found for each permissible descriptor in
        /// <paramref name="queryDescriptors"/>.
        /// </param>
        /// <param name="mask">
        /// The optional operation mask specifying permissible matches between input query descriptors
        /// and stored training descriptors.
        /// </param>
        public override void Match(Arr queryDescriptors, Arr trainDescriptors, DMatchCollection matches, Arr mask)
        {
            NativeMethods.cv_features2d_BFMatcher_match(this, queryDescriptors, trainDescriptors, matches, mask ?? Arr.Null);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="BFMatcher"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cv_features2d_BFMatcher_delete(handle);
            return true;
        }
    }
}
