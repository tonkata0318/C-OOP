using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username= username;
            RacingBehavior= racingBehavior;
            DrivingExperience= drivingExperience;
            Car = car;
        }
        private string username;

        public string Username
        {
            get { return username; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value;
            }
        }


        private string racingBehavior;

        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior = value;
            }
        }


        private int drivingExperience;

        public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set
            {
                if (value<0||value>100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value;
            }
        }


        private ICar car;

        public ICar Car
        {
            get { return car; }
            private set 
            {
                if (value==null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            }
        }


        public bool IsAvailable()
        {
            if (car.FuelAvailable>car.FuelConsumptionPerRace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Race()
        {
            car.Drive();
            if (this.GetType().Name==nameof(StreetRacer))
            {
                drivingExperience += 5;
            }
            else if (this.GetType().Name == nameof(ProfessionalRacer))
            {
                drivingExperience += 10;
            }
        }
    }
}
