using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomTests
{
    using FrontDeskApp;
    using NUnit.Framework;
    public  class BookingTest
    {
        [Test]
        public void TestIfConstructoWorksFine()
        {
            Room room = new Room(5, 15);
            Booking booking = new Booking(5, room, 3);
            Assert.IsNotNull(booking);
            Assert.AreEqual(booking.BookingNumber, 5);
            Assert.AreEqual(booking.Room, room);
            Assert.AreEqual(booking.ResidenceDuration, 3);
        }
    }
}
