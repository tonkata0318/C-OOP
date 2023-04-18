using NUnit.Framework;
namespace HeroRepository.Tests
{
    public class HeroTests
    {
        [Test]
        public void TestIfConstructorWorksFine()
        {
            Hero hero = new Hero("Georgi", 5);
            Assert.IsNotNull(hero);
            Assert.That(hero.Name, Is.EqualTo("Georgi"));
            Assert.That(hero.Level, Is.EqualTo(5));
        }
    }
}
