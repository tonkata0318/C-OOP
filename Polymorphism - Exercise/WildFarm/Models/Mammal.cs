using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public abstract class Mammal : Animal
    {
        public string livingRegion { get; private set; }
        protected Mammal(string name, double weight, int foodeaten,string livingRegion) : base(name, weight, foodeaten)
        {
            this.livingRegion = livingRegion;
        }
    }
}
