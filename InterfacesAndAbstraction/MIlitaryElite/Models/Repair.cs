using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class Repair : IRepair
    {
        public string partname { get; private set; }
        public int workedhours { get; private set; }
        
        public string partName => partname;

        public int workedHours => workedhours;
    }
}
