using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private int countColoredEggs;
        public Controller()
        {
            bunnies= new BunnyRepository();
            eggs= new EggRepository();
            countColoredEggs= 0;
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny=null;
            if (bunnyType!=nameof(HappyBunny)
                &&bunnyType!=nameof(SleepyBunny))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidBunnyType));
            }
            if (bunnyType==nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType==nameof(SleepyBunny))
            {
                bunny=new SleepyBunny(bunnyName);
            }
            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded,eggName);
        }

        public string ColorEgg(string eggName)
        {
            BunnyRepository suitableBunnies=new BunnyRepository();
            IEgg egg=eggs.FindByName(eggName);
            IWorkshop workshop = new Workshop();
            foreach (var buny in bunnies.Models)
            {
                if (buny.Energy>=50)
                {
                    suitableBunnies.Add(buny);
                }
            }
            if (suitableBunnies.Models.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            else
            {
                foreach (var bunny in suitableBunnies.Models)
                {
                    workshop.Color(egg,bunny);
                    if (bunny.Energy==0)
                    {
                        bunnies.Remove(bunny);
                    }
                }
            }
            if (egg.IsDone()==true)
            {
                countColoredEggs++;
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(x=>x.IsFinished()==false).ToList().Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
