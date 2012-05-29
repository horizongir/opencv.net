using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class CvSeqReader
    {
        _CvSeqReader reader;

        public CvSeqReader(CvSeq seq)
            : this(seq, false)
        {
        }

        public CvSeqReader(CvSeq seq, bool reverse)
        {
            core.cvStartReadSeq(seq, out reader, reverse ? 1 : 0);
        }

        public IntPtr Current
        {
            get { return reader.ptr; }
        }

        public void NextElement(int elementSize)
        {
            if ((reader.ptr += elementSize).ToInt64() >= reader.block_max.ToInt64())
            {
                core.cvChangeSeqBlock(ref reader, 1);
            }
        }

        public void PreviousElement(int elementSize)
        {
            if ((reader.ptr -= elementSize).ToInt64() < reader.block_min.ToInt64())
            {
                core.cvChangeSeqBlock(ref reader, -1);
            }
        }
    }
}
