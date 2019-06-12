using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.A_WebFormControl
{
    public partial class WFC_A_List_J : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                /*continue*/
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }
        }

        protected void gvA1_3_SelectedIndexChanged(object sender, EventArgs e)    /*open button is clicked*/
        {
            Label job_ID = gvA1_3.SelectedRow.FindControl("labelA1_3") as Label;
            Response.Redirect("~/Admin/A_List_J_Details.aspx?id=" + job_ID.Text);
        }
    }
}