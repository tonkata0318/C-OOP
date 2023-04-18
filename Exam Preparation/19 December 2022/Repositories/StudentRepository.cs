using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;
        public StudentRepository()
        {
            this.models =new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => models;

        public void AddModel(IStudent model)
        {
            this.models.Add(model);
        }

        public IStudent FindById(int id) => models.FirstOrDefault(x => x.Id == id);


        public IStudent FindByName(string name)
        {
            string[] names = name.Split(" ");
            string firstName = names[0];
            string lastName = names[1];
            IStudent student = null;
            foreach (var model in models)
            {
                if (model.FirstName==firstName&&model.LastName==lastName)
                {
                    student= model;
                }
            }
            return student;
        }
    }
}
