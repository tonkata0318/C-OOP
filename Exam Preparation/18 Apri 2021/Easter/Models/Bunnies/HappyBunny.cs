using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int initalHappyBunnyenergy = 100;
        public HappyBunny(string name) : base(name, 100)
        {
        }
    }
}
