﻿using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a collection of nodes.
    /// </summary>
    public class CvSet : CvSeq
    {
        internal CvSet()
        {
        }

        private CvSet(int elementType, SequenceKind kind, SequenceFlags flags, CvMemStorage storage)
            : base(storage)
        {
            var pSet = NativeMethods.cvCreateSet(elementType | (int)kind | (int)flags, SeqHelper.SetHeaderSize, MatHelper.GetElemSize(elementType), storage);
            SetHandle(pSet);
        }

        /// <summary>
        /// Removes all elements from the set.
        /// </summary>
        public override void Clear()
        {
            NativeMethods.cvClearSet(this);
        }
    }
}