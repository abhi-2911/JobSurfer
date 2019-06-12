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
    public partial class WFC_A_Notification_R_Js : System.Web.UI.UserControl
    {
        static int check_notificationID_flag;    /*for storing value returned by executeScalar*/

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
                check_notificationID_flag = 0;  /*initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)   /*for checking , wheather correct*/
        {                                                                                                                                               /* Message ID is entered*/
            SqlConnection js_notificationID_check_con;
            SqlCommand js_notificationID_check_cmd;

            try
            {
                js_notificationID_check_con = new SqlConnection();
                js_notificationID_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                js_notificationID_check_con.Open();

                js_notificationID_check_cmd = new SqlCommand();
                js_notificationID_check_cmd.Connection = js_notificationID_check_con;
                js_notificationID_check_cmd.CommandText = "check_JSnotificationID_A_p";
                js_notificationID_check_cmd.CommandType = CommandType.StoredProcedure;

                js_notificationID_check_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));  /*provided value to parameter*/

                check_notificationID_flag = Convert.ToInt32(js_notificationID_check_cmd.ExecuteScalar());

                if (check_notificationID_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is incorrect*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Notification ID Incorrect')</script>");
                }
                js_notificationID_check_cmd.Connection.Close();
                js_notificationID_check_con.Close();
            }
            catch (Exception js_notificationID_check_exp)
            {
                Response.Write("<script>alert('js_notificationID_check_exp Occured , Report to admin')</script>");
                Console.Write(js_notificationID_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*remove button is clicked*/
        {
            SqlConnection delete_js_notification_con = null;
            SqlCommand delete_js_notification_cmd = null;

            if (check_notificationID_flag == 1)    /*message id correct*/
            {
                try
                {
                    delete_js_notification_con = new SqlConnection();
                    delete_js_notification_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_js_notification_con.Open();

                    delete_js_notification_cmd = new SqlCommand();
                    delete_js_notification_cmd.Connection = delete_js_notification_con;
                    delete_js_notification_cmd.CommandText = "delete_JSnotifications_A_p";
                    delete_js_notification_cmd.CommandType = CommandType.StoredProcedure;

                    delete_js_notification_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));

                    int check_success = delete_js_notification_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*js notification id textbox*/
                    }
                    else
                    {
                        Response.Write("<script>alert('Exception delete_js_notification_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_js_notification_exp)
                {
                    Response.Write("<script>alert('Exception delete_js_notification_exp . Contact Admin')</script>");
                    Console.Write(delete_js_notification_exp.Message);
                }
                finally
                {
                    delete_js_notification_cmd.Connection.Close();
                    delete_js_notification_con.Close();
                }
            }
        }


    }
}