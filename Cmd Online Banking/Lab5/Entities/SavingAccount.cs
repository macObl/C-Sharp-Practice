using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class SavingAccount : Account
    {
        public  double PrimierAmount = 2000.0;
        public double WithdrawPenalyAmount = 10.0;

        public SavingAccount(Customer x, double y) : base(x,y)
        {
            Balance = y;
        }
        public override Transaction Deposit(Transaction x)
        {
            if (Owner.Status == Enums.CustomerSatus.REGULAR)
            {
                Balance += x.Amount;
                if(Balance >= PrimierAmount)
                {
                    Owner.Status = Enums.CustomerSatus.PREMIER;
                }
                x.Type = Enums.TransactionType.DEPOSIT;
                Transaction transactionDeposit = new Transaction(x.Amount, x.Type);
                transactionHistory.Add(transactionDeposit);
            }
            else
            {
                Balance += x.Amount;
                x.Type = Enums.TransactionType.DEPOSIT;
                Transaction transactionDeposit = new Transaction(x.Amount, x.Type);
                transactionHistory.Add(transactionDeposit);
            }
            return x;
        }
        public override Transaction Withdarw(Transaction x)
        {
            if(Owner.Status == Enums.CustomerSatus.REGULAR)
            {
                if(x.Amount >= Balance)
                {
                    Owner.Result = Enums.TransactionResult.INSUFFICIENT_FUND;
                }
                else
                {

                    Balance -= x.Amount + WithdrawPenalyAmount;
                    x.Type = Enums.TransactionType.WITHDDRAW;
                    Transaction transactionWithdraw = new Transaction(x.Amount + WithdrawPenalyAmount, x.Type);
                    Transaction transactionPenalty = new Transaction(WithdrawPenalyAmount, Enums.TransactionType.PENALTY);
                    transactionHistory.Add(transactionWithdraw);
                    transactionHistory.Add(transactionPenalty);
                }
            }
            else
            {
                if(x.Amount > Balance)
                {
                    Owner.Result = Enums.TransactionResult.INSUFFICIENT_FUND;
                }
                else
                {
                    Balance -= x.Amount;
                    if (Balance < PrimierAmount)
                    {
                        Owner.Status = Enums.CustomerSatus.REGULAR;
                    }
                    x.Type = Enums.TransactionType.WITHDDRAW;
                    Transaction transactionWithdraw = new Transaction(x.Amount, x.Type);
                    transactionHistory.Add(transactionWithdraw);
                }
            }
            return x;
        }

        public override Transaction Transfer(Transaction x)
        {
            Owner.Saving.Balance -= x.Amount;
            Owner.Checking.Balance += x.Amount;
            if(Owner.Saving.Balance < PrimierAmount)
            {
                Owner.Status = Enums.CustomerSatus.REGULAR;
            }
            else
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
