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
    public partial class WFC_A_Resources_Del_Vid_J : System.Web.UI.UserControl
    {
        static int check_videoID_flag;    /*for storing value returned by executeScalar*/

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
                check_videoID_flag = 0;  /*initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)   /*for checking , whether correct*/
        {                                                                                                                                                       /* Video ID is entered*/
            SqlConnection videoID_check_con;
            SqlCommand videoID_check_cmd;

            try
            {
                videoID_check_con = new SqlConnection();
                videoID_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                videoID_check_con.Open();

                videoID_check_cmd = new SqlCommand();
                videoID_check_cmd.Connection = videoID_check_con;
                videoID_check_cmd.CommandText = "check_JS_videoResource_ID";
                videoID_check_cmd.CommandType = CommandType.StoredProcedure;

                videoID_check_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));  /*provided value to parameter*/

                check_videoID_flag = Convert.ToInt32(videoID_check_cmd.ExecuteScalar());

                if (check_videoID_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is incorrect*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Video ID Incorrect')</script>");
                }
                videoID_check_cmd.Connection.Close();
                videoID_check_con.Close();
            }
            catch (Exception videoID_check_exp)
            {
                Response.Write("<script>alert('videoID_check_exp Occured , Report to admin')</script>");
                Console.Write(videoID_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*remove button is clicked*/
        {
            SqlConnection delete_videoResource_con = null;
            SqlCommand delete_videoResource_cmd = null;

            if (check_videoID_flag == 1)    /*video id correct*/
            {
                try
                {
                    delete_videoResource_con = new SqlConnection();
                    delete_videoResource_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_videoResource_con.Open();

                    delete_videoResource_cmd = new SqlCommand();
                    delete_videoResource_cmd.Connection = delete_videoResource_con;
                    delete_videoResource_cmd.CommandText = "delete_JS_videoResource_ID";
                    delete_videoResource_cmd.CommandType = CommandType.StoredProcedure;

                    delete_videoResource_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));

                    int check_success = delete_videoResource_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*video id textbox*/
                    }
                    else
                    {
                        Response.Write("<script>alert('Exception  delete_videoResource_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_videoResource_exp)
                {
                    Response.Write("<script>alert('Exception delete_videoResource_exp . Contact Admin')</script>");
                    Console.Write(delete_videoResource_exp.Message);
                }
                finally
                {
                    delete_videoResource_cmd.Connection.Close();
                    delete_videoResource_con.Close();
                }
            }
        }


    }
}