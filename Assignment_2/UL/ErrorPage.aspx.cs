using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Request.IsSecureConnection)
			{
				if (!string.IsNullOrEmpty(RouteData.Values["status"].ToString()))
				{
					int errorCode = Convert.ToInt32(RouteData.Values["status"]);

					switch (errorCode)
					{
						case 0:
							unauthorized();
							break;
						case 1:
							emailFailure();
							break;
						case 2:
							verificationError();
							break;
						case 3:
							passwordNotUpdated();
							break;
						case 4:
							checkoutNotAvailable();
							break;
						case 5:
							wrongLoginStatus();
							break;
						case 6:
							notSecureConnection();
							break;
                        case 7:
                            purchaseNotAvailable();
                            break;
                        default:
							defaultError();
							break;
					}
				}
				else
				{
					noTransactionMade();
				}
			}
			else
			{
				// Make connection unsecured if it isn't already
				string url = ConfigurationManager.AppSettings["UnsecurePath"] + "ErrorPage/" + RouteData.Values["status"];
				Response.Redirect(url);

			}

		}

        protected void defaultError()
        {
            StatusLabel.Text = "Error";
            DescriptionLabel.Text = "Sorry, something has gone wrong...";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void unauthorized()
        {
            StatusLabel.Text = "Sorry, Unauthorized";
            DescriptionLabel.Text = "The page you have requested requires a user to be logged in.";
            ResultingButton.Text = "Login";
            ResultingButton.PostBackUrl = "~/UL/Login";
        }

        protected void emailFailure()
        {
            StatusLabel.Text = "Sorry, Failed to send email";
            DescriptionLabel.Text = "Something went wrong in trying to send an email to the email " +
                "address specified for your account. Please ensure you have a valid email attached to your account.";
            ResultingButton.Text = "Check Email";
            ResultingButton.PostBackUrl = "~/UL/AccountSettings";
        }

        protected void verificationError()
        {
            StatusLabel.Text = "Sorry, Account verification failure";
            DescriptionLabel.Text = "Our efforts to verify your account failed. This is most likely due to a safety" +
                " precaution in attempt to protect your account.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void passwordNotUpdated()
        {
            StatusLabel.Text = "Sorry, Password Update Failure";
            DescriptionLabel.Text = "User password was unable to be updated at this time.";
            ResultingButton.Text = "Try Again";
            ResultingButton.PostBackUrl = "~/UL/ChangePassword";
        }

        protected void checkoutNotAvailable()
        {
            StatusLabel.Text = "Sorry, Unable to Checkout";
            DescriptionLabel.Text = "Checkout can only be completed by a registered account.";
            ResultingButton.Text = "Login";
            ResultingButton.PostBackUrl = "~/UL/Login";
        }

        protected void wrongLoginStatus()
        {
            StatusLabel.Text = "Sorry, Page not available";
            DescriptionLabel.Text = "The page you are trying to access is not available according to your" +
                " current login status.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void purchaseNotAvailable()
        {
            StatusLabel.Text = "Sorry, Page not available";
            DescriptionLabel.Text = "Purchase is unable to be made until products are added to cart.";
            ResultingButton.Text = "Start Shopping";
            ResultingButton.PostBackUrl = "~/UL/Products";
        }

        protected void notSecureConnection()
        {
            StatusLabel.Text = "Sorry, Secure connection is required";
            DescriptionLabel.Text = "The page being request requires a secure connection in order to be viewed.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
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