namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_The_Constructor_Workds()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            Assert.That(car.Make, Is.EqualTo("BMW"));
        }
        [Test]
        public void Test_The_Empty_Constructor()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
        [Test]
        public void Test_Make_Prop_Is_Not_Null_Or_Empty()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car(null, "M4", 8.5, 50));
        }
        [Test]
        public void Test_Model_Prop_Is_Not_Null_Or_Empty()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", null, 8.5, 50));
        }
        [Test]
        public void Test_FuelConsumption_Prop_WithInvalidInput_0()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "M3", 0, 50));
        }
        [Test]
        public void Test_FuelConsumption_Prop_WithInvalidInput_BelowZero()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "M3", -5, 50));
        }
        [Test]
        public void Test_FuelConsumption_Prop_Is_Not_0()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "M3", 0, 50));
        }
        [Test]
        public void Test_FuelAmount()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
        [Test]
        public void Test_FuelCapacity_WithInvalidInput_0()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "M3", 8.5,0));
        }
        [Test]
        public void Test_FuelCapacity_WithInvalidInput_Below0()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "M3", 8.5, -5));
        }
        [Test]
        public void Test_Refuel_WithInvalidInput_0()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            Assert.Throws<ArgumentException>(()=>car.Refuel(0));
        }
        [Test]
        public void Test_Refuel_WithInvalidInput_Below0()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            Assert.Throws<ArgumentException>(() => car.Refuel(-5));
        }
        [Test]
        public void Test_Refuel_With_Correct_Input()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            car.Refuel(50);
            Assert.AreEqual(car.FuelAmount, 50);
        }
        [Test]
        public void Test_Refuel_With_More_Than_Capacity()
        {
            Car car = new Car("BMW", "M3", 8.5, 45);
            car.Refuel(50);
            Assert.AreEqual(car.FuelAmount, 45);
        }
        [Test]
        public void Test_Drive_Method_With_LowerFuel_Than_Needed()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            Assert.Throws<InvalidOperationException>(() => car.Drive(25));
        }
        [Test]
        public void Test_Drive_With_EnoughFuel()
        {
            Car car = new Car("BMW", "M3", 8.5, 50);
            car.Refuel(50);
            car.Drive(25);
            Assert.That(car.FuelAmount, Is.EqualTo(47.875));
        }
    }
}