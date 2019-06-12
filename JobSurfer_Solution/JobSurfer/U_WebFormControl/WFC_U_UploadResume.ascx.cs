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
    public partial class WFC_U_UploadResume : System.Web.UI.UserControl
    {
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

            if (!IsPostBack)
            {
                buttonB1_3.Visible = false;/*update button*/

                resume_pull(); /*check resume data avilability*/
            }
        }



        protected void resume_pull()/*check data avilability*/
        {
            SqlConnection resume_pull_con = null;
            SqlCommand resume_pull_cmd = null;
            SqlDataReader resume_pull_rdr = null;
            string check_username = null;

            try
            {
                resume_pull_con = new SqlConnection();
                resume_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                resume_pull_con.Open();

                resume_pull_cmd = new SqlCommand();
                resume_pull_cmd.Connection = resume_pull_con;
                resume_pull_cmd.CommandText = "pullResume_p";
                resume_pull_cmd.CommandType = CommandType.StoredProcedure;

                resume_pull_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());

                resume_pull_rdr = resume_pull_cmd.ExecuteReader();

                if (resume_pull_rdr.HasRows)
                {
                    while (resume_pull_rdr.Read())
                    {
                        check_username = resume_pull_rdr.GetString(1);/*username*/
                    }
                }

                resume_pull_rdr.Close();

                if (check_username != null)/*if username is available*/
                {

                    buttonA1_3.Visible = false;/*save*/
                    buttonB1_3.Visible = true;/*update*/

                    resume_pull_cmd.Connection.Close();
                    resume_pull_con.Close();
                    check_username = null;

                }
                else /*if username not available*/
                {
                    /*continue*/
                    resume_pull_cmd.Connection.Close();
                    resume_pull_con.Close();
                    check_username = null;
                }

            }
            catch (Exception resume_pull_exp)
            {
                Response.Write("<script>alert('resume_pull_exp Occured , Report to admin')</script>");
                Console.Write(resume_pull_exp.Message);
            }

        }



        protected void buttonA1_3_Click(object sender, EventArgs e)  /*save button*/
        {
            SqlConnection save_resume_con = null;
            SqlCommand save_resume_cmd = null;

            string fileType = fileuploadA1_3.PostedFile.ContentType;/*application/pdf*/

            if (fileType == "application/pdf")
            {
                int fileSize = fileuploadA1_3.PostedFile.ContentLength;

                if (fileSize < 3145728) /*31,45,728 bytes is 3MB, 1024*1024 = 1048567 bytes is 1MB */
                {
                    /*.pdf file to byte[]*/
                    byte[] docData = new byte[fileSize];
                    fileuploadA1_3.PostedFile.InputStream.Read(docData, 0, fileSize);


                    try
                    {
                        save_resume_con = new SqlConnection();
                        save_resume_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                        save_resume_con.Open();

                        save_resume_cmd = new SqlCommand();
                        save_resume_cmd.Connection = save_resume_con;
                        save_resume_cmd.CommandText = "saveResume_p";
                        save_resume_cmd.CommandType = CommandType.StoredProcedure;

                        save_resume_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                        save_resume_cmd.Parameters.AddWithValue("@resume", docData);

                        int checkSuccess = save_resume_cmd.ExecuteNonQuery();

                        if (checkSuccess >= 1)
                        {
                            /*success*/
                            disable_controls();/*to disable controls after successfully saving data*/

                        }
                        else
                        {
                            /*error in insert transaction*/
                            Response.Write("<script>alert('Please resolve errors and retry Registration')</script>");
                        }
                    }
                    catch (Exception save_resume_exp)
                    {
                        Response.Write("<script>alert('save_resume_exp Occured. Contact Admin')</script>");
                        Console.Write(save_resume_exp.Message);
                    }
                    finally
                    {
                        save_resume_cmd.Connection.Close();
                        save_resume_con.Close();
                    }


                }
                else/*file size greater than 3MB*/
                {
                    Response.Write("<script>alert('Filesize should be less than 3MB')</script>");
                }
            }
            else/*file type not .pdf*/
            {
                Response.Write("<script>alert('Filtype Should Be .pdf')</script>");
            }
        }/*end bracket of save button click event*/


         protected void disable_controls()/*to disable controls after successfully saving data*/
        {
            fileuploadA1_3.Enabled = false;
            buttonA1_3.Enabled = false;/*saveButton*/
        }

        protected void disable_controls_update()/*to disable controls after successfully updating data*/
        {
            fileuploadA1_3.Enabled = false;
            buttonB1_3.Enabled = false;/*updateButton*/
        }

        protected void buttonB1_3_Click(object sender, EventArgs e)/*update resume button*/
        {
            SqlConnection update_resume_con = null;
            SqlCommand update_resume_cmd = null;

            string fileType = fileuploadA1_3.PostedFile.ContentType;/*application/pdf*/

            if (fileType == "application/pdf")
            {
                int fileSize = fileuploadA1_3.PostedFile.ContentLength;

                if (fileSize < 3145728) /*31,45,728 bytes is 3MB, 1024*1024 = 1048567 bytes is 1MB */
                {
                    /*.pdf file to byte[]*/
                    byte[] docData = new byte[fileSize];
                    fileuploadA1_3.PostedFile.InputStream.Read(docData, 0, fileSize);


                    try
                    {
                        update_resume_con = new SqlConnection();
                        update_resume_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                        update_resume_con.Open();

                        update_resume_cmd = new SqlCommand();
                        update_resume_cmd.Connection = update_resume_con;
                        update_resume_cmd.CommandText = "updateResume_p";
                        update_resume_cmd.CommandType = CommandType.StoredProcedure;

                        update_resume_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                        update_resume_cmd.Parameters.AddWithValue("@resume", docData);

                        int checkSuccess = update_resume_cmd.ExecuteNonQuery();

                        if (checkSuccess >= 1)
                        {
                            /*success*/
                            disable_controls_update();/*to disable controls after successfully updating data*/

                        }
                        else
                        {
                            /*error in insert transaction*/
                            Response.Write("<script>alert('Err_update_resume_ExecuteNonQuery: Please resolve errors and retry')</script>");
                        }
                    }
                    catch (Exception update_resume_exp)
                    {
                        Response.Write("<script>alert('update_resume_exp Occured. Contact Admin')</script>");
                        Console.Write(update_resume_exp.Message);
                    }
                    finally
                    {
                        update_resume_cmd.Connection.Close();
                        update_resume_con.Close();
                    }


                }
                else/*file size greater than 3MB*/
                {
                    Response.Write("<script>alert('Filesize should be less than 3MB')</script>");
                }
            }
            else/*file type not .pdf*/
            {
                Response.Write("<script>alert('Filtype Should Be .pdf')</script>");
            }
        }/*end bracket of update button click event*/
    }
}

