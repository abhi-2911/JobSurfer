using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.W_MasterPage
{
    public partial class Master_Site_1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TA_1_Tick(object sender, EventArgs e)
        {
            LblA_1.Text = DateTime.Now.ToString("F");
        }
    }
}