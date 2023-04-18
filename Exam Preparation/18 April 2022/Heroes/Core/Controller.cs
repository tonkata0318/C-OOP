using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Heroes.Core
{
    internal class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            heroes= new HeroRepository();
            weapons= new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            string result = "";
            if (heroes.FindByName(name)!=null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist,name));
            }
            if (type!=nameof(Knight)&&
                type!=nameof(Barbarian))
            {
                throw new InvalidOperationException(OutputMessages.HeroTypeIsInvalid);
            }
            IHero hero;
            if (type==nameof(Knight))
            {
                hero=new Knight(name, health, armour);
                heroes.Add(hero);
                result = string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }
            else if (type==nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                result = string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }
            return result;

        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name)!=null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists,name));
            }
            if (type!=nameof(Mace)&&
                type!=nameof(Claymore))
            {
                throw new InvalidOperationException(OutputMessages.WeaponTypeIsInvalid);
            }
            IWeapon weapon=null;
            if (type==nameof(Claymore))
            {
                weapon = new Claymore(name, durability);
            }
            else if (type==nameof(Mace))
            {
                weapon = new Mace(name, durability);
            }
            weapons.Add(weapon);
            return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName)==null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist,heroName));
            }
            if (weapons.FindByName(weaponName)==null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist,weaponName));
            }
            IHero hero=heroes.FindByName(heroName);
            IWeapon weapon=weapons.FindByName(weaponName);
            if (hero.Weapon!=null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }
            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.Name);
        }
        public string StartBattle()
        {
            string result = "";
            IMap map = new Map();
            ICollection<IHero> heroesToFight=heroes.Models.Where(hero => hero.IsAlive&&hero.Weapon!=null).ToList();
            result = map.Fight(heroesToFight);
            return result;
        }
        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            var OrderedHeroes = heroes.Models.OrderBy(hero => hero.GetType().Name).ThenByDescending(h=>h.Health).ThenBy(h=>h.Name);
            foreach (var hero in OrderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon!=null)
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
                else
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
