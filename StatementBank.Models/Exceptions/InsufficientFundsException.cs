using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
