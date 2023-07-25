namespace StatementBank.Models.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public decimal Balance { get; private set; }
        public InsufficientFundsException(decimal balance) : base($"Insufficient funds. Balance {balance}")
        {
            Balance = balance;
        }
    }
}
