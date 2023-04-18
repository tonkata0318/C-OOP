using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;
        public RobotRepository()
        {
            models= new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(x=>x.InterfaceStandards.Contains(interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return models.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            var HasOrNo=models.FirstOrDefault(x=>x.Model==typeName);
            if (HasOrNo==null)
            {
                return false;
            }
            else
            {
                models.Remove(models.FirstOrDefault(x=>x.Model==typeName));
                return true;
            }
        }
    }
}
