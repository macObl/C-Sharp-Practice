using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class CheckingAccount : Account
    {
        public double MaxWithDrawAmount = 300.0;

        public CheckingAccount(Customer x, double y) : base(x,y)
        {
            Balance = y;
        }
        public override Transaction Withdarw(Transaction x)
        {
            if(Owner.Status == Enums.CustomerSatus.REGULAR)
            {
                if(x.Amount >= MaxWithDrawAmount)
                {
                    Owner.Result = Enums.TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;
                }
                else
                {
                    Balance -= x.Amount;
                    x.Type = Enums.TransactionType.WITHDDRAW;
                    Transaction transactionWithdraw = new Transaction(x.Amount, x.Type);
                    transactionHistory.Add(transactionWithdraw);
                }
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
        public override Transaction Transfer(Transaction x)
        {
            Owner.Checking.Balance -= x.Amount;
            Owner.Saving.Balance += x.Amount;
            if(Owner.Checking.Balance >= 2000)
            {
                Owner.Status = Enums.CustomerSatus.PREMIER;
            }
            x.Type = Enums.TransactionType.TRANSFER_OUT;
            Transaction transactionTransfer = new Transaction(x.Amount, x.Type);
            transactionHistory.Add(transactionTransfer);
            return x;
        }

    }
}
