using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementBank.Model
{
    public class Transaction
    {
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH}")]
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public Currency Currency { get; set; } = Currency.EUR;
        public Transaction(string description, decimal price,DateTime date)
        {
            Description = description;
            Amount = price;
            Date = date;
        }
        public Transaction(string description, decimal price)
        {
            Description = description;
            Amount = price;
        }

    }
}
