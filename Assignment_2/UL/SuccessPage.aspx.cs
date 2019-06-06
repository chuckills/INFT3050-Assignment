using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class SuccessPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RouteData.Values["status"].ToString()))
            {
                int successCode = Convert.ToInt32(RouteData.Values["status"]);

                switch (successCode)
                {
                    case 0:
                        verificationSent();
                        break;
                    case 1:
                        passwordUpdated();
                        break;
                    case 2:
                        contactSent();
                        break;
                    case 3:
                        adminAdded();
                        break;
                    default:
                        defaultSuccess();
                        break;
                }
            }
            else
            {
                noTransactionMade();
            }
        }

        protected void defaultSuccess()
        {
            StatusLabel.Text = "Status: Success";
            DescriptionLabel.Text = "Action performed was successful...";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void verificationSent()
        {
            StatusLabel.Text = "Verification Email Sent";
            DescriptionLabel.Text = "A verification email was successfully sent to the specified email address.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void passwordUpdated()
        {
            StatusLabel.Text = "Password Updated";
            DescriptionLabel.Text = "Your password has been successfully updated.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void contactSent()
        {
            StatusLabel.Text = "Contact Form Sent";
            DescriptionLabel.Text = "Your enquiry has been submitted and we will be sure to get back to you " +
                "as soon as we can.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void adminAdded()
        {
            StatusLabel.Text = "Admin Account Added";
            DescriptionLabel.Text = "Admin account has been verified by email and successfully added to our system.";
            ResultingButton.Text = "View Accounts";
            ResultingButton.PostBackUrl = "~/UL/AdminManageUserAccounts";
        }

        protected void noTransactionMade()
        {
            StatusLabel.Text = "No Transaction Made";
            DescriptionLabel.Text = "Nothing has been executed within our system to report on.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }
    }
}