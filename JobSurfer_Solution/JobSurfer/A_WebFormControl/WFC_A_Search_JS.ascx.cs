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
    public partial class WFC_A_Search_JS : System.Web.UI.UserControl
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

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*view button*/
        {
            if (check_username_flag == 1)  /*username correct*/
            {
                Response.Redirect("~/Admin/A_Search_JS_Details.aspx?id=" + textboxA1_3.Text.Trim());
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)   /*for checking , wheather correct*/
        {                                                                                                                                              /* username is entered*/
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

                js_username_check_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());      /*provided value to parameter*/

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

    }
}