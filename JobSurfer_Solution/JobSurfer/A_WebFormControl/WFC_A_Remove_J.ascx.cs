using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace JobSurfer.A_WebFormControl
{
    public partial class WFC_A_Remove_J : System.Web.UI.UserControl
    {
        static int check_jobID_flag;    /*for storing value returned by executeScalar*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                /*continue*/
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                check_jobID_flag = 0;   /*initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)     /*for checking , wheather correct*/
        {                                                                                                                                                 /* jobID is entered*/
            SqlConnection job_id_check_con;
            SqlCommand job_id_check_cmd;

            try
            {
                job_id_check_con = new SqlConnection();
                job_id_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                job_id_check_con.Open();

                job_id_check_cmd = new SqlCommand();
                job_id_check_cmd.Connection = job_id_check_con;
                job_id_check_cmd.CommandText = "check_jobID_A_p";
                job_id_check_cmd.CommandType = CommandType.StoredProcedure;

                job_id_check_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(textboxA1_3.Text.Trim()));      /*provided value to parameter*/

                check_jobID_flag = Convert.ToInt32(job_id_check_cmd.ExecuteScalar());

                if (check_jobID_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is correct*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Job ID Incorrect')</script>");
                }
                job_id_check_cmd.Connection.Close();
                job_id_check_con.Close();
            }
            catch (Exception job_id_check_exp)
            {
                Response.Write("<script>alert('job_id_check_exp Occured , Report to admin')</script>");
                Console.Write(job_id_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*delete button*/
        {
            SqlConnection delete_j_con = null;
            SqlCommand delete_j_cmd = null;

            if (check_jobID_flag == 1)    /*username correct*/
            {
                try
                {
                    delete_j_con = new SqlConnection();
                    delete_j_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_j_con.Open();

                    delete_j_cmd = new SqlCommand();
                    delete_j_cmd.Connection = delete_j_con;
                    delete_j_cmd.CommandText = "delete_Job_p";
                    delete_j_cmd.CommandType = CommandType.StoredProcedure;

                    delete_j_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(textboxA1_3.Text.Trim()));

                    int check_success = delete_j_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*jobID  textbox*/
                        Response.Redirect("~/Admin/A_Remove_J.aspx");   /*important to refresh orelse previous */
                    }                                                                                              /* is used and button_click function starts again */
                    else
                    {
                        Response.Write("<script>alert('Exception delete_j_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_j_exp)
                {
                    Response.Write("<script>alert('Exception delete_j_exp . Contact Admin')</script>");
                    Console.Write(delete_j_exp.Message);
                }
                finally
                {
                    delete_j_cmd.Connection.Close();
                    delete_j_con.Close();
                }
            }
        }


    }
}