using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies the predefined font weights for Qt fonts.
    /// </summary>
    public enum FontWeight : int
    {
        /// <summary>
        /// Specifies a light Qt font weight.
        /// </summary>
        Light = 25,

        /// <summary>
        /// Specifies a normal Qt font weight.
        /// </summary>
        Normal = 50,

        /// <summary>
        /// Specifies a demibold Qt font weight.
        /// </summary>
        DemiBold = 63,

        /// <summary>
        /// Specifies a bold Qt font weight.
        /// </summary>
        Bold = 75,

        /// <summary>
        /// Specifies a black Qt font weight.
        /// </summary>
        Black = 87
    }

    /// <summary>
    /// Specifies the available Qt font glyph styles.
    /// </summary>
    public enum FontStyle : int
    {
        /// <summary>
        /// Specifies a normal (i.e. non-italicized) Qt font glyph style.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Specifies an italicized Qt font glyph style.
        /// </summary>
        Italic = 1,

        /// <summary>
        /// Specifies a Qt font glyph style with an italic appearance but based on unstyled glyphs.
        /// </summary>
        Oblique = 2
    }

    /// <summary>
    /// Represents the method that will be called when the button changes state.
    /// </summary>
    /// <param name="state">The new state of the button.</param>
    public delegate void ButtonCallback(bool state);

    /// <summary>
    /// Specifies the available GUI button types.
    /// </summary>
    public enum ButtonType : int
    {
        /// <summary>
        /// Specifies that the button will be a push button.
        /// </summary>
        PushButton = 0,

        /// <summary>
        /// Specifies that the button will be a checkbox button.
        /// </summary>
        CheckBox = 1,

        /// <summary>
        /// Specifies that the button will be a radiobox button. The radiobox on the same button bar
        /// (same line) are exclusive; only one can be selected at a time.
        /// </summary>
        RadioBox = 2
    }

    /// <summary>
    /// Specifies the window properties that are available to query and modify.
    /// </summary>
    public enum WindowProperty : int
    {
        /// <summary>
        /// Specifies the fullscreen state of the window.
        /// </summary>
        Fullscreen = 0,

        /// <summary>
        /// Specifies the autosize state of the window.
        /// </summary>
        AutoSize = 1,

        /// <summary>
        /// Specifies the aspect ratio of the window.
        /// </summary>
        AspectRatio = 2,

        /// <summary>
        /// Specifies the window's OpenGL support.
        /// </summary>
        OpenGL = 3,
    }

    /// <summary>
    /// Specifies the available flags used to create a named window.
    /// </summary>
    [Flags]
    public enum WindowFlags : int
    {
        /// <summary>
        /// Specifies that the user can resize the window (no constraint).
        /// </summary>
        Normal = 0x00000000,

        /// <summary>
        /// Specifies that the user cannot resize the window, i.e. the size is constrained by
        /// the displayed image.
        /// </summary>
        AutoSize = 0x00000001,

        /// <summary>
        /// Specifies that the window will have OpenGL support.
        /// </summary>
        OpenGL = 0x00001000,

        /// <summary>
        /// Specifies that the new Qt status and tool bars should be used.
        /// </summary>
        GuiExpanded = 0x00000000,

        /// <summary>
        /// Specifies that the classic GUI style should be used.
        /// </summary>
        GuiNormal = 0x00000010,

        /// <summary>
        /// Specifies that the window should be fullscreen.
        /// </summary>
        Fullscreen = 1,

        /// <summary>
        /// Specifies that the image can be resized freely (no ratio constraint).
        /// </summary>
        FreeRatio = 0x00000100,

        /// <summary>
        /// Specifies that the image aspect ratio will be maintained.
        /// </summary>
        KeepRatio = 0x00000000
    }

    /// <summary>
    /// Represents the method that wil be called whenever the trackbar changes value.
    /// </summary>
    /// <param name="pos">The new position of the trackbar.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TrackbarCallback(int pos);

    /// <summary>
    /// Specifies mouse event categories.
    /// </summary>
    public enum MouseEvent : int
    {
        /// <summary>
        /// Specifies that the event was triggered by mouse movement.
        /// </summary>
        MouseMove = 0,

        /// <summary>
        /// Specifies that the event was triggered by depressing the left mouse button.
        /// </summary>
        LButtonDown = 1,

        /// <summary>
        /// Specifies that the event was triggered by depressing the right mouse button.
        /// </summary>
        RButtonDown = 2,

        /// <summary>
        /// Specifies that the event was triggered by depressing the middle mouse button.
        /// </summary>
        MButtonDown = 3,

        /// <summary>
        /// Specifies that the event was triggered by releasing the left mouse button.
        /// </summary>
        LButtonUp = 4,

        /// <summary>
        /// Specifies that the event was triggered by releasing the right mouse button.
        /// </summary>
        RButtonUp = 5,

        /// <summary>
        /// Specifies that the event was triggered by releasing the middle mouse button.
        /// </summary>
        MButtonUp = 6,

        /// <summary>
        /// Specifies that the event was triggered by double cliking with the left mouse button.
        /// </summary>
        LButtonDblClk = 7,

        /// <summary>
        /// Specifies that the event was triggered by double cliking with the right mouse button.
        /// </summary>
        RButtonDblClk = 8,

        /// <summary>
        /// Specifies that the event was triggered by double cliking with the middle mouse button.
        /// </summary>
        MButtonDblClk = 9
    }

    /// <summary>
    /// Specifies mouse event modifier flags.
    /// </summary>
    [Flags]
    public enum MouseEventFlags : int
    {
        /// <summary>
        /// Specifies that the left mouse button is depressed.
        /// </summary>
        LButton = 1,

        /// <summary>
        /// Specifies that the right mouse button is depressed.
        /// </summary>
        RButton = 2,

        /// <summary>
        /// Specifies that the middle mouse button is depressed.
        /// </summary>
        MButton = 4,

        /// <summary>
        /// Specifies that the CTRL key is depressed.
        /// </summary>
        CtrlKey = 8,

        /// <summary>
        /// Specifies that the SHIFT key is depressed.
        /// </summary>
        ShiftKey = 16,

        /// <summary>
        /// Specifies that the ALT key is depressed.
        /// </summary>
        AltKey = 32
    }

    /// <summary>
    /// Represents the method that will handle mouse events of a named window.
    /// </summary>
    /// <param name="evt">The mouse event category.</param>
    /// <param name="x">The x-coordinate of the mouse during the generating mouse event.</param>
    /// <param name="y">The y-coordinate of the mouse during the generating mouse event.</param>
    /// <param name="flags">The mouse event modifier flags.</param>
    public delegate void MouseCallback(MouseEvent evt, int x, int y, MouseEventFlags flags);

    /// <summary>
    /// Specifies the color type of a loaded image.
    /// </summary>
    [Flags]
    public enum LoadImageFlags : int
    {
        /// <summary>
        /// Specifies that the image is 8-bit, color or not. Overrides all other flags.
        /// </summary>
        Unchanged = -1,

        /// <summary>
        /// Specifies that the image is 8-bit grayscale.
        /// </summary>
        Grayscale = 0,

        /// <summary>
        /// Specifies that the image is 8-bit color.
        /// </summary>
        Color = 1,

        /// <summary>
        /// Specifies that the image can be either 16-bit or 32-bit when the input
        /// has the corresponding depth. Otherwise, convert it to 8-bit.
        /// </summary>
        AnyDepth = 2,
        
        /// <summary>
        /// Specifies that the image can be color or not. Unless <see cref="AnyDepth"/>
        /// is specified, the image will be converted to 8-bit.
        /// </summary>
        AnyColor = 4
    }

    /// <summary>
    /// Specifies the available image compression parameters.
    /// </summary>
    public static class CompressionParameters
    {
        /// <summary>
        /// Specifies the quality of image JPEG compression from 0 to 100 (the higher the better).
        /// Default value is 95.
        /// </summary>
        public const int JpegQuality = 1;

        /// <summary>
        /// Specifies the PNG compression level from 0 to 9. A higher value means a smaller size
        /// and longer compression time. Default value is 3.
        /// </summary>
        public const int PngCompression = 16;

        /// <summary>
        /// Specifies the PNG compression strategy.
        /// </summary>
        public const int PngStrategy = 17;

        /// <summary>
        /// Specifies whether PNG compression should use bi-level (binary) images. 
        /// </summary>
        public const int PngBiLevel = 18;

        /// <summary>
        /// Specifies a default PNG compression strategy.
        /// </summary>
        public const int PngStrategyDefault = 0;

        /// <summary>
        /// Specifies a filtered PNG compression strategy.
        /// </summary>
        public const int PngStrategyFiltered = 1;

        /// <summary>
        /// Specifies a huffman code based PNG compression strategy.
        /// </summary>
        public const int PngStrategyHuffmanOnly = 2;

        /// <summary>
        /// Specifies a run-length encoding PNG compression strategy.
        /// </summary>
        public const int PngStrategyRle = 3;

        /// <summary>
        /// Specifies a fixed PNG compression strategy.
        /// </summary>
        public const int PngStrategyFixed = 4;

        /// <summary>
        /// Specifies a binary format flag for PPM, PGM or PBM. Default value is 1.
        /// </summary>
        public const int PxmBinary = 32;
    }

    /// <summary>
    /// Specifies operation flags for <see cref="cv.ConvertImage"/>.
    /// </summary>
    [Flags]
    public enum ConvertImageFlags : int
    {
        /// <summary>
        /// Specifies that no flags should be used for this call.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that the image should be flipped vertically.
        /// </summary>
        Flip = 1,

        /// <summary>
        /// Specifies that the red and blue channels should be swapped.
        /// </summary>
        SwapRB = 2
    }

    /// <summary>
    /// Represents the method that will draw OpenGL on top of the image display.
    /// </summary>
    public delegate void OpenGLDrawCallback();

    /// <summary>
    /// Specifies the available camera or video capture domains.
    /// </summary>
    public enum CaptureDomain : int
    {
        /// <summary>
        /// Specifies that the domain will be automatically detected.
        /// </summary>
        Any = 0,

        /// <summary>
        /// Specifies the MIL proprietary driver domain.
        /// </summary>
        Mil = 100,

        /// <summary>
        /// Specifies the native platform specific video capture domain.
        /// </summary>
        Vfw = 200,

        /// <summary>
        /// Specifies the native platform specific video capture domain.
        /// </summary>
        V4L = 200,

        /// <summary>
        /// Specifies the native platform specific video capture domain.
        /// </summary>
        V4L2 = 200,

        /// <summary>
        /// Specifies the IEEE 1394 capture driver domain.
        /// </summary>
        Fireware = 300,

        /// <summary>
        /// Specifies the IEEE 1394 capture driver domain.
        /// </summary>
        Firewire = 300,

        /// <summary>
        /// Specifies the IEEE 1394 capture driver domain.
        /// </summary>
        Ieee1394 = 300,

        /// <summary>
        /// Specifies the IEEE 1394 capture driver domain.
        /// </summary>
        DC1394 = 300,

        /// <summary>
        /// Specifies the IEEE 1394 capture driver domain.
        /// </summary>
        Cmu1394 = 300,

        /// <summary>
        /// Specifies the TYZX proprietary driver domain.
        /// </summary>
        Stereo = 400,

        /// <summary>
        /// Specifies the TYZX proprietary driver domain.
        /// </summary>
        Tyzx = 400,

        /// <summary>
        /// Specifies the TYZX proprietary driver's left source.
        /// </summary>
        TyzxLeft = 400,

        /// <summary>
        /// Specifies the TYZX proprietary driver's right source.
        /// </summary>
        TyzxRight = 401,

        /// <summary>
        /// Specifies the TYZX proprietary driver's color source.
        /// </summary>
        TyzxColor = 402,

        /// <summary>
        /// Specifies the TYZX proprietary driver's depth source.
        /// </summary>
        TyzxZ = 403,

        /// <summary>
        /// Specifies the Quicktime capture domain.
        /// </summary>
        QuickTime = 500,

        /// <summary>
        /// Specifies the Unicap driver domain.
        /// </summary>
        Unicap = 600,

        /// <summary>
        /// Specifies the DirectShow (via videoInput) capture domain.
        /// </summary>
        DirectShow = 700,

        /// <summary>
        /// Specifies the Microsoft Media Foundation (via videoInput) capture domain.
        /// </summary>
        Msmf = 1400,

        /// <summary>
        /// Specifies the PvAPI, Prosilica GigE SDK capture domain.
        /// </summary>
        PvAPI = 800,

        /// <summary>
        /// Specifies the OpenNI (for Kinect) capture domain.
        /// </summary>
        OpenNI = 900,

        /// <summary>
        /// Specifies the OpenNI (for Asus Xtion) capture domain.
        /// </summary>
        OpenNIAsus = 910,

        /// <summary>
        /// Specifies the Android capture domain.
        /// </summary>
        Android = 1000,

        /// <summary>
        /// Specifies the Android back camera capture domain.
        /// </summary>
        AndroidBack = Android + 99,

        /// <summary>
        /// Specifies the Android front camera capture domain.
        /// </summary>
        AndroidFront = Android + 98,

        /// <summary>
        /// Specifies the XIMEA Camera API domain.
        /// </summary>
        XIApi = 1100,

        /// <summary>
        /// Specifies the AVFoundation framework for iOS capture domain (OS X Lion will have the same API).
        /// </summary>
        AVFoundation = 1200,

        /// <summary>
        /// Specifies the Smartek Giganetix GigEVision SDK capture domain.
        /// </summary>
        Giganetix = 1300
    }

    /// <summary>
    /// Specifies the available properties of a camera or video file.
    /// </summary>
    public enum CaptureProperty : int
    {
        /// <summary>
        /// Turn the feature off (not controlled manually nor automatically).
        /// </summary>
        DC1394Off = -4,

        /// <summary>
        /// Specifies the manual mode for the controlling register. Set automatically
        /// when a value of the feature is set by the user.
        /// </summary>
        DC1394ModeManual = -3,

        /// <summary>
        /// Specifies the auto mode for the controlling register.
        /// </summary>
        DC1394ModeAuto = -2,

        /// <summary>
        /// Specifies the auto single push mode for the controlling register.
        /// </summary>
        DC1394ModeOnePushAuto = -1,

        /// <summary>
        /// Specifies the movie current position in milliseconds or video capture timestamp.
        /// </summary>
        PosMsec = 0,

        /// <summary>
        /// Specifies the 0-based index of the frame to be decoded/captured next.
        /// </summary>
        PosFrames = 1,

        /// <summary>
        /// Specifies the relative position of the video file (0 - start of the film, 1 - end of the film).
        /// </summary>
        PosAviRatio = 2,

        /// <summary>
        /// Specifies the width of the frames in the video stream.
        /// </summary>
        FrameWidth = 3,

        /// <summary>
        /// Specifies the height of the frames in the video stream.
        /// </summary>
        FrameHeight = 4,

        /// <summary>
        /// Specifies the frame rate.
        /// </summary>
        Fps = 5,

        /// <summary>
        /// Specifies the 4-character code of codec.
        /// </summary>
        FourCC = 6,

        /// <summary>
        /// Specifies the number of frames in the video file.
        /// </summary>
        FrameCount = 7,

        /// <summary>
        /// Specifies the format of the <see cref="IplImage"/> objects returned by
        /// <see cref="Capture.RetrieveFrame"/>.
        /// </summary>
        Format = 8,

        /// <summary>
        /// Specifies a backend-specific value indicating the current capture mode.
        /// </summary>
        Mode = 9,

        /// <summary>
        /// Specifies the brightness of the image (only for cameras).
        /// </summary>
        Brightness = 10,

        /// <summary>
        /// Specifies the contrast of the image (only for cameras).
        /// </summary>
        Contrast = 11,

        /// <summary>
        /// Specifies the saturation of the image (only for cameras).
        /// </summary>
        Saturation = 12,

        /// <summary>
        /// Specifies the hue of the image (only for cameras).
        /// </summary>
        Hue = 13,

        /// <summary>
        /// Specifies the gain of the image (only for cameras).
        /// </summary>
        Gain = 14,

        /// <summary>
        /// Specifies the exposure (only for cameras).
        /// </summary>
        Exposure = 15,

        /// <summary>
        /// Specifies a value indicating whether images should be converted to RGB.
        /// </summary>
        ConvertRgb = 16,

        /// <summary>
        /// Specifies the white balance blue to green ratio (only for cameras).
        /// </summary>
        WhiteBalanceBlueU = 17,

        /// <summary>
        /// Specifies a rectification flag for stereo cameras.
        /// </summary>
        Rectification = 18,

        /// <summary>
        /// Specifies a value indicating whether images are captured in grayscale.
        /// </summary>
        Monocrome = 19,

        /// <summary>
        /// Specifies the sharpness of the image (only for cameras).
        /// </summary>
        Sharpness = 20,

        /// <summary>
        /// Specifies a value indicating whether auto exposure is enabled.
        /// </summary>
        AutoExposure = 21,

        /// <summary>
        /// Specifies the gamma correction of the image (only for cameras).
        /// </summary>
        Gamma = 22,

        /// <summary>
        /// Specifies the current temperature in the camera sensor.
        /// </summary>
        Temperature = 23,

        /// <summary>
        /// Specifies the current trigger mode (only for cameras).
        /// </summary>
        Trigger = 24,

        /// <summary>
        /// Specifies the trigger delay (only for cameras).
        /// </summary>
        TriggerDelay = 25,

        /// <summary>
        /// Specifies the white balance red to green ratio (only for cameras).
        /// </summary>
        WhiteBalanceRedV = 26,

        /// <summary>
        /// Specifies the camera's zoom setting.
        /// </summary>
        Zoom = 27,

        /// <summary>
        /// Specifies the camera's focus setting.
        /// </summary>
        Focus = 28,

        /// <summary>
        /// Specifies the camera's device GUID.
        /// </summary>
        Guid = 29,

        /// <summary>
        /// Specifies the ISO speed of the camera.
        /// </summary>
        IsoSpeed = 30,

        /// <summary>
        /// Specifies a value that indicates the end of DC1394 backend properties (internal use only).
        /// </summary>
        MaxDC1394 = 31,

        /// <summary>
        /// Specifies the camera's backlight compensation setting.
        /// </summary>
        Backlight = 32,

        /// <summary>
        /// Specifies the camera's pan setting, in degrees.
        /// </summary>
        Pan = 33,

        /// <summary>
        /// Specifies the camera's tilt setting, in degrees.
        /// </summary>
        Tilt = 34,

        /// <summary>
        /// Specifies the camera's roll setting, in degrees.
        /// </summary>
        Roll = 35,

        /// <summary>
        /// Specifies the camera's iris setting.
        /// </summary>
        Iris = 36,

        /// <summary>
        /// Specifies a value indicating whether the camera's driver configuration dialog is displayed.
        /// </summary>
        Settings = 37,

        /// <summary>
        /// Specifies a value indicating whether auto-grab is enabled (Android cameras only).
        /// </summary>
        Autograb = 1024,

        /// <summary>
        /// Specifies the supported preview sizes. Returns a pointer to a native string
        /// (Android cameras only).
        /// </summary>
        SupportedPreviewSizesString = 1025,

        /// <summary>
        /// Specifies the supported preview format. Returns a pointer to a native string
        /// (Android cameras only).
        /// </summary>
        PreviewFormat = 1026,

        /// <summary>
        /// Specifies a flag for getting/setting properties of the OpenNI sensor depth generator.
        /// </summary>
        OpenNIDepthGenerator = 1 << 31,

        /// <summary>
        /// Specifies a flag for getting/setting properties of the OpenNI sensor image generator.
        /// </summary>
        OpenNIImageGenerator = 1 << 30,

        /// <summary>
        /// Specifies a combination of <see cref="OpenNIDepthGenerator"/> and
        /// <see cref="OpenNIImageGenerator"/>.
        /// </summary>
        OpenNIGeneratorsMask = OpenNIDepthGenerator + OpenNIImageGenerator,

        /// <summary>
        /// Specifies the output mode of the OpenNI generator.
        /// </summary>
        OpenNIOutputMode = 100,

        /// <summary>
        /// Specifies the maximum supported depth of the OpenNI sensor, in mm.
        /// </summary>
        OpenNIFrameMaxDepth = 101,

        /// <summary>
        /// Specifies the baseline sensor value, in mm.
        /// </summary>
        OpenNIBaseline = 102,

        /// <summary>
        /// Specifies the sensor focal length in pixels.
        /// </summary>
        OpenNIFocalLength = 103,

        /// <summary>
        /// Specifies a flag that registers the remapping depth map to image map by changing
        /// the generator’s view point.
        /// </summary>
        OpenNIRegistration = 104,

        /// <summary>
        /// Specifies that the <see cref="OpenNIRegistration"/> flag is "on".
        /// </summary>
        OpenNIRegistrationOn = OpenNIRegistration,

        /// <summary>
        /// Specifies whether the depth generator should be approximately synchronized with the image generator.
        /// </summary>
        OpenNIApproxFrameSync = 105,

        /// <summary>
        /// Specifies the maximum buffer size for generator synchronization.
        /// </summary>
        OpenNIMaxBufferSize = 106,

        /// <summary>
        /// Specifies whether the synchronization buffer is circular.
        /// </summary>
        OpenNICircleBuffer = 107,

        /// <summary>
        /// Specifies the maximum time difference to consider depth and image frame to be in sync.
        /// </summary>
        OpenNIMaxTimeDuration = 108,

        /// <summary>
        /// Specifies a flag that is used to check whether a given OpenNI generator is present.
        /// </summary>
        OpenNIGeneratorPresent = 109,

        /// <summary>
        /// Specifies whether an image generator is present.
        /// </summary>
        OpenNIImageGeneratorPresent = OpenNIImageGenerator + OpenNIGeneratorPresent,

        /// <summary>
        /// Specifies the output mode of the OpenNI image generator.
        /// </summary>
        OpenNIImageGeneratorOutputMode = OpenNIImageGenerator + OpenNIOutputMode,

        /// <summary>
        /// Specifies the depth sensor baseline value, in mm.
        /// </summary>
        OpenNIDepthGeneratorBaseline = OpenNIDepthGenerator + OpenNIBaseline,

        /// <summary>
        /// Specifies the depth sensor focal length in pixels.
        /// </summary>
        OpenNIDepthGeneratorFocalLength = OpenNIDepthGenerator + OpenNIFocalLength,

        /// <summary>
        /// Specifies a flag that registers the remapping depth map to image map by changing
        /// the depth generator’s view point.
        /// </summary>
        OpenNIDepthGeneratorRegistration = OpenNIDepthGenerator + OpenNIRegistration,

        /// <summary>
        /// Specifies that the <see cref="OpenNIDepthGeneratorRegistration"/> flag is "on".
        /// </summary>
        OpenNIDepthGeneratorRegistrationOn = OpenNIDepthGeneratorRegistration,

        /// <summary>
        /// Specifies the queue length of cameras acquired through the GStreamer interface.
        /// </summary>
        GStreamerQueueLength = 200,

        /// <summary>
        /// Specifies the IP address to enable multicast master mode. A zero address disables
        /// multicast (GStreamer interface cameras only).
        /// </summary>
        PVApiMulticastIP = 300,

        /// <summary>
        /// Specifies whether to change image resolution by binning or skipping (XIMEA SDK only).
        /// </summary>
        XIDownsampling = 400,

        /// <summary>
        /// Specifies the output data format (XIMEA SDK only).
        /// </summary>
        XIDataFormat = 401,

        /// <summary>
        /// Specifies the horizontal offset from the origin to the area of interest, in pixels
        /// (XIMEA SDK only).
        /// </summary>
        XIOffsetX = 402,

        /// <summary>
        /// Specifies the vertical offset from the origin to the area of interest, in pixels
        /// (XIMEA SDK only).
        /// </summary>
        XIOffsetY = 403,

        /// <summary>
        /// Specifies the trigger source (XIMEA SDK only).
        /// </summary>
        XITrgSource = 404,

        /// <summary>
        /// Specifies whether to generate an internal trigger (XIMEA SDK only).
        /// </summary>
        XITrgSoftware = 405,

        /// <summary>
        /// Specifies the general purpose input (XIMEA SDK only).
        /// </summary>
        XIGpiSelector = 406,

        /// <summary>
        /// Specifies the general purpose input mode (XIMEA SDK only).
        /// </summary>
        XIGpiMode = 407,

        /// <summary>
        /// Specifies the general purpose input level (XIMEA SDK only).
        /// </summary>
        XIGpiLevel = 408,

        /// <summary>
        /// Specifies the general purpose output (XIMEA SDK only).
        /// </summary>
        XIGpoSelector = 409,

        /// <summary>
        /// Specifies the general purpose output mode (XIMEA SDK only).
        /// </summary>
        XIGpoMode = 410,

        /// <summary>
        /// Specifies the camera signalling LED (XIMEA SDK only).
        /// </summary>
        XILedSelector = 411,

        /// <summary>
        /// Specifies the functionality of the camera signalling LED (XIMEA SDK only).
        /// </summary>
        XILedMode = 412,

        /// <summary>
        /// Specifies whether to calculate white balance. Must be called during acquisition (XIMEA SDK only).
        /// </summary>
        XIManualWb = 413,

        /// <summary>
        /// Specifies automatic white balance calculation (XIMEA SDK only).
        /// </summary>
        XIAutoWb = 414,

        /// <summary>
        /// Specifies automatic exposure and gain (XIMEA SDK only).
        /// </summary>
        XIAeag = 415,

        /// <summary>
        /// Specifies exposure priority relative to gain (XIMEA SDK only).
        /// </summary>
        XIExpPriority = 416,

        /// <summary>
        /// Specifies the maximum limit of exposure in AEAG procedure (XIMEA SDK only).
        /// </summary>
        XIAeMaxLimit = 417,

        /// <summary>
        /// Specifies the maximum limit of gain in AEAG procedure (XIMEA SDK only).
        /// </summary>
        XIAgMaxLimit = 418,

        /// <summary>
        /// Specifies the average intensity of the output signal that AEAG should achieve,
        /// in percentage (XIMEA SDK only).
        /// </summary>
        XIAeagLevel = 419,

        /// <summary>
        /// Specifies the image capture timeout in milliseconds (XIMEA SDK only).
        /// </summary>
        XITimeout = 420,

        /// <summary>
        /// Specifies the camera flash mode (Android cameras only).
        /// </summary>
        AndroidFlashMode = 8001,

        /// <summary>
        /// Specifies the camera focus mode (Android cameras only).
        /// </summary>
        AndroidFocusMode = 8002,

        /// <summary>
        /// Specifies the camera white balance mode (Android cameras only).
        /// </summary>
        AndroidWhiteBalance = 8003,

        /// <summary>
        /// Specifies the camera antibanding mode (Android cameras only).
        /// </summary>
        AndroidAntibanding = 8004,

        /// <summary>
        /// Specifies the camera focal length (Android cameras only).
        /// </summary>
        AndroidFocalLength = 8005,

        /// <summary>
        /// Specifies the camera near focus distance (Android cameras only).
        /// </summary>
        AndroidFocusDistanceNear = 8006,

        /// <summary>
        /// Specifies the camera optimal focus distance (Android cameras only).
        /// </summary>
        AndroidFocusDistanceOptimal = 8007,

        /// <summary>
        /// Specifies the camera far focus distance (Android cameras only).
        /// </summary>
        AndroidFocusDistanceFar = 8008,

        /// <summary>
        /// Specifies the device focus (AV Foundation cameras only).
        /// </summary>
        IosDeviceFocus = 9001,

        /// <summary>
        /// Specifies the device exposure (AV Foundation cameras only). 
        /// </summary>
        IosDeviceExposure = 9002,

        /// <summary>
        /// Specifies the device flash state (AV Foundation cameras only).
        /// </summary>
        IosDeviceFlash = 9003,

        /// <summary>
        /// Specifies the device white balance (AV Foundation cameras only).
        /// </summary>
        IosDeviceWhitebalance = 9004,

        /// <summary>
        /// Specifies whether the device has a torch (AV Foundation cameras only).
        /// </summary>
        IosDeviceTorch = 9005,

        /// <summary>
        /// Specifies the horizontal offset of the image frame (Smartek Giganetix Ethernet vision interface only).
        /// </summary>
        GigaFrameOffsetX = 10001,

        /// <summary>
        /// Specifies the vertical offset of the image frame (Smartek Giganetix Ethernet vision interface only).
        /// </summary>
        GigaFrameOffsetY = 10002,

        /// <summary>
        /// Specifies the maximum frame width (Smartek Giganetix Ethernet vision interface only).
        /// </summary>
        GigaFrameWidthMax = 10003,

        /// <summary>
        /// Specifies the maximum frame height (Smartek Giganetix Ethernet vision interface only).
        /// </summary>
        GigaFrameHeightMax = 10004,

        /// <summary>
        /// Specifies the sensor width (Smartek Giganetix Ethernet vision interface only).
        /// </summary>
        GigaFrameSensorWidth = 10005,

        /// <summary>
        /// Specifies the sensor height (Smartek Giganetix Ethernet vision interface only).
        /// </summary>
        GigaFrameSensorHeight = 10006
    }
}
