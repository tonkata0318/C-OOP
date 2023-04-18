using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> models;
        public SupplementRepository()
        {
            models= new List<ISupplement>();
        }
        public void AddNew(ISupplement model)
        {
            models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            var supplement = models.FirstOrDefault(x=>x.InterfaceStandard == interfaceStandard);
            return supplement;
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return models.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            var HasOrNo = models.FirstOrDefault(x => x.GetType().Name == typeName);
            if (HasOrNo==null)
            {
                return false;
            }
            else
            {
                models.Remove(models.FirstOrDefault(x=>x.GetType().Name== typeName));
                return true;
            }
        }
    }
}
