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
    public partial class WFC_A_Resources_Add_Vid_E : System.Web.UI.UserControl
    {
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
                successLabelA1_3.Visible = false;  /*success label */
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)
        {
            SqlConnection add_video_con = null;
            SqlCommand add_video_cmd = null;

            try
            {
                add_video_con = new SqlConnection();
                add_video_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                add_video_con.Open();

                add_video_cmd = new SqlCommand();
                add_video_cmd.Connection = add_video_con;
                add_video_cmd.CommandText = "add_emp_video_res";
                add_video_cmd.CommandType = CommandType.StoredProcedure;

                add_video_cmd.Parameters.AddWithValue("@title", textboxA1_3.Text.Trim());
                add_video_cmd.Parameters.AddWithValue("@link", textboxB1_3.Text.Trim());

                int check_success = add_video_cmd.ExecuteNonQuery();

                if (check_success >= 1)
                {
                    textboxA1_3.Enabled = false;  /*title textbox*/
                    textboxB1_3.Enabled = false;  /*link textbox*/
                    buttonA1_3.Enabled = false;  /*add button*/
                    successLabelA1_3.Visible = true;  /*success label*/
                }
                else
                {
                    Response.Write("<script>alert('Exception add_video_cmd.ExecuteNonQuery . Contact Admin')</script>");
                }
            }
            catch (Exception add_video_exp)
            {
                Response.Write("<script>alert('Exception add_video_exp . Contact Admin')</script>");
                Console.Write(add_video_exp.Message);
            }
            finally
            {
                add_video_cmd.Connection.Close();
                add_video_con.Close();
            }
        }


    }
}