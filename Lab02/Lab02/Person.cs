using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Person : IEquatable<Person>
    {
        protected string name;
        protected int age;

        public string Name { get => name; }
        public int Age { get => age; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public bool Equals(Person other)
        {
            if (other == null) return false;
            if (other == this) return true;

            return Object.Equals(this.name, other.name) && Object.Equals(this.age, other.age);
        }

        public override string ToString()
        {
            return $"Person: {name}, age: ({age})";
        }
    }
}
