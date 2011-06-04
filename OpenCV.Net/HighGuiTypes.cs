using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public enum ConvertImageFlags : int
    {
        None = 0,
        Flip = 1,
        SwapRB = 2
    }

    public enum LoadImageMode : int
    {
        /* 8bit, color or not */
        Unchanged = -1,
        /* 8bit, gray */
        Grayscale = 0,
        /* ?, color */
        Color = 1,
        /* any depth, ? */
        AnyDepth = 2,
        /* ?, any color */
        AnyColor = 4
    }

    public enum WindowFlags : int
    {
        //These 3 flags are used by cvSet/GetWindowProperty
        PROP_FULLSCREEN = 0,//to change/get window's fullscreen property
        PROP_AUTOSIZE = 1,//to change/get window's autosize property
        PROP_ASPECTRATIO = 2,//to change/get window's aspectratio property
        //
        //These 2 flags are used by cvNamedWindow and cvSet/GetWindowProperty
        NORMAL = 0x00000000,//the user can resize the window (no constraint)  / also use to switch a fullscreen window to a normal size
        AUTOSIZE = 0x00000001,//the user cannot resize the window, the size is constrainted by the image displayed
        //
        //Those flags are only for Qt
        GUI_EXPANDED = 0x00000000,//status bar and tool bar
        GUI_NORMAL = 0x00000010,//old fashious way
        //
        //These 3 flags are used by cvNamedWindow and cvSet/GetWindowProperty
        FULLSCREEN = 1,//change the window to fullscreen
        FREERATIO = 0x00000100,//the image expends as much as it can (no ratio constraint)
        KEEPRATIO = 0x00000000//the ration image is respected.
    }

    public enum CaptureProperty : int
    {
        POS_MSEC = 0,
        POS_FRAMES = 1,
        POS_AVI_RATIO = 2,
        FRAME_WIDTH = 3,
        FRAME_HEIGHT = 4,
        FPS = 5,
        FOURCC = 6,
        FRAME_COUNT = 7,
        FORMAT = 8,
        MODE = 9,
        BRIGHTNESS = 10,
        CONTRAST = 11,
        SATURATION = 12,
        HUE = 13,
        GAIN = 14,
        EXPOSURE = 15,
        CONVERT_RGB = 16,
        WHITE_BALANCE = 17,
        RECTIFICATION = 18,
        MONOCROME = 19
    }
}
