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
    public partial class WFC_A_Remove_E : System.Web.UI.UserControl
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
                check_username_flag = 0;  /*initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)   /*for checking , wheather correct*/
        {                                                                                                                                               /* username is entered*/
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

        protected void buttonA1_3_Click(object sender, EventArgs e)    /*delete button*/
        {
            SqlConnection delete_e_con = null;
            SqlCommand delete_e_cmd = null;

            if (check_username_flag == 1)    /*username correct*/
            {
                try
                {
                    delete_e_con = new SqlConnection();
                    delete_e_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_e_con.Open();

                    delete_e_cmd = new SqlCommand();
                    delete_e_cmd.Connection = delete_e_con;
                    delete_e_cmd.CommandText = "delete_E_A_p";
                    delete_e_cmd.CommandType = CommandType.StoredProcedure;

                    delete_e_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());

                    int check_success = delete_e_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*js username textbox*/
                        Response.Redirect("~/Admin/A_Remove_E.aspx");   /*important to refresh orelse previous */
                    }                                                                                              /* is used and button_click function starts again */
                    else
                    {
                        Response.Write("<script>alert('Exception delete_e_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_e_exp)
                {
                    Response.Write("<script>alert('Exception delete_e_exp . Contact Admin')</script>");
                    Console.Write(delete_e_exp.Message);
                }
                finally
                {
                    delete_e_cmd.Connection.Close();
                    delete_e_con.Close();
                }
            }
        }

    }
}