using System;
using AlgonquinCollege.Registration.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
        btnHome.Click += (s, a) => Response.Redirect("Default.aspx");
        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");
        topMenu.Click += (s, a) => Response.Redirect("AddStudent.aspx");
        if (!IsPostBack)
        {
            topMenu.Items.Add(new ListItem("Add Student Records"));
        }
        List<Course> courses = Session["courses"] as List<Course>;
        if(courses == null)
        {
            courses = new List<Course>();
            Session["courses"] = courses;
        }
        string sort = Request.Params["sort"];

        if (!string.IsNullOrEmpty(sort))
        {
            ShowCourseInfo(courses, sort);
        }
        else
        {
            ShowCourseInfo(courses);
        }
    }
    protected void btnAddCourse_OnClick(object sender, EventArgs e)
    {
        List<Course> courses = Session["courses"] as List<Course>;
        if(courses == null)
        {
            courses = new List<Course>();
            Session["courses"] = courses;
        }
        Course course = new Course(courseNumber.Text,courseName.Text);
        courses.Add(course);
        ShowCourseInfo(courses);

    }
    protected void ShowCourseInfo(List<Course> courses, string sort = "code")
    {
        for(int i = Table.Rows.Count -1; i > 0; i--)
        {
            Table.Rows.RemoveAt(i);
        }
        if(courses == null || courses.Count == 0)
        {
            TableRow errorRow = new TableRow();
            TableCell errorCell = new TableCell();
            errorCell.Text = "No cources in system yet";
            errorCell.ForeColor = System.Drawing.Color.Red;
            errorCell.ColumnSpan = 4;
            errorCell.HorizontalAlign = HorizontalAlign.Center;
            errorRow.Cells.Add(errorCell);
            Table.Rows.Add(errorRow);
        }
        else
        {
            if(sort == "code")
            {
                courses.Sort((c1, c2) => c1.CourseNumber.CompareTo(c2.CourseNumber));
            }
            else if(sort == "title")
            {
                courses.Sort((c1, c2) => c1.CourseName.CompareTo(c2.CourseName));
            }
            if(Session["order"] != null && (string)Session["order"] == "decending")
            {
                courses.Reverse();
                Session["order"] = "ascending";
            }
            else
            {
                Session["order"] = "descending";
            }
            foreach (var course in courses)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = course.CourseNumber;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = course.CourseName;
                row.Cells.Add(cell);

                Table.Rows.Add(row);

            }
        }
    }
}