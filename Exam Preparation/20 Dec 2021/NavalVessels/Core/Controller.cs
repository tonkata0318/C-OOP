using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;
        public Controller()
        {
            vessels= new VesselRepository();
            captains= new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == fullName);
            if (captain != null)
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            else
            {
                captain = new Captain(fullName);
                captains.Add(captain);
                return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = vessels.FindByName(name);
            if (vessel!=null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            if (vesselType!=nameof(Battleship)
                &&vesselType!=nameof(Submarine))
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }
            if (vesselType==nameof(Battleship))
            {
                vessel = new Battleship(name,0, mainWeaponCaliber, speed);
            }
            else if (vesselType==nameof(Submarine))
            {
                vessel=new Submarine(name, 0, mainWeaponCaliber, speed);
            }

            vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);

        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName== selectedCaptainName);
            if (captain==null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            IVessel vessel = vessels.FindByName(selectedVesselName);
            if (vessel==null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain!=null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }
        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }
        public string VesselReport(string vesselName)
        {
            IVessel vessel=vessels.FindByName(vesselName);
            return vessel.ToString();
        }
        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel==null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            if (vessel.GetType().Name==nameof(Battleship))
            {
                IBattleship battleship = new Battleship(vessel.Name, vessel.ArmorThickness, vessel.MainWeaponCaliber, vessel.Speed);
                battleship.ToggleSonarMode();
                vessels.Remove(vessel);
                vessels.Add(battleship);
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, battleship.Name);
            }
            else
            {
                ISubmarine submarine = new Submarine(vessel.Name,vessel.ArmorThickness, vessel.MainWeaponCaliber, vessel.Speed);
                submarine.ToggleSubmergeMode();
                vessels.Remove(vessel);
                vessels.Add(submarine);
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, submarine.Name);
            }

        }
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel=vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            else
            {
                vessel.RepairVessel();
                return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel firstvessel = vessels.FindByName(attackingVesselName);
            IVessel secondvessel = vessels.FindByName(defendingVesselName);
            if (firstvessel==null||secondvessel==null)
            {
                if (firstvessel==null)
                {
                    return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
                }
                else if (secondvessel==null)
                {
                    return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
                }
            }
            if (firstvessel.ArmorThickness==0||secondvessel.ArmorThickness==0)
            {
                if (firstvessel.ArmorThickness==0)
                {
                    return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
                }
                else if (secondvessel.ArmorThickness==0)
                {
                    return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
                }
            }
            firstvessel.Attack(secondvessel);
            firstvessel.Captain.IncreaseCombatExperience();
            secondvessel.Captain.IncreaseCombatExperience();
            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, secondvessel.ArmorThickness);
        }
    }
}
