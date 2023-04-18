using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> equipments;
        private ICollection<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value; 
            }
        }


        public int Capacity { get { return this.capacity; } private set { capacity = value; } }

        public double EquipmentWeight => CalculateEquipmentWeight();
        private double CalculateEquipmentWeight()
        {
            double sum = 0d;
            foreach (var equipment in equipments)
            {
                sum+= equipment.Weight;
            }
            return sum;
        }
        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count<capacity)
            {
                athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{name} is a {this.GetType().Name}:");
            sb.Append("Athletes: ");
            if (athletes.Count>0)
            {
                Queue<string> que = new Queue<string>();
                foreach (var athlete in athletes)
                {
                    que.Enqueue(athlete.FullName);
                }
                sb.Append(string.Join(", ", que));
            }
            else
            {
                sb.Append("No athletes");
            }
            sb.AppendLine();
            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            if (athletes.Contains(athlete))
            {
                athletes.Remove(athlete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
