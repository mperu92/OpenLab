using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services; // Need to add this on DAL
using OpenLab.DAL.EF;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OpenLab.Services.Services
{
    public class EmailService : IEmailSender
    {
        public IAppConfiguration _appConfiguration;

        public EmailService(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridMessage myMessage = new SendGridMessage();
            myMessage.From = new EmailAddress("register@openlab.com");
            myMessage.AddTo(email);
            myMessage.Subject = subject;
            myMessage.HtmlContent = htmlMessage;

            // Send email
            string apiKey = _appConfiguration.SendGridApiKey;
            SendGridClient client = new SendGridClient(apiKey);
            Response response = await client.SendEmailAsync(myMessage);
        }
    }
}
