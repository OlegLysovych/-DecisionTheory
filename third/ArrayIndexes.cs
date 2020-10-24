using System;
using System.Linq;

namespace third
{
    public static class ArrayIndexes
    {
        public static Tuple<int, int> CoordinatesOf<T>(this T[,] matrix, T value, int[] looper)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height


            for (int x = looper[0]; x < w; ++x)
            {
                for (int y = looper[1]; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }
        public static Tuple<int, int> CoordinatesOf<T>(this T[,] matrix, T value)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height


            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }

        public static int[] FindIndex(this Array haystack, object needle)
        {
            if (haystack.Rank == 1)
                return new[] { Array.IndexOf(haystack, needle) };

            var found = haystack.OfType<object>()
                              .Select((v, i) => new { v, i })
                              .FirstOrDefault(s => s.v.Equals(needle));
            if (found == null)
                throw new Exception("needle not found in set");

            var indexes = new int[haystack.Rank];
            var last = found.i;
            var lastLength = Enumerable.Range(0, haystack.Rank)
                                       .Aggregate(1,
                                           (a, v) => a * haystack.GetLength(v));
            for (var rank = 0; rank < haystack.Rank; rank++)
            {
                lastLength = lastLength / haystack.GetLength(rank);
                var value = last / lastLength;
                last -= value * lastLength;

                var index = value + haystack.GetLowerBound(rank);
                if (index > haystack.GetUpperBound(rank))
                    throw new IndexOutOfRangeException();
                indexes[rank] = index;
            }

            return indexes;
        }
    }
}