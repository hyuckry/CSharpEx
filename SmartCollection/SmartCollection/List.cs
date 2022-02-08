using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCollection
{
    [DebuggerDisplay("Count={Count}")]
    public class List<T>:IEnumerable<T>
    {
        internal class InternalComparer : IComparer<T>
        {
            private Comparison<T> comparison;

            public InternalComparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            public int Compare(T? x, T? y)
            {
                return this.comparison(x,y);
            }
        }

        private T[] _items = new T[10];
        private int _size = 0;         

        public void Add(T item)
        {
            //There is enough space in Array to add an element
            if (_size < _items.Length)
            {
                _items[_size] = item;
                _size++;
            }
            else
            {
                T[] destinArray = new T[_size * 2];
                Array.Copy(_items, destinArray, _size);
                _items = destinArray;
                _items[_size] = item;
                _size++;
            }
        }
        public void Remove(T item)
        {
            var index = Array.IndexOf(_items, item);
            if (index >= 0)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
                _size--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get { return _size; } }

        public T this[int index]
        {
            get
            {
                if (index >= this._items.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                else
                {
                    return _items[index];
                }
            }
            set
            {
                if (index >= this._items.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                else
                { _items[index] = value; }
            }
        }

        public void Sort()
        {
            Array.Sort<T>(_items,0,_size);
        }

        public void Sort(Comparison<T> comparison)
        {
            Array.Sort<T>(_items,0,_size,new InternalComparer(comparison));
        }

    }

}
