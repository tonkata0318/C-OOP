using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;
        private const int initialarmorThickness= 300;
        public Battleship(string name, double armorThickness, double mainWeaponCaliber, double speed) : base(name, initialarmorThickness, mainWeaponCaliber, speed)
        {
            SonarMode = false;
        }

        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            if (sonarMode==false)
            {
                sonarMode = true;
                base.MainWeaponCaliber += 40;
                base.Speed -= 5;
            }
            else if (sonarMode==true)
            {
                sonarMode = false;
                base.MainWeaponCaliber -= 40;
                base.Speed +=5;
            }
        }
        public override void RepairVessel()
        {
            if (this.ArmorThickness<300)
            {
                ArmorThickness = initialarmorThickness;
            }
        }
        public override string ToString()
        {
            string yesorNo = string.Empty;
            StringBuilder sb=new StringBuilder();
            sb.AppendLine(base.ToString());
            if (sonarMode==true)
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
