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
    public partial class WFC_E_PostJobs : System.Web.UI.UserControl
    {
        string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };  /*for month dropdownlist*/
        static string emp_industry;   /*to store industry selected by the employer*/
        static int emp_industry_id;   /*to store industry_id */

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
                labelJ1_3.Visible = false;  /*Job Posted label*/

                pull_Industry();  /*to get industry selected by the employer */

                pull_IndustryID();  /*to get industry_ID from ddlIndustry table, using industry retrived from pull_Industry() */

                ddl_role();  /*dropdownlist(role) */

                for (int m = 0; m <= 90; m += 5)  /*dropdownlist(lakh)*/
                {
                    ListItem desired_career_profile_lakh = new ListItem(m.ToString()); /*datatext*/
                    ddlC1_3.Items.Add(desired_career_profile_lakh);
                }

                for (int n = 5; n <= 90; n += 5)/*dropdownlist(thousand)*/
                {
                    ListItem desired_career_profile_thousand = new ListItem(n.ToString()); /*datatext*/
                    ddlD1_3.Items.Add(desired_career_profile_thousand);
                }

                for (int j = 1; j <= 31; j++) /*dropdownlist(day)*/
                {
                    ListItem personal_details_day = new ListItem(j.ToString()); /*datatext*/
                    ddlE1_3.Items.Add(personal_details_day);  /*Interview Dates From_day*/
                    ddlH1_3.Items.Add(personal_details_day);  /*Interview Dates To_day*/
                }

                for (int k = 0; k <= 11; k++) /*dropdownlist(month)*/
                {
                    ListItem personal_details_month = new ListItem(month[k]); /*datatext*/
                    ddlF1_3.Items.Add(personal_details_month);  /*Interview Dates From_month*/
                    ddlI1_3.Items.Add(personal_details_month);  /*Interview Dates To_month*/
                }
            }

        }

        protected void pull_Industry()  /*to get industry selected by the employer */
        {
            SqlConnection pull_Industry_con = null;
            SqlCommand pull_Industry_cmd = null;
            SqlDataReader pull_Industry_rdr = null;

            try
            {
                pull_Industry_con = new SqlConnection();
                pull_Industry_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_Industry_con.Open();

                pull_Industry_cmd = new SqlCommand();
                pull_Industry_cmd.Connection = pull_Industry_con;
                pull_Industry_cmd.CommandText = "pull_E_Industry_p";
                pull_Industry_cmd.CommandType = CommandType.StoredProcedure;

                pull_Industry_cmd.Parameters.AddWithValue("@username",Session["employer"].ToString());

                pull_Industry_rdr = pull_Industry_cmd.ExecuteReader();

                if (pull_Industry_rdr.HasRows)
                {
                    while (pull_Industry_rdr.Read())
                    {
                        emp_industry = pull_Industry_rdr.GetString(0);   /*industry*/
                    }
                }
            }
            catch (Exception pull_Industry_exp)
            {
                Response.Write("<script>alert('Exception pull_Industry_exp . Contact Admin')</script>");
                Console.Write(pull_Industry_exp.Message);
            }
            finally
            {
                pull_Industry_rdr.Close();
                pull_Industry_cmd.Connection.Close();
                pull_Industry_con.Close();
            }

        }

        protected void pull_IndustryID()  /*to get industry_ID from ddlIndustry table, using industry retrived from pull_Industry() */
        {
            SqlConnection pull_IndustryID_con = null;
            SqlCommand pull_IndustryID_cmd = null;
            SqlDataReader pull_IndustryID_rdr = null;

            try
            {
                pull_IndustryID_con = new SqlConnection();
                pull_IndustryID_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_IndustryID_con.Open();

                pull_IndustryID_cmd = new SqlCommand();
                pull_IndustryID_cmd.Connection = pull_IndustryID_con;
                pull_IndustryID_cmd.CommandText = "pull_E_Industry_ID_p";
                pull_IndustryID_cmd.CommandType = CommandType.StoredProcedure;

                pull_IndustryID_cmd.Parameters.AddWithValue("@industry", emp_industry);

                pull_IndustryID_rdr = pull_IndustryID_cmd.ExecuteReader();

                if (pull_IndustryID_rdr.HasRows)
                {
                    while (pull_IndustryID_rdr.Read())
                    {
                        emp_industry_id = pull_IndustryID_rdr.GetInt32(0);   /*industry_id*/
                    }
                }
            }
            catch (Exception pull_IndustryID_exp)
            {
                Response.Write("<script>alert('Exception pull_IndustryID_exp . Contact Admin')</script>");
                Console.Write(pull_IndustryID_exp.Message);
            }
            finally
            {
                pull_IndustryID_rdr.Close();
                pull_IndustryID_cmd.Connection.Close();
                pull_IndustryID_con.Close();
            }
        }


        protected void ddl_role()  /*dropdownlist(role) */
        {
            ListItem select_role = new ListItem("Select Role", "0");
            SqlConnection ddl_role_con = null;
            SqlCommand ddl_role_cmd = null;
            SqlDataReader ddl_role_rdr = null;

            try
            {
                ddl_role_con = new SqlConnection();
                ddl_role_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                ddl_role_con.Open();

                ddl_role_cmd = new SqlCommand();
                ddl_role_cmd.Connection = ddl_role_con;
                ddl_role_cmd.CommandText = "ddlRole_p";
                ddl_role_cmd.CommandType = CommandType.StoredProcedure;

                ddl_role_cmd.Parameters.AddWithValue("@industryID", emp_industry_id);

                ddl_role_rdr = ddl_role_cmd.ExecuteReader();
                ddlA1_3.DataSource = ddl_role_rdr;
                ddlA1_3.Items.Clear();
                ddlA1_3.Items.Add(select_role);
                ddlA1_3.DataTextField = "role";
                ddlA1_3.DataValueField = "roleID";
                ddlA1_3.DataBind();
            }
            catch (Exception ddl_role_exp)
            {
                Response.Write("<script>alert('Exception ddl_role_exp . Contact Admin')</script>");
                Console.Write(ddl_role_exp.Message);
            }
            finally
            {
                ddl_role_rdr.Close();
                ddl_role_cmd.Connection.Close();
                ddl_role_con.Close();
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*Post Job Button*/
        {
            SqlConnection post_job_con = null;
            SqlCommand post_job_cmd = null;

            try
            {
                post_job_con = new SqlConnection();
                post_job_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                post_job_con.Open();

                post_job_cmd = new SqlCommand();
                post_job_cmd.Connection = post_job_con;
                post_job_cmd.CommandText = "save_Job_p";
                post_job_cmd.CommandType = CommandType.StoredProcedure;

                post_job_cmd.Parameters.AddWithValue("@emp_username", Session["employer"].ToString());   /*emp_username*/
                post_job_cmd.Parameters.AddWithValue("@job_role", ddlA1_3.SelectedItem.Text);   /*job_role*/
                post_job_cmd.Parameters.AddWithValue("@job_industry", emp_industry);   /*job_industry*/
                post_job_cmd.Parameters.AddWithValue("@job_title", textboxA1_3.Text.Trim());   /*job_title*/
                post_job_cmd.Parameters.AddWithValue("@job_description", textboxB1_3.Text.Trim());   /*job_description*/
                post_job_cmd.Parameters.AddWithValue("@education", ddlB1_3.SelectedItem.Text);   /*education*/
                post_job_cmd.Parameters.AddWithValue("@salary_lakh", ddlC1_3.SelectedItem.Text);   /*salary_lakh*/
                post_job_cmd.Parameters.AddWithValue("@salary_thousand", ddlD1_3.SelectedItem.Text);   /*salary_thousand*/
                post_job_cmd.Parameters.AddWithValue("@vacancy", textboxC1_3.Text.Trim());   /*vacancy*/
                post_job_cmd.Parameters.AddWithValue("@interview_from_day", ddlE1_3.SelectedItem.Text);   /*interview_from_day*/
                post_job_cmd.Parameters.AddWithValue("@interview_from_month", ddlF1_3.SelectedItem.Text);   /*interview_from_month*/
                post_job_cmd.Parameters.AddWithValue("@interview_from_year", ddlG1_3.SelectedItem.Text);   /*interview_from_year*/
                post_job_cmd.Parameters.AddWithValue("@interview_to_day", ddlH1_3.SelectedItem.Text);   /*interview_to_day*/
                post_job_cmd.Parameters.AddWithValue("@interview_to_month", ddlI1_3.SelectedItem.Text);   /*interview_to_month*/
                post_job_cmd.Parameters.AddWithValue("@interview_to_year", ddlJ1_3.SelectedItem.Text);   /*interview_to_year*/
                post_job_cmd.Parameters.AddWithValue("@posted_date", DateTime.Now);   /*posted_date*/

                int check_success = post_job_cmd.ExecuteNonQuery();

                if (check_success >= 1)
                {
                    labelJ1_3.Visible = true;  /*job posted label*/
                    disable_Controls();  /*to disabe control after successfull job posting*/
                }
                else
                {
                    Response.Write("<script>alert('Exception post_job_cmd.ExecuteNonQuery . Contact Admin')</script>");
                }

            }
            catch (Exception post_job_exp)
            {
                Response.Write("<script>alert('Exception post_job_exp . Contact Admin')</script>");
                Console.Write(post_job_exp.Message);
            }
            finally
            {
                post_job_cmd.Connection.Close();
                post_job_con.Close();
            }
        }

        protected void disable_Controls()  /*to disabe control after successfull job posting*/
        {
            ddlA1_3.Enabled = false;  /*role*/
            textboxA1_3.Enabled = false;  /*Job Title*/
            textboxB1_3.Enabled = false;  /*Job Description*/
            ddlB1_3.Enabled = false;  /*Education*/
            ddlC1_3.Enabled = false;  /*Salary lakh*/
            ddlD1_3.Enabled = false;  /*Salary thousand*/
            textboxC1_3.Enabled = false;  /*Vacancy*/
            ddlE1_3.Enabled = false;  /*Interview Dates from_day*/
            ddlF1_3.Enabled = false;  /*Interview Dates from_month*/
            ddlG1_3.Enabled = false;  /*Interview Dates from_year*/
            ddlH1_3.Enabled = false;  /*Interview Dates to_day*/
            ddlI1_3.Enabled = false;  /*Interview Dates to_month*/
            ddlJ1_3.Enabled = false;  /*Interview Dates to_year*/
            buttonA1_3.Enabled = false;  /*Post Job button*/
        }

    }
}