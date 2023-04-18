﻿using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
		private List<string> items;
		public Planet(string name)
		{
			Name= name;
			items= new List<string>();
		}
        public ICollection<string> Items => items;

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
				}
				name = value;
			}
		}

	}
}
