using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> models;
        public HotelRepository()
        {
            models= new List<IHotel>();
        }
        public List<IHotel> Models => models;
        public void AddNew(IHotel model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            IReadOnlyCollection<IHotel> models = Models;
            return models;
        }

        public IHotel Select(string criteria)
            => this.Models.FirstOrDefault(x => x.FullName == criteria);
    }
}
