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
    public partial class WFC_E_ViewVideo : System.Web.UI.UserControl
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
                buttonB1_3.Visible = false; /*Add Video button*/

                emp_Video_pull();  /*check data avilability*/
            }
        }


        protected void emp_Video_pull()  /*check data avilability*/
        {
            SqlConnection emp_Video_pull_con = null;
            SqlCommand emp_Video_pull_cmd = null;
            SqlDataReader emp_Video_pull_rdr = null;

            try
            {
                emp_Video_pull_con = new SqlConnection();
                emp_Video_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                emp_Video_pull_con.Open();

                emp_Video_pull_cmd = new SqlCommand();
                emp_Video_pull_cmd.Connection = emp_Video_pull_con;
                emp_Video_pull_cmd.CommandText = "pull_E_Video_p";
                emp_Video_pull_cmd.CommandType = CommandType.StoredProcedure;

                emp_Video_pull_cmd.Parameters.AddWithValue("@username", Session["employer"].ToString());

                emp_Video_pull_rdr = emp_Video_pull_cmd.ExecuteReader();

                if (emp_Video_pull_rdr.HasRows)  /*company video present*/
                {
                    while (emp_Video_pull_rdr.Read())
                    {
                        buttonA1_3.PostBackUrl = emp_Video_pull_rdr.GetString(2);  /*companyVideo*/
                    }

                }
                else  /*company video absent*/
                {
                    buttonA1_3.Visible = false; /*Click To View button*/
                    buttonB1_3.Visible = true;  /*Add company Video button*/
                }

            }
            catch (Exception emp_Video_pull_exp)
            {
                Response.Write("<script>alert('emp_Video_pull_exp Occured , Report to admin')</script>");
                Console.Write(emp_Video_pull_exp.Message);
            }
            finally
            {
                emp_Video_pull_rdr.Close();
                emp_Video_pull_cmd.Connection.Close();
                emp_Video_pull_con.Close();
            }

        }



    }
}