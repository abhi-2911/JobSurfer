using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace JobSurfer.U_WebFormControl
{
    public partial class WFC_U_RegisterPage : System.Web.UI.UserControl
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        static int check_username_flag;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            buttonB1_3.Visible = false;

            if (!IsPostBack)
            {
                check_username_flag = 0;  /*set initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)
        {                               /*custom validator for unique username*/
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con.Open();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "username_check_p";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username",textboxA1_3.Text.Trim());/*provided value to parameter*/

                check_username_flag = Convert.ToInt32(cmd.ExecuteScalar());

                if (check_username_flag == 1)/*username already exists*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Username Already Exists . Change Username')</script>");
                }
                else /*username is available*/
                {
                    /*continue*/
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

        protected void buttonA1_3_Click(object sender, EventArgs e)/*register button*/
        {
            if (check_username_flag == 0) /*username is available*/
            {
                string fileType = fileuploadA1_3.PostedFile.ContentType;/*image/jpeg , image/png*/

                if (fileType == "image/jpeg" || fileType == "image/png")
                {
                    int fileSize = fileuploadA1_3.PostedFile.ContentLength;

                    if (fileSize < 4194304) /*4194304 bytes is 4MB, 1048567 bytes is 1MB */
                    {
                        /*image to byte[]*/
                        byte[] picData = new byte[fileSize];
                        fileuploadA1_3.PostedFile.InputStream.Read(picData, 0, fileSize);

                        /*upload of data to sql server*/

                        try
                        {
                            con = new SqlConnection();
                            con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                            con.Open();

                            cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "userRegistration_To_userLogin";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@userName", textboxA1_3.Text.Trim());
                            cmd.Parameters.AddWithValue("@firstName", textboxB1_3.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastName", textboxC1_3.Text.Trim());
                            cmd.Parameters.AddWithValue("@emailId", textboxD1_3.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactDetail", textboxE1_3.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", textboxG1_3.Text.Trim());
                            cmd.Parameters.AddWithValue("@profilePicture", picData);
                            cmd.Parameters.AddWithValue("@accDate", DateTime.Now);

                            int checkSuccess = cmd.ExecuteNonQuery();

                            if (checkSuccess == 2)
                            {
                                /*success*/
                                Clear_TextBox();
                                Disable_TextBox();
                                buttonA1_3.Visible = false;
                                buttonB1_3.Visible = true;

                            }
                            else
                            {
                                /*error in insert transaction*/
                                Response.Write("<script>alert('Please resolve errors and retry Registration')</script>");
                            }
                        }
                        catch (Exception exp)
                        {
                            Response.Write("<script>alert('Exception Occured, report this to admin')</script>");
                            Console.Write(exp.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                    }
                    else
                    {
                        /*filesize of less than 4MB required*/
                        Response.Write("<script>alert('Profile Picture size should be less than 4MB')</script>");
                    }
                }
                else
                {
                    /*filtype should be png or jpg*/
                    Response.Write("<script>alert('Profile Picture Should be .jpg or .png')</script>");
                }
            }
            else  /*username not available*/
            {
                /*continue*/
            }
        }

        private void Clear_TextBox()/*for clearing the text of textboxes on registration page*/
        {
            textboxA1_3.Text = "";/*UserName*/
            textboxB1_3.Text = "";/*FirstName*/
            textboxC1_3.Text = "";/*LastName*/
            textboxD1_3.Text = "";/*EmailId*/
            textboxE1_3.Text = "";/*ContactDetail*/
            textboxF1_3.Text = "";/*Password*/
            textboxG1_3.Text = "";/*ConfirmPassword*/

        }
        private void Disable_TextBox()/*for disabling the textboxes on registration page*/
        {
            textboxA1_3.Enabled = false;/*UserName*/
            textboxB1_3.Enabled = false;/*FirstName*/
            textboxC1_3.Enabled = false;/*LastName*/
            textboxD1_3.Enabled = false;/*EmailId*/
            textboxE1_3.Enabled = false;/*ContactDetail*/
            textboxF1_3.Enabled = false;/*Password*/
            textboxG1_3.Enabled = false;/*ConfirmPassword*/
            fileuploadA1_3.Enabled = false;/*uploadFile button*/

        }

        protected void cvB1_3_ServerValidate(object source, ServerValidateEventArgs args)
        {                                   /*password length validator*/

            if (textboxF1_3.Text.Length < 4) /*min 4 char of password are required*/
            {
                 /*invalid*/
                check_username_flag = 1;
                Response.Write("<script>alert('Password Minimum 4 char.')</script>");
                args.IsValid = false;

            }else /*4 char are present*/
            {
                 /*continue*/
            }
        }
    }
}