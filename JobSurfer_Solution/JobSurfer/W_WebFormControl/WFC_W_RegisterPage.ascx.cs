using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.W_WebFormControl
{
    public partial class WFC_W_RegisterPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButA1_3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/U_RegisterPage.aspx");
        }

        protected void ButB1_3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employer/E_RegisterPage.aspx");
        }
    }
}