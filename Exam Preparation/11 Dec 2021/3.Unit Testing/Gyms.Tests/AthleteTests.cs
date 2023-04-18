using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class AthleteTests
    {
        [Test]
        public void TestIfConstructorWorksFine()
        {
            Athlete athlete = new Athlete("Pesho");
            Assert.IsNotNull(athlete);
            Assert.That(athlete.FullName, Is.EqualTo("Pesho"));
            Assert.That(athlete.IsInjured, Is.EqualTo(false));
        }
    }
}
