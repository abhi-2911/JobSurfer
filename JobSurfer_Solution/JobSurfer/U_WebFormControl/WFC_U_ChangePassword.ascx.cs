
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace JobSurfer.U_WebFormControl
{
    public partial class WFC_U_ChangePassword : System.Web.UI.UserControl
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlConnection con_2 = null;
        SqlCommand cmd_2 = null;
        int check_success;              /*for rows returned ,when old password == new password*/
        string check_password;          /*for old password*/
        string user_Name;               /*for session to string*/
        static int min_char_password;   /*for password char len*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)//check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            labelD1_3.Visible = false;

            min_char_password = 0;
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)
        {   /*password min. 4 char*/

            if (textboxB1_3.Text.Length < 4)
            {
                min_char_password = 1;
                args.IsValid = false;
            }
            else
            {
                min_char_password = 0;
                args.IsValid = true;
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)
        {
            if (min_char_password == 0)/*check char len of password*/
            {
                try /*check if old password is correct*/
                {
                    con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    con.Open();

                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "checkOldPassword_p";
                    cmd.CommandType = CommandType.StoredProcedure;

                    user_Name = Convert.ToString(Session["user"]);

                    cmd.Parameters.AddWithValue("@userName", user_Name);

                    check_password = (string)cmd.ExecuteScalar();

                    if (check_password == textboxA1_3.Text.Trim())   /*current typed password == old password*/
                    {

                        try
                        {
                            con_2 = new SqlConnection();
                            con_2.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                            con_2.Open();

                            cmd_2 = new SqlCommand();
                            cmd_2.Connection = con_2;
                            cmd_2.CommandText = "updatePassword_p";
                            cmd_2.CommandType = CommandType.StoredProcedure;

                            cmd_2.Parameters.AddWithValue("@userName", user_Name);
                            cmd_2.Parameters.AddWithValue("@password", textboxC1_3.Text.Trim());

                            check_success = cmd_2.ExecuteNonQuery();

                            if (check_success == 2)
                            {
                                //success code
                                Clear_TextBox();
                                buttonA1_3.Enabled = false;
                                labelD1_3.Text = "Password Changed";
                                labelD1_3.Visible = true;
                            }
                            else
                            {
                                //try again code
                                Clear_TextBox();
                                labelD1_3.ForeColor = Color.Red;
                                labelD1_3.Text = "Re-try to Update Password";
                                labelD1_3.Visible = true;
                            }
                        }
                        catch (Exception exp_2)
                        {

                            Response.Write("<script>alert('Exception exp_2 Occured , Report this to admin')</script>");
                            Console.Write(exp_2.Message);
                        }
                        finally
                        {
                            con_2.Close();
                        }

                    }
                    else /*current typed password == old typed password*/
                    {
                        Clear_TextBox();
                        Response.Write("<script>alert('Old Password Incorrect')</script>");
                    }
                }
                catch (Exception exp)
                {
                    Response.Write("<script>alert('Exception exp Occured , Report this to admin')</script>");
                    Console.Write(exp.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else/*check char len of password*/
            {
                Clear_TextBox();
                Response.Write("<script>alert('Minimum Password Length is 4')</script>");
            }
        }

        private void Clear_TextBox()/*clear text in textboxes*/
        {
            textboxA1_3.Text = "";
            textboxB1_3.Text = "";
            textboxC1_3.Text = "";
        }
    }
}