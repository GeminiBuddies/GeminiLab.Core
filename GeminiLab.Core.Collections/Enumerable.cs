using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.Collections {
    public static class Enumerable {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            foreach (var i in source) action(i);
        }

        public static IEnumerable<T> ChainForEach<T>(this IEnumerable<T> source, Action<T> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            foreach (T i in source) {
                action(i);
                yield return i;
            }
        }

        public static void EndChainForEach<T>(this IEnumerable<T> source) {
            if (source == null) throw new ArgumentNullException("source");

            foreach (T i in source) ;
        }

        public static IEnumerable<T> EnumerateAll<T>(this IEnumerable<T> source) {
            return source.ToList();
        }

        public static IEnumerable<T> ArbitraryUnion<T>(this IEnumerable<IEnumerable<T>> source) {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Union(y));
        }

        public static IEnumerable<T> ArbitraryUnion<T>(this IEnumerable<IEnumerable<T>> source, IEqualityComparer<T> comparer) {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Union(y, comparer));
        }

        public static IEnumerable<T> ArbitraryIntersect<T>(this IEnumerable<IEnumerable<T>> source) {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Intersect(y));
        }

        public static IEnumerable<T> ArbitraryIntersect<T>(this IEnumerable<IEnumerable<T>> source, IEqualityComparer<T> comparer) {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Intersect(y, comparer));
        }

        public static IEnumerable<T> Expand<T>(this IEnumerable<IEnumerable<T>> source) {
            if (source == null) throw new ArgumentNullException("source");

            foreach (var ie in source) {
                if (ie == null) throw new ArgumentOutOfRangeException("source", "A value in parameter source is null.");

                foreach (var i in ie) yield return i;
            }
        }

        public static IEnumerable<T> RemoveNull<T>(this IEnumerable<T> source) {
            if (source == null) throw new ArgumentNullException("source");

            foreach (var i in source) if (i != null) yield return i;
        }

        public static Dictionary<int, T> NumberItems<T>(this IEnumerable<T> source) => source.NumberItems(0);

        public static Dictionary<int, T> NumberItems<T>(this IEnumerable<T> source, int startIndex) {
            if (source == null) throw new ArgumentNullException("source");

            int count = startIndex;
            return source.ToDictionary(any => count++);
        }
    }

    public static class EnumerableOfString {
        public static string JoinBy(this IEnumerable<string> value, string separator) => string.Join(separator, value);
        public static string JoinBy(this IEnumerable<char> value, string separator) => string.Join(separator, value);

        public static string Join(this IEnumerable<string> value) => string.Join("", value);
        public static string Join(this IEnumerable<char> value) => string.Join("", value);

        public static string Join(this string separator, IEnumerable<string> value) => string.Join(separator, value);
    }

    public static class EnumerableAndRandom {
        public static Random staticRan = new Random();

        public static T Choose<T>(this IEnumerable<T> source) => source.ToList().Choose();
        public static T Choose<T>(this IEnumerable<T> source, Random ran) => source.ToList().Choose(ran);

        public static T Choose<T>(this IList<T> source) => Choose(source, staticRan);

        public static T Choose<T>(this IList<T> source, Random ran) {
            if (source == null) throw new ArgumentNullException("source");
            if (ran == null) throw new ArgumentNullException("ran");

            return source[ran.Next(0, source.Count)];
        }
    }
}
