using StatementBank.Abstractions;
using StatementBank.Models;
using StatementBank.Generators;
using StatementBank.Models.Exceptions;

Customer customer = new Customer(234, "Andrei", "Neamtu");
Customer customer1 = new Customer(41, "Ion", "Dumitru");
Customer customer2 = new Customer(251, "Gabriel", "Grigore");

Account account = new Account(customer);
Account account1 = new Account(customer1);
Account account2 = new Account(customer2);

try
{
    account.MakeWithdrawal(-2, "Cumparare POS");
    account.MakeWithdrawal((decimal)102.32, "Imprimanta");
    account.MakeDeposit((decimal)5.99, "Tablou albastru");
    account.MakeDeposit((decimal)1113.23, "Masina");
    account.MakeWithdrawal((decimal)11.99, "Tastatura");
    account.MakeWithdrawal(39.99M, "Ochelari");
    account.MakeWithdrawal((decimal)55.21, "Monitor");
    account1.MakeDeposit(152.35M, "Periferice");
    account1.MakeWithdrawal((decimal)79.22, "Masina de cafea");
    account2.MakeWithdrawal(231.2M, "Imprimanta");
    account2.MakeWithdrawal((decimal)5.99, "Tablou albastru");
}
catch (InvalidAmountException ex) 
{
    Console.WriteLine(ex.Message);
}
catch(InsufficientFundsException ex)
{
    Console.WriteLine(ex.Message);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

var startDate = new DateTime(2019, 3, 5, 12, 30, 0);
var endDate = new DateTime(2026, 5, 6, 12, 30, 0);

IStatementGenerator statement = new CSVGenerator();
statement.GenerateStatement(account1,startDate,endDate);

Console.ReadLine();