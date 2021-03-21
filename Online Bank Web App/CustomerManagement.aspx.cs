using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;
        if(customers == null)
        {
            customers = new List<Lab5.Customer>();
            Session["customers"] = customers;
        }
        ShowCustomersInfo(customers);

    }

    protected void button_Submit(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;

        if(customers == null)
        {
            customers = new List<Lab5.Customer>();
            Session["customers"] = customers;
        }
        Lab5.Customer customer = new Lab5.Customer(txtName.Text);
        double initial = double.Parse(initialDeposit.Text);

        Lab5.SavingAccount saving = new Lab5.SavingAccount(customer, initial);
        Lab5.CheckingAccount checking = new Lab5.CheckingAccount(customer, initial);

        customer.Saving = saving;
        customer.Checking = checking;

        customers.Add(customer);
        ShowCustomersInfo(customers);

    }
    protected void ShowCustomersInfo(List<Lab5.Customer> customers)
    {
        for (int i = Table.Rows.Count - 1; i > 0; i--)
        {
            Table.Rows.RemoveAt(i);
        }

        if (customers.Count == 0)
        {
            TableRow errorRow = new TableRow();
            TableCell errorCell = new TableCell();
            errorCell.Text = "No customer in system yet";
            errorCell.ForeColor = System.Drawing.Color.Red;
            errorCell.ColumnSpan = 4;
            errorCell.HorizontalAlign = HorizontalAlign.Center;
            errorRow.Cells.Add(errorCell);
            Table.Rows.Add(errorRow);
        }
        else
        {
            for (int i = 0; i < customers.Count; i++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = customers[i].Name;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "$" + customers[i].Checking.Balance.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "$" + customers[i].Saving.Balance.ToString();
                row.Cells.Add(cell);

                if (customers[i].Saving.Balance >= 2000)
                {
                    customers[i].Status = Lab5.Enums.CustomerSatus.PREMIER;
                }

                cell = new TableCell();
                cell.Text = customers[i].Status.ToString();
                row.Cells.Add(cell);

                Table.Rows.Add(row);

            }
        }
    }
    
}