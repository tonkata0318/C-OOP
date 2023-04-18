using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodeaten, double wingSize) : base(name, weight, foodeaten, wingSize)
        {
        }
        public override string Sound()
        {
            return "Hoot Hoot";
        }
        public override string ToString()
        {
            return $"Owl [{name}, {WingSize}, {weight}, {foodeaten}]";
        }
    }
}
