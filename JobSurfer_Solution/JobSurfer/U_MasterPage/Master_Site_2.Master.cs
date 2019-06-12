using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.U_MasterPage
{
    public partial class Master_Site_2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void timerA_1_Tick(object sender, EventArgs e)
        {
            labelA_1.Text = DateTime.Now.ToString("F");
        }

        protected void buttonI1_1_Click(object sender, EventArgs e) /*logout button*/
        {
            Session.Remove("user");
            Session.Remove("industry"); /*created at job search page*/
            Session.Remove("role"); /*created at job search page*/
            Response.Redirect("~/Website/HomePage.aspx");
        }


    }
}