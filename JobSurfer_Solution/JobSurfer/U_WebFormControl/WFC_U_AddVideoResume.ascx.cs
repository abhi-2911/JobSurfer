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
    public partial class WFC_U_AddVideoResume : System.Web.UI.UserControl
    {
        string check_username = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


            if (Session["user"] != null)//check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }



            if (!IsPostBack)/*first time load*/
            {
                buttonB1_3.Visible = false;/*update*/

                videoResume_pull();/*check for data availability*/
            }


        }

        protected void buttonA1_3_Click(object sender, EventArgs e)/*save Button*/
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con.Open();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "saveVideoResume_p";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username",Session["user"].ToString());
                cmd.Parameters.AddWithValue("@videoResume", textboxA1_3.Text.Trim());

                int check_success = cmd.ExecuteNonQuery();

                if (check_success >= 1)/*success*/
                {
                    disable_controls();/*disable controls*/
                }
                else/*try again*/
                {
                    Response.Write("<script>alert('save_exp Occured , Report to admin')</script>");
                }

            }
            catch (Exception save_exp)
            {
                Response.Write("<script>alert('save_exp Occured , Report to admin')</script>");
                Console.Write(save_exp.Message);
            }
            finally
            {
                if (con !=null)
                {
                    cmd.Connection.Close();
                    con.Close();
                }
            }
        }

        protected void disable_controls()/*disable controls for save button*/
        {
            textboxA1_3.Enabled = false;
            buttonA1_3.Enabled = false;
        }

        protected void disable_controls_update()/*disable controls for update button*/
        {
            textboxA1_3.Enabled = false;
            buttonB1_3.Enabled = false;
        }

        protected void videoResume_pull() /*check data avilability*/
        {
            SqlConnection videoResume_pull_con = null;
            SqlCommand videoResume_pull_cmd = null;
            SqlDataReader videoResume_pull_rdr = null;

            try
            {
                videoResume_pull_con = new SqlConnection();
                videoResume_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                videoResume_pull_con.Open();

                videoResume_pull_cmd = new SqlCommand();
                videoResume_pull_cmd.Connection = videoResume_pull_con;
                videoResume_pull_cmd.CommandText = "pullVideoResume_p";
                videoResume_pull_cmd.CommandType = CommandType.StoredProcedure;

                videoResume_pull_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());

                videoResume_pull_rdr = videoResume_pull_cmd.ExecuteReader();

                if (videoResume_pull_rdr.HasRows)
                {
                    while (videoResume_pull_rdr.Read())
                    {
                       check_username = videoResume_pull_rdr.GetString(1);
                    }
                }

                videoResume_pull_rdr.Close();

                if (check_username != null)
                {
                    videoResume_pull_rdr = videoResume_pull_cmd.ExecuteReader();

                    if (videoResume_pull_rdr.HasRows)
                    {
                        while (videoResume_pull_rdr.Read())
                        {
                            textboxA1_3.Text = videoResume_pull_rdr.GetString(2);
                        }

                        buttonA1_3.Visible = false;/*save*/
                        buttonB1_3.Visible = true;/*update*/
                    }

                    videoResume_pull_rdr.Close();
                    videoResume_pull_cmd.Connection.Close();
                    videoResume_pull_con.Close();
                    check_username = null;

                }
                else
                {
                    /*continue*/
                    videoResume_pull_cmd.Connection.Close();
                    videoResume_pull_con.Close();
                    check_username = null;
                }

            }
            catch (Exception videoResume_pull_exp)
            {
                Response.Write("<script>alert('videoResume_pull_exp Occured , Report to admin')</script>");
                Console.Write(videoResume_pull_exp.Message);
            }

        }

        protected void buttonB1_3_Click(object sender, EventArgs e)/*update button*/
        {
            SqlConnection videoResume_update_con = null;
            SqlCommand videoResume_update_cmd = null;

            try
            {
                videoResume_update_con = new SqlConnection();
                videoResume_update_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                videoResume_update_con.Open();

                videoResume_update_cmd = new SqlCommand();
                videoResume_update_cmd.Connection = videoResume_update_con;
                videoResume_update_cmd.CommandText = "updateVideoResume_p";
                videoResume_update_cmd.CommandType = CommandType.StoredProcedure;

                videoResume_update_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                videoResume_update_cmd.Parameters.AddWithValue("@videoResume", textboxA1_3.Text.Trim());

                int check_success = videoResume_update_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*success*/
                {
                    disable_controls_update();/*disable controls*/
                }
                else/*try again*/
                {
                    Response.Write("<script>alert('save_exp Occured , Report to admin')</script>");
                }
            }
            catch (Exception videoResume_update_exp)
            {
                Response.Write("<script>alert('videoResume_update_exp Occured , Report to admin')</script>");
                Console.Write(videoResume_update_exp.Message);
            }
            finally
            {
                videoResume_update_cmd.Connection.Close();
                videoResume_update_con.Close();
            }

        }
    }
}