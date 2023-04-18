using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        public BioChemicalWeapon(int destructionlevel) : base(destructionlevel,3.2)
        {
        }
    }
}
