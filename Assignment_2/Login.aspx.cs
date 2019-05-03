using Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Checks login credentials and updates login status accordingly if it correct
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Values from the login input
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;

                // Get default credentials for user and admin 
                User customer = HttpContext.Current.Session["User"] as User;
                User admin = HttpContext.Current.Session["Admin"] as User;

                if (username.Equals(customer.Username) && password.Equals(customer.Password))
                {
                    // Check if customer
                    HttpContext.Current.Session["LoginStatus"] = "User";
                    Response.Redirect("~/Default.aspx");
                }
                else if (username.Equals(admin.Username) && password.Equals(admin.Password))
                {
                    // Check if admin
                    HttpContext.Current.Session["LoginStatus"] = "Admin";
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    // Login unsuccessful
                    LoginErrorLabel.Text = "Login credentials are incorrect. Try again.";
                }
            }
        }
    }
}