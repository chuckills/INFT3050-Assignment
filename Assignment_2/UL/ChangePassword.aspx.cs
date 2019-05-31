using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            bool status = false;
            if (IsValid)
            {
                // Get current user from the session
                BLUser user = HttpContext.Current.Session["CurrentUser"] as BLUser;
                string newPassword = Password2TextBox.Text;
                // Run and learn success status
                status = BLUser.updateUserPassword(user, newPassword);
            }

            if (status)
                Response.Redirect("~/UL/Status?status=success");
            else
                Response.Redirect("~/UL/Status?status=failed");
        }
    }
}