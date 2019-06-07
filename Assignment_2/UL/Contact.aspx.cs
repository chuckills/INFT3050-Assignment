using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Request.IsSecureConnection)
			{
				// Page is not accessible on admin site
				if (!Session["LoginStatus"].Equals("Admin"))
				{
                    if (Session["LoginStatus"].Equals("User"))
                    {
                        BLUser user = Session["CurrentUser"] as BLUser;
                        tbxName.Text = user.userFirstName + " " + user.userLastName;
                        tbxName.Enabled = false;
                        tbxEmail.Text = user.userEmail;
                    }
                }
                else
                {
                    Response.Redirect("~/UL/ErrorPage/5");
                }
			}
			else
			{
				// Make connection unsecured if it isn't already
				string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Contact";
				Response.Redirect(url);

			}
		}

        // Redirect to contact enquiry received message
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Send email with query information

                // Generate message body for email
                string mailbody =
                      "<p>"
                    + tbxName.Text + ","
                    + "</p>"
                    + "<p>"
                    + "This is a courtesy email to inform you that we have "
                    + "received your enquiry and will respond within two business days."
                    + "</p>"
                    + "<br/>"
                    + "<p>"
                    + "Outlined below is a summary of your submitted enquiry:"
                    + "</p>"
                    + "<p>"
                    + "\"" + tbxQuery.Text + "\""
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
                    BLEmail.SendEmail(tbxEmail.Text, "Contact Form Query - JerseySure", mailbody);
                }
                catch (Exception ex)
                {
                    // Display error page for unable to send email
                    Response.Redirect("~/UL/ErrorPage/1");
                }

                Response.Redirect("~/UL/SuccessPage/2");
            }
        }
    }
}