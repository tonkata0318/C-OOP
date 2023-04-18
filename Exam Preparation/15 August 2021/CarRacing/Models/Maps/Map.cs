using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable()==false&&racerTwo.IsAvailable()==false)
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            if (racerOne.IsAvailable()==false&&racerTwo.IsAvailable()==true)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);

            }
            if (racerOne.IsAvailable()==true&&racerTwo.IsAvailable()==false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            double racerOneWiningChance = 0;
            double racerOneMultiplyier=0;
            double racerTwoMultiplyier = 0;
            double racerTwoWiningChance = 0;
            if (racerOne.RacingBehavior=="strict")
            {
                racerOneMultiplyier = 1.2;
            }
            else if (racerOne.RacingBehavior== "aggressive")
            {
                racerOneMultiplyier = 1.1;
            }
            if (racerTwo.RacingBehavior=="strict")
            {
                racerTwoMultiplyier = 1.2;
            }
            else if (racerTwo.RacingBehavior== "aggressive")
            {
                racerTwoMultiplyier = 1.1;
            }
            racerOneWiningChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplyier;
            racerTwoWiningChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplyier;
            racerOne.Race();
            racerTwo.Race();
            if (racerOneWiningChance>racerTwoWiningChance)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}
