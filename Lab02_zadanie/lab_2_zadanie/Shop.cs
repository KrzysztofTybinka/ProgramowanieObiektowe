using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    class Shop : IThing
    {
        private string name;
        private Person[] people;
        private Product[] products;

        public string Name { get => name; set { name = Name; } }

        public Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;
            this.people = people;
            this.products = products;
        }

        public string Print()
        {
            string output = "";
            string input = $"Shop: {Name}" + "\n" + "--People: --";

            foreach (var item in people)
            {
                output += item.Print(input);
            }
            return output;
        }

    }
}
