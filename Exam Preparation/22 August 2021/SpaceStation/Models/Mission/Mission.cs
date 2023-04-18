using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> itemsOnthatPlane= new List<string>();
            foreach (object item in planet.Items)
            {
                itemsOnthatPlane.Add(item.ToString());
            }
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Oxygen>0&&planet.Items.Count!=0)
                {
                    for(int i=0;i<itemsOnthatPlane.Count;i++) 
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(itemsOnthatPlane[i]);
                        planet.Items.Remove(itemsOnthatPlane[i]);
                        itemsOnthatPlane.Remove(itemsOnthatPlane[i]);
                        i--;
                        if (astronaut.Oxygen<=0)
                        {
                            break;
                        }
                    }
                }
                if (planet.Items.Count<=0)
                {
                    break;
                }
            }
            
        }
    }
}
