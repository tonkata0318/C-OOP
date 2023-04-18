using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> models;
        public BookingRepository()
        {
            models= new List<IBooking>();
        }
        public List<IBooking> Models => models;
        public void AddNew(IBooking model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            IReadOnlyCollection<IBooking> models = Models;
            return models;
        }

        public IBooking Select(string criteria)
            => this.models.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
    }
}
