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
    public partial class WFC_A_Notification_S_Js : System.Web.UI.UserControl
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
                labelD1_3.Visible = false;  /*notification sent Label*/
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)
        {
            SqlConnection save_jsNotification_con = null;
            SqlCommand save_jsNotification_cmd = null;

                try
                {
                save_jsNotification_con = new SqlConnection();
                save_jsNotification_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                save_jsNotification_con.Open();

                save_jsNotification_cmd = new SqlCommand();
                save_jsNotification_cmd.Connection = save_jsNotification_con;
                save_jsNotification_cmd.CommandText = "save_JSnotifications_p";
                save_jsNotification_cmd.CommandType = CommandType.StoredProcedure;

                save_jsNotification_cmd.Parameters.AddWithValue("@subject", textboxB1_3.Text.Trim());
                save_jsNotification_cmd.Parameters.AddWithValue("@message", textboxC1_3.Text.Trim());

                    int check_success = save_jsNotification_cmd.ExecuteNonQuery();

                    if (check_success >= 1)
                    {
                        buttonA1_3.Enabled = false;  /*Send Notification button*/
                        textboxB1_3.Enabled = false;  /*subject textbox*/
                        textboxC1_3.Enabled = false;  /*message textbox*/
                        labelD1_3.Visible = true;  /*Message sent Label*/
                    }
                    else
                    {
                        Response.Write("<script>alert('Exception save_jsNotification_cmd.ExecuteNonQuery. Contact Admin')</script>");
                    }
                }
                catch (Exception save_jsNotification_exp)
                {
                    Response.Write("<script>alert('Exception save_jsNotification_exp . Contact Admin')</script>");
                    Console.Write(save_jsNotification_exp.Message);
                }
                finally
                {
                save_jsNotification_cmd.Connection.Close();
                save_jsNotification_con.Close();
                }
            }


    }
}