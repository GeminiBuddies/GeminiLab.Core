using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.Collections
{
    public interface IMultiDictionary<TKey, TValue> : IDictionary<TKey, IEnumerable<TValue>>
    {

    }

    public class MultiDictionary<TKey, TValue> : IDictionary<TKey, IEnumerable<TValue>>, IEnumerable<KeyValuePair<TKey, IEnumerable<TValue>>>
    {
        IEnumerable<TValue> IDictionary<TKey, IEnumerable<TValue>>.this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        ICollection<TKey> IDictionary<TKey, IEnumerable<TValue>>.Keys => throw new NotImplementedException();

        ICollection<IEnumerable<TValue>> IDictionary<TKey, IEnumerable<TValue>>.Values => throw new NotImplementedException();

        int ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Count => throw new NotImplementedException();

        bool ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.IsReadOnly => false;

        void IDictionary<TKey, IEnumerable<TValue>>.Add(TKey key, IEnumerable<TValue> value)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Add(KeyValuePair<TKey, IEnumerable<TValue>> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Contains(KeyValuePair<TKey, IEnumerable<TValue>> item)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<TKey, IEnumerable<TValue>>.ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.CopyTo(KeyValuePair<TKey, IEnumerable<TValue>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<TKey, IEnumerable<TValue>>> IEnumerable<KeyValuePair<TKey, IEnumerable<TValue>>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool IDictionary<TKey, IEnumerable<TValue>>.Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Remove(KeyValuePair<TKey, IEnumerable<TValue>> item)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<TKey, IEnumerable<TValue>>.TryGetValue(TKey key, out IEnumerable<TValue> value)
        {
            throw new NotImplementedException();
        }
    }
}
