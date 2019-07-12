using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobSurfer.W_WebFormControl
{
    public partial class WFC_Company : System.Web.UI.UserControl
    {
        static int counter = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                counter = 1;
            }
        }

        protected void ButA1_3_Click(object sender, EventArgs e)
        {
            
            if (counter == 1)
            {
                ImgA1_3.Visible = false;
                ImgC1_3.Visible = false;
                ImgB1_3.Visible = true;
                ButA1_3.Visible = true;
                ButB1_3.Visible = false;
            }
            else if(counter == 2)
            {
                ImgA1_3.Visible = false;
                ImgB1_3.Visible = false;
                ImgC1_3.Visible = true;
                ButA1_3.Visible = true;
                ButB1_3.Visible = false;
            }
            else if(counter == 3)
            {
                ImgA1_3.Visible = false;
                ImgB1_3.Visible = false;
                ImgC1_3.Visible = true;
                ButA1_3.Visible = false;
                ButB1_3.Visible = true;
            }

            if (counter == 6)
            {
                ImgA1_3.Visible = false;
                ImgC1_3.Visible = false;
                ImgB1_3.Visible = true;
                ButA1_3.Visible = true;
                ButB1_3.Visible = false;
                counter = 1;
            }

            counter++;
        }

        protected void ButB1_3_Click(object sender, EventArgs e)
        {
            if (counter == 4)
            {
                ImgA1_3.Visible = false;
                ImgB1_3.Visible = true;
                ImgC1_3.Visible = false;
                ButA1_3.Visible = false;
                ButB1_3.Visible = true;
            }
            else if (counter == 5)
            {
                ImgA1_3.Visible = true;
                ImgB1_3.Visible = false;
                ImgC1_3.Visible = false;
                ButA1_3.Visible = true;
                ButB1_3.Visible = false;
            }

            counter++;
        }
    }
}