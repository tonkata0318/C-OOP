using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> models;
        public RoomRepository()
        {
            models = new List<IRoom>();
        }
        public List<IRoom> Models { get { return models; } }

        public void AddNew(IRoom model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            IReadOnlyCollection<IRoom> models=Models;
            return models;
        }

        public IRoom Select(string criteria) => this.Models.FirstOrDefault(x => x.GetType().Name == criteria);
    }
}
