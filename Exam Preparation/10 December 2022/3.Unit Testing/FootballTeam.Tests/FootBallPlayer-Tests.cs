using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {

        [Test]
        public void TestIFConstructorCreateAndScoredGoalsIsZero()
        {
            FootballPlayer footballPlayer = new FootballPlayer("valerian", 7, "Midfielder");
            Assert.IsNotNull(footballPlayer);
            Assert.That(footballPlayer.ScoredGoals, Is.EqualTo(0));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestNamePropWithIncorrectINput(string name)
        {
            FootballPlayer footballPlayer = null;
            Assert.Throws<ArgumentException>(() => footballPlayer = new FootballPlayer(name, 7, "Midfielder"));
        }
        [Test]
        [TestCase(0)]
        [TestCase(22)]
        public void TestPlayerNumberWithIncorrectInput(int number)
        {
        FootballPlayer footballPlayer = null;
        Assert.Throws<ArgumentException>(() => footballPlayer = new FootballPlayer("Pesho", number, "Midfielder"));
        }
        [Test]
        public void TestPlayerPositionWithIncorrectInput()
        {
            FootballPlayer footballPlayer = null;
            Assert.Throws<ArgumentException>(() => footballPlayer = new FootballPlayer("Pesho", 5, "Mid"));
        }
        [Test]
        public void TestScoreMethod()
        {
            FootballPlayer footballPlayer = new FootballPlayer("Pesho", 7, "Midfielder");
            footballPlayer.Score();
            Assert.AreEqual(footballPlayer.ScoredGoals, 1);
        }
    }
}