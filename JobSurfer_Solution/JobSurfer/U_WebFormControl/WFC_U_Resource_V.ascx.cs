using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.U_WebFormControl
{
    public partial class WFC_U_Resource_V : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                /*continue*/
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }
        }

        protected void gvA1_3_SelectedIndexChanged(object sender, EventArgs e)  /*open button within the gridview*/
        {
            Label video_link = gvA1_3.SelectedRow.FindControl("labelA1_3") as Label;

            Response.Write("<script>window.open(' " + video_link.Text + " ','_blank');</script>");
        }
    }
}