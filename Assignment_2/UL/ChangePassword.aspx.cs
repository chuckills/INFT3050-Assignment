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
            if (!(string.IsNullOrEmpty(RouteData.Values["email"].ToString())
                && string.IsNullOrEmpty(RouteData.Values["pass"].ToString())))
            {
                // Get request parameters
                string email = RouteData.Values["email"].ToString();
                string password = RouteData.Values["pass"].ToString();

                // Retrieve user corresponding to email address of account
                BLUser user = new BLUser();
                user = user.getUserByEmail(email);

                // Check password

                int result = user.login(email, password);

                switch (result)
                {
                    case (0):
                        // Username does not exist
                        Response.Redirect("~/UL/ErrorPage/2");
                        break;
                    case (-1):
                        // Incorrect password
                        Response.Redirect("~/UL/ErrorPage/2");
                        break;
                    case (-2):
                        // Suspended account
                        Response.Redirect("~/UL/ErrorPage/2");
                        break;
                    default:
                        // Allow update password - create temporary login
                        HttpContext.Current.Session["TempUser"] = user;
                        break;
                }
            }
            else
            {
                if (HttpContext.Current.Session["CurrentUser"] == null)
                {
                    // Unauthorised
                    Response.Redirect("~/UL/ErrorPage/0");
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            bool status = false;
            if (IsValid)
            {
                if (!Session["LoginStatus"].Equals("LoggedOut"))
                {
                    // Get current user from the session
                    BLUser user = HttpContext.Current.Session["CurrentUser"] as BLUser;
                    string newPassword = Password2TextBox.Text;
                    // Run and learn success status
                    status = BLUser.updateUserPassword(user, newPassword);
                }
                else
                {
                    if (Session["TempUser"] != null)
                    {
                        // Get current user from the session
                        BLUser user = HttpContext.Current.Session["TempUser"] as BLUser;
                        string newPassword = Password2TextBox.Text;
                        // Run and learn success status
                        status = BLUser.updateUserPassword(user, newPassword);
                        HttpContext.Current.Session.Remove("TempUser");

                        // Log user in
                        Session["Name"] = user.userFirstName;
                        Session["CurrentUser"] = user;
                        Session["UserName"] = user.userEmail;
                        if (user.userAdmin)
                        {
                            Session["LoginStatus"] = "Admin";
                        }
                        else
                        {
                            Session["LoginStatus"] = "User";
                        }
                    }
                    else
                    {
                        // Unauthorised
                        Response.Redirect("~/UL/ErrorPage/0");
                    }
                }
            }

            if (status)
                Response.Redirect("~/UL/SuccessPage/1");
            else
                Response.Redirect("~/UL/ErrorPage/3");
        }
    }
}