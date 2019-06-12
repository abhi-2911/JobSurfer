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
    public partial class WFC_A_LoginPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*login button*/
        {
            SqlConnection admin_login_con = null;
            SqlCommand admin_login_cmd = null;
            int check_success;

            try
            {
                admin_login_con = new SqlConnection();
                admin_login_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                admin_login_con.Open();

                admin_login_cmd = new SqlCommand();
                admin_login_cmd.Connection = admin_login_con;
                admin_login_cmd.CommandText = "adminLoin_p";
                admin_login_cmd.CommandType = CommandType.StoredProcedure;

                admin_login_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());
                admin_login_cmd.Parameters.AddWithValue("@password", textboxB1_3.Text.Trim());

                check_success = Convert.ToInt32(admin_login_cmd.ExecuteScalar());

                if (check_success == 1)   /*record is present*/
                {
                    /*success*/
                    buttonA1_3.Enabled = false;   /*login button disable*/
                    Session["admin"] = textboxA1_3.Text;   /* username textbox*/
                    Response.Redirect("~/Admin/A_FrontPage.aspx");
                }
                else/*record is absent*/
                {
                    /*try again*/
                    Clear_TextBox();
                    Response.Write("<script>alert('Check the Values Entered and Retry Login')</script>");
                }
            }
            catch (Exception admin_login_exp)
                {
                    Response.Write("<script>alert('admin_login_exp occured. Contact Admin.')</script>");
                    Console.Write(admin_login_exp.Message);
                }
            finally
                {
                    admin_login_cmd.Connection.Close();
                    admin_login_con.Close();
                }
        }

        protected void Clear_TextBox()  /*clear textbox text , to retry login*/
        {
            textboxA1_3.Text = ""; /*username*/
            textboxB1_3.Text = ""; /*password*/
        }

    }
}