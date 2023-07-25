namespace StatementBank.Models
{
    public class Transaction
    {
        public string Description { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public decimal Amount { get; private set; }

        private readonly Currency Currency = Currency.EUR;
        public Transaction(string description, decimal price,DateTime date)
        {
            Description = description;
            Amount = price;
            Date = date;
        }
        public Transaction(string description, decimal price)
        {
            Description = description;
            Amount = price;
        }
        public string GetAmountAndCurrency()
        {
            return $"{Amount}{Currency}";
        }

    }
}
