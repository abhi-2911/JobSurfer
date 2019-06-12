using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.E_MasterPage
{
    public partial class Master_Site_3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void timerA_1_Tick(object sender, EventArgs e) /*timer*/
        {
            labelA_1.Text = DateTime.Now.ToString("F");
        }

        protected void buttonJ1_1_Click(object sender, EventArgs e) /*logout button*/
        {
            Session.Remove("employer");
            Session.Remove("emp_job_id");   /*created after selecting job_id at edit_job*/
            Response.Redirect("~/Website/HomePage.aspx");
        }
    }
}