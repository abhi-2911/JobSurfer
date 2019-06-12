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
    public partial class WFC_E_UpdateJobs : System.Web.UI.UserControl
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
                ddl_jobID();  /*dropdownlist(JOB_ID) */
            }

        }

        protected void ddl_jobID()  /*dropdownlist(JOB_ID) */
        {
            ListItem select_jobID = new ListItem("Select Job_ID", "Select Job_ID");
            SqlConnection ddl_jobID_con = null;
            SqlCommand ddl_jobID_cmd = null;
            SqlDataReader ddl_jobID_rdr = null;

            try
            {
                ddl_jobID_con = new SqlConnection();
                ddl_jobID_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                ddl_jobID_con.Open();

                ddl_jobID_cmd = new SqlCommand();
                ddl_jobID_cmd.Connection = ddl_jobID_con;
                ddl_jobID_cmd.CommandText = "supplyData_E_JobID_p";
                ddl_jobID_cmd.CommandType = CommandType.StoredProcedure;

                ddl_jobID_cmd.Parameters.AddWithValue("@emp_username", Session["employer"].ToString());

                ddl_jobID_rdr = ddl_jobID_cmd.ExecuteReader();
                ddlA1_3.DataSource = ddl_jobID_rdr;
                ddlA1_3.Items.Clear();
                ddlA1_3.Items.Add(select_jobID);
                ddlA1_3.DataTextField = "job_id";
                ddlA1_3.DataBind();
            }
            catch (Exception ddl_jobID_exp)
            {
                Response.Write("<script>alert('Exception ddl_jobID_exp . Contact Admin')</script>");
                Console.Write(ddl_jobID_exp.Message);
            }
            finally
            {
                ddl_jobID_rdr.Close();
                ddl_jobID_cmd.Connection.Close();
                ddl_jobID_con.Close();
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*Edit button*/
        {
            Session["emp_job_id"] = ddlA1_3.SelectedItem.Text;  /*Job_ID from dropdownlist*/
            Response.Redirect("~/Employer/E_UpdateJobs_Edit.aspx");
        }
    }
}