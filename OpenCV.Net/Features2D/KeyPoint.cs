using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a point feature found by one of the available keypoint detectors.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyPoint : IEquatable<KeyPoint>
    {
        /// <summary>
        /// The 2D coordinate of the keypoint.
        /// </summary>
        public Point2f Point;

        /// <summary>
        /// The diameter of the meaningful keypoint neighborhood.
        /// </summary>
        public float Size;

        /// <summary>
        /// The computed orientation of the keypoint. This value is -1 if it is not applicable.
        /// </summary>
        public float Angle;

        /// <summary>
        /// The response by which the strongest keypoints have been selected.
        /// </summary>
        public float Response;

        /// <summary>
        /// The octave, or pyramid layer, from which the keypoint has been extracted.
        /// </summary>
        public int Octave;

        /// <summary>
        /// The class of the object, in case keypoints need to be clustered by an object they belong to.
        /// </summary>
        public int ClassId;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPoint"/> class with the specified properties.
        /// </summary>
        /// <param name="point">The 2D coordinate of the keypoint.</param>
        /// <param name="size">The diameter of the meaningful keypoint neighborhood.</param>
        /// <param name="angle">The computed orientation of the keypoint. This value is -1 if it is not applicable.</param>
        /// <param name="response">The response by which the strongest keypoints have been selected.</param>
        /// <param name="octave">The octave, or pyramid layer, from which the keypoint has been extracted.</param>
        /// <param name="classId">The class of the object, in case keypoints need to be clustered by an object they belong to.</param>
        public KeyPoint(Point2f point, float size, float angle, float response, int octave, int classId)
        {
            Point = point;
            Size = size;
            Angle = angle;
            Response = response;
            Octave = octave;
            ClassId = classId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPoint"/> class with the specified properties.
        /// </summary>
        /// <param name="x">The x-coordinate of the keypoint.</param>
        /// <param name="y">The y-coordinate of the keypoint.</param>
        /// <param name="size">The diameter of the meaningful keypoint neighborhood.</param>
        /// <param name="angle">The computed orientation of the keypoint. This value is -1 if it is not applicable.</param>
        /// <param name="response">The response by which the strongest keypoints have been selected.</param>
        /// <param name="octave">The octave, or pyramid layer, from which the keypoint has been extracted.</param>
        /// <param name="classId">The class of the object, in case keypoints need to be clustered by an object they belong to.</param>
        public KeyPoint(float x, float y, float size, float angle, float response, int octave, int classId)
        {
            Point = new Point2f(x, y);
            Size = size;
            Angle = angle;
            Response = response;
            Octave = octave;
            ClassId = classId;
        }

        /// <summary>
        /// Converts a collection of keypoints to an array of points.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to convert.</param>
        /// <param name="points">The array of points that is the destination of the converted keypoints.</param>
        public static void Convert(KeyPointCollection keyPoints, Point2f[] points)
        {
            Convert(keyPoints, points, null);
        }

        /// <summary>
        /// Converts a collection of keypoints to an array of points.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to convert.</param>
        /// <param name="points">The array of points that is the destination of the converted keypoints.</param>
        /// <param name="keyPointIndices">The optional array containing the keypoint indices to convert.</param>
        public static void Convert(KeyPointCollection keyPoints, Point2f[] points, int[] keyPointIndices)
        {
            using (var pointVector = new Point2fCollection())
            using (var indexVector = keyPointIndices != null ? new Int32Collection(keyPointIndices) : null)
            {
                Convert(keyPoints, pointVector, indexVector);
                pointVector.CopyTo(points);
            }
        }

        /// <summary>
        /// Converts a collection of keypoints to a collection of points.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to convert.</param>
        /// <param name="points">The collection of points that is the destination of the converted keypoints.</param>
        public static void Convert(KeyPointCollection keyPoints, Point2fCollection points)
        {
            Convert(keyPoints, points, null);
        }

        /// <summary>
        /// Converts a collection of keypoints to a collection of points.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to convert.</param>
        /// <param name="points">The collection of points that is the destination of the converted keypoints.</param>
        /// <param name="keyPointIndices">The optional collection of the keypoint indices to convert.</param>
        public static void Convert(KeyPointCollection keyPoints, Point2fCollection points, Int32Collection keyPointIndices)
        {
            NativeMethods.cv_features2d_KeyPoint_convert_vector_KeyPoint(keyPoints, points, keyPointIndices ?? Int32Collection.Null);
        }

        /// <summary>
        /// Converts an array of points to a collection of keypoints, where each
        /// keypoint is assigned the same size, response and orientation.
        /// </summary>
        /// <param name="points">The array of points to convert.</param>
        /// <param name="keyPoints">The collection that is the destination of the converted keypoints.</param>
        /// <param name="size">The shared size of the converted keypoints.</param>
        /// <param name="response">The shared response of the converted keypoints.</param>
        /// <param name="octave">The shared octave, or pyramid level, of the converted keypoints.</param>
        /// <param name="classId">The shared class id of the converted keypoints.</param>
        public static void Convert(
            Point2f[] points,
            KeyPointCollection keyPoints,
            float size,
            float response,
            int octave,
            int classId)
        {
            using (var vector = new Point2fCollection(points))
            {
                Convert(vector, keyPoints, size, response, octave, classId);
            }
        }

        /// <summary>
        /// Converts a collection of points to a collection of keypoints, where each
        /// keypoint is assigned the same size, response and orientation.
        /// </summary>
        /// <param name="points">The collection of points to convert.</param>
        /// <param name="keyPoints">The collection that is the destination of the converted keypoints.</param>
        /// <param name="size">The shared size of the converted keypoints.</param>
        /// <param name="response">The shared response of the converted keypoints.</param>
        /// <param name="octave">The shared octave, or pyramid level, of the converted keypoints.</param>
        /// <param name="classId">The shared class id of the converted keypoints.</param>
        public static void Convert(
            Point2fCollection points,
            KeyPointCollection keyPoints,
            float size,
            float response,
            int octave,
            int classId)
        {
            NativeMethods.cv_features2d_KeyPoint_convert_vector_Point2f(
                points,
                keyPoints,
                size,
                response,
                octave,
                classId);
        }

        /// <summary>
        /// Computes overlap for a pair of keypoints, defined as the ratio between the
        /// area of intersection of each keypoint region and their area of union.
        /// </summary>
        /// <param name="keyPoint1">The first keypoint for which to compute overlap.</param>
        /// <param name="keyPoint2">The second keypoint for which to compute overlap.</param>
        /// <returns>The overlap between the specified keypoints.</returns>
        public static float Overlap(KeyPoint keyPoint1, KeyPoint keyPoint2)
        {
            return Overlap(ref keyPoint1, ref keyPoint2);
        }

        /// <summary>
        /// Computes overlap for a pair of keypoints, defined as the ratio between the
        /// area of intersection of each keypoint region and their area of union.
        /// </summary>
        /// <param name="keyPoint1">The first keypoint for which to compute overlap.</param>
        /// <param name="keyPoint2">The second keypoint for which to compute overlap.</param>
        /// <returns>The overlap between the specified keypoints.</returns>
        public static float Overlap(ref KeyPoint keyPoint1, ref KeyPoint keyPoint2)
        {
            return NativeMethods.cv_features2d_KeyPoint_overlap(ref keyPoint1, ref keyPoint2);
        }

        /// <summary>
        /// Returns a hash code for this <see cref="KeyPoint"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="KeyPoint"/> structure.</returns>
        public override int GetHashCode()
        {
            return Point.GetHashCode() ^
                Size.GetHashCode() ^
                Angle.GetHashCode() ^
                Response.GetHashCode() ^
                Octave.GetHashCode() ^
                ClassId.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="KeyPoint"/> structure
        /// with the same properties as this <see cref="KeyPoint"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="KeyPoint"/> and has the
        /// same properties as this <see cref="KeyPoint"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is KeyPoint)
            {
                return Equals((KeyPoint)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same properties
        /// as a specified <see cref="KeyPoint"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="KeyPoint"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same properties as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(KeyPoint other)
        {
            return Point == other.Point &&
                Size == other.Size &&
                Angle == other.Angle &&
                Response == other.Response &&
                Octave == other.Octave &&
                ClassId == other.ClassId;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="KeyPoint"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the property values of this <see cref="KeyPoint"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("[Point: {0}, Size: {1}, Angle: {2}, Response: {3}, Octave: {4}, ClassId: {5}]",
                Point,
                Size,
                Angle,
                Response,
                Octave,
                ClassId);
        }

        /// <summary>
        /// Tests whether two <see cref="KeyPoint"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="KeyPoint"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="KeyPoint"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal properties;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(KeyPoint left, KeyPoint right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="KeyPoint"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="KeyPoint"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="KeyPoint"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in any of their properties;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(KeyPoint left, KeyPoint right)
        {
            return !left.Equals(right);
        }
    }
}
