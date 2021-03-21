using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;
        for (int i = 0; i < customers.Count; i++)
        {
            ListItem item = new ListItem(customers[i].Name);
            customerList.Items.Add(item);
        }
    }

    protected void customerList_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;
        if (customerList.SelectedIndex > 0)
        {
            checkingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.Balance.ToString();
            savingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.Balance.ToString();
        }

    }
    protected void button_Submit(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;
        Lab5.Account account = null;

            if (accountList.SelectedValue == "checking")
            {
                account = customers[customerList.SelectedIndex - 1].Checking;
                
                if(double.Parse(tranAmount.Text) > customers[customerList.SelectedIndex - 1].Checking.Balance)
                {
                    subLabel.CssClass = "error";
                    subLabel.Text = "You can not transfer than much!";
                }
                else
                {
                    Lab5.Transaction transaction = new Lab5.Transaction(double.Parse(tranAmount.Text), Lab5.Enums.TransactionType.TRANSFER_IN);
                    customers[customerList.SelectedIndex - 1].Checking.Transfer(transaction);
                    Lab5.Transaction transactionIN = new Lab5.Transaction(double.Parse(tranAmount.Text), Lab5.Enums.TransactionType.TRANSFER_IN);
                    customers[customerList.SelectedIndex - 1].Saving.transactionHistory.Add(transactionIN);
                    
                     subLabel.Text = "The transfer is completed";
                    subLabel.CssClass = "";
                }

            }
            else
            {
                account = customers[customerList.SelectedIndex - 1].Saving;

                if (double.Parse(tranAmount.Text) > customers[customerList.SelectedIndex - 1].Saving.Balance)
                {
                    subLabel.Text = "You can not transfer than much!";
                    subLabel.CssClass = "error";
                }
                else
                {
                    if (customers[customerList.SelectedIndex - 1].Status == Lab5.Enums.CustomerSatus.REGULAR)
                    {
                        Lab5.Transaction transactionReg = new Lab5.Transaction(double.Parse(tranAmount.Text), Lab5.Enums.TransactionType.TRANSFER_IN);
                        customers[customerList.SelectedIndex - 1].Saving.Transfer(transactionReg);
                        Lab5.Transaction transactionINReg = new Lab5.Transaction(double.Parse(tranAmount.Text), Lab5.Enums.TransactionType.TRANSFER_IN);
                        customers[customerList.SelectedIndex - 1].Checking.transactionHistory.Add(transactionINReg);
                        Lab5.Transaction transactionPen = new Lab5.Transaction(10, Lab5.Enums.TransactionType.PENALTY);
                        customers[customerList.SelectedIndex - 1].Saving.transactionHistory.Add(transactionPen);
                        
                         subLabel.Text = "The transfer is completed";
                         subLabel.CssClass = "";

                    }
                    else
                    {
                    Lab5.Transaction transaction = new Lab5.Transaction(double.Parse(tranAmount.Text), Lab5.Enums.TransactionType.TRANSFER_IN);
                    customers[customerList.SelectedIndex - 1].Saving.Transfer(transaction);
                    Lab5.Transaction transactionIN = new Lab5.Transaction(double.Parse(tranAmount.Text), Lab5.Enums.TransactionType.TRANSFER_IN);
                    customers[customerList.SelectedIndex - 1].Checking.transactionHistory.Add(transactionIN);

                    subLabel.Text = "The transfer is completed";
                    subLabel.CssClass = "";
                    }
                }

            
            }
            checkingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.Balance.ToString();
            savingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.Balance.ToString();

           

    }
}