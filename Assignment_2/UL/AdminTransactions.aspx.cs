using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class AdminTransactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page only accessible by admin
            if (!Session["LoginStatus"].Equals("Admin"))
            {
                Response.Redirect("~/UL/ErrorPage/5");
            }
        }
    }
}