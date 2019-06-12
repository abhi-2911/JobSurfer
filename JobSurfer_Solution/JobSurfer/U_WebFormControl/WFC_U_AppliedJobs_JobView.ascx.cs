using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace JobSurfer.U_WebFormControl
{
    public partial class WFC_U_AppliedJobs_JobView : System.Web.UI.UserControl
    {
        static string JOB_id;   /*stores job_id from url*/
        static string EMP_username;   /*stores employer username from Jobs table, using pull_jobs()*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)//check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                JOB_id = Request.QueryString["id"];   /*pulling the job id from url*/

                pull_jobs();   /*for pulling job info from database*/

                registrationInfo_pull();  /*pull information from employer_registration table on page load*/

                emp_Video_pull();  /*pull the emp_compnay_video url from database*/
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
                pull_jobs_cmd.CommandText = "supplyData_U_Jobs_p";
                pull_jobs_cmd.CommandType = CommandType.StoredProcedure;

                pull_jobs_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(JOB_id));

                pull_jobs_rdr = pull_jobs_cmd.ExecuteReader();

                if (pull_jobs_rdr.HasRows)
                {
                    while (pull_jobs_rdr.Read())
                    {
                        EMP_username = pull_jobs_rdr.GetString(0);                              /*supply employer user name*/

                        labelA1_3.Text = pull_jobs_rdr.GetString(2);                                /*job title*/
                        labelValueE1_3.Text = pull_jobs_rdr.GetString(1);                       /*Role */
                        labelValueF1_3.Text = pull_jobs_rdr.GetString(4);                       /*education dropdownlist*/
                        labelValueG1_3.Text = pull_jobs_rdr.GetString(5) + " Lakh";                       /*salary_lakh dropdownlist*/
                        thousandValueG1_3.Text = pull_jobs_rdr.GetString(6) + " Thousand";               /*salary_thousand dropdownlist*/
                        labelValueH1_3.Text = pull_jobs_rdr.GetString(7);                       /*vacancy*/
                        fromDayI1_3.Text = pull_jobs_rdr.GetString(8);                           /*interview date from_day*/
                        fromMonthI1_3.Text = pull_jobs_rdr.GetString(9);                      /*interview date from_month*/
                        fromYearI1_3.Text = pull_jobs_rdr.GetString(10);                         /*interview date from_year*/
                        tillDayJ1_3.Text = pull_jobs_rdr.GetString(11);                          /*interview date to_day*/
                        tillMonthJ1_3.Text = pull_jobs_rdr.GetString(12);                   /*interview date to_month*/
                        tillYearJ1_3.Text = pull_jobs_rdr.GetString(13);                       /*interview date to_year*/
                        textboxK1_3.Text = pull_jobs_rdr.GetString(3);                       /*job description*/
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

                registrationInfo_pull_cmd.Parameters.AddWithValue("@username", EMP_username);

                SqlDataReader registrationInfo_pull_rdr = registrationInfo_pull_cmd.ExecuteReader();

                if (registrationInfo_pull_rdr.HasRows)
                {
                    while (registrationInfo_pull_rdr.Read())
                    {
                        /*employee profile image*/
                        byte[] imagedata = (byte[])registrationInfo_pull_rdr["profilePicture"];
                        string image_ready = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                        imageA1_3.ImageUrl = "data:image/jpeg;base64," + image_ready;

                        labelValueM1_3.Text = registrationInfo_pull_rdr.GetString(2);   /*emp name*/
                        labelValueN1_3.Text = registrationInfo_pull_rdr.GetString(4);   /*emp designation*/
                        labelValueO1_3.Text = registrationInfo_pull_rdr.GetString(11);   /*emp Contact Number*/
                        labelValueP1_3.Text = registrationInfo_pull_rdr.GetString(6);   /*emp Email ID*/
                        textboxR1_3.Text = registrationInfo_pull_rdr.GetString(10);   /*emp Company Address*/
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

        protected void emp_Video_pull()  /*pull employer company video info from emp_Video table*/
        {
            SqlConnection emp_Video_pull_con = null;
            SqlCommand emp_Video_pull_cmd = null;
            SqlDataReader emp_Video_pull_rdr = null;

            try
            {
                emp_Video_pull_con = new SqlConnection();
                emp_Video_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                emp_Video_pull_con.Open();

                emp_Video_pull_cmd = new SqlCommand();
                emp_Video_pull_cmd.Connection = emp_Video_pull_con;
                emp_Video_pull_cmd.CommandText = "pull_E_Video_p";
                emp_Video_pull_cmd.CommandType = CommandType.StoredProcedure;

                emp_Video_pull_cmd.Parameters.AddWithValue("@username", EMP_username);

                emp_Video_pull_rdr = emp_Video_pull_cmd.ExecuteReader();

                if (emp_Video_pull_rdr.HasRows)
                {
                    while (emp_Video_pull_rdr.Read())
                    {
                        buttonQ1_3.PostBackUrl = emp_Video_pull_rdr.GetString(2);  /*companyVideo*/
                    }
                }
            }
            catch (Exception emp_Video_pull_exp)
            {
                Response.Write("<script>alert('emp_Video_pull_exp Occured , Report to admin')</script>");
                Console.Write(emp_Video_pull_exp.Message);
            }
            finally
            {
                emp_Video_pull_rdr.Close();
                emp_Video_pull_cmd.Connection.Close();
                emp_Video_pull_con.Close();
            }
        }

        protected void buttonB1_3_Click(object sender, EventArgs e)   /*cancel button, delete data in jobs_application table*/
        {
            SqlConnection cancel_con = null;
            SqlCommand cancel_cmd = null;

            try
            {
                cancel_con = new SqlConnection();
                cancel_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                cancel_con.Open();

                cancel_cmd = new SqlCommand();
                cancel_cmd.Connection = cancel_con;
                cancel_cmd.CommandText = "deleteJobApplication_p";
                cancel_cmd.CommandType = CommandType.StoredProcedure;

                cancel_cmd.Parameters.AddWithValue("@js_username", Session["user"].ToString());
                cancel_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(JOB_id));

                int check_success = cancel_cmd.ExecuteNonQuery();

                if (check_success >= 1)   /*data deleted from table*/
                {
                    buttonB1_3.Enabled = false;   /*cancel button*/
                    Response.Redirect("~/User/U_AppliedJobs.aspx");   /*because if job is cancelled then it should not exist in applied jobs*/
                }
                else   /*retry to delete data in table*/
                {
                    Response.Write("<script>alert('cancel_cmd.ExecuteNonQuery Occured , Report to admin')</script>");
                }
            }
            catch (Exception cancel_exp)
            {
                Response.Write("<script>alert('cancel_exp Occured , Report to admin')</script>");
                Console.Write(cancel_exp.Message);
            }
            finally
            {
                cancel_cmd.Connection.Close();
                cancel_con.Close();
            }
        }
    }
}