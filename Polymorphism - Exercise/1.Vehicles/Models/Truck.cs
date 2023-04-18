using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public class Truck : ITruck
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

        public Truck(double fuelquantity, double fuelconsumption, int tankcapacity)
        {
            this.tankcapacity = tankcapacity;
            this.fuelquantity = fuelquantity;
            this.fuelconsumption = fuelconsumption;
        }

        public double fuelQuantity => fuelquantity;

        public double fuelConsumption => fuelconsumption + 1.6;

        public int capacity => tankcapacity;

        public void Drive(double distance)
        {
            if (fuelConsumption * distance <= fuelquantity)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                fuelquantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double litres)
        {
            if (litres<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuelquantity+litres>tankcapacity)
            {
                Console.WriteLine($"Cannot fit {litres} fuel in the tank");
            }
            else
            {
                litres = litres - (litres / 10 / 2);
                fuelquantity += litres;
            }

        }
    }
}
