using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
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
	            BLUser newUser = new BLUser
	            {
		            userFirstName = tbxFirstName.Text,
		            userLastName = tbxLastName.Text,
		            userEmail = tbxUsername.Text + "@jerseysure.com.au",
		            userPhone = tbxPhone.Text,
		            billAddress = null,
		            postAddress = BLAddress.fillAddress('P', tbxAddress.Text, tbxSuburb.Text, ddlState.SelectedValue, Convert.ToInt32(tbxPostCode.Text)),
		            userPassword = tbxPassword.Text,
		            userAdmin = true,
		            userActive = true
	            };

	            BLUser.addUser(newUser);

	            newUser.login(newUser.userEmail, newUser.userPassword);

	            Session["CurrentUser"] = newUser;
	            Session["UserName"] = newUser.userEmail;
	            Session["LoginStatus"] = "Admin";

				Response.Redirect("~/UL/Default");
            }
        }
    }
}