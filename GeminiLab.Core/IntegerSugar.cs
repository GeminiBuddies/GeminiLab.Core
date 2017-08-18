using System;
using System.Collections;
using System.Collections.Generic;

namespace GeminiLab.Core {
    public static class IntegerSugar {
        public static IEnumerable<T> Times<T>(this int v, Func<T> fn) {
            if (fn == null) throw new ArgumentNullException("fn");
            if (v < 0) throw new ArgumentOutOfRangeException("v", v, "v should be greater than 0.");
            if (v == 0) yield break;

            for (int i = 0; i < v; ++i) yield return fn();
        }

        public static void Times<T>(this int v, Action act) {
            if (act == null) throw new ArgumentNullException("act");
            if (v < 0) throw new ArgumentOutOfRangeException("v", v, "v should be greater than 0.");
            
            for (int i = 0; i < v; ++i) act();
        }

        public static IEnumerable<int> To(this int v, int dest) => new Range(v, dest);
        public static IEnumerable<int> To(this int v, int dest, int step) => new Range(v, dest, step);
        public static IEnumerable<long> To(this long v, long dest) => new LongRange(v, dest);
        public static IEnumerable<long> To(this long v, long dest, long step) => new LongRange(v, dest, step);
    }
}