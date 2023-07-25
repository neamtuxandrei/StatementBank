using StatementBank.Models;
using StatementBank.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementBank.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new();
        public List<Account> GetAccounts()
        {
            SeedData();
            MakeWithdraws(_accounts);
            return _accounts;
        }
        private void SeedData()
        {
            var customer = new Customer(234, "Andrei", "Neamtu");
            var customer1 = new Customer(41, "Ion", "Dumitru");
            var customer2 = new Customer(251, "Gabriel", "Grigore");
            _accounts.Add(new Account(customer));
            _accounts.Add(new Account(customer1));
            _accounts.Add(new Account(customer2));
        }
        private static void MakeWithdraws(List<Account> accounts)
        {
            try
            {
                accounts[0].MakeWithdrawal(2, "Cumparare POS");
                accounts[0].MakeWithdrawal((decimal)102.32, "Imprimanta");
                accounts[0].MakeDeposit((decimal)5.99, "Tablou albastru");
                accounts[0].MakeDeposit((decimal)1113.23, "Masina");
                accounts[0].MakeWithdrawal((decimal)11.99, "Tastatura");
                accounts[0].MakeWithdrawal(39.99M, "Ochelari");
                accounts[0].MakeWithdrawal((decimal)55.21, "Monitor");
                accounts[1].MakeDeposit(152.35M, "Periferice");
                accounts[1].MakeWithdrawal((decimal)79.22, "Masina de cafea");
                accounts[2].MakeWithdrawal(231.2M, "Imprimanta");
                accounts[2].MakeWithdrawal((decimal)5.99, "Tablou albastru");
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
