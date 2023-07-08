using StatementBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementBank.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts;
        
        public AccountRepository()
        {
            _accounts = new List<Account>();
            SeedData();
        }
        public List<Account> GetAccounts()
        {
            return _accounts;
        }
        private void SeedData()
        {
            Customer customer = new Customer(234, "Andrei", "Neamtu");
            Customer customer1 = new Customer(41, "Ion", "Dumitru");
            Customer customer2 = new Customer(251, "Gabriel", "Grigore");

            Account account = new Account(customer);
            Account account1 = new Account(customer1);
            Account account2 = new Account(customer2);

            account.Transactions.Add(new Transaction("Cumparare POS", (decimal)26.53, new DateTime(2023, 4, 4, 12, 30, 0)));
            account.Transactions.Add(new Transaction("Imprimanta", (decimal)102.32, new DateTime(2023, 7, 7, 12, 30, 0)));
            account.Transactions.Add(new Transaction("Tablou albastru", (decimal)5.99, new DateTime(2023, 5, 5, 10, 30, 0)));
            account.Transactions.Add(new Transaction("Masina", (decimal)1113.23, new DateTime(2023, 9, 9, 10, 30, 0)));
            account.Transactions.Add(new Transaction("Tastatura", (decimal)11.99, new DateTime(2022, 12, 5, 13, 28, 21)));
            account.Transactions.Add(new Transaction("Ochelari", (decimal)39.99, new DateTime(2021, 2, 6, 18, 0, 0)));
            account.Transactions.Add(new Transaction("Monitor", (decimal)55.21, new DateTime(2025, 11, 26, 11, 16, 0)));



            account1.Transactions.Add(new Transaction("Periferice", (decimal)152.35));
            account1.Transactions.Add(new Transaction("Masina de cafea", (decimal)79.22));


            account2.Transactions.Add(new Transaction("Imprimanta", (decimal)102.32));
            account2.Transactions.Add(new Transaction("Tablou albastru", (decimal)5.99));

            _accounts.Add(account);
            _accounts.Add(account1);
            _accounts.Add(account2);
        }
    }
}
