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
    public partial class WFC_A_Notification_S_Em : System.Web.UI.UserControl
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

        protected void buttonA1_3_Click(object sender, EventArgs e)  /* send notification*/
        {
            SqlConnection save_empNotification_con = null;
            SqlCommand save_empNotification_cmd = null;

            try
            {
                save_empNotification_con = new SqlConnection();
                save_empNotification_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                save_empNotification_con.Open();

                save_empNotification_cmd = new SqlCommand();
                save_empNotification_cmd.Connection = save_empNotification_con;
                save_empNotification_cmd.CommandText = "save_EMPnotifications_p";
                save_empNotification_cmd.CommandType = CommandType.StoredProcedure;

                save_empNotification_cmd.Parameters.AddWithValue("@subject", textboxB1_3.Text.Trim());
                save_empNotification_cmd.Parameters.AddWithValue("@message", textboxC1_3.Text.Trim());

                int check_success = save_empNotification_cmd.ExecuteNonQuery();

                if (check_success >= 1)
                {
                    buttonA1_3.Enabled = false;  /*Send Notification button*/
                    textboxB1_3.Enabled = false;  /*subject textbox*/
                    textboxC1_3.Enabled = false;  /*message textbox*/
                    labelD1_3.Visible = true;  /*Message sent Label*/
                }
                else
                {
                    Response.Write("<script>alert('Exception save_empNotification_cmd.ExecuteNonQuery. Contact Admin')</script>");
                }
            }
            catch (Exception save_empNotification_exp)
            {
                Response.Write("<script>alert('Exception save_empNotification_exp . Contact Admin')</script>");
                Console.Write(save_empNotification_exp.Message);
            }
            finally
            {
                save_empNotification_cmd.Connection.Close();
                save_empNotification_con.Close();
            }
        }


    }
}