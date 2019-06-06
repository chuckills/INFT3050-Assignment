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
            // Check if query parameter exists
            if (RouteData.Values["vc"] != null)
            {
                // Get query parameter
                string queryParameter = RouteData.Values["vc"].ToString();

                if (Session["VCode"] != null && Session["TempAdmin"] != null)
                {
                    // Get temp data stored in session for admin registration
                    string verificationCode = Session["VCode"].ToString();
                    BLUser user = Session["TempAdmin"] as BLUser;

                    if (verificationCode.Equals(queryParameter))
                    {
                        // Add admin account
                        BLUser.addUser(user);
                        // Destroy temp data in session
                        Session.Remove("VCode");
                        Session.Remove("TempAdmin");
                        // Admin account successfully verified and added
                        Response.Redirect("~/UL/SuccessPage/3");
                    }
                    else
                    {
                        // Security measure - remove temp data from session?
                        Session.Remove("VCode");
                        Session.Remove("TempAdmin");

                        // Security error - wrong query parameter for verification code
                        Response.Redirect("~/UL/ErrorPage/2");
                    }
                }
                else
                {
                    // Error to represent that verification code and user are not stored
                    // correctly in the session
                    Response.Redirect("~/UL/ErrorPage/100"); // Default error page
                }
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
                string verificationCode = BLPassword.RandomString(10, true);
                string mailbody =
                    "<p>"
                    + "Hi,"
                    + "</p>"
                    + "<br/>"
                    + "<p>"
                    + "Below is the verification link needed to update your password (click to update):"
                    + "</p>"
                    + "<p>"
                    + "http://localhost:50446/UL/AdminRegistration/" + verificationCode
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
		            userPassword = tbxPassword.Text,
		            userAdmin = true,
		            userActive = true
	            };

                // Add data to session
                Session["TempAdmin"] = newUser;
                Session["VCode"] = verificationCode;

                // View saying verification email has been sent
				Response.Redirect("~/UL/SuccessPage/0");
            }
        }
    }
}