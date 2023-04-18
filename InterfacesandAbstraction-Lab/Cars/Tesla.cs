using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla :Car, ICar, IElectricCar
    {
        int battery { get;}
        public Tesla(string model, string color, int battery):base(model,color)
        {
           this.battery = battery;
        }

        public string Model => model;

        public string Color => color;

        public int Baterry => this.battery;
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Baterry} Batteries";
        }
    }
}
