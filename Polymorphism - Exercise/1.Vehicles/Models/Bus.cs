using _1.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public class Bus : IBus
    {
        private double fuelquantityField;
        public double fuelquantity
        {
            get { return fuelquantityField; }
            private set
            {
                if (value > tankcapacity)
                {
                    fuelquantityField = 0;
                }
                else
                {
                    fuelquantityField = value;
                }

            }
        }
        public double fuelconsumption { get; private set; }
        public int tankcapacity { get; private set; }
        public Bus(double fuelquantity, double fuelconsumption, int tankCapacity)
        {
            this.tankcapacity = tankCapacity;
            this.fuelquantity = fuelquantity;
            this.fuelconsumption = fuelconsumption;
        }

        public double fuelQuantity => fuelquantity;

        public double fuelConsumption => fuelconsumption+1.4;

        public int tankCapacity => tankcapacity;

        public void Drive(double distance)
        {
            if (fuelConsumption * distance <= fuelquantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                fuelquantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void Refuel(double litres)
        {
            if (litres<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuelquantity + litres > tankcapacity)
            {
                Console.WriteLine($"Cannot fit {litres} fuel in the tank");
            }
            else
            {
                fuelquantity += litres;
            }

        }

        public void DriveEmpty(double distance)
        {
            fuelconsumption -= 1.4;
            if (fuelConsumption * distance <= fuelquantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                fuelquantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
    }
}
