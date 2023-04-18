using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; private set; }
        protected Feline(string name, double weight,string livingRegion,int foodeaten string breed) : base(name, weight,0,livingRegion)
        {
            Breed = breed;
        }
    }
}
