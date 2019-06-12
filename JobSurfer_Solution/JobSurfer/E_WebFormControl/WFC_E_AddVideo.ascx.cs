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
    public partial class WFC_E_AddVideo : System.Web.UI.UserControl
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
                buttonB1_3.Visible = false;  /*update button*/

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

                if (emp_Video_pull_rdr.HasRows)
                {
                    while (emp_Video_pull_rdr.Read())
                    {
                        textboxA1_3.Text = emp_Video_pull_rdr.GetString(2);  /*companyVideo*/
                    }

                    buttonA1_3.Visible = false;  /*save button*/
                    buttonB1_3.Visible = true;  /*update button*/
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

        protected void buttonA1_3_Click(object sender, EventArgs e) /*save button*/
        {
            SqlConnection save_empVideo_con = null;
            SqlCommand save_empVideo_cmd = null;
            try
            {
                save_empVideo_con = new SqlConnection();
                save_empVideo_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                save_empVideo_con.Open();

                save_empVideo_cmd = new SqlCommand();
                save_empVideo_cmd.Connection = save_empVideo_con;
                save_empVideo_cmd.CommandText = "save_E_Video_p";
                save_empVideo_cmd.CommandType = CommandType.StoredProcedure;

                save_empVideo_cmd.Parameters.AddWithValue("@username", Session["employer"].ToString());
                save_empVideo_cmd.Parameters.AddWithValue("@companyVideo", textboxA1_3.Text.Trim());

                int check_success = save_empVideo_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*success*/
                {
                    disable_controls(); /*disable controls*/
                }
                else/*try again*/
                {
                    Response.Write("<script>alert('save_empVideo_cmd.ExecuteNonQuery Occured , Report to admin')</script>");
                }

            }
            catch (Exception save_empVideo_exp)
            {
                Response.Write("<script>alert('save_empVideo_exp Occured , Report to admin')</script>");
                Console.Write(save_empVideo_exp.Message);
            }
            finally
            {
                save_empVideo_cmd.Connection.Close();
                save_empVideo_con.Close();
            }
        }

        protected void disable_controls()  /*disable controls save button*/
        {
            textboxA1_3.Enabled = false; /*video textbox*/
            buttonA1_3.Enabled = false; /*save button*/
        }

        protected void disable_controls_update()  /*disable controls update btton*/
        {
            textboxA1_3.Enabled = false; /*video textbox*/
            buttonB1_3.Enabled = false; /*upadate button*/
        }

        protected void buttonB1_3_Click(object sender, EventArgs e)  /*update button*/
        {
            SqlConnection update_empVideo_con = null;
            SqlCommand update_empVideo_cmd = null;
            try
            {
                update_empVideo_con = new SqlConnection();
                update_empVideo_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_empVideo_con.Open();

                update_empVideo_cmd = new SqlCommand();
                update_empVideo_cmd.Connection = update_empVideo_con;
                update_empVideo_cmd.CommandText = "update_E_Video_p";
                update_empVideo_cmd.CommandType = CommandType.StoredProcedure;

                update_empVideo_cmd.Parameters.AddWithValue("@username", Session["employer"].ToString());
                update_empVideo_cmd.Parameters.AddWithValue("@companyVideo", textboxA1_3.Text.Trim());

                int check_success = update_empVideo_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*success*/
                {
                    disable_controls_update();  /*disable controls update btton*/
                }
                else/*try again*/
                {
                    Response.Write("<script>alert('update_empVideo_cmd.ExecuteNonQuery Occured , Report to admin')</script>");
                }

            }
            catch (Exception update_empVideo_exp)
            {
                Response.Write("<script>alert('update_empVideo_exp Occured , Report to admin')</script>");
                Console.Write(update_empVideo_exp.Message);
            }
            finally
            {
                update_empVideo_cmd.Connection.Close();
                update_empVideo_con.Close();
            }
        }
    }
}