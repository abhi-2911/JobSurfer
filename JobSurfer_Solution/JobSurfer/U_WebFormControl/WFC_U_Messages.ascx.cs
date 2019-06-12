using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.U_WebFormControl
{
    public partial class WFC_U_Messages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)  //check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }
        }

        protected void gvA1_3_SelectedIndexChanged(object sender, EventArgs e)    /*open button within the gridview is clicked*/
        {
            Label js_message_id = gvA1_3.SelectedRow.FindControl("labelA1_3") as Label;
            Response.Redirect("~/User/U_Message_Details.aspx?id=" + js_message_id.Text);
        }
    }
}