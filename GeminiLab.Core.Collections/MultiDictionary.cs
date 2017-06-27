using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.Collections {
    public interface IMultiDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, IEnumerable<TValue>>> {
        int KeyCount { get; }
        int ValueCount { get; }

        IEnumerable<TValue> this[TKey key] { get; set; }
        IEnumerable<TKey> Keys { get; }
        IEnumerable<TValue> Values { get; }

        void Add(TKey key, TValue value);
        void Remove(TKey key, TValue value);
        void RemoveAll(TKey key);
        bool ContainsKey(TKey key);
        bool Contains(TKey key, TValue value);

        bool TryGetValue(TKey key, out IEnumerable<TValue> values);
    }

    public static class IMultiDictionaryExtension {
        public static IEnumerable<KeyValuePair<TKey, TValue>> EnumeratePairs<TKey, TValue>(this IMultiDictionary<TKey, TValue> v) {
            if (v == null) throw new ArgumentNullException("v");

            foreach (var key in v.Keys)
                foreach (var value in v[key]) yield return new KeyValuePair<TKey, TValue>(key, value);
        }
    }

    public class MultiDictionary<TKey, TValue> : IMultiDictionary<TKey, TValue> {
        private Dictionary<TKey, HashSet<TValue>> innerDict;

        public MultiDictionary() {
            innerDict = new Dictionary<TKey, HashSet<TValue>>();
        }

        public IEnumerable<TValue> this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int KeyCount => throw new NotImplementedException();

        public int ValueCount => throw new NotImplementedException();

        public IEnumerable<TKey> Keys => throw new NotImplementedException();

        public IEnumerable<TValue> Values => throw new NotImplementedException();

        public void Add(TKey key, TValue value) {
            throw new NotImplementedException();
        }

        public bool Contains(TKey key, TValue value) {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key) {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, IEnumerable<TValue>>> GetEnumerator() {
            throw new NotImplementedException();
        }

        public void Remove(TKey key, TValue value) {
            throw new NotImplementedException();
        }

        public void RemoveAll(TKey key) {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out IEnumerable<TValue> values) {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }

}
}
