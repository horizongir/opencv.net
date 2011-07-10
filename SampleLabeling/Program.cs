using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net;

namespace SampleLabeling
{
    class Program
    {
        static IplImage src;
        static IplImage dst;
        static IplImage output;
        static CvMemStorage storage;
        static CvSeq contours;

        static int thresholdParam;
        static NamedWindow labelingWindow;

        static bool drawThreshold;
        static bool drawContours;
        static bool drawCentroids;
        static bool drawAxis;

        static void OnTrackbar(int pos)
        {
            ImgProc.cvThreshold(src, dst, pos, 255, ThresholdType.BinaryInv);
            if (drawThreshold) ImgProc.cvCvtColor(dst, output, ColorConversion.GRAY2BGR);
            else ImgProc.cvCvtColor(src, output, ColorConversion.GRAY2BGR);
            ImgProc.cvFindContours(dst, storage, out contours, CvContour.HeaderSize, ContourRetrieval.Tree, ContourApproximation.CHAIN_APPROX_SIMPLE, new CvPoint());

            CvMoments moments;
            if (drawContours) Core.cvDrawContours(output, contours, CvScalar.Rgb(255, 0, 0), CvScalar.Rgb(0, 0, 255), 3, 1, 8, new CvPoint());
            while (contours != null && !contours.IsInvalid)
            {
                ImgProc.cvMoments(contours, out moments, 0);

                var x = moments.m10 / moments.m00;
                var y = moments.m01 / moments.m00;
                var center = new CvPoint((int)x, (int)y);

                var miu20 = moments.m20 / moments.m00 - x * x;
                var miu02 = moments.m02 / moments.m00 - y * y;
                var miu11 = moments.m11 / moments.m00 - x * y;
                var angle = 0.5 * Math.Atan2(2 * miu11, (miu20 - miu02));
                var pt1 = new CvPoint((int)(x + 10 * Math.Cos(angle)), (int)(y + 10 * Math.Sin(angle)));
                var pt2 = new CvPoint((int)(x - 10 * Math.Cos(angle)), (int)(y - 10 * Math.Sin(angle)));

                if (drawAxis) Core.cvLine(output, pt1, pt2, CvScalar.Rgb(0, 0, 255), 2, 8, 0);
                if (drawCentroids) Core.cvCircle(output, new CvPoint((int)x, (int)y), 2, CvScalar.Rgb(255, 0, 0), -1, 8, 0);

                contours = contours.HNext;
            }

            labelingWindow.ShowImage(output);
        }

        static void Main(string[] args)
        {
            string filename = args.Length == 1 ? args[0] : (string)"M382-e.jpg";
            if ((src = HighGui.cvLoadImage(filename, LoadImageMode.Grayscale)).IsInvalid)
                return;

            dst = src.Clone();
            output = new IplImage(dst.Size, 8, 3);
            storage = new CvMemStorage(0);
            drawThreshold = true;

            var imageWindow = new NamedWindow("Image", WindowFlags.AUTOSIZE);
            imageWindow.ShowImage(src);

            labelingWindow = new NamedWindow("Labeling", WindowFlags.AUTOSIZE);
            labelingWindow.CreateTrackbar("Threshold", ref thresholdParam, 255, OnTrackbar);

            while(true)
            {
                int c;

                OnTrackbar(thresholdParam);
                c = HighGui.cvWaitKey(0);

                if ((char)c == 27)
                    break;
                if ((char)c == 't')
                    drawThreshold = !drawThreshold;
                else if ((char)c == 'c')
                    drawContours = !drawContours;
                else if ((char)c == 'p')
                    drawCentroids = !drawCentroids;
                else if ((char)c == 'o')
                    drawAxis = !drawAxis;
            }
        }
    }
}
