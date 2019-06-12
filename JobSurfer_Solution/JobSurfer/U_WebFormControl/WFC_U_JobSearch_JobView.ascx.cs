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
    public partial class WFC_U_JobSearch_JobView : System.Web.UI.UserControl
    {
        static string JOB_id;
        static string EMP_username;

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
                buttonB1_3.Visible = false;   /*cancel button*/

                JOB_id = Request.QueryString["id"];   /*pulling the job id from url*/

                pull_jobs();   /*for pulling job info from database*/

                registrationInfo_pull();  /*pull information from employer_registration table on page load*/

                pull_jobApplication();   /*check if data is present in job application table, then either apply or cancel button*/

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

        protected void pull_jobApplication()   /*check if data is present in job application table, then either apply or cancel button*/
        {
            SqlConnection pull_jobApplication_con = null;
            SqlCommand pull_jobApplication_cmd = null;

            try
            {
                pull_jobApplication_con = new SqlConnection();
                pull_jobApplication_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_jobApplication_con.Open();

                pull_jobApplication_cmd = new SqlCommand();
                pull_jobApplication_cmd.Connection = pull_jobApplication_con;
                pull_jobApplication_cmd.CommandText = "pullJobsApplication_p";
                pull_jobApplication_cmd.CommandType = CommandType.StoredProcedure;

                pull_jobApplication_cmd.Parameters.AddWithValue("@js_username", Session["user"].ToString());
                pull_jobApplication_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(JOB_id));

                int check_success = Convert.ToInt32(pull_jobApplication_cmd.ExecuteScalar());

                if (check_success == 1)   /*data saved to table*/
                {
                    buttonA1_3.Visible = false;   /*apply button*/
                    buttonB1_3.Visible = true;   /*cancel button*/
                }
                else   /*retry to save data to table*/
                {
                   /*continue*/
                }
            }
            catch (Exception pull_jobApplication_exp)
            {
                Response.Write("<script>alert('pull_jobApplication_exp Occured , Report to admin')</script>");
                Console.Write(pull_jobApplication_exp.Message);
            }
            finally
            {
                pull_jobApplication_cmd.Connection.Close();
                pull_jobApplication_con.Close();
            }
        }


        protected void buttonA1_3_Click(object sender, EventArgs e)  /*apply button, save data to jobs_application table*/
        {
            SqlConnection apply_con = null;
            SqlCommand apply_cmd = null;

            try
            {
                apply_con = new SqlConnection();
                apply_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                apply_con.Open();

                apply_cmd = new SqlCommand();
                apply_cmd.Connection = apply_con;
                apply_cmd.CommandText = "saveJobsApplication_p";
                apply_cmd.CommandType = CommandType.StoredProcedure;

                apply_cmd.Parameters.AddWithValue("@js_username", Session["user"].ToString());
                apply_cmd.Parameters.AddWithValue("@job_id", Convert.ToInt32(JOB_id));

               int check_success =  apply_cmd.ExecuteNonQuery();

                if (check_success >= 1)   /*data saved to table*/
                {
                    buttonA1_3.Visible = false;   /*apply button*/
                    buttonB1_3.Visible = true;   /*cancel button*/
                    Response.Redirect("~/User/U_JobSearch_Table.aspx");   /*because when back button on browser pressed it shows apply again*/
                }
                else   /*retry to save data to table*/
                {
                    Response.Write("<script>alert('apply_cmd.ExecuteNonQuery Occured , Report to admin')</script>");
                }
            }
            catch (Exception apply_exp)
            {
                Response.Write("<script>alert('apply_exp Occured , Report to admin')</script>");
                Console.Write(apply_exp.Message);
            }
            finally
            {
                apply_cmd.Connection.Close();
                apply_con.Close();
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
                    buttonA1_3.Visible = true;   /*apply button*/
                    buttonB1_3.Visible = false;   /*cancel button*/
                    Response.Redirect("~/User/U_JobSearch_Table.aspx");   /*because when back button on browser pressed it shows cancel again*/
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