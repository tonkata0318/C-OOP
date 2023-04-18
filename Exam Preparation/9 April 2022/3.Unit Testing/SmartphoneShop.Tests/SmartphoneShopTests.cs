using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void TestTheConstructor()
        {
            Smartphone smartphone = new Smartphone("Galaxy",5000);
            Assert.IsNotNull(smartphone);
            Assert.That(smartphone.ModelName, Is.EqualTo("Galaxy"));
            Assert.That(smartphone.MaximumBatteryCharge, Is.EqualTo(5000));
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(5000));
        }
    }
}