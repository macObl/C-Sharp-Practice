using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
     public class Account 
    {
        public Customer Owner { get; }
        public double Balance { get; set; }

        public List<Transaction> transactionHistory = new List<Transaction>();

        public Account(Customer x, double y) 
        {
            Owner = x;
            Balance = y;
        }
        public virtual Transaction Deposit(Transaction x)
        {
            Balance += x.Amount;
            if(x.Amount > Owner.Checking.Balance || x.Amount > Owner.Saving.Balance)
            {
                Owner.Status = Enums.CustomerSatus.PREMIER;
            }
            x.Type = Enums.TransactionType.DEPOSIT;
            Transaction transactionDeposit = new Transaction(x.Amount, x.Type);
            transactionHistory.Add(transactionDeposit);
            return x;
        }
        public virtual Transaction Withdarw(Transaction x)
        {
            if (x.Amount >= Balance)
            {
                Owner.Result = Enums.TransactionResult.INSUFFICIENT_FUND;
            }
            else
            {
                Balance -= x.Amount;
                x.Type = Enums.TransactionType.WITHDDRAW;
                Transaction transactionWithdraw = new Transaction(x.Amount, x.Type);
                transactionHistory.Add(transactionWithdraw);
            }
            return x;
        }
        public virtual Transaction Transfer(Transaction x)
        {
            Balance += x.Amount;
            x.Type = Enums.TransactionType.TRANSFER_IN;
            Transaction transactionTransfer = new Transaction(x.Amount, x.Type);
            transactionHistory.Add(transactionTransfer);
            return x;
        }
    }
}
