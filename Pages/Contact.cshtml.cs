using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Models;

namespace PersonalWebsite.Pages
{
    public class ContactModel : PageModel
    {
        public string SubmitStatus { get; set; }

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
                //send the email or something  
                SubmitStatus = "Email has been sent";
            }
            else
            {
                SubmitStatus = "Some information seems to be missing. Please make sure all fields are filled out.";
            }
        }
    }
}
