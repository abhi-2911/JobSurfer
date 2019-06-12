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
    public partial class WFC_U_JobSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)//check for valid user 
            {
                //continue
            }
            else
            {
                Response.Redirect("~/Website/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                ddl_industry();   /*dropdownlist(Industry) */
            }

        }

        protected void ddl_industry()   /*dropdownlist(Industry) */
        {
            SqlConnection ddl_industry_con = null;
            SqlCommand ddl_industry_cmd = null;
            SqlDataReader ddl_industry_rdr = null;

            try
            {
                ddl_industry_con = new SqlConnection();
                ddl_industry_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                ddl_industry_con.Open();

                ddl_industry_cmd = new SqlCommand();
                ddl_industry_cmd.Connection = ddl_industry_con;
                ddl_industry_cmd.CommandText = "ddlIndustry_p";
                ddl_industry_cmd.CommandType = CommandType.StoredProcedure;

                ddl_industry_rdr = ddl_industry_cmd.ExecuteReader();
                ddlA1_3.DataSource = ddl_industry_rdr;
                ddlA1_3.DataTextField = "industry";
                ddlA1_3.DataBind();
            }
            catch (Exception ddl_industry_exp)
            {
                Response.Write("<script>alert('Exception ddl_industry_exp . Contact Admin')</script>");
                Console.Write(ddl_industry_exp.Message);
            }
            finally
            {
                ddl_industry_rdr.Close();
                ddl_industry_cmd.Connection.Close();
                ddl_industry_con.Close();
            }
        }

        protected void ddl_role()   /*dropdownlist(role) */
        {
            ListItem select_role = new ListItem("Select Role");
            SqlConnection ddl_role_con = null;
            SqlCommand ddl_role_cmd = null;
            SqlDataReader ddl_role_rdr = null;

            try
            {
                ddl_role_con = new SqlConnection();
                ddl_role_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                ddl_role_con.Open();

                ddl_role_cmd = new SqlCommand();
                ddl_role_cmd.Connection = ddl_role_con;
                ddl_role_cmd.CommandText = "ddlRole_p";
                ddl_role_cmd.CommandType = CommandType.StoredProcedure;

                ddl_role_cmd.Parameters.AddWithValue("@industryID", ddlA1_3.SelectedIndex);

                ddl_role_rdr = ddl_role_cmd.ExecuteReader();
                ddlB1_3.DataSource = ddl_role_rdr;
                ddlB1_3.Items.Clear();
                ddlB1_3.Items.Add(select_role);
                ddlB1_3.DataTextField = "role";
                ddlB1_3.DataBind();
            }
            catch (Exception ddl_role_exp)
            {
                Response.Write("<script>alert('Exception ddl_role_exp . Contact Admin')</script>");
                Console.Write(ddl_role_exp.Message);
            }
            finally
            {
                ddl_role_rdr.Close();
                ddl_role_cmd.Connection.Close();
                ddl_role_con.Close();
            }
        }

        protected void ddlA1_3_SelectedIndexChanged(object sender, EventArgs e)   /*when selected index of dropdownlist industry is changed*/
        {
            ddl_role();   /*dropdownlist(role) */
        }

        protected void buttonA1_3_Click(object sender, EventArgs e)   /*Search button*/
        {
            Session["industry"] = ddlA1_3.SelectedItem.Text;  /*industry and role are required for pulling data from jobs table*/
            Session["role"] = ddlB1_3.SelectedItem.Text;            /*on the next page*/
            Response.Redirect("~/User/U_JobSearch_Table.aspx");
        }


    }
}