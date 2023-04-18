using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [Test]
        public void TestSupplementConstructoWorksFine()
        {
            Supplement supplement = new Supplement("Pesho", 5);
            Assert.IsNotNull(supplement);
            Assert.That(supplement.Name, Is.EqualTo("Pesho"));
            Assert.That(supplement.InterfaceStandard, Is.EqualTo(5));
        }
        [Test]
        public void TestToStringMethod()
        {
            Supplement supplement = new Supplement("Pesho", 5);
            string result=supplement.ToString();
            Assert.That(result, Is.EqualTo($"Supplement: Pesho IS: 5"));
        }
        [Test]
        public void TestIfConstructorOfRobotWorksFine()
        {
            Robot robot = new Robot("Pesho", 2.50, 5);
            Assert.IsNotNull(robot);
            Assert.That(robot.Model, Is.EqualTo("Pesho"));
            Assert.That(robot.InterfaceStandard, Is.EqualTo(5));
            Assert.That(robot.Price, Is.EqualTo(2.5));
            Assert.That(robot.Supplements.Count,Is.EqualTo(0));
        }
        [Test]
        public void TestTheToStringOfRobot()
        {
            Robot robot = new Robot("Pesho", 2.5, 5);
            string result=robot.ToString();
            Assert.That(result, Is.EqualTo($"Robot model: Pesho IS: 5, Price: 2.50"));
        }
        [Test]
        public void TestfactoryConstructoWorksFine()
        {
            Factory factory = new Factory("BMV", 5);
            Assert.IsNotNull(factory);
            Assert.That(factory.Name, Is.EqualTo("BMV"));
            Assert.That(factory.Capacity, Is.EqualTo(5));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestProduceRobotWithFullFactory()
        {
            Factory factory = new Factory("BMV", 1);
            Robot robot = new Robot("Pesho", 2.5, 5);
            factory.ProduceRobot("Pesho", 2.5, 5);
            string result = factory.ProduceRobot("Ivan", 3, 6);
            Assert.That(result, Is.EqualTo("The factory is unable to produce more robots for this production day!"));
        }
        [Test]
        public void TestProduceRobotWithSpaceavailable()
        {
            Factory factory = new Factory("BMV", 1);
            Robot robot = new Robot("Pesho", 2.5, 5);
            string result= factory.ProduceRobot("Pesho", 2.5, 5);
            Assert.That(result, Is.EqualTo($"Produced --> {robot.ToString()}"));
            Assert.That(factory.Robots.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestProduceSupplement()
        {
            Factory factory = new Factory("BMW", 2);
            Supplement supplement = new Supplement("Ivan", 5);
            string result = factory.ProduceSupplement("Ivan", 5);
            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"{supplement.ToString()}"));
        }
        [Test]
        public void TestUpgradeRobotWhenTheRobotAlreadyGotThatSupplement()
        {
            Factory factory = new Factory("BMW", 2);
            Supplement supplement = new Supplement("Ivan", 5);
            Robot robot = new Robot("Peter", 2.5, 5);
            factory.UpgradeRobot(robot, supplement);
            bool vs=factory.UpgradeRobot(robot, supplement);
            Assert.That(vs, Is.EqualTo(false));
        }
        [Test]
        public void TestUpgradeRobotWhenInterfaceStandartsAreBothRaxlichin()
        {
            Factory factory = new Factory("BMW", 2);
            Supplement supplement = new Supplement("Ivan", 3);
            Robot robot = new Robot("Peter", 2.5, 5);
            Robot robot2 = new Robot("Gosho", 2.5, 6);
            factory.UpgradeRobot(robot, supplement);
            bool vs = factory.UpgradeRobot(robot2, supplement);
            Assert.That(vs, Is.EqualTo(false));
        }
        [Test]
        public void TestUpgradeRobotWithBothIncorrect()
        {
            Factory factory = new Factory("BMW", 2);
            Supplement supplement = new Supplement("Ivan", 3);
            Robot robot = new Robot("Peter", 2.5, 5);
            robot.Supplements.Add(supplement);
            bool vs=factory.UpgradeRobot(robot, supplement);
            Assert.That(vs,Is.EqualTo(false));
        }
        [Test]
        public void TestUpgradeRobotWithValidData()
        {
            Factory factory = new Factory("BMW", 2);
            Supplement supplement = new Supplement("Ivan", 5);
            Robot robot = new Robot("Peter", 2.5, 5);
            bool vs = factory.UpgradeRobot(robot, supplement);
            Assert.That(vs, Is.EqualTo(true));
            Assert.That(robot.Supplements.Count,Is.EqualTo(1));
        }
        [Test]
        public void TestSellRobotReturnsTheCorrectThing()
        {
            Factory factory = new Factory("BMW", 2);
            Supplement supplement = new Supplement("Ivan", 5);
            Robot robot = new Robot("Peter", 2.5, 5);
            factory.ProduceRobot("Peter", 2.5, 5);
            Robot selledRobot = factory.SellRobot(2.5);
            Assert.AreEqual(robot.ToString(), selledRobot.ToString());
            Assert.That(factory.Robots.Count, Is.EqualTo(1));
        }
    }
}