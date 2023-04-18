using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class CarTests
    {
        [Test]
        public void Test_ConstructorWorskFineWithNumberOfIssuesBiggerThanZero()
        {
            Car car = new Car("BMW",5);
            Assert.IsNotNull(car);
            Assert.That(car.CarModel, Is.EqualTo("BMW"));
            Assert.That(car.NumberOfIssues, Is.EqualTo(5));
            Assert.That(car.IsFixed, Is.False);
        }
        [Test]
        public void Test_ConstructorWorskFineWithNumberOfIssuesEqualThanZero()
        {
            Car car = new Car("BMW", 0);
            Assert.IsNotNull(car);
            Assert.That(car.CarModel, Is.EqualTo("BMW"));
            Assert.That(car.NumberOfIssues, Is.EqualTo(0));
            Assert.That(car.IsFixed, Is.True);
        }
    }
}
