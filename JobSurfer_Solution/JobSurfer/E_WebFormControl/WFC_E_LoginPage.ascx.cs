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
    public partial class WFC_E_LoginPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void buttonA1_3_Click(object sender, EventArgs e) /*login button*/
        {
            SqlConnection emp_login_con = null;
            SqlCommand emp_login_cmd = null;
            int check_success;

            try
            {
                emp_login_con = new SqlConnection();
                emp_login_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                emp_login_con.Open();

                emp_login_cmd = new SqlCommand();
                emp_login_cmd.Connection = emp_login_con;
                emp_login_cmd.CommandText = "empLogin_p";
                emp_login_cmd.CommandType = CommandType.StoredProcedure;

                emp_login_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());
                emp_login_cmd.Parameters.AddWithValue("@password", textboxB1_3.Text.Trim());

                check_success = Convert.ToInt32(emp_login_cmd.ExecuteScalar());

                if (check_success == 1)/*record is present*/
                {
                    /*success*/
                    Session["employer"] = textboxA1_3.Text;
                    Response.Redirect("~/Employer/E_ProfilePage.aspx");

                }
                else/*record is absent*/
                {
                    /*try again*/
                    Clear_TextBox();
                    Response.Write("<script>alert('Check the Values Entered and Retry Login')</script>");
                }

            }
            catch (Exception emp_login_exp)
            {
                Response.Write("<script>alert('emp_login_exp occured. Contact Admin.')</script>");
                Console.Write(emp_login_exp.Message);
            }
            finally
            {
                emp_login_cmd.Connection.Close();
                emp_login_con.Close();
            }
        }

        protected void Clear_TextBox()  /*clear textbox text , to retry login*/
        {
            textboxA1_3.Text = ""; /*username*/
            textboxB1_3.Text = ""; /*password*/
        }


    }
}