using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public abstract class Bird : Animal
    {
        public double WingSize { get;private set; }
        protected Bird(string name, double weight, int foodeaten, double wingSize) : base(name, weight, foodeaten)
        {
            WingSize = wingSize;
        }
    }
}
