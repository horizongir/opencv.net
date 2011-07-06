using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net;

namespace SampleStarDetector
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            string filename = args.Length > 1 ? args[0] : "lena.jpg";
            IplImage img = HighGui.cvLoadImage(filename, 0);
            CvMemStorage storage = new CvMemStorage(0);
            CvSeq keypoints;
            int i;

            if (img == null)
                return;

            var imageWindow = new NamedWindow("image", WindowFlags.AUTOSIZE);
            imageWindow.ShowImage(img);
            var featuresWindow = new NamedWindow("features", WindowFlags.AUTOSIZE);
            var cimg = new IplImage(img.Size, 8, 3);
            ImgProc.cvCvtColor(img, cimg, ColorConversion.GRAY2BGR);

            keypoints = Features2D.cvGetStarKeypoints(img, storage, new CvStarDetectorParams(45));

            for (i = 0; i < (keypoints != null ? keypoints.Total : 0); i++)
            {
                CvStarKeypoint kpt = *((CvStarKeypoint*)keypoints.GetElement(i).ToPointer());
                int r = kpt.Size / 2;
                Core.cvCircle(cimg, kpt.Point, r, CvScalar.Rgb(0, 255, 0), 1, 8, 0);
                Core.cvLine(cimg, new CvPoint(kpt.Point.X + r, kpt.Point.Y + r),
                    new CvPoint(kpt.Point.X - r, kpt.Point.Y - r), CvScalar.Rgb(0, 255, 0), 1, 8, 0);
                Core.cvLine(cimg, new CvPoint(kpt.Point.X - r, kpt.Point.Y + r),
                    new CvPoint(kpt.Point.X + r, kpt.Point.Y - r), CvScalar.Rgb(0, 255, 0), 1, 8, 0);
            }

            featuresWindow.ShowImage(cimg);
            HighGui.cvWaitKey(0);
        }
    }
}
