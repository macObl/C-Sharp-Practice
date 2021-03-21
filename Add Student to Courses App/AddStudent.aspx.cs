using System;
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
        if (!IsPostBack)
        {
            topMenu.Items.Add(new ListItem("Add Course"));
        }

        if (!IsPostBack)
        {
            using (var studentRecords = new StudentRecordEntities())
            {
                var cs = (from c in studentRecords.Courses orderby c.Title select new { CourseId = c.Code, CourseText = c.Code + "-" + c.Title }).ToList();
                if (cs.Count == 0)
                {
                    Response.Redirect("AddCourse.aspx");
                }
                else
                {
                    courseList.DataSource = cs;
                    courseList.DataTextField = "CourseText";
                    courseList.DataValueField = "CourseId";
                    courseList.DataBind();
                }

            }

        }
        

    }
    protected void btnAddStudent_OnClick(object sender, EventArgs e)
    {
        using(var studentRecords = new StudentRecordEntities())
        {
            Course course = (from a in studentRecords.Courses where a.Code == courseList.SelectedValue select a).FirstOrDefault();
            List<AcademicRecord> records = (from b in course.AcademicRecords where b.StudentId == number.Text select b).ToList();
            if(records.Count > 0)
            {
                numberError.Text = "The system already has record of this student for the selected course";
                ShowStudent(course);
            }
            else
            {
                Student student = (from c in studentRecords.Students where c.Id == number.Text select c).FirstOrDefault();
                if(student == null)
                {
                    student = new Student();
                    student.Id = number.Text;
                    student.Name = name.Text;
                    studentRecords.Students.Add(student);
                }

                AcademicRecord academic = new AcademicRecord();
                academic.CourseCode = course.Code;
                academic.Grade = int.Parse(grade.Text);
                academic.Student = student;

                course.AcademicRecords.Add(academic);
                studentRecords.SaveChanges();

                Response.Redirect("AddStudent.aspx");
            }
        }
    }
    protected void ShowStudent(Course course)
    {
        for (int i = Table.Rows.Count - 1; i > 0; i--)
        {
            Table.Rows.RemoveAt(i);
        }
        if (course == null || course.AcademicRecords.Count == 0)
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

            foreach (var record in course.AcademicRecords)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = record.Student.Id;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = record.Student.Name;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = record.Grade.ToString();
                row.Cells.Add(cell);

                Table.Rows.Add(row);

            }
        }
    }
    protected void courseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        using(var studentRecords = new StudentRecordEntities())
        {
            Course course = (from a in studentRecords.Courses where a.Code == courseList.SelectedValue select a).FirstOrDefault();
            ShowStudent(course);
        }

    }
}