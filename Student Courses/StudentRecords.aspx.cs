using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST8256Lab2
{
    public partial class StudentRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Course.Courses courses = Session["courses"] as Course.Courses;
            Page.Title = courses.Number + courses.Name;
            List<StudentRecord.StudentRecords> records = Session["records"] as List<StudentRecord.StudentRecords>;
            if (records == null)
            {
                records = new List<StudentRecord.StudentRecords>();
                Session["records"] = records;
            }
            DisplayStudentRecords(records);
        }
        protected void btnAddRecords_Click(object sender, EventArgs e)
        {
            List<StudentRecord.StudentRecords> records = Session["records"] as List<StudentRecord.StudentRecords>;
            if (records == null)
            {
                records = new List<StudentRecord.StudentRecords>();
                Session["records"] = records;
            }
            StudentRecord.StudentRecords record = new StudentRecord.StudentRecords(studentID.Text, studentName.Text, int.Parse(studentGrade.Text));

            records.Add(record);
            DisplayStudentRecords(records);
        }
        protected void RadioButtonList_SelectedValue(object sender, EventArgs e)
        {
            List<StudentRecord.StudentRecords> records = Session["records"] as List<StudentRecord.StudentRecords>;
            if (records == null)
            {
                records = new List<StudentRecord.StudentRecords>();
                Session["records"] = records;
            }
            if (RadioButtonList.SelectedIndex == 0)
            {
                records.Sort((x, y) => x.id.CompareTo(y.id));
                foreach (StudentRecord.StudentRecords student in records)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();

                    cell.Text = student.id;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = student.name;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = student.grade.ToString();
                    row.Cells.Add(cell);

                    tblCourses.Rows.Add(row);


                }
            }
            else if (RadioButtonList.SelectedIndex == 1)
            {
                records = records.OrderBy(s => s.name.Split(' ')[1]).ThenBy(s => s.name.Split(' ')[0]).ToList();

                foreach (StudentRecord.StudentRecords student in records)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();

                    cell.Text = student.id;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = student.name;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = student.grade.ToString();
                    row.Cells.Add(cell);

                    tblCourses.Rows.Add(row);
                }
            }
            else if (RadioButtonList.SelectedIndex == 2)
            {
                records.Sort((x, y) => x.grade.CompareTo(y.grade));
                foreach (StudentRecord.StudentRecords student in records)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();

                    cell.Text = student.id;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = student.name;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = student.grade.ToString();
                    row.Cells.Add(cell);

                    tblCourses.Rows.Add(row);


                }
            }
            DisplayStudentRecords(records);
        }
        private void DisplayStudentRecords(List<StudentRecord.StudentRecords> records)
        {
            for (int i = tblCourses.Rows.Count - 1; i > 0; i--)
            {
                tblCourses.Rows.RemoveAt(i);
            }
            if (!IsPostBack)
            {
                if (records.Count == 0)
                {
                    TableRow lastRow = new TableRow();
                    TableCell lastRowCell = new TableCell();
                    lastRowCell.Text = "No Student Record Exists!";
                    lastRowCell.ForeColor = System.Drawing.Color.Red;
                    lastRowCell.ColumnSpan = 3;
                    lastRowCell.HorizontalAlign = HorizontalAlign.Center;
                    lastRow.Cells.Add(lastRowCell);
                    tblCourses.Rows.Add(lastRow);
                }
            }
            else
            {
                for (int i = 0; i < records.Count; i++)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();

                    cell.Text = records[i].id;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = records[i].name;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = records[i].grade.ToString();
                    row.Cells.Add(cell);

                    tblCourses.Rows.Add(row);

                }
            }
        }
    }
}