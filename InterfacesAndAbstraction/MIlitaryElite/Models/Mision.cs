using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class Mision : IMissions
    {
        public string codename { get; private set; }
        public string State { get; private set; }
        public Mision(string codename, string state)
        {
            this.codename = codename;
            State = state;
        }

        public string codeName => codename;

        public string state => State;
    }
}
