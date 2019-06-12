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
    public partial class WFC_E_Resource_D : System.Web.UI.UserControl
    {
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
        }

        protected void gvA1_3_SelectedIndexChanged(object sender, EventArgs e)  /*open button click within gridview*/
        {
            Label doc_id = gvA1_3.SelectedRow.FindControl("labelA1_3") as Label;

            SqlConnection viewDoc_con = null;
            SqlCommand viewDoc_cmd = null;
            SqlDataReader viewDoc_rdr = null;

            try
            {
                viewDoc_con = new SqlConnection();
                viewDoc_con.ConnectionString = "Data Source=DESKTOP-NKM47LH\\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True";
                viewDoc_con.Open();

                viewDoc_cmd = new SqlCommand();
                viewDoc_cmd.Connection = viewDoc_con;
                viewDoc_cmd.CommandText = "pull_emp_doc_res";
                viewDoc_cmd.CommandType = CommandType.StoredProcedure;

                viewDoc_cmd.Parameters.AddWithValue("@id", Convert.ToInt32(doc_id.Text));

                viewDoc_rdr = viewDoc_cmd.ExecuteReader();

                if (viewDoc_rdr.HasRows)
                {
                    while (viewDoc_rdr.Read())
                    {
                        byte[] docData = (byte[])viewDoc_rdr["pdf_doc"];  /*resume pdf*/

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", docData.Length.ToString());
                        Response.BinaryWrite(docData);
                    }
                }
            }
            catch (Exception viewDoc_exp)
            {
                Response.Write("<script>alert('viewDoc_exp Occured , Report to admin')</script>");
                Console.Write(viewDoc_exp.Message);
            }
            finally
            {
                viewDoc_rdr.Close();
                viewDoc_cmd.Connection.Close();
                viewDoc_con.Close();
            }
        }


    }
}