using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;
        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            vessels= new List<IVessel>();
        }

        public string FullName
        {
            get { return fullName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }


        public int CombatExperience
        {
            get { return combatExperience; }
            private set
            {
                combatExperience=value;
            }
        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel==null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            else
            {
                vessels.Add(vessel);
            }
        }

        public void IncreaseCombatExperience()
        {
            combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{fullName} has {combatExperience} combat experience and commands {vessels.Count} vessels.");
            foreach (var vesel in vessels)
            {
                sb.AppendLine(vesel.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
