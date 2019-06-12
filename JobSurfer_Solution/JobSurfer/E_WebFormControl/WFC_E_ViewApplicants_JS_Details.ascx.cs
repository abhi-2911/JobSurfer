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
    public partial class WFC_E_ViewApplicants_JS_Details : System.Web.UI.UserControl
    {
        static string js_username_save;   /*save jobseeker username from query string(url)*/

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
                js_username_save = Request.QueryString["id"];   /*save jobseeker username from query string(url)*/

                pull_General_Info();    /*pull data from user registration table*/

                pull_Employment_Info();    /*pull data from user_Emplpyment table*/

                pull_Project_Info();    /*pull data from user_Project table*/

                pull_OnlineProfile_Info();    /*pull data from userOnlineProfile table*/

                pull_Certification_Info();    /*pull data from userCertification table*/

                pull_PersonalDetails_Info();    /*pull data from userPersonalDetails table*/

                pull_Education_Info();    /*pull data from userEducation table*/
            }

        }

        protected void pull_General_Info()    /*pull data from user registration table*/
        {
            SqlConnection pull_General_Info_con = null;
            SqlCommand pull_General_Info_cmd = null;
            SqlDataReader pull_General_Info_rdr = null;

            try
            {
                pull_General_Info_con = new SqlConnection();
                pull_General_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_General_Info_con.Open();

                pull_General_Info_cmd = new SqlCommand();
                pull_General_Info_cmd.Connection = pull_General_Info_con;
                pull_General_Info_cmd.CommandText = "pull_E_GeneralInfo_p";
                pull_General_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_General_Info_cmd.Parameters.AddWithValue("@userName", js_username_save);

                pull_General_Info_rdr = pull_General_Info_cmd.ExecuteReader();

                if (pull_General_Info_rdr.HasRows)
                {
                    while (pull_General_Info_rdr.Read())
                    {
                        /*for profile picture*/
                        byte[] imagedata = (byte[])pull_General_Info_rdr["profilePicture"];
                        string image_ready = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                        imageA1_3.ImageUrl = "data:image/jpeg;base64," + image_ready;

                        valuelabelA1_3.Text = pull_General_Info_rdr.GetString(2);  /*first name*/
                        valuelabelB1_3.Text = pull_General_Info_rdr.GetString(3);  /*last name*/
                        valuelabelC1_3.Text = pull_General_Info_rdr.GetString(4);  /*email id*/
                        valuelabelD1_3.Text = pull_General_Info_rdr.GetString(5);  /*contact details*/
                    }
                }
            }
            catch (Exception pull_General_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_General_Info_exp occured. Contact admin.')</script>");
                Response.Write(pull_General_Info_exp.Message);
            }
            finally
            {
                pull_General_Info_rdr.Close();
                pull_General_Info_cmd.Connection.Close();
                pull_General_Info_con.Close();
            }
        }

        protected void view_Resume()    /*pull data from  table,so when resume button is clicked it will display pdf in browser*/
        {                                                       /*this method will be in buttonResumeA1_3_click()*/
            SqlConnection viewResume_con = null;
            SqlCommand viewResume_cmd = null;
            SqlDataReader viewResume_rdr = null;            

            try
            {
                viewResume_con = new SqlConnection();
                viewResume_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                viewResume_con.Open();

                viewResume_cmd = new SqlCommand();
                viewResume_cmd.Connection = viewResume_con;
                viewResume_cmd.CommandText = "pullResume_p";
                viewResume_cmd.CommandType = CommandType.StoredProcedure;

                viewResume_cmd.Parameters.AddWithValue("@username", js_username_save);

                viewResume_rdr = viewResume_cmd.ExecuteReader();

                if (viewResume_rdr.HasRows)
                {
                    while (viewResume_rdr.Read())
                    {
                            byte[] docData = (byte[])viewResume_rdr["resume"];  /*resume pdf*/

                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", docData.Length.ToString());
                            Response.BinaryWrite(docData);
                    }
                }
            }
            catch (Exception veiwResume_exp)
            {
                Response.Write("<script>alert('veiwResume_exp Occured , Report to admin')</script>");
                Console.Write(veiwResume_exp.Message);
            }
            finally
            {
                viewResume_rdr.Close();
                viewResume_cmd.Connection.Close();
                viewResume_con.Close();
            }
        }

        protected void pull_Employment_Info()    /*pull data from user_Emplpyment table*/
        {
            SqlConnection pull_Employment_Info_con = null;
            SqlCommand pull_Employment_Info_cmd = null;
            SqlDataReader pull_Employment_Info_rdr = null;

            try
            {
                pull_Employment_Info_con = new SqlConnection();
                pull_Employment_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_Employment_Info_con.Open();

                pull_Employment_Info_cmd = new SqlCommand();
                pull_Employment_Info_cmd.Connection = pull_Employment_Info_con;
                pull_Employment_Info_cmd.CommandText = "pullEmployment_p";
                pull_Employment_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_Employment_Info_cmd.Parameters.AddWithValue("@userName", js_username_save);

                pull_Employment_Info_rdr = pull_Employment_Info_cmd.ExecuteReader();

                if (pull_Employment_Info_rdr.HasRows)
                {
                    while (pull_Employment_Info_rdr.Read())
                    {
                        valuelabelE1_3.Text = pull_Employment_Info_rdr.GetString(2);  /*Designation*/
                        valuelabelF1_3.Text = pull_Employment_Info_rdr.GetString(3);  /*Organization*/
                        valuelabelG1_3.Text = pull_Employment_Info_rdr.GetString(4);  /*Working*/
                    }
                }
            }
            catch (Exception pull_Employment_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_Employment_Info_exp occured. Contact admin.')</script>");
                Response.Write(pull_Employment_Info_exp.Message);
            }
            finally
            {
                pull_Employment_Info_rdr.Close();
                pull_Employment_Info_cmd.Connection.Close();
                pull_Employment_Info_con.Close();
            }
        }

        protected void pull_Project_Info()    /*pull data from user_Project table*/
        {
            SqlConnection pull_Project_Info_con = null;
            SqlCommand pull_Project_Info_cmd = null;
            SqlDataReader pull_Project_Info_rdr = null;

            try
            {
                pull_Project_Info_con = new SqlConnection();
                pull_Project_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_Project_Info_con.Open();

                pull_Project_Info_cmd = new SqlCommand();
                pull_Project_Info_cmd.Connection = pull_Project_Info_con;
                pull_Project_Info_cmd.CommandText = "pullProject_p";
                pull_Project_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_Project_Info_cmd.Parameters.AddWithValue("@userName", js_username_save);

                pull_Project_Info_rdr = pull_Project_Info_cmd.ExecuteReader();

                if (pull_Project_Info_rdr.HasRows)
                {
                    while (pull_Project_Info_rdr.Read())
                    {
                        valuelabelH_3.Text = pull_Project_Info_rdr.GetString(2);  /*Title*/
                        valuelabelI_3.Text = pull_Project_Info_rdr.GetString(3);  /*Project of*/
                        valuelabelJ_3.Text = pull_Project_Info_rdr.GetString(4);  /*Status*/
                        textboxK1_3.Text = pull_Project_Info_rdr.GetString(5);  /*Description*/
                    }
                }
            }
            catch (Exception pull_Project_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_Project_Info_exp occured. Contact admin.')</script>");
                Response.Write(pull_Project_Info_exp.Message);
            }
            finally
            {
                pull_Project_Info_rdr.Close();
                pull_Project_Info_cmd.Connection.Close();
                pull_Project_Info_con.Close();
            }
        }

        protected void pull_OnlineProfile_Info()    /*pull data from userOnlineProfile table*/
        {
            SqlConnection pull_OnlineProfile_Info_con = null;
            SqlCommand pull_OnlineProfile_Info_cmd = null;
            SqlDataReader pull_OnlineProfile_Info_rdr = null;

            try
            {
                pull_OnlineProfile_Info_con = new SqlConnection();
                pull_OnlineProfile_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_OnlineProfile_Info_con.Open();

                pull_OnlineProfile_Info_cmd = new SqlCommand();
                pull_OnlineProfile_Info_cmd.Connection = pull_OnlineProfile_Info_con;
                pull_OnlineProfile_Info_cmd.CommandText = "pullOnlineProfile_p";
                pull_OnlineProfile_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_OnlineProfile_Info_cmd.Parameters.AddWithValue("@userName", js_username_save);

                pull_OnlineProfile_Info_rdr = pull_OnlineProfile_Info_cmd.ExecuteReader();

                if (pull_OnlineProfile_Info_rdr.HasRows)
                {
                    while (pull_OnlineProfile_Info_rdr.Read())
                    {
                        valuelabelL1_3.Text = pull_OnlineProfile_Info_rdr.GetString(2);  /*Social Profile*/
                        buttonM1_3.PostBackUrl = pull_OnlineProfile_Info_rdr.GetString(3);  /*URL*/
                        textboxN1_3.Text = pull_OnlineProfile_Info_rdr.GetString(4);  /*Description*/
                    }
                }
            }
            catch (Exception pull_OnlineProfile_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_OnlineProfile_Info_exp occured. Contact admin.')</script>");
                Response.Write(pull_OnlineProfile_Info_exp.Message);
            }
            finally
            {
                pull_OnlineProfile_Info_rdr.Close();
                pull_OnlineProfile_Info_cmd.Connection.Close();
                pull_OnlineProfile_Info_con.Close();
            }
        }

        protected void pull_Certification_Info()    /*pull data from userCertification table*/
        {
            SqlConnection pull_Certification_Info_con = null;
            SqlCommand pull_Certification_Info_cmd = null;
            SqlDataReader pull_Certification_Info_rdr = null;

            try
            {
                pull_Certification_Info_con = new SqlConnection();
                pull_Certification_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_Certification_Info_con.Open();

                pull_Certification_Info_cmd = new SqlCommand();
                pull_Certification_Info_cmd.Connection = pull_Certification_Info_con;
                pull_Certification_Info_cmd.CommandText = "pullCertification_p";
                pull_Certification_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_Certification_Info_cmd.Parameters.AddWithValue("@userName", js_username_save);

                pull_Certification_Info_rdr = pull_Certification_Info_cmd.ExecuteReader();

                if (pull_Certification_Info_rdr.HasRows)
                {
                    while (pull_Certification_Info_rdr.Read())
                    {
                        valuelabelO1_3.Text = pull_Certification_Info_rdr.GetString(2);  /*Name*/
                        valuelabelP1_3.Text= pull_Certification_Info_rdr.GetString(3);  /*Institute*/
                        valuelabelQ1_3.Text = pull_Certification_Info_rdr.GetString(4);  /*Year*/
                    }
                }
            }
            catch (Exception pull_Certification_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_Certification_Info_exp occured. Contact admin.')</script>");
                Response.Write(pull_Certification_Info_exp.Message);
            }
            finally
            {
                pull_Certification_Info_rdr.Close();
                pull_Certification_Info_cmd.Connection.Close();
                pull_Certification_Info_con.Close();
            }
        }

        protected void pull_PersonalDetails_Info()    /*pull data from userPersonalDetails table*/
        {
            SqlConnection pull_PersonalDetails_Info_con = null;
            SqlCommand pull_PersonalDetails_Info_cmd = null;
            SqlDataReader pull_PersonalDetails_Info_rdr = null;

            try
            {
                pull_PersonalDetails_Info_con = new SqlConnection();
                pull_PersonalDetails_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_PersonalDetails_Info_con.Open();

                pull_PersonalDetails_Info_cmd = new SqlCommand();
                pull_PersonalDetails_Info_cmd.Connection = pull_PersonalDetails_Info_con;
                pull_PersonalDetails_Info_cmd.CommandText = "pullPersonalDetails_p";
                pull_PersonalDetails_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_PersonalDetails_Info_cmd.Parameters.AddWithValue("@userName", js_username_save);

                pull_PersonalDetails_Info_rdr = pull_PersonalDetails_Info_cmd.ExecuteReader();

                if (pull_PersonalDetails_Info_rdr.HasRows)
                {
                    while (pull_PersonalDetails_Info_rdr.Read())
                    {
                        valuedayR1_3.Text = pull_PersonalDetails_Info_rdr.GetString(2);  /*DOB_day*/
                        valuemonthR1_3.Text = pull_PersonalDetails_Info_rdr.GetString(3);  /*DOB_month*/
                        valueyearR1_3.Text = pull_PersonalDetails_Info_rdr.GetString(4);  /*DOB_year*/
                        valuelabelS1_3.Text = pull_PersonalDetails_Info_rdr.GetString(5);  /*Gender*/
                        valuelabelT1_3.Text = pull_PersonalDetails_Info_rdr.GetString(6);  /*State*/
                        valuelabelU1_3.Text = pull_PersonalDetails_Info_rdr.GetString(7);  /*City*/
                        valuelabelV1_3.Text = pull_PersonalDetails_Info_rdr.GetString(8);  /*HomeTown*/
                        valuelabelW1_3.Text = pull_PersonalDetails_Info_rdr.GetString(9);  /*Pincode*/
                        valuelabelX1_3.Text = pull_PersonalDetails_Info_rdr.GetString(10);  /*Marital Status*/
                    }
                }
            }
            catch (Exception pull_PersonalDetails_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_PersonalDetails_Info_exp occured. Contact admin.')</script>");
                Response.Write(pull_PersonalDetails_Info_exp.Message);
            }
            finally
            {
                pull_PersonalDetails_Info_rdr.Close();
                pull_PersonalDetails_Info_cmd.Connection.Close();
                pull_PersonalDetails_Info_con.Close();
            }
        }

        protected void pull_Education_Info()    /*pull data from userEducation table*/
        {
            SqlConnection pull_Education_Info_con = null;
            SqlCommand pull_Education_Info_cmd = null;
            SqlDataReader pull_Education_Info_rdr = null;

            try
            {
                pull_Education_Info_con = new SqlConnection();
                pull_Education_Info_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                pull_Education_Info_con.Open();

                pull_Education_Info_cmd = new SqlCommand();
                pull_Education_Info_cmd.Connection = pull_Education_Info_con;
                pull_Education_Info_cmd.CommandText = "pullEducation_p";
                pull_Education_Info_cmd.CommandType = CommandType.StoredProcedure;

                pull_Education_Info_cmd.Parameters.AddWithValue("@userName", js_username_save);

                pull_Education_Info_rdr = pull_Education_Info_cmd.ExecuteReader();

                if (pull_Education_Info_rdr.HasRows)
                {
                    while (pull_Education_Info_rdr.Read())
                    {
                        valuelabelY1_3.Text = pull_Education_Info_rdr.GetString(2);  /*Qualification*/
                        valuelabelZ1_3.Text = pull_Education_Info_rdr.GetString(3);  /*Course Name*/
                        valuelabelAA1_3.Text = pull_Education_Info_rdr.GetString(4);  /*College Name*/
                        valuelabelAB1_3.Text = pull_Education_Info_rdr.GetString(5);  /*University*/
                        valuelabelAC1_3.Text = pull_Education_Info_rdr.GetString(6) + " %";  /*Percentage*/
                    }
                }
            }
            catch (Exception pull_Education_Info_exp)
            {
                Response.Write("<script>alert('Exception pull_Education_Info_exp occured. Contact admin.')</script>");
                Response.Write(pull_Education_Info_exp.Message);
            }
            finally
            {
                pull_Education_Info_rdr.Close();
                pull_Education_Info_cmd.Connection.Close();
                pull_Education_Info_con.Close();
            }
        }

        protected void buttonResumeA1_3_Click(object sender, EventArgs e)   /*Resume button*/
        {
            view_Resume();    /*pull data from  table,so when resume button is clicked it will display pdf in browser*/
        }

        protected void buttonVideoResumeA1_3_Click(object sender, EventArgs e)    /*Video Resume Button*/
        {
            SqlConnection viewVideoResume_pull_con = null;
            SqlCommand viewVideoResume_pull_cmd = null;
            SqlDataReader viewVideoResume_pull_rdr = null;

            try
            {
                viewVideoResume_pull_con = new SqlConnection();
                viewVideoResume_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                viewVideoResume_pull_con.Open();

                viewVideoResume_pull_cmd = new SqlCommand();
                viewVideoResume_pull_cmd.Connection = viewVideoResume_pull_con;
                viewVideoResume_pull_cmd.CommandText = "pullVideoResume_p";
                viewVideoResume_pull_cmd.CommandType = CommandType.StoredProcedure;

                viewVideoResume_pull_cmd.Parameters.AddWithValue("@username", js_username_save);

                viewVideoResume_pull_rdr = viewVideoResume_pull_cmd.ExecuteReader();

                if (viewVideoResume_pull_rdr.HasRows)
                {
                    while (viewVideoResume_pull_rdr.Read())
                    {
                        string url_video_resume = viewVideoResume_pull_rdr.GetString(2);   /*storing the url in string variable */
                        Response.Write("<script>window.open(' "+ url_video_resume + " ','_blank');</script>");
                    }                                                                                                                                        /*providing that variable to response.write*/
                }
            }
            catch (Exception viewVideoResume_pull_exp)
            {
                Response.Write("<script>alert('viewVideoResume_pull_exp Occured , Report to admin')</script>");
                Console.Write(viewVideoResume_pull_exp.Message);
            }
            finally
            {
                viewVideoResume_pull_rdr.Close();
                viewVideoResume_pull_cmd.Connection.Close();
                viewVideoResume_pull_con.Close();
            }
        }
            
        }
    }