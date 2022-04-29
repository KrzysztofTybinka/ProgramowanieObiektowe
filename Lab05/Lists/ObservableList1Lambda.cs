using System;
using System.Collections.Generic;


namespace Lab05
{
    public class ObservableList1Lambda<T>
    {
        private List<T> list;
        private int length;

        public int Length { get => length; }

        public delegate void ObservationListEventhandler(object sender, ChangedEventArgs<T> e);

        public event ObservationListEventhandler Added;
        public event ObservationListEventhandler Removed;
        public event ObservationListEventhandler Updated;

        public T this[int i]
        {
            get => list[i]; 
            set
            {
                list[i] = value;
                OnUpdated(new ChangedEventArgs<T>(value));
            }
        }

        public ObservableList1Lambda()
        {
            list = new List<T>();
            length = 0;
        }

        public void Add(T input)
        {
            list.Add(input);
            length++;

            OnAdded(new ChangedEventArgs<T>(input));
        }

        public void RemoveAt(int index)
        {
            if (index >= length)
                throw new IndexOutOfRangeException();
            var temp = list[index];
            list.RemoveAt(index);
            length--;

            OnRemoved(new ChangedEventArgs<T>(temp));
        }

        protected virtual void OnAdded(ChangedEventArgs<T> e)
        {
            if (Added != null)
                Added(this, e);
        }

        protected virtual void OnRemoved(ChangedEventArgs<T> e)
        {
            if (Removed != null)
                Removed(this, e);
        }

        protected virtual void OnUpdated(ChangedEventArgs<T> e)
        {
            if (Updated != null)
                Updated(this, e);
        }
    }
}
