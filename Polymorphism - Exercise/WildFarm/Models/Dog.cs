using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodeaten, string livingRegion) : base(name, weight, foodeaten, livingRegion)
        {
        }
        public override string Sound()
        {
            return "Woof!";
        }
    }
}
