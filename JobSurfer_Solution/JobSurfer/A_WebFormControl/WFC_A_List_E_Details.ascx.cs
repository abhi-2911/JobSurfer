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
    public partial class WFC_A_List_E_Details : System.Web.UI.UserControl
    {
        static string emp_username;  /*fro storing employer username */
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
                emp_username = Request.QueryString["id"];     /*pull employer username from queryString (url)*/ 

                pull_emp_Info();   /*pull employer information from empRegistration table*/
            }
        }

        protected void pull_emp_Info()   /*pull employer information from empRegistration table*/
        {
            SqlConnection pull_emp_Info_con = null;
            SqlCommand pull_emp_Info_cmd = null;
            SqlDataReader pull_emp_Info_rdr = null;

            try
            {
                pull_emp_Info_con = new SqlConnection();
                pull_emp_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_emp_Info_con.Open();

                pull_emp_Info_cmd = new SqlCommand();
                pull_emp_Info_cmd.Connection = pull_emp_Info_con;
                pull_emp_Info_cmd.CommandText = "supplyData_E_ProfilePage_p";
                pull_emp_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_emp_Info_cmd.Parameters.AddWithValue("@userName", emp_username);

                pull_emp_Info_rdr = pull_emp_Info_cmd.ExecuteReader();

                if (pull_emp_Info_rdr.HasRows)
                {
                    while (pull_emp_Info_rdr.Read())
                    {

                        /*for emp profile pictuer*/
                        byte[] imagedata = (byte[])pull_emp_Info_rdr["profilePicture"];
                        string image_ready = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                        imageA1_3.ImageUrl = "data:image/jpeg;base64," + image_ready;

                        valuelabelA1_3.Text = pull_emp_Info_rdr.GetString(2); /*firstName*/
                        valuelabelB1_3.Text = pull_emp_Info_rdr.GetString(3); /*lastName*/
                        valuelabelC1_3.Text = pull_emp_Info_rdr.GetString(4); /*designation*/
                        valuelabelD1_3.Text = pull_emp_Info_rdr.GetString(5); /*company Name*/
                        valuelabelE1_3.Text = pull_emp_Info_rdr.GetString(6); /*email id*/
                        valuelabelF1_3.Text = pull_emp_Info_rdr.GetString(7); /*state*/
                        valuelabelG1_3.Text = pull_emp_Info_rdr.GetString(8); /*city*/
                        valuelabelH1_3.Text = pull_emp_Info_rdr.GetString(9); /*industry*/
                        textboxI1_3.Text = pull_emp_Info_rdr.GetString(10); /*Address*/
                        valuelabelJ1_3.Text = pull_emp_Info_rdr.GetString(11); /*contact number*/

                    }
                }
            }
            catch (Exception pull_emp_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_emp_Info_exp Occured , Report this to admin')</script>");
                Console.Write(pull_emp_Info_exp.Message);
            }
            finally
            {
                pull_emp_Info_rdr.Close();
                pull_emp_Info_cmd.Connection.Close();
                pull_emp_Info_con.Close();
            }
        }

    }
}