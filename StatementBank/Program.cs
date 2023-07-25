using StatementBank.Abstractions;
using StatementBank.Models;
using StatementBank.Models.Exceptions;
using StatementBank;
using StatementBank.DataAccess;

public class Program
{
    private IStatementGenerator? _statementGenerator;
    private readonly IAccountRepository _accountRepository = new AccountRepository();
    static void Main(string[] args)
    {
        var startDate = new DateTime(2019, 3, 5, 12, 30, 0);
        var endDate = new DateTime(2026, 5, 6, 12, 30, 0);

        Console.WriteLine("Enter type of generator:");
        var userInput = Console.ReadLine();
        
        var compositionBuilder = new ReportGeneratorsManager();
        Program program = new();
        try
        {

            var accounts = program._accountRepository.GetAccounts();
            program._statementGenerator = compositionBuilder.GetGeneratorOfType(userInput);
            program._statementGenerator.GenerateStatement(accounts[0], startDate, endDate);
        }catch(ArgumentException)
        {
            Console.WriteLine($"The user input is not valid. A generator with type {userInput} does not exist.");
        }catch(Exception)
        {
            Console.WriteLine("Unexpected behavior encountered.");
        }

        Console.ReadLine();
    }
   
   
}



