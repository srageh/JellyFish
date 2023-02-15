using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net.Http;


namespace JellyFish.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp-mail.outlook.com", //or another email sender provider
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("jellyfishjob_s@outlook.com", "Aresk34#"),
           
        };

            return client.SendMailAsync("jellyfishjob_s@outlook.com", email, subject, htmlMessage);
        }
    }
}
