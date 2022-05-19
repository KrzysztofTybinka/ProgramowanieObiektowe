using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    class Fruit : Product
    {
        private int count;

        public int Count { get => count; set { count = Count; } }

        public Fruit(string name, int count) : base(name)
        {
            base.Name = name;
            this.count = count;
        }

        public new string Print(string prefix)
        { 
            return $"{Name} ({count} fruits)";
        }
    }
}
