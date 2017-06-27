using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core {
    // python style range
    // [start, end)
    public class Range : IEnumerable<int> {
        int start, end, step;

        public Range() : this(0, 0, 1) { }
        public Range(int end) : this(0, end) { }
        public Range(int start, int end) : this(start, end, start <= end ? 1 : -1) { }
        public Range(int start, int end, int step) {
            this.start = start;
            this.end = end;
            this.step = step;

            if (step == 0) throw new ArgumentException("Invalid parameter.", "step");
            if (start != end && Math.Sign(step) != Math.Sign(end - start)) throw new ArgumentException("Invalid parameter.", "step");
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new RangeEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => new RangeEnumerator(this);

        internal class RangeEnumerator : IEnumerator<int> {
            bool used;
            int value;
            Range mutter;

            public int Current => value;
            object IEnumerator.Current => value;

            public void Dispose() { }

            public bool MoveNext() {
                if (!used) value = mutter.start;
                else value += mutter.step;

                used = true;

                if ((value >= mutter.end && mutter.step > 0) || (value <= mutter.end && mutter.step < 0)) return false;
                return true;
            }

            public void Reset() => used = false;
            public RangeEnumerator(Range mutter) { used = false; this.mutter = mutter; }
        }
    }

    public class LongRange : IEnumerable<long> {
        long start, end, step;

        public LongRange() : this(0, 0, 1) { }
        public LongRange(long end) : this(0, end) { }
        public LongRange(long start, long end) : this(start, end, start <= end ? 1 : -1) { }
        public LongRange(long start, long end, long step) {
            this.start = start;
            this.end = end;
            this.step = step;

            if (step == 0) throw new ArgumentException("Invalid parameter.", "step");
            if (start != end && Math.Sign(step) != Math.Sign(end - start)) throw new ArgumentException("Invalid parameter.", "step");
        }

        IEnumerator<long> IEnumerable<long>.GetEnumerator() => new LongRangeEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => new LongRangeEnumerator(this);

        internal class LongRangeEnumerator : IEnumerator<long> {
            bool used;
            long value;
            LongRange mutter;

            public long Current => value;
            object IEnumerator.Current => value;

            public void Dispose() { }

            public bool MoveNext() {
                if (!used) value = mutter.start;
                else value += mutter.step;

                used = true;

                if ((value >= mutter.end && mutter.step > 0) || (value <= mutter.end && mutter.step < 0)) return false;
                return true;
            }

            public void Reset() => used = false;
            public LongRangeEnumerator(LongRange mutter) { used = false; this.mutter = mutter; }
        }
    }
}
