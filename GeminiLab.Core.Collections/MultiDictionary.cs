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
        bool Remove(TKey key, TValue value);
        bool RemoveAll(TKey key);
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

        public IEnumerable<TValue> this[TKey key] { get => innerDict[key]; set => innerDict[key] = new HashSet<TValue>(value); }

        public int KeyCount => innerDict.Count;
        public int ValueCount {
            get {
                int acc = 0;
                foreach (var key in innerDict.Keys) {
                    acc += innerDict[key].Count;
                }
                return acc;
            }
        }

        public IEnumerable<TKey> Keys => innerDict.Keys;
        public IEnumerable<TValue> Values {
            get {
                foreach (var key in innerDict.Keys) {
                    foreach (var val in innerDict[key]) yield return val;
                }
            }
        }

        public void Add(TKey key, TValue value) {
            if (!innerDict.ContainsKey(key)) innerDict[key] = new HashSet<TValue>();

            innerDict[key].Add(value);
        }

        public bool Contains(TKey key, TValue value) {
            if (!innerDict.ContainsKey(key)) return false;

            return innerDict[key].Contains(value);
        }

        public bool ContainsKey(TKey key) {
            return innerDict.ContainsKey(key);
        }

        class MultiDictionaryEnumerator : IEnumerator<KeyValuePair<TKey, IEnumerable<TValue>>> {
            IEnumerator<KeyValuePair<TKey, HashSet<TValue>>> innerE;

            public KeyValuePair<TKey, IEnumerable<TValue>> Current => new KeyValuePair<TKey, IEnumerable<TValue>>(innerE.Current.Key, innerE.Current.Value);
            object IEnumerator.Current => new KeyValuePair<TKey, IEnumerable<TValue>>(innerE.Current.Key, innerE.Current.Value);

            public bool MoveNext() { return innerE.MoveNext(); }
            public void Reset() { innerE.Reset(); }
            public void Dispose() { innerE.Dispose(); }

            public MultiDictionaryEnumerator(IEnumerator<KeyValuePair<TKey, HashSet<TValue>>> innerE) {
                this.innerE = innerE;
            }
        }

        public IEnumerator<KeyValuePair<TKey, IEnumerable<TValue>>> GetEnumerator() {
            return new MultiDictionaryEnumerator(innerDict.GetEnumerator());
        }

        public bool Remove(TKey key, TValue value) {
            if (!innerDict.ContainsKey(key)) return false;
            return innerDict[key].Remove(value);
        }

        public bool RemoveAll(TKey key) {
            return innerDict.Remove(key);
        }

        public bool TryGetValue(TKey key, out IEnumerable<TValue> values) {
            if (innerDict.TryGetValue(key, out HashSet<TValue> v)) {
                values = v;
                return true;
            } else {
                values = default(IEnumerable<TValue>);
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
