using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PersonalWebsite.Data;
using PersonalWebsite.Domain;
using PersonalWebsite.Models;

namespace PersonalWebsite.Pages
{
    public class ContactModel : PageModel
    {
        public string SubmitStatus { get; set; }
        private readonly IConfiguration _config;

        public ContactModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet()
        {
            SubmitStatus = string.Empty;
        }

        [BindProperty]
        public EmailContact ContactEmail { get; set; }

        public void OnPost()
        {
            if (ContactEmail.IsValid())
            {
                IEmail email = new Email(_config);
                email.SendContactMeEmail(ContactEmail);
                SubmitStatus = "Email has been sent";
            }
            else
            {
                SubmitStatus = "Some information seems to be missing. Please make sure all fields are filled out.";
            }
        }
    }
}
