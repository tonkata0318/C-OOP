using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class SpecialisedSoldier : ISpecialisedSoldier, ISoldier,IPrivate
    {
        public int ID { get; private set; }
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public decimal Salary { get; private set; }
        public string Corps
        {
            get
            {
                return this.Corps;
            }
            private set
            {
                if (value!="Airforces"&&value!="Marines")
                {
                    throw new ArgumentException();
                }
                Corps= value;
            }
        }

        public SpecialisedSoldier(int iD, string firstname, string lastname, decimal salary,string corps)
        {
            ID = iD;
            this.firstname = firstname;
            this.lastname = lastname;
            this.Corps = corps;
            Salary = salary;
        }

        public string corps => Corps;

        public int id => ID;

        public string firstName => firstname;

        public string lastName => lastname;

        public decimal salary => Salary;
    }
}
