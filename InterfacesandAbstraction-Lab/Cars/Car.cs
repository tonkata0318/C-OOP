using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public abstract class Car
    {
        public string model { get;}
        public string color { get;}
        public Car(string model, string color)
        {
            this.model = model;
            this.color = color;
        }
    }
}
