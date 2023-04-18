using MIlitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models
{
    public class Engineer : ISoldier, IPrivate, ISpecialisedSoldier, IRepair
    {
        public int ID { get; private set; }
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public decimal Salary { get; private set; }
        public string Corps { get; private set; }
        public string partname { get; private set; }
        public int worKedHours { get; private set; }
        public HashSet<IRepair> Engineers { get; private set; }
        public Engineer(int iD, string firstname, string lastname, decimal salary, string corps, HashSet<IEngineer> engineers)
        {
            ID = iD;
            this.firstname = firstname;
            this.lastname = lastname;
            Salary = salary;
            Corps = corps;
            Engineers= engineers;
        }

        public int id => ID;

        public string firstName => firstname;

        public string lastName => lastname;

        public decimal salary =>Salary;

        public string corps => Corps;

        public string partName => partname;

        public int workedHours => worKedHours;

        public HashSet<IRepair> engineers => Engineers;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {firstName} {lastName} Id: {id} Salary: {salary:f2}");
            sb.AppendLine($"Corps: {corps}");
            foreach (var item in engineers)
            {
                sb.AppendLine($"Part Name: {partname} Hours Worked: {workedHours}");
            }
            return sb.ToString();
        }
    }
}
