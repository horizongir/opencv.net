﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an algorithm for matching two sets of descriptors.
    /// </summary>
    public interface IDescriptorMatcher
    {
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
        void Match(Arr queryDescriptors, Arr trainDescriptors, DMatchCollection matches, Arr mask = null);
    }
}
