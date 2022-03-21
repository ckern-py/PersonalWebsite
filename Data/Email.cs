using Microsoft.Extensions.Configuration;
using PersonalWebsite.Domain;
using PersonalWebsite.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

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
            string apiKey = _configuration["SENDGRID_API_KEY"];
            SendGridClient client = new SendGridClient(apiKey);

            string websiteEmail = _configuration["WEBSITE_EMAIL_ADDRESS"];
            SendGridMessage emailMessage = new SendGridMessage()
            {
                From = new EmailAddress(websiteEmail, "ColinK_PersonalWebsite"),
                Subject = "New web inquiry",
                PlainTextContent = $"New email from {emailContactInfo.PersonEmail}.\n\nSubject: {emailContactInfo.EmailSubject}.\n\nMessage: {emailContactInfo.EmailMessage}"
            };

            string receivingEmail = _configuration["MY_EMAIL"];
            emailMessage.AddTo(new EmailAddress(receivingEmail));

            client.SendEmailAsync(emailMessage);
        }
    }
}
