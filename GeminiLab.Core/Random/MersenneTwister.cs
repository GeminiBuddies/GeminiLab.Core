using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.Random {
    public class MT19937X64 : IPRNG<ulong> {
        public const int w = 64;
        public const ulong n = 312;
        public const ulong m = 156;
        public const int r = 31;
        public const ulong a = 0xB5026F5AA96619E9;
        public const int u = 29;
        public const ulong d = 0x5555555555555555;
        public const int s = 17;
        public const ulong b = 0x71D67FFFEDA60000;
        public const int t = 37;
        public const ulong c = 0xFFF7EEE000000000;
        public const int l = 43;
        public const ulong f = 6364136223846793005;

        public const ulong lowerMask = (1ul << r) - 1;
        public const ulong upperMask = ~lowerMask;

        private ulong[] MT = new ulong[n];
        private ulong index;

        public MT19937X64(ulong seed) => Initialize(seed);
        public void Initialize(ulong seed) {
            index = n;
            MT[0] = seed;

            for (ulong i = 1; i < n; ++i) {
                MT[i] = (f * (MT[i - 1] ^ (MT[i - 1] >> (w - 2))) + i);
            }
        }

        public ulong Next() {
            if (index >= n) twist();

            ulong y = MT[index];
            y = y ^ ((y >> u) & d);
            y = y ^ ((y << s) & b);
            y = y ^ ((y << t) & c);
            y = y ^ (y >> l);

            ++index;

            return y;
        }

        private void twist() {
            for (ulong i = 0; i < n; ++i) {
                ulong x = (MT[i] & upperMask) + (MT[(i + 1) % n] & lowerMask);
                ulong xA = x >> 1;

                if ((x & 1) == 1) xA = xA ^ a;

                MT[i] = MT[(i + m) % n] ^ xA;
            }

            index = 0;
        }
    }

    public class MT19937 : IPRNG<uint> {
        public const int w = 32;
        public const uint n = 624;
        public const uint m = 397;
        public const int r = 31;
        public const uint a = 0x9908B0DF;
        public const int u = 11;
        public const uint d = 0xffffffff;
        public const int s = 7;
        public const uint b = 0x9d2c5680;
        public const int t = 15;
        public const uint c = 0xefc60000;
        public const int l = 18;
        public const uint f = 1812433253;

        public const uint lowerMask = (1u << r) - 1;
        public const uint upperMask = ~lowerMask;

        private uint[] MT = new uint[n];
        private uint index;

        public MT19937(uint seed) => Initialize(seed);
        public void Initialize(uint seed) {
            index = n;
            MT[0] = seed;

            for (uint i = 1; i < n; ++i) {
                MT[i] = (f * (MT[i - 1] ^ (MT[i - 1] >> (w - 2))) + i);
            }
        }

        public uint Next() {
            if (index >= n) twist();

            uint y = MT[index];
            y = y ^ ((y >> u) & d);
            y = y ^ ((y << s) & b);
            y = y ^ ((y << t) & c);
            y = y ^ (y >> l);

            ++index;

            return y;
        }

        private void twist() {
            for (uint i = 0; i < n; ++i) {
                uint x = (MT[i] & upperMask) + (MT[(i + 1) % n] & lowerMask);
                uint xA = x >> 1;

                if ((x & 1) == 1) xA = xA ^ a;

                MT[i] = MT[(i + m) % n] ^ xA;
            }

            index = 0;
        }
    }

    public class MT19937S : IPRNG<int> {
        MT19937 gen;

        public MT19937S(int seed) => gen = new MT19937(unchecked((uint)(seed)));
        
        public void Initialize(int seed) => gen.Initialize(unchecked((uint)(seed)));
        public int Next() => unchecked((int)(gen.Next()));
    }

    public class MT19937X64S : IPRNG<long> {
        MT19937X64 gen;

        public MT19937X64S(long seed) => gen = new MT19937X64(unchecked((ulong)(seed)));

        public void Initialize(long seed) => gen.Initialize(unchecked((ulong)(seed)));
        public long Next() => unchecked((long)(gen.Next()));
    }
}
