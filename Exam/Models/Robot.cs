using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model= model;
            BatteryCapacity= batteryCapacity;
            BatteryLevel = batteryCapacity;
            ConvertionCapacityIndex= conversionCapacityIndex;
            interfaceStandards = new List<int>();
        }
        private string model;

        public string Model
        {
            get { return model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                } 
                model = value;
            }
        }


        private int batteryCapacity;

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set 
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                } 
                batteryCapacity = value;
            }
        }


        private int batteryLevel;

        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set { batteryLevel = value; }
        }


        private int convertionCapacityIndex;

        public int ConvertionCapacityIndex
        {
            get { return convertionCapacityIndex; }
            private set { convertionCapacityIndex = value; }
        }
        private List<int> interfaceStandards;

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards;

        public void Eating(int minutes)
        {
            int energy = 0;
            for (int i = 0; i < minutes; i++)
            {
                energy = convertionCapacityIndex * i;
                batteryLevel += energy;
                if (batteryLevel == batteryCapacity)
                {
                    break;
                }
            }  
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (batteryLevel>=consumedEnergy)
            {
                batteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            batteryCapacity -= supplement.BatteryUsage;
            batteryLevel -= supplement.BatteryUsage;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} {model}:");
            sb.AppendLine($"--Maximum battery capacity: {batteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.Append($"--Supplements installed: ");
            if (interfaceStandards.Count>0)
            {
                Queue<int> queq=new Queue<int>();
                foreach (var standard in interfaceStandards)
                {
                    queq.Enqueue(standard);
                }
                sb.Append($"{string.Join(" ",queq)}");
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("none");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
