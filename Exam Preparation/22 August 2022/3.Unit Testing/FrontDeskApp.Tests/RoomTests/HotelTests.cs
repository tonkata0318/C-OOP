using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomTests
{
    using FrontDeskApp;
    using NUnit.Framework;
    public class HotelTests
    {
        [Test]
        public void TestIfConstructorWorksFine()
        {
            Hotel hotel = new Hotel("Ski beach", 5);
            Assert.IsNotNull(hotel);
            Assert.AreEqual(hotel.FullName,"Ski beach");
            Assert.AreEqual(hotel.Category, 5);
            Assert.IsNotNull(hotel.Rooms);
            Assert.IsNotNull(hotel.Bookings);
            Assert.AreEqual(hotel.Turnover, 0);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void TestFulNamePropWithIncorrectName(string name)
        {
            Hotel hotel = null;
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(name, 5));
        }
        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void TestCategoryWithIncorrectInput(int category)
        {
            Hotel hotel = null;
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("Sunny beach", category));
        }
        [Test]
        public void Test_AddRoomMethod()
        {
            Hotel hotel = new Hotel("Ski beach", 5);
            hotel.AddRoom(new Room(5, 15));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }
        [Test]
        public void Test_Bock_Room_Property_With_Incorrect_Adult()
        {
            Hotel hotel = new Hotel("Ski beach", 5);
            Assert.Throws<ArgumentException>(()=>hotel.BookRoom(0, 2, 3, 500));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 2, 3, 500));
        }
        [Test]
        public void Test_Bock_Room_Property_With_Incorrect_Children()
        {
            Hotel hotel = new Hotel("Ski beach", 5);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -5, 3, 500));
        }
        [Test]
        public void Test_Bock_Room_Property_With_Incorrect_ResidenceDuration()
        {
            Hotel hotel = new Hotel("Ski beach", 5);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 0, 0, 500));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 0, -2, 500));
        }
        [Test]
        public void Test_Bock_Room_With_Correct_Input()
        {
            Hotel hotel = new Hotel("Ski beach", 5);
            hotel.AddRoom(new Room(5, 15));
            hotel.BookRoom(2,0,3,500);
            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Turnover, Is.EqualTo(45));

        }
    }
}
