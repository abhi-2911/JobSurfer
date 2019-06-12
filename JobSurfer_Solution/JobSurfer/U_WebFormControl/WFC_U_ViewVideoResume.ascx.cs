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
    public partial class WFC_U_ViewVideoResume : System.Web.UI.UserControl
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

            buttonA1_3.Visible = false; /*visibility of Add Video Resume button*/

            viewVideoResume_pull();/*check if data is available*/
        }


        protected void viewVideoResume_pull()/*check if data is available*/
        {
            SqlConnection viewVideoResume_pull_con = null;
            SqlCommand viewVideoResume_pull_cmd = null;
            SqlDataReader viewVideoResume_pull_rdr = null;
            string check_username = null;

            try
            {
                viewVideoResume_pull_con = new SqlConnection();
                viewVideoResume_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                viewVideoResume_pull_con.Open();

                viewVideoResume_pull_cmd = new SqlCommand();
                viewVideoResume_pull_cmd.Connection = viewVideoResume_pull_con;
                viewVideoResume_pull_cmd.CommandText = "pullVideoResume_p";
                viewVideoResume_pull_cmd.CommandType = CommandType.StoredProcedure;

                viewVideoResume_pull_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());

                viewVideoResume_pull_rdr = viewVideoResume_pull_cmd.ExecuteReader();

                if (viewVideoResume_pull_rdr.HasRows)
                {
                    while (viewVideoResume_pull_rdr.Read())
                    {
                        check_username = viewVideoResume_pull_rdr.GetString(1);
                    }
                }

                viewVideoResume_pull_rdr.Close();

                if (check_username != null)
                {
                    viewVideoResume_pull_rdr = viewVideoResume_pull_cmd.ExecuteReader();

                    if (viewVideoResume_pull_rdr.HasRows)
                    {
                        while (viewVideoResume_pull_rdr.Read())
                        {
                            buttonB1_3.PostBackUrl = viewVideoResume_pull_rdr.GetString(2);/*Click to View button postback url */
                        }
                    }
                    /*closed opened connections*/
                    viewVideoResume_pull_rdr.Close();
                    viewVideoResume_pull_cmd.Connection.Close();
                    viewVideoResume_pull_con.Close();
                    check_username = null;
                }
                else/*video resume is not provided by the user*/
                {
                    viewVideoResume_pull_cmd.Connection.Close();
                    viewVideoResume_pull_con.Close();
                    check_username = null;

                    buttonA1_3.Visible = true;/*add video resume button*/
                    buttonB1_3.Visible = false;/*Click to View button*/
                }

            }
            catch (Exception viewVideoResume_pull_exp)
            {
                Response.Write("<script>alert('viewVideoResume_pull_exp Occured , Report to admin')</script>");
                Console.Write(viewVideoResume_pull_exp.Message);
            }
        }

    }
}