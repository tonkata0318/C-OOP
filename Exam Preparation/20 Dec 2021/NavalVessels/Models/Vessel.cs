using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private ICollection<string> targets;
        private string name;
        public Vessel(string name, double armorThickness, double mainWeaponCaliber,double speed)
        {
            Name = name;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            targets=new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVesselName);
                }
                name = value; 
            }
        }


        private ICaptain captain;

        public ICaptain Captain
        {
            get { return captain; }
            set 
            {
                if (value==null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }

        private double armorThickness;

        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }


        private double mainWeaponCaliber;

        public double MainWeaponCaliber
        {
            get { return  mainWeaponCaliber; }
            protected set {  mainWeaponCaliber = value; }
        }


        private double speed;

        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }


        public ICollection<string> Targets { get { return targets; } private set { targets = value; } }

        public void Attack(IVessel target)
        {
            if (target==null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
                if (target.ArmorThickness<0)
                {
                    target.ArmorThickness = 0;
                }
                targets.Add(target.Name);
            }
        }

        public abstract void RepairVessel();
        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"- {name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {armorThickness}");
            sb.AppendLine($" *Main weapon caliber: {mainWeaponCaliber}");
            sb.AppendLine($" *Speed: {speed} knots");
            sb.Append($" *Targets: ");
            if (targets.Count>0)
            {
                Queue<string > queue = new Queue<string>();
                foreach (var item in targets)
                {
                    queue.Enqueue(item);
                }
                sb.Append($"{string.Join(", ", queue)}");
            }
            else
            {
                sb.Append("None");
            }
            sb.AppendLine();
            return sb.ToString().TrimEnd();
        }
    }
}
