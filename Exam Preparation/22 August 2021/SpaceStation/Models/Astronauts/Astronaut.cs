using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        public Astronaut(string name,double oxygen)
        {
            Name= name;
            Oxygen= oxygen;
            CanBreath= true;
            Bag = new Backpack();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }


        private double oxygen;

        public double Oxygen
        {
            get { return oxygen; }
            protected set 
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }


        private bool canBreath;

        public bool CanBreath
        {
            get { return canBreath; }
            private set 
            {
                if (oxygen>0)
                {
                    canBreath = true;
                }
                else
                {
                    canBreath= false;
                }
            }
        }


        private IBag bag;

        public IBag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }


        public virtual void Breath()
        {
            oxygen -= 10;
            if (canBreath==false)
            {
                oxygen = 0;
            }
        }
    }
}
