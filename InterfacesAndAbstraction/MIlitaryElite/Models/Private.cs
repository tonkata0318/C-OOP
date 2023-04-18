using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class Private : ISoldier, IPrivate
    {
        string firstname;
        string lastname;
        int Id;
        decimal Salary;
        public Private(int id,string firstname, string lastname, decimal salary)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            Id = id;
            this.Salary = salary;
        }

        public int id => Id;

        public string firstName => firstname;

        public string lastName => lastname;

        public decimal salary => Salary;
        public override string ToString()
        {
            return $"Name: {firstname} {lastname} Id: {Id} Salary: {salary:f2}";
        }
    }
}
