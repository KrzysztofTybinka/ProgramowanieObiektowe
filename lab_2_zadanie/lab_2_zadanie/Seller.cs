using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    class Seller : Person
    {
        public Seller(string name, int age) : base(name, age)
        {
            base.Name = name;
            base.Age = age;
        }

        public new string Print(string prefix)
        {
            return prefix + $"\t\nSeller: {Name} ({Age} y.o.)";
        }
    }
}
