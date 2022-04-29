using System;
using System.Collections.Generic;

namespace Lab05
{
    public delegate void Added(int msg);
    public delegate void Set(int msg);
    public delegate void Removed(int msg);

    public class ObservableList2
    {
        private List<int> list;
        private int length;

        public int Length { get { return length; } }

        public Added added;
        public Set set;
        public Removed removed;

        public int this[int i]
        {
            get { return list[i]; }
            set
            {
                Set s = set;
                list[i] = value;
                s(i);
            }
        }

        public ObservableList2(Added delAdded, Set delSet, Removed delRemoved)
        {
            list = new List<int>();
            length = 0;
            added = delAdded;
            set = delSet;
            removed = delRemoved;

        }

        public void Add(int input)
        {
            Added a = added;
            list.Add(input);
            length++;

            a(input);
        }

        public void RemoveAt(int index)
        {
            Removed r = removed;
            if (index >= length)
                throw new IndexOutOfRangeException();
            var temp = list[index];
            list.RemoveAt(index);
            length--;

            r(index);
        }

    }
}
