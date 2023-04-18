using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;
        private const double CoffeeMillilitres = 50;
        public Coffee(string name, double caffeine) 
            : base(name, CoffeePrice, CoffeeMillilitres)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
