using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.A_MasterPage
{
    public partial class Master_Site_4 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void timerA_1_Tick(object sender, EventArgs e) /*timer*/
        {
            labelA_1.Text = DateTime.Now.ToString("F");
        }

        protected void buttonA1_1_Click(object sender, EventArgs e)  /*admin button*/
        {
            Response.Redirect("~/Admin/A_FrontPage.aspx");
        }
    }
}