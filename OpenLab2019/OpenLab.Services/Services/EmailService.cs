using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services; // Need to add this on DAL
using OpenLab.DAL.EF;
using OpenLab.Services.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OpenLab.Services.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendGridMessage myMessage);
        Task<bool> SendWelcomeConfirmEmail(string email, string subject, Uri callbackUrl, string username = null, string password = null);
    }

    public class EmailService : IEmailService
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IWebHostEnvironment _env;

        private string _webRootPath;
        private string _pathToFile;

        public EmailService(IAppConfiguration appConfiguration, IWebHostEnvironment env)
        {
            _webRootPath = string.Empty;
            _pathToFile = string.Empty;

            _appConfiguration = appConfiguration;
            _env = env;
            
            if (_env != null)
            {
                _webRootPath = _env.WebRootPath;
                _pathToFile = $"{_webRootPath}{Path.DirectorySeparatorChar}Templates{Path.DirectorySeparatorChar}EmailTemplate{Path.DirectorySeparatorChar}";
            }
        }

        public async Task<bool> SendWelcomeConfirmEmail(string email, string subject, Uri callbackUrl, string username = null, string password = null)
        {
            string htmlFile = $"{_pathToFile}WelcomeConfirmEmail.html";
            string htmlContent = string.Empty;

            using (StreamReader streamReader = File.OpenText(htmlFile))
                htmlContent = await streamReader.ReadToEndAsync().ConfigureAwait(false);

            SendGridMessage myMessage = new SendGridMessage();
            myMessage.From = new EmailAddress("register@openlab.com");
            myMessage.AddTo(email);
            myMessage.Subject = subject;
            if (!string.IsNullOrEmpty(htmlContent))
                myMessage.HtmlContent = string.Format(new AcctNumberFormat(), htmlContent, username, username, password, callbackUrl);
            else
                return false;

            await SendEmailAsync(myMessage).ConfigureAwait(false);
            return true;
        }

        public async Task SendEmailAsync(SendGridMessage myMessage)
        {
            // Send email
            string apiKey = _appConfiguration.EmailKey;
            SendGridClient client = new SendGridClient(apiKey);
            Response response = await client.SendEmailAsync(myMessage).ConfigureAwait(false);
        }
    }
}
