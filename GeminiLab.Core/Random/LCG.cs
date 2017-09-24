using System;

namespace GeminiLab.Core.Random {
    internal static class LCGUtil {
        internal static ulong StepModULong(ref ulong X, ulong a, ulong c) => X = unchecked(a * X + c);
        internal static uint StepModUInt(ref uint X, uint a, uint c) => X = unchecked(a * X + c);
    }
    
    public class LCGUInt : IPRNG<uint> {
        protected internal uint a = 0, c = 0;
        private uint X;

        public LCGUInt(uint a, uint c, uint seed) {
            this.a = a; this.c = c;
            Initialize(seed);
        }

        public void Initialize(uint seed) => X = seed;
        public uint Next() => LCGUtil.StepModUInt(ref X, a, c);
    }

    public class LCG0 : LCGUInt {
        private const uint A = 1664525u, C = 1013904223u;
        public LCG0(uint seed) : base(A, C, seed) { }
    }

    public class LCG1 : LCGUInt {
        private const uint A = 22695477u, C = 1u;
        public LCG1(uint seed) : base(A, C, seed) { }
    }

    public class LCG2 : LCGUInt {
        private const uint A = 134775813u, C = 1u;
        public LCG2(uint seed) : base(A, C, seed) { }
    }

    public class LCG3 : LCGUInt {
        private const uint A = 214013u, C = 2531011u;
        public LCG3(uint seed) : base(A, C, seed) { }
    }
}
