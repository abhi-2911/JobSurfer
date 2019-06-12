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
    public partial class WFC_A_Resources_Add_Doc_J : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)//check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                successLabelA1_3.Visible = false;  /*success label*/
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*add button click*/
        {
            SqlConnection add_doc_con = null;
            SqlCommand add_doc_cmd = null;

            string fileType = fileuploadA1_3.PostedFile.ContentType;  /*application/pdf*/

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
                        add_doc_con = new SqlConnection();
                        add_doc_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                        add_doc_con.Open();

                        add_doc_cmd = new SqlCommand();
                        add_doc_cmd.Connection = add_doc_con;
                        add_doc_cmd.CommandText = "add_js_doc_res";
                        add_doc_cmd.CommandType = CommandType.StoredProcedure;

                        add_doc_cmd.Parameters.AddWithValue("@title", textboxA1_3.Text.Trim());
                        add_doc_cmd.Parameters.AddWithValue("@pdf_doc", docData);

                        int checkSuccess = add_doc_cmd.ExecuteNonQuery();

                        if (checkSuccess >= 1)
                        {
                            /*success*/
                            textboxA1_3.Enabled = false;
                            fileuploadA1_3.Enabled = false;
                            buttonA1_3.Enabled = false;
                            successLabelA1_3.Visible = true;
                        }
                        else
                        {
                            /*error in insert transaction*/
                            Response.Write("<script>alert('add_doc_cmd.ExecuteNonQuery. Contact Admin')</script>");
                        }
                    }
                    catch (Exception add_doc_exp)
                    {
                        Response.Write("<script>alert('add_doc_exp Occured. Contact Admin')</script>");
                        Console.Write(add_doc_exp.Message);
                    }
                    finally
                    {
                        add_doc_cmd.Connection.Close();
                        add_doc_con.Close();
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
        }


    }
}