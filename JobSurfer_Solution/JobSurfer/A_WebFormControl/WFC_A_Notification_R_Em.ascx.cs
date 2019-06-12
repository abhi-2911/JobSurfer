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
    public partial class WFC_A_Notification_R_Em : System.Web.UI.UserControl
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
            SqlConnection emp_notificationID_check_con;
            SqlCommand emp_notificationID_check_cmd;

            try
            {
                emp_notificationID_check_con = new SqlConnection();
                emp_notificationID_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                emp_notificationID_check_con.Open();

                emp_notificationID_check_cmd = new SqlCommand();
                emp_notificationID_check_cmd.Connection = emp_notificationID_check_con;
                emp_notificationID_check_cmd.CommandText = "check_EMPnotificationID_A_p";
                emp_notificationID_check_cmd.CommandType = CommandType.StoredProcedure;

                emp_notificationID_check_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));  /*provided value to parameter*/

                check_notificationID_flag = Convert.ToInt32(emp_notificationID_check_cmd.ExecuteScalar());

                if (check_notificationID_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is incorrect*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Notification ID Incorrect')</script>");
                }
                emp_notificationID_check_cmd.Connection.Close();
                emp_notificationID_check_con.Close();
            }
            catch (Exception emp_notificationID_check_exp)
            {
                Response.Write("<script>alert('emp_notificationID_check_exp Occured , Report to admin')</script>");
                Console.Write(emp_notificationID_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*remove button is clicked*/
        {
            SqlConnection delete_emp_notification_con = null;
            SqlCommand delete_emp_notification_cmd = null;

            if (check_notificationID_flag == 1)    /*message id correct*/
            {
                try
                {
                    delete_emp_notification_con = new SqlConnection();
                    delete_emp_notification_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_emp_notification_con.Open();

                    delete_emp_notification_cmd = new SqlCommand();
                    delete_emp_notification_cmd.Connection = delete_emp_notification_con;
                    delete_emp_notification_cmd.CommandText = "delete_EMPnotifications_A_p";
                    delete_emp_notification_cmd.CommandType = CommandType.StoredProcedure;

                    delete_emp_notification_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));

                    int check_success = delete_emp_notification_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*js notification id textbox*/
                    }
                    else
                    {
                        Response.Write("<script>alert('Exception delete_emp_notification_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_emp_notification_exp)
                {
                    Response.Write("<script>alert('Exception delete_emp_notification_exp . Contact Admin')</script>");
                    Console.Write(delete_emp_notification_exp.Message);
                }
                finally
                {
                    delete_emp_notification_cmd.Connection.Close();
                    delete_emp_notification_con.Close();
                }
            }
        }

    }
}