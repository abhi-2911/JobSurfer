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
    public partial class WFC_A_Message_S_Js : System.Web.UI.UserControl
    {
        static int check_username_flag;    /*for storing value returned by executeScalar*/

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
                labelD1_3.Visible = false;  /*Message sent Label*/

                check_username_flag = 0;  /*initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)   /*for checking , wheather correct*/
        {                                                                                                                                               /* username is entered*/
            SqlConnection js_username_check_con;
            SqlCommand js_username_check_cmd;

            try
            {
                js_username_check_con = new SqlConnection();
                js_username_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                js_username_check_con.Open();

                js_username_check_cmd = new SqlCommand();
                js_username_check_cmd.Connection = js_username_check_con;
                js_username_check_cmd.CommandText = "username_check_p";
                js_username_check_cmd.CommandType = CommandType.StoredProcedure;

                js_username_check_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());  /*provided value to parameter*/

                check_username_flag = Convert.ToInt32(js_username_check_cmd.ExecuteScalar());

                if (check_username_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is incorrect*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('User Name Incorrect')</script>");
                }
                js_username_check_cmd.Connection.Close();
                js_username_check_con.Close();
            }
            catch (Exception js_username_check_exp)
            {
                Response.Write("<script>alert('js_username_check_exp Occured , Report to admin')</script>");
                Console.Write(js_username_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)    /*Message Sent Button*/
        {
            SqlConnection save_jsMessage_con = null;
            SqlCommand save_jsMessage_cmd = null;

            if (check_username_flag == 1)    /*username correct*/
            {
                try
                {
                    save_jsMessage_con = new SqlConnection();
                    save_jsMessage_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    save_jsMessage_con.Open();

                    save_jsMessage_cmd = new SqlCommand();
                    save_jsMessage_cmd.Connection = save_jsMessage_con;
                    save_jsMessage_cmd.CommandText = "save_JSmessage_p";
                    save_jsMessage_cmd.CommandType = CommandType.StoredProcedure;

                    save_jsMessage_cmd.Parameters.AddWithValue("@subject", textboxB1_3.Text.Trim());
                    save_jsMessage_cmd.Parameters.AddWithValue("@message", textboxC1_3.Text.Trim());
                    save_jsMessage_cmd.Parameters.AddWithValue("@js_username", textboxA1_3.Text.Trim());

                    int check_success = save_jsMessage_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*Send Message button*/
                        textboxA1_3.Enabled = false;  /*js username textbox*/
                        textboxB1_3.Enabled = false;  /*subject textbox*/
                        textboxC1_3.Enabled = false;  /*message textbox*/
                        labelD1_3.Visible = true;  /*Message sent Label*/
                    }                                                                                             
                    else
                    {
                        Response.Write("<script>alert('Exception save_jsMessage_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception save_jsMessage_exp)
                {
                    Response.Write("<script>alert('Exception save_jsMessage_exp . Contact Admin')</script>");
                    Console.Write(save_jsMessage_exp.Message);
                }
                finally
                {
                    save_jsMessage_cmd.Connection.Close();
                    save_jsMessage_con.Close();
                }
            }
        }


    }
}