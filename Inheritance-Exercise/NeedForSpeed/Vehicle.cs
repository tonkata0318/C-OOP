using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }
        public virtual void Drive(double kilometres)
        {
            double fuelConsumed = FuelConsumption * kilometres;
            Fuel-=fuelConsumed;
            //Console.WriteLine(Fuel);
        }
    }
}
