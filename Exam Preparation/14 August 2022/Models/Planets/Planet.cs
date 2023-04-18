using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units=new UnitRepository();
            weapons=new WeaponRepository();
        }

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

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower=> Math.Round(this.CalculateMilitalyPower(), 3);

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;
        
        private double CalculateMilitalyPower()
        {
            double totalAmount = 0d;
            if (units.FindByName(nameof(AnonymousImpactUnit))!=null)
            {
                int sumOfEnduranceLevel = units.Models.Sum(x => x.EnduranceLevel);
                int sumofweaponDestrution = weapons.Models.Sum(x => x.DestructionLevel);
                totalAmount = sumOfEnduranceLevel + sumofweaponDestrution;
                return totalAmount += totalAmount * 0.3;
            }
            else if (weapons.FindByName(nameof(NuclearWeapon))!= null)
            {
                int sumOfEnduranceLevel = units.Models.Sum(x => x.EnduranceLevel);
                int sumofweaponDestrution = weapons.Models.Sum(x => x.DestructionLevel);
                totalAmount = sumOfEnduranceLevel + sumofweaponDestrution;
                return totalAmount += totalAmount * 0.45;
            }
            else
            {
                int sumOfEnduranceLevel = units.Models.Sum(x => x.EnduranceLevel);
                int sumofweaponDestrution = weapons.Models.Sum(x => x.DestructionLevel);
                return totalAmount=sumOfEnduranceLevel+sumofweaponDestrution;
            }
        }
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.Append($"--Forces: ");

            if (this.Army.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                var units = new Queue<string>();

                foreach (var item in this.Army)
                {
                    units.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }

            sb.Append($"--Combat equipment: ");

            if (this.Weapons.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var equipment = new Queue<string>();

                foreach (var item in this.Weapons)
                {
                    equipment.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", equipment));
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }
        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnsufficientBudget));
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in Army)
            {
                item.IncreaseEndurance();
            }
        }
    }
}
