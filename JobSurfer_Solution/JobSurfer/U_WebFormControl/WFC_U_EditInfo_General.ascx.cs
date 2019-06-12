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
    public partial class WFC_U_EditInfo_General : System.Web.UI.UserControl
    {

        private SqlConnection con = null;
        private SqlCommand cmd = null;
        private SqlDataReader rdr = null;
        private string user_Name = null;

        private SqlConnection con_2 = null;
        private SqlCommand cmd_2 = null;
        private int check_update_rec;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                /*continue*/
            }
            else
            {
                /*redirect*/
                Response.Redirect("~/Website/HomePage.aspx");
            }

            buttonB1_3.Visible = false;
            buttonB1_3.Enabled = false;
            labelE1_3.Visible = false;

            if (!IsPostBack)/*only when page is loaded for the first time*/
            {
                try /*page load should display info about user first in textbox*/
                {
                    con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                    con.Open();

                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "showGeneralInfo_p";
                    cmd.CommandType = CommandType.StoredProcedure;

                    user_Name = Convert.ToString(Session["user"]);

                    cmd.Parameters.AddWithValue("@userName", user_Name);

                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            textboxA1_3.Text = rdr.GetString(0);
                            textboxB1_3.Text = rdr.GetString(1);
                            textboxC1_3.Text = rdr.GetString(2);
                            textboxD1_3.Text = rdr.GetString(3);
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('rdr has no rows. Contact admin.')</script>");
                    }

                }
                catch (Exception exp_1)
                {
                    Response.Write("<script>alert('Exception exp_1 occured. Contact admin.')</script>");
                    Response.Write(exp_1.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        protected void buttonA1_3_Click(object sender, EventArgs e)  /*update button*/
        {
            try
            {
                con_2 = new SqlConnection();
                con_2.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con_2.Open();

                cmd_2 = new SqlCommand();
                cmd_2.Connection = con_2;
                cmd_2.CommandText = "updateGeneralInfo_p";
                cmd_2.CommandType = CommandType.StoredProcedure;

                user_Name = Convert.ToString(Session["user"]);

                cmd_2.Parameters.AddWithValue("@userName", user_Name);
                cmd_2.Parameters.AddWithValue("@firstName", textboxA1_3.Text.Trim());
                cmd_2.Parameters.AddWithValue("@lastName", textboxB1_3.Text.Trim());
                cmd_2.Parameters.AddWithValue("@emailId", textboxC1_3.Text.Trim());
                cmd_2.Parameters.AddWithValue("@contactDetail", textboxD1_3.Text.Trim());

                check_update_rec = cmd_2.ExecuteNonQuery();

                if (check_update_rec==1)
                {
                    //updated
                    buttonB1_3.Enabled = true;/*profile button*/
                    buttonB1_3.Visible = true;/*profile button*/
                    labelE1_3.Visible = true;/*success label*/

                    buttonA1_3.Visible = false;/*update button*/
                    buttonA1_3.Enabled = false;/*update button*/

                    textbox_disable();/*disable textbox method*/
                }
                else
                {
                    //retry to update
                    Response.Write("<script>alert('Retry to update record. Contact admin.')</script>");
                }

            }
            catch (Exception exp_2)
            {
                Response.Write("<script>alert('Exception exp_2 occured. Contact admin.')</script>");
                Response.Write(exp_2.Message);
            }
            finally
            {
                con_2.Close();
            }
        }
        private void textbox_disable()/*method to disable textboxes*/
        {
            textboxA1_3.Enabled = false;
            textboxB1_3.Enabled = false;
            textboxC1_3.Enabled = false;
            textboxD1_3.Enabled = false;
        }
    }
}