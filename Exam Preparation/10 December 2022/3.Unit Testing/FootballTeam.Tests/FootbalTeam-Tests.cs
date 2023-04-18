using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using NUnit;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public  class FootbalTeam_Tests
    {
        [Test]
        public void TestTheConstructorAndPlayersFilledIsNotNull()
        {
            FootballTeam footballTeam = new FootballTeam("Napadateli", 15);
            Assert.IsNotNull(footballTeam);
            Assert.IsNotNull(footballTeam.Players);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestNamePropWithIncorrectINput(string name)
        {
            FootballTeam footballPlayer = null;
            Assert.Throws<ArgumentException>(() => footballPlayer = new FootballTeam(name, 18));
        }
        [Test]
        public void TEstCapaciTyPRopWithIncorrectInput()
        {
            FootballTeam footballTeam = null;
            Assert.Throws<ArgumentException>(() => footballTeam = new FootballTeam("Leopardi", 12));
        }
        [Test]
        public void TestAddNewPlayerWithFullTeam()
        {
            FootballTeam footballTeam = new FootballTeam("Napadateli", 15);
            FootballPlayer footballPlayer2 = new FootballPlayer($"Nishto", 21, "Midfielder");
            for (int i = 1; i <=15; i++)
            {
                FootballPlayer footballPlayer = new FootballPlayer($"{i}", i, "Midfielder");
                footballTeam.AddNewPlayer(footballPlayer);
            }
            string result = footballTeam.AddNewPlayer(footballPlayer2);
            Assert.That(result, Is.EqualTo("No more positions available!"));
        }
        [Test]
        public void TestAddNewPalyerWorksWithCorrecInput()
        {
            FootballTeam footballTeam = new FootballTeam("Napadateli", 15);
            FootballPlayer footballPlayer = new FootballPlayer($"PEsho", 5, "Midfielder");
            string result=footballTeam.AddNewPlayer(footballPlayer);
            Assert.That(footballTeam.Players.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"Added player PEsho in position Midfielder with number 5"));
        }
        [Test]
        public void TestPickPlayerWithCorrectInput()
        {
            FootballTeam footballTeam = new FootballTeam("Napadateli", 15);
            FootballPlayer footballPlayer = new FootballPlayer($"PEsho", 5, "Midfielder");
            footballTeam.AddNewPlayer(footballPlayer);
            FootballPlayer footballPlayer1 = footballTeam.PickPlayer("PEsho");
            Assert.IsNotNull(footballPlayer1);
        }
        [Test]
        public void TestPickPlayerWithInCorrectInput()
        {
            FootballTeam footballTeam = new FootballTeam("Napadateli", 15);
            FootballPlayer footballPlayer = new FootballPlayer($"PEsho", 5, "Midfielder");
            footballTeam.AddNewPlayer(footballPlayer);
            FootballPlayer footballPlayer1 = footballTeam.PickPlayer("Pesho");
            Assert.IsNull(footballPlayer1);
        }
        [Test]
        public void TestPlayerScoreWithCorrectInput()
        {
            FootballTeam footballTeam = new FootballTeam("Napadateli", 15);
            FootballPlayer footballPlayer = new FootballPlayer($"PEsho", 5, "Midfielder");
            footballTeam.AddNewPlayer(footballPlayer);
            string result = footballTeam.PlayerScore(5);
            Assert.That(result, Is.EqualTo($"PEsho scored and now has 1 for this season!"));
        }
        [Test]
        public void TestPlayerScoreWithInCorrectInput()
        {
            FootballTeam footballTeam = new FootballTeam("Napadateli", 15);
            FootballPlayer footballPlayer = new FootballPlayer($"PEsho", 5, "Midfielder");
            footballTeam.AddNewPlayer(footballPlayer);
            Assert.Throws<NullReferenceException>(() => footballTeam.PlayerScore(6));
        }
    }
}
