using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        public SpaceMissiles(int destructionlevel) : base(destructionlevel, 8.75)
        {
        }
    }
}
