using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

/// <summary>
/// Class to provide email capabilities for the ASP.net application.
/// </summary>

namespace Assignment_2.BL
{
    public class BLEmail
    {
        /// <summary>
        /// Sends an email according to the properties defined by the given parameters. Emails are sent from a default
        /// JerseySure account: jerseysure3050@gmail.com
        /// Sourced from: https://www.c-sharpcorner.com/UploadFile/2a6dc5/how-to-send-a-email-using-Asp-Net-C-Sharp/
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="mailbody"></param>
        public static void SendEmail(string to, string subject, string mailbody)
        {
            // Send email with query information
            string from = "jerseysure3050@gmail.com";

            // Define general properties of email
            MailMessage message = new MailMessage(from, to);

            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            // Define SMTP properties of email
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("jerseysure3050@gmail.com", "MoreSecurePassword");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            // Attempt to send
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}