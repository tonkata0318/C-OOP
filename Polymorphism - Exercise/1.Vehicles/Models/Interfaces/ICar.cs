using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public interface ICar
    {
        double fuelQuantity { get;}
        double fuelConsumption { get;}
        int tankCapacity { get;}
        void Drive(double distance);
        void Refuel(double litres);

    }
}
