using StatementBank.DataAccess;
using StatementBank.Model;
using StatementBank.Service;

IAccountRepository repository = new AccountRepository();
IStatementGenerator statement = new CSVGenerator();

List<Account> accounts = repository.GetAccounts();

var startDate = new DateTime(2019, 3, 5, 12, 30, 0);
var endDate = new DateTime(2026, 5, 6, 12, 30, 0);

for (int i = 0; i < accounts.Count; i++)
    statement.GenerateStatement(accounts[i],startDate,endDate);


Console.ReadLine();