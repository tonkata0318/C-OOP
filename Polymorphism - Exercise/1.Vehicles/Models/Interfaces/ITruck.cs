using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public interface ITruck
    {
        double fuelQuantity { get; }
        double fuelConsumption { get; }
        void Drive(double distance);
        void Refuel(double litres);
        int capacity { get; }
    }
}
