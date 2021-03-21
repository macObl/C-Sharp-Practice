using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST8256Lab2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            Course.Courses courses = new Course.Courses(cName.Text, cNumber.Text);
            Session["courses"] = courses;

            Response.Redirect("StudentRecords.aspx");
        }
    }
}