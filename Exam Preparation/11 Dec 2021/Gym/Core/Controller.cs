using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private ICollection<IGym> gyms;
        public Controller()
        {
            equipments= new EquipmentRepository();
            gyms= new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType != nameof(BoxingGym) &&
                gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            if (gymType==nameof(BoxingGym))
            {
                gym=new BoxingGym(gymName);
            }
            else
            {
                gym=new WeightliftingGym(gymName);
            }
            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType!=nameof(BoxingGloves)&&
                equipmentType!=nameof(Kettlebell))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            if (equipmentType==nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment=new Kettlebell();
            }
            equipments.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = equipments.FindByType(equipmentType);
            if (equipment==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,equipmentType));
            }
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            equipments.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            IGym gym=gyms.FirstOrDefault(x=>x.Name ==gymName); 
            if (athleteType!=nameof(Boxer)&&
                athleteType!=nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            if (athleteType==nameof(Boxer))
            {
                athlete=new Boxer(athleteName, motivation, numberOfMedals);
                if (!(gym.GetType().Name == nameof(BoxingGym)))
                {
                    return OutputMessages.InappropriateGym;
                }
                else
                {
                    gym.AddAthlete(athlete);
                    return string.Format(OutputMessages.EntityAddedToGym, athleteType, gym.GetType().Name);
                }
            }
            else
            {
                athlete=new Weightlifter(athleteName,motivation, numberOfMedals);
                if (!(gym.GetType().Name == nameof(WeightliftingGym)))
                {
                    return OutputMessages.InappropriateGym;
                }
                else
                {
                    gym.AddAthlete(athlete);
                    return string.Format(OutputMessages.EntityAddedToGym, athleteType, gym.Name);
                }
            }
        }
        public string TrainAthletes(string gymName)
        {
            IGym gym=gyms.FirstOrDefault(x=> x.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise,gym.Athletes.Count());
        }
        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
