namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Warrior_Name_Cannot_Be_Null()
        {
            Warrior warriot = null;
            Assert.Throws<ArgumentException>(() => warriot = new Warrior(null,5,100));
        }
        [Test]
        public void Warrior_Name_Cannot_Be_Empty()
        {
            Warrior warriot = null;
            Assert.Throws<ArgumentException>(() => warriot = new Warrior(string.Empty, 5, 100));
        }
        [Test]
        public void Warrior_Name_Cannot_Be_WhiteSpace()
        {
            Warrior warriot = null;
            Assert.Throws<ArgumentException>(() => warriot = new Warrior(" ", 5, 100));
        }
        [Test]
        public void Warrior_Damage_Cannot_Be_Zero()
        {
            Warrior warrior = null;
            Assert.Throws < ArgumentException>(() => warrior = new Warrior("Ivan", 0, 100));
        }
        [Test]
        public void Warrior_Damage_Cannot_Be_Negative_Number()
        {
            Warrior warrior = null;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Ivan", -1, 100));
        }
        [Test]
        public void Warrior_Health_Cannot_Be_Negative_Number()
        {
            Warrior warrior = null;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Ivan", 5,-2));
        }
        [Test]
        public void Warrior_Cannot_atack_With_HP_Less_Than_30()
        {
            Warrior warrior = new Warrior("Ivan", 25, 22);
            Warrior warior2 = new Warrior("Pesho", 5, 100);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warior2));
        }
        [Test]
        public void Warrior_Cannot_atack_With_HP_Qual_To_30()
        {
            Warrior warrior = new Warrior("Ivan", 25, 30);
            Warrior warior2 = new Warrior("Pesho", 5, 100);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warior2));
        }
        [Test]
        public void Warrior_Can_Atack_With_Hp_Bigger_Than_30()
        {
            Warrior pesho = new Warrior("Pesho", 10, 35);
            Warrior ivan = new Warrior("Ivan", 10, 35);
            pesho.Attack(ivan);  
            Assert.That(ivan.HP,Is.EqualTo(25));
        }
        [Test]
        public void Warrior_Cant_Atack_Warrior_Whose_Hp_Is_Less_Than_30()
        {
            Warrior pesho = new Warrior("Pesho", 5, 100);
            Warrior ivan = new Warrior("Ivan", 10, 25);
            Assert.Throws<InvalidOperationException>(() => pesho.Attack(ivan));
        }
        [Test]
        public void Warrior_Cant_Atack_Warrior_Whose_Hp_Is_EqualTo_30()
        {
            Warrior pesho = new Warrior("Pesho", 5, 100);
            Warrior ivan = new Warrior("Ivan", 10,30);
            Assert.Throws<InvalidOperationException>(() => pesho.Attack(ivan));
        }
        [Test]
        public void Warrior_Can_Atack_OtherWarior_With_Hp_Bigger_Than_30()
        {
            Warrior pesho = new Warrior("Pesho", 10, 50);
            Warrior ivan = new Warrior("Ivan", 5, 35);
            pesho.Attack(ivan);
            Assert.That(ivan.HP, Is.EqualTo(25));
        }
        [Test]
        public void Warrior_Cant_Atack_If_He_Has_LessHealth_Than_Other_Damage()
        {
            Warrior pesho = new Warrior("Pesho", 5, 35);
            Warrior ivan = new Warrior("Ivan", 36, 100);
            Assert.Throws<InvalidOperationException>(() => pesho.Attack(ivan));
        }
        [Test]
        public void Warrior_Can_Atack_When_He_Has_MoreHealth_Than_Other_Damage()
        {
            Warrior pesho = new Warrior("Pesho", 5, 50);
            Warrior ivan = new Warrior("Ivan", 10, 35);
            pesho.Attack(ivan);
            Assert.That(ivan.HP, Is.EqualTo(30));
        }
        [Test]
        public void AtackShoudKill()
        {
            var atacker = new Warrior("Pesho", 45, 35);
            var defender = new Warrior("Gosho", 15, 35);
            atacker.Attack(defender);
            Assert.AreEqual(20,atacker.HP);
            Assert.AreEqual(0,defender.HP);
        }
        [Test]
        public void Warrior_Test_Constructor_WithValid_Input()
        {
            Warrior goshko = new Warrior("Goshko", 5, 25);
            Assert.That(goshko.HP, Is.EqualTo(25));
        }
    }
}
