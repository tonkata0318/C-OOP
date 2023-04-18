using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double availableFuel = 65;
        private const double fuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, availableFuel, fuelConsumptionPerRace)
        {
        }
    }
}
