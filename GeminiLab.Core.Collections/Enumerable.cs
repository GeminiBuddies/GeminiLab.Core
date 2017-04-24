using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.Collections
{
    public static class Enumerable
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            foreach (var i in source) action(i);
        }

        public static IEnumerable<T> ChainForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            foreach(T i in source)
            {
                action(i);
                yield return i;
            }

            yield break;
        }

        public static void EndChainForEach<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            foreach (T i in source) ;
        }

        public static IEnumerable<T> EnumerateAll<T>(this IEnumerable<T> source)
        {
            return source.ToList();
        }

        public static IEnumerable<T> ArbitraryUnion<T>(this IEnumerable<IEnumerable<T>> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Union(y));
        }

        public static IEnumerable<T> ArbitraryUnion<T>(this IEnumerable<IEnumerable<T>> source, IEqualityComparer<T> comparer)
        {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Union(y, comparer));
        }

        public static IEnumerable<T> ArbitraryIntersect<T>(this IEnumerable<IEnumerable<T>> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Intersect(y));
        }

        public static IEnumerable<T> ArbitraryIntersect<T>(this IEnumerable<IEnumerable<T>> source, IEqualityComparer<T> comparer)
        {
            if (source == null) throw new ArgumentNullException("source");

            return source.Aggregate((x, y) => x.Intersect(y, comparer));
        }

        public static IEnumerable<T> Expand<T>(this IEnumerable<IEnumerable<T>> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            foreach (var ie in source)
            {
                if (ie == null) throw new ArgumentOutOfRangeException("source", "A value in parameter source is null.");

                foreach (var i in ie) yield return i;
            }
        }
        
        public static IEnumerable<T> RemoveNull<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            foreach (var i in source) if (i != null) yield return i;
        }

        public static Dictionary<int, T> NumberItems<T>(this IEnumerable<T> source) => source.NumberItems(0);

        public static Dictionary<int, T> NumberItems<T>(this IEnumerable<T> source, int startIndex)
        {
            if (source == null) throw new ArgumentNullException("source");

            int count = startIndex;
            return source.ToDictionary(any => count++);
        }
    }
}
