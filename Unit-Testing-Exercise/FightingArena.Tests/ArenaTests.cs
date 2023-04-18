namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.ComponentModel;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Test_Constructor()
        {
            Arena arena = new Arena();
            Assert.That(arena.Warriors, Is.Not.Null);
        }
        [Test]
        public void Test_Enrolle_With_Invalid_Input()
        {
            Arena arena = new Arena();
            Warrior pessho = new Warrior("Pesho", 5, 50);
            arena.Enroll(pessho);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(pessho));
        }
        [Test]
        public void Test_Enrole_With_Valid_Input()
        {
            Arena arena = new Arena();
            Warrior warrio = new Warrior("Pesho", 5, 50);
            arena.Enroll(warrio);
            Assert.AreEqual(arena.Warriors.Count, 1);
        }
        [Test]
        public void Test_Fight_With_NotEnrolled_Atacker()
        {
            Arena arena = new Arena();
            Warrior atacker = new Warrior("Ivan", 5, 50);
            Warrior defender=new Warrior("Dimitrichko",10,50);
            arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(atacker.Name, defender.Name));
        }
        [Test]
        public void Test_Fight_With_NotEnrolled_Defender()
        {
            Arena arena = new Arena();
            Warrior atacker = new Warrior("Ivan", 5, 50);
            Warrior defender = new Warrior("Dimitrichko", 10, 50);
            arena.Enroll(atacker);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(atacker.Name, defender.Name));
        }
        [Test]
        public void Test_Fight_With_Enrolled_Both_Fighters()
        {
            Arena arena = new Arena();
            Warrior atacker = new Warrior("Ivan", 5, 50);
            Warrior defender = new Warrior("Dimitrichko", 10, 50);
            arena.Enroll(atacker);
            arena.Enroll(defender);
            arena.Fight(atacker.Name,defender.Name);
            Assert.That(defender.HP, Is.EqualTo(45));
        }
    }
}
