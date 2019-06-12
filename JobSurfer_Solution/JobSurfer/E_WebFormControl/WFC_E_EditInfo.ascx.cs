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
    public partial class WFC_E_EditInfo : System.Web.UI.UserControl
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
                ddl_state();   /*method for putting data in dropdownlist state*/

                registrationInfo_pull();  /*pull information from registration table on page load*/

                labelH1_3.Visible = false;  /*success label*/

                buttonB1_3.Visible = false;   /*profile button*/
            }

        }

        protected void ddl_state()   /*method for putting data in dropdownlist state*/
        {
            SqlConnection state_con = null;
            SqlCommand state_cmd = null;
            SqlDataReader state_rdr = null;

            try
            {
                state_con = new SqlConnection();
                state_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                state_con.Open();

                state_cmd = new SqlCommand();
                state_cmd.Connection = state_con;
                state_cmd.CommandText = "ddlState_p";
                state_cmd.CommandType = CommandType.StoredProcedure;

                state_rdr = state_cmd.ExecuteReader();
                ddlA1_3.DataSource = state_rdr;
                ddlA1_3.DataTextField = "state";
                ddlA1_3.DataValueField = "stateid";
                ddlA1_3.DataBind();
            }
            catch (Exception state_exp)
            {
                Response.Write("<script>alert('Exception state_exp . Contact Admin')</script>");
                Console.Write(state_exp.Message);
            }
            finally
            {
                state_rdr.Close();
                state_cmd.Connection.Close();
                state_con.Close();
            }
        }

        protected void ddlA1_3_SelectedIndexChanged(object sender, EventArgs e)  /*when index of state ddl is changed it will fill city ddl*/
        {
            ListItem select_city = new ListItem("Select City", "0");
            SqlConnection state_indx_chng_con = null;
            SqlCommand state_indx_chng_cmd = null;
            SqlDataReader state_indx_chng_rdr = null;
            try
            {
                state_indx_chng_con = new SqlConnection();
                state_indx_chng_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                state_indx_chng_con.Open();

                state_indx_chng_cmd = new SqlCommand();
                state_indx_chng_cmd.Connection = state_indx_chng_con;
                state_indx_chng_cmd.CommandText = "ddlCity_p";
                state_indx_chng_cmd.CommandType = CommandType.StoredProcedure;

                state_indx_chng_cmd.Parameters.AddWithValue("@stateid", Convert.ToInt32(ddlA1_3.SelectedValue));

                state_indx_chng_rdr = state_indx_chng_cmd.ExecuteReader();
                ddlB1_3.DataSource = state_indx_chng_rdr;
                ddlB1_3.Items.Clear();
                ddlB1_3.Items.Add(select_city);
                ddlB1_3.DataTextField = "city";
                ddlB1_3.DataValueField = "cityid";
                ddlB1_3.DataBind();
            }
            catch (Exception state_indx_chng_exp)
            {
                Response.Write("<script>alert('Exception state_indx_chng_exp . Contact Admin')</script>");
                Console.Write(state_indx_chng_exp.Message);
            }
            finally
            {
                state_indx_chng_rdr.Close();
                state_indx_chng_cmd.Connection.Close();
                state_indx_chng_con.Close();
            }
        }

        protected void registrationInfo_pull()  /*pull information from registration table on page load*/
        {
            try
            {
                SqlConnection registrationInfo_pull_con = new SqlConnection();
                registrationInfo_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                registrationInfo_pull_con.Open();

                SqlCommand registrationInfo_pull_cmd = new SqlCommand();
                registrationInfo_pull_cmd.Connection = registrationInfo_pull_con;
                registrationInfo_pull_cmd.CommandText = "pull_E_RegistrationInfo_p";
                registrationInfo_pull_cmd.CommandType = CommandType.StoredProcedure;

                registrationInfo_pull_cmd.Parameters.AddWithValue("@username",Session["employer"].ToString());

                SqlDataReader registrationInfo_pull_rdr = registrationInfo_pull_cmd.ExecuteReader();

                if (registrationInfo_pull_rdr.HasRows)
                {
                    while (registrationInfo_pull_rdr.Read())
                    {
                        ddlA1_3.SelectedItem.Text = registrationInfo_pull_rdr.GetString(7);  /*State DropDownList*/
                        ddlB1_3.SelectedItem.Text = registrationInfo_pull_rdr.GetString(8);  /*City DropDownList*/
                        textboxA1_3.Text = registrationInfo_pull_rdr.GetString(2);  /*First Name*/
                        textboxB1_3.Text = registrationInfo_pull_rdr.GetString(3);  /*Last Name*/
                        textboxC1_3.Text = registrationInfo_pull_rdr.GetString(4);  /*Designation*/
                        textboxD1_3.Text = registrationInfo_pull_rdr.GetString(6);  /*Email Id*/
                        textboxE1_3.Text = registrationInfo_pull_rdr.GetString(11);  /*Contact Number*/
                    }
                }

                registrationInfo_pull_rdr.Close();
                registrationInfo_pull_cmd.Connection.Close();
                registrationInfo_pull_con.Close();
            }
            catch (Exception registrationInfo_pull_exp)
            {
                Response.Write("<script>alert('Exception registrationInfo_pull_exp . Contact Admin')</script>");
                Console.Write(registrationInfo_pull_exp.Message);
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*update button*/
        {
            try
            {
                SqlConnection update_registration_con = new SqlConnection();
                update_registration_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_registration_con.Open();

                SqlCommand update_registration_cmd = new SqlCommand();
                update_registration_cmd.Connection = update_registration_con;
                update_registration_cmd.CommandText = "update_E_Registration_p";
                update_registration_cmd.CommandType = CommandType.StoredProcedure;

                update_registration_cmd.Parameters.AddWithValue("@username",Session["employer"].ToString());
                update_registration_cmd.Parameters.AddWithValue("@firstName", textboxA1_3.Text.Trim());
                update_registration_cmd.Parameters.AddWithValue("@lastName", textboxB1_3.Text.Trim());
                update_registration_cmd.Parameters.AddWithValue("@designation", textboxC1_3.Text.Trim());
                update_registration_cmd.Parameters.AddWithValue("@emailID", textboxD1_3.Text.Trim());
                update_registration_cmd.Parameters.AddWithValue("@state", ddlA1_3.SelectedItem.Text);
                update_registration_cmd.Parameters.AddWithValue("@city", ddlB1_3.SelectedItem.Text);
                update_registration_cmd.Parameters.AddWithValue("@contactNumber", textboxE1_3.Text.Trim());

                 int check_update_rec =  update_registration_cmd.ExecuteNonQuery();

                if (check_update_rec >= 1)  /*updated*/
                {
                    buttonA1_3.Visible = false;   /*update button*/
                    labelH1_3.Visible = true;  /*success label*/
                    buttonB1_3.Visible = true;   /*profile button*/
                    disable_controls();  /*disable controls after successfull update*/
                   
                }
                else  /*retry*/
                {
                    Response.Write("<script>alert('update_registration_cmd.ExecuteNonQuery occured. Contact admin.')</script>");
                }

                update_registration_cmd.Connection.Close();
                update_registration_con.Close();

            }
            catch (Exception update_registration_exp)
            {
                Response.Write("<script>alert('Exception update_registration_exp occured. Contact admin.')</script>");
                Response.Write(update_registration_exp.Message);
            }
        }

         protected void disable_controls()  /*disable controls after successfull update*/
        {
            ddlA1_3.Enabled = false;  /*state dropdownlist*/
            ddlB1_3.Enabled = false;  /*city dropdownlist*/
            textboxA1_3.Enabled = false;  /*first name*/
            textboxB1_3.Enabled = false;  /*last name*/
            textboxC1_3.Enabled = false;  /*Designation*/
            textboxD1_3.Enabled = false;  /*Email Id*/
            textboxE1_3.Enabled = false;  /*Contact Number*/

        }


    }
}