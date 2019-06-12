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
    public partial class WFC_U_ProfilePage : System.Web.UI.UserControl
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rdr = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                //continue the process;

                try
                {
                    con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    con.Open();

                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "supplyData_ProfilePage_p";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@userName", Session["user"].ToString());

                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {

                        while (rdr.Read())
                        {
                            literalA_1.Text = "JobSeeker JS_123"+rdr.GetInt32(0).ToString();    //for userID on the top

                            //for profile picture
                            byte[] imagedata = (byte[])rdr["profilePicture"];
                            string image_ready = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                            imageA1_3.ImageUrl = "data:image/jpeg;base64," + image_ready;

                            labelB1_3.Text = rdr.GetString(1);  //for username
                            labelD1_3.Text = rdr.GetString(2).ToLower();  //for firstName
                            labelF1_3.Text = rdr.GetString(3).ToLower();   //for lastName
                            labelH1_3.Text = rdr.GetString(4).ToLower();  //for emailId
                            labelJ1_3.Text = rdr.GetString(5);   //for contactDetail

                            //for Member since function
                            DateTime dat_1 = rdr.GetDateTime(8); //date from database
                            DateTime dat_2 = DateTime.Now; //current date and time
                            TimeSpan time_diff = dat_2 - dat_1; //difference

                            //presentation in terms of days
                            labelL1_3.Text = (time_diff.Days > 0) ? time_diff.Days.ToString() + " day(s)" : " Today";
                        }
                    }
                    else//if condition -> rdr has no rows
                    {
                        //reader has no rows
                        literalA_1.Text = "Contact Admin";
                        labelB1_3.Text =" ";
                        labelD1_3.Text = " ";
                        labelF1_3.Text = " ";
                        labelH1_3.Text = " ";
                        labelJ1_3.Text = " ";

                    }

                }
                catch (Exception exp)
                {

                    Console.Write(exp.Message);
                }
                finally
                {
                    con.Close();
                }
            }else //if condition ->session
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                pull_messages();    /*display message count  on profile page*/

                pull_notification();   /*display notification count  on profile page*/
            }

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
                pull_messages_cmd.CommandText = "count_U_Messages_p";
                pull_messages_cmd.CommandType = CommandType.StoredProcedure;

                pull_messages_cmd.Parameters.AddWithValue("@js_username", Session["user"].ToString());

                int message_count = (int)pull_messages_cmd.ExecuteScalar();

                if(message_count > 0)
                {
                    buttonMessageA1_3.Text = "Messages " +"(" + message_count.ToString()  + ")";
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
                pull_notifications_cmd.CommandText = "count_U_Notifications_p";
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