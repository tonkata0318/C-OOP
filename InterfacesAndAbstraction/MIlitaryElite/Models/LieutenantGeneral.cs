using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class LieutenantGeneral : ISoldier, IPrivate, ILieutenantGeneral
    {
        public int ID { get; private set; }
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public decimal Salary { get; private set; }
        public HashSet<Private> Privates { get; private set; }
        public LieutenantGeneral(int iD, string firstname, string lastname, decimal salary, HashSet<Private> privates)
        {
            ID = iD;
            this.firstname = firstname;
            this.lastname = lastname;
            Salary = salary;
            Privates = privates;
        }

        public int id => ID;

        public string firstName => firstname;

        public string lastName => lastname;

        public decimal salary => Salary;

        public HashSet<Private> privates => Privates;
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"Name: {firstName} {lastName} Id: {id} Salary: {salary:f2}");
            foreach (var item in Privates)
            {
                sb.AppendLine($"Name: {item.firstName} {item.lastName} Id: {id} Salary: {salary:f2}");
            }
            return sb.ToString();
        }
    }
}
