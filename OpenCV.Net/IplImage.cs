using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an IPL image header.
    /// </summary>
    public class IplImage : Arr
    {
        bool ownsData;

        internal IplImage()
            : base(true)
        {
        }

        internal IplImage(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal IplImage(IntPtr handle)
            : this(handle, true)
        {
        }

        internal IplImage(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);

            if (ownsHandle)
            {
                GC.AddMemoryPressure(WidthStep * Height);
                ownsData = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IplImage"/> class with the
        /// specified <paramref name="size"/>, pixel bit <paramref name="depth"/> and
        /// <paramref name="channels"/> per element.
        /// </summary>
        /// <param name="size">The pixel-accurate size of the <see cref="IplImage"/>.</param>
        /// <param name="depth">The bit depth of image pixels.</param>
        /// <param name="channels">The number of channels per pixel.</param>
        public IplImage(Size size, IplDepth depth, int channels)
            : this(NativeMethods.cvCreateImage(size, depth, channels), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IplImage"/> class with the
        /// specified <paramref name="size"/>, pixel bit <paramref name="depth"/> and
        /// <paramref name="channels"/> per element. A pointer to the image raw
        /// <paramref name="data"/> is provided.
        /// </summary>
        /// <param name="size">The pixel-accurate size of the <see cref="IplImage"/>.</param>
        /// <param name="depth">The bit depth of image pixels.</param>
        /// <param name="channels">The number of channels per pixel.</param>
        /// <param name="data">A pointer to the image raw pixel data.</param>
        public IplImage(Size size, IplDepth depth, int channels, IntPtr data)
            : base(true)
        {
            var pImage = NativeMethods.cvCreateImageHeader(size, depth, channels);
            SetHandle(pImage);
            SetData(data, WidthStep);
        }

        /// <summary>
        /// Gets the bit depth of image pixels.
        /// </summary>
        public IplDepth Depth
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->depth;
                }
            }
        }

        /// <summary>
        /// Gets the number of channels per image pixel.
        /// </summary>
        public int Channels
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->nChannels;
                }
            }
        }

        /// <summary>
        /// Gets the width of the image in pixels.
        /// </summary>
        public int Width
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->width;
                }
            }
        }

        /// <summary>
        /// Gets the height of the image in pixels.
        /// </summary>
        public int Height
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->height;
                }
            }
        }

        /// <summary>
        /// Gets the size of the aligned image row in bytes.
        /// </summary>
        public int WidthStep
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->widthStep;
                }
            }
        }

        /// <summary>
        /// Gets a pointer to the aligned image data.
        /// </summary>
        public IntPtr ImageData
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->imageData;
                }
            }
        }

        /// <summary>
        /// Gets or sets the image channel of interest.
        /// Only a few functions support COI.
        /// </summary>
        public int ChannelOfInterest
        {
            get { return NativeMethods.cvGetImageCOI(this); }
            set { NativeMethods.cvSetImageCOI(this, value); }
        }

        /// <summary>
        /// Gets or sets the image region of interest.
        /// </summary>
        public Rect RegionOfInterest
        {
            get { return NativeMethods.cvGetImageROI(this); }
            set { NativeMethods.cvSetImageROI(this, value); }
        }

        /// <summary>
        /// Resets the image region and channel of interest.
        /// </summary>
        public void ResetRegionOfInterest()
        {
            NativeMethods.cvResetImageROI(this);
        }

        /// <summary>
        /// Creates a new <see cref="IplImage"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="IplImage"/> that is a copy of this instance.
        /// <see cref="WidthStep"/> may differ.
        /// </returns>
        public IplImage Clone()
        {
            return new IplImage(NativeMethods.cvCloneImage(this), true);
        }

        /// <summary>
        /// Creates a new <see cref="IplImage"/> from a subrectangle of the current instance.
        /// No data is copied.
        /// </summary>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest.</param>
        /// <returns>
        /// A new <see cref="IplImage"/> that corresponds to the specified rectangle of
        /// the current image.
        /// </returns>
        public new IplImage GetSubRect(Rect rect)
        {
            _CvMat subRect;
            NativeMethods.cvGetSubRect(this, out subRect, rect);
            return new IplImageSubRect(this, subRect);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="IplImage"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            if (ownsData)
            {
                GC.RemoveMemoryPressure(WidthStep * Height);
                NativeMethods.cvReleaseImage(ref handle);
            }
            else NativeMethods.cvReleaseImageHeader(ref handle);
            return true;
        }

        class IplImageSubRect : IplImage
        {
            IplImage owner;

            public IplImageSubRect(IplImage source, _CvMat subRect)
                : base(true)
            {
                var pImage = NativeMethods.cvCreateImageHeader(new Size(subRect.cols, subRect.rows), source.Depth, source.Channels);
                SetHandle(pImage);
                SetData(subRect.data, subRect.step);
                owner = source;
            }

            protected override bool ReleaseHandle()
            {
                base.ReleaseHandle();
                owner = null;
                return true;
            }
        }

        #region Operator Overloads

        /// <summary>
        /// Converts a <see cref="IplImage"/> value to a <see cref="Mat"/>.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <returns>A <see cref="Mat"/> value of the same size and element type.</returns>
        public static explicit operator Mat(IplImage image)
        {
            return image.GetMat();
        }

        /// <summary>
        /// Returns the <see cref="IplImage"/> value (the sign is unchanged).
        /// </summary>
        /// <param name="image">The image to return.</param>
        /// <returns>The image <paramref name="image"/>.</returns>
        public static IplImage operator +(IplImage image)
        {
            return image;
        }

        /// <summary>
        /// Negates the specified <see cref="IplImage"/> value.
        /// </summary>
        /// <param name="image">The image to negate.</param>
        /// <returns>
        /// The result of <paramref name="image"/> multiplied by negative one (-1).
        /// </returns>
        public static IplImage operator -(IplImage image)
        {
            var result = new IplImage(image.Size, image.Depth, image.Channels);
            CV.ConvertScale(image, result, -1, 0);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise inversion of the specified <see cref="IplImage"/> value.
        /// </summary>
        /// <param name="image">The image to invert.</param>
        /// <returns>The result of bitwise inverting <paramref name="image"/>.</returns>
        public static IplImage operator ~(IplImage image)
        {
            var result = new IplImage(image.Size, image.Depth, image.Channels);
            CV.Not(image, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of two <see cref="IplImage"/> values.
        /// </summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator +(IplImage left, IplImage right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.Add(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="IplImage"/> and a <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The image to add.</param>
        /// <param name="right">The scalar to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator +(IplImage left, Scalar right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.AddS(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="Scalar"/> and a <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar to add.</param>
        /// <param name="right">The image to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator +(Scalar left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.AddS(right, left, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="IplImage"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The image to add.</param>
        /// <param name="right">The scalar value to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator +(IplImage left, double right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.ConvertScale(left, result, 1, right);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="double"/> value and a
        /// <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value to add.</param>
        /// <param name="right">The image to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator +(double left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.ConvertScale(right, result, 1, left);
            return result;
        }

        /// <summary>
        /// Calculates the per-element difference between two <see cref="IplImage"/> values.
        /// </summary>
        /// <param name="left">The minuend.</param>
        /// <param name="right">The subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static IplImage operator -(IplImage left, IplImage right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.Sub(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element difference between a <see cref="IplImage"/> and a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The image minuend.</param>
        /// <param name="right">The scalar subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static IplImage operator -(IplImage left, Scalar right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.SubS(left, right, result);
            return result;
        }

        /// <summary>
        /// Subtracts every element of the specified <see cref="IplImage"/> value from a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The scalar minuend.</param>
        /// <param name="right">The image subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static IplImage operator -(Scalar left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.SubRS(right, left, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element difference between a <see cref="IplImage"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The image minuend.</param>
        /// <param name="right">The scalar subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static IplImage operator -(IplImage left, double right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.SubS(left, Scalar.All(right), result);
            return result;
        }

        /// <summary>
        /// Subtracts every element of the specified <see cref="IplImage"/> value from a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The scalar minuend.</param>
        /// <param name="right">The image subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static IplImage operator -(double left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.SubRS(right, Scalar.All(left), result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element product of two <see cref="IplImage"/> values.
        /// </summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>
        /// The result of multiplying <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static IplImage operator *(IplImage left, IplImage right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.Mul(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element product of a <see cref="IplImage"/> by a
        /// <see cref="double"/> scalar value.
        /// </summary>
        /// <param name="left">The image to multiply.</param>
        /// <param name="right">The scalar value to multiply.</param>
        /// <returns>
        /// The result of multiplying <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static IplImage operator *(IplImage left, double right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.ConvertScale(left, result, right);
            return result;
        }

        /// <summary>
        /// Calculates the per-element product of a <see cref="double"/> scalar value
        /// by a <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value to multiply.</param>
        /// <param name="right">The image to multiply.</param>
        /// <returns>
        /// The result of multiplying <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static IplImage operator *(double left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.ConvertScale(right, result, left);
            return result;
        }

        /// <summary>
        /// Calculates the per-element division of two <see cref="IplImage"/> values.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>
        /// The result of dividing <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static IplImage operator /(IplImage left, IplImage right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.Div(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element division of a <see cref="IplImage"/> by a
        /// <see cref="double"/> scalar value.
        /// </summary>
        /// <param name="left">The image dividend.</param>
        /// <param name="right">The scalar divisor.</param>
        /// <returns>
        /// The result of dividing <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static IplImage operator /(IplImage left, double right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.ConvertScale(left, result, 1.0 / right);
            return result;
        }

        /// <summary>
        /// Calculates the per-element division of a <see cref="double"/> scalar value
        /// by a <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar dividend.</param>
        /// <param name="right">The image divisor.</param>
        /// <returns>
        /// The result of dividing <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static IplImage operator /(double left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.Div(null, right, result, left);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on two
        /// <see cref="IplImage"/> values.
        /// </summary>
        /// <param name="left">The first image value.</param>
        /// <param name="right">The second image value.</param>
        /// <returns>
        /// The result of performing the bit-wise "exclusive or" operation
        /// of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator ^(IplImage left, IplImage right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.Xor(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation of a
        /// <see cref="IplImage"/> and a <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The image value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise "exclusive or" operation
        /// of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator ^(IplImage left, Scalar right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.XorS(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation of a
        /// <see cref="Scalar"/> and a <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The image value.</param>
        /// <returns>
        /// The result of performing the bit-wise "exclusive or" operation
        /// of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator ^(Scalar left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.XorS(right, left, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation of a
        /// <see cref="IplImage"/> and a <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The image value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise "exclusive or" operation
        /// of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator ^(IplImage left, double right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.XorS(left, Scalar.All(right), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation of a
        /// <see cref="double"/> value and a <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The image value.</param>
        /// <returns>
        /// The result of performing the bit-wise "exclusive or" operation
        /// of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator ^(double left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.XorS(right, Scalar.All(left), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of two <see cref="IplImage"/> values.
        /// </summary>
        /// <param name="left">The first image value.</param>
        /// <param name="right">The second image value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator &(IplImage left, IplImage right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.And(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="IplImage"/> and a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The image value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator &(IplImage left, Scalar right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.AndS(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="Scalar"/> and a
        /// <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The image value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator &(Scalar left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.AndS(right, left, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="IplImage"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The image value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator &(IplImage left, double right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.AndS(left, Scalar.All(right), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="double"/> value and a
        /// <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The image value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator &(double left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.AndS(right, Scalar.All(left), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of two <see cref="IplImage"/> values.
        /// </summary>
        /// <param name="left">The first image value.</param>
        /// <param name="right">The second image value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator |(IplImage left, IplImage right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.Or(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="IplImage"/> and a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The image value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator |(IplImage left, Scalar right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.OrS(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="Scalar"/> and a
        /// <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The image value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator |(Scalar left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.OrS(right, left, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="IplImage"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The image value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator |(IplImage left, double right)
        {
            var result = new IplImage(left.Size, left.Depth, left.Channels);
            CV.OrS(left, Scalar.All(right), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="double"/> value and a
        /// <see cref="IplImage"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The image value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static IplImage operator |(double left, IplImage right)
        {
            var result = new IplImage(right.Size, right.Depth, right.Channels);
            CV.OrS(right, Scalar.All(left), result);
            return result;
        }

        #endregion
    }
}
