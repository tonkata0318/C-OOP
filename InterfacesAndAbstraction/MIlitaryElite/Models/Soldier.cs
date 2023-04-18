using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class Soldier : ISoldier
    {
        private int ID;
        private string firstname;
        private string lastname;
        public Soldier(int id,string firstName,string lastName)
        {
            ID= id;
            this.firstname = firstName;
            this.lastname = lastName;
        }
        public int id => ID;

        public string firstName => firstname;

        public string lastName => lastname;
    }
}
