using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make= make;
            Model= model;
            HorsePower= horsePower;
            FuelAvailable= fuelAvailable;
            this.VIN = VIN;
            this.FuelConsumptionPerRace= fuelConsumptionPerRace;
        }
        private string make;

        public string Make
        {
            get { return make; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                make = value;
            }
        }


        private string model;

        public string Model
        {
            get { return model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                model = value;
            }
        }


        private string vin;

        public string VIN
        {
            get { return vin; }
            private set 
            {
                if (value.Length!=17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }
                vin = value;
            }
        }


        private int horsePower;

        public int HorsePower
        {
            get { return horsePower; }
            private set 
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                horsePower = value;
            }
        }


        private double fuelAvailable;

        public double FuelAvailable
        {
            get { return fuelAvailable; }
            private set { fuelAvailable = value; }
        }


        private double fuelConsumptionPerRace;

        public double FuelConsumptionPerRace
        {
            get { return fuelConsumptionPerRace; }
            private set 
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                fuelConsumptionPerRace = value; 
            }
        }


        public void Drive()
        {
            fuelAvailable -= fuelConsumptionPerRace;
            if (fuelAvailable<0)
            {
                fuelAvailable = 0;
            }
            if (this.GetType().Name ==nameof(TunedCar))
            {
                
                int amount = 3/horsePower*100;
                horsePower -= amount;
            }
        }
    }
}
