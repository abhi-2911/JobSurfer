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
    public partial class WFC_A_ChangePassword : System.Web.UI.UserControl
    {
        int min_char_password;
        static string check_e_password;

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
                min_char_password = 0;  /*setting default value */

                labelD1_3.Visible = false;  /*success label*/

                check_password();  /*will pull old password at page load event*/
            }
        }

        protected void check_password()   /*will pull old password at page load event*/
        {
            SqlConnection check_password_con = null;
            SqlCommand check_password_cmd = null;

            try
            {
                check_password_con = new SqlConnection();
                check_password_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                check_password_con.Open();

                check_password_cmd = new SqlCommand();
                check_password_cmd.Connection = check_password_con;
                check_password_cmd.CommandText = "checkOldPassword_A_p";
                check_password_cmd.CommandType = CommandType.StoredProcedure;

                check_password_cmd.Parameters.AddWithValue("@userName", Session["admin"].ToString());

                check_e_password = (string)check_password_cmd.ExecuteScalar();
            }
            catch (Exception check_password_exp)
            {
                Response.Write("<script>alert('check_password_exp Occured , Report this to admin')</script>");
                Console.Write(check_password_exp.Message);
            }
            finally
            {
                check_password_cmd.Connection.Close();
                check_password_con.Close();
            }

        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)   /*password min. 4 char*/
        {
            if (textboxB1_3.Text.Length < 4)
            {
                min_char_password = 1;
                args.IsValid = false;
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*update button*/
        {
            if (min_char_password == 0)
            {
                if (check_e_password == textboxA1_3.Text.Trim())
                {
                    try
                    {
                        SqlConnection update_password_con = new SqlConnection();
                        update_password_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                        update_password_con.Open();

                        SqlCommand update_password_cmd = new SqlCommand();
                        update_password_cmd.Connection = update_password_con;
                        update_password_cmd.CommandText = "update_A_Password_p";
                        update_password_cmd.CommandType = CommandType.StoredProcedure;

                        update_password_cmd.Parameters.AddWithValue("@userName", Session["admin"].ToString());   /*username from employer session*/
                        update_password_cmd.Parameters.AddWithValue("@password", textboxC1_3.Text.Trim());  /*confirm password textbox*/

                        int check_success = update_password_cmd.ExecuteNonQuery();

                        update_password_cmd.Connection.Close();
                        update_password_con.Close();

                        if (check_success >= 1)
                        {
                            //success code
                            disable_controls();   /*disable controls after successful update*/
                            buttonA1_3.Enabled = false;  /*update button*/
                            labelD1_3.Text = "Password Changed";   /*success label*/
                            labelD1_3.Visible = true;
                        }
                        else
                        {
                            //try again code
                            clear_controls();   /*clear text in  textboxes*/
                            labelD1_3.ForeColor = System.Drawing.Color.Red;
                            labelD1_3.Text = "Re-try to Update Password";
                            labelD1_3.Visible = true;
                        }
                    }
                    catch (Exception update_password_exp)
                    {
                        Response.Write("<script>alert('update_password_exp Occured , Report this to admin')</script>");
                        Console.Write(update_password_exp.Message);
                    }
                }
                else  /*Password mismatch*/
                {
                    Response.Write("<script>alert('Old Password Mismatch')</script>");
                }
            }
            else  /*Minimum 4 characters required*/
            {
                Response.Write("<script>alert('Min 4 Characters required')</script>");
            }
        }

        protected void disable_controls()   /*disable controls after successful update*/
        {
            textboxA1_3.Enabled = false;  /*old password*/
            textboxB1_3.Enabled = false;   /*new password*/
            textboxC1_3.Enabled = false;  /*confirm password*/
            buttonA1_3.Enabled = false;   /*update button*/
        }

        protected void clear_controls()   /*clear text in  textboxes*/
        {
            textboxA1_3.Text = "";  /*old password*/
            textboxB1_3.Text = "";   /*new password*/
            textboxC1_3.Text = "";  /*confirm password*/
        }

    }
}