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
    public partial class WFC_A_Message_R_Em : System.Web.UI.UserControl
    {
        static int check_messageID_flag;    /*for storing value returned by executeScalar*/

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
                check_messageID_flag = 0;  /*initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)  /*for checking , wheather correct*/
        {                                                                                                                                               /* Message ID is entered*/
            SqlConnection emp_messageID_check_con;
            SqlCommand emp_messageID_check_cmd;

            try
            {
                emp_messageID_check_con = new SqlConnection();
                emp_messageID_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                emp_messageID_check_con.Open();

                emp_messageID_check_cmd = new SqlCommand();
                emp_messageID_check_cmd.Connection = emp_messageID_check_con;
                emp_messageID_check_cmd.CommandText = "check_EMP_messageID_A_p";
                emp_messageID_check_cmd.CommandType = CommandType.StoredProcedure;

                emp_messageID_check_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));  /*provided value to parameter*/

                check_messageID_flag = Convert.ToInt32(emp_messageID_check_cmd.ExecuteScalar());

                if (check_messageID_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is incorrect*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Message ID Incorrect')</script>");
                }
                emp_messageID_check_cmd.Connection.Close();
                emp_messageID_check_con.Close();
            }
            catch (Exception emp_messageID_check_exp)
            {
                Response.Write("<script>alert('emp_messageID_check_exp Occured , Report to admin')</script>");
                Console.Write(emp_messageID_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)     /*remove button*/
        {
            SqlConnection delete_emp_message_con = null;
            SqlCommand delete_emp_message_cmd = null;

            if (check_messageID_flag == 1)    /*message id correct*/
            {
                try
                {
                    delete_emp_message_con = new SqlConnection();
                    delete_emp_message_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_emp_message_con.Open();

                    delete_emp_message_cmd = new SqlCommand();
                    delete_emp_message_cmd.Connection = delete_emp_message_con;
                    delete_emp_message_cmd.CommandText = "delete_EMP_messageID_A_p";
                    delete_emp_message_cmd.CommandType = CommandType.StoredProcedure;

                    delete_emp_message_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));

                    int check_success = delete_emp_message_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*emp message id textbox*/

                    }
                    else
                    {
                        Response.Write("<script>alert('Exception delete_emp_message_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_emp_message_exp)
                {
                    Response.Write("<script>alert('Exception delete_emp_message_exp . Contact Admin')</script>");
                    Console.Write(delete_emp_message_exp.Message);
                }
                finally
                {
                    delete_emp_message_cmd.Connection.Close();
                    delete_emp_message_con.Close();
                }
            }
        }

    }
}