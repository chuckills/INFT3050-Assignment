using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Not a page featured in the Admin site
            if (Session["LoginStatus"].Equals("Admin"))
            {
                Response.Redirect("~/UL/ErrorPage/5");
            }
        }
    }
}