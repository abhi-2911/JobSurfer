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
    public partial class WFC_E_Notification_Details : System.Web.UI.UserControl
    {
        static string notification_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employer"] != null)
            {
                /*continue*/
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                notification_id = Request.QueryString["id"];   /*pulling the job id from url*/

                pull_notifications();   /*for pulling js notifications from database*/
            }
        }

        protected void pull_notifications()   /*for pulling js notifications from database*/
        {
            SqlConnection pull_notification_con = null;
            SqlCommand pull_notification_cmd = null;
            SqlDataReader pull_notification_rdr = null;

            try
            {

                pull_notification_con = new SqlConnection();
                pull_notification_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_notification_con.Open();

                pull_notification_cmd = new SqlCommand();
                pull_notification_cmd.Connection = pull_notification_con;
                pull_notification_cmd.CommandText = "view_EMPnotifications_p";
                pull_notification_cmd.CommandType = CommandType.StoredProcedure;

                pull_notification_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(notification_id));

                pull_notification_rdr = pull_notification_cmd.ExecuteReader();

                if (pull_notification_rdr.HasRows)
                {
                    while (pull_notification_rdr.Read())
                    {
                        textboxB1_3.Text = pull_notification_rdr.GetString(0);                       /*Subject */
                        textboxC1_3.Text = pull_notification_rdr.GetString(1);                       /*Message */
                    }
                }

                pull_notification_rdr.Close();
                pull_notification_cmd.Connection.Close();
                pull_notification_con.Close();

            }
            catch (Exception pull_notification_exp)
            {
                Response.Write("<script>alert('Exception pull_notification_exp . Contact Admin')</script>");
                Console.Write(pull_notification_exp.Message);
            }
        }

    }
}