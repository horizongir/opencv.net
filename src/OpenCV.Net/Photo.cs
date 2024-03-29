﻿using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public static partial class CV
    {
        /// <summary>
        /// Restores the selected region in an image using the region neighborhood.
        /// </summary>
        /// <param name="src">Input 8-bit 1-channel or 3-channel image.</param>
        /// <param name="inpaintMask">
        /// Inpainting mask, 8-bit 1-channel image. Non-zero pixels indicate the area that needs to be inpainted.
        /// </param>
        /// <param name="dst">Output image with the same size and type as <paramref name="src"/>.</param>
        /// <param name="inpaintRange">
        /// Radius of a circular neighborhood of each point inpainted that is considered by the algorithm.
        /// </param>
        /// <param name="flags">Specifies the inpainting method.</param>
        public static void Inpaint(Arr src, Arr inpaintMask, Arr dst, double inpaintRange, InpaintMethod flags)
        {
            NativeMethods.cvInpaint(src, inpaintMask, dst, inpaintRange, flags);
        }
    }
}
