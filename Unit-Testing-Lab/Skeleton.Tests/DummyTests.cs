using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthIfAtacked()
        {
            //Arrange
            Axe axe = new Axe(1, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(axe.AttackPoints);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(9),"Dummy doesn't lose health to atack.");
        }
        [Test]
        public void DeadDummyThrowsException()
        {
            //Arrange
            Axe axe = new Axe(1, 10);
            Dummy dummy = new Dummy(0, 10);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(()=>dummy.TakeAttack(axe.AttackPoints));
        }
        [Test]
        public void DeadDummyCanGiveExp()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 10);

            //Act
            //Assert
            Assert.That(dummy.GiveExperience(), Is.EqualTo(10), "Dummy is not dead");
        }
        [Test]
        public void AliveDummyDoesNotGiveExp() 
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(2, 10);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(()=>dummy.GiveExperience());
        }
    }
}