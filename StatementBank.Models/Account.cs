using StatementBank.Models.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StatementBank.Models
{
    public class Account
    {
        public Customer Customer { get; set; }

        private List<Transaction> _transactions = new List<Transaction>();
        public IReadOnlyCollection<Transaction> Transactions { get => _transactions.AsReadOnly(); }

        public decimal Balance { get; private set; } = 1371.23M;
        public Account(Customer customer)
        {
            Customer = customer;
        }
         public void MakeWithdrawal (decimal amount,string description)
        {
            if(amount <= 0)
            {
                throw new InvalidAmountException(amount);
            }
            if(Balance - amount < 0) 
            {
                throw new InsufficientFundsException(Balance);
            }
            _transactions.Add(new Transaction(description, -amount));
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount} from {Customer.LastName} account. New Balance:{Balance}");
        }
        public void MakeDeposit (decimal amount,string description) 
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException(amount);
            }
            _transactions.Add(new Transaction(description, amount));
            Balance += amount;
            Console.WriteLine($"Deposited {amount} to {Customer.LastName}. New Balance:{Balance}");

        }

        public List<Transaction> GetTransactionsByKey(string key)
        {
            return Transactions.Where(item => item.Description
            .Contains(key, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
