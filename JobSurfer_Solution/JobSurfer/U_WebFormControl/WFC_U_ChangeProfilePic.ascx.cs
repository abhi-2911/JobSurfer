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
    public partial class WFC_U_ChangeProfilePic : System.Web.UI.UserControl
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

            if (!IsPostBack)
            {
                buttonB1_3.Visible = false;    /*profile button visibility*/

                image_load(); /*method to display profilePic*/
            }

        }

        protected void buttonA1_3_Click(object sender, EventArgs e)/*upload button*/
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
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
                        con = new SqlConnection();
                        con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                        con.Open();

                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "updateProfilePic_p";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@userName", Session["user"].ToString());
                        cmd.Parameters.AddWithValue("@profilePicture", picData);

                        int checkSuccess = cmd.ExecuteNonQuery();

                        if (checkSuccess >= 1)
                        {
                            /*success*/
                            disable_controls();
                            buttonA1_3.Visible = false;   /*upload button*/
                            buttonB1_3.Visible = true;   /*profile button*/

                        }
                        else
                        {
                            /*error in insert transaction*/
                            Response.Write("<script>alert('Err_in_ExecuteNonQuery: Please resolve errors and retry')</script>");
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
            catch (Exception upload_exp)
            {
                Response.Write("<script>alert('upload_exp Occured. Contact Admin')</script>");
                Console.Write(upload_exp.Message);
            }
            finally
            {
                if (con != null) {
                    cmd.Connection.Close();
                    con.Close();
                }
            }
       }

        protected void disable_controls()/*disable controls after success*/
        {
            imageA1_3.Visible = false;
            fileuploadA1_3.Enabled = false;
        }

        protected void image_load()/*will load image from the database, when the page loads*/
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con.Open();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "supplyData_ProfilePic_p";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userName", Session["user"].ToString());/*username*/

                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        //for profile picture
                        byte[] imagedata = (byte[])rdr["profilePicture"];
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
                rdr.Close();
                cmd.Connection.Close();
                con.Close();
            }
        }

    }
}