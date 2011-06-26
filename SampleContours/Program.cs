using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net;

namespace SampleContours
{
    class Program
    {
        const int w = 500;
        static int levels = 3;
        static CvSeq contours;
        static NamedWindow contoursWindow;

        static void OnTrackbar(int pos)
        {
            IplImage cnt_img = new IplImage(new CvSize(w, w), 8, 3);
            CvSeq _contours = contours;
            int _levels = pos - 3;
            if (_levels <= 0) // get to the nearest face to make it look more funny
                _contours = _contours.HNext.HNext.HNext;
            cnt_img.SetZero();
            Core.cvDrawContours(cnt_img, _contours, CvScalar.Rgb(255, 0, 0), CvScalar.Rgb(0, 255, 0), _levels, 3, 16, new CvPoint(0, 0));
            contoursWindow.ShowImage(cnt_img);
            cnt_img.Close();
        }

        static void Main(string[] args)
        {
            CvMemStorage storage = new CvMemStorage(0);
            IplImage img = new IplImage(new CvSize(w, w), 8, 1);
            img.SetZero();

            for (int i = 0; i < 6; i++)
            {
                int dx = (i % 2) * 250 - 30;
                int dy = (i / 2) * 150;
                CvScalar white = CvScalar.Real(255);
                CvScalar black = CvScalar.Real(0);

                if (i == 0)
                {
                    for (int j = 0; j <= 10; j++)
                    {
                        double angle = (j + 5) * Math.PI / 21;
                        Core.cvLine(img, new CvPoint((int)Math.Round(dx + 100 + j * 10 - 80 * Math.Cos(angle)),
                            (int)Math.Round(dy + 100 - 90 * Math.Sin(angle))),
                            new CvPoint((int)Math.Round(dx + 100 + j * 10 - 30 * Math.Cos(angle)),
                            (int)Math.Round(dy + 100 - 30 * Math.Sin(angle))), white, 1, 8, 0);

                    }
                }

                Core.cvEllipse(img, new CvPoint(dx + 150, dy + 100), new CvSize(100, 70), 0, 0, 360, white, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 115, dy + 70), new CvSize(30, 20), 0, 0, 360, black, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 185, dy + 70), new CvSize(30, 20), 0, 0, 360, black, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 115, dy + 70), new CvSize(15, 15), 0, 0, 360, white, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 185, dy + 70), new CvSize(15, 15), 0, 0, 360, white, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 115, dy + 70), new CvSize(5, 5), 0, 0, 360, black, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 185, dy + 70), new CvSize(5, 5), 0, 0, 360, black, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 150, dy + 100), new CvSize(10, 5), 0, 0, 360, black, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 150, dy + 150), new CvSize(40, 10), 0, 0, 360, black, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 27, dy + 100), new CvSize(20, 35), 0, 0, 360, white, -1, 8, 0);
                Core.cvEllipse(img, new CvPoint(dx + 273, dy + 100), new CvSize(20, 35), 0, 0, 360, white, -1, 8, 0);
            }

            var imageWindow = new NamedWindow("image", WindowFlags.AUTOSIZE);
            imageWindow.ShowImage(img);

            ImgProc.cvFindContours(img, storage, out contours, CvContour.HeaderSize,
                                   ContourRetrieval.Tree, ContourApproximation.CHAIN_APPROX_SIMPLE, new CvPoint(0, 0));

            contours = ImgProc.cvApproxPoly(contours, CvContour.HeaderSize, storage, PolygonApproximation.CV_POLY_APPROX_DP, 3, 1);

            contoursWindow = new NamedWindow("contours", WindowFlags.AUTOSIZE);
            contoursWindow.CreateTrackbar("levels+3", ref levels, 7, OnTrackbar);

            OnTrackbar(levels);
            HighGui.cvWaitKey(0);
            storage.Close();
            img.Close();
        }
    }
}
