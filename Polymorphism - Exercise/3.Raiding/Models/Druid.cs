using _3.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name, int power) : base(name, power)
        {
            
        }
        public override string CastAbility()
        {
            return $"Druid - {Name} healed for {Power}";
        }
    }
}
