using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Activity : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;
        for (int i = 0; i < customers.Count; i++)
        {
            ListItem item = new ListItem(customers[i].Name);
            customerList.Items.Add(item);
        }
        checkingTable.Visible = false;
        savingTable.Visible = false;
    }

    protected void customerList_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Lab5.Customer> customers = Session["customers"] as List<Lab5.Customer>;
        if (customerList.SelectedIndex > 0)
        {
            for (int j = 0; j < customers[customerList.SelectedIndex - 1].Checking.transactionHistory.Count; j++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = customers[customerList.SelectedIndex - 1].Checking.transactionHistory[j].TransactionDate.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "$" + customers[customerList.SelectedIndex - 1].Checking.transactionHistory[j].Amount.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = customers[customerList.SelectedIndex - 1].Checking.transactionHistory[j].Type.ToString();
                row.Cells.Add(cell);

                checkingTable.Rows.Add(row);

                checkingTable.Visible = true;
            }
            for (int j = 0; j < customers[customerList.SelectedIndex - 1].Saving.transactionHistory.Count; j++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = customers[customerList.SelectedIndex - 1].Saving.transactionHistory[j].TransactionDate.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "$" + customers[customerList.SelectedIndex - 1].Saving.transactionHistory[j].Amount.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = customers[customerList.SelectedIndex - 1].Saving.transactionHistory[j].Type.ToString();
                row.Cells.Add(cell);

                savingTable.Rows.Add(row);

                savingTable.Visible = true;
            }
        }
    }
}