using _00.BankAcount;

namespace BankAccountTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AccountInitializationWithPossitiveValue()
        {
            BankAccount account = new BankAccount(2000m);
            Assert.That(account.Amount, Is.EqualTo(2000m));
        }
    }
}