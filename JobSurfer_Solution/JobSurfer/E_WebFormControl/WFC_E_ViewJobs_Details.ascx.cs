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
    public partial class WFC_E_ViewJobs_Details : System.Web.UI.UserControl
    {
        string emp_job_id;

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
                emp_job_id = Request.QueryString["id"];   /*pulling the job id from url*/

                pull_jobs();   /*for pulling job info from database*/

                registrationInfo_pull();  /*pull information from registration table on page load*/
            }
        }

        protected void pull_jobs()   /*for pulling job info from database*/
        {
            SqlConnection pull_jobs_con = null;
            SqlCommand pull_jobs_cmd = null;
            SqlDataReader pull_jobs_rdr = null;

            try
            {

                pull_jobs_con = new SqlConnection();
                pull_jobs_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_jobs_con.Open();

                pull_jobs_cmd = new SqlCommand();
                pull_jobs_cmd.Connection = pull_jobs_con;
                pull_jobs_cmd.CommandText = "pull_Jobs_p";
                pull_jobs_cmd.CommandType = CommandType.StoredProcedure;

                pull_jobs_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(emp_job_id));

                pull_jobs_rdr = pull_jobs_cmd.ExecuteReader();

                if (pull_jobs_rdr.HasRows)
                {
                    while (pull_jobs_rdr.Read())
                    {
                        labelA1_3.Text = pull_jobs_rdr.GetString(1);                                /*job title*/
                        labelValueE1_3.Text = pull_jobs_rdr.GetString(0);                       /*Role */
                        labelValueF1_3.Text = pull_jobs_rdr.GetString(3);                       /*education dropdownlist*/
                        labelValueG1_3.Text = pull_jobs_rdr.GetString(4) + " Lakh";                       /*salary_lakh dropdownlist*/
                        thousandValueG1_3.Text = pull_jobs_rdr.GetString(5) + " Thousand";               /*salary_thousand dropdownlist*/
                        labelValueH1_3.Text = pull_jobs_rdr.GetString(6);                       /*vacancy*/
                        fromDayI1_3.Text = pull_jobs_rdr.GetString(7);                           /*interview date from_day*/
                        fromMonthI1_3.Text = pull_jobs_rdr.GetString(8);                      /*interview date from_month*/
                        fromYearI1_3.Text = pull_jobs_rdr.GetString(9);                         /*interview date from_year*/
                        tillDayJ1_3.Text = pull_jobs_rdr.GetString(10);                          /*interview date to_day*/
                        tillMonthJ1_3.Text = pull_jobs_rdr.GetString(11);                   /*interview date to_month*/
                        tillYearJ1_3.Text = pull_jobs_rdr.GetString(12);                       /*interview date to_year*/
                        textboxK1_3.Text = pull_jobs_rdr.GetString(2);                       /*job description*/
                    }
                }

                pull_jobs_rdr.Close();
                pull_jobs_cmd.Connection.Close();
                pull_jobs_con.Close();

            }
            catch (Exception pull_jobs_exp)
            {
                Response.Write("<script>alert('Exception pull_jobs_exp . Contact Admin')</script>");
                Console.Write(pull_jobs_exp.Message);
            }
        }

        protected void registrationInfo_pull()  /*pull information from registration table on page load*/
        {
            try
            {
                SqlConnection registrationInfo_pull_con = new SqlConnection();
                registrationInfo_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                registrationInfo_pull_con.Open();

                SqlCommand registrationInfo_pull_cmd = new SqlCommand();
                registrationInfo_pull_cmd.Connection = registrationInfo_pull_con;
                registrationInfo_pull_cmd.CommandText = "pull_E_RegistrationInfo_p";
                registrationInfo_pull_cmd.CommandType = CommandType.StoredProcedure;

                registrationInfo_pull_cmd.Parameters.AddWithValue("@username", Session["employer"].ToString());

                SqlDataReader registrationInfo_pull_rdr = registrationInfo_pull_cmd.ExecuteReader();

                if (registrationInfo_pull_rdr.HasRows)
                {
                    while (registrationInfo_pull_rdr.Read())
                    {
                        labelValueB1_3.Text = registrationInfo_pull_rdr.GetString(5);  /*Company*/
                        labelValueC_13.Text = registrationInfo_pull_rdr.GetString(7);  /*State*/
                        labelValueD1_3.Text = registrationInfo_pull_rdr.GetString(8);  /*City*/
                    }
                }

                registrationInfo_pull_rdr.Close();
                registrationInfo_pull_cmd.Connection.Close();
                registrationInfo_pull_con.Close();
            }
            catch (Exception registrationInfo_pull_exp)
            {
                Response.Write("<script>alert('Exception registrationInfo_pull_exp . Contact Admin')</script>");
                Console.Write(registrationInfo_pull_exp.Message);
            }
        }

    }
}