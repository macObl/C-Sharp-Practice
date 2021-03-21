using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Transaction
    {
        public double Amount = 0.0;
        public Enums.TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction(double x, Enums.TransactionType y)
        {
            Amount = x;
            Type = y;
            TransactionDate = DateTime.Now;
        }
    }
}
