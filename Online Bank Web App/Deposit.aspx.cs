using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Deposit : System.Web.UI.Page
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
        }
        else
        {
            account = customers[customerList.SelectedIndex - 1].Saving;
        }
        Lab5.Transaction transaction = new Lab5.Transaction(double.Parse(depAmount.Text), Lab5.Enums.TransactionType.DEPOSIT);
        account.Deposit(transaction);

        checkingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.Balance.ToString();
        savingLabel.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.Balance.ToString();

        subLabel.Text = "The transaction is completed";

    }
}