using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    public class ChangedEventArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public ChangedEventArgs(T value)
        {
            this.Value = value;
        }
    }
}
