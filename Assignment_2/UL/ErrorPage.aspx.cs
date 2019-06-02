﻿using System;
using System.Collections.Generic;
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
            if (!string.IsNullOrEmpty(Request.QueryString["status"]))
            {
                int errorCode = Int32.Parse(Request.QueryString["status"]);

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

        protected void defaultError()
        {
            StatusLabel.Text = "Error";
            DescriptionLabel.Text = "Sorry, something has gone wrong...";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void unauthorized()
        {
            StatusLabel.Text = "Error: Unauthorized";
            DescriptionLabel.Text = "The page you have requested requires a user to be logged in.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void emailFailure()
        {
            StatusLabel.Text = "Error: Failed to send email";
            DescriptionLabel.Text = "Something went wrong in trying to send an email to the email " +
                "address specified for your account. Please ensure you have a valid email attached to your account.";
            ResultingButton.Text = "Check Email";
            ResultingButton.PostBackUrl = "~/UL/AccountSettings";
        }

        protected void verificationError()
        {
            StatusLabel.Text = "Error: Account verification failure";
            DescriptionLabel.Text = "Our efforts to verify your account failed. This is most likely due to a safety" +
                " precaution in attempt to protect your account.";
            ResultingButton.Text = "Return Home";
            ResultingButton.PostBackUrl = "~/UL/Default";
        }

        protected void passwordNotUpdated()
        {
            StatusLabel.Text = "Error: Password Update Failure";
            DescriptionLabel.Text = "User password was unable to be updated at this time.";
            ResultingButton.Text = "Try Again";
            ResultingButton.PostBackUrl = "~/UL/ChangePassword";
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