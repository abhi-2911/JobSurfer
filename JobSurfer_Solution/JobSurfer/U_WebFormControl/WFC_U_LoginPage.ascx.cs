using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JobSurfer.U_WebFormControl
{
    public partial class WFC_U_LoginPage : System.Web.UI.UserControl
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        int check_success;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con.Open();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "userLogin_p";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username",textboxA1_3.Text.Trim());
                cmd.Parameters.AddWithValue("@password", textboxB1_3.Text.Trim());

                check_success = Convert.ToInt32( cmd.ExecuteScalar());

                if (check_success==1)/*record is present*/
                {
                    /*success*/
                    Session["user"] = textboxA1_3.Text;
                    Response.Redirect("~/User/U_ProfilePage.aspx");

                }
                else/*record is absent*/
                {
                    /*try again*/
                    Clear_TextBox();
                    Response.Write("<script>alert('Check the Values Entered and Retry Login')</script>");
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
        }
        private void Clear_TextBox()
        {
            textboxA1_3.Text="";
            textboxB1_3.Text = "";
        }
    }
}