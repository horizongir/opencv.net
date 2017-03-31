using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies available operation flags for drawing keypoints and keypoint matches.
    /// </summary>
    [Flags]
    public enum DrawMatchesFlags : int
    {
        /// <summary>
        /// Specifies the default operation mode. Output image contents will be recreated.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that matches will be drawn on the existing contents of the output image.
        /// </summary>
        DrawOverOutput = 1,

        /// <summary>
        /// Specifies that single keypoints will not be drawn.
        /// </summary>
        DontDrawSinglePoints = 2,

        /// <summary>
        /// Specifies that for each keypoint the circle around the keypoint and its
        /// orientation will be drawn.
        /// </summary>
        DrawRichKeypoints = 4
    }

    /// <summary>
    /// Specifies the type of score used to rank features in the ORB keypoint detector and descriptor extractor.
    /// </summary>
    public enum OrbScoreType : int
    {
        /// <summary>
        /// Specifies that the Harris algorithm should be used to rank features.
        /// </summary>
        HarrisScore = 0,

        /// <summary>
        /// Specifies that the results of the FAST corner detector should be used to rank features.
        /// </summary>
        FastScore = 1
    }

    /// <summary>
    /// Specifies available operation flags for the FAST corner detector.
    /// </summary>
    public enum FastDetectorType : int
    {
        /// <summary>
        /// Specifies a pixel neighbourhood perimeter of 8 pixels.
        /// </summary>
        Fast8 = 0,

        /// <summary>
        /// Specifies a pixel neighbourhood perimeter of 12 pixels.
        /// </summary>
        Fast12 = 1,

        /// <summary>
        /// Specifies a pixel neighbourhood perimeter of 16 pixels.
        /// </summary>
        Fast16 = 2
    }
}
