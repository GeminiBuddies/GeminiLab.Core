using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.Collections
{
    public static class DictionaryExtension
    {
        public static Dictionary<U, V> Reverse<V, U>(this Dictionary<V, U> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            Dictionary<U, V> rv = new Dictionary<U, V>();

            foreach (var i in source)
            {
                if (rv.ContainsKey(i.Value)) throw new ArgumentException("Duplicate values.", "source");
                rv.Add(i.Value, i.Key);
            }

            return rv;
        }
    }
}
