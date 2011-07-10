using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net;

namespace SampleMorphology
{
    class Program
    {
        static IplImage src;
        static IplImage dst;

        static IplConvKernel element;
        static int max_iters = 10;
        static int open_pos;
        static int erode_pos;
        static NamedWindow openCloseWindow;
        static NamedWindow erodeDilateWindow;
        static StructuringElementShape element_shape;

        static void OpenClose(int pos)
        {
            int n = pos - max_iters;
            int an = n > 0 ? n : -n;
            element = new IplConvKernel(an * 2 + 1, an * 2 + 1, an, an, element_shape);
            if (n < 0)
            {
                ImgProc.cvErode(src, dst, element, 1);
                ImgProc.cvDilate(dst, dst, element, 1);
            }
            else
            {
                ImgProc.cvDilate(src, dst, element, 1);
                ImgProc.cvErode(dst, dst, element, 1);
            }
            element.Close();
            openCloseWindow.ShowImage(dst);
        }

        // callback function for erode/dilate trackbar
        static void ErodeDilate(int pos)
        {
            int n = pos - max_iters;
            int an = n > 0 ? n : -n;
            element = new IplConvKernel(an * 2 + 1, an * 2 + 1, an, an, element_shape);
            if (n < 0)
            {
                ImgProc.cvErode(src, dst, element, 1);
            }
            else
            {
                ImgProc.cvDilate(src, dst, element, 1);
            }
            element.Close();
            erodeDilateWindow.ShowImage(dst);
        }

        static void Main(string[] args)
        {
            string filename = args.Length == 1 ? args[0] : (string)"baboon.jpg";
            if ((src = HighGui.cvLoadImage(filename, LoadImageMode.Color)).IsInvalid)
                return;

            dst = src.Clone();

            //create windows for output images
            openCloseWindow = new NamedWindow("Open/Close", WindowFlags.AUTOSIZE);
            erodeDilateWindow = new NamedWindow("Erode/Dilate", WindowFlags.AUTOSIZE);

            open_pos = erode_pos = max_iters;
            openCloseWindow.CreateTrackbar("iterations", ref open_pos, max_iters * 2 + 1, OpenClose);
            erodeDilateWindow.CreateTrackbar("iterations", ref erode_pos, max_iters * 2 + 1, ErodeDilate);

            for (; ; )
            {
                int c;

                OpenClose(open_pos);
                ErodeDilate(erode_pos);
                c = HighGui.cvWaitKey(0);

                if ((char)c == 27)
                    break;
                if ((char)c == 'e')
                    element_shape = StructuringElementShape.Ellipse;
                else if ((char)c == 'r')
                    element_shape = StructuringElementShape.Rectangle;
                else if ((char)c == 'c')
                    element_shape = StructuringElementShape.Cross;
                else if ((char)c == ' ')
                    element_shape = (StructuringElementShape)(((int)element_shape + 1) % 3);
            }

            //release images
            src.Close();
            dst.Close();

            //destroy windows
            openCloseWindow.Dispose();
            erodeDilateWindow.Dispose();
        }
    }
}
