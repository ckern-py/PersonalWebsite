using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PersonalWebsite.Data;
using PersonalWebsite.Domain;
using PersonalWebsite.Models;

namespace PersonalWebsite.Pages
{
    public class ContactModel : PageModel
    {
        public string SubmitStatus { get; set; }

        private readonly ILogger<ContactModel> _logger;

        private readonly IConfiguration _config;

        public ContactModel(ILogger<ContactModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {
            SubmitStatus = string.Empty;
            IStatsAPI statsAPI = new StatsAPI(_config);
            statsAPI.RecordPageVisit("Contact");
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
