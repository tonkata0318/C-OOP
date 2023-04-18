namespace RoomTests
{
    using FrontDeskApp;
    using NUnit.Framework;
    public class Tests
    {
        
        [Test]
        public void TestIfConstrtuctorWorksFine()
        {
            Room room = new Room(5, 15);
            Assert.IsNotNull(room);
            Assert.AreEqual(room.PricePerNight, 15);
            Assert.AreEqual(room.BedCapacity, 5);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestBedCapacityWithIncorrectInput(int capacit)
        {
            Room room = null;
            Assert.Throws<ArgumentException>(() => room = new Room(capacit, 15));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestPricePerNightWithIncorrectInput(int priceperNight)
        {
            Room room = null;
            Assert.Throws<ArgumentException>(() => room = new Room(5, priceperNight));
        }
    }
}