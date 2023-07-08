using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StatementBank.Model
{
    public class Account
    {
        public Customer Customer { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public Account(Customer customer)
        {
            Customer = customer;
        }
    }
}
