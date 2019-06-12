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
    public partial class WFC_E_Message_Details : System.Web.UI.UserControl
    {
        static string message_id;  /*for storing message id from url*/

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
                message_id = Request.QueryString["id"];   /*pulling the message id from url*/

                pull_messages();   /*for pulling emp messages from database*/
            }
        }

        protected void pull_messages()   /*for pulling emp messages from database*/
        {
            SqlConnection pull_messages_con = null;
            SqlCommand pull_messages_cmd = null;
            SqlDataReader pull_messages_rdr = null;

            try
            {

                pull_messages_con = new SqlConnection();
                pull_messages_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_messages_con.Open();

                pull_messages_cmd = new SqlCommand();
                pull_messages_cmd.Connection = pull_messages_con;
                pull_messages_cmd.CommandText = "view_EMPmessages_p";
                pull_messages_cmd.CommandType = CommandType.StoredProcedure;

                pull_messages_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(message_id));

                pull_messages_rdr = pull_messages_cmd.ExecuteReader();

                if (pull_messages_rdr.HasRows)
                {
                    while (pull_messages_rdr.Read())
                    {
                        textboxB1_3.Text = pull_messages_rdr.GetString(1);                       /*Subject */
                        textboxC1_3.Text = pull_messages_rdr.GetString(2);                       /*Message */
                    }
                }

                pull_messages_rdr.Close();
                pull_messages_cmd.Connection.Close();
                pull_messages_con.Close();

            }
            catch (Exception pull_messages_exp)
            {
                Response.Write("<script>alert('Exception pull_messages_exp . Contact Admin')</script>");
                Console.Write(pull_messages_exp.Message);
            }
        }

    }
}