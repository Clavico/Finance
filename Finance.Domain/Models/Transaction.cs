using Finance.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Models
{
    public class Transaction
    {
        public Transaction(int id, string description, decimal value, eType type, DateTime date)
        {
            Id = id;
            Description = description;
            Value = value;
            Type = type;
            Date = date;
        }

        public Transaction(string description, decimal value, eType type, DateTime date)
        {
            Description = description;
            Value = value;
            Type = type;
            Date = date;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public eType Type { get; set; }
        public DateTime Date { get; set; }
    }
}
