using System;
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
        if (courses == null)
        {
            courses = new List<Course>();
            Session["courses"] = courses;
        }
        string sort = Request.Params["sort"];

        if (!string.IsNullOrEmpty(sort))
        {
           ShowCourseTable(courses, sort);
        }
        else
        {
            ShowCourseTable(courses);
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Course course = new Course();
        course.Code = courseNumber.Text;
        course.Title = courseName.Text;

        using (var courseRecord = new StudentRecordEntities())
        {
            if (courseRecord.Courses.Where(c => c.Code == courseNumber.Text).Count() > 0)
            {
                lblError.Text = "Course with this code already exists";
                return;
            }
            else
            {
                courseRecord.Courses.Add(course);
                courseRecord.SaveChanges();
                Response.Redirect("AddCourse.aspx");
            }
        }
    }
    protected void ShowCourseTable(List<Course> test, string sort = "code")
    {
        using(var context = new StudentRecordEntities())
        {
            List<Course> courses = context.Courses.ToList();
            for (int i = Table.Rows.Count - 1; i > 0; i--)
            {
                Table.Rows.RemoveAt(i);
            }
            if (courses == null || courses.Count == 0)
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
                if (sort == "code")
                {
                    courses.Sort((c1, c2) => c1.Code.CompareTo(c2.Code));
                }
                else if (sort == "title")
                {
                    courses.Sort((c1, c2) => c1.Title.CompareTo(c2.Title));
                }
                if (Session["order"] != null && (string)Session["order"] == "decending")
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

                    cell.Text = course.Code;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = course.Title;
                    row.Cells.Add(cell);

                    Table.Rows.Add(row);

                }
            }
            }
    }
}