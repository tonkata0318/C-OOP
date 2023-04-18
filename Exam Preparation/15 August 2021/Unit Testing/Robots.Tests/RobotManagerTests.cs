using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace Robots.Tests
{
    public class RobotManagerTests
    {
        [Test]
        public void TestIfConstructorWorksFine()
        {
            RobotManager robotManager = new RobotManager(2);
            Assert.IsNotNull(robotManager);
            Assert.That(robotManager.Capacity, Is.EqualTo(2));
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestCapacityPropWithNegativeValue()
        {
            RobotManager robotManager = null;
            Assert.Throws<ArgumentException>(() => robotManager = new RobotManager(-1));
        }
        [Test]
        public void TestAddMethodWhenWeAlreadyHaveTheSameRobot()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }
        [Test]
        public void TestAddMehtodWithFullManager()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Zb", 1)));
        }
        [Test]
        public void TestAddMethodWithCuurectData()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestRemoveMethodWhenWeDontHaveOne()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Ivan"));
        }
        [Test]
        public void TestRemoveMehodWithCurrData()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            robotManager.Remove("Ivan");
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestWorkMethodWithRobotWeDontVae()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Ivan", "Pensioner", 50));
        }
        [Test]
        public void TestWorkPropWhenWeDontHaveEnoughBattery()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Ivan", "Chisti", 3));
        }
        [Test]
        public void TestWorkPropWithCorrectData()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            robotManager.Work("Ivan", "Chistu", 1);
            Assert.That(robot.Battery, Is.EqualTo(1));
        }
        [Test]
        public void TestChargePropWhenWeDontHaveOne()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Kris"));
        }
        [Test]
        public void TestChargePropWithCorrectData()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 2);
            robotManager.Add(robot);
            robotManager.Work("Ivan", "Chisti", 1);
            robotManager.Charge("Ivan");
            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }
    }
}
