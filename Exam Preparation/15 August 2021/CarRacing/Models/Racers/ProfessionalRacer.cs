using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int drivingExp = 30;
        private const string racingBeh = "strict";
        public ProfessionalRacer(string username, ICar car) : base(username, racingBeh, drivingExp, car)
        {
        }
    }
}
