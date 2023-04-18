using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodeaten, double wingSize) : base(name, weight, foodeaten, wingSize)
        {
        }
        public override string Sound()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return $"Hen [{name}, {WingSize}, {weight}, {foodeaten}]";
        }
    }
}
