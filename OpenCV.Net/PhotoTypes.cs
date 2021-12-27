namespace OpenCV.Net
{
    /// <summary>
    /// Specifies available inpainting methods.
    /// </summary>
    public enum InpaintMethod : int
    {
        /// <summary>
        /// Specifies a Navier-Stokes based method.
        /// </summary>
        NavierStokes = 0,

        /// <summary>
        /// Specifies the method by Alexandru Telea.
        /// </summary>
        Telea = 1
    }
}
