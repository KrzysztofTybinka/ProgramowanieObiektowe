using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    class Buyer : Person
    {
        protected List<Product> tasks = new List<Product>();

        public Buyer(string name, int age) : base(name, age)
        {
            base.Name = name;
            base.Age = age;
        }

        public void AddProducts(Product product)
        {
            tasks.Add(product);
        }

        public void RemoveProduct(int index)
        {
            tasks.RemoveAt(index);
        }

        public new string Print(string prefix)
        {
            string output;
            if (tasks.Count > 0)
                output = $"\tBuyer: {Name} ({Age} y.o.)\n\t-- Products --"; //call function
            else
                output = $"\tBuyer: {Name} ({Age} y.o.)";

            return prefix + output;
        }
    }
}
