using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Bank
    {
        static void Main(string[] args)
        {
            string userInput = "";
            double initialDeposit = 0;
            int userInput2 = 0;
            int userInput3 = 0;
            double amount = 0.0;

            List<Customer> customers = new List<Customer>();

            Console.WriteLine("Welcome to Algonquin Bank!");
            Console.WriteLine();
            do
            {
                Console.Write("Enter Cusomer Name: ");
                userInput = Console.ReadLine();
                Customer customer = new Customer(userInput);

                if (userInput != "")
                {
                    Console.Write("Enter " + userInput + "'s Initial Deposit Amount: ");
                    initialDeposit = double.Parse(Console.ReadLine());
                    if (initialDeposit <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Entry, try agian ");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        SavingAccount saving = new SavingAccount(customer, initialDeposit);
                        CheckingAccount checking = new CheckingAccount(customer, initialDeposit);

                        customer.Saving = saving;
                        customer.Checking = checking;

                        customers.Add(customer);
                    }
                }

            } while (userInput != "");
            Console.WriteLine();
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Saving.Balance > customers[i].Saving.PrimierAmount - 1)
                {
                    customers[i].Status = Enums.CustomerSatus.PREMIER;
                }
                else
                {
                    customers[i].Status = Enums.CustomerSatus.REGULAR;
                }
                Console.WriteLine("{0}. Customer {1}, current status {2}",
                                i,
                                customers[i].Name,
                                customers[i].Status);

            }
            Console.WriteLine();
            do
            {
                Console.Write("Enter your selection 0 to {0}: ", customers.Count - 1);
                userInput2 = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (userInput2 > customers.Count - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Entry, try agian ");
                    Console.WriteLine();
                }
                else
                {
                    for (int i = 0; i < customers.Count; i++)
                    {
                        if (userInput2 == i)
                        {
                            Console.WriteLine("Welcome {0} You are currently our {1} customer.",
                                                    customers[i].Name,
                                                    customers[i].Status);

                            customers[i].Checking.Balance = 0;

                        while (userInput2 != 6)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Select one of the following activities: ");

                            Console.WriteLine();
                            Console.WriteLine("1. Deposit...");
                            Console.WriteLine("2. Withdraw... ");
                            Console.WriteLine("3. Transfer...");
                            Console.WriteLine("4. Balance Enquiry...");
                            Console.WriteLine("5. Account Activity Enquiry...");
                            Console.WriteLine("6. EXIT");

                            Console.WriteLine();
                            Console.Write("Enter your selection (1 to 6): ");
                            userInput2 = int.Parse(Console.ReadLine());
                                if (userInput2 == 0 || userInput2 > 6)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid Entry, try agian ");
                                }
                                else
                                {
                                    //Deposit
                                    if (userInput2 == 1)
                                    {
                                            Console.WriteLine();
                                            Console.Write("Select account (1 - Checking Account, 2 - Saving Account): ");
                                            userInput3 = int.Parse(Console.ReadLine());
                                            if (userInput3 == 1)
                                            {
                                                Console.Write("Enter Amount: ");
                                                amount = double.Parse(Console.ReadLine());
                                                Transaction transaction = new Transaction(amount, Enums.TransactionType.DEPOSIT);
                                                customers[i].Checking.Deposit(transaction);
                                                Console.WriteLine();
                                                Console.WriteLine(" Deposit complete blanace is ${0}", customers[i].Checking.Balance);
                                                Console.WriteLine();
                                            }
                                            else if (userInput3 == 2)
                                            {
                                                Console.Write("Enter Amount: ");
                                                amount = double.Parse(Console.ReadLine());
                                                Transaction transaction = new Transaction(amount, Enums.TransactionType.DEPOSIT);
                                                customers[i].Saving.Deposit(transaction);

                                                Console.WriteLine();
                                                Console.WriteLine(" Deposit complete blanace is ${0}", customers[i].Saving.Balance);
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine(" {0}, your current status is {1}",
                                                                         customers[i].Name,
                                                                         customers[i].Status);
                                            }
                                        
                                    }

                                    //Withdraw
                                    if (userInput2 == 2)
                                    {
                                            Console.WriteLine();
                                            Console.Write("Select account (1 - Checking Account, 2 - Saving Account): ");
                                            userInput3 = int.Parse(Console.ReadLine());
                                            if (userInput3 == 1)
                                            {
                                                Console.Write("Enter Amount: ");
                                                amount = double.Parse(Console.ReadLine());
                                                if (amount >= customers[i].Checking.Balance)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("  Withdraw cancelled: {0} ", customers[i].Result);
                                                    Console.WriteLine();
                                                }
                                                else
                                                {

                                                    Transaction transaction = new Transaction(amount, Enums.TransactionType.WITHDDRAW);
                                                    customers[i].Checking.Withdarw(transaction);
                                                    if (customers[i].Status == Enums.CustomerSatus.REGULAR)
                                                    {
                                                        if (amount > 300)
                                                        {
                                                            Console.WriteLine();
                                                            Console.WriteLine(" Withdraw cancelled: {0} ", customers[i].Result);
                                                            Console.WriteLine();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine(" Withdraw complete, account current balance is: ${0} ", customers[i].Checking.Balance);
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            else if (userInput3 == 2)
                                            {
                                                Console.Write("Enter Amount: ");
                                                amount = double.Parse(Console.ReadLine());
                                                if (amount >= customers[i].Saving.Balance)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine(" Withdraw cancelled: {0} ", customers[i].Result);
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    Transaction transaction = new Transaction(amount, Enums.TransactionType.WITHDDRAW);
                                                    customers[i].Saving.Withdarw(transaction);

                                                    Console.WriteLine();
                                                    Console.WriteLine(" Withdraw complete, account current balance is: ${0} ", customers[i].Saving.Balance);
                                                    Console.WriteLine();
                                                    Console.WriteLine(" Your current status is: {0}", customers[i].Status);
                                                }

                                            }

                                        
                                    }

                                    //Transfer
                                    if (userInput2 == 3)
                                    {
                                            Console.Write("Slect accounts (1 - from Checking to Saving, 2 - from Saving to Checking): ");
                                            userInput3 = int.Parse(Console.ReadLine());
                                            if (userInput3 == 1)
                                            {
                                                Console.Write("Enter Amount: ");
                                                amount = double.Parse(Console.ReadLine());
                                                if (amount >= customers[i].Checking.Balance)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("You can't transfer that much");
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    Transaction transaction = new Transaction(amount, Enums.TransactionType.TRANSFER_IN);
                                                    customers[i].Checking.Transfer(transaction);
                                                    Transaction transactionIN = new Transaction(amount, Enums.TransactionType.TRANSFER_IN);
                                                    customers[i].Saving.transactionHistory.Add(transactionIN);

                                                    if (customers[i].Saving.Balance > 2000)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("You are now a {0} status", customers[i].Status);
                                                        Console.WriteLine();
                                                    }
                                            }
                                            }
                                            else if (userInput3 == 2)
                                            {
                                                Console.Write("Enter Amount: ");
                                                amount = double.Parse(Console.ReadLine());
                                                if (amount >= customers[i].Saving.Balance)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("You can't transfer that much");
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    Transaction transaction = new Transaction(amount, Enums.TransactionType.TRANSFER_IN);
                                                    customers[i].Saving.Transfer(transaction);

                                                    Transaction transactionIN = new Transaction(amount, Enums.TransactionType.TRANSFER_IN);
                                                    customers[i].Checking.transactionHistory.Add(transactionIN);

                                                    if (customers[i].Checking.Balance > 2000)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("You are now a {0} status", customers[i].Status);
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                    }

                                    //Balance Enquiry
                                    if (userInput2 == 4)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Account              Balance");
                                        Console.WriteLine("----------------------------");
                                        Console.WriteLine("Checking              ${0}", customers[i].Checking.Balance);
                                        Console.WriteLine("Savings               ${0}", customers[i].Saving.Balance);

                                    }

                                    //Account Actiity Enquiry
                                    if (userInput2 == 5)
                                    {
                                            Console.WriteLine("Checking Account: ");
                                            Console.WriteLine();
                                            Console.WriteLine("Amount        Date          Activity");
                                            Console.WriteLine("------------------------------------");
                                            for (int j = 0; j < customers[i].Checking.transactionHistory.Count; j++)
                                            {
                                                Console.WriteLine("{0}       {1}         {2} ",
                                                    customers[i].Checking.transactionHistory[j].Amount,
                                                    customers[i].Checking.transactionHistory[j].TransactionDate,
                                                    customers[i].Checking.transactionHistory[j].Type);
                                                Console.WriteLine();
                                            }
                                            Console.WriteLine("Saving Account: ");
                                            Console.WriteLine();
                                            Console.WriteLine("Amount        Date          Activity");
                                            Console.WriteLine("------------------------------------");
                                            for (int j = 0; j < customers[i].Saving.transactionHistory.Count; j++)
                                            {
                                                Console.WriteLine("{0}       {1}         {2} ",
                                                    customers[i].Saving.transactionHistory[j].Amount,
                                                    customers[i].Saving.transactionHistory[j].TransactionDate,
                                                    customers[i].Saving.transactionHistory[j].Type);
                                                Console.WriteLine();
                                            }
                                        

                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Algonquin bank");
                    break;
                }
            } while (userInput2 > customers.Count - 1);
            Console.Read();
        }
    }
}
