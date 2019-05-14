using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
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
				BLLogin login = new BLLogin();
				
				bool status;

				int result = login.login(UsernameTextBox.Text, PasswordTextBox.Text, out status);

				switch (result)
				{
					case(0):
						LoginErrorLabel.Text = "Username does not exist. Try again.";
						break;
					case (-1):
						LoginErrorLabel.Text = "Password incorrect. Try again.";
						break;
					default:
						Session["UserName"] = UsernameTextBox.Text;
						Session["UserID"] = result.ToString();
						if (status)
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
    }
}