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
    public delegate void CvButtonCallback(bool state);

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
    public delegate void CvTrackbarCallback(int pos);

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
    public delegate void CvMouseCallback(MouseEvent evt, int x, int y, MouseEventFlags flags);

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
    public delegate void CvOpenGlDrawCallback();
}
