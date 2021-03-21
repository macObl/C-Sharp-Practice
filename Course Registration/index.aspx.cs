using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        List<Course> course = Helper.GetCourses();
        for (int i = 0; i < course.Count; i++)
        {
            Course courses = course[i] as Course;
            ListItem item = new ListItem(course[i].ToString(), i.ToString());
            liCourses.Items.Add(item);
        }
        Regestration.Visible = true;
        Results.Visible = false;
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            List<Course> course = Helper.GetCourses();
            Student student = null;

            //Choses the type of student
            switch (studentType.SelectedItem.Value)
            {
                case "full-time":
                    student = new FullTimeStudent(txtName.Text);
                    break;
                case "part-time":
                    student = new PartTimeStudent(txtName.Text);
                    break;
                case "co-op":
                    student = new PartTimeStudent(txtName.Text);
                    break;
            }
            //Add the couses to the student 
            foreach(ListItem item in liCourses.Items)
            {
                if (item.Selected)
                {
                    int selected = int.Parse(item.Value);
                    student.addCourse(course[selected] as Course);
                    
                }
            }

            //Throw Errors
            if (txtName.Text == "")
            {
                throw new Exception("You need to type your name in the space provided");
            }
            if (student.getEnrolledCourses().Count == 0)
            {
                throw new Exception("You need to select a cource");
            }

            //Makes table from selected courses
            foreach (Course courses in student.getEnrolledCourses())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = courses.Code;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = courses.Title;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = courses.WeeklyHours.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text ="$" + courses.Fee.ToString();
                row.Cells.Add(cell);

                Table.Rows.Add(row);
            }
            //Makes the Total of the table
            TableRow rowTotal = new TableRow();
            TableCell cellTotal = new TableCell();

            cellTotal.Text = "Total:";
            cellTotal.ColumnSpan = 2;
            rowTotal.Cells.Add(cellTotal);

            cellTotal = new TableCell();
            cellTotal.Text = student.totalWeeklyHours().ToString();
            rowTotal.Cells.Add(cellTotal);

            cellTotal = new TableCell();
            cellTotal.Text = "$" + student.feePayable().ToString();
            rowTotal.Cells.Add(cellTotal);
            
            Table.Rows.Add(rowTotal);

            Name.Text = txtName.Text;
            Type.Text = studentType.SelectedItem.Text;

            Regestration.Visible = false;
            Results.Visible = true;
            
        }
        catch (Exception x)
        {
            error.Text = x.Message;
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
}