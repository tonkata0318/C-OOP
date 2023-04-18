using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class Commando : ISoldier, IPrivate, ISpecialisedSoldier, ICommando
    {
        public int ID { get; private set; }
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public decimal Salary { get; private set; }
        public string Corps { get; private set; }
        public HashSet<IMissions> Missions { get; private set; }
        public Commando(int iD, string firstname, string lastname, decimal salary, string corps, HashSet<IMissions> missions)
        {
            ID = iD;
            this.firstname = firstname;
            this.lastname = lastname;
            Salary = salary;
            Corps = corps;
            Missions = missions;
        }

        public int id => ID;

        public string firstName => firstName;

        public string lastName => lastname;

        public decimal salary => Salary;

        public string corps =>Corps;

        public HashSet<IMissions> missions => Missions;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {firstName} {lastName} Id: {id} Salary: {salary:f2}");
            sb.AppendLine($"Corps: {corps}");
            foreach (var item in missions)
            {
                sb.AppendLine($"Code Name: {item.codeName} State: {item.state}");
            }
            return sb.ToString();
        }
    }
}
