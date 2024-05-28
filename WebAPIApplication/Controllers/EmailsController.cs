using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        [HttpGet("apiSendEmail")]
        public ActionResult SendEmail()
        {
            send_mail();
            return Ok();
        }

        public void send_mail()
        {
            try
            {
                // SMTP server configuration
                string smtpServer = "***"; // Brevo SMTP server
                int smtpPort = 587; // SMTP port
                string smtpUsername = "***"; // Your Brevo SMTP username
                string smtpPassword = "***"; // Your Brevo SMTP password

                // Email message configuration
                string fromEmail = "***"; // Sender email address
                string toEmail = "***"; // Recipient email address
                string subject = "Test Email from Brevo SMTP";
                string body = "This is a test email sent using Brevo SMTP service.";

                // Create a new MailMessage object
                MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);

                // Configure the SmtpClient
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true // Enable SSL for secure email sending
                };

                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
