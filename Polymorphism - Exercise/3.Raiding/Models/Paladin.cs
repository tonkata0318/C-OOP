using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name, int power) : base(name, power)
        {
        }
        public override string CastAbility()
        {
            return $"Paladin - {Name} healed for {Power}";
        }
    }
}
