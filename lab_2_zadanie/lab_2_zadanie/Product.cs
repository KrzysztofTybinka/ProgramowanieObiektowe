using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    class Product : IThing
    {
        private string name;

        public string Name { get => name; set { name = Name; } }

        public Product(string name)
        {
            this.name = name;
        }

        public string Print(string prefix)
        {
            return $"{name}";
        }
    }
}
