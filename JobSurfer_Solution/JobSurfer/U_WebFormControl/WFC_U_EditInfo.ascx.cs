using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.U_WebFormControl
{
    public partial class WFC_U_EditInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                /*continue*/
            }
            else
            {
                /*redirect*/
                Response.Redirect("~/Website/HomePage.aspx");

            }
        }
    }
}