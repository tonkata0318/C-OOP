using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void TestIfConstructorWorksFIne()
            {
                Garage garage = new Garage("BMW-Garaj", 5);
                Assert.IsNotNull(garage);
                Assert.That(garage.Name, Is.EqualTo("BMW-Garaj"));
                Assert.That(garage.MechanicsAvailable,Is.EqualTo(5));
                Assert.That(garage.CarsInGarage, Is.EqualTo(0));
            }
            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void TestIfGarageNameThrowsExceptionIfWorngValue(string name)
            {
                Garage garage = null;
                Assert.Throws<ArgumentNullException>(() => garage = new Garage(name, 2));
            }
            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            public void TestAvailableMechanicsPropWithWrongValues(int values)
            {
                Garage garage = null;
                Assert.Throws<ArgumentException>(() => garage = new Garage("BMw-Garasj", values));
            }
            [Test]
            public void TestAdCarWithFullGarage()
            {
                Garage garage = new Garage("BMW-Garaj", 2);
                garage.AddCar(new Car("BVM", 2));
                garage.AddCar(new Car("Wdawdwa", 1));
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("Pesho", 2)));
            }
            [Test]
            public void TestAdCarWithNotFullGarage()
            {
                Garage garage = new Garage("BMW-Garaj", 3);
                garage.AddCar(new Car("BVM", 2));
                garage.AddCar(new Car("Wdawdwa", 1));
                garage.AddCar(new Car("Pesho", 2));
                Assert.That(garage.CarsInGarage, Is.EqualTo(3));
            }
            [Test]
            public void TestFixCarWithNotEnteredCar()
            {
                Garage garage = new Garage("BMW-Garaj", 3);
                garage.AddCar(new Car("BVM", 2));
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Honda"));
            }
            [Test]
            public void TestFixCarWithEnteredCar()
            {
                Garage garage = new Garage("BMW-Garaj", 3);
                Car bmw = new Car("BVM", 2);
                garage.AddCar(bmw);
                garage.FixCar("BVM");
                Assert.That(bmw.IsFixed, Is.EqualTo(true));
                Assert.That(bmw.NumberOfIssues, Is.EqualTo(0));
            }
            [Test]
            public void TestRemovedFixedCarWithNoFixedCar()
            {
                Garage garage = new Garage("BMW-Garaj", 3);
                Car bmw = new Car("BVM", 2);
                garage.AddCar(bmw);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }
            [Test]
            public void TestRemovedFixedCarWithOneFixedCar()
            {
                Garage garage = new Garage("BMW-Garaj", 3);
                Car bmw = new Car("BVM", 2);
                garage.AddCar(bmw);
                garage.FixCar("BVM");
                garage.RemoveFixedCar();
                Assert.That(garage.CarsInGarage, Is.EqualTo(0));
            }
            [Test]
            public void TestReportFunctionWorksFine()
            {
                Garage garage = new Garage("BMW-Garaj", 3);
                Car bmw = new Car("BVM", 2);
                garage.AddCar(bmw);
                Assert.AreEqual(garage.Report(), "There are 1 which are not fixed: BVM.");
            }
        }
    }
}