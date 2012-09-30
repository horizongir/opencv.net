using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public delegate void CvMouseCallback(MouseEvent evt, int x, int y, MouseEventFlags flags, IntPtr param);

    public delegate void CvTrackbarCallback(int pos);

    public enum MouseEvent : int
    {
        MOUSEMOVE = 0,
        LBUTTONDOWN = 1,
        RBUTTONDOWN = 2,
        MBUTTONDOWN = 3,
        LBUTTONUP = 4,
        RBUTTONUP = 5,
        MBUTTONUP = 6,
        LBUTTONDBLCLK = 7,
        RBUTTONDBLCLK = 8,
        MBUTTONDBLCLK = 9
    }

    [Flags]
    public enum MouseEventFlags : int
    {
        LBUTTON = 1,
        RBUTTON = 2,
        MBUTTON = 4,
        CTRLKEY = 8,
        SHIFTKEY = 16,
        ALTKEY = 32
    }

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
        PROP_FULLSCREEN = 0, //to change/get window's fullscreen property
        PROP_AUTOSIZE = 1, //to change/get window's autosize property
        PROP_ASPECTRATIO = 2, //to change/get window's aspectratio property
        PROP_OPENGL = 3, //to change/get window's opengl support

        //These 2 flags are used by cvNamedWindow and cvSet/GetWindowProperty
        NORMAL = 0x00000000, //the user can resize the window (no constraint)  / also use to switch a fullscreen window to a normal size
        AUTOSIZE = 0x00000001, //the user cannot resize the window, the size is constrainted by the image displayed
        OPENGL = 0x00001000, //window with opengl support

        //Those flags are only for Qt
        GUI_EXPANDED = 0x00000000, //status bar and tool bar
        GUI_NORMAL = 0x00000010, //old fashious way

        //These 3 flags are used by cvNamedWindow and cvSet/GetWindowProperty
        FULLSCREEN = 1,//change the window to fullscreen
        FREERATIO = 0x00000100,//the image expends as much as it can (no ratio constraint)
        KEEPRATIO = 0x00000000//the ration image is respected.
    }

    public enum CaptureProperty : int
    {
        // modes of the controlling registers (can be: auto, manual, auto single push, absolute Latter allowed with any other mode)
        // every feature can have only one mode turned on at a time
        DC1394_OFF = -4,  //turn the feature off (not controlled manually nor automatically)
        DC1394_MODE_MANUAL = -3, //set automatically when a value of the feature is set by the user
        DC1394_MODE_AUTO = -2,
        DC1394_MODE_ONE_PUSH_AUTO = -1,
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
        WHITE_BALANCE_BLUE_U = 17,
        RECTIFICATION = 18,
        MONOCROME = 19,
        SHARPNESS = 20,
        AUTO_EXPOSURE = 21, // exposure control done by camera,
        // user can adjust refernce level
        // using this feature
        GAMMA = 22,
        TEMPERATURE = 23,
        TRIGGER = 24,
        TRIGGER_DELAY = 25,
        WHITE_BALANCE_RED_V = 26,
        ZOOM = 27,
        FOCUS = 28,
        GUID = 29,
        ISO_SPEED = 30,
        MAX_DC1394 = 31,
        BACKLIGHT = 32,
        PAN = 33,
        TILT = 34,
        ROLL = 35,
        IRIS = 36,
        SETTINGS = 37,

        AUTOGRAB = 1024, // property for highgui class CvCapture_Android only
        SUPPORTED_PREVIEW_SIZES_STRING = 1025, // readonly, tricky property, returns cpnst char* indeed
        PREVIEW_FORMAT = 1026, // readonly, tricky property, returns cpnst char* indeed

        // OpenNI map generators
        OPENNI_DEPTH_GENERATOR = 1 << 31,
        OPENNI_IMAGE_GENERATOR = 1 << 30,
        OPENNI_GENERATORS_MASK = OPENNI_DEPTH_GENERATOR + OPENNI_IMAGE_GENERATOR,

        // Properties of cameras available through OpenNI interfaces
        OPENNI_OUTPUT_MODE = 100,
        OPENNI_FRAME_MAX_DEPTH = 101, // in mm
        OPENNI_BASELINE = 102, // in mm
        OPENNI_FOCAL_LENGTH = 103, // in pixels
        OPENNI_REGISTRATION = 104, // flag
        OPENNI_REGISTRATION_ON = OPENNI_REGISTRATION, // flag that synchronizes the remapping depth map to image map
        // by changing depth generator's view point (if the flag is "on") or
        // sets this view point to its normal one (if the flag is "off").
        OPENNI_APPROX_FRAME_SYNC = 105,
        OPENNI_MAX_BUFFER_SIZE = 106,
        OPENNI_CIRCLE_BUFFER = 107,
        OPENNI_MAX_TIME_DURATION = 108,

        OPENNI_GENERATOR_PRESENT = 109,

        OPENNI_IMAGE_GENERATOR_PRESENT = OPENNI_IMAGE_GENERATOR + OPENNI_GENERATOR_PRESENT,
        OPENNI_IMAGE_GENERATOR_OUTPUT_MODE = OPENNI_IMAGE_GENERATOR + OPENNI_OUTPUT_MODE,
        OPENNI_DEPTH_GENERATOR_BASELINE = OPENNI_DEPTH_GENERATOR + OPENNI_BASELINE,
        OPENNI_DEPTH_GENERATOR_FOCAL_LENGTH = OPENNI_DEPTH_GENERATOR + OPENNI_FOCAL_LENGTH,
        OPENNI_DEPTH_GENERATOR_REGISTRATION = OPENNI_DEPTH_GENERATOR + OPENNI_REGISTRATION,
        OPENNI_DEPTH_GENERATOR_REGISTRATION_ON = OPENNI_DEPTH_GENERATOR_REGISTRATION,

        // Properties of cameras available through GStreamer interface
        GSTREAMER_QUEUE_LENGTH = 200, // default is 1
        PVAPI_MULTICASTIP = 300, // ip for anable multicast master mode. 0 for disable multicast

        // Properties of cameras available through XIMEA SDK interface
        XI_DOWNSAMPLING = 400,      // Change image resolution by binning or skipping.
        XI_DATA_FORMAT = 401,       // Output data format.
        XI_OFFSET_X = 402,      // Horizontal offset from the origin to the area of interest (in pixels).
        XI_OFFSET_Y = 403,      // Vertical offset from the origin to the area of interest (in pixels).
        XI_TRG_SOURCE = 404,      // Defines source of trigger.
        XI_TRG_SOFTWARE = 405,      // Generates an internal trigger. PRM_TRG_SOURCE must be set to TRG_SOFTWARE.
        XI_GPI_SELECTOR = 406,      // Selects general purpose input
        XI_GPI_MODE = 407,      // Set general purpose input mode
        XI_GPI_LEVEL = 408,      // Get general purpose level
        XI_GPO_SELECTOR = 409,      // Selects general purpose output
        XI_GPO_MODE = 410,      // Set general purpose output mode
        XI_LED_SELECTOR = 411,      // Selects camera signalling LED
        XI_LED_MODE = 412,      // Define camera signalling LED functionality
        XI_MANUAL_WB = 413,      // Calculates White Balance(must be called during acquisition)
        XI_AUTO_WB = 414,      // Automatic white balance
        XI_AEAG = 415,      // Automatic exposure/gain
        XI_EXP_PRIORITY = 416,      // Exposure priority (0.5 - exposure 50%, gain 50%).
        XI_AE_MAX_LIMIT = 417,      // Maximum limit of exposure in AEAG procedure
        XI_AG_MAX_LIMIT = 418,      // Maximum limit of gain in AEAG procedure
        XI_AEAG_LEVEL = 419,       // Average intensity of output signal AEAG should achieve(in %)
        XI_TIMEOUT = 420,       // Image capture timeout in milliseconds

        // Properties for Android cameras
        ANDROID_FLASH_MODE = 8001,
        ANDROID_FOCUS_MODE = 8002,
        ANDROID_WHITE_BALANCE = 8003,
        ANDROID_ANTIBANDING = 8004,
        ANDROID_FOCAL_LENGTH = 8005,
        ANDROID_FOCUS_DISTANCE_NEAR = 8006,
        ANDROID_FOCUS_DISTANCE_OPTIMAL = 8007,
        ANDROID_FOCUS_DISTANCE_FAR = 8008,

        // Properties of cameras available through AVFOUNDATION interface
        IOS_DEVICE_FOCUS = 9001,
        IOS_DEVICE_EXPOSURE = 9002,
        IOS_DEVICE_FLASH = 9003,
        IOS_DEVICE_WHITEBALANCE = 9004,
        IOS_DEVICE_TORCH = 9005
    }
}
