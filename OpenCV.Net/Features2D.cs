using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public static class Features2D
    {
        const string libName = "opencv_features2d231";

        public static CvSeq cvGetStarKeypoints(CvArr img, CvMemStorage storage, CvStarDetectorParams detectorParams)
        {
            var keypoints = features2d.cvGetStarKeypoints(img, storage, detectorParams);
            keypoints.SetOwnerStorage(storage);
            return keypoints;
        }

        // If useProvidedKeyPts!=0, keypoints are not detected, but descriptors are computed
        //  at the locations provided in keypoints (a CvSeq of CvSURFPoint).
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvExtractSURF(
            CvArr img, CvArr mask,
            out CvSeq keypoints, out CvSeq descriptors,
            CvMemStorage storage, CvSURFParams _params,
            int useProvidedKeyPts);
    }
}
