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
    public partial class WFC_E_ProfilePage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["employer"] != null)//check for valid user 
            {
                //continue

                SqlConnection emp_profile_con = null;
                SqlCommand emp_profile_cmd = null;
                SqlDataReader emp_profile_rdr = null;

                try
                {
                    emp_profile_con = new SqlConnection();
                    emp_profile_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    emp_profile_con.Open();

                    emp_profile_cmd = new SqlCommand();
                    emp_profile_cmd.Connection = emp_profile_con;
                    emp_profile_cmd.CommandText = "supplyData_E_ProfilePage_p";
                    emp_profile_cmd.CommandType = CommandType.StoredProcedure;

                    emp_profile_cmd.Parameters.AddWithValue("@userName", Session["employer"].ToString());

                    emp_profile_rdr = emp_profile_cmd.ExecuteReader();

                    if (emp_profile_rdr.HasRows)
                    {
                        while (emp_profile_rdr.Read())
                        {
                            /*for emp id in emp name box*/
                            literalA_1.Text = "Employer Emp_321" + emp_profile_rdr.GetInt32(0).ToString();

                            /*for emp profile pictuer*/
                            byte[] imagedata = (byte[])emp_profile_rdr["profilePicture"];
                            string image_ready = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                            imageA1_3.ImageUrl = "data:image/jpeg;base64," + image_ready;

                            labelB1_3.Text = emp_profile_rdr.GetString(1); /*username*/
                            labelD1_3.Text = emp_profile_rdr.GetString(2); /*firstName*/
                            labelF1_3.Text = emp_profile_rdr.GetString(3); /*lastName*/
                            labelH1_3.Text = emp_profile_rdr.GetString(4); /*designation*/
                            labelJ1_3.Text = emp_profile_rdr.GetString(5); /*company Name*/
                            labelL1_3.Text = emp_profile_rdr.GetString(6); /*email id*/
                            labelN1_3.Text = emp_profile_rdr.GetString(7); /*state*/
                            labelP1_3.Text = emp_profile_rdr.GetString(8); /*city*/
                            labelR1_3.Text = emp_profile_rdr.GetString(9); /*industry*/
                            labelT1_3.Text = emp_profile_rdr.GetString(11); /*contact number*/

                            //for Member since function
                            DateTime dat_1 = emp_profile_rdr.GetDateTime(14); //date from database
                            DateTime dat_2 = DateTime.Now; //current date and time
                            TimeSpan time_diff = dat_2 - dat_1; //difference

                            //presentation in terms of days
                            labelV1_3.Text = (time_diff.Days > 0) ? time_diff.Days.ToString() + " day(s)" : " Today";

                        }
                    }
                }
                catch (Exception emp_profile_exp)
                {
                    Response.Write("<script>alert('Exception emp_profile_exp Occured , Report this to admin')</script>");
                    Console.Write(emp_profile_exp.Message);
                }
                finally
                {
                    emp_profile_rdr.Close();
                    emp_profile_cmd.Connection.Close();
                    emp_profile_con.Close();
                }

            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            pull_messages();    /*display message count  on profile page*/

            pull_notification();    /*display notification count  on profile page*/

        }

        protected void pull_messages()    /*display message count  on profile page*/
        {
            SqlConnection pull_messages_con = null;
            SqlCommand pull_messages_cmd = null;

            try
            {

                pull_messages_con = new SqlConnection();
                pull_messages_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_messages_con.Open();

                pull_messages_cmd = new SqlCommand();
                pull_messages_cmd.Connection = pull_messages_con;
                pull_messages_cmd.CommandText = "count_EMP_Messages_p";
                pull_messages_cmd.CommandType = CommandType.StoredProcedure;

                pull_messages_cmd.Parameters.AddWithValue("@username", Session["employer"].ToString());

                int message_count = (int)pull_messages_cmd.ExecuteScalar();

                if (message_count > 0)
                {
                    buttonMessageA1_3.Text = "Messages " + "(" + message_count.ToString() + ")";
                }
                else
                {
                    buttonMessageA1_3.Text = "Messages ";
                }

                pull_messages_cmd.Connection.Close();
                pull_messages_con.Close();

            }
            catch (Exception pull_messages_exp)
            {
                Response.Write("<script>alert('Exception pull_messages_exp . Contact Admin')</script>");
                Console.Write(pull_messages_exp.Message);
            }
        }


        protected void pull_notification()    /*display notification count  on profile page*/
        {
            SqlConnection pull_notifications_con = null;
            SqlCommand pull_notifications_cmd = null;

            try
            {

                pull_notifications_con = new SqlConnection();
                pull_notifications_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_notifications_con.Open();

                pull_notifications_cmd = new SqlCommand();
                pull_notifications_cmd.Connection = pull_notifications_con;
                pull_notifications_cmd.CommandText = "count_EMP_Notifications_p";
                pull_notifications_cmd.CommandType = CommandType.StoredProcedure;

                int notification_count = (int)pull_notifications_cmd.ExecuteScalar();

                if (notification_count > 0)
                {
                    buttonNotificationA1_3.Text = "Notifications " + "(" + notification_count.ToString() + ")";
                }
                else
                {
                    buttonNotificationA1_3.Text = "Notifications ";
                }

                pull_notifications_cmd.Connection.Close();
                pull_notifications_con.Close();

            }
            catch (Exception pull_notifications_exp)
            {
                Response.Write("<script>alert('Exception pull_notifications_exp . Contact Admin')</script>");
                Console.Write(pull_notifications_exp.Message);
            }
        }

    }
}