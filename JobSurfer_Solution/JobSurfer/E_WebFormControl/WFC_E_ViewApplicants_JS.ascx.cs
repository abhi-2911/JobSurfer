using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace JobSurfer.E_WebFormControl
{
    public partial class WFC_E_ViewApplicants_JS : System.Web.UI.UserControl
    {
        static string job_ID;   /*for storing job id from url*/

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
                job_ID = Request.QueryString["id"];   /*pulling job id fromm url*/

                buttonA1_3.Visible = false;  /*Previous Page button*/

                gridviewLoad();  /*load the gridview on the page with data*/
            }
        }

        public void gridviewLoad()  /*load the gridview on the page with data*/
        {
            SqlConnection gridviewLoad_con = null;
            SqlCommand gridviewLoad_cmd = null;
            SqlDataReader gridviewLoad_rdr = null;

            try
            {
                gridviewLoad_con = new SqlConnection();
                gridviewLoad_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                gridviewLoad_con.Open();

                gridviewLoad_cmd = new SqlCommand();
                gridviewLoad_cmd.Connection = gridviewLoad_con;
                gridviewLoad_cmd.CommandText = "pull_Jobs_Applicants_list_p";
                gridviewLoad_cmd.CommandType = CommandType.StoredProcedure;

                gridviewLoad_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(job_ID));

                gridviewLoad_rdr = gridviewLoad_cmd.ExecuteReader();

                if (gridviewLoad_rdr.HasRows)
                {
                    gvA1_3.DataSource = gridviewLoad_rdr;
                    gvA1_3.DataBind();
                }
                else
                {
                    buttonA1_3.Visible = true;  /*Previous Page button*/
                }
            }
            catch (Exception gridviewLoad_exp)
            {
                Response.Write("<script>alert('gridviewLoad_exp Occured , Report to admin')</script>");
                Console.Write(gridviewLoad_exp.Message);
            }
        }

        protected void gvA1_3_SelectedIndexChanged(object sender, EventArgs e)  /*when open(button),in the gridview is clicked*/
        {
            Label js_username = gvA1_3.SelectedRow.FindControl("labelA1_3") as Label;
            Response.Redirect("~/Employer/E_ViewApplicants_JS_Details.aspx?id=" + js_username.Text);
        }
    }
}