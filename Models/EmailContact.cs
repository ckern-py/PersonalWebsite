using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
