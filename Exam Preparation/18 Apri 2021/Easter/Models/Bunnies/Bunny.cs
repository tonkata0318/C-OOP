using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        public Bunny(string name,int energy)
        {
            Name= name;
            Energy= energy;
            dyes=new List<IDye>();
        }
        private string name;
        private List<IDye> dyes;
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }


        private int energy;

        public int Energy
        {
            get { return energy; }
            private set 
            {
                if (value<0)
                {
                    energy = 0;
                }
                energy = value;
            }
        }


        public ICollection<IDye> Dyes => dyes;

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public void Work()
        {
            this.energy -= 10;
            if (energy<0)
            {
                energy = 0;
            }
        }
    }
}
