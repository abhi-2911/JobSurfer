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
    public partial class WFC_A_Message_R_Js : System.Web.UI.UserControl
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
            SqlConnection js_messageID_check_con;
            SqlCommand js_messageID_check_cmd;

            try
            {
                js_messageID_check_con = new SqlConnection();
                js_messageID_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                js_messageID_check_con.Open();

                js_messageID_check_cmd = new SqlCommand();
                js_messageID_check_cmd.Connection = js_messageID_check_con;
                js_messageID_check_cmd.CommandText = "check_messageID_A_p";
                js_messageID_check_cmd.CommandType = CommandType.StoredProcedure;

                js_messageID_check_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));  /*provided value to parameter*/

                check_messageID_flag = Convert.ToInt32(js_messageID_check_cmd.ExecuteScalar());

                if (check_messageID_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is incorrect*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Message ID Incorrect')</script>");
                }
                js_messageID_check_cmd.Connection.Close();
                js_messageID_check_con.Close();
            }
            catch (Exception js_messageID_check_exp)
            {
                Response.Write("<script>alert('js_messageID_check_exp Occured , Report to admin')</script>");
                Console.Write(js_messageID_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)     /*remove button*/
        {
            SqlConnection delete_js_message_con = null;
            SqlCommand delete_js_message_cmd = null;

            if (check_messageID_flag == 1)    /*message id correct*/
            {
                try
                {
                    delete_js_message_con = new SqlConnection();
                    delete_js_message_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_js_message_con.Open();

                    delete_js_message_cmd = new SqlCommand();
                    delete_js_message_cmd.Connection = delete_js_message_con;
                    delete_js_message_cmd.CommandText = "delete_JS_message_A_p";
                    delete_js_message_cmd.CommandType = CommandType.StoredProcedure;

                    delete_js_message_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));

                    int check_success = delete_js_message_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*js message id textbox*/
                        
                    }                                                                                              
                    else
                    {
                        Response.Write("<script>alert('Exception delete_js_message_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_js_message_exp)
                {
                    Response.Write("<script>alert('Exception delete_js_message_exp . Contact Admin')</script>");
                    Console.Write(delete_js_message_exp.Message);
                }
                finally
                {
                    delete_js_message_cmd.Connection.Close();
                    delete_js_message_con.Close();
                }
            }
        }

    }
}