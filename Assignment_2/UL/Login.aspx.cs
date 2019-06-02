using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        UsernameTextBox.Focus();
        }

        // Checks login credentials and updates login status accordingly if it correct
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
				BLUser user = new BLUser();

				int result = user.login(UsernameTextBox.Text, PasswordTextBox.Text);

				switch (result)
				{
					case(0):
						LoginErrorLabel.Text = "Username does not exist. Try again.";
						break;
					case (-1):
						LoginErrorLabel.Text = "Password incorrect. Try again.";
						break;
					case (-2):
						LoginErrorLabel.Text = "User account is suspended. Contact admin.";
						break;
					default:
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
						Response.Redirect("~/UL/Default");
						break;
				}
            }
        }

        protected void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/ForgotPassword");
        }
    }
}