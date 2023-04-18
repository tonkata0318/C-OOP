using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            int numberOfDeadKnights = 0;
            int numberOfDeadBarbarians = 0;
            string winner = "";
            List <IHero> knights =new List<IHero>();
            List<IHero> barbarians=new List<IHero>();
            foreach (var hero in players)
            {
                if (hero.GetType().Name==nameof(Knight))
                {
                    knights.Add(hero);
                }
                else if (hero.GetType().Name == nameof(Barbarian))
                {
                    barbarians.Add(hero);
                }
            }
            while (knights.Count>0&&barbarians.Count>0)
            {
                foreach (var knight in knights)
                {
                    for (int i = 0; i < barbarians.Count; i++)
                    {
                        if (knight.Health > 0)
                        {
                            barbarians[i].TakeDamage(knight.Weapon.DoDamage());
                            if (barbarians[i].IsAlive == false)
                            {
                                numberOfDeadBarbarians++;
                                barbarians.Remove(barbarians[i]);
                                i--;
                            }
                        }
                    }
                }
                if (barbarians.Count==0)
                {
                    winner = "knights";
                    break;
                }
                else
                {
                    foreach (var barbarian in barbarians)
                    {
                        for (int i = 0; i < knights.Count; i++)
                        {
                            if (barbarian.Health > 0)
                            {

                                knights[i].TakeDamage(barbarian.Weapon.DoDamage());
                                if (knights[i].IsAlive == false)
                                {
                                    numberOfDeadKnights++;
                                    knights.Remove(knights[i]);
                                    i--;
                                }
                            }
                        }

                    }
                    if (knights.Count==0)
                    {
                        winner = "barbarians";
                        break;
                    }
                }
            }
            if (winner=="barbarians")
            {
                return string.Format(OutputMessages.MapFigthBarbariansWin, numberOfDeadBarbarians);
            }
            else
            {
                return string.Format(OutputMessages.MapFightKnightsWin, numberOfDeadKnights);
            }
        }
    }
}
