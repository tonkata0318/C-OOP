using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int InitialDrivingExp = 10;
        private const string InitialRacingBeg = "aggressive";
        public StreetRacer(string username,ICar car) : base(username, InitialRacingBeg, InitialDrivingExp, car)
        {
        }
    }
}
