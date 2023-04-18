using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        public string name { get; private set; }
        public double weight { get; private set; }
        public int foodeaten { get; private set; }
        public Animal(string name, double weight, int foodeaten)
        {
            this.name = name;
            this.weight = weight;
            this.foodeaten = foodeaten;
        }

        public string Name => name;

        public double Weight => weight;

        public int FoodEaten => foodeaten;

        public virtual string Sound()
        {
            return "Sound";
        }

        public virtual void IncreaseWeight(double weight)
        {
            this.weight += weight;
        }
    }
}
