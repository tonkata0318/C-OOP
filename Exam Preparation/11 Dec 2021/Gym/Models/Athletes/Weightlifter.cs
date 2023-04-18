using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int initialWeightlifterStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberofMedals) : base(fullName, motivation, numberofMedals,initialWeightlifterStamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;
            if (Stamina>100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
