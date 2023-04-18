using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        public Controller()
        {
            supplements= new SupplementRepository();
            robots= new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            IRobot robot=null;
            if (typeName!=nameof(DomesticAssistant)&&
                typeName!=nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            if (typeName==nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName==nameof(IndustrialAssistant))
            {
                robot=new IndustrialAssistant(model);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName,model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement=null;
            if (typeName!=nameof(SpecializedArm)&&
                typeName!=nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            if (typeName==nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName==nameof(LaserRadar))
            {
                supplement= new LaserRadar();
            }
            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            RobotRepository robotsWhoSupTheInterface = new RobotRepository();
            foreach (var robot in robots.Models())
            {
                if (robot.InterfaceStandards.Contains(intefaceStandard))
                {
                    robotsWhoSupTheInterface.AddNew(robot);
                }
            }
            if (robotsWhoSupTheInterface.Models().Count==0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            else
            {
                var robotRepository = robotsWhoSupTheInterface.Models().OrderByDescending(x => x.BatteryLevel);
                int sum = 0;
                foreach (var robot in robotRepository)
                {
                    sum += robot.BatteryLevel;
                }
                if (sum<totalPowerNeeded)
                {
                    return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);
                }
                else
                {
                    int counter = 0;
                    foreach (var robot in robotRepository)
                    {
                        if (robot.BatteryLevel>=totalPowerNeeded)
                        {
                            robot.ExecuteService(totalPowerNeeded);
                            counter++;
                            break;
                        }
                        else
                        {
                            totalPowerNeeded-= robot.BatteryLevel;
                            robot.ExecuteService(robot.BatteryLevel);
                            counter++;
                            if (totalPowerNeeded==0)
                            {
                                break;
                            }
                        }
                    }
                    return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
                }
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var robot in robots.Models().OrderByDescending(x=>x.BatteryLevel).ThenBy(x=>x.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            int fedCount = 0;
            RobotRepository robotRepository = new RobotRepository();
            foreach (var robot in robots.Models())
            {
                if (robot.Model==model&&robot.BatteryLevel<=robot.BatteryCapacity/2)
                {
                    robotRepository.AddNew(robot);
                }
            }
            foreach (var robot in robotRepository.Models())
            {
                robot.Eating(minutes);
                fedCount++;
            }
            return string.Format(OutputMessages.RobotsFed, fedCount);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            IReadOnlyCollection<ISupplement> suplements=supplements.Models();
            ISupplement supplement = suplements.FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            int suplementValue = supplement.InterfaceStandard;
            IReadOnlyCollection<IRobot> robotsWeWillSearchIn = robots.Models();
            RobotRepository robotsWhoDontContainsSupValue = new RobotRepository();
            foreach (var robot in robotsWeWillSearchIn)
            {
                if (!(robot.InterfaceStandards.Contains(suplementValue))&&robot.Model==model)
                {
                    robotsWhoDontContainsSupValue.AddNew(robot);
                }
            }
            if (robotsWhoDontContainsSupValue.Models().Count==0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            else
            {
                IRobot robot = robotsWhoDontContainsSupValue.Models().First();
                robot.InstallSupplement(supplement);
                supplements.RemoveByName(supplementTypeName);
                return string.Format(OutputMessages.UpgradeSuccessful,model,supplementTypeName);
            }
        }
    }
}
