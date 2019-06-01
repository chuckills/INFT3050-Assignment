using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RequestButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Check if email exists in the system; reload page and display error if not

                // If exists, update password to random generated string

                // Attach email address and hashed password as parameters for url to update password
                // Check and only allow if they match
            }
        }
    }
}