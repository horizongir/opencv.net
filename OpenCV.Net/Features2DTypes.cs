using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public struct CvStarKeypoint
    {
        public CvPoint Point;
        public int Size;
        public float Response;
    }

    public struct CvStarDetectorParams
    {
        public int MaxSize;
        public int ResponseThreshold;
        public int LineThresholdProjected;
        public int LineThresholdBinarized;
        public int SuppressNonmaxSize;

        public CvStarDetectorParams(int maxSize)
        {
            MaxSize = maxSize;
            ResponseThreshold = 30;
            LineThresholdProjected = 10;
            LineThresholdBinarized = 8;
            SuppressNonmaxSize = 5;
        }
    }
}
