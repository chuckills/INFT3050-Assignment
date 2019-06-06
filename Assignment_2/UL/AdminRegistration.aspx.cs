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
            // Page only accessible by admin
            if (!Session["LoginStatus"].Equals("Admin"))
            {
                Response.Redirect("~/UL/ErrorPage/5");
            }
        }

        protected void checkExists(object sender, ServerValidateEventArgs args)
        {
	        args.IsValid = BLUser.checkUser(args.Value) == 0;
        }

		// Handles submission of admin registration form
		protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string password = BLPassword.RandomString(10, true);
                string mailbody =
                    "<p>"
                    + "Hi,"
                    + "</p>"
                    + "<br/>"
                    + "<p>"
                    + "Below is the verification link needed to update your password (click to update):"
                    + "</p>"
                    + "<p>"
                    + "http://localhost:50446/UL/ChangePassword/" + tbxUsername.Text +"/" +password
                    + "</p>"
                    + "<br/>"
                    + "<p>"
                    + "Kind Regards,"
                    + "</p>"
                    + "<p>"
                    + "The JerseySure Team"
                    + "</p>";

                
                try
                {
                    BLEmail.SendEmail(tbxUsername.Text, "Admin Verification Link - JerseySure", mailbody);
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/UL/ErrorPage/1");
                }
                
                
                BLUser newUser = new BLUser
	            {
		            userFirstName = tbxFirstName.Text,
		            userLastName = tbxLastName.Text,
		            userEmail = tbxUsername.Text,
		            userPhone = tbxPhone.Text,
		            billAddress = null,
		            postAddress = BLAddress.fillAddress('P', tbxAddress.Text, tbxSuburb.Text, ddlState.SelectedValue, Convert.ToInt32(tbxPostCode.Text)),
		            userPassword = password,
		            userAdmin = true,
		            userActive = true
	            };

                // Add admin account
                BLUser.addUser(newUser);

                // View saying verification email has been sent
                Response.Redirect("~/UL/SuccessPage/0");
            }
        }
    }
}