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
    public partial class WFC_U_EditInfo_Professional : System.Web.UI.UserControl
    {
        string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        SqlConnection con = null;
        SqlCommand cmd = null;      /*state dropdownlist*/
        SqlDataReader rdr = null;

        SqlConnection con_2 = null;
        SqlCommand cmd_2 = null;        /*city dropdownlist*/
        SqlDataReader rdr_2 = null;

        SqlConnection con_3 = null;
        SqlCommand cmd_3 = null;        /*Industry dropdownlist*/
        SqlDataReader rdr_3 = null;

        SqlConnection con_4 = null;
        SqlCommand cmd_4 = null;        /*role dropdownlist*/
        SqlDataReader rdr_4 = null;

        SqlConnection employment_con = null; /*for storing employment data*/
        SqlCommand employment_cmd = null;

        SqlConnection project_con = null; /*for storing project data*/
        SqlCommand project_cmd = null;

        SqlConnection onlineProfile_con = null; /*for storing online profile data*/
        SqlCommand onlineProfile_cmd = null;

        SqlConnection certification_con = null; /*for storing certification data*/
        SqlCommand certification_cmd = null;


        SqlConnection personalDetail_con = null; /*for storing personalDetail data*/
        SqlCommand personalDetail_cmd = null;

        SqlConnection dcf_con = null; /*for storing desired career profile data*/
        SqlCommand dcf_cmd = null;

        SqlConnection education_con = null; /*for storing education data*/
        SqlCommand education_cmd = null;

        string check_data_availability;

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
            if (!IsPostBack)
            {
                /*update buttons*/
                update_buttonA1_3.Visible = false; /*employment*/
                update_buttonB1_3.Visible = false; /*project*/
                update_buttonC1_3.Visible = false; /*online profile*/
                update_buttonD1_3.Visible = false; /*certification*/
                update_buttonE1_3.Visible = false; /*personal details*/
                update_buttonF1_3.Visible = false; /*desired career profile*/
                update_buttonG1_3.Visible = false; /*education*/


                for (int i = 2008; i <= 2018; i++)/*dropdownlist(year) of certification section*/
                {
                    ListItem certification_years = new ListItem(i.ToString());/*datatext*/
                    ddlA1_3.Items.Add(certification_years);
                }

                for (int j = 1; j <= 31; j++)/*dropdownlist(day) of personal_details section*/
                {
                    ListItem personal_details_day = new ListItem(j.ToString());/*datatext*/
                    ddlB1_3.Items.Add(personal_details_day);
                }

                for (int k = 0; k <= 11; k++)/*dropdownlist(month) of personal_details section*/
                {
                    ListItem personal_details_month = new ListItem(month[k]);/*datatext*/
                    ddlC1_3.Items.Add(personal_details_month);
                }

                for (int l = 1960; l <= 1998; l++)/*dropdownlist(year) of personal_details section*/
                {
                    ListItem personal_details_year = new ListItem(l.ToString());/*datatext*/
                    ddlD1_3.Items.Add(personal_details_year);
                }

                ddl_state();/*method for putting data in dropdownlist of Personal Details State*/

                for (int m = 0; m <= 90; m += 5)/*dropdownlist(lakh) of desired career profile*/
                {
                    ListItem desired_career_profile_lakh = new ListItem(m.ToString());/*datatext*/
                    ddlJ1_3.Items.Add(desired_career_profile_lakh);
                }


                for (int n = 5; n <= 90; n += 5)/*dropdownlist(thousand) of desired career profile*/
                {
                    ListItem desired_career_profile_thousand = new ListItem(n.ToString());/*datatext*/
                    ddlK1_3.Items.Add(desired_career_profile_thousand);
                }


                ddl_industry();/*dropdownlist(Industry) of desired career profile*/

                /*pull data and check availability*/
                employment_pull();
                project_pull();
                onlineProfile_pull();
                certification_pull();
                personalDetails_pull();
                dcp_pull();
                education_pull();

            }

            /*Success Labels*/
            success_labelA1_3.Visible = false;/*employment*/
            success_labelB1_3.Visible = false; /*project*/
            success_labelC1_3.Visible = false; /*Online profile*/
            success_labelD1_3.Visible = false; /*certification*/
            success_labelE1_3.Visible = false; /*personal details*/
            success_labelF1_3.Visible = false; /*Desired career profile*/
            success_labelG1_3.Visible = false; /*Education*/


        }

        protected void ddl_state()/*method for putting data in dropdownlist of personal detail state*/
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con.Open();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "ddlState_p";
                cmd.CommandType = CommandType.StoredProcedure;

                rdr = cmd.ExecuteReader();
                ddlE1_3.DataSource = rdr;
                ddlE1_3.DataTextField = "state";
                ddlE1_3.DataValueField = "stateid";
                ddlE1_3.DataBind();
            }
            catch (Exception exp_1)
            {
                Response.Write("<script>alert('Exception exp_1 . Contact Admin')</script>");
                Console.Write(exp_1.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void ddl_city()/*method for putting data in dropdownlist of personal detail city*/
        {
            ListItem select_city = new ListItem("Select City", "0");
            try
            {
                con_2 = new SqlConnection();
                con_2.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con_2.Open();

                cmd_2 = new SqlCommand();
                cmd_2.Connection = con_2;
                cmd_2.CommandText = "ddlCity_p";
                cmd_2.CommandType = CommandType.StoredProcedure;

                cmd_2.Parameters.AddWithValue("@stateid", Convert.ToInt32(ddlE1_3.SelectedValue));

                rdr_2 = cmd_2.ExecuteReader();
                ddlF1_3.DataSource = rdr_2;
                ddlF1_3.Items.Clear();
                ddlF1_3.Items.Add(select_city);
                ddlF1_3.DataTextField = "city";
                ddlF1_3.DataValueField = "cityid";
                ddlF1_3.DataBind();
            }
            catch (Exception exp_2)
            {
                Response.Write("<script>alert('Exception exp_2 . Contact Admin')</script>");
                Console.Write(exp_2.Message);
            }
            finally
            {
                con_2.Close();
            }

        }

        protected void ddlE1_3_SelectedIndexChanged(object sender, EventArgs e)/*when dropdownlist datatext of state is changed*/
        {
            ddl_city();
        }

        protected void ddl_industry()/*dropdownlist(Industry) of desired career profile*/
        {
            try
            {
                con_3 = new SqlConnection();
                con_3.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con_3.Open();

                cmd_3 = new SqlCommand();
                cmd_3.Connection = con_3;
                cmd_3.CommandText = "ddlIndustry_p";
                cmd_3.CommandType = CommandType.StoredProcedure;

                rdr_3 = cmd_3.ExecuteReader();
                ddlH1_3.DataSource = rdr_3;
                ddlH1_3.DataTextField = "industry";
                ddlH1_3.DataValueField = "industryID";
                ddlH1_3.DataBind();
            }
            catch (Exception exp_3)
            {
                Response.Write("<script>alert('Exception exp_3 . Contact Admin')</script>");
                Console.Write(exp_3.Message);
            }
            finally
            {
                con_3.Close();
            }
        }

        protected void ddlH1_3_SelectedIndexChanged(object sender, EventArgs e)/*dropdownlist(Industry) of desired career profile*/
        {
            ddl_role();
        }

        protected void ddl_role()/*dropdownlist(role) of desired career profile*/
        {
            ListItem select_role = new ListItem("Select Role", "0");

            try
            {
                con_4 = new SqlConnection();
                con_4.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                con_4.Open();

                cmd_4 = new SqlCommand();
                cmd_4.Connection = con_4;
                cmd_4.CommandText = "ddlRole_p";
                cmd_4.CommandType = CommandType.StoredProcedure;

                cmd_4.Parameters.AddWithValue("@industryID", Convert.ToInt32(ddlH1_3.SelectedIndex));

                rdr_4 = cmd_4.ExecuteReader();
                ddlI1_3.DataSource = rdr_4;
                ddlI1_3.Items.Clear();
                ddlI1_3.Items.Add(select_role);
                ddlI1_3.DataTextField = "role";
                ddlI1_3.DataValueField = "roleID";
                ddlI1_3.DataBind();
            }
            catch (Exception exp_4)
            {
                Response.Write("<script>alert('Exception exp_4 . Contact Admin')</script>");
                Console.Write(exp_4.Message);
            }
            finally
            {
                con_4.Close();
            }
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)/*employment button*/
        {
            try
            {
                employment_con = new SqlConnection();
                employment_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                employment_con.Open();

                employment_cmd = new SqlCommand();
                employment_cmd.Connection = employment_con;
                employment_cmd.CommandText = "saveEmployment_p";
                employment_cmd.CommandType = CommandType.StoredProcedure;

                employment_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                employment_cmd.Parameters.AddWithValue("@designation", textboxA1_3.Text.Trim());
                employment_cmd.Parameters.AddWithValue("@organization", textboxB1_3.Text.Trim());

                if (radiobuttonA1_3.Checked)/*radiobutton data of current company*/
                {
                    employment_cmd.Parameters.AddWithValue("@currentCompany", radiobuttonA1_3.Text);
                }
                else
                {
                    employment_cmd.Parameters.AddWithValue("@currentCompany", radiobuttonB1_3.Text);
                }

                int check_success = employment_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelA1_3.Visible = true;
                    employment_control_dis(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelA1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelA1_3.Text = "Retry to Save Data";
                    success_labelA1_3.Visible = true;
                }


            }
            catch (Exception employment_exp)
            {
                Response.Write("<script>alert('Exception employment_exp . Contact Admin')</script>");
                Console.Write(employment_exp.Message);
            }
            finally
            {
                employment_con.Close();
                employment_cmd.Connection.Close();
            }
        }

        protected void buttonB1_3_Click(object sender, EventArgs e)/*project button*/
        {
            try
            {
                project_con = new SqlConnection();
                project_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                project_con.Open();

                project_cmd = new SqlCommand();
                project_cmd.Connection = project_con;
                project_cmd.CommandText = "saveProject_p";
                project_cmd.CommandType = CommandType.StoredProcedure;

                project_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                project_cmd.Parameters.AddWithValue("@projectTitle", textboxC1_3.Text.Trim());

                if (radiobuttonC1_3.Checked)
                {
                    project_cmd.Parameters.AddWithValue("@tagProjectTo", radiobuttonC1_3.Text);
                }
                else
                {
                    project_cmd.Parameters.AddWithValue("@tagProjectTo", radiobuttonD1_3.Text);
                }

                if (radiobuttonE1_3.Checked)
                {
                    project_cmd.Parameters.AddWithValue("@projectStatus", radiobuttonE1_3.Text);
                }
                else
                {
                    project_cmd.Parameters.AddWithValue("@projectStatus", radiobuttonF1_3.Text);
                }

                project_cmd.Parameters.AddWithValue("@describeProject", textboxD1_3.Text.Trim());

                int check_success = project_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelB1_3.Visible = true;
                    project_control_dis(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelA1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelA1_3.Text = "Retry to Save Data";
                    success_labelA1_3.Visible = true;
                }

            }
            catch (Exception project_exp)
            {
                Response.Write("<script>alert('Exception project_exp . Contact Admin')</script>");
                Console.Write(project_exp.Message);
            }
            finally
            {
                project_con.Close();
                project_cmd.Connection.Close();
            }
        }

        protected void buttonC1_3_Click(object sender, EventArgs e)/*online profile button*/
        {
            try
            {
                onlineProfile_con = new SqlConnection();
                onlineProfile_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                onlineProfile_con.Open();

                onlineProfile_cmd = new SqlCommand();
                onlineProfile_cmd.Connection = onlineProfile_con;
                onlineProfile_cmd.CommandText = "saveOnlineProfile_p";
                onlineProfile_cmd.CommandType = CommandType.StoredProcedure;

                onlineProfile_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                onlineProfile_cmd.Parameters.AddWithValue("@socialProfile", textboxE1_3.Text.Trim());
                onlineProfile_cmd.Parameters.AddWithValue("@url", textboxF1_3.Text.Trim());
                onlineProfile_cmd.Parameters.AddWithValue("@description", textboxG1_3.Text.Trim());

                int check_success = onlineProfile_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelC1_3.Visible = true;
                    onlineProfile_control_dis(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelC1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelC1_3.Text = "Retry to Save Data";
                    success_labelC1_3.Visible = true;
                }
            }
            catch (Exception onlineProfile_exp)
            {
                Response.Write("<script>alert('Exception onlineProfile_exp . Contact Admin')</script>");
                Console.Write(onlineProfile_exp.Message);
            }
            finally
            {
                onlineProfile_con.Close();
                onlineProfile_cmd.Connection.Close();
            }
        }

        protected void buttonD1_3_Click(object sender, EventArgs e)/*certification button*/
        {
            try
            {
                certification_con = new SqlConnection();
                certification_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                certification_con.Open();

                certification_cmd = new SqlCommand();
                certification_cmd.Connection = certification_con;
                certification_cmd.CommandText = "saveCertification_p";
                certification_cmd.CommandType = CommandType.StoredProcedure;

                certification_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                certification_cmd.Parameters.AddWithValue("@certificationName", textboxH1_3.Text.Trim());
                certification_cmd.Parameters.AddWithValue("@certificationBody", textboxI1_3.Text.Trim());
                certification_cmd.Parameters.AddWithValue("@year", ddlA1_3.SelectedValue.Trim());

                int check_success = certification_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelD1_3.Visible = true;
                    certification_control_dis(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelD1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelD1_3.Text = "Retry to Save Data";
                    success_labelD1_3.Visible = true;
                }

            }
            catch (Exception certification_exp)
            {
                Response.Write("<script>alert('Exception certification_exp . Contact Admin')</script>");
                Console.Write(certification_exp.Message);
            }
            finally
            {
                certification_con.Close();
                certification_cmd.Connection.Close();
            }
        }

        protected void buttonE1_3_Click(object sender, EventArgs e)/*personal details*/
        {
            try
            {
                personalDetail_con = new SqlConnection();
                personalDetail_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                personalDetail_con.Open();

                personalDetail_cmd = new SqlCommand();
                personalDetail_cmd.Connection = personalDetail_con;
                personalDetail_cmd.CommandText = "savePersonalDetails_p";
                personalDetail_cmd.CommandType = CommandType.StoredProcedure;

                personalDetail_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                personalDetail_cmd.Parameters.AddWithValue("@dobDay", ddlB1_3.SelectedValue.ToString());
                personalDetail_cmd.Parameters.AddWithValue("@dobMonth", ddlC1_3.SelectedValue.ToString());
                personalDetail_cmd.Parameters.AddWithValue("@dobYear", ddlD1_3.SelectedValue.ToString());

                if (radiobuttonG1_3.Checked)
                {
                    personalDetail_cmd.Parameters.AddWithValue("@gender", radiobuttonG1_3.Text);
                }
                else
                {
                    personalDetail_cmd.Parameters.AddWithValue("@gender", radiobuttonH1_3.Text);
                }

                personalDetail_cmd.Parameters.AddWithValue("@state", ddlE1_3.SelectedItem.ToString());
                personalDetail_cmd.Parameters.AddWithValue("@city", ddlF1_3.SelectedItem.ToString());
                personalDetail_cmd.Parameters.AddWithValue("@hometown", textboxJ1_3.Text.Trim());
                personalDetail_cmd.Parameters.AddWithValue("@pincode", textboxK1_3.Text.Trim());
                personalDetail_cmd.Parameters.AddWithValue("@maritalStatus", ddlG1_3.SelectedValue);


                int check_success = personalDetail_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelE1_3.Visible = true;
                    personalDetails_control_dis(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelE1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelE1_3.Text = "Retry to Save Data";
                    success_labelE1_3.Visible = true;
                }
            }
            catch (Exception personalDetail_exp)
            {
                Response.Write("<script>alert('Exception personalDetail_exp . Contact Admin')</script>");
                Console.Write(personalDetail_exp.Message);
            }
            finally
            {
                personalDetail_con.Close();
                personalDetail_cmd.Connection.Close();
            }
        }

        protected void buttonF1_3_Click(object sender, EventArgs e)/*desired career profile button*/
        {
            try
            {
                dcf_con = new SqlConnection();
                dcf_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                dcf_con.Open();

                dcf_cmd = new SqlCommand();
                dcf_cmd.Connection = dcf_con;
                dcf_cmd.CommandText = "saveDCP_p";
                dcf_cmd.CommandType = CommandType.StoredProcedure;

                dcf_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                dcf_cmd.Parameters.AddWithValue("@industry", ddlH1_3.SelectedItem.ToString());
                dcf_cmd.Parameters.AddWithValue("@role", ddlI1_3.SelectedItem.ToString());

                if (checkboxA1_3.Checked && checkboxB1_3.Checked)/*permanent & contract true & true*/
                {
                    dcf_cmd.Parameters.AddWithValue("@jobType", "P&C");
                }
                else if (checkboxA1_3.Checked && !checkboxB1_3.Checked)/*permanent & contract true & false*/
                {
                    dcf_cmd.Parameters.AddWithValue("@jobType", "P");
                }
                else if (!checkboxA1_3.Checked && checkboxB1_3.Checked)/*permanent & contract false & true*/
                {
                    dcf_cmd.Parameters.AddWithValue("@jobType", "C");
                }
                else  /*permanent & contract false & fasle*/
                {
                    dcf_cmd.Parameters.AddWithValue("@jobType", "P");
                }


                if (checkboxC1_3.Checked && checkboxD1_3.Checked)/*fulltime & parttime true & true*/
                {
                    dcf_cmd.Parameters.AddWithValue("@employmentType", "F&P");
                }
                else if (checkboxC1_3.Checked && !checkboxD1_3.Checked)/*fulltime & parttime true & false*/
                {
                    dcf_cmd.Parameters.AddWithValue("@employmentType", "F");
                }
                else if (!checkboxC1_3.Checked && checkboxD1_3.Checked)/*fulltime & parttime false & true*/
                {
                    dcf_cmd.Parameters.AddWithValue("@employmentType", "P");
                }
                else  /*fulltime & parttime fasle & fasle*/
                {
                    dcf_cmd.Parameters.AddWithValue("@employmentType", "F");
                }

                if (radiobuttonI1_3.Checked) /*day night flexible , day selected*/
                {
                    dcf_cmd.Parameters.AddWithValue("@preferredShift", radiobuttonI1_3.Text);
                }
                else if (radiobuttonJ1_3.Checked)  /*day night flexible , night selected*/
                {
                    dcf_cmd.Parameters.AddWithValue("@preferredShift", radiobuttonJ1_3.Text);
                }
                else   /*day night flexible , flexible selected*/
                {
                    dcf_cmd.Parameters.AddWithValue("@preferredShift", radiobuttonK1_3.Text);
                }

                dcf_cmd.Parameters.AddWithValue("@expSalaryLakh", ddlJ1_3.SelectedValue.ToString());
                dcf_cmd.Parameters.AddWithValue("@expSalaryThousand", ddlK1_3.SelectedValue.ToString());

                int check_success = dcf_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelF1_3.Visible = true;
                    DCP_control_dis(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelF1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelF1_3.Text = "Retry to Save Data";
                    success_labelF1_3.Visible = true;
                }

            }
            catch (Exception dcp_exp)
            {
                Response.Write("<script>alert('Exception dcp_exp . Contact Admin')</script>");
                Console.Write(dcp_exp.Message);
            }
            finally
            {
                dcf_con.Close();
                dcf_cmd.Connection.Close();
            }
        }

        protected void buttonG1_3_Click(object sender, EventArgs e)/*education button*/
        {
            try
            {
                education_con = new SqlConnection();
                education_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                education_con.Open();

                education_cmd = new SqlCommand();
                education_cmd.Connection = education_con;
                education_cmd.CommandText = "saveEducation_p";
                education_cmd.CommandType = CommandType.StoredProcedure;

                education_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                education_cmd.Parameters.AddWithValue("@qualification", ddlL1_3.SelectedItem.ToString());
                education_cmd.Parameters.AddWithValue("@courseName", textboxL1_3.Text.Trim());
                education_cmd.Parameters.AddWithValue("@collegeName", textboxM1_3.Text.Trim());
                education_cmd.Parameters.AddWithValue("@universityName", textboxN1_3.Text.Trim());
                education_cmd.Parameters.AddWithValue("@percentage", textboxO1_3.Text.Trim());

                int check_success = education_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelG1_3.Visible = true;
                    education_control_dis(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelG1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelG1_3.Text = "Retry to Save Data";
                    success_labelG1_3.Visible = true;
                }

            }
            catch (Exception education_exp)
            {
                Response.Write("<script>alert('Exception education_exp . Contact Admin')</script>");
                Console.Write(education_exp.Message);
            }
            finally
            {

            }
        }


        /*********************disable controls**************************/


        protected void employment_control_dis()/*employment*/
        {
            textboxA1_3.Enabled = false;
            textboxB1_3.Enabled = false;
            radiobuttonA1_3.Enabled = false;
            radiobuttonB1_3.Enabled = false;
            buttonA1_3.Enabled = false;
        }

        protected void employment_control_dis_update()/*employment update button*/
        {
            textboxA1_3.Enabled = false;
            textboxB1_3.Enabled = false;
            radiobuttonA1_3.Enabled = false;
            radiobuttonB1_3.Enabled = false;
            update_buttonA1_3.Enabled = false;
        }

        protected void project_control_dis()/*project*/
        {
            textboxC1_3.Enabled = false;
            radiobuttonC1_3.Enabled = false;
            radiobuttonD1_3.Enabled = false;
            radiobuttonE1_3.Enabled = false;
            radiobuttonF1_3.Enabled = false;
            textboxD1_3.Enabled = false;
            buttonB1_3.Enabled = false;
        }
        protected void project_control_dis_update()/*project update button*/
        {
            textboxC1_3.Enabled = false;
            radiobuttonC1_3.Enabled = false;
            radiobuttonD1_3.Enabled = false;
            radiobuttonE1_3.Enabled = false;
            radiobuttonF1_3.Enabled = false;
            textboxD1_3.Enabled = false;
            update_buttonB1_3.Enabled = false;
        }
        protected void onlineProfile_control_dis()/*online profile*/
        {
            textboxE1_3.Enabled = false;
            textboxF1_3.Enabled = false;
            textboxG1_3.Enabled = false;
            buttonC1_3.Enabled = false;
        }
        protected void onlineProfile_control_dis_update()/*online profile update button*/
        {
            textboxE1_3.Enabled = false;
            textboxF1_3.Enabled = false;
            textboxG1_3.Enabled = false;
            update_buttonC1_3.Enabled = false;
        }

        protected void certification_control_dis()/*certification*/
        {
            textboxH1_3.Enabled = false;
            textboxI1_3.Enabled = false;
            ddlA1_3.Enabled = false;
            buttonD1_3.Enabled = false;
        }
        protected void certification_control_dis_update()/*certification update button*/
        {
            textboxH1_3.Enabled = false;
            textboxI1_3.Enabled = false;
            ddlA1_3.Enabled = false;
            update_buttonD1_3.Enabled = false;
        }

        protected void personalDetails_control_dis()/*personal details*/
        {
            ddlB1_3.Enabled = false;
            ddlC1_3.Enabled = false;
            ddlD1_3.Enabled = false;
            radiobuttonG1_3.Enabled = false;
            radiobuttonH1_3.Enabled = false;
            ddlE1_3.Enabled = false;
            ddlF1_3.Enabled = false;
            textboxJ1_3.Enabled = false;
            textboxK1_3.Enabled = false;
            ddlG1_3.Enabled = false;
            buttonE1_3.Enabled = false;
        }
        protected void personalDetails_control_dis_update()/*personal details update button*/
        {
            ddlB1_3.Enabled = false;
            ddlC1_3.Enabled = false;
            ddlD1_3.Enabled = false;
            radiobuttonG1_3.Enabled = false;
            radiobuttonH1_3.Enabled = false;
            ddlE1_3.Enabled = false;
            ddlF1_3.Enabled = false;
            textboxJ1_3.Enabled = false;
            textboxK1_3.Enabled = false;
            ddlG1_3.Enabled = false;
            update_buttonE1_3.Enabled = false;
        }

        protected void DCP_control_dis()/*desired career profile details*/
        {
            ddlH1_3.Enabled = false;
            ddlI1_3.Enabled = false;
            checkboxA1_3.Enabled = false;
            checkboxB1_3.Enabled = false;
            checkboxC1_3.Enabled = false;
            checkboxD1_3.Enabled = false;
            radiobuttonI1_3.Enabled = false;
            radiobuttonJ1_3.Enabled = false;
            radiobuttonK1_3.Enabled = false;
            ddlJ1_3.Enabled = false;
            ddlK1_3.Enabled = false;
            buttonF1_3.Enabled = false;
        }
        protected void DCP_control_dis_update()/*desired career profile update button*/
        {
            ddlH1_3.Enabled = false;
            ddlI1_3.Enabled = false;
            checkboxA1_3.Enabled = false;
            checkboxB1_3.Enabled = false;
            checkboxC1_3.Enabled = false;
            checkboxD1_3.Enabled = false;
            radiobuttonI1_3.Enabled = false;
            radiobuttonJ1_3.Enabled = false;
            radiobuttonK1_3.Enabled = false;
            ddlJ1_3.Enabled = false;
            ddlK1_3.Enabled = false;
            update_buttonF1_3.Enabled = false;
        }

        protected void education_control_dis()/*education details*/
        {
            ddlL1_3.Enabled = false;
            textboxL1_3.Enabled = false;
            textboxM1_3.Enabled = false;
            textboxN1_3.Enabled = false;
            textboxO1_3.Enabled = false;
            buttonG1_3.Enabled = false;
        }
        protected void education_control_dis_update()/*education update button*/
        {
            ddlL1_3.Enabled = false;
            textboxL1_3.Enabled = false;
            textboxM1_3.Enabled = false;
            textboxN1_3.Enabled = false;
            textboxO1_3.Enabled = false;
            update_buttonG1_3.Enabled = false;
        }

        /*********************pull data & check**************************/


        protected void employment_pull() /*check data availability in useremployment table*/
        {
            try
            {
                SqlConnection employment_pull_con = new SqlConnection();
                employment_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                employment_pull_con.Open();

                SqlCommand employment_pull_cmd = new SqlCommand();
                employment_pull_cmd.Connection = employment_pull_con;
                employment_pull_cmd.CommandText = "pullEmployment_p";
                employment_pull_cmd.CommandType = CommandType.StoredProcedure;

                employment_pull_cmd.Parameters.AddWithValue("@username",Session["user"].ToString());

                SqlDataReader employment_pull_rdr = employment_pull_cmd.ExecuteReader();

                if (employment_pull_rdr.HasRows)
                {
                    while (employment_pull_rdr.Read())
                    {
                        check_data_availability = employment_pull_rdr.GetString(1);/*username check*/
                    }
                }

                employment_pull_rdr.Close();


                if (check_data_availability != null)/*data is available*/
                {
                    /*pull data*/

                    employment_pull_rdr = employment_pull_cmd.ExecuteReader();

                    if (employment_pull_rdr.HasRows)
                    {
                        while (employment_pull_rdr.Read())
                        {

                            textboxA1_3.Text = employment_pull_rdr.GetString(2);/*designation*/
                            textboxB1_3.Text = employment_pull_rdr.GetString(3); /*organization*/
                            if (employment_pull_rdr.GetString(4) == "Yes") /*current company*/
                            {
                                radiobuttonA1_3.Checked = true;
                            }
                            else
                            {
                                radiobuttonB1_3.Checked = true;
                            }
                        }

                        update_buttonA1_3.Visible = true;/*update button*/
                        buttonA1_3.Visible = false;  /*save button*/

                    }

                    employment_pull_con.Close();
                    employment_pull_cmd.Connection.Close();
                    employment_pull_rdr.Close();
                    check_data_availability = null;

                }
                else
                {
                    /*continue*/
                    employment_pull_con.Close();
                    employment_pull_cmd.Connection.Close();
                    check_data_availability = null;
                }

            }
            catch (Exception employment_pull_exp)
            {
                Response.Write("<script>alert('Exception employment_pull_exp . Contact Admin')</script>");
                Console.Write(employment_pull_exp.Message);
            }

        }

        protected void project_pull() /*check data availability in userproject table*/
        {
            try
            {
                SqlConnection project_pull_con = new SqlConnection();
                project_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                project_pull_con.Open();

                SqlCommand project_pull_cmd = new SqlCommand();
                project_pull_cmd.Connection = project_pull_con;
                project_pull_cmd.CommandText = "pullProject_p";
                project_pull_cmd.CommandType = CommandType.StoredProcedure;

                project_pull_cmd.Parameters.AddWithValue("@username",Session["user"].ToString());

                SqlDataReader project_pull_rdr = project_pull_cmd.ExecuteReader();

                if (project_pull_rdr.HasRows)
                {
                    while (project_pull_rdr.Read())
                    {
                        check_data_availability = project_pull_rdr.GetString(1);/*username*/
                    }
                }

                project_pull_rdr.Close();

                if (check_data_availability != null)/*if data is available*/
                {
                    project_pull_rdr = project_pull_cmd.ExecuteReader();

                    if (project_pull_rdr.HasRows)
                    {
                        while (project_pull_rdr.Read())
                        {
                            textboxC1_3.Text = project_pull_rdr.GetString(2); /*project title*/

                            if (project_pull_rdr.GetString(3) == "Education")/*tag this project to*/
                            {
                                radiobuttonC1_3.Checked = true;
                            }
                            else
                            {
                                radiobuttonD1_3.Checked = true;
                            }

                            if (project_pull_rdr.GetString(4) == "Finished")/*project status*/
                            {
                                radiobuttonF1_3.Checked = true;
                            }
                            else
                            {
                                radiobuttonE1_3.Checked = true;
                            }

                            textboxD1_3.Text = project_pull_rdr.GetString(5);
                        }

                        update_buttonB1_3.Visible = true;
                        buttonB1_3.Visible = false;

                    }

                    project_pull_rdr.Close();
                    project_pull_cmd.Connection.Close();
                    project_pull_con.Close();
                    check_data_availability = null;

                }
                else
                {
                    project_pull_cmd.Connection.Close();
                    project_pull_con.Close();
                    check_data_availability = null;
                }

            }
            catch (Exception project_pull_exp)
            {
                Response.Write("<script>alert('Exception project_pull_exp . Contact Admin')</script>");
                Console.Write(project_pull_exp.Message);
            }
        }


        protected void onlineProfile_pull() /*check data availability in userOnlineProfile table*/
        {
            try
            {
                SqlConnection onlineProfile_pull_con = new SqlConnection();
                onlineProfile_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                onlineProfile_pull_con.Open();

                SqlCommand onlineProfile_pull_cmd = new SqlCommand();
                onlineProfile_pull_cmd.Connection = onlineProfile_pull_con;
                onlineProfile_pull_cmd.CommandText = "pullOnlineProfile_p";
                onlineProfile_pull_cmd.CommandType = CommandType.StoredProcedure;

                onlineProfile_pull_cmd.Parameters.AddWithValue("@username",Session["user"].ToString());

                SqlDataReader onlineProfile_pull_rdr = onlineProfile_pull_cmd.ExecuteReader();

                if (onlineProfile_pull_rdr.HasRows)
                {
                    while (onlineProfile_pull_rdr.Read())
                    {
                        check_data_availability = onlineProfile_pull_rdr.GetString(1); /*username*/
                    }
                }

                onlineProfile_pull_rdr.Close();

                if (check_data_availability != null)
                {
                    onlineProfile_pull_rdr = onlineProfile_pull_cmd.ExecuteReader();

                    if (onlineProfile_pull_rdr.HasRows)
                    {
                        while (onlineProfile_pull_rdr.Read())
                        {
                            textboxE1_3.Text = onlineProfile_pull_rdr.GetString(2);/*social profile*/

                            textboxF1_3.Text = onlineProfile_pull_rdr.GetString(3);/*url*/

                            textboxG1_3.Text = onlineProfile_pull_rdr.GetString(4); /*description*/
                        }

                        update_buttonC1_3.Visible = true;/*update button*/
                        buttonC1_3.Visible = false;  /*save button*/
                    }

                    /*close connections*/
                    onlineProfile_pull_rdr.Close();
                    onlineProfile_pull_cmd.Connection.Close();
                    onlineProfile_pull_con.Close();
                    check_data_availability = null;

                }
                else
                {
                    /*close connections and continue*/
                    onlineProfile_pull_cmd.Connection.Close();
                    onlineProfile_pull_con.Close();
                    check_data_availability = null;
                }

            }
            catch (Exception onlineProfile_pull_exp)
            {
                Response.Write("<script>alert('Exception onlineProfile_pull_exp . Contact Admin')</script>");
                Console.Write(onlineProfile_pull_exp.Message);
            }
        }


        protected void certification_pull() /*check data availability in userCertification table*/
        {
            try
            {
                SqlConnection certification_pull_con = new SqlConnection();
                certification_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                certification_pull_con.Open();

                SqlCommand certification_pull_cmd = new SqlCommand();
                certification_pull_cmd.Connection = certification_pull_con;
                certification_pull_cmd.CommandText = "pullCertification_p";
                certification_pull_cmd.CommandType = CommandType.StoredProcedure;

                certification_pull_cmd.Parameters.AddWithValue("username",Session["user"].ToString());

                SqlDataReader certification_pull_rdr = certification_pull_cmd.ExecuteReader();

                if (certification_pull_rdr.HasRows)
                {
                    while (certification_pull_rdr.Read())
                    {
                        check_data_availability = certification_pull_rdr.GetString(1);/*username*/
                    }
                }

                certification_pull_rdr.Close();

                if (check_data_availability != null)/*if data present*/
                {

                    certification_pull_rdr = certification_pull_cmd.ExecuteReader();

                    if (certification_pull_rdr.HasRows)
                    {
                        while (certification_pull_rdr.Read())
                        {
                            textboxH1_3.Text = certification_pull_rdr.GetString(2);/*Certification Name*/
                            textboxI1_3.Text = certification_pull_rdr.GetString(3);/*Certification Body*/
                            ddlA1_3.SelectedValue = certification_pull_rdr.GetString(4);/*Year*/
                        }

                        update_buttonD1_3.Visible = true;
                        buttonD1_3.Visible = false;
                    }

                    certification_pull_rdr.Close();
                    certification_pull_cmd.Connection.Close();
                    certification_pull_con.Close();
                    check_data_availability = null;

                }
                else/*if data absent*/
                {
                    certification_pull_cmd.Connection.Close();
                    certification_pull_con.Close();
                    check_data_availability = null;
                }

            }
            catch (Exception certification_pull_exp)
            {
                Response.Write("<script>alert('Exception certification_pull_exp . Contact Admin')</script>");
                Console.Write(certification_pull_exp.Message);
            }
        }

        protected void personalDetails_pull() /*check data availability in userPersonalDetails table*/
        {
            try
            {
                SqlConnection personalDetails_pull_con = new SqlConnection();
                personalDetails_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                personalDetails_pull_con.Open();

                SqlCommand personalDetails_pull_cmd = new SqlCommand();
                personalDetails_pull_cmd.Connection = personalDetails_pull_con;
                personalDetails_pull_cmd.CommandText = "pullPersonalDetails_p";
                personalDetails_pull_cmd.CommandType = CommandType.StoredProcedure;

                personalDetails_pull_cmd.Parameters.AddWithValue("@username",Session["user"].ToString());

                SqlDataReader personalDetails_pull_rdr = personalDetails_pull_cmd.ExecuteReader();

                if (personalDetails_pull_rdr.HasRows)
                {
                    while (personalDetails_pull_rdr.Read())
                    {
                        check_data_availability = personalDetails_pull_rdr.GetString(1);/*username*/
                    }
                }

                personalDetails_pull_rdr.Close();

                if (check_data_availability != null)
                {
                    personalDetails_pull_rdr = personalDetails_pull_cmd.ExecuteReader();

                    if (personalDetails_pull_rdr.HasRows)
                    {
                        while (personalDetails_pull_rdr.Read())
                        {
                            ddlB1_3.SelectedValue = personalDetails_pull_rdr.GetString(2);/*day*/
                            ddlC1_3.SelectedValue = personalDetails_pull_rdr.GetString(3);/*month*/
                            ddlD1_3.SelectedValue = personalDetails_pull_rdr.GetString(4);/*year*/

                            if (personalDetails_pull_rdr.GetString(5) == "Male")/*gender*/
                            {
                                radiobuttonG1_3.Checked = true;
                            }
                            else
                            {
                                radiobuttonH1_3.Checked = true;
                            }

                            ddlE1_3.SelectedItem.Text= personalDetails_pull_rdr.GetString(6);/*state*//*will change select state to the provided string*/
                            ddlF1_3.SelectedItem.Text = personalDetails_pull_rdr.GetString(7);/*city*//*will change select city to the provided string*/

                            textboxJ1_3.Text = personalDetails_pull_rdr.GetString(8);/*hometown*/
                            textboxK1_3.Text = personalDetails_pull_rdr.GetString(9);/*pincode*/

                            ddlG1_3.SelectedValue = personalDetails_pull_rdr.GetString(10);/*maritalStatus*/
                        }

                        update_buttonE1_3.Visible = true;
                        buttonE1_3.Visible = false;
                    }

                    personalDetails_pull_rdr.Close();
                    personalDetails_pull_cmd.Connection.Close();
                    personalDetails_pull_con.Close();
                    check_data_availability = null;
                }
                else
                {
                    personalDetails_pull_cmd.Connection.Close();
                    personalDetails_pull_con.Close();
                    check_data_availability = null;
                }

            }
            catch (Exception personalDetails_pull_exp)
            {
                Response.Write("<script>alert('Exception personalDetails_pull_exp . Contact Admin')</script>");
                Console.Write(personalDetails_pull_exp.Message);
            }
        }


        protected void dcp_pull() /*check data availability in userDCP table*/
        {
            try
            {
                SqlConnection dcp_pull_con = new SqlConnection();
                dcp_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                dcp_pull_con.Open();

                SqlCommand dcp_pull_cmd = new SqlCommand();
                dcp_pull_cmd.Connection = dcp_pull_con;
                dcp_pull_cmd.CommandText = "pullDCP_p";
                dcp_pull_cmd.CommandType = CommandType.StoredProcedure;

                dcp_pull_cmd.Parameters.AddWithValue("@username",Session["user"].ToString());

                SqlDataReader dcp_pull_rdr = dcp_pull_cmd.ExecuteReader();

                if (dcp_pull_rdr.HasRows)
                {
                    while (dcp_pull_rdr.Read())
                    {
                        check_data_availability = dcp_pull_rdr.GetString(1);/*username*/
                    }
                }

                dcp_pull_rdr.Close();

                if (check_data_availability != null)
                {
                    dcp_pull_rdr = dcp_pull_cmd.ExecuteReader();

                    if (dcp_pull_rdr.HasRows)
                    {
                        while (dcp_pull_rdr.Read())
                        {
                            ddlH1_3.SelectedItem.Text = dcp_pull_rdr.GetString(2);/*industry*/
                            ddlI1_3.SelectedItem.Text = dcp_pull_rdr.GetString(3);/*role*/

                            if (dcp_pull_rdr.GetString(4) == "P")/*job type*/
                            {
                                checkboxA1_3.Checked = true;
                            }
                            else if(dcp_pull_rdr.GetString(4) == "C")
                            {
                                checkboxB1_3.Checked = true;
                            }
                            else
                            {
                                checkboxA1_3.Checked = true;
                                checkboxB1_3.Checked = true;
                            }

                            if (dcp_pull_rdr.GetString(5) == "F")/*employment type*/
                            {
                                checkboxC1_3.Checked = true;
                            }
                            else if (dcp_pull_rdr.GetString(5) == "P")
                            {
                                checkboxD1_3.Checked = true;
                            }
                            else
                            {
                                checkboxC1_3.Checked = true;
                                checkboxD1_3.Checked = true;
                            }

                            if (dcp_pull_rdr.GetString(6) == "Day")/*preferred shift*/
                            {
                                radiobuttonI1_3.Checked = true;
                            }
                            else if (dcp_pull_rdr.GetString(6) == "Night")
                            {
                                radiobuttonJ1_3.Checked = true;
                            }
                            else
                            {
                                radiobuttonK1_3.Checked = true;
                            }

                            ddlJ1_3.SelectedValue = dcp_pull_rdr.GetString(7); /*expSalaryLakh*/
                            ddlK1_3.SelectedValue = dcp_pull_rdr.GetString(8); /*expSalaryThousand*/
                        }

                        update_buttonF1_3.Visible = true;
                        buttonF1_3.Visible = false;

                    }

                    dcp_pull_rdr.Close();
                    dcp_pull_cmd.Connection.Close();
                    dcp_pull_con.Close();
                    check_data_availability = null;

                }
                else
                {
                    dcp_pull_cmd.Connection.Close();
                    dcp_pull_con.Close();
                    check_data_availability = null;
                }

            }
            catch (Exception dcp_pull_exp)
            {
                Response.Write("<script>alert('Exception dcp_pull_exp . Contact Admin')</script>");
                Console.Write(dcp_pull_exp.Message);
            }
        }

        protected void education_pull() /*check data availability in userEducation table*/
        {
            try
            {
                SqlConnection education_pull_con = new SqlConnection();
                education_pull_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                education_pull_con.Open();

                SqlCommand education_pull_cmd = new SqlCommand();
                education_pull_cmd.Connection = education_pull_con;
                education_pull_cmd.CommandText = "pullEducation_p";
                education_pull_cmd.CommandType = CommandType.StoredProcedure;

                education_pull_cmd.Parameters.AddWithValue("@username",Session["user"].ToString());

                SqlDataReader education_pull_rdr = education_pull_cmd.ExecuteReader();

                if (education_pull_rdr.HasRows)
                {
                    while (education_pull_rdr.Read())
                    {
                        check_data_availability = education_pull_rdr.GetString(1);/*username*/
                    }
                }

                education_pull_rdr.Close();

                if (check_data_availability != null)
                {
                    education_pull_rdr = education_pull_cmd.ExecuteReader();

                    if (education_pull_rdr.HasRows)
                    {
                        while (education_pull_rdr.Read())
                        {
                            ddlL1_3.SelectedItem.Text= education_pull_rdr.GetString(2); /*qualification*/
                            textboxL1_3.Text = education_pull_rdr.GetString(3); /*courseName*/
                            textboxM1_3.Text = education_pull_rdr.GetString(4);/*collegeName*/
                            textboxN1_3.Text = education_pull_rdr.GetString(5);/*universityName*/
                            textboxO1_3.Text = education_pull_rdr.GetString(6);/*percentage*/
                        }

                        update_buttonG1_3.Visible = true;
                        buttonG1_3.Visible = false;
                    }

                    education_pull_rdr.Close();
                    education_pull_cmd.Connection.Close();
                    education_pull_con.Close();
                    check_data_availability = null;
                }
                else
                {
                    education_pull_cmd.Connection.Close();
                    education_pull_con.Close();
                    check_data_availability = null;
                }

            }
            catch (Exception education_pull_exp)
            {
                Response.Write("<script>alert('Exception education_pull_exp . Contact Admin')</script>");
                Console.Write(education_pull_exp.Message);
            }
        }

        /**************************Update buttons***********************************/
        protected void update_buttonA1_3_Click(object sender, EventArgs e)/*employment*/
        {
            SqlConnection update_employment_con = null;
            SqlCommand update_employment_cmd = null;

            try
            {
                update_employment_con = new SqlConnection();
                update_employment_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_employment_con.Open();

                update_employment_cmd = new SqlCommand();
                update_employment_cmd.Connection = update_employment_con;
                update_employment_cmd.CommandText = "updateEmployment_p";
                update_employment_cmd.CommandType = CommandType.StoredProcedure;


                update_employment_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                update_employment_cmd.Parameters.AddWithValue("@designation", textboxA1_3.Text.Trim());
                update_employment_cmd.Parameters.AddWithValue("@organization", textboxB1_3.Text.Trim());

                if (radiobuttonA1_3.Checked)/*radiobutton data of current company*/
                {
                    update_employment_cmd.Parameters.AddWithValue("@currentCompany", radiobuttonA1_3.Text);
                }
                else
                {
                    update_employment_cmd.Parameters.AddWithValue("@currentCompany", radiobuttonB1_3.Text);
                }

                int check_success = update_employment_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelA1_3.Visible = true;
                    employment_control_dis_update(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelA1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelA1_3.Text = "Retry to Save Data";
                    success_labelA1_3.Visible = true;
                }


            }
            catch (Exception update_employment_exp)
            {
                Response.Write("<script>alert('Exception update_employment_exp . Contact Admin')</script>");
                Console.Write(update_employment_exp.Message);
            }
            finally
            {
                update_employment_cmd.Connection.Close();
                update_employment_con.Close();
            }
        }

        protected void update_buttonB1_3_Click(object sender, EventArgs e)/*project*/
        {
            SqlConnection update_project_con = null;
            SqlCommand update_project_cmd = null;

            try
            {
                update_project_con = new SqlConnection();
                update_project_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_project_con.Open();

                update_project_cmd = new SqlCommand();
                update_project_cmd.Connection = update_project_con;
                update_project_cmd.CommandText = "updateProject_p";
                update_project_cmd.CommandType = CommandType.StoredProcedure;

                update_project_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                update_project_cmd.Parameters.AddWithValue("@projectTitle", textboxC1_3.Text.Trim());

                if (radiobuttonC1_3.Checked)
                {
                    update_project_cmd.Parameters.AddWithValue("@tagProjectTo", radiobuttonC1_3.Text);
                }
                else
                {
                    update_project_cmd.Parameters.AddWithValue("@tagProjectTo", radiobuttonD1_3.Text);
                }

                if (radiobuttonE1_3.Checked)
                {
                    update_project_cmd.Parameters.AddWithValue("@projectStatus", radiobuttonE1_3.Text);
                }
                else
                {
                    update_project_cmd.Parameters.AddWithValue("@projectStatus", radiobuttonF1_3.Text);
                }

                update_project_cmd.Parameters.AddWithValue("@describeProject", textboxD1_3.Text.Trim());

                int check_success = update_project_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelB1_3.Visible = true;
                    project_control_dis_update(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelA1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelA1_3.Text = "Retry to Save Data";
                    success_labelA1_3.Visible = true;
                }


            }
            catch (Exception update_project_exp)
            {
                Response.Write("<script>alert('Exception update_project_exp . Contact Admin')</script>");
                Console.Write(update_project_exp.Message);
            }
            finally
            {
                update_project_cmd.Connection.Close();
                update_project_con.Close();
            }
        }

        protected void update_buttonC1_3_Click(object sender, EventArgs e)/*online profile*/
        {
            SqlConnection update_onlineProfile_con = null;
            SqlCommand update_onlineProfile_cmd = null;

            try
            {
                update_onlineProfile_con = new SqlConnection();
                update_onlineProfile_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_onlineProfile_con.Open();

                update_onlineProfile_cmd = new SqlCommand();
                update_onlineProfile_cmd.Connection = update_onlineProfile_con;
                update_onlineProfile_cmd.CommandText = "updateOnlineProfile_p";
                update_onlineProfile_cmd.CommandType = CommandType.StoredProcedure;

                update_onlineProfile_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                update_onlineProfile_cmd.Parameters.AddWithValue("@socialProfile", textboxE1_3.Text.Trim());
                update_onlineProfile_cmd.Parameters.AddWithValue("@url", textboxF1_3.Text.Trim());
                update_onlineProfile_cmd.Parameters.AddWithValue("@description", textboxG1_3.Text.Trim());

                int check_success = update_onlineProfile_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelC1_3.Visible = true;
                    onlineProfile_control_dis_update(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelC1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelC1_3.Text = "Retry to Save Data";
                    success_labelC1_3.Visible = true;
                }
            }
            catch (Exception update_onlineProfile_exp)
            {
                Response.Write("<script>alert('Exception update_onlineProfile_exp . Contact Admin')</script>");
                Console.Write(update_onlineProfile_exp.Message);
            }
            finally
            {
                update_onlineProfile_cmd.Connection.Close();
                update_onlineProfile_con.Close();
            }
        }

        protected void update_buttonD1_3_Click(object sender, EventArgs e)/*certification*/
        {
            SqlConnection update_certification_con = null;
            SqlCommand update_certification_cmd = null;

            try
            {
                update_certification_con = new SqlConnection();
                update_certification_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_certification_con.Open();

                update_certification_cmd = new SqlCommand();
                update_certification_cmd.Connection = update_certification_con;
                update_certification_cmd.CommandText = "updateCertification_p";
                update_certification_cmd.CommandType = CommandType.StoredProcedure;

                update_certification_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                update_certification_cmd.Parameters.AddWithValue("@certificationName", textboxH1_3.Text.Trim());
                update_certification_cmd.Parameters.AddWithValue("@certificationBody", textboxI1_3.Text.Trim());
                update_certification_cmd.Parameters.AddWithValue("@year", ddlA1_3.SelectedValue.Trim());

                int check_success = update_certification_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelD1_3.Visible = true;
                    certification_control_dis_update(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelD1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelD1_3.Text = "Retry to Save Data";
                    success_labelD1_3.Visible = true;
                }
            }
            catch (Exception update_certification_exp)
            {
                Response.Write("<script>alert('Exception update_certification_exp . Contact Admin')</script>");
                Console.Write(update_certification_exp.Message);
            }finally
            {
                update_certification_cmd.Connection.Close();
                update_certification_con.Close();
            }
        }

        protected void update_buttonE1_3_Click(object sender, EventArgs e)
        {
            SqlConnection update_personalDetails_con = null;
            SqlCommand update_personalDetails_cmd = null;

            try
            {
                update_personalDetails_con = new SqlConnection();
                update_personalDetails_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_personalDetails_con.Open();

                update_personalDetails_cmd = new SqlCommand();
                update_personalDetails_cmd.Connection = update_personalDetails_con;
                update_personalDetails_cmd.CommandText = "updatePersonalDetails_p";
                update_personalDetails_cmd.CommandType = CommandType.StoredProcedure;

                update_personalDetails_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                update_personalDetails_cmd.Parameters.AddWithValue("@dobDay", ddlB1_3.SelectedValue.ToString());
                update_personalDetails_cmd.Parameters.AddWithValue("@dobMonth", ddlC1_3.SelectedValue.ToString());
                update_personalDetails_cmd.Parameters.AddWithValue("@dobYear", ddlD1_3.SelectedValue.ToString());

                if (radiobuttonG1_3.Checked)
                {
                    update_personalDetails_cmd.Parameters.AddWithValue("@gender", radiobuttonG1_3.Text);
                }
                else
                {
                    update_personalDetails_cmd.Parameters.AddWithValue("@gender", radiobuttonH1_3.Text);
                }

                update_personalDetails_cmd.Parameters.AddWithValue("@state", ddlE1_3.SelectedItem.ToString());
                update_personalDetails_cmd.Parameters.AddWithValue("@city", ddlF1_3.SelectedItem.ToString());
                update_personalDetails_cmd.Parameters.AddWithValue("@hometown", textboxJ1_3.Text.Trim());
                update_personalDetails_cmd.Parameters.AddWithValue("@pincode", textboxK1_3.Text.Trim());
                update_personalDetails_cmd.Parameters.AddWithValue("@maritalStatus", ddlG1_3.SelectedValue);


                int check_success = update_personalDetails_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelE1_3.Visible = true;
                    personalDetails_control_dis_update(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelE1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelE1_3.Text = "Retry to Save Data";
                    success_labelE1_3.Visible = true;
                }
            }
            catch (Exception update_personalDetails_exp)
            {
                Response.Write("<script>alert('Exception update_personalDetails_exp . Contact Admin')</script>");
                Console.Write(update_personalDetails_exp.Message);
            }
            finally
            {
                update_personalDetails_cmd.Connection.Close();
                update_personalDetails_con.Close();
            }
        }

        protected void update_buttonF1_3_Click(object sender, EventArgs e)/*desired career profile*/
        {
            SqlConnection update_DCP_con = null;
            SqlCommand update_DCP_cmd = null;

            try
            {
                update_DCP_con = new SqlConnection();
                update_DCP_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_DCP_con.Open();

                update_DCP_cmd = new SqlCommand();
                update_DCP_cmd.Connection = update_DCP_con;
                update_DCP_cmd.CommandText = "updateDCP_p";
                update_DCP_cmd.CommandType = CommandType.StoredProcedure;

                update_DCP_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                update_DCP_cmd.Parameters.AddWithValue("@industry", ddlH1_3.SelectedItem.ToString());
                update_DCP_cmd.Parameters.AddWithValue("@role", ddlI1_3.SelectedItem.ToString());

                if (checkboxA1_3.Checked && checkboxB1_3.Checked)/*permanent & contract true & true*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@jobType", "P&C");
                }
                else if (checkboxA1_3.Checked && !checkboxB1_3.Checked)/*permanent & contract true & false*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@jobType", "P");
                }
                else if (!checkboxA1_3.Checked && checkboxB1_3.Checked)/*permanent & contract false & true*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@jobType", "C");
                }
                else  /*permanent & contract false & fasle*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@jobType", "P");
                }


                if (checkboxC1_3.Checked && checkboxD1_3.Checked)/*fulltime & parttime true & true*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@employmentType", "F&P");
                }
                else if (checkboxC1_3.Checked && !checkboxD1_3.Checked)/*fulltime & parttime true & false*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@employmentType", "F");
                }
                else if (!checkboxC1_3.Checked && checkboxD1_3.Checked)/*fulltime & parttime false & true*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@employmentType", "P");
                }
                else  /*fulltime & parttime fasle & fasle*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@employmentType", "F");
                }

                if (radiobuttonI1_3.Checked) /*day night flexible , day selected*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@preferredShift", radiobuttonI1_3.Text);
                }
                else if (radiobuttonJ1_3.Checked)  /*day night flexible , night selected*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@preferredShift", radiobuttonJ1_3.Text);
                }
                else   /*day night flexible , flexible selected*/
                {
                    update_DCP_cmd.Parameters.AddWithValue("@preferredShift", radiobuttonK1_3.Text);
                }

                update_DCP_cmd.Parameters.AddWithValue("@expSalaryLakh", ddlJ1_3.SelectedValue.ToString());
                update_DCP_cmd.Parameters.AddWithValue("@expSalaryThousand", ddlK1_3.SelectedValue.ToString());

                int check_success = update_DCP_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelF1_3.Visible = true;
                    DCP_control_dis_update(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelF1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelF1_3.Text = "Retry to Save Data";
                    success_labelF1_3.Visible = true;
                }
            }
            catch (Exception update_DCP_exp)
            {
                Response.Write("<script>alert('Exception update_DCP_exp . Contact Admin')</script>");
                Console.Write(update_DCP_exp.Message);
            }
            finally
            {
                update_DCP_cmd.Connection.Close();
                update_DCP_con.Close();
            }

        }

        protected void update_buttonG1_3_Click(object sender, EventArgs e)/*education*/
        {
            SqlConnection update_education_con = null;
            SqlCommand update_education_cmd = null;

            try
            {
                update_education_con = new SqlConnection();
                update_education_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                update_education_con.Open();

                update_education_cmd = new SqlCommand();
                update_education_cmd.Connection = update_education_con;
                update_education_cmd.CommandText = "updateEducation_p";
                update_education_cmd.CommandType = CommandType.StoredProcedure;

                update_education_cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                update_education_cmd.Parameters.AddWithValue("@qualification", ddlL1_3.SelectedItem.ToString());
                update_education_cmd.Parameters.AddWithValue("@courseName", textboxL1_3.Text.Trim());
                update_education_cmd.Parameters.AddWithValue("@collegeName", textboxM1_3.Text.Trim());
                update_education_cmd.Parameters.AddWithValue("@universityName", textboxN1_3.Text.Trim());
                update_education_cmd.Parameters.AddWithValue("@percentage", textboxO1_3.Text.Trim());

                int check_success = update_education_cmd.ExecuteNonQuery();

                if (check_success >= 1)/*data added, success*/
                {
                    success_labelG1_3.Visible = true;
                    education_control_dis_update(); /*disable controls*/
                }
                else/*retry to insert data*/
                {
                    success_labelG1_3.ForeColor = System.Drawing.Color.Red;
                    success_labelG1_3.Text = "Retry to Save Data";
                    success_labelG1_3.Visible = true;
                }
            }
            catch (Exception update_education_exp)
            {
                Response.Write("<script>alert('Exception update_education_exp . Contact Admin')</script>");
                Console.Write(update_education_exp.Message);
            }
            finally
            {
                update_education_cmd.Connection.Close();
                update_education_con.Close();
            }

        }
    }
}