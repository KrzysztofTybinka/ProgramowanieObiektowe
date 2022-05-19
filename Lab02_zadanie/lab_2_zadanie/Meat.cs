using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    class Meat : Product
    {
        private double weight;

        public double Weigt { get => weight; set { weight = Weigt; } }

        public Meat (string name, double weight) : base(name)
        {
            base.Name = name;
            this.weight = weight;
        }

        public new string Print()
        {
            return $"{Name} ({weight} kg)";
        }
    }
}
