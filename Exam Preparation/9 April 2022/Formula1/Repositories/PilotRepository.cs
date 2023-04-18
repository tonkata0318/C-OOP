using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public PilotRepository()
        {
            models= new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => models;

        public void Add(IPilot model)
        {
           models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilot = models.FirstOrDefault(c => c.FullName == name);
            return pilot;
        }

        public bool Remove(IPilot model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
