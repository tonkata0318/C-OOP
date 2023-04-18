using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int initialBoxerStamina = 60;
        public Boxer(string fullName, string motivation, int numberofMedals) : base(fullName, motivation, numberofMedals,initialBoxerStamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 25;
            if (Stamina>100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
