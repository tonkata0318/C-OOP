using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    public class ShopTests
    {
        [Test]
        public void TestTheConstructor()
        {
            Shop shop = new Shop(5);
            Assert.IsNotNull(shop);
            Assert.That(shop.Capacity, Is.EqualTo(5));
            Assert.That(shop.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestCapacityPropWithNegativeValue()
        {
            Shop shop = null;
            Assert.Throws<ArgumentException>(() => shop = new Shop(-5));
        }
        [Test]
        public void TestAddWithExistingPhoe()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }
        [Test]
        public void TestAddWhenShopIsFull()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("M2",2000)));
        }
        [Test]
        public void TestAddOperationWithNormalValues()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            Assert.That(shop.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestRemoveOperatorWithUnexistingPhone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Gosho"));
        }
        [Test]
        public void TestRemoveOperationWithExistringPhone()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            shop.Remove("Galaxy");
            Assert.That(shop.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestTestPhoneWithUnexistingPhone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Gosho",200));
        }
        [Test]
        public void TestTestPhoneWhenCurrPhoneHaveLowerBatteryThanTheOneWeWhantToUse()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Galaxy", 1000));
        }
        [Test]
        public void TestTestPhoneWorksFine()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            shop.TestPhone("Galaxy", 200);
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(300));
        }
        [Test]
        public void TestChargePhoneWithUnexistingPhone()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Gosho"));
        }
        [Test]
        public void TestChargePhoneWithExistingPhone()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Galaxy", 500);
            shop.Add(smartphone);
            shop.TestPhone("Galaxy", 200);
            shop.ChargePhone("Galaxy");
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(500));
        }
    }
}
