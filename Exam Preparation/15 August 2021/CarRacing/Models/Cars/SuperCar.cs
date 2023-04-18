﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double availableFuel = 80;
        private const double fuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower,availableFuel, fuelConsumptionPerRace)
        {
        }
    }
}
