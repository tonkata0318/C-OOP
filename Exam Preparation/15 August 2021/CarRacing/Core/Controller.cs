﻿using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            cars= new CarRepository();
            racers= new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car=null;
            if (type!=nameof(SuperCar)
                &&type!=nameof(TunedCar))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            if(type==nameof(SuperCar))
            {
                car = new SuperCar(make,model,VIN,horsePower);
            }
            else
            {
                car=new TunedCar(make,model,VIN,horsePower);
            }
            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            IRacer racer = null;
            if (car==null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type!=nameof(ProfessionalRacer)
                &&type!=nameof(StreetRacer))
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            if (type==nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else
            {
                racer = new StreetRacer(username, car);
            }
            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne=racers.FindBy(racerOneUsername);
            IRacer racerTwo=racers.FindBy(racerTwoUsername);
            if (racerOne==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var racer in racers.Models.OrderByDescending(x=>x.DrivingExperience).ThenBy(x=>x.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
