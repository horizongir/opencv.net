using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCV.Net
{
    static class ArrayHelper
    {
        public static TResult[] ConvertAll<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector)
        {
            var result = new TResult[source.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = selector(source[i]);
            }
            return result;
        }

        public static void ForEach<TSource>(this TSource[] source, Action<TSource> action)
        {
            for (int i = 0; i < source.Length; i++)
            {
                action(source[i]);
            }
        }
    }
}
