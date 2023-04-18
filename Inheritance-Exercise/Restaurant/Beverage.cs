using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Beverage : Product
    {

        public Beverage(string name, decimal price,double millimetres) 
            : base(name, price)
        {
            Millimetres= millimetres;
        }
        public double Millimetres { get; private set; }
    }
}
