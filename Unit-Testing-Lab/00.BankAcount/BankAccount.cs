namespace _00.BankAcount
{
    public class BankAccount
    {
        private decimal amount;
        public BankAccount(decimal amount)
        {
            this.amount = amount;
        }
        public decimal Amount { get { return amount; } }
    }
}
