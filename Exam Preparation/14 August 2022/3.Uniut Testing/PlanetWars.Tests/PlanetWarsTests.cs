using NUnit.Framework;
using System;
using System.Diagnostics.Contracts;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void TestPlanetConstructor()
            {
                Planet planet = new Planet("Palma", 500);
                Assert.IsNotNull(planet);
                Assert.That(planet.Name, Is.EqualTo("Palma"));
                Assert.That(planet.Budget,Is.EqualTo(500));
                Assert.IsNotNull(planet.Weapons);
            }
            [Test]
            [TestCase("")]
            [TestCase(null)]
            public void TestNameWithInvalidInput(string name)
            {
                Planet planet = null;
                Assert.Throws<ArgumentException>(() => planet = new Planet(name, 500));
            }
            [Test]
            public void TestBudgetWithInvalidInput()
            {
                Planet planet = null;
                Assert.Throws<ArgumentException>(() => planet = new Planet("Palma", -5));
            }
            [Test]
            public void TestProfitMethod()
            {
                Planet planet = new Planet("Palma", 5);
                planet.Profit(5);
                Assert.That(planet.Budget, Is.EqualTo(10));
            }
            [Test]
            public void TestSpendFunWithAmountBiggerThanTHeBydget()
            {
                Planet planet = new Planet("Palma", 5);
                Assert.Throws<InvalidOperationException>(()=>planet.SpendFunds(10));

            }
            [Test]
            public void TestSpendFunWithAmountLowerThanTHeBydget()
            {
                Planet planet = new Planet("Palma", 5);
                planet.SpendFunds(2);
                Assert.That(planet.Budget, Is.EqualTo(3));
            }
            [Test]
            public void TestAddWeaponWithWeaponWeAlreadyHave()
            {
                Planet planet = new Planet("Palma", 5);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(new Weapon("Gosho", 5, 10)));
            }
            [Test]
            public void TestAddWeaponWithWeaponWeDontHave()
            {
                Planet planet = new Planet("Palma", 5);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                planet.AddWeapon(new Weapon("Stilkop", 12, 3));
                Assert.That(planet.Weapons.Count,Is.EqualTo(2));
            }
            [Test]
            public void TestTheRemoveMethod()
            {
                Planet planet = new Planet("Palma", 5);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                planet.AddWeapon(new Weapon("Stilkop", 12, 3));
                planet.RemoveWeapon("Gosho");
                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
            }
            [Test]
            public void TestTryToUpgrageWeaponWeDontHave()
            {
                Planet planet = new Planet("Palma", 5);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                planet.AddWeapon(new Weapon("Stilkop", 12, 3));
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Toni"));
            }
            [Test]
            public void TestTryToUpgrageWeaponWeHave()
            {
                Planet planet = new Planet("Palma", 5);
                Weapon weapon = new Weapon("Stilkop", 12, 3);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Stilkop");
                Assert.That(weapon.DestructionLevel, Is.EqualTo(4));
            }
            [Test]
            public void TestMilitaryPowerRatioWorksGood()
            {
                Planet planet = new Planet("Palma", 5);
                Weapon weapon = new Weapon("Stilkop", 12, 3);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                planet.AddWeapon(weapon);
                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(13));
            }
            [Test]
            public void TestDestructionOponentWhenHeHaveMorePowerThanUs()
            {
                Planet planet = new Planet("Palma", 5);
                Weapon weapon = new Weapon("Stilkop", 12, 3);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                planet.AddWeapon(weapon);
                Planet planet2 = new Planet("Palma", 5);
                Weapon weapon2= new Weapon("Stilkop", 12, 5);
                planet2.AddWeapon(new Weapon("Gosho", 5, 10));
                planet2.AddWeapon(weapon2);
                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet2));
            }
            [Test]
            public void TestDestructionOponentWhenWeHaveMorePowerThanUs()
            {
                Planet planet = new Planet("Palma", 5);
                Weapon weapon = new Weapon("Stilkop", 12, 3);
                planet.AddWeapon(new Weapon("Gosho", 5, 10));
                planet.AddWeapon(weapon);
                Planet planet2 = new Planet("Palma", 5);
                Weapon weapon2 = new Weapon("Stilkop", 12, 2);
                planet2.AddWeapon(new Weapon("Gosho", 5, 10));
                planet2.AddWeapon(weapon2);
                string result = planet.DestructOpponent(planet2);
                Assert.That(result, Is.EqualTo($"{planet2.Name} is destructed!"));
            }
        }
    }
}
