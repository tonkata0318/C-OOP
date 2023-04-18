using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class Spy : ISoldier, ISpy
    {
        public int ID { get; private set; }
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public int codenumber { get; private set; }
        public Spy(int iD, string firstname, string lastname, int codenumber)
        {
            ID = iD;
            this.firstname = firstname;
            this.lastname = lastname;
            this.codenumber = codenumber;
        }

        public int id => ID;

        public string firstName => firstname;

        public string lastName => lastname;

        public int codeNumber => codenumber;
        public override string ToString()
        {
            return $"Name: {firstName} {lastName} Id: {ID} Code Number: {codeNumber}";

        }
    }
}
