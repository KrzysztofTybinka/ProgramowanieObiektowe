using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    class Person : IThing
    {
        private string name;
        private int age;

        public string Name { get => name; set { name = Name; } }
        public int Age { get => age; set { age = Age; }  }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Print(string prefix)
        {


            return $"{name} ({age} y.o.)";
        }


    }
}
