using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionlevel;
        private double price;
        public Weapon(int destructionlevel, double price)
        {
            DestructionLevel = destructionlevel;
            this.price = price;
        }

        public double Price => price;

        public int DestructionLevel
        {
            get { return destructionlevel; }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value>10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                else
                {
                    destructionlevel= value;
                }
            }
        }

    }
}
