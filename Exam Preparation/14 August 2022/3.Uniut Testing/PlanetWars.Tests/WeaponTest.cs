using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class WeaponTest
    {
        [TestFixture]
        public class WeaponTests
        {
            [Test] 
            public void Test_The_Constrictor()
            {
                Weapon weapon = new Weapon("Ivan", 6.99, 5);
                Assert.IsNotNull(weapon);
                Assert.That(weapon.Name, Is.EqualTo("Ivan"));
                Assert.That(weapon.Price, Is.EqualTo(6.99));
                Assert.That(weapon.DestructionLevel,Is.EqualTo(5));
            }
            [Test]
            public void TestPricePropWithNegativeValue()
            {
                Weapon weapon = null;
                Assert.Throws<ArgumentException>(() => weapon = new Weapon("Ivan", -5, 6));
            }
            [Test]
            public void TestIncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("Ivan", 5, 6);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel, Is.EqualTo(7));
            }
            [Test]
            public void TestIsNuclearWithNuclearDestructiuonLevel()
            {
                Weapon weapon = new Weapon("Ivan", 5, 15);
                Assert.That(weapon.IsNuclear, Is.True);

            }
            [Test]
            public void TestIsNuclearWithoutNuclearDestructiuonLevel()
            {
                Weapon weapon = new Weapon("Ivan", 5, 5);
                Assert.That(weapon.IsNuclear, Is.False);

            }
        }

    }
}
