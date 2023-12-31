﻿using StatementBank.Abstractions;
using StatementBank.Models;
using System.ComponentModel.Composition;
using System.Text;

namespace StatementBank.Generators
{
    [Export(typeof(IStatementGenerator))]
    [ExportMetadata("Type", "csv")]
    public class CSVGenerator : IStatementGenerator
    {
        public void GenerateStatement(Account account, DateTime? startDate = null, DateTime? endDate = null)
        {
            var fileName = account.Customer.LastName.ToString() + "Statement.csv";
            var stringBuilder = new StringBuilder();

            var header = "FirstName,LastName,TransactionDescription,TransactionAmount,TransactionDate";
            stringBuilder.AppendLine(header);

            var transactions = account.Transactions;

            if (startDate != null)
                transactions = transactions.Where(t => t.Date >= startDate).ToList();
            if (endDate != null)
                transactions = transactions.Where(t => t.Date <= endDate).ToList();

            LogToConsole($"\nGenerating {account.Customer.FirstName} {account.Customer.LastName}'s CSV statement...");

            foreach (var transaction in transactions)
            {
                stringBuilder.Append($"{account.Customer.FirstName},{account.Customer.LastName},");
                stringBuilder.Append($"{transaction.Description},{transaction.GetAmountAndCurrency()},{transaction.Date}");
                stringBuilder.AppendLine();
            }

            SaveFile(stringBuilder.ToString(), fileName);
        }

        private void SaveFile(string content, string fileName)
        {
            File.WriteAllText(fileName, content);
            LogToConsole($"CSV file saved: {fileName}\n");
        }

        private void LogToConsole(string info)
        {
            Console.WriteLine($"{info}");
        }


    }
}
