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
    public partial class WFC_U_ViewResume : System.Web.UI.UserControl
    {
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

            if (!IsPostBack)/*when page loads for first time*/
            {
                buttonA1_3.Visible = false;/*upload resume button*/

                resume_pull(); /*method to check data available or not*/
            }
        }

        protected void linkbuttonA1_3_Click(object sender, EventArgs e)/*click to veiw resume*/
        {
            SqlConnection viewResume_con = null;
            SqlCommand viewResume_cmd = null;
            SqlDataReader viewResume_rdr = null;
            string check_username = null;

            try
            {
                viewResume_con = new SqlConnection();
                viewResume_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                viewResume_con.Open();

                viewResume_cmd = new SqlCommand();
                viewResume_cmd.Connection = viewResume_con;
                viewResume_cmd.CommandText = "pullResume_p";
                viewResume_cmd.CommandType = CommandType.StoredProcedure;

                viewResume_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());

                viewResume_rdr = viewResume_cmd.ExecuteReader();

                if (viewResume_rdr.HasRows)
                {
                    while (viewResume_rdr.Read())
                    {
                        check_username = viewResume_rdr.GetString(1);/*username*/

                        if (check_username != null)/*if username is available*/
                        {
                            byte[] docData = (byte[])viewResume_rdr["resume"];  /*resume pdf*/

                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", docData.Length.ToString());
                            Response.BinaryWrite(docData);
                        }
                    }
                }
            }
            catch (Exception veiwResume_exp)
            {
                Response.Write("<script>alert('veiwResume_exp Occured , Report to admin')</script>");
                Console.Write(veiwResume_exp.Message);
            }
            finally
            {
                viewResume_rdr.Close();
                viewResume_cmd.Connection.Close();
                viewResume_con.Close();
                check_username = null;
            }
        }/*end bracket of click to view link button , click event*/


        protected void resume_pull()/*check data avilability of resume first*/
        {
            SqlConnection resume_pull_con = null;
            SqlCommand resume_pull_cmd = null;
            SqlDataReader resume_pull_rdr = null;

            try
            {
                resume_pull_con = new SqlConnection();
                resume_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                resume_pull_con.Open();

                resume_pull_cmd = new SqlCommand();
                resume_pull_cmd.Connection = resume_pull_con;
                resume_pull_cmd.CommandText = "pullResume_p";
                resume_pull_cmd.CommandType = CommandType.StoredProcedure;

                resume_pull_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());

                resume_pull_rdr = resume_pull_cmd.ExecuteReader();

                if (resume_pull_rdr.HasRows)/*if username available i.e only one row must have returned,*/
                {                           /*from the unique coloumn of username*/
                    /*continue*/
                }
                else /*if username not available*/
                {
                    linkbuttonA1_3.Visible = false; /*click to view linkButton*/
                    buttonA1_3.Visible = true; /*upload resume button*/
                }
            }
            catch (Exception resume_pull_exp)
            {
                Response.Write("<script>alert('resume_pull_exp Occured , Report to admin')</script>");
                Console.Write(resume_pull_exp.Message);
            }
            finally
            {
                resume_pull_rdr.Close();
                resume_pull_cmd.Connection.Close();
                resume_pull_con.Close();
            }

        }

    }
}