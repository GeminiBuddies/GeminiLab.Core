using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.IO
{
    public static class StreamExtension
    {
        public static IEnumerable<string> EnumerateLines(this StreamReader src)
        {
            while (!src.EndOfStream) yield return src.ReadLine();
        }
    }
}
