using System;
using System.Collections;
using System.Collections.Generic;


namespace Lab04
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] array;
        private int count;
        private int capacity;

        public T this[int i]
        {
            get { return array[i]; }
            set 
            {
                if (i >= capacity)
                {
                    T[] temp = new T[i + 1];
                    for (int j = 0; j < Capacity; j++)
                    {
                        temp[j] = array[j];
                    }
                    count = i; 
                    capacity = i;
                    array = temp;
                }
                else
                    count++;
                array[i] = value; 
            }
        }
        public int Count { get => count; }
        public int Capacity { get => capacity; }

        public DynamicArray()
        {
            array = new T[1];
            count = 0;
            capacity = 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this.array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] arr;
        private int curIndex;

        public DynamicArrayEnumerator(T[] array)
        {
            arr = array;
            curIndex = -1;
        }
        public T Current { get => arr[curIndex]; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (++curIndex >= arr.Length)
                return false;
            return true;
        }

        public void Reset()
        {
            curIndex = -1;
        }
    }
}
