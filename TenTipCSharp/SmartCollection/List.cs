using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SmartCollection
{
    public class List<T>
    {
        private T[] _items = new T[10];
        private int _size = 0;

        public int Count { get { return _size; } }
        public void Add(T item)
        {
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
            //1. item 인덱스 찾기
            var index = Array.IndexOf(_items, item);
            //2. item 제거
            if (index >= 0)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
                _size--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
             
        }

        internal class SmartListEnumerator : IEnumerator<T>
        {
            private List<T> _list;
            private int index = -1;
            public T Current => _list._items[index];

            object IEnumerator.Current => throw new NotImplementedException();

  
            public void Dispose()
            {
                //TODO
            }

            public bool MoveNext()
            {
                if (index + 1 >= _list._size)
                    return false;
                else
                    index++;
                return true;
            }

            public void Reset()
            {
                index = -1;
            }
        }

    }
}
