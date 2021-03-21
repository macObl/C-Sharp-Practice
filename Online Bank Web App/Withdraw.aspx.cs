using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Withdraw : System.Web.UI.Page
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
            for (int i = 0; i < customers.Count; i++)
            {
                checkingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.Balance.ToString();
                savingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.Balance.ToString();
            }
        }

    }
    protected void button_Submit(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;
        Lab5.Account account = null;
        double compare = Convert.ToDouble(withAmount.Text);

        if (accountList.SelectedValue == "checking")
        {
            account = customers[customerList.SelectedIndex - 1].Checking;

            if (double.Parse(withAmount.Text) > customers[customerList.SelectedIndex - 1].Checking.Balance)
            {
                subLabel.Text = "At least 1 dollar and no more than the account balance";
                subLabel.CssClass = "error";
            }
            else
            {
                if(customers[customerList.SelectedIndex - 1].Status == Lab5.Enums.CustomerSatus.REGULAR)
                {
                    Lab5.Transaction transaction = new Lab5.Transaction(double.Parse(withAmount.Text), Lab5.Enums.TransactionType.WITHDDRAW);
                    account.Withdarw(transaction);
                    if (compare >= 300)
                    {
                        subLabel.Text = "Transaction cancelled:" + Lab5.Enums.TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;
                    }
                    else
                    {
                        checkingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.Balance.ToString();
                        savingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.Balance.ToString();

                        subLabel.Text = "The transaction is completed";
                        subLabel.CssClass = "";
                    }
                }
                else
                {
                    Lab5.Transaction transaction = new Lab5.Transaction(double.Parse(withAmount.Text), Lab5.Enums.TransactionType.WITHDDRAW);
                    account.Withdarw(transaction);
                    checkingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.Balance.ToString();
                    savingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.Balance.ToString();

                    subLabel.Text = "The transaction is completed";
                    subLabel.CssClass = "";
                }
            }
        }
        else
        {
            account = customers[customerList.SelectedIndex - 1].Saving;

            if (double.Parse(withAmount.Text) > customers[customerList.SelectedIndex - 1].Saving.Balance)
            {
                subLabel.Text = "At least 1 dollar and no more than the account balance";
                subLabel.CssClass = "error";
            }
            else
            {
                Lab5.Transaction transaction = new Lab5.Transaction(double.Parse(withAmount.Text), Lab5.Enums.TransactionType.WITHDDRAW);
                account.Withdarw(transaction);
                checkingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.Balance.ToString();
                savingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.Balance.ToString();

                subLabel.Text = "The transaction is completed";
                subLabel.CssClass = "";
            }
        }

    }
}