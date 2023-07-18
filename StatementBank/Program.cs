using StatementBank.Abstractions;
using StatementBank.Models;
using StatementBank.Models.Exceptions;
using StatementBank;

public class Program
{
    private IStatementGenerator? _statementGenerator;
    private List<Account> _accounts = new List<Account>();

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
            program._accounts = GetAccounts();
            program._statementGenerator = compositionBuilder.GetGeneratorOfType(userInput);
            program._statementGenerator.GenerateStatement(program._accounts[0], startDate, endDate);
        }catch(ArgumentException)
        {
            Console.WriteLine($"The user input is not valid. A generator with type {userInput} does not exist.");
        }catch(Exception)
        {
            Console.WriteLine("Unexpected behavior encountered.");
        }

        Console.ReadLine();
    }
    public static List<Account> GetAccounts()
    {
        var accounts = new List<Account>();
        var customer = new Customer(234, "Andrei", "Neamtu");
        var customer1 = new Customer(41, "Ion", "Dumitru");
        var customer2 = new Customer(251, "Gabriel", "Grigore");
        accounts.Add(new Account(customer));
        accounts.Add(new Account(customer1));
        accounts.Add(new Account(customer2));
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
        return accounts;
    }
}



