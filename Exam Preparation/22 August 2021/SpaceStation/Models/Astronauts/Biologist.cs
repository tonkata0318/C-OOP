using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int initialUnitOFOxygen=70;
        public Biologist(string name) : base(name, 70)
        {
        }
        public override void Breath()
        {
            this.Oxygen -= 5;
        }
    }
}
