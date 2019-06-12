using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.E_WebFormControl
{
    public partial class WFC_E_ViewJobs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employer"] != null)//check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                int row_count = gvA1_3.Rows.Count;     /*count the number of rows present in gridview*/
                if (row_count < 1)                                  /*then based on that show Post Jobs button*/
                {
                    buttonB1_3.Visible = true;  /*Post Job button*/
                }
                else
                {
                    buttonB1_3.Visible = false;  /*Post Job button*/
                }
            }

        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*gridview button to view jobs*/
        {
            Response.Redirect("~/Employer/E_ViewJobs_Details.aspx?ID=" +  ((Button)sender).Text);  /*pulling the link from the sender object */
        }                                                                                                                                                       /*by casting and supplying it to url*/
    }
}