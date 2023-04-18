using _3.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public string name { get;private set; }
        public int power { get; private set; }
        public BaseHero(string name, int power)
        {
            this.name = name;
            this.power = power;
        }

        public string Name => name;

        public int Power => power;

        public virtual string CastAbility()
        {
            return "";
        }
    }
}
