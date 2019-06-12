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
    public partial class WFC_A_Resources_Del_Doc_J : System.Web.UI.UserControl
    {
        static int check_documentID_flag;    /*for storing value returned by executeScalar*/

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
                check_documentID_flag = 0;  /*initial value*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)  /*for checking , whether correct*/
        {                                                                                                                                                        /* document ID is entered*/
            SqlConnection documentID_check_con;
            SqlCommand documentID_check_cmd;

            try
            {
                documentID_check_con = new SqlConnection();
                documentID_check_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                documentID_check_con.Open();

                documentID_check_cmd = new SqlCommand();
                documentID_check_cmd.Connection = documentID_check_con;
                documentID_check_cmd.CommandText = "check_JS_docResource_ID";
                documentID_check_cmd.CommandType = CommandType.StoredProcedure;

                documentID_check_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));  /*provided value to parameter*/

                check_documentID_flag = Convert.ToInt32(documentID_check_cmd.ExecuteScalar());

                if (check_documentID_flag == 1)  /*document ID correct*/
                {
                    /*continue*/

                }
                else /*document ID is incorrect*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Document ID Incorrect')</script>");
                }
                documentID_check_cmd.Connection.Close();
                documentID_check_con.Close();
            }
            catch (Exception documentID_check_exp)
            {
                Response.Write("<script>alert('documentID_check_exp Occured , Report to admin')</script>");
                Console.Write(documentID_check_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*remove button is clicked*/
        {
            SqlConnection delete_docResource_con = null;
            SqlCommand delete_docResource_cmd = null;

            if (check_documentID_flag == 1)    /*document id correct*/
            {
                try
                {
                    delete_docResource_con = new SqlConnection();
                    delete_docResource_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    delete_docResource_con.Open();

                    delete_docResource_cmd = new SqlCommand();
                    delete_docResource_cmd.Connection = delete_docResource_con;
                    delete_docResource_cmd.CommandText = "delete_JS_docResource_ID";
                    delete_docResource_cmd.CommandType = CommandType.StoredProcedure;

                    delete_docResource_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textboxA1_3.Text.Trim()));

                    int check_success = delete_docResource_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*remove button*/
                        textboxA1_3.Enabled = false;  /*document id textbox*/
                    }
                    else
                    {
                        Response.Write("<script>alert('Exception  delete_docResource_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception delete_docResource_exp)
                {
                    Response.Write("<script>alert('Exception delete_docResource_exp . Contact Admin')</script>");
                    Console.Write(delete_docResource_exp.Message);
                }
                finally
                {
                    delete_docResource_cmd.Connection.Close();
                    delete_docResource_con.Close();
                }
            }
        }


    }
}