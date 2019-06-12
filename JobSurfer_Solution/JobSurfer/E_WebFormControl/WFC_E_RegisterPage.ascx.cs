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
    public partial class WFC_E_RegisterPage : System.Web.UI.UserControl
    {

        int check_username_flag; /*flag for checking unique username and password length*/

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                check_username_flag = 0; /*flag for checking unique username*/

                ddl_state(); /*method for putting data in dropdownlist state*/

                ddl_industry(); /*dropdownlist(Industry)*/

                buttonB1_3.Visible = false; /*login button*/
            }
        }

        protected void cvA1_3_ServerValidate(object source, ServerValidateEventArgs args)/*unique username custom validator*/
        {
            SqlConnection uni_username_con = null;
            SqlCommand uni_username_cmd = null;

            try
            {
                uni_username_con = new SqlConnection();
                uni_username_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                uni_username_con.Open();

                uni_username_cmd = new SqlCommand();
                uni_username_cmd.Connection = uni_username_con;
                uni_username_cmd.CommandText = "emp_username_check_p";
                uni_username_cmd.CommandType = CommandType.StoredProcedure;

                uni_username_cmd.Parameters.AddWithValue("@username", textboxA1_3.Text.Trim());/*provided value to parameter*/

                check_username_flag = Convert.ToInt32(uni_username_cmd.ExecuteScalar());

                if (check_username_flag == 1)/*username already exists*/
                {
                    args.IsValid = false;
                    Response.Write("<script>alert('Username Already Exists. Change Username')</script>");
                }
                else /*username is available*/
                {
                    /*continue because check_username_flag is already = 0 when page loaded*/
                }
            }
            catch (Exception uni_username_exp)
            {
                Response.Write("<script>alert('uni_username_exp occured. Contact Admin')</script>");
                Console.Write(uni_username_exp.Message);
            }
            finally
            {
                uni_username_cmd.Connection.Close();
                uni_username_con.Close();
            }

        }

        protected void cvB1_3_ServerValidate(object source, ServerValidateEventArgs args)  /*password minimum 4 characters required custom validator*/
        {
            if (textboxI1_3.Text.Length < 4) /*min 4 char of password are required*/
            {
                /*invalid*/
                check_username_flag = 1;
                Response.Write("<script>alert('Password Minimum 4 char.')</script>");
                args.IsValid = false;

            }
            else /*4 char are present*/
            {
                /*args by deefault is true also,*/
                /*continue because check_username_flag is already = 0 when page loaded*/
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

        protected void ddlA1_3_SelectedIndexChanged(object sender, EventArgs e) /*when index of state ddl is changed it will fill city ddl*/
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


        protected void ddl_industry()/*dropdownlist(Industry)*/
        {
            SqlConnection industry_con = null;
            SqlCommand industry_cmd = null;
            SqlDataReader industry_rdr = null;

            try
            {
                industry_con = new SqlConnection();
                industry_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                industry_con.Open();

                industry_cmd = new SqlCommand();
                industry_cmd.Connection = industry_con;
                industry_cmd.CommandText = "ddlIndustry_p";
                industry_cmd.CommandType = CommandType.StoredProcedure;

                industry_rdr = industry_cmd.ExecuteReader();
                ddlC1_3.DataSource = industry_rdr;
                ddlC1_3.DataTextField = "industry";
                ddlC1_3.DataValueField = "industryID";
                ddlC1_3.DataBind();
            }
            catch (Exception industry_exp)
            {
                Response.Write("<script>alert('Exception industry_exp . Contact Admin')</script>");
                Console.Write(industry_exp.Message);
            }
            finally
            {
                industry_rdr.Close();
                industry_cmd.Connection.Close();
                industry_con.Close();
            }
        }


        protected void buttonA1_3_Click(object sender, EventArgs e) /*register button click*/
        {
            SqlCommand register_cmd = null;
            SqlConnection register_con = null;

            if (check_username_flag == 0) /*username is available*/
            {
                string fileType = fileuploadA1_3.PostedFile.ContentType;/*image/jpeg , image/png*/

                if (fileType == "image/jpeg" || fileType == "image/png")
                {
                    int fileSize = fileuploadA1_3.PostedFile.ContentLength;

                    if (fileSize < 4194304) /*4194304 bytes is 4MB, 1048567 bytes is 1MB */
                    {
                        /*image to byte[]*/
                        byte[] picData = new byte[fileSize];
                        fileuploadA1_3.PostedFile.InputStream.Read(picData, 0, fileSize);

                        try
                        {
                            /*upload of data to sql server*/
                            register_con = new SqlConnection();
                            register_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                            register_con.Open();

                            register_cmd = new SqlCommand();
                            register_cmd.Connection = register_con;
                            register_cmd.CommandText = "empRegistration_To_empLogin";
                            register_cmd.CommandType = CommandType.StoredProcedure;

                            register_cmd.Parameters.AddWithValue("@userName", textboxA1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@firstName", textboxB1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@lastName", textboxC1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@designation", textboxD1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@companyName", textboxE1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@emailID", textboxF1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@state", ddlA1_3.SelectedItem.Text);
                            register_cmd.Parameters.AddWithValue("@city", ddlB1_3.SelectedItem.Text);
                            register_cmd.Parameters.AddWithValue("@industry", ddlC1_3.SelectedItem.Text);
                            register_cmd.Parameters.AddWithValue("@address", textboxG1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@contactNumber", textboxH1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@password", textboxJ1_3.Text.Trim());
                            register_cmd.Parameters.AddWithValue("@profilePicture", picData);
                            register_cmd.Parameters.AddWithValue("@accDate", DateTime.Now);

                            int checkSuccess = register_cmd.ExecuteNonQuery();

                            if (checkSuccess == 2)
                            {
                                /*success*/
                                disable_controls();
                                buttonA1_3.Visible = false; /*register*/
                                buttonB1_3.Visible = true; /*login*/

                            }
                            else
                            {
                                /*error in insert transaction*/
                                Response.Write("<script>alert('register_cmd_ExecuteNonQuery. Contact Admin')</script>");
                            }
                        }
                        catch (Exception register_exp)
                        {
                            Response.Write("<script>alert('register_exp Occured, report this to admin')</script>");
                            Console.Write(register_exp.Message);
                        }
                        finally
                        {
                            register_cmd.Connection.Close();
                            register_con.Close();
                        }

                    }
                    else
                    {
                        /*filesize of less than 4MB required*/
                        Response.Write("<script>alert('Profile Picture size should be less than 4MB')</script>");
                    }
                }
                else
                {
                    /*filtype should be png or jpg*/
                    Response.Write("<script>alert('Profile Picture Should be .jpg or .png')</script>");
                }
            }

        }


        protected void disable_controls() /*disable all the controls after successfull registration*/
        {
            textboxA1_3.Enabled = false;
            textboxB1_3.Enabled = false; ;
            textboxC1_3.Enabled = false; ;
            textboxD1_3.Enabled = false; ;
            textboxE1_3.Enabled = false; ;
            textboxF1_3.Enabled = false; ;
            ddlA1_3.Enabled = false; ;
            ddlB1_3.Enabled = false; ;
            ddlC1_3.Enabled = false; ;
            textboxG1_3.Enabled = false; ;
            textboxH1_3.Enabled = false; ;
            textboxI1_3.Enabled = false; ;
            textboxJ1_3.Enabled = false; ;
            fileuploadA1_3.Enabled = false; ;
            buttonA1_3.Enabled = false; ;
        }



    }
}