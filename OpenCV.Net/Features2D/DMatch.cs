using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a pairwise comparison between keypoint descriptors.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMatch : IEquatable<DMatch>, IComparable<DMatch>, IComparable
    {
        /// <summary>
        /// The index of the matched descriptor in the query set.
        /// </summary>
        public int QueryIndex;

        /// <summary>
        /// The index of the matched descriptor in the training set.
        /// </summary>
        public int TrainIndex;

        /// <summary>
        /// The index of the image used to compute the descriptor training set.
        /// </summary>
        public int ImageIndex;

        /// <summary>
        /// The computed distance between the keypoint descriptors.
        /// </summary>
        public float Distance;

        /// <summary>
        /// Returns a hash code for this <see cref="DMatch"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="DMatch"/> structure.</returns>
        public override int GetHashCode()
        {
            return QueryIndex.GetHashCode() ^
                TrainIndex.GetHashCode() ^
                ImageIndex.GetHashCode() ^
                Distance.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="DMatch"/> structure
        /// with the same properties as this <see cref="DMatch"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="DMatch"/> and has the
        /// same properties as this <see cref="DMatch"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is DMatch)
            {
                return Equals((DMatch)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same properties
        /// as a specified <see cref="DMatch"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="DMatch"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same properties as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(DMatch other)
        {
            return QueryIndex == other.QueryIndex &&
                TrainIndex == other.TrainIndex &&
                ImageIndex == other.ImageIndex &&
                Distance == other.Distance;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="DMatch"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the property values of this <see cref="DMatch"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("[QueryIndex: {0}, TrainIndex: {1}, ImageIndex: {2}, Distance: {3}]",
                QueryIndex,
                TrainIndex,
                ImageIndex,
                Distance);
        }

        /// <summary>
        /// Compares the current instance with another object of type <see cref="DMatch"/> and returns
        /// an integer that indicates whether the current instance precedes, follows, or occurs
        /// in the same position in the sort order as the <paramref name="obj"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The
        /// return value will be less than zero if this instance precedes <paramref name="obj"/>
        /// in the sort order; zero if this instance occurs in the same position in the
        /// sort order as <paramref name="obj"/>; and greater than zero if this instance
        /// follows <paramref name="obj"/> in the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (!(obj is DMatch))
            {
                throw new ArgumentException(string.Format("Object must be of type {0}.", GetType()));
            }

            return CompareTo((DMatch)obj);
        }

        /// <summary>
        /// Compares the current instance with another <see cref="DMatch"/> object and returns
        /// an integer that indicates whether the current instance precedes, follows, or occurs
        /// in the same position in the sort order as the <paramref name="other"/> object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The
        /// return value will be less than zero if this instance precedes <paramref name="other"/>
        /// in the sort order; zero if this instance occurs in the same position in the
        /// sort order as <paramref name="other"/>; and greater than zero if this instance
        /// follows <paramref name="other"/> in the sort order.
        /// </returns>
        public int CompareTo(DMatch other)
        {
            var comparison = Distance.CompareTo(other.Distance);
            if (comparison != 0) return comparison;

            comparison = QueryIndex.CompareTo(other.QueryIndex);
            if (comparison != 0) return comparison;

            comparison = ImageIndex.CompareTo(other.ImageIndex);
            if (comparison != 0) return comparison;

            return TrainIndex.CompareTo(other.TrainIndex);
        }

        /// <summary>
        /// Tests whether two <see cref="DMatch"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="DMatch"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="DMatch"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal properties;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(DMatch left, DMatch right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="DMatch"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="DMatch"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="DMatch"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in any of their properties;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(DMatch left, DMatch right)
        {
            return !left.Equals(right);
        }
    }
}
