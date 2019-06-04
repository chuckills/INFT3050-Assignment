using Assignment_2.BL;
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
                // Check if email exists in the system; reload page and display error if not -- X

                // If exists, update password to random generated string; password is hashed for security
                string randomCode = BLPassword.RandomString(10, true);

                // Retrieve user corresponding to email address of account and update password
                BLUser user = new BLUser();
                user = user.getUserByEmail(EmailTextBox.Text);
                BLUser.updateUserPassword(user, randomCode);

                // Attach email address and hashed password as parameters for url to update password (sent in the email)
                BLEmail email = new BLEmail();

                string mailbody =
                    "<p>"
                    + "Hi,"
                    + "</p>"
                    + "<br/>"
                    + "<p>"
                    + "Below is the verification link needed to update your password (click to update):"
                    + "</p>"
                    + "<p>"
                    + "http://localhost:50446/UL/ChangePassword?email=" + EmailTextBox.Text + "&pass=" + randomCode
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
                    email.SendEmail(EmailTextBox.Text, "Verification Link - JerseySure", mailbody);
                }
                catch (Exception ex)
                {
                    // Display error page for unable to send email
                    Response.Redirect("~/UL/ErrorPage?status=1");
                }
                

                // Display success status of email being sent
                Response.Redirect("~/UL/SuccessPage?status=0");
            }
        }

        protected void checkExists(object sender, ServerValidateEventArgs args)
        {
            // Checks if a registered account exists for the email entered
            args.IsValid = BLUser.checkUserEmail(args.Value);
        }
    }
}