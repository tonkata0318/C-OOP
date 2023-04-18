﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models;
        public HeroRepository()
        {
            models= new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models
        { get { return models; } }

        public void Add(IHero model)
        {
            models.Add(model);
        }

        public IHero FindByName(string name)
        {
           return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
