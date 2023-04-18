using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            models= new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models;

        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return Models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            var planetFound = Models.FirstOrDefault(x => x.Name == name);
            if (planetFound != null)
            {
                models.Remove(planetFound);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
