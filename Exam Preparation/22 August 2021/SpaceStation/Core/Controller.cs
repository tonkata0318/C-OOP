using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanets = 0;
        public Controller()
        {
            astronauts= new AstronautRepository();
            planets= new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type!=nameof(Biologist)
                &&type!=nameof(Geodesist)
                &&type!=nameof(Meteorologist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            if (type==nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if(type==nameof(Geodesist)) 
            {
                astronaut=new Geodesist(astronautName);
            }
            else
            {
                astronaut=new Meteorologist(astronautName);
            }
            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }
            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded,planetName);
        }
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if (astronaut==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            else
            {
                astronauts.Remove(astronaut);
                return string.Format(OutputMessages.AstronautRetired, astronautName);
            }
        }
        public string ExplorePlanet(string planetName)
        {
            ICollection<IAstronaut> suitableAstronaut=new List<IAstronaut>();
            IPlanet planet=planets.FindByName(planetName);
            IMission mission = new Mission();
            foreach (var astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen>60)
                {
                    suitableAstronaut.Add(astronaut);
                }
            }
            if (suitableAstronaut.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            mission.Explore(planet, suitableAstronaut);
            exploredPlanets++;
            int deadAstronauts = 0;
            foreach (var item in suitableAstronaut)
            {
                if (item.Oxygen<=0)
                {
                    deadAstronauts++;
                }
            }
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append("Bag items: ");
                if (astronaut.Bag.Items.Count==0)
                {
                    sb.Append("none");
                }
                else
                {
                    Queue<string> q= new Queue<string>();
                    foreach (var item in astronaut.Bag.Items)
                    {
                        q.Enqueue(item);
                    }
                    sb.Append($"{string.Join(", ", q)}");
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
