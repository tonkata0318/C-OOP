using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion,int foodeaten, string breed) : base(name, weight, livingRegion,0, breed)
        {
        }

        public override string Sound()
        {
            return "ROAR!!!";
        }
        public override string ToString()
        {
            return $"Tiger [{name}, {Breed}, {weight}, {livingRegion}, {Breed}]";
        }
    }
}
