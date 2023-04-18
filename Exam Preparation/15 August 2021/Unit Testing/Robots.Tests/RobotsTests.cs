namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    public class RobotsTests
    {
        [Test]
        public void TestIfConstructorWorksFine()
        {
            Robot robot = new Robot("Toni", 50);
            Assert.IsNotNull(robot);
            Assert.That(robot.Name, Is.EqualTo("Toni"));
            Assert.That(robot.MaximumBattery, Is.EqualTo(50));
        }
    }
}
