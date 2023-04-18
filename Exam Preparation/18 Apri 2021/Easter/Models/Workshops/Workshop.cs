using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            bool nextdye=false;
            foreach (var dye in bunny.Dyes.Where(x => x.IsFinished() == false))
            {
                while (dye.IsFinished()==false)
                {
                    if (bunny.Energy > 0)
                    {
                        egg.GetColored();
                        dye.Use();
                        bunny.Work();
                    }
                    if (dye.IsFinished())
                    {
                        nextdye = true;
                        break;
                    }
                    if (egg.IsDone() == true || bunny.Energy == 0)
                    {
                        nextdye= true;
                        break;
                    }
                }
                if (nextdye==true)
                {

                    if (egg.IsDone() == true || bunny.Energy == 0)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
