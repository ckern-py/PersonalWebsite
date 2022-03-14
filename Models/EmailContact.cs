using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Models
{
    public class EmailContact
    {
        [BindProperty]
        public string PersonEmail { get; set; }
        [BindProperty]
        public string EmailSubject { get; set; }
        [BindProperty]
        public string EmailMessage { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(PersonEmail) || string.IsNullOrWhiteSpace(EmailSubject) || string.IsNullOrWhiteSpace(EmailMessage))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
