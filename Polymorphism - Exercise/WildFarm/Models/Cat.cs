using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodeaten, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override string Sound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            return $"Tiger [{name}, {Breed}, {weight}, {livingRegion}, {Breed}]";
        }
    }
}
