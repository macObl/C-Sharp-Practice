using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Customer 
    {
        public string Name = "";
        public Enums.CustomerSatus Status { get; set; }
        public CheckingAccount Checking { get; set; }
        public SavingAccount Saving { get; set; }
        public Enums.TransactionResult Result { get; set; }

        public Customer(string x) 
        {
            Name = x;
            
        }
    }
}
