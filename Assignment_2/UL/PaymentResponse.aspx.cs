using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class PaymentResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page only accessible by logged in user
            if (Session["LoginStatus"].Equals("User"))
            {
                lblResult.Text = Session["Result"].ToString();
            }
            else
            {
                Response.Redirect("~/UL/ErrorPage/0");
            }
        }
    }
}