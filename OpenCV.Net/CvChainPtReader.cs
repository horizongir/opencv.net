using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class CvChainPtReader
    {
        _CvChainPtReader reader;

        public CvChainPtReader(CvChain chain)
        {
            imgproc.cvStartReadChainPoints(chain, out reader);
        }

        public CvPoint ReadChainPoint()
        {
            return imgproc.cvReadChainPoint(ref reader);
        }
    }
}
