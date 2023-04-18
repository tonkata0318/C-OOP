using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodeaten, string livingRegion) : base(name, weight, foodeaten, livingRegion)
        {
        }
        public override string Sound()
        {
            return "Squeak";
        }
    }
}
