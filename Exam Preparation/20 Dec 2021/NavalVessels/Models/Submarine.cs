using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        private const int initialSubmarineThickness = 200;

        public Submarine(string name, double armorThickness, double mainWeaponCaliber, double speed) : base(name, initialSubmarineThickness, mainWeaponCaliber, speed)
        {
            submergeMode = false;
        }

        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < initialSubmarineThickness)
            {
                ArmorThickness = initialSubmarineThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (submergeMode == false)
            {
                submergeMode = true;
                base.MainWeaponCaliber += 40;
                base.Speed -= 4;
            }
            else if (submergeMode == true)
            {
                submergeMode = false;
                base.MainWeaponCaliber -= 40;
                base.Speed += 4;
            }
        }
        public override string ToString()
        {
            string yesorNo = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (submergeMode == true)
            {
                yesorNo = "ON";
            }
            else
            {
                yesorNo = "OFF";
            }
            sb.AppendLine($" *Sonar mode: {yesorNo}");
            return sb.ToString().TrimEnd();
        }
    }
}
