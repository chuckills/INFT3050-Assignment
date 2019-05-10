using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class AdminRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Handles submission of admin registration form
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}