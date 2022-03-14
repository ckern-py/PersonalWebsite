using Microsoft.Extensions.Configuration;
using PersonalWebsite.Domain;
using PersonalWebsite.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;

namespace PersonalWebsite.Data
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendContactMeEmail(EmailContact emailContactInfo)
        {
            string apiKey = _configuration["SendgridAPIKey"];
            SendGridClient client = new SendGridClient(apiKey);

            string websiteEmail = _configuration["WebsiteEmailAddress"];
            SendGridMessage emailMessage = new SendGridMessage()
            {
                From = new EmailAddress(websiteEmail, "ColinK_PersonalWebsite"),
                Subject = "New web inquiry",
                PlainTextContent = $"New email from {emailContactInfo.PersonEmail}.\n\nSubject: {emailContactInfo.EmailSubject}.\n\nMessage: {emailContactInfo.EmailMessage}"
            };

            string receivingEmail = _configuration["MyEmail"];
            emailMessage.AddTo(new EmailAddress(receivingEmail));

            client.SendEmailAsync(emailMessage);
        }
    }
}
