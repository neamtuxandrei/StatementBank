using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementBank.Models.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public decimal Amount { get; private set; }
        public InvalidAmountException(decimal amount) : base($"Invalid amount:{amount}. It must be > 0.")
        {
            Amount = amount;
        }
    }
}
