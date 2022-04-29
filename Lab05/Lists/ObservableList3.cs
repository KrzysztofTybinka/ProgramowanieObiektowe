using System;
using System.Collections.Generic;


namespace Lab05
{
    public class ObservableList3<T>
    {
        private List<T> list;
        private int length;

        public int Length { get { return length; } }

        public delegate void Added(T i);
        public delegate void Updated(int i);
        public delegate void Removed(int i);

        public T this[int i]
        {
            get { return list[i]; }
            set
            {
                list[i] = value;
                Updated u = new Updated(OnUpdate);
                u.Invoke(i);
            }
        }

        public ObservableList3()
        {
            list = new List<T>();
            length = 0;
        }

        public void Add(T input)
        {
            list.Add(input);
            length++;

            Added a = new Added(OnAdd);
            a.Invoke(input);
        }

        public void RemoveAt(int index)
        {
            if (index >= length)
                throw new IndexOutOfRangeException();
            var temp = list[index];
            list.RemoveAt(index);
            length--;

            Removed r = new Removed(OnRemoveAt);
            r.Invoke(index);
        }

        public void OnRemoveAt(int i)
        {
            Console.WriteLine("Event raised! Removing value at index: " + i);
        }

        public void OnAdd(T i)
        {
            Console.WriteLine("Event raised! Adding value: " + i);
        }

        public void OnUpdate(int i)
        {
            Console.WriteLine("Event raised! Updating value at index: " + i);
        }

    }
}
