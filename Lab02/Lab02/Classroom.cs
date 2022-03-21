using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Classroom
    {
        private string name;
        private Person[] persons;

        public string Name { get => name; set { name = Name; } }

        public Classroom(string name, Person[] persons)
        {
            this.name = name;
            this.persons = persons;
        }

        public override string ToString()
        {
            string output = "";
            foreach (var item in persons)
            {
                output += item.ToString() + '\n' + '\n';
            }
            return $"Classroom: {name}" + '\n' + '\n' + output;
        }

    }
}
