using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.IO {
    public static class TextIO {
        public static IEnumerable<string> EnumerateLines(this TextReader src) {
            while (src.Peek() != -1) yield return src.ReadLine();
        }
    }
}
