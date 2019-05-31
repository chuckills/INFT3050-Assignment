using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace Assignment_2.UL
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Redirect to contact enquiry received message
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Send email with query information
                // Sourced from: https://www.c-sharpcorner.com/UploadFile/2a6dc5/how-to-send-a-email-using-Asp-Net-C-Sharp/
                string to = tbxEmail.Text;
                string from = "jerseysure3050@gmail.com";

                MailMessage message = new MailMessage(from, to);

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

                message.Subject = "Contact Form Query - JerseySure";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("jerseysure3050@gmail.com", "MoreSecurePassword");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                Response.Redirect("~/UL/ContactResponse.aspx");
            }
        }
    }
}