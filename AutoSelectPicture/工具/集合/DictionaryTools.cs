using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture.工具
{
    public class DictionaryTools<K,V>
    {
        private Dictionary<K,V> dictionary = null;

        public void SetDictionary(Dictionary<K,V> dictionary)
        {
            this.dictionary = dictionary;
        }

        public ListCollection<K,V> GetListCollection()
        {
            if (this.dictionary != null)
            {
                List<K> keyList = null;
                List<V> valueList = null;
                ListCollection<K, V> listCollection = new ListCollection<K, V>();
                Dictionary<K, V>.Enumerator enumerator = this.dictionary.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    K key = enumerator.Current.Key;
                    V value = enumerator.Current.Value;
                    keyList.Add(key);
                    valueList.Add(value);
                }
                listCollection.SetKeyList(keyList);
                listCollection.SetValueList(valueList);
                return listCollection;
            }
            else
            {
                return null;
            }
        }

        public ArrayCollection<K, V> GetArrayCollection()
        {
            if (this.dictionary != null)
            {
                List<K> keyList = null;
                List<V> valueList = null;
                ArrayCollection<K, V> arrayCollection = new ArrayCollection<K, V>();
                Dictionary<K, V>.Enumerator enumerator = dictionary.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    K key = enumerator.Current.Key;
                    V value = enumerator.Current.Value;
                    keyList.Add(key);
                    valueList.Add(value);
                }
                arrayCollection.SetKeyArray(keyList.ToArray());
                arrayCollection.SetValueArray(valueList.ToArray());
                return arrayCollection;
            }
            else
            {
                return null;
            }    
        }

    }

    public class ListCollection<K,V>
    {
        List<K> keyList   = null;
        List<V> valueList = null;
        public ListCollection()
        {
            
        }
        public ListCollection(List<K> key,List<V> value)
        {
            this.keyList = key;
            this.valueList = value;
        }

        public void Clear()
        {
            keyList.Clear();
            valueList.Clear();
        }

        public void SetKeyList(List<K> keyList)
        {
            this.keyList = keyList;
        }

        public List<K> GetKeyList()
        {
            return this.keyList;
        }

        public void SetValueList(List<V> valueList)
        {
            this.valueList = valueList;
        }

        public List<V> GetValueList()
        {
            return this.valueList;
        }
    }

    public class ArrayCollection<K, V>
    {
        K[] keyArray   = null;
        V[] valueArray = null;
        public void Clear()
        {
            Array.Clear(keyArray,0,keyArray.Length);
            Array.Clear(valueArray, 0, valueArray.Length);
        }

        public void SetKeyArray(K[] keyArray)
        {
            this.keyArray = keyArray;
        }

        public K[] GetKeyArray()
        {
            return this.keyArray;
        }

        public void SetValueArray(V[] valueList)
        {
            this.valueArray = valueList;
        }

        public V[] GetValueArray()
        {
            return valueArray;
        }
    }
}
