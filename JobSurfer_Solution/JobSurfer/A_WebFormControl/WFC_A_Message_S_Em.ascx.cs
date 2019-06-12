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
    public partial class WFC_A_Message_S_Em : System.Web.UI.UserControl
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
        {                                                                                                                                                /* username is entered*/
            SqlConnection emp_username_check_con;
            SqlCommand emp_username_check_cmd;

            try
            {
                emp_username_check_con = new SqlConnection();
                emp_username_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                emp_username_check_con.Open();

                emp_username_check_cmd = new SqlCommand();
                emp_username_check_cmd.Connection = emp_username_check_con;
                emp_username_check_cmd.CommandText = "emp_username_check_p";
                emp_username_check_cmd.CommandType = CommandType.StoredProcedure;

                emp_username_check_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());  /*provided value to parameter*/

                check_username_flag = Convert.ToInt32(emp_username_check_cmd.ExecuteScalar());

                if (check_username_flag == 1)  /*username correct*/
                {
                    /*continue*/

                }
                else /*username is correct*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('User Name Incorrect')</script>");
                }
                emp_username_check_cmd.Connection.Close();
                emp_username_check_con.Close();
            }
            catch (Exception emp_username_check_exp)
            {
                Response.Write("<script>alert('emp_username_check_exp Occured , Report to admin')</script>");
                Console.Write(emp_username_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)    /*Message Sent Button*/
        {
            SqlConnection save_empMessage_con = null;
            SqlCommand save_empMessage_cmd = null;

            if (check_username_flag == 1)    /*username correct*/
            {
                try
                {
                    save_empMessage_con = new SqlConnection();
                    save_empMessage_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    save_empMessage_con.Open();

                    save_empMessage_cmd = new SqlCommand();
                    save_empMessage_cmd.Connection = save_empMessage_con;
                    save_empMessage_cmd.CommandText = "save_EMPmessage_p";
                    save_empMessage_cmd.CommandType = CommandType.StoredProcedure;

                    save_empMessage_cmd.Parameters.AddWithValue("@subject", textboxB1_3.Text.Trim());
                    save_empMessage_cmd.Parameters.AddWithValue("@message", textboxC1_3.Text.Trim());
                    save_empMessage_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());

                    int check_success = save_empMessage_cmd.ExecuteNonQuery();

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
                        Response.Write("<script>alert('Exception save_empMessage_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception save_empMessage_exp)
                {
                    Response.Write("<script>alert('Exception save_empMessage_exp . Contact Admin')</script>");
                    Console.Write(save_empMessage_exp.Message);
                }
                finally
                {
                    save_empMessage_cmd.Connection.Close();
                    save_empMessage_con.Close();
                }
            }
        }


    }
}