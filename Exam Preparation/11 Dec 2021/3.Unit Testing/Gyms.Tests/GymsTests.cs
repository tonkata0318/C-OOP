namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    public class GymsTests
    {
        [Test]
        public void TestConstrucotIfWorksFine()
        {
            Gym gym = new Gym("TheBest", 5);
            Assert.IsNotNull(gym);
            Assert.That(gym.Name,Is.EqualTo("TheBest"));
            Assert.That(gym.Capacity, Is.EqualTo(5));
            Assert.That(gym.Count,Is.EqualTo(0));
        }
        [Test]
        [TestCase(null)]
        public void TestNamePropWithInvalid(string name)
        {
            Gym gym = null;
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, 5));
        }
        [Test]
        public void TestCapacityPropWithInvalid()
        {
            Gym gym = null;
            Assert.Throws<ArgumentException>(() => gym = new Gym("Pego", -1));
        }
        [Test]
        public void TestAddAthletesWithFullGym()
        {
            Gym gym = new Gym("Pego", 1);
            Athlete athlete = new Athlete("Gogo");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }
        [Test]
        public void TestAddAthletesWithoutFullGym()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            Assert.That(gym.Count, Is.EqualTo(2));
        }
        [Test]
        public void TestRemoveAthleteWhenWeDontHaveOne()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Gosho"));
        }
        [Test]
        public void TestRemoveAthleteWhenWeHaveOne()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Gogo");
            Assert.That(gym.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestInJureAthleteWithathleteWeDontHave()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Goshko"));
        }
        [Test]
        public void TestInJureAthleteWithathleteWeHave()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            gym.AddAthlete(athlete);
            Athlete injuredAthlete=gym.InjureAthlete("Gogo");
            Assert.That(athlete.IsInjured, Is.EqualTo(true));
            Assert.That(injuredAthlete, Is.EqualTo(athlete));
        }
        [Test]
        public void TestReportWithONeAthlete()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            gym.AddAthlete(athlete);
            string result=gym.Report();
            Assert.AreEqual(result, $"Active athletes at Pego: Gogo");
        }
        [Test]
        public void TestReportWithMoreThanOneAthlete()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            Athlete athlete2 = new Athlete("Kriso");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            string result = gym.Report();
            Assert.AreEqual(result, $"Active athletes at Pego: Gogo, Kriso");
        }
        [Test]
        public void TestReportWithNoAthletes()
        {
            Gym gym = new Gym("Pego", 2);
            Athlete athlete = new Athlete("Gogo");
            string result = gym.Report();
            Assert.AreEqual(result, $"Active athletes at Pego: ");
        }
    }
}
