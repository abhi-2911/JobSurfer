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
    public partial class WFC_E_ChangeProfilePic : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employer"] != null)//check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                buttonB1_3.Visible = false;  /*profile button visibility*/

                image_load(); /*method to display profilePic*/
            }

        }


        protected void image_load()/*will load image from the database, when the page loads*/
        {
            SqlConnection image_load_con = null;
            SqlCommand image_load_cmd = null;
            SqlDataReader image_load_rdr = null;

            try
            {
                image_load_con = new SqlConnection();
                image_load_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                image_load_con.Open();

                image_load_cmd = new SqlCommand();
                image_load_cmd.Connection = image_load_con;
                image_load_cmd.CommandText = "supplyData_E_ProfilePic_p";
                image_load_cmd.CommandType = CommandType.StoredProcedure;

                image_load_cmd.Parameters.AddWithValue("@userName", Session["employer"].ToString());     /*username*/

                image_load_rdr = image_load_cmd.ExecuteReader();

                if (image_load_rdr.HasRows)
                {

                    while (image_load_rdr.Read())
                    {
                        //for profile picture
                        byte[] imagedata = (byte[])image_load_rdr["profilePicture"];
                        string image_ready = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                        imageA1_3.ImageUrl = "data:image/jpeg;base64," + image_ready;
                    }
                }
            }
            catch (Exception image_load_exp)
            {
                Response.Write("<script>alert('image_load_exp Occured. Contact Admin')</script>");
                Console.Write(image_load_exp.Message);
            }
            finally
            {
                image_load_rdr.Close();
                image_load_cmd.Connection.Close();
                image_load_con.Close();
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*upload button*/
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

                    try
                    {
                        SqlConnection upload_e_profile_pic_con = new SqlConnection();
                        upload_e_profile_pic_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                        upload_e_profile_pic_con.Open();

                        SqlCommand upload_e_profile_pic_cmd = new SqlCommand();
                        upload_e_profile_pic_cmd.Connection = upload_e_profile_pic_con;
                        upload_e_profile_pic_cmd.CommandText = "update_E_ProfilePic_p";
                        upload_e_profile_pic_cmd.CommandType = CommandType.StoredProcedure;

                        upload_e_profile_pic_cmd.Parameters.AddWithValue("@username", Session["employer"].ToString());
                        upload_e_profile_pic_cmd.Parameters.AddWithValue("@profilePicture", picData);

                        int checkSuccess = upload_e_profile_pic_cmd.ExecuteNonQuery();

                        upload_e_profile_pic_cmd.Connection.Close();  /*close connection*/
                        upload_e_profile_pic_con.Close();   /*close connection*/

                        if (checkSuccess >= 1)
                        {
                            /*success*/
                            disable_controls();   /*disable controls after success*/
                            buttonA1_3.Visible = false;   /*upload button*/
                            buttonB1_3.Visible = true;   /*profile button*/
                        }
                        else
                        {
                            /*error in insert transaction*/
                            Response.Write("<script>alert('upload_e_profile_pic_cmd.ExecuteNonQuery: Please resolve errors and retry')</script>");
                        }
                    }
                    catch (Exception upload_exp)
                    {
                        Response.Write("<script>alert('upload_exp Occured. Contact Admin')</script>");
                        Console.Write(upload_exp.Message);
                    }

                }
                else/*fileSize*/
                {
                    Response.Write("<script>alert('File Size : Less than 4MB')</script>");
                }
            }
            else/*file type*/
            {
                Response.Write("<script>alert('File Type : .jpg or .png')</script>");
            }
        }

        protected void disable_controls()  /*disable controls after success*/
        {
            imageA1_3.Visible = false;
            fileuploadA1_3.Enabled = false;
        }

    }
}


