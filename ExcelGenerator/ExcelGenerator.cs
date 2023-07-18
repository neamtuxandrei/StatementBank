using ClosedXML.Excel;
using StatementBank.Abstractions;
using StatementBank.Models;
using System.ComponentModel.Composition;

namespace StatementBank.Generators
{
    [Export(typeof(IStatementGenerator))]
    [ExportMetadata("Type", "excel")]
    public class ExcelGenerator : IStatementGenerator
    {
        public void GenerateStatement(Account account, DateTime? startDate = null, DateTime? endDate = null)
        {
            var fileName = account.Customer.LastName.ToString() + "Statement";

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Statement");
                worksheet.Cell(1, 1).Value = "FirstName";
                worksheet.Cell(1, 2).Value = "LastName";
                worksheet.Cell(1, 3).Value = "TransactionDescription";
                worksheet.Cell(1, 4).Value = "TransactionAmount";
                worksheet.Cell(1, 5).Value = "TransactionDate";

                var transactions = account.Transactions.ToList();

                if (startDate != null)
                    transactions = transactions.Where(t => t.Date >= startDate).ToList();
                if (endDate != null)
                    transactions = transactions.Where(t => t.Date <= endDate).ToList();

                LogToConsole($"\nGenerating {account.Customer.FirstName} {account.Customer.LastName}'s statement...");

                for (int i = 0; i < transactions.Count; i++)
                {
                    var transaction = transactions[i];
                    worksheet.Cell(i + 2, 1).Value = account.Customer.FirstName;
                    worksheet.Cell(i + 2, 2).Value = account.Customer.LastName;
                    worksheet.Cell(i + 2, 3).Value = transaction.Description;
                    worksheet.Cell(i + 2, 4).Value = transaction.GetAmountAndCurrency();
                    worksheet.Cell(i + 2, 5).Value = transaction.Date;
                }

                SaveFile(workbook, fileName);
            }
        }

        private void SaveFile(XLWorkbook workbook, string fileName)
        {
            fileName += ".xlsx";
            workbook.SaveAs(fileName);
            LogToConsole($"Excel file saved: {fileName}\n");
        }

        private void LogToConsole(string info)
        {
            Console.WriteLine($"{info}");
        }
    }

}
