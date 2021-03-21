using System;
using AlgonquinCollege.Registration.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
        btnHome.Click += (s, a) => Response.Redirect("Default.aspx");
        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");
        topMenu.Click += (s, a) => Response.Redirect("AddCourse.aspx");
        
        List<Course> courses = Session["courses"] as List<Course>;

        List<AcademicRecord> records = Session["records"] as List<AcademicRecord>;
        if (!IsPostBack)
        {
            topMenu.Items.Add(new ListItem("Add Course"));
            if(courses == null)
            {
                Response.Redirect("AddCourse.aspx");
            }
            if(courseList.Items.Count < courses.Count)
            {
                for(int i = 0; i < courses.Count; i++)
                {
                    courseList.Items.Add(new ListItem(courses[i].CourseName));
                }
            }
        }
        string sort = Request.Params["sort"];
        //ShowStudentInfo(records, sort);
        Table.Visible = false;
    }
    protected void btnAddStudent_OnClick(object sender, EventArgs e)
    {
        List<Course> courses = Session["courses"] as List<Course>;
        Course course = courses[courseList.SelectedIndex];
        Student student = new Student(number.Text, name.Text);

        AcademicRecord academicRecord = new AcademicRecord(course, student);
        academicRecord.Grade = Int32.Parse(grade.Text);
        course.AcademicRecords.Add(academicRecord);

        course.AcademicRecords.OrderBy(s => s.Student.Name.Split(' ')[1]).ThenBy(s => s.Student.Name.Split(' ')[0]).ToList();

        if (courses == null || courses.Count == 0)
        {
            TableRow errorRow = new TableRow();
            TableCell errorCell = new TableCell();
            errorCell.Text = "No students in system yet";
            errorCell.ForeColor = System.Drawing.Color.Red;
            errorCell.ColumnSpan = 4;
            errorCell.HorizontalAlign = HorizontalAlign.Center;
            errorRow.Cells.Add(errorCell);
            Table.Rows.Add(errorRow);

            Table.Visible = true;
        }
        foreach (var record in course.AcademicRecords)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell(); ;
            cell.Text = record.Student.Id;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = record.Student.Name;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = record.Grade.ToString();
            row.Cells.Add(cell);

            Table.Rows.Add(row);
            Table.Visible = true;
        }

        Table.Visible = true;
    }
    protected void courseList_SelectedIndexChanged(object sender, EventArgs e)
    {

        
        List<Course> courses = Session["courses"] as List<Course>;
        Course course = courses[courseList.SelectedIndex];

        course.AcademicRecords.OrderBy(s => s.Student.Name.Split(' ')[1]).ThenBy(s => s.Student.Name.Split(' ')[0]).ToList();
        if (courses == null || courses.Count == 0)
        {
            TableRow errorRow = new TableRow();
            TableCell errorCell = new TableCell();
            errorCell.Text = "No students in system yet";
            errorCell.ForeColor = System.Drawing.Color.Red;
            errorCell.ColumnSpan = 4;
            errorCell.HorizontalAlign = HorizontalAlign.Center;
            errorRow.Cells.Add(errorCell);
            Table.Rows.Add(errorRow);

            Table.Visible = true;
        }
        foreach (var record in course.AcademicRecords)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();;
            cell.Text = record.Student.Id;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = record.Student.Name;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = record.Grade.ToString();
            row.Cells.Add(cell);

            Table.Rows.Add(row);
            Table.Visible = true;
        }
    }
    protected void ShowStudentInfo(List<AcademicRecord> records, string sort = "id")
    {
        List<Course> courses = Session["courses"] as List<Course>;
        Course course = courses[courseList.SelectedIndex];

        if (sort == "id")
        {
            records.Sort((c1, c2) => c1.Student.Id.CompareTo(c2.Student.Id));
        }
        else if (sort == "name")
        {
            records.Sort((c1, c2) => c1.Student.Name.CompareTo(c2.Student.Name));
        }
        else if (sort == "grade")
        {
            records.Sort((c1, c2) => c1.Grade.CompareTo(c2.Grade));
        }
        for (int j = Table.Rows.Count - 1; j > 0; j--)
        {
            Table.Rows.RemoveAt(j);
        }
        if (records == null || records.Count == 0)
        {
            TableRow errorRow = new TableRow();
            TableCell errorCell = new TableCell();
            errorCell.Text = "No students in system yet";
            errorCell.ForeColor = System.Drawing.Color.Red;
            errorCell.ColumnSpan = 4;
            errorCell.HorizontalAlign = HorizontalAlign.Center;
            errorRow.Cells.Add(errorCell);
            Table.Rows.Add(errorRow);

            Table.Visible = true;
        }
        foreach (var record in course.AcademicRecords)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            //cell.Text = records[courseList.SelectedIndex].Student.Id;
            cell.Text = record.Student.Id;
            row.Cells.Add(cell);

            cell = new TableCell();
           // cell.Text = records[courseList.SelectedIndex].Student.Name;
            cell.Text = record.Student.Name;
            row.Cells.Add(cell);

            cell = new TableCell();
            //cell.Text = records[courseList.SelectedIndex].Grade.ToString();
            cell.Text = record.Grade.ToString();
            row.Cells.Add(cell);

            Table.Rows.Add(row);
            Table.Visible = true;
        }

    }
}