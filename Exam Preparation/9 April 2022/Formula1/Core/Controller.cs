using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilots;
        private FormulaOneCarRepository cars;
        private RaceRepository races;
        public Controller()
        {
            pilots= new PilotRepository();
            cars= new FormulaOneCarRepository();
            races= new RaceRepository();
        }
        public string CreatePilot(string fullName)
        {
            IPilot pilot=pilots.FindByName(fullName);
            if (pilot!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            pilot = new Pilot(fullName);
            pilots.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);

        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car=cars.FindByName(model);
            if (car!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage,model));
            }
            if (type!=nameof(Ferrari)&&
                type!=nameof(Williams))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if(type==nameof(Ferrari))
            {
                car=new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type==nameof(Williams))
            {
                car=new Williams(model, horsepower, engineDisplacement);
            }
            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race=races.FindByName(raceName);
            if (race!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            race=new Race(raceName, numberOfLaps);
            races.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot=pilots.FindByName(pilotName);
            IFormulaOneCar car=cars.FindByName(carModel);
            if (pilot==null||pilot.Car!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (car==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            cars.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race=races.FindByName(raceName);
            IPilot pilot = pilots.FindByName(pilotFullName);
            if (race==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilot == null || pilot.CanRace == false || race.Pilots.Any(x => x.FullName == pilotFullName)) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string StartRace(string raceName)
        {
            IRace race = races.FindByName(raceName);
            if (race==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace==true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            var riders = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator!=null).ToList();
            
            race.TookPlace = true;
            riders[2].WinRace();
            StringBuilder sb=new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, riders[2].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, riders[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, riders[0].FullName, raceName));
            return sb.ToString().TrimEnd();
        }
        public string PilotReport()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var pilot in pilots.Models.OrderByDescending(x=>x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var race in races.Models.Where(x=>x.TookPlace==true))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
