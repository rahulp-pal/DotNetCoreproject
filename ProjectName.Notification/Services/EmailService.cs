using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using ProjectName.Notification.Interfaces;
using ProjectName.Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectName.Notification.Services
{
    public class EmailService : IEmailSender
    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailService> _logger;
        public EmailService(IEmailConfiguration emailConfiguration, ILogger<EmailService> logger)
        {
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            EmailMessage emailMessage = new EmailMessage();
            List<EmailAddress> fromList = new List<EmailAddress>
            {
                new EmailAddress { Address = "r4rahul1034@gmail.com" }
            };
            List<EmailAddress> toList = new List<EmailAddress>
            {
                new EmailAddress { Address = email }
            };
            emailMessage.ToAddresses = toList;
            emailMessage.FromAddresses = fromList;
            emailMessage.Subject = subject;
            emailMessage.Content = htmlMessage;
            Send(emailMessage);
            return Task.CompletedTask;
        }

        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }

        public void Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                try
                {
                    //The last parameter here is to use SSL (Which you should!)
                    emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                    //Remove any OAuth functionality as we won't be using it.
                    _ = emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                    emailClient.Send(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    throw;
                }
                finally
                {
                    emailClient.Disconnect(true);
                    emailClient.Dispose();
                }
            }
        }
    }
}
